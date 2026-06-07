using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class WardrobeHandler : MonoBehaviour
	{
		public DynamicCharacterAvatar Avatar;

		public UMATextRecipe Recipe;

		public string Slot;

		public string theText;

		private Color32 LoadedColor;

		private Color32 UnloadedColor;

		public bool isReady => false;

		public void SetColors()
		{
		}

		public void Setup(DynamicCharacterAvatar avatar, UMATextRecipe recipe, string slot, string text)
		{
		}

		public void OnClick()
		{
		}

		private void SetRecipe()
		{
		}
	}
}
