using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class DateOfBirthField : MonoBehaviour, ISelectableUI, IUIObject
	{
		public delegate void OnValueChanged(int val);

		[SerializeField]
		private TextMeshProUGUI _Label;

		[SerializeField]
		private TextMeshProUGUI _ErrorLabel;

		[SerializeField]
		private CustomDropDown _Date;

		[SerializeField]
		private CustomDropDown _Month;

		[SerializeField]
		private CustomDropDown _Year;

		private DateTime _date;

		private List<int> _days;

		private List<string> _months;

		private List<int> _years;

		private int _selectedDayIndex;

		private int _selectedMonthIndex;

		private int _selectedYearIndex;

		private bool _hasSetDate;

		private bool _hasSetMonth;

		private bool _hasSetYear;

		public event OnValueChanged DayChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnValueChanged MonthChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnValueChanged YearChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Initialize()
		{
		}

		public void SetLabel(string label)
		{
		}

		public void SetError(string label)
		{
		}

		private void SetDate(int i)
		{
		}

		private void SetMonth(int i)
		{
		}

		private void SetYear(int i)
		{
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
		{
		}

		private void SetNavigationMode(Selectable s)
		{
		}
	}
}
