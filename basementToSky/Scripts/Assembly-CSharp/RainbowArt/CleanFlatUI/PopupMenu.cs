using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class PopupMenu : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		protected internal class PopupMenuItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
		{
			public TextMeshProUGUI itemText;

			public Image itemImage;

			public Image itemLine;

			public Button button;

			public virtual void OnPointerEnter(PointerEventData eventData)
			{
				EventSystem.current.SetSelectedGameObject(base.gameObject);
			}
		}

		public enum Origin
		{
			TopStart = 0,
			TopCenter = 1,
			TopEnd = 2,
			BottomStart = 3,
			BottomCenter = 4,
			BottomEnd = 5,
			LeftStart = 6,
			LeftCenter = 7,
			LeftEnd = 8,
			RightStart = 9,
			RightCenter = 10,
			RightEnd = 11
		}

		[Serializable]
		public class OptionItem
		{
			public string text;

			public Sprite icon;

			public OptionItem()
			{
			}

			public OptionItem(string newText)
			{
				text = newText;
			}

			public OptionItem(Sprite newImage)
			{
				icon = newImage;
			}

			public OptionItem(string newText, Sprite newImage)
			{
				text = newText;
				icon = newImage;
			}
		}

		[Serializable]
		public class PopupMenuEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private GameObject itemTemplate;

		[SerializeField]
		private TextMeshProUGUI itemText;

		[SerializeField]
		private Image itemImage;

		[SerializeField]
		private Image itemLine;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectOffset padding = new RectOffset();

		[SerializeField]
		private float spacing = 2f;

		[SerializeField]
		private Origin origin = Origin.BottomStart;

		[SerializeField]
		private List<OptionItem> options = new List<OptionItem>();

		[SerializeField]
		private PopupMenuEvent onValueChanged = new PopupMenuEvent();

		private List<PopupMenuItem> menuItems = new List<PopupMenuItem>();

		private GameObject clickerBlocker;

		private IEnumerator diableCoroutine;

		private float disableTime = 0.15f;

		private uint distance = 10u;

		public RectOffset Padding
		{
			get
			{
				return padding;
			}
			set
			{
				padding = value;
			}
		}

		public float Spacing
		{
			get
			{
				return spacing;
			}
			set
			{
				spacing = value;
			}
		}

		public PopupMenuEvent OnValueChanged
		{
			get
			{
				return onValueChanged;
			}
			set
			{
				onValueChanged = value;
			}
		}

		public void ShowPopupMenu(Vector3 position, float width, float height)
		{
			if (options.Count > 0)
			{
				base.gameObject.SetActive(value: true);
				DestroyAllMenuItems();
				DestroyClickBlocker();
				SetupTemplate();
				CreateAllMenuItems(options);
				UpdatePosition(position, width, height);
				CreateClickBlocker();
				PlayAnimation(bShow: true);
			}
		}

		public void AddOptions(List<OptionItem> optionList)
		{
			options.AddRange(optionList);
		}

		public void AddOptions(List<string> optionList)
		{
			for (int i = 0; i < optionList.Count; i++)
			{
				options.Add(new OptionItem(optionList[i]));
			}
		}

		public void AddOptions(List<Sprite> optionList)
		{
			for (int i = 0; i < optionList.Count; i++)
			{
				options.Add(new OptionItem(optionList[i]));
			}
		}

		public void ClearOptions()
		{
			options.Clear();
		}

		private void SetupTemplate()
		{
			if (itemTemplate.GetComponent<PopupMenuItem>() == null)
			{
				PopupMenuItem popupMenuItem = itemTemplate.AddComponent<PopupMenuItem>();
				popupMenuItem.itemText = itemText;
				popupMenuItem.itemImage = itemImage;
				popupMenuItem.itemLine = itemLine;
				popupMenuItem.button = itemTemplate.GetComponent<Button>();
			}
			itemTemplate.SetActive(value: false);
		}

		private void CreateAllMenuItems(List<OptionItem> options)
		{
			float width = itemTemplate.GetComponent<RectTransform>().rect.width;
			_ = itemTemplate.transform.parent;
			int count = options.Count;
			float num = -padding.top;
			for (int i = 0; i < count; i++)
			{
				OptionItem optionItem = options[i];
				int index = i;
				GameObject obj = UnityEngine.Object.Instantiate(itemTemplate);
				obj.transform.SetParent(itemTemplate.gameObject.transform.parent, worldPositionStays: false);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localEulerAngles = Vector3.zero;
				obj.SetActive(value: true);
				obj.name = "MenuItem" + i;
				PopupMenuItem component = obj.GetComponent<PopupMenuItem>();
				menuItems.Add(component);
				component.itemText.text = optionItem.text;
				if (optionItem.icon == null)
				{
					component.itemImage.gameObject.SetActive(value: false);
					component.itemImage.sprite = null;
				}
				else
				{
					component.itemImage.gameObject.SetActive(value: true);
					component.itemImage.sprite = optionItem.icon;
				}
				if (component.itemLine != null)
				{
					if (i == count - 1)
					{
						component.itemLine.gameObject.SetActive(value: false);
					}
					else
					{
						component.itemLine.gameObject.SetActive(value: true);
					}
				}
				component.button.onClick.RemoveAllListeners();
				component.button.onClick.AddListener(delegate
				{
					OnItemClicked(index);
				});
				RectTransform component2 = obj.GetComponent<RectTransform>();
				component2.anchoredPosition3D = new Vector3(padding.left, num, 0f);
				float height = component2.rect.height;
				num -= height;
				if (i < count - 1)
				{
					num -= spacing;
				}
			}
			base.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Abs(num) + (float)padding.bottom);
			base.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width + (float)padding.left + (float)padding.right);
		}

		private Canvas GetRootCanvas()
		{
			List<Canvas> list = new List<Canvas>();
			base.gameObject.GetComponentsInParent(includeInactive: false, list);
			if (list.Count == 0)
			{
				return null;
			}
			int count = list.Count;
			Canvas result = list[count - 1];
			for (int i = 0; i < count; i++)
			{
				if (list[i].isRootCanvas || list[i].overrideSorting)
				{
					result = list[i];
					break;
				}
			}
			return result;
		}

		private RectTransform GetRootCanvasRectTrans()
		{
			Canvas rootCanvas = GetRootCanvas();
			if (rootCanvas == null)
			{
				return null;
			}
			return rootCanvas.GetComponent<RectTransform>();
		}

		private void CreateClickBlocker()
		{
			Canvas rootCanvas = GetRootCanvas();
			if (!(rootCanvas == null))
			{
				clickerBlocker = new GameObject("ClickBlocker");
				RectTransform rectTransform = clickerBlocker.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
				rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
				rectTransform.pivot = new Vector2(0.5f, 0.5f);
				clickerBlocker.AddComponent<Image>().color = Color.clear;
				RectTransform component = rootCanvas.GetComponent<RectTransform>();
				float width = component.rect.width;
				float height = component.rect.height;
				rectTransform.SetParent(rootCanvas.transform, worldPositionStays: false);
				rectTransform.localPosition = Vector3.zero;
				rectTransform.SetParent(base.gameObject.transform, worldPositionStays: true);
				rectTransform.SetAsFirstSibling();
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			HidePopupMenu(playAnim: true);
		}

		private void OnItemClicked(int index)
		{
			onValueChanged.Invoke(index);
			HidePopupMenu(playAnim: true);
		}

		private void DestroyAllMenuItems()
		{
			int count = menuItems.Count;
			for (int i = 0; i < count; i++)
			{
				if (menuItems[i] != null)
				{
					UnityEngine.Object.Destroy(menuItems[i].gameObject);
				}
			}
			menuItems.Clear();
		}

		private void DestroyClickBlocker()
		{
			if (clickerBlocker != null)
			{
				UnityEngine.Object.Destroy(clickerBlocker);
				clickerBlocker = null;
			}
		}

		public void HidePopupMenu(bool playAnim)
		{
			if (diableCoroutine != null)
			{
				StopCoroutine(diableCoroutine);
				diableCoroutine = null;
			}
			if (playAnim)
			{
				PlayAnimation(bShow: false);
				diableCoroutine = DisableTransition();
				StartCoroutine(diableCoroutine);
				return;
			}
			if (animator != null)
			{
				animator.enabled = false;
				animator.gameObject.transform.localScale = Vector3.one;
				animator.gameObject.transform.localEulerAngles = Vector3.zero;
			}
			base.gameObject.SetActive(value: false);
			DestroyAllMenuItems();
			DestroyClickBlocker();
		}

		private IEnumerator DisableTransition()
		{
			yield return new WaitForSeconds(disableTime);
			base.gameObject.SetActive(value: false);
			DestroyAllMenuItems();
		}

		public bool IsShowing()
		{
			return base.gameObject.activeSelf;
		}

		private void UpdatePosition(Vector3 position, float uiWidth, float uiHeight)
		{
			RectTransform component = GetComponent<RectTransform>();
			float width = component.rect.width;
			float height = component.rect.height;
			float x = position.x;
			float y = position.y;
			switch (origin)
			{
			case Origin.BottomStart:
				y = position.y - (float)distance;
				break;
			case Origin.BottomCenter:
				x = position.x + uiWidth / 2f - width / 2f;
				y = position.y - (float)distance;
				break;
			case Origin.BottomEnd:
				x = position.x + uiWidth - width;
				y = position.y - (float)distance;
				break;
			case Origin.TopStart:
				y = position.y + uiHeight + height + (float)distance;
				break;
			case Origin.TopCenter:
				x = position.x + uiWidth / 2f - width / 2f;
				y = position.y + uiHeight + height + (float)distance;
				break;
			case Origin.TopEnd:
				x = position.x + uiWidth - width;
				y = position.y + uiHeight + height + (float)distance;
				break;
			case Origin.LeftStart:
				x = position.x - width - (float)distance;
				y = position.y + uiHeight;
				break;
			case Origin.LeftCenter:
				x = position.x - width - (float)distance;
				y = position.y + uiHeight / 2f + height / 2f;
				break;
			case Origin.LeftEnd:
				x = position.x - width - (float)distance;
				y = position.y + height;
				break;
			case Origin.RightStart:
				x = position.x + uiWidth + (float)distance;
				y = position.y + uiHeight;
				break;
			case Origin.RightCenter:
				x = position.x + uiWidth + (float)distance;
				y = position.y + uiHeight / 2f + height / 2f;
				break;
			case Origin.RightEnd:
				x = position.x + uiWidth + (float)distance;
				y = position.y + height;
				break;
			}
			Vector3 anchoredPosition3D = new Vector3(x, y, 0f);
			component.anchoredPosition3D = anchoredPosition3D;
		}

		private void PlayAnimation(bool bShow)
		{
			if (animator != null)
			{
				animator.enabled = false;
				animator.gameObject.transform.localScale = Vector3.one;
				animator.gameObject.transform.localEulerAngles = Vector3.zero;
			}
			if (!(animator != null))
			{
				return;
			}
			if (!animator.enabled)
			{
				animator.enabled = true;
			}
			string text = null;
			if (bShow)
			{
				text = "In Right Bottom";
				switch (origin)
				{
				case Origin.TopStart:
				case Origin.RightEnd:
					text = "In Right Top";
					break;
				case Origin.TopEnd:
				case Origin.LeftEnd:
					text = "In Left Top";
					break;
				case Origin.BottomEnd:
				case Origin.LeftStart:
					text = "In Left Bottom";
					break;
				case Origin.TopCenter:
					text = "In Top Middle";
					break;
				case Origin.BottomCenter:
					text = "In Bottom Middle";
					break;
				case Origin.LeftCenter:
					text = "In Left Middle";
					break;
				case Origin.RightCenter:
					text = "In Right Middle";
					break;
				}
			}
			else
			{
				text = "Out Right Bottom";
				switch (origin)
				{
				case Origin.TopStart:
				case Origin.RightEnd:
					text = "Out Right Top";
					break;
				case Origin.TopEnd:
				case Origin.LeftEnd:
					text = "Out Left Top";
					break;
				case Origin.BottomEnd:
				case Origin.LeftStart:
					text = "Out Left Bottom";
					break;
				case Origin.TopCenter:
					text = "Out Top Middle";
					break;
				case Origin.BottomCenter:
					text = "Out Bottom Middle";
					break;
				case Origin.LeftCenter:
					text = "Out Left Middle";
					break;
				case Origin.RightCenter:
					text = "Out Right Middle";
					break;
				}
			}
			animator.Play(text, 0, 0f);
		}
	}
}
