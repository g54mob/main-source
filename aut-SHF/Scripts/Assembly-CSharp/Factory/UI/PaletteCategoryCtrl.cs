using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Factory.UI
{
	public class PaletteCategoryCtrl : MonoBehaviour
	{
		[SerializeField]
		private Image itemIcon;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private NoticeBadge noticeBadge;

		[SerializeField]
		private Image tabBG;

		[SerializeField]
		private TMP_Text hotKeyText;

		[SerializeField]
		private HotKeyRaycaster hotKeyRaycaster;

		private ArtifactPaletteCtrl.PaletteCategoryData paletteCategoryData;

		private List<ArtifactPaletteCtrl.PaletteItemData> paletteItemData;

		private UnityAction<int> onClickButtonAction;

		private const string shortcutKeyImagePathBase = "Assets/Textures/UI/Inventory/inventory_key_F{0}.png";

		public bool ToggleEnable => false;

		public ArtifactPaletteCtrl.PaletteCategoryData CategoryData => null;

		public void Init(ArtifactPaletteCtrl.PaletteCategoryData paletteCategoryData, List<ArtifactPaletteCtrl.PaletteItemData> paletteItemData, ToggleGroup toggleGroup, bool isOn, UnityAction<int> action, bool showShortcut, InputAction shortcutAction)
		{
		}

		private void Start()
		{
		}

		private void PlayAnimation(float time, float interval)
		{
		}

		public void SetToggleOn()
		{
		}

		public void OnClickButton()
		{
		}

		public void UpdateCategoryBadge()
		{
		}

		public void UpdateVisibleShortcutIcon(bool showShortcut)
		{
		}

		private void FinishTutorial()
		{
		}
	}
}
