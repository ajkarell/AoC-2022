rucksacks = open("input.txt").read().splitlines()

a_to_z = list(map(chr, range(ord('a'), ord('z') + 1)))
A_to_Z = list(map(chr, range(ord('A'), ord('Z') + 1)))

item_priorities = dict(zip(a_to_z + A_to_Z, range(1, 53)))

total = 0

for rucksack in rucksacks:
    midpoint = int(len(rucksack) / 2)

    first_compartment = rucksack[:midpoint]
    second_compartment = rucksack[midpoint:]

    unique_item_types = list(set(rucksack))

    for item_type in unique_item_types:
        if first_compartment.count(item_type) > 0 and second_compartment.count(item_type) > 0:
            total += item_priorities[item_type]

print(f"Part 1: {total}")
