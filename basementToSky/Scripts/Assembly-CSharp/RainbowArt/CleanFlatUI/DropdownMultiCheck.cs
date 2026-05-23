using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class DropdownMultiCheck : TMP_Dropdown
	{
		[Serializable]
		public class DropdownMultiCheckEvent : UnityEvent
		{
		}

		[SerializeField]
		private List<int> selectedOptions = new List<int>();

		[SerializeField]
		private DropdownMultiCheckEvent onSelectValueChanged = new DropdownMultiCheckEvent();

		private Toggle[] toggleList;

		private HashSet<int> selectedOptionsHashSet = new HashSet<int>();

		public int[] SelectedOptions
		{
			get
			{
				int[] array = new int[selectedOptionsHashSet.Count];
				selectedOptionsHashSet.CopyTo(array);
				return array;
			}
			set
			{
				selectedOptionsHashSet.Clear();
				if (value != null)
				{
					foreach (int item in value)
					{
						selectedOptionsHashSet.Add(item);
					}
				}
				onSelectValueChanged.Invoke();
			}
		}

		public DropdownMultiCheckEvent OnSelectValueChanged
		{
			get
			{
				return onSelectValueChanged;
			}
			set
			{
				onSelectValueChanged = value;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			foreach (int selectedOption in selectedOptions)
			{
				selectedOptionsHashSet.Add(selectedOption);
			}
		}

		public bool IsOptionSelected(int index)
		{
			return selectedOptionsHashSet.Contains(index);
		}

		public void SetOptionSelected(int index, bool selected, bool sendEvent = true)
		{
			if (IsOptionSelected(index) != selected)
			{
				if (selected)
				{
					selectedOptionsHashSet.Add(index);
				}
				else
				{
					selectedOptionsHashSet.Remove(index);
				}
				if (sendEvent)
				{
					onSelectValueChanged.Invoke();
				}
			}
		}

		public void UnSelecteAll()
		{
			int count = selectedOptionsHashSet.Count;
			selectedOptionsHashSet.Clear();
			if (count > 0)
			{
				onSelectValueChanged.Invoke();
			}
		}

		public new void Show()
		{
			if (base.transform.Find("Dropdown List") != null)
			{
				return;
			}
			base.Show();
			Transform transform = base.transform.Find("Dropdown List/Viewport/Content");
			toggleList = transform.GetComponentsInChildren<Toggle>(includeInactive: false);
			for (int i = 0; i < toggleList.Length; i++)
			{
				int index = i;
				Toggle obj = toggleList[i];
				obj.onValueChanged.RemoveAllListeners();
				obj.onValueChanged.AddListener(delegate(bool x)
				{
					OnSelectItemCustom(index, x);
				});
				obj.SetIsOnWithoutNotify(IsOptionSelected(i));
			}
		}

		public new void Hide()
		{
			base.Hide();
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			Show();
		}

		private void OnSelectItemCustom(int selectedIndex, bool isSelected)
		{
			SetOptionSelected(selectedIndex, isSelected);
		}
	}
}
