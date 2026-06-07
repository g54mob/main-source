using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DatePicker : MonoBehaviour
{
	[Serializable]
	public class DateEvent : UnityEvent<SDateTime>
	{
	}

	public GUICombobox Day;

	public GUICombobox Month;

	public GUICombobox Year;

	public int YearsIntoFuture;

	public int MaxYearsBack = -1;

	public int MinYear = 1970;

	public bool AutoDay = true;

	public bool UseDays = true;

	private bool _disableUpdate;

	private bool _dateSet;

	private bool _combosSet;

	public DateEvent DateChanged;

	public bool Interactable
	{
		get
		{
			return Year.interactable;
		}
		set
		{
			GUICombobox year = Year;
			GUICombobox month = Month;
			bool flag = (Day.interactable = value);
			bool interactable = (month.interactable = flag);
			year.interactable = interactable;
		}
	}

	public SDateTime CurrentDate
	{
		get
		{
			return new SDateTime(UseDays ? Day.Selected : 0, Month.Selected, Year.Selected + GetFirstYear());
		}
		set
		{
			if (_disableUpdate)
			{
				return;
			}
			_dateSet = true;
			_disableUpdate = true;
			InitCombos();
			UpdateCombos();
			SDateTime sDateTime = SDateTime.Now() + new SDateTime(0, 0, YearsIntoFuture);
			if (value > sDateTime)
			{
				_disableUpdate = false;
				CurrentDate = SDateTime.Now();
				return;
			}
			if (UseDays)
			{
				Day.Selected = value.Day;
			}
			Month.Selected = value.Month;
			int year = value.Year;
			int firstYear = GetFirstYear();
			year = Mathf.Max(firstYear, year);
			year -= firstYear;
			Year.Selected = year;
			_disableUpdate = false;
		}
	}

	private void InitCombos()
	{
		if (_combosSet)
		{
			return;
		}
		if (AutoDay)
		{
			UseDays = GameSettings.DaysPerMonth > 1;
		}
		Day.gameObject.SetActive(UseDays);
		if (UseDays)
		{
			Day.UpdateContent(from x in Enumerable.Range(1, GameSettings.DaysPerMonth)
				select x.ToString());
			Day.OnSelectedChanged.AddListener(delegate
			{
				CurrentDate = CurrentDate;
				if (!_disableUpdate)
				{
					DateChanged.Invoke(CurrentDate);
				}
			});
		}
		Month.UpdateContent(from x in Enumerable.Range(0, 12)
			select SDateTime.Months[x].Loc());
		Month.OnSelectedChanged.AddListener(delegate
		{
			CurrentDate = CurrentDate;
			if (!_disableUpdate)
			{
				DateChanged.Invoke(CurrentDate);
			}
		});
		_combosSet = true;
	}

	public void Start()
	{
		InitCombos();
		Year.OnSelectedChanged.AddListener(delegate
		{
			CurrentDate = CurrentDate;
			if (!_disableUpdate)
			{
				DateChanged.Invoke(CurrentDate);
			}
		});
		if (!_dateSet)
		{
			CurrentDate = SDateTime.Now();
		}
	}

	private int GetFirstYear()
	{
		int a = ((MaxYearsBack >= 0) ? Mathf.Max(0, SDateTime.Now().Year - MaxYearsBack) : 0);
		int b = MinYear - 1900;
		return Mathf.Max(a, b);
	}

	public void UpdateCombos()
	{
		int num = SDateTime.Now().Year + YearsIntoFuture;
		List<string> list = new List<string>();
		for (int i = GetFirstYear(); i <= num; i++)
		{
			list.Add((i + 1900).ToString());
		}
		Year.UpdateContent(list);
	}
}
