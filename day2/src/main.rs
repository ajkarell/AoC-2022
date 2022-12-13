enum Hand {
    Rock = 1,
    Paper = 2,
    Scissors = 3,
}

fn to_hands(round: &str) -> (Hand, Hand) {
    let opponent = match round.chars().nth(0).unwrap() {
        'A' => Hand::Rock,
        'B' => Hand::Paper,
        'C' => Hand::Scissors,
        _ => panic!("Invalid input."),
    };

    let me = match round.chars().nth(2).unwrap() {
        'X' => Hand::Rock,
        'Y' => Hand::Paper,
        'Z' => Hand::Scissors,
        _ => panic!("Invalid input."),
    };

    (opponent, me)
}

fn play(hands: (Hand, Hand)) -> i32 {
    let (opponent, me) = hands;
    match opponent {
        Hand::Rock => match me {
            Hand::Rock => 3 + 1,
            Hand::Paper => 6 + 2,
            Hand::Scissors => 0 + 3,
        },
        Hand::Paper => match me {
            Hand::Rock => 0 + 1,
            Hand::Paper => 3 + 2,
            Hand::Scissors => 6 + 3,
        },
        Hand::Scissors => match me {
            Hand::Rock => 6 + 1,
            Hand::Paper => 0 + 2,
            Hand::Scissors => 3 + 3,
        },
    }
}

fn main() {
    let input = std::fs::read_to_string("input.txt").expect("Input not found.");

    let total_points: i32 = input
        .lines()
        .map(|round| to_hands(round))
        .map(|hands| play(hands))
        .sum();

    println!("{total_points}");
}
