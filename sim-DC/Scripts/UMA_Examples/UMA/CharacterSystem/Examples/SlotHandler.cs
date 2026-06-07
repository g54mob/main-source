using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class SlotHandler : MonoBehaviour
	{
		public DynamicCharacterAvatar Avatar;

		public GameObject WardrobePanel;

		public GameObject WardrobeButtonPrefab;

		public GameObject LabelPrefab;

		public string SlotName;

		public void Setup(DynamicCharacterAvatar avatar, string slotName, GameObject wardrobePanel)
		{
		}

		public void OnClick()
		{
		}

		private void AddLabel(string theText)
		{
		}

		private void AddButton(string theText, string SlotName, UMATextRecipe utr = null)
		{
		}

		private void Cleanup()
		{
		}
	}
}
