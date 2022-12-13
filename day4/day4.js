const fs = require("fs");

const toRange = (assignmentString) => {
  const range = assignmentString.split("-").map(Number); // parseInt() returns NaN.. (for reasons unbeknownst to me)
  return {
    start: range[0],
    end: range[1],
  };
};

const toRangePairs = (pairString) => pairString.split(",").map(toRange);

const isOverlappingRangePair = (rangePair) => {
  const A = rangePair[0];
  const B = rangePair[1];

  const magnitudeA = A.end - A.start;
  const magnitudeB = B.end - B.start;

  if (magnitudeA >= magnitudeB) {
    return A.start <= B.start && B.end <= A.end;
  } else {
    return B.start <= A.start && A.end <= B.end;
  }
};

fs.readFile("input.txt", "utf8", (err, input) => {
  if (err) {
    console.error(err);
    return;
  }

  const numOverlaps = input
    .split("\n")
    .filter((line) => line.length > 0)
    .map(toRangePairs)
    .filter(isOverlappingRangePair).length;

  console.log(numOverlaps);
});
