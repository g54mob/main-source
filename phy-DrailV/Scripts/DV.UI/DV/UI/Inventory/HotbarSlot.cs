using DV.Common;
using DV.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.Inventory
{
	[ExecuteAfter(typeof(PlatformAutoRectSize))]
	public class HotbarSlot : MonoBehaviour
	{
		private const string EMPTY_SLOT_LABEL = "";

		private const string FAKE_SLOT_LABEL = "Inventory";

		private const float ANIMATION_SMOOTHING = 15f;

		private static readonly Color HIGHLIGHT_BAR_ON = new Color32(134, 198, 223, byte.MaxValue);

		private static readonly Color HIGHLIGHT_BAR_OFF = new Color32(48, 60, 80, byte.MaxValue);

		private readonly Color COLOR_HIGHLIGHTED_TEXT = Color.white;

		public bool fakeSlot;

		[SerializeField]
		private Image itemIcon;

		[SerializeField]
		private Image highlightImage;

		[SerializeField]
		private Sprite itemMissingIconSprite;

		[SerializeField]
		private TextMeshProUGUI itemNameText;

		[SerializeField]
		private float highlightIconFloatOffset;

		private HotbarController parentController;

		private bool isHighlighted;

		private float itemIconBaseY;

		public bool Occupied { get; private set; }

		private void Awake()
		{
			parentController = GetComponentInParent<HotbarController>();
			Clear();
			SetHighlight(highlighted: false);
			if (itemNameText != null)
			{
				itemNameText.color = COLOR_HIGHLIGHTED_TEXT;
			}
			base.enabled = true;
		}

		private void Start()
		{
			itemIconBaseY = itemIcon.rectTransform.anchoredPosition.y;
		}

		public void RefreshInventoryItemName(IInventoryItemSpec itemSpec, bool showText = true)
		{
			if (fakeSlot)
			{
				itemNameText.name = "Inventory";
				itemNameText.gameObject.SetActive(value: true);
				return;
			}
			if (itemSpec != null)
			{
				itemNameText.text = parentController.GetLocalizedNameForItem(itemSpec);
			}
			else
			{
				showText = false;
				itemNameText.text = "";
			}
			itemNameText.gameObject.SetActive(showText);
		}

		public void ToggleItemName(bool on)
		{
			if ((!fakeSlot || on) && itemNameText != null)
			{
				itemNameText.gameObject.SetActive(on);
			}
		}

		public void Clear()
		{
			Occupied = fakeSlot;
			if (itemNameText != null)
			{
				itemNameText.text = (fakeSlot ? "Inventory" : "");
			}
			itemIcon.sprite = (fakeSlot ? itemMissingIconSprite : null);
			itemIcon.gameObject.SetActive(fakeSlot);
		}

		public void SetHighlight(bool highlighted)
		{
			isHighlighted = highlighted;
			if (highlighted)
			{
				base.enabled = true;
			}
		}

		private void Update()
		{
			Color color = (isHighlighted ? HIGHLIGHT_BAR_ON : HIGHLIGHT_BAR_OFF);
			if (highlightImage.color != color)
			{
				highlightImage.color = color;
			}
			float num = (isHighlighted ? (itemIconBaseY + highlightIconFloatOffset) : itemIconBaseY);
			if (Mathf.Abs(itemIcon.rectTransform.anchoredPosition.y - num) > 0.001f)
			{
				itemIcon.rectTransform.anchoredPosition = Vector2.up * Mathf.Lerp(itemIcon.rectTransform.anchoredPosition.y, num, Time.unscaledDeltaTime * 15f);
			}
			else if (!isHighlighted)
			{
				base.enabled = false;
			}
		}

		public void ResetSlotVisuals(IInventoryItemSpec specs, bool highlighted, bool isDropped, bool showText = true)
		{
			Clear();
			Occupied = fakeSlot || specs != null;
			SetHighlight(highlighted);
			if (Occupied)
			{
				Sprite sprite = (fakeSlot ? itemMissingIconSprite : (isDropped ? specs.ItemIconSpriteDropped : specs.ItemIconSprite));
				itemIcon.sprite = ((sprite != null) ? sprite : itemMissingIconSprite);
				itemIcon.gameObject.SetActive(value: true);
				RefreshInventoryItemName(specs, showText);
			}
		}
	}
}
