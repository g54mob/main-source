using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class DynamicCharacterSystemBase : MonoBehaviour
	{
		public virtual void Awake()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void Refresh(bool forceUpdateRaceLibrary = true, string bundleToGather = "")
		{
		}

		public virtual void Update()
		{
		}

		public virtual void Init()
		{
		}

		public virtual UMARecipeBase GetBaseRecipe(string filename, bool dynamicallyAdd = true)
		{
			return null;
		}

		public virtual List<string> GetRecipeNamesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public virtual List<UMARecipeBase> GetRecipesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public virtual bool CheckRecipeAvailability(string recipeName)
		{
			return false;
		}
	}
}
