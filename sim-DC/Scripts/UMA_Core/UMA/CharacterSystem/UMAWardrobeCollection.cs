using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class UMAWardrobeCollection : UMATextRecipe
	{
		[Tooltip("Cover images for the collection as a whole. Use these for a promotional images for this collection, presenting the goodies inside.")]
		public List<Sprite> coverImages;

		public WardrobeCollectionList wardrobeCollection;

		[Tooltip("WardrobeCollections can also contain an arbitrary list of wardrobeRecipes, not associated with any particular race.You can use this to make a 'hairStyles' pack or a 'tattoos' pack for example")]
		public List<string> arbitraryRecipes;

		public Sprite GetCoverImage(int desiredIndex = 0)
		{
			return null;
		}

		public void EnsureLocalAvailability(string forRace = "")
		{
		}

		public List<WardrobeSettings> GetRacesWardrobeSet(string race)
		{
			return null;
		}

		public List<WardrobeSettings> GetRacesWardrobeSet(RaceData race)
		{
			return null;
		}

		public List<string> GetRacesRecipeNames(string race)
		{
			return null;
		}

		public List<UMATextRecipe> GetRacesRecipes(string race)
		{
			return null;
		}

		public List<string> GetArbitraryRecipesNames()
		{
			return null;
		}

		public List<UMATextRecipe> GetArbitraryRecipes(DynamicCharacterSystem dcs)
		{
			return null;
		}

		public DCSUniversalPackRecipe GetUniversalPackRecipe(DynamicCharacterAvatar dca, UMAContextBase context)
		{
			return null;
		}

		public override void Load(UMAData.UMARecipe umaRecipe, UMAContextBase context, bool loadSlots = true)
		{
		}
	}
}
