using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class CustomDropdown : MonoBehaviour
	{
		public enum AnimationType
		{
			FADING = 0,
			SLIDING = 1,
			STYLISH = 2
		}

		[Serializable]
		public class Item
		{
			public string itemName;

			public Sprite itemIcon;

			public UnityEvent OnItemSelection;
		}

		public bool changeTextOnChange;

		public GameObject triggerObject;

		public TextMeshProUGUI selectedText;

		public Image selectedImage;

		public Transform itemParent;

		public GameObject itemObject;

		public GameObject scrollbar;

		private VerticalLayoutGroup itemList;

		public bool enableIcon;

		public bool enableTrigger;

		public bool enableScrollbar;

		public bool invokeAtStart;

		public AnimationType animationType;

		[Space]
		[SerializeField]
		public List<Item> dropdownItems;

		private List<Item> imageList;

		public int selectedItemIndex;

		[Space]
		private Animator dropdownAnimator;

		private TextMeshProUGUI setItemText;

		private Image setItemImage;

		private Sprite imageHelper;

		private string textHelper;

		private bool isOn;

		private void Start()
		{
		}

		public void ChangeDropdownInfo(int itemIndex)
		{
		}

		public void Animate()
		{
		}
	}
}
