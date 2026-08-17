using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class DateOfBirthField : MonoBehaviour, ISelectableUI, IUIObject
{
	public delegate void OnValueChanged(int val);

	private TextMeshProUGUI _Label;

	private TextMeshProUGUI _ErrorLabel;

	private CustomDropDown _Date;

	private CustomDropDown _Month;

	private CustomDropDown _Year;

	private OnValueChanged m_DayChanged;

	private OnValueChanged m_MonthChanged;

	private OnValueChanged m_YearChanged;

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
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 72;
			Delegate obj2 = this.m_DayChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 72;
			Delegate obj2 = this.m_DayChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnValueChanged MonthChanged
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 80;
			Delegate obj2 = this.m_MonthChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 80;
			Delegate obj2 = this.m_MonthChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnValueChanged YearChanged
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_YearChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_YearChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnValueChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public unsafe void Initialize()
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_00a8: Expected O, but got Ref
		//IL_09bb: Expected O, but got I
		//IL_09cb: Expected O, but got I
		//IL_0b65: Expected I4, but got O
		//IL_0a24: Expected O, but got I
		//IL_0a4b: Expected O, but got Ref
		//IL_0bd8: Expected I4, but got O
		//IL_0c2a: Expected I4, but got O
		List<string> list = new List<string>();
		int num = 1;
		object obj3 = default(object);
		do
		{
			List<int> days = _days;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r8_v5+18]");
			if (num2 >= 0)
			{
				days.AddWithResize(num);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj2 = (nint)0 + (nint)1;
			}
			string item = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj3), null);
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)item);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 32);
		List<object> months = (List<object>)(object)_months;
		int version2 = months._version + 1;
		months._version = version2;
		object[] items2 = months._items;
		if (months._size >= items2.Length)
		{
			months.AddWithResize((object)"January");
		}
		else
		{
			int size2 = months._size + 1;
			months._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months2 = (List<object>)(object)_months;
		int version3 = months2._version + 1;
		months2._version = version3;
		object[] items3 = months2._items;
		if (months2._size >= items3.Length)
		{
			months2.AddWithResize((object)"February");
		}
		else
		{
			int size3 = months2._size + 1;
			months2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months3 = (List<object>)(object)_months;
		int version4 = months3._version + 1;
		months3._version = version4;
		object[] items4 = months3._items;
		if (months3._size >= items4.Length)
		{
			months3.AddWithResize((object)"March");
		}
		else
		{
			int size4 = months3._size + 1;
			months3._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months4 = (List<object>)(object)_months;
		int version5 = months4._version + 1;
		months4._version = version5;
		object[] items5 = months4._items;
		if (months4._size >= items5.Length)
		{
			months4.AddWithResize((object)"April");
		}
		else
		{
			int size5 = months4._size + 1;
			months4._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months5 = (List<object>)(object)_months;
		int version6 = months5._version + 1;
		months5._version = version6;
		object[] items6 = months5._items;
		if (months5._size >= items6.Length)
		{
			months5.AddWithResize((object)"May");
		}
		else
		{
			int size6 = months5._size + 1;
			months5._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months6 = (List<object>)(object)_months;
		int version7 = months6._version + 1;
		months6._version = version7;
		object[] items7 = months6._items;
		if (months6._size >= items7.Length)
		{
			months6.AddWithResize((object)"June");
		}
		else
		{
			int size7 = months6._size + 1;
			months6._size = size7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months7 = (List<object>)(object)_months;
		int version8 = months7._version + 1;
		months7._version = version8;
		object[] items8 = months7._items;
		if (months7._size >= items8.Length)
		{
			months7.AddWithResize((object)"July");
		}
		else
		{
			int size8 = months7._size + 1;
			months7._size = size8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months8 = (List<object>)(object)_months;
		int version9 = months8._version + 1;
		months8._version = version9;
		object[] items9 = months8._items;
		if (months8._size >= items9.Length)
		{
			months8.AddWithResize((object)"August");
		}
		else
		{
			int size9 = months8._size + 1;
			months8._size = size9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months9 = (List<object>)(object)_months;
		int version10 = months9._version + 1;
		months9._version = version10;
		object[] items10 = months9._items;
		if (months9._size >= items10.Length)
		{
			months9.AddWithResize((object)"September");
		}
		else
		{
			int size10 = months9._size + 1;
			months9._size = size10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months10 = (List<object>)(object)_months;
		int version11 = months10._version + 1;
		months10._version = version11;
		object[] items11 = months10._items;
		if (months10._size >= items11.Length)
		{
			months10.AddWithResize((object)"October");
		}
		else
		{
			int size11 = months10._size + 1;
			months10._size = size11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months11 = (List<object>)(object)_months;
		int version12 = months11._version + 1;
		months11._version = version12;
		object[] items12 = months11._items;
		if (months11._size >= items12.Length)
		{
			months11.AddWithResize((object)"November");
		}
		else
		{
			int size12 = months11._size + 1;
			months11._size = size12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		List<object> months12 = (List<object>)(object)_months;
		int version13 = months12._version + 1;
		months12._version = version13;
		object[] items13 = months12._items;
		if (months12._size >= items13.Length)
		{
			months12.AddWithResize((object)"December");
		}
		else
		{
			int size13 = months12._size + 1;
			months12._size = size13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		DateTime now = DateTime.Now;
		DateTime dateTime = default(DateTime);
		int datePart = dateTime.GetDatePart(0);
		List<string> list2 = new List<string>();
		bool flag = datePart <= 1923;
		int num3 = 1923;
		Action<int> action = default(Action<int>);
		if (!flag)
		{
			bool flag2;
			do
			{
				List<int> years = _years;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v35+18]");
				if (num4 >= 0)
				{
					years.AddWithResize(num3);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v50 (System.Collections.Generic.List`1<System.Int32>)+18]");
					object obj6 = (nint)0 + (nint)1;
				}
				string item2 = System.Number.FormatInt32(num3, (ReadOnlySpan<char>)(&obj3), null);
				int version14 = list2._version + 1;
				list2._version = version14;
				List<string> items14 = (List<string>)(object)list2._items;
				if (list2._size >= items14._size)
				{
					((List<object>)(object)list2).AddWithResize((object)item2);
				}
				else
				{
					int size14 = list2._size + 1;
					list2._size = size14;
					items14._002Ector();
				}
				num3++;
				flag2 = num3 < datePart;
				action = action;
			}
			while (flag2);
		}
		((List<string>)(object)_years)._002Ector();
		((List<object>)(object)list2).Reverse();
		List<object> options = new List<object>(list);
		Action<int> action2 = null;
		((DateOfBirthField)(object)action2).SetDate((int)this);
		bool clearCurrentOptions = default(bool);
		_Date.InitialSet("Date", options, 0, action, clearCurrentOptions);
		if (_months != null)
		{
			List<object> options2 = new List<object>(_months);
			Action<int> action3 = null;
			((DateOfBirthField)(object)action3).SetMonth((int)this);
			_Month.InitialSet("Month", options2, 0, action, clearCurrentOptions);
			List<object> options3 = new List<object>(list2);
			Action<int> action4 = null;
			((DateOfBirthField)(object)action4).SetYear((int)this);
			_Year.InitialSet("Year", options3, 0, action, clearCurrentOptions);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void SetLabel(string label)
	{
		_Label.text = label;
	}

	public void SetError(string label)
	{
		_ErrorLabel.text = label;
	}

	private void SetDate(int i)
	{
		//IL_004b: Expected O, but got I
		OnValueChanged dayChanged = this.m_DayChanged;
		_selectedDayIndex = i;
		if (this.m_DayChanged != null)
		{
			List<int> days = _days;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)i < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v33.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private void SetMonth(int i)
	{
		//IL_0041: Expected O, but got I4
		OnValueChanged monthChanged = this.m_MonthChanged;
		_selectedMonthIndex = i;
		if (this.m_MonthChanged != null)
		{
			object obj = i + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void SetYear(int i)
	{
		//IL_004b: Expected O, but got I
		OnValueChanged yearChanged = this.m_YearChanged;
		_selectedYearIndex = i;
		if (this.m_YearChanged != null)
		{
			List<int> years = _years;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)i < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v33.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public Selectable GetSelectable()
	{
		CustomDropDown date = _Date;
		if ((object)_Date != null)
		{
			return date._DropDown;
		}
		return (Selectable)(object)new NullReferenceException();
	}

	public unsafe void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
	{
		//IL_003f: Expected O, but got Ref
		//IL_0056: Expected O, but got Ref
		//IL_006d: Expected O, but got Ref
		CustomDropDown date = _Date;
		CustomDropDown month = _Month;
		CustomDropDown year = _Year;
		object obj = default(object);
		date._DropDown.navigation = (Navigation)(&obj);
		month._DropDown.navigation = (Navigation)(&obj);
		year._DropDown.navigation = (Navigation)(&obj);
		Selectable right2 = default(Selectable);
		_Date.UpdateNavigation(above, below, null, right2);
		_Month.UpdateNavigation(above, below, date._DropDown, right2);
		Selectable right3 = default(Selectable);
		_Year.UpdateNavigation(above, below, month._DropDown, right3);
	}

	private unsafe void SetNavigationMode(Selectable s)
	{
		//IL_000d: Expected O, but got Ref
		object obj = default(object);
		s.navigation = (Navigation)(&obj);
	}

	public DateOfBirthField()
	{
		List<int> days = new List<int>();
		_days = days;
		List<string> months = new List<string>();
		_months = months;
		List<int> years = new List<int>();
		_years = years;
	}
}
