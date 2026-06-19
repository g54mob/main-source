using UnityEngine;

namespace TH20
{
	public static class TraitsGenerator
	{
		public static string GenerateFlavourTrait()
		{
			string[] array = new string[7] { "Afraid of", "Addicted to", "Worships", "Outraged by", "In love with", "Allergic to", "Enjoys" };
			string[] array2 = new string[34]
			{
				"ducks", "cheese", "puffins", "biscuits", "armpits", "crisps", "hair", "cress", "beef", "cats",
				"celery", "toothpaste", "milk", "funny worms", "trains", "beards", "feet", "yoghurt", "jazz", "trumpets",
				"sausages", "pants", "sheep", "clowns", "fart juggling", "internet dating", "murder", "tap dancing", "owls", "ghosts",
				"aliens", "hobgoblins", "robots", "jungle music"
			};
			return $"{array[Random.Range(0, array.Length)]} {array2[Random.Range(0, array2.Length)]}";
		}
	}
}
