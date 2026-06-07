using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowRadioButton : MonoBehaviour
	{
		protected internal class ContentItem : MonoBehaviour
		{
			public TextMeshProUGUI itemText;

			public Image itemImage;

			public Image itemSelect;

			public Image itemCheckmark;

			public Button button;
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
		public class ModalWindowEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private Image iconTitle;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private Button buttonClose;

		[SerializeField]
		private Button buttonConfirm;

		[SerializeField]
		private Button buttonCancel;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform contentRect;

		[SerializeField]
		private GameObject itemTemplate;

		[SerializeField]
		private TextMeshProUGUI itemText;

		[SerializeField]
		private Image itemImage;

		[SerializeField]
		private Image itemSelect;

		[SerializeField]
		private Image itemCheckmark;

		[SerializeField]
		private RectOffset padding = new RectOffset();

		[SerializeField]
		private float spacing = 2f;

		[SerializeField]
		private int startSelectedIndex;

		[SerializeField]
		private List<OptionItem> options = new List<OptionItem>();

		private List<ContentItem> contentItems = new List<ContentItem>();

		[SerializeField]
		private ModalWindowEvent onConfirm = new ModalWindowEvent();

		[SerializeField]
		private ModalWindowEvent onCancel = new ModalWindowEvent();

		private int selectedIndex;

		private IEnumerator diableCoroutine;

		private float disableTime = 0.5f;

		public int StartSelectedIndex
		{
			get
			{
				return startSelectedIndex;
			}
			set
			{
				startSelectedIndex = value;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return selectedIndex;
			}
			set
			{
				if (value >= 0 && value < options.Count)
				{
					selectedIndex = value;
				}
				else
				{
					selectedIndex = 0;
				}
			}
		}

		public string TitleValue
		{
			get
			{
				if (title != null)
				{
					return title.text;
				}
				return "";
			}
			set
			{
				if (title != null)
				{
					title.text = value;
				}
			}
		}

		public Sprite IconValue
		{
			get
			{
				if (iconTitle != null)
				{
					return iconTitle.sprite;
				}
				return null;
			}
			set
			{
				if (iconTitle != null)
				{
					if (value != null)
					{
						iconTitle.gameObject.SetActive(value: true);
						iconTitle.sprite = value;
					}
					else
					{
						iconTitle.gameObject.SetActive(value: false);
						iconTitle.sprite = null;
					}
				}
			}
		}

		public ModalWindowEvent OnConfirm
		{
			get
			{
				return onConfirm;
			}
			set
			{
				onConfirm = value;
			}
		}

		public ModalWindowEvent OnCancel
		{
			get
			{
				return onCancel;
			}
			set
			{
				onCancel = value;
			}
		}

		public void ShowModalWindow()
		{
			base.gameObject.SetActive(value: true);
			UpdateSelectIndex();
			InitButtons();
			InitAnimation();
			DestroyAllItems();
			SetupTemplate();
			CreateAllItems(options);
			PlayAnimation(bShow: true);
		}

		public void HideModalWindow()
		{
			PlayAnimation(bShow: false);
			if (animator != null)
			{
				if (diableCoroutine != null)
				{
					StopCoroutine(diableCoroutine);
					diableCoroutine = null;
				}
				diableCoroutine = DisableTransition();
				StartCoroutine(diableCoroutine);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private IEnumerator DisableTransition()
		{
			yield return new WaitForSeconds(disableTime);
			base.gameObject.SetActive(value: false);
		}

		private void UpdateSelectIndex()
		{
			selectedIndex = 0;
			if (startSelectedIndex >= 0 && startSelectedIndex < options.Count)
			{
				selectedIndex = startSelectedIndex;
			}
		}

		private void InitButtons()
		{
			if (buttonClose != null)
			{
				buttonClose.onClick.RemoveAllListeners();
				buttonClose.onClick.AddListener(OnCloseClick);
			}
			if (buttonConfirm != null)
			{
				buttonConfirm.onClick.RemoveAllListeners();
				buttonConfirm.onClick.AddListener(OnConfirmClick);
			}
			if (buttonCancel != null)
			{
				buttonCancel.onClick.RemoveAllListeners();
				buttonCancel.onClick.AddListener(OnCancelClick);
			}
		}

		private void OnCloseClick()
		{
			OnCancelClick();
		}

		private void OnCancelClick()
		{
			HideModalWindow();
			onCancel.Invoke(-1);
		}

		private void OnConfirmClick()
		{
			HideModalWindow();
			onConfirm.Invoke(selectedIndex);
		}

		private void InitAnimation()
		{
			if (animator != null)
			{
				animator.enabled = false;
				animator.gameObject.transform.localScale = Vector3.one;
				animator.gameObject.transform.localEulerAngles = Vector3.zero;
			}
		}

		private void PlayAnimation(bool bShow)
		{
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				if (bShow)
				{
					animator.Play("In", 0, 0f);
				}
				else
				{
					animator.Play("Out", 0, 0f);
				}
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
			if (itemTemplate.GetComponent<ContentItem>() == null)
			{
				ContentItem contentItem = itemTemplate.AddComponent<ContentItem>();
				contentItem.itemText = itemText;
				contentItem.itemImage = itemImage;
				contentItem.itemSelect = itemSelect;
				contentItem.itemCheckmark = itemCheckmark;
				contentItem.button = itemTemplate.GetComponent<Button>();
			}
			itemTemplate.SetActive(value: false);
		}

		private void CreateAllItems(List<OptionItem> options)
		{
			_ = itemTemplate.GetComponent<RectTransform>().rect.width;
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
				obj.name = "Item" + i;
				ContentItem component = obj.GetComponent<ContentItem>();
				contentItems.Add(component);
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
				if (i == selectedIndex)
				{
					component.itemCheckmark.gameObject.SetActive(value: true);
				}
				else
				{
					component.itemCheckmark.gameObject.SetActive(value: false);
				}
				component.button.onClick.RemoveAllListeners();
				component.button.onClick.AddListener(delegate
				{
					OnItemSelected(index);
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
			contentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Abs(num) + (float)padding.bottom);
			contentRect.anchoredPosition3D = new Vector3(0f, 0f, 0f);
		}

		private void DestroyAllItems()
		{
			int count = contentItems.Count;
			for (int i = 0; i < count; i++)
			{
				if (contentItems[i] != null)
				{
					UnityEngine.Object.Destroy(contentItems[i].gameObject);
				}
			}
			contentItems.Clear();
		}

		private void OnItemSelected(int index)
		{
			selectedIndex = index;
			for (int i = 0; i < contentItems.Count; i++)
			{
				ContentItem contentItem = contentItems[i];
				if (i == selectedIndex)
				{
					if (contentItem.itemSelect != null)
					{
						contentItem.itemSelect.gameObject.SetActive(value: true);
					}
					contentItem.itemCheckmark.gameObject.SetActive(value: true);
				}
				else
				{
					if (contentItem.itemSelect != null)
					{
						contentItem.itemSelect.gameObject.SetActive(value: false);
					}
					contentItem.itemCheckmark.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
