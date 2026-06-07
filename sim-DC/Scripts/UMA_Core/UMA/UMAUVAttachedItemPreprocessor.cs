using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class UMAUVAttachedItemPreprocessor : MonoBehaviour
	{
		private DynamicCharacterAvatar avatar;

		public List<UMAUVAttachedItemLauncher> launchers;

		private void Awake()
		{
		}

		public void OnBuildCharacterBegun(UMAData umaData)
		{
		}

		public void OnSlotsHidden(List<SlotData> hiddenSlots)
		{
		}

		public void OnWardrobeSuppressed(List<UMATextRecipe> suppressedRecipes)
		{
		}
	}
}
