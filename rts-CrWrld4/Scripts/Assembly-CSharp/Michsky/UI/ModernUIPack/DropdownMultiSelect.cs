using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
			public string itemName;

			[SerializeField]
			public ToggleEvent toggleEvents;
		}

		public GameObject triggerObject;

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

		public int selectedItemIndex;

		[Space]
		private Animator dropdownAnimator;

		private TextMeshProUGUI setItemText;

		private string textHelper;

		private bool isOn;

		private int iHelper;

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
