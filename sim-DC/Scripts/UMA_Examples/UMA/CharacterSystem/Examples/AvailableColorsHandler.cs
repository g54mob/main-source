using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class AvailableColorsHandler : MonoBehaviour
	{
		public DynamicCharacterAvatar Avatar;

		public SharedColorTable Colors;

		public GameObject ColorPanel;

		public GameObject ColorButtonPrefab;

		public string ColorName;

		public GameObject LabelPrefab;

		public void Setup(DynamicCharacterAvatar avatar, string colorName, GameObject colorPanel, SharedColorTable colorTable)
		{
		}

		public void OnClick()
		{
		}

		private void AddLabel(string theText)
		{
		}

		private void AddRemoverButton()
		{
		}

		private void AddButton(OverlayColorData ocd)
		{
		}

		private void Cleanup()
		{
		}
	}
}
