using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class DropdownMultiCheckTransition : Dropdown
	{
		[Serializable]
		public class DropdownMultiCheckTransitionEvent : UnityEvent
		{
		}

		[SerializeField]
		private List<int> selectedOptions;

		[SerializeField]
		private DropdownMultiCheckTransitionEvent onSelectValueChanged;

		private Toggle[] toggleList;

		private Animator animatorList;

		private HashSet<int> selectedOptionsHashSet;

		public int[] SelectedOptions
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DropdownMultiCheckTransitionEvent OnSelectValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public bool IsOptionSelected(int index)
		{
			return false;
		}

		public void SetOptionSelected(int index, bool selected, bool sendEvent = true)
		{
		}

		public void UnSelecteAll()
		{
		}

		public new void Show()
		{
		}

		public new void Hide()
		{
		}

		private void PlayAnimation(bool bShow)
		{
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		private void OnSelectItemCustom(int selectedIndex, bool isSelected)
		{
		}
	}
}
