class Program
{
    record Command
    {
        public readonly int Amount;
        public readonly int From;
        public readonly int To;

        public Command(string commandString)
        {
            var parts =
                new String(commandString.Where(c => Char.IsDigit(c) || Char.IsWhiteSpace(c)).ToArray())
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Int32.Parse)
                    .ToArray();

            Amount = parts[0];
            From = parts[1];
            To = parts[2];
        }
    };

    static (Dictionary<int, Stack<char>>, IEnumerable<Command>) ParseInput()
    {
        var input = File.ReadAllText("input.txt");
        var inputParts = input.Split("\n\n");

        var crateArrangement = inputParts[0];

        var TrimPadding = (string crossSection) => new String(crossSection.Where((c, i) => i % 2 == 1).ToArray()); // every other character is padding

        var crossSectionsFlipped = crateArrangement
            .Split('\n')
            .SkipLast(1)
            .Select(TrimPadding)
            .Reverse();

        var crateStacks = new Dictionary<int, Stack<char>> {
            { 1, new Stack<char>() },
            { 2, new Stack<char>() },
            { 3, new Stack<char>() },
            { 4, new Stack<char>() },
            { 5, new Stack<char>() },
            { 6, new Stack<char>() },
            { 7, new Stack<char>() },
            { 8, new Stack<char>() },
            { 9, new Stack<char>() },
        };

        foreach (var crossSection in crossSectionsFlipped)
        {
            for (int x = 0; x < 9; x++)
            {
                var crate = crossSection[x * 2];
                if (Char.IsWhiteSpace(crate))
                    continue;

                crateStacks[x + 1].Push(crate);
            }
        }

        var procedure = inputParts[1]
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(cmdStr => new Command(cmdStr));

        return (crateStacks, procedure);
    }

    public static void Main(string[] args)
    {
        {
            (var crateStacks, var procedure) = ParseInput();

            var movedStacks = MoveWithCrateMover9000(crateStacks, procedure);
            var topCratesPart1 = new String(movedStacks.Select(kv => kv.Value.First()).ToArray());
            Console.WriteLine(topCratesPart1);
        }

        {
            (var crateStacks, var procedure) = ParseInput();

            var movedStacks = MoveWithCrateMover9001(crateStacks, procedure);
            var topCratesPart2 = new String(movedStacks.Select(kv => kv.Value.First()).ToArray());
            Console.WriteLine(topCratesPart2);
        }
    }

    static Dictionary<int, Stack<char>> MoveWithCrateMover9000(Dictionary<int, Stack<char>> crateStacks, IEnumerable<Command> procedure)
    {
        foreach (var command in procedure)
        {
            for (int i = 0; i < command.Amount; i++)
            {
                var grabbed = crateStacks[command.From].Pop();
                crateStacks[command.To].Push(grabbed);
            }
        }

        return crateStacks;
    }

    static Dictionary<int, Stack<char>> MoveWithCrateMover9001(Dictionary<int, Stack<char>> crateStacks, IEnumerable<Command> procedure)
    {
        foreach (var command in procedure)
        {
            var grabbed = new List<char>();

            for (int i = 0; i < command.Amount; i++)
            {
                grabbed.Add(crateStacks[command.From].Pop());
            }

            grabbed.Reverse();

            foreach (var crate in grabbed)
            {
                crateStacks[command.To].Push(crate);
            }
        }

        return crateStacks;
    }
}