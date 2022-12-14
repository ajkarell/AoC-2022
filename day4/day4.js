const fs = require("fs");

const toRange = (assignmentString) => {
  const range = assignmentString.split("-").map(Number); // parseInt() returns NaN.. (for reasons unbeknownst to me)
  return {
    start: range[0],
    end: range[1],
    magnitude: range[1] - range[0],
  };
};

const toRangePairs = (pairString) => pairString.split(",").map(toRange);

const isFullyOverlapping = (rangePair) => {
  const A = rangePair[0];
  const B = rangePair[1];

  if (A.magnitude >= B.magnitude) {
    return A.start <= B.start && B.end <= A.end;
  } else {
    return B.start <= A.start && A.end <= B.end;
  }
};

const isOverlapping = (rangePair) => {
  const A = rangePair[0];
  const B = rangePair[1];

  if (A.start <= B.start) {
    return A.end >= B.start;
  } else {
    return B.end >= A.start;
  }
};

fs.readFile("input.txt", "utf8", (err, input) => {
  if (err) {
    console.error(err);
    return;
  }

  const overlappingRangePairs = input
    .split("\n")
    .filter((line) => line.length > 0)
    .map(toRangePairs)
    .filter(isOverlapping);

  const numFullOverlaps =
    overlappingRangePairs.filter(isFullyOverlapping).length;

  console.log(`Part 1: ${numFullOverlaps}`);
  console.log(`Part 2: ${overlappingRangePairs.length}`);
});
