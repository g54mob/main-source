using InputControl;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Factory.UI
{
	public class PaletteItemCtrl : MonoBehaviour
	{
		[SerializeField]
		private Image itemIcon;

		[SerializeField]
		private Image blankIcon;

		[SerializeField]
		private Image itemSeparater;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private GameObject pointObj;

		[SerializeField]
		private TMP_Text pointText;

		[SerializeField]
		private GameObject countObj;

		[SerializeField]
		private TMP_Text countText;

		[SerializeField]
		private NoticeBadge noticeBadge;

		[SerializeField]
		private TMP_Text hotKeyText;

		[SerializeField]
		private GameObject favStarObj;

		[SerializeField]
		private HotKeyRaycaster hotKeyRaycaster;

		[SerializeField]
		private CursorUIBase cursorUI;

		private const string shortcutKeyImagePathBase = "Assets/Textures/UI/Inventory/inventory_key_{0}.png";

		private ArtifactPaletteCtrl.PaletteItemData itemData;

		private UnityAction<ArtifactPaletteCtrl.PaletteItemData, PointerEventData, PaletteItemCtrl> onClickButtonAction;

		private UnityAction<ArtifactPaletteCtrl.PaletteItemData> onPointerEnterButtonAction;

		private UnityAction onPointerExitButtonAction;

		private ePaletteCategory category;

		public ArtifactPaletteCtrl.PaletteItemData ItemData => null;

		public bool isOn => false;

		public CursorUIBase CursorUI => null;

		public void Init(ePaletteCategory category, ArtifactPaletteCtrl.PaletteItemData itemData, bool showShortcut, InputAction shortcutAction, bool showSeparater, bool isFavorite, bool isOn, UnityAction<ArtifactPaletteCtrl.PaletteItemData, PointerEventData, PaletteItemCtrl> onClick, UnityAction<ArtifactPaletteCtrl.PaletteItemData> onPointerEnter, UnityAction OnPointerExit)
		{
		}

		public void ChangeData(ePaletteCategory category, ArtifactPaletteCtrl.PaletteItemData itemData, bool isOn, bool showShortcut, bool isFavorite)
		{
		}

		private void CheckItemData(ArtifactPaletteCtrl.PaletteItemData itemData, bool showShortcut, bool isFavorite)
		{
		}

		private void LoadShortcutIcon(bool showShortcut)
		{
		}

		private void LoadSprite()
		{
		}

		public void OnClickButton(BaseEventData eventData)
		{
		}

		public void OnClickPadDecide()
		{
		}

		public void OnClickPadFavorite()
		{
		}

		public void OnPointerEnterButton()
		{
		}

		public void OnPointerExitButton()
		{
		}

		public void UpdateUI(bool isOn, bool showShortcut, bool? isFavorite = null)
		{
		}

		public void UpdateItemBadge()
		{
		}

		public void SetToggleGroup(ToggleGroup toggleGroup)
		{
		}
	}
}
