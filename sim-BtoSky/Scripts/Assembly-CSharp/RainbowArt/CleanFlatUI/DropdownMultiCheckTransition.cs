using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class DropdownMultiCheckTransition : TMP_Dropdown
	{
		[Serializable]
		public class DropdownMultiCheckTransitionEvent : UnityEvent
		{
		}

		[SerializeField]
		private List<int> selectedOptions = new List<int>();

		[SerializeField]
		private DropdownMultiCheckTransitionEvent onSelectValueChanged = new DropdownMultiCheckTransitionEvent();

		private Toggle[] toggleList;

		private Animator animatorList;

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

		public DropdownMultiCheckTransitionEvent OnSelectValueChanged
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
			if (animatorList == null)
			{
				Transform transform2 = base.transform.Find("Dropdown List");
				animatorList = transform2.gameObject.GetComponent<Animator>();
			}
			PlayAnimation(bShow: true);
		}

		public new void Hide()
		{
			if (animatorList == null)
			{
				Transform transform = base.transform.Find("Dropdown List");
				animatorList = transform.gameObject.GetComponent<Animator>();
			}
			PlayAnimation(bShow: false);
			base.Hide();
		}

		private void PlayAnimation(bool bShow)
		{
			if (animatorList != null)
			{
				if (!animatorList.enabled)
				{
					animatorList.enabled = true;
				}
				if (bShow)
				{
					animatorList.Play("In", 0, 0f);
				}
				else
				{
					animatorList.Play("Out", 0, 0f);
				}
			}
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
