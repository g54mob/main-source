using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlotControl : MonoBehaviour
{
	public Text TeamLabel;

	public Text CountLabel;

	public RectTransform Self;

	public Sprite LTimeSlotSprite;

	public Sprite TimeSlotSprite;

	public Sprite RTimeSlotSprite;

	public Image Slot1;

	public Image Slot2;

	public Color[] Colors;

	[NonSerialized]
	public Team CTeam;

	[NonSerialized]
	public List<Actor> Staff;

	[NonSerialized]
	private bool _isDragging;

	[NonSerialized]
	private bool _isResizingStart;

	[NonSerialized]
	private bool _isResizingEnd;

	[NonSerialized]
	private bool _vacationMode;

	[NonSerialized]
	private CalendarWindow _parent;

	private int _initialOffset;

	private int _initialStart;

	private int _initialEnd;

	public int PeriodStart
	{
		get
		{
			if (Staff == null)
			{
				if (!_vacationMode)
				{
					return CTeam.WorkStart;
				}
				return CTeam.VacationMonth;
			}
			return Staff[0].StaffOn;
		}
		set
		{
			if (Staff != null)
			{
				foreach (Actor item in Staff)
				{
					item.StaffOn = value;
					item.StaffOff = (value + item.GetStaffHours()) % 24;
					StaffWindow.RefreshStaffTime(item);
				}
				return;
			}
			if (_vacationMode)
			{
				if (CTeam.VacationMonth != value)
				{
					int periodEnd = PeriodEnd;
					CTeam.VacationMonth = value;
					PeriodEnd = periodEnd;
					CTeam.RescheduleVacations();
				}
			}
			else
			{
				CTeam.ChangeWorkStart(value);
			}
		}
	}

	public int PeriodEnd
	{
		get
		{
			if (Staff == null)
			{
				if (!_vacationMode)
				{
					return CTeam.WorkEnd;
				}
				return KeepWithin(CTeam.VacationMonth + CTeam.VacationSpread + 1);
			}
			return Staff[0].StaffOff;
		}
		set
		{
			if (Staff != null)
			{
				return;
			}
			if (_vacationMode)
			{
				int time = ((CTeam.VacationMonth <= value) ? (value - CTeam.VacationMonth - 1) : (12 - CTeam.VacationMonth + value - 1));
				time = KeepWithin(time);
				if (CTeam.VacationSpread != time)
				{
					CTeam.VacationSpread = time;
					CTeam.RescheduleVacations();
				}
			}
			else
			{
				CTeam.ChangeWorkEnd(value);
			}
		}
	}

	public int MaxValue
	{
		get
		{
			if (!_vacationMode)
			{
				return 24;
			}
			return 12;
		}
	}

	public bool CanTouch
	{
		get
		{
			return _vacationMode;
		}
	}

	public bool CanResize
	{
		get
		{
			return Staff == null;
		}
	}

	public bool CanSplit
	{
		get
		{
			return Staff != null;
		}
	}

	public void SetVacationMode(bool vacationMode)
	{
		_vacationMode = vacationMode;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (Staff != null)
		{
			CountLabel.text = Staff.Count.ToString();
		}
		else
		{
			CountLabel.text = CTeam.Count.ToString();
			Image slot = Slot2;
			Color color = (Slot1.color = CTeam.TeamColor);
			slot.color = color;
		}
		if (_isDragging)
		{
			Vector2 localPoint;
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
			else if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				int num = Mathf.FloorToInt(localPoint.x / Self.rect.width * (float)MaxValue) - _initialOffset;
				PeriodStart = KeepWithin(_initialStart + num);
				PeriodEnd = KeepWithin(_initialEnd + num);
			}
		}
		if (_isResizingStart)
		{
			Vector2 localPoint2;
			if (Input.GetMouseButtonUp(0))
			{
				_isResizingStart = false;
			}
			else if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint2))
			{
				int num2 = Mathf.FloorToInt(localPoint2.x / Self.rect.width * (float)MaxValue) - _initialOffset;
				int num3 = KeepWithin(_initialStart + num2);
				if (!CanTouch && num3 == PeriodEnd)
				{
					num3 = KeepWithin(PeriodEnd - 1);
				}
				PeriodStart = num3;
			}
		}
		if (_isResizingEnd)
		{
			Vector2 localPoint3;
			if (Input.GetMouseButtonUp(0))
			{
				_isResizingEnd = false;
			}
			else if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint3))
			{
				int num4 = Mathf.FloorToInt(localPoint3.x / Self.rect.width * (float)MaxValue) - _initialOffset;
				int num5 = KeepWithin(_initialEnd + num4);
				if (!CanTouch && PeriodStart == num5)
				{
					num5 = KeepWithin(PeriodStart + 1);
				}
				PeriodEnd = num5;
			}
		}
		SetTime(PeriodStart, PeriodEnd);
	}

	private int KeepWithin(int time)
	{
		if (time >= 0)
		{
			return time % MaxValue;
		}
		return MaxValue - Mathf.Abs(time) % MaxValue;
	}

	public void Init(Team t, CalendarWindow parent)
	{
		CTeam = t;
		TeamLabel.text = CTeam.Name;
		_parent = parent;
	}

	public void Init(Actor s, CalendarWindow parent)
	{
		Staff = new List<Actor> { s };
		TeamLabel.text = Staff[0].AItype.ToString().Loc();
		Image slot = Slot1;
		Color color = (Slot2.color = Colors[CalendarWindow.GetAITypeIndex(Staff[0].AItype)]);
		slot.color = color;
		_parent = parent;
	}

	public void SetTime(int start, int end)
	{
		if (end == 0)
		{
			end = MaxValue;
		}
		if (start >= end)
		{
			Slot2.gameObject.SetActive(true);
			SetSlot(Slot1.rectTransform, 0, end);
			SetSlot(Slot2.rectTransform, start, MaxValue);
			Slot1.sprite = LTimeSlotSprite;
			Slot2.sprite = RTimeSlotSprite;
		}
		else
		{
			Slot2.gameObject.SetActive(false);
			SetSlot(Slot1.rectTransform, start, end);
			Slot1.sprite = TimeSlotSprite;
		}
	}

	private void SetSlot(RectTransform slot, int start, int end)
	{
		slot.anchorMin = new Vector2((float)start / (float)MaxValue, slot.anchorMin.y);
		slot.anchorMax = new Vector2((float)end / (float)MaxValue, slot.anchorMax.y);
		slot.offsetMin = new Vector2(1f, 0f);
		slot.offsetMax = new Vector2(-1f, 0f);
	}

	public void StartDrag(int slot)
	{
		Vector2 localPoint;
		if (Input.GetMouseButton(1))
		{
			if (Staff != null && Staff.Count > 1)
			{
				_parent.StartSplit(this);
			}
		}
		else if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			_isDragging = true;
			_initialOffset = Mathf.FloorToInt(localPoint.x / Self.rect.width * (float)MaxValue);
			_initialStart = PeriodStart;
			_initialEnd = PeriodEnd;
		}
	}

	public void StartResizeSlot1(bool start)
	{
		if (!CanResize)
		{
			return;
		}
		int num = ((PeriodEnd == 0) ? MaxValue : PeriodEnd);
		Vector2 localPoint;
		if ((!start || PeriodStart <= num) && RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			_initialOffset = Mathf.FloorToInt(localPoint.x / Self.rect.width * (float)MaxValue);
			_initialStart = PeriodStart;
			_initialEnd = PeriodEnd;
			if (start)
			{
				_isResizingStart = true;
			}
			else
			{
				_isResizingEnd = true;
			}
		}
	}

	public void StartResizeSlot2(bool start)
	{
		Vector2 localPoint;
		if (CanResize && RectTransformUtility.ScreenPointToLocalPointInRectangle(Self, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			_initialOffset = Mathf.FloorToInt(localPoint.x / Self.rect.width * (float)MaxValue);
			_initialStart = PeriodStart;
			_initialEnd = PeriodEnd;
			if (start)
			{
				_isResizingStart = true;
			}
			else
			{
				_isResizingEnd = true;
			}
		}
	}
}
