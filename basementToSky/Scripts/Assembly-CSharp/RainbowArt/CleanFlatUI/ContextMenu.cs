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
	public class ContextMenu : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		protected internal class ContextMenuItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
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
		public class ContextMenuEvent : UnityEvent<int>
		{
		}

		private enum Origin
		{
			RightBottom = 0,
			LeftBottom = 1,
			RightTop = 2,
			LeftTop = 3
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
		private List<OptionItem> options = new List<OptionItem>();

		[SerializeField]
		private ContextMenuEvent onValueChanged = new ContextMenuEvent();

		private Origin origin;

		private List<ContextMenuItem> menuItems = new List<ContextMenuItem>();

		private GameObject clickerBlocker;

		private IEnumerator diableCoroutine;

		private float disableTime = 0.15f;

		private float distanceX = 2f;

		private float distanceY = 2f;

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

		public ContextMenuEvent OnValueChanged
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

		public void Show(Vector2 mousePosition, RectTransform areaScope)
		{
			if (options.Count > 0)
			{
				base.gameObject.SetActive(value: true);
				DestroyAllMenuItems();
				DestroyClickBlocker();
				SetupTemplate();
				CreateAllMenuItems(options);
				UpdatePosition(mousePosition, areaScope);
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
			if (itemTemplate.GetComponent<ContextMenuItem>() == null)
			{
				ContextMenuItem contextMenuItem = itemTemplate.AddComponent<ContextMenuItem>();
				contextMenuItem.itemText = itemText;
				contextMenuItem.itemImage = itemImage;
				contextMenuItem.itemLine = itemLine;
				contextMenuItem.button = itemTemplate.GetComponent<Button>();
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
				ContextMenuItem component = obj.GetComponent<ContextMenuItem>();
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
			Hide(playAnim: true);
		}

		private void OnItemClicked(int index)
		{
			onValueChanged.Invoke(index);
			Hide(playAnim: true);
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

		public void Hide(bool playAnim)
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

		private void UpdatePosition(Vector2 mousePosition, RectTransform areaScope)
		{
			if (areaScope == null)
			{
				areaScope = GetRootCanvasRectTrans();
				if (areaScope == null)
				{
					return;
				}
			}
			RectTransform component = GetComponent<RectTransform>();
			component.localPosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
			Vector3[] array = new Vector3[4];
			component.GetWorldCorners(array);
			Vector3[] array2 = new Vector3[4];
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < 4; i++)
			{
				array2[i] = areaScope.InverseTransformPoint(array[i]);
			}
			if (array2[2].x >= areaScope.rect.xMax)
			{
				if (array2[0].x - component.rect.width < areaScope.rect.xMin)
				{
					num = array2[0].x - component.rect.width - areaScope.rect.xMin;
				}
				if (array2[0].y < areaScope.rect.yMin)
				{
					origin = Origin.LeftTop;
					if (array2[2].y + component.rect.height > areaScope.rect.yMax)
					{
						num2 = array2[2].y + component.rect.height - areaScope.rect.yMax;
					}
				}
				else
				{
					origin = Origin.LeftBottom;
				}
			}
			else if (array2[0].y < areaScope.rect.yMin)
			{
				origin = Origin.RightTop;
				if (array2[2].y + component.rect.height > areaScope.rect.yMax)
				{
					num2 = array2[2].y + component.rect.height - areaScope.rect.yMax;
				}
			}
			else
			{
				origin = Origin.RightBottom;
			}
			Vector3 localPosition = component.localPosition;
			float width = component.rect.width;
			float height = component.rect.height;
			switch (origin)
			{
			case Origin.RightBottom:
				localPosition.x += distanceX;
				localPosition.y -= distanceY;
				break;
			case Origin.RightTop:
				localPosition.x += distanceX;
				if (num2 == 0f)
				{
					localPosition.y = localPosition.y + height + distanceY;
				}
				else
				{
					localPosition.y = localPosition.y + height - num2;
				}
				break;
			case Origin.LeftTop:
				if (num == 0f)
				{
					localPosition.x = localPosition.x - width - distanceX;
				}
				else
				{
					localPosition.x = localPosition.x - width - num;
				}
				if (num2 == 0f)
				{
					localPosition.y = localPosition.y + height + distanceY;
				}
				else
				{
					localPosition.y = localPosition.y + height - num2;
				}
				break;
			case Origin.LeftBottom:
				if (num == 0f)
				{
					localPosition.x = localPosition.x - width - distanceX;
				}
				else
				{
					localPosition.x = localPosition.x - width - num;
				}
				localPosition.y -= distanceY;
				break;
			}
			component.localPosition = localPosition;
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
				case Origin.RightTop:
					text = "In Right Top";
					break;
				case Origin.LeftTop:
					text = "In Left Top";
					break;
				case Origin.LeftBottom:
					text = "In Left Bottom";
					break;
				}
			}
			else
			{
				text = "Out Right Bottom";
				switch (origin)
				{
				case Origin.RightTop:
					text = "Out Right Top";
					break;
				case Origin.LeftTop:
					text = "Out Left Top";
					break;
				case Origin.LeftBottom:
					text = "Out Left Bottom";
					break;
				}
			}
			animator.Play(text, 0, 0f);
		}
	}
}
