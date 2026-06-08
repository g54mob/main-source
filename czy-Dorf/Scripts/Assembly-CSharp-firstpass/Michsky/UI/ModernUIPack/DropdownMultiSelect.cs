using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class DropdownMultiSelect : MonoBehaviour
	{
		[Serializable]
		public class ToggleEvent : UnityEvent<bool>
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

			public bool isOn;

			[SerializeField]
			public ToggleEvent toggleEvents;
		}

		public GameObject triggerObject;

		public Transform itemParent;

		public GameObject itemObject;

		public GameObject scrollbar;

		private VerticalLayoutGroup itemList;

		private Transform currentListParent;

		public Transform listParent;

		private Animator dropdownAnimator;

		public TextMeshProUGUI setItemText;

		public bool enableIcon = true;

		public bool enableTrigger = true;

		public bool enableScrollbar = true;

		public bool setHighPriorty = true;

		public bool outOnPointerExit;

		public bool isListItem;

		public AnimationType animationType;

		public bool saveSelected;

		public bool invokeAtStart;

		public string toggleTag = "Multi Dropdown";

		[SerializeField]
		public List<Item> dropdownItems = new List<Item>();

		private string textHelper;

		private string newItemTitle;

		private Sprite newItemIcon;

		private bool isOn;

		public int iHelper;

		public int siblingIndex;

		private void Start()
		{
			try
			{
				dropdownAnimator = GetComponent<Animator>();
				itemList = itemParent.GetComponent<VerticalLayoutGroup>();
				itemList = itemParent.GetComponent<VerticalLayoutGroup>();
				SetupDropdown();
				currentListParent = base.transform.parent;
			}
			catch
			{
				Debug.LogError("Dropdown - Cannot initalize the object due to missing resources.", this);
			}
			if (enableScrollbar)
			{
				itemList.padding.right = 25;
				scrollbar.SetActive(value: true);
			}
			else
			{
				itemList.padding.right = 8;
				UnityEngine.Object.Destroy(scrollbar);
			}
			if (setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
		}

		public void SetupDropdown()
		{
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < dropdownItems.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(itemObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(itemParent, worldPositionStays: false);
				setItemText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
				textHelper = dropdownItems[i].itemName;
				setItemText.text = textHelper;
				Toggle component = gameObject.GetComponent<Toggle>();
				iHelper = i;
				component.onValueChanged.AddListener(UpdateToggle);
				if (dropdownItems[i].toggleEvents != null)
				{
					component.onValueChanged.AddListener(dropdownItems[i].toggleEvents.Invoke);
				}
				if (saveSelected)
				{
					if (invokeAtStart)
					{
						if (PlayerPrefs.GetInt(toggleTag + "Toggle") == 1)
						{
							dropdownItems[i].toggleEvents.Invoke(arg0: true);
						}
						else
						{
							dropdownItems[i].toggleEvents.Invoke(arg0: false);
						}
					}
					else
					{
						component.onValueChanged.AddListener(SaveToggle);
					}
				}
				else if (invokeAtStart)
				{
					if (dropdownItems[i].isOn)
					{
						dropdownItems[i].toggleEvents.Invoke(arg0: true);
					}
					else
					{
						dropdownItems[i].toggleEvents.Invoke(arg0: false);
					}
				}
				else if (dropdownItems[i].isOn)
				{
					component.isOn = true;
				}
				else
				{
					component.isOn = false;
				}
				if (invokeAtStart)
				{
					if (dropdownItems[i].isOn)
					{
						dropdownItems[i].toggleEvents.Invoke(arg0: true);
					}
					else
					{
						dropdownItems[i].toggleEvents.Invoke(arg0: false);
					}
				}
			}
			currentListParent = base.transform.parent;
		}

		public void UpdateToggle(bool isOn)
		{
		}

		public void SaveToggle(bool isOn)
		{
			if (isOn)
			{
				PlayerPrefs.SetInt(toggleTag + "Toggle" + iHelper, 1);
			}
			else
			{
				PlayerPrefs.SetInt(toggleTag + "Toggle" + iHelper, 0);
			}
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
			if (outOnPointerExit)
			{
				if (isOn)
				{
					Animate();
					isOn = false;
				}
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
		}

		public void CreateNewItem()
		{
			Item item = new Item();
			item.itemName = newItemTitle;
			dropdownItems.Add(item);
			SetupDropdown();
		}

		public void SetItemTitle(string title)
		{
			newItemTitle = title;
		}

		public void AddNewItem()
		{
			Item item = new Item();
			dropdownItems.Add(item);
		}
	}
}
