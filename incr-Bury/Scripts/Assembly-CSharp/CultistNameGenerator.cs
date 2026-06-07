using UnityEngine;

public class CultistNameGenerator
{
	private static string[] nameBank = new string[514]
	{
		"Hank", "Gary", "Stephen", "Steven", "Steve", "Marcus", "Robert", "Jeff", "Izzy", "Rowan",
		"Vivian", "Brasco", "Dianne", "Ross", "Chad", "Clump", "Rooster", "Alice", "Bob", "Charlie",
		"Daisy", "Eli", "Fiona", "George", "Hazel", "Ian", "Juno", "Kip", "Luna", "Milo",
		"Nora", "Otto", "Penny", "Quinn", "Rex", "Sally", "Toby", "Uma", "Vera", "Waldo",
		"Xena", "Yanni", "Zoe", "Bean", "Crumb", "Pickles", "Bloop", "Snork", "Fizz", "Binky",
		"Chomps", "Puffin", "Toots", "Muffin", "Bumble", "Sprig", "Nibbles", "Zuzu", "Gizmo", "Wiggles",
		"Goober", "Mopsy", "Bobo", "Tinker", "Plunk", "Jellybean", "Scoot", "Pip", "Rubble", "Noodle",
		"Spud", "Momo", "Blorp", "Grover", "Betsy", "Rufus", "Tilly", "Marge", "Dex", "Lenny",
		"Opal", "Poppy", "Rita", "Fritz", "Gertie", "Sunny", "Clove", "Doodle", "Whimsy", "Puddles",
		"Tango", "Razzle", "Boomer", "Snazzy", "Chip", "Marbles", "Skippy", "Womble", "Bruno", "Pixie",
		"Drip", "Bash", "Moosh", "Arlo", "Bitsy", "Clancy", "Doodlebug", "Eugene", "Flapjack", "Gumbo",
		"Hattie", "Indigo", "Juniper", "Kiki", "Lumpy", "Monty", "Nanners", "Ollie", "Peppy", "Quibble",
		"Ringo", "Sprocket", "Tater", "Upton", "Vinnie", "Waffles", "Xoxo", "Yip", "Zigzag", "Banjo",
		"Cricket", "Dottie", "Eggbert", "Flossie", "Gravy", "Hobbes", "Iggy", "Jubilee", "Krum", "Lulu",
		"Munch", "Nugget", "Oopsy", "Panko", "Queenie", "Rubbleton", "Squiggles", "Twinkle", "Umi", "Vroom",
		"Whistle", "Zazzy", "Boingo", "Chumble", "Dimples", "Froodle", "Goose", "Hiccup", "Jelly", "Knobby",
		"Lark", "Mango", "Nuzzle", "Oona", "Puddle", "Quark", "Rumpus", "Snappy", "Tinkerbop", "Umber",
		"Violet", "Wizzle", "Yoyo", "Zorp", "Beppo", "Chili", "Daffy", "Elbow", "Flimsy", "Gribble",
		"Hopper", "Inky", "Jangle", "Kettle", "Lumpyjack", "Mopsydoo", "Nim", "Oob", "Plink", "Quill",
		"Rascal", "Swoop", "Toodle", "Updog", "Vex", "Whippy", "Zoodle", "Bonbon", "Crumbly", "Ducky",
		"Eeps", "Flap", "Grimble", "Hubbub", "Jinx", "Kappa", "Loopy", "Midge", "Nib", "Oatley",
		"Pipette", "Ruffles", "Snorf", "Tangoose", "Upsy", "Voodle", "Wobble", "Yapper", "Zibby", "Brim",
		"Albie", "Bloopa", "Cobb", "Dizzy", "Eclair", "Figgy", "Gubbins", "Hoot", "Itchy", "Jambon",
		"Koodle", "Lolly", "Mimsy", "Norb", "Olive", "Peeb", "Quoodle", "Rambler", "Sprout", "Tippy",
		"Umba", "Vibble", "Wompy", "Xanthe", "Yabble", "Zonk", "Bim", "Clappy", "Doobie", "Eepsy",
		"Fennel", "Grumps", "Hopperly", "Jiffy", "Klink", "Loodle", "Murtle", "Nono", "Ober", "Pocky",
		"Quindle", "Riff", "Snizzle", "Tumble", "Uffa", "Vongo", "Wigbert", "Yuli", "Zabble", "Blinky",
		"Crispin", "Darla", "Eebo", "Fizzle", "Gobbo", "Hilda", "Ippo", "Jorby", "Krumble", "Lem",
		"Mopsykin", "Noodlebug", "Oona-Belle", "Pumper", "Quinko", "Rugsy", "Snoodle", "Tuppy", "Urba", "Vimmy",
		"Woggles", "Yapperly", "Zoodlebug", "Buzzle", "Cloverly", "Dumpling", "Elgar", "Froop", "Grizzle", "Hunny",
		"Inklet", "Jib", "Knotty", "Lunet", "Mumble", "Noggin", "Orbie", "Piffle", "Quirky", "Raffy",
		"Sloop", "Taterbug", "Umberly", "Voodlebug", "Wompus", "Yib", "Zonko", "Blip", "Crumble", "Dibble",
		"Esker", "Fizbit", "Groob", "Hoggle", "Iona", "Jubb", "Kabo", "Lop", "Mim", "Nixie",
		"Oodle", "Ploop", "Quabble", "Rumpy", "Astra", "Bibble", "Clonk", "Darlaine", "Eeboop", "Fennick",
		"Gimble", "Hush", "Izzet", "Jorba", "Kipple", "Lunlo", "Marnie", "Nuzzleton", "Ooble", "Pennybop",
		"Quindleton", "Razz", "Snibble", "Toodlebug", "Umka", "Varn", "Wisp", "Xoba", "Yindle", "Zabbo",
		"Buzzo", "Clem", "Doodledew", "Eskerine", "Flom", "Grinny", "Hortle", "Icky", "Jibbles", "Kleppy",
		"Lumpydoo", "Marn", "Nubby", "Oodlebert", "Plick", "Quarla", "Rimble", "Squee", "Tully", "Umberbee",
		"Vibber", "Wizzleton", "Yobbo", "Zinny", "Brumble", "Chon", "Dipsy", "Elka", "Floopa", "Greeb",
		"Hondo", "Iffy", "Joll", "Kinty", "Lardo", "Mimble", "Nurn", "Olli", "Pumple", "Quinda",
		"Rorby", "Snoot", "Tinkerloo", "Urple", "Vella", "Woop", "Yaddle", "Zorby", "Blon", "Cubbie",
		"Darlo", "Ebb", "Frawny", "Gubble", "Hinnie", "Iska", "Joodle", "Kroop", "Lindle", "Marnu",
		"Nini", "Opper", "Plonka", "Quatch", "Rindle", "Sproop", "Tiffy", "Uzzle", "Vorn", "Waddles",
		"Yim", "Zibbit", "Blarp", "Chort", "Dundle", "Effie", "Frizzle", "Gobby", "Harn", "Iona-Bee",
		"Jelba", "Kwick", "Lommy", "Marnet", "Nerk", "Orla", "Pinkle", "Quindlebee", "Ruppy", "Swizzle",
		"Tarn", "Umpa", "Vindle", "Wimsy", "Yubble", "Zooba", "Paul", "ZaZa", "Bert", "Garfield",
		"Smidgen", "Morty", "Roux", "Pogo", "Meepo", "Tibbers", "Simon", "Gremlin", "Bub", "Bubbo",
		"Squirt", "Paco", "Beef", "Spratt", "Gurkin", "Dilly", "Ruby", "Popy", "Triggsy", "Toast",
		"Spbee", "Terrance", "Allishive", "Billiam", "Willy", "June", "Juneau", "Montgomery", "Pickle", "Boofta",
		"Binko", "Noir", "Worm", "Ed", "Gilbert", "Maurice", "Mister", "Stamps", "Zootie", "Flax",
		"Zipper", "Honk", "Cinnamim", "Babble", "Fido", "Spot", "Lil' Mittens", "Pepper", "Sono", "Figaro",
		"Maggie", "Crab", "Ivan", "Flo"
	};

	public static string PickARandomName()
	{
		int num = Random.Range(0, nameBank.Length);
		return nameBank[num];
	}
}
