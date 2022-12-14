signal = open("input.txt").read()

length = len(signal)

for head in range(3, length):
    tail = head - 3
    uniques = set(signal[tail:head + 1])
    if len(uniques) == 4:
        print(f"Part 1: {head + 1}")
        break

for head in range(13, length):
    tail = head - 13
    uniques = set(signal[tail:head + 1])
    if len(uniques) == 14:
        print(f"Part 2: {head + 1}")
        break
