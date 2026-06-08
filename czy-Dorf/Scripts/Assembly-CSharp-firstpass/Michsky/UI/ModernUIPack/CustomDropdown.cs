using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class CustomDropdown : MonoBehaviour, IPointerExitHandler, IEventSystemHandler, IPointerEnterHandler, IPointerClickHandler
	{
		[Serializable]
		public class DropdownEvent : UnityEvent<int>
		{
		}

		public enum AnimationType
		{
			FADING = 0,
			SLIDING = 1,
			STYLISH = 2
		}

		[Serializable]
		public class Item
		{
			public string itemName = "Dropdown Item";

			public Sprite itemIcon;

			public UnityEvent OnItemSelection = new UnityEvent();
		}

		private sealed class _003C_003Ec__DisplayClass40_0
		{
			public GameObject go;

			public CustomDropdown _003C_003E4__this;

			internal void _003CSetupDropdown_003Eb__0()
			{
				_003C_003E4__this.ChangeDropdownInfo(_003C_003E4__this.index = go.transform.GetSiblingIndex());
				_003C_003E4__this.dropdownEvent.Invoke(_003C_003E4__this.index = go.transform.GetSiblingIndex());
				if (_003C_003E4__this.saveSelected)
				{
					PlayerPrefs.SetInt(_003C_003E4__this.dropdownTag + "Dropdown", go.transform.GetSiblingIndex());
				}
			}
		}

		public Animator dropdownAnimator;

		public GameObject triggerObject;

		public TextMeshProUGUI selectedText;

		public Image selectedImage;

		public Transform itemParent;

		public GameObject itemObject;

		public GameObject scrollbar;

		public VerticalLayoutGroup itemList;

		public Transform currentListParent;

		public Transform listParent;

		public AudioSource soundSource;

		public bool enableIcon = true;

		public bool enableTrigger = true;

		public bool enableScrollbar = true;

		public bool setHighPriorty = true;

		public bool outOnPointerExit;

		public bool isListItem;

		public bool invokeAtStart;

		public AnimationType animationType;

		public int selectedItemIndex;

		public bool enableDropdownSounds;

		public bool useHoverSound = true;

		public bool useClickSound = true;

		public bool saveSelected;

		public string dropdownTag = "Dropdown";

		[SerializeField]
		public List<Item> dropdownItems = new List<Item>();

		public DropdownEvent dropdownEvent;

		public AudioClip hoverSound;

		public AudioClip clickSound;

		public bool isOn;

		public int index;

		public int siblingIndex;

		public TextMeshProUGUI setItemText;

		public Image setItemImage;

		private Sprite imageHelper;

		private string textHelper;

		private void Start()
		{
			try
			{
				dropdownAnimator = base.gameObject.GetComponent<Animator>();
				itemList = itemParent.GetComponent<VerticalLayoutGroup>();
				if (dropdownItems.Count != 0)
				{
					SetupDropdown();
				}
				currentListParent = base.transform.parent;
			}
			catch
			{
				Debug.LogError("Dropdown - Cannot initalize the object due to missing resources.", this);
			}
			if (enableScrollbar)
			{
				itemList.padding.right = 25;
			}
			else
			{
				itemList.padding.right = 8;
			}
			if (setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
			if (saveSelected)
			{
				if (invokeAtStart)
				{
					dropdownItems[PlayerPrefs.GetInt(dropdownTag + "Dropdown")].OnItemSelection.Invoke();
				}
				else
				{
					ChangeDropdownInfo(PlayerPrefs.GetInt(dropdownTag + "Dropdown"));
				}
			}
		}

		public void SetupDropdown()
		{
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			index = 0;
			for (int i = 0; i < dropdownItems.Count; i++)
			{
				_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass40_0();
				CS_0024_003C_003E8__locals15._003C_003E4__this = this;
				CS_0024_003C_003E8__locals15.go = UnityEngine.Object.Instantiate(itemObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				CS_0024_003C_003E8__locals15.go.transform.SetParent(itemParent, worldPositionStays: false);
				setItemText = CS_0024_003C_003E8__locals15.go.GetComponentInChildren<TextMeshProUGUI>();
				textHelper = dropdownItems[i].itemName;
				setItemText.text = textHelper;
				Transform transform = CS_0024_003C_003E8__locals15.go.gameObject.transform.Find("Icon");
				setItemImage = transform.GetComponent<Image>();
				imageHelper = dropdownItems[i].itemIcon;
				setItemImage.sprite = imageHelper;
				Button component = CS_0024_003C_003E8__locals15.go.GetComponent<Button>();
				component.onClick.AddListener(Animate);
				component.onClick.AddListener(delegate
				{
					CS_0024_003C_003E8__locals15._003C_003E4__this.ChangeDropdownInfo(CS_0024_003C_003E8__locals15._003C_003E4__this.index = CS_0024_003C_003E8__locals15.go.transform.GetSiblingIndex());
					CS_0024_003C_003E8__locals15._003C_003E4__this.dropdownEvent.Invoke(CS_0024_003C_003E8__locals15._003C_003E4__this.index = CS_0024_003C_003E8__locals15.go.transform.GetSiblingIndex());
					if (CS_0024_003C_003E8__locals15._003C_003E4__this.saveSelected)
					{
						PlayerPrefs.SetInt(CS_0024_003C_003E8__locals15._003C_003E4__this.dropdownTag + "Dropdown", CS_0024_003C_003E8__locals15.go.transform.GetSiblingIndex());
					}
				});
				if (dropdownItems[i].OnItemSelection != null)
				{
					component.onClick.AddListener(dropdownItems[i].OnItemSelection.Invoke);
				}
				if (invokeAtStart)
				{
					dropdownItems[i].OnItemSelection.Invoke();
				}
			}
			try
			{
				selectedText.text = dropdownItems[selectedItemIndex].itemName;
				selectedImage.sprite = dropdownItems[selectedItemIndex].itemIcon;
				currentListParent = base.transform.parent;
			}
			catch
			{
				selectedText.text = dropdownTag;
				currentListParent = base.transform.parent;
				Debug.Log("Dropdown - There is no dropdown items in the list.", this);
			}
		}

		public void ChangeDropdownInfo(int itemIndex)
		{
			if (selectedImage != null)
			{
				selectedImage.sprite = dropdownItems[itemIndex].itemIcon;
			}
			if (selectedText != null)
			{
				selectedText.text = dropdownItems[itemIndex].itemName;
			}
			if (enableDropdownSounds && useClickSound)
			{
				soundSource.PlayOneShot(clickSound);
			}
			selectedItemIndex = itemIndex;
		}

		public void Animate()
		{
			if (!isOn && animationType == AnimationType.FADING)
			{
				dropdownAnimator.Play("Fading In");
				isOn = true;
				if (isListItem)
				{
					siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(listParent, worldPositionStays: true);
				}
			}
			else if (isOn && animationType == AnimationType.FADING)
			{
				dropdownAnimator.Play("Fading Out");
				isOn = false;
				if (isListItem)
				{
					base.gameObject.transform.SetParent(currentListParent, worldPositionStays: true);
					base.gameObject.transform.SetSiblingIndex(siblingIndex);
				}
			}
			else if (!isOn && animationType == AnimationType.SLIDING)
			{
				dropdownAnimator.Play("Sliding In");
				isOn = true;
				if (isListItem)
				{
					siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(listParent, worldPositionStays: true);
				}
			}
			else if (isOn && animationType == AnimationType.SLIDING)
			{
				dropdownAnimator.Play("Sliding Out");
				isOn = false;
				if (isListItem)
				{
					base.gameObject.transform.SetParent(currentListParent, worldPositionStays: true);
					base.gameObject.transform.SetSiblingIndex(siblingIndex);
				}
			}
			else if (!isOn && animationType == AnimationType.STYLISH)
			{
				dropdownAnimator.Play("Stylish In");
				isOn = true;
				if (isListItem)
				{
					siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(listParent, worldPositionStays: true);
				}
			}
			else if (isOn && animationType == AnimationType.STYLISH)
			{
				dropdownAnimator.Play("Stylish Out");
				isOn = false;
				if (isListItem)
				{
					base.gameObject.transform.SetParent(currentListParent, worldPositionStays: true);
					base.gameObject.transform.SetSiblingIndex(siblingIndex);
				}
			}
			if (enableTrigger && !isOn)
			{
				triggerObject.SetActive(value: false);
			}
			else if (enableTrigger && isOn)
			{
				triggerObject.SetActive(value: true);
			}
			if (outOnPointerExit)
			{
				triggerObject.SetActive(value: false);
			}
			if (setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (outOnPointerExit && isOn)
			{
				Animate();
				isOn = false;
				if (isListItem)
				{
					base.gameObject.transform.SetParent(currentListParent, worldPositionStays: true);
				}
			}
		}

		public void UpdateValues()
		{
			if (enableScrollbar)
			{
				itemList.padding.right = 25;
				scrollbar.SetActive(value: true);
			}
			else
			{
				itemList.padding.right = 8;
				scrollbar.SetActive(value: false);
			}
			if (!enableIcon)
			{
				selectedImage.gameObject.SetActive(value: false);
			}
			else
			{
				selectedImage.gameObject.SetActive(value: true);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (enableDropdownSounds && useClickSound)
			{
				soundSource.PlayOneShot(clickSound);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (enableDropdownSounds && useHoverSound)
			{
				soundSource.PlayOneShot(hoverSound);
			}
		}

		public void CreateNewItem(string title, Sprite icon)
		{
			Item item = new Item();
			item.itemName = title;
			item.itemIcon = icon;
			dropdownItems.Add(item);
			SetupDropdown();
		}

		public void CreateNewItemFast(string title, Sprite icon)
		{
			Item item = new Item();
			item.itemName = title;
			item.itemIcon = icon;
			dropdownItems.Add(item);
		}

		public void AddNewItem()
		{
			Item item = new Item();
			dropdownItems.Add(item);
		}
	}
}
