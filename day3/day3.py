rucksacks = open("input.txt").read().splitlines()

a_to_z = list(map(chr, range(ord('a'), ord('z') + 1)))
A_to_Z = list(map(chr, range(ord('A'), ord('Z') + 1)))

item_priorities = dict(zip(a_to_z + A_to_Z, range(1, 53)))

# Part 1

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

# Part 2

groups = zip(*(iter(rucksacks),) * 3) # form a list of groups with 3 rucksacks per group

total_part2 = 0

for group in groups:
    shared_item_type_candidates = list(set(group[0])) # the shared item type must be in the first rucksack
    for candidate in shared_item_type_candidates:
        if all(rucksack.count(candidate) > 0 for rucksack in group):
            total_part2 += item_priorities[candidate]

print(f"Part 2: {total_part2}")