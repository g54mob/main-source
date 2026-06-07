using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CalendarWindow : MonoBehaviour
{
	public struct StaffKey
	{
		public int WorkStart;

		public AI.AIType Type;

		public StaffKey(int workStart, AI.AIType type)
		{
			WorkStart = workStart;
			Type = type;
		}

		public StaffKey(Actor a)
		{
			WorkStart = a.StaffOn;
			Type = a.AItype;
		}

		public bool Equals(StaffKey other)
		{
			if (WorkStart == other.WorkStart)
			{
				return Type == other.Type;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			object obj2;
			if ((obj2 = obj) is StaffKey)
			{
				StaffKey other = (StaffKey)obj2;
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (WorkStart * 397) ^ (int)Type;
		}
	}

	public class EmpKey
	{
		public readonly int Start;

		public readonly int End;

		public readonly int Type;

		public EmpKey(Actor act)
		{
			Type = GetAITypeIndex(act.AItype);
			if (act.IsEmployee())
			{
				Team team = act.GetTeam();
				if (team == null)
				{
					Start = 8;
					End = 16;
				}
				else
				{
					Start = team.WorkStart;
					End = team.WorkEnd;
				}
			}
			else
			{
				Start = act.StaffOn;
				End = act.StaffOff;
			}
		}

		public override bool Equals(object obj)
		{
			EmpKey empKey = obj as EmpKey;
			if (empKey != null && Start == empKey.Start && End == empKey.End)
			{
				return Type == empKey.Type;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((1879799094 * -1521134295 + Start.GetHashCode()) * -1521134295 + End.GetHashCode()) * -1521134295 + Type.GetHashCode();
		}
	}

	public GUIWindow Window;

	public Button MonthButton;

	public GameObject VacationDelimit;

	public GameObject HourDelimit;

	public RectTransform TimeLine;

	public RectTransform SplitSliderRect;

	public RectTransform ScrollView;

	public Text CurrentMonthLabel;

	public Text SplitLabel;

	public TimeSlotControl TimeSlotPrefab;

	public Slider SplitSlider;

	public Toggle VacationToggle;

	public Toggle StaffToggle;

	public Text[] HourDelimText;

	private bool _init;

	private int _activeMonth;

	private Button[] _monthButtons;

	private Text[] _monthLabels;

	private GUIProgressBar[] _monthProgs;

	[NonSerialized]
	private Dictionary<Team, TimeSlotControl> _timeSlots = new Dictionary<Team, TimeSlotControl>();

	[NonSerialized]
	private Dictionary<StaffKey, TimeSlotControl> _staffSlots = new Dictionary<StaffKey, TimeSlotControl>();

	[NonSerialized]
	private TimeSlotControl _splitting;

	public static bool ScheduleRefresh;

	[NonSerialized]
	private HashSet<Actor> _staffCheck = new HashSet<Actor>();

	private void Update()
	{
		if (ScheduleRefresh)
		{
			Refresh();
		}
		if (!SplitSlider.gameObject.activeSelf)
		{
			return;
		}
		SplitLabel.text = ((int)SplitSlider.value).ToString();
		Vector2 localPoint;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(SplitSliderRect, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			SplitSlider.value = ((0f - localPoint.y) / SplitSliderRect.rect.height).MapRange(1f, 0f, SplitSlider.minValue, SplitSlider.maxValue, true);
		}
		if (Input.GetMouseButtonUp(1))
		{
			SelectorController.CanClick = false;
			List<Actor> list = _splitting.Staff.Take(_splitting.Staff.Count - (int)SplitSlider.value).ToList();
			for (int i = 0; i < list.Count; i++)
			{
				_splitting.Staff.Remove(list[i]);
			}
			TimeSlotControl timeSlotControl = UnityEngine.Object.Instantiate(TimeSlotPrefab);
			timeSlotControl.Init(list[0], this);
			for (int j = 1; j < list.Count; j++)
			{
				timeSlotControl.Staff.Add(list[j]);
			}
			timeSlotControl.transform.SetParent(TimeLine, false);
			_staffSlots[new StaffKey(_staffSlots.Keys.Min((StaffKey x) => x.WorkStart) - 1, list[0].AItype)] = timeSlotControl;
			RefreshOrder();
			SplitSlider.gameObject.SetActive(false);
		}
	}

	public void StartSplit(TimeSlotControl c)
	{
		SplitSlider.gameObject.SetActive(true);
		SplitSlider.minValue = 1f;
		SplitSlider.value = c.Staff.Count / 2;
		SplitSlider.maxValue = c.Staff.Count - 1;
		SplitSliderRect.transform.position = c.Self.transform.position + new Vector3(TimeLine.rect.width / 2f, SplitSliderRect.rect.height / 2f, 0f);
		_splitting = c;
	}

	public void ClearSplit()
	{
		SplitSlider.gameObject.SetActive(false);
		_splitting = null;
	}

	public void Refresh()
	{
		Init();
		ScheduleRefresh = false;
		if (StaffToggle.isOn)
		{
			_staffCheck.Clear();
			foreach (KeyValuePair<StaffKey, TimeSlotControl> s in _staffSlots.ToList())
			{
				s.Value.Staff.RemoveAll((Actor x) => !x.IsAliveNotNull() || x.StaffOn != s.Key.WorkStart);
				if (s.Value.Staff.Count == 0)
				{
					UnityEngine.Object.Destroy(s.Value.gameObject);
					_staffSlots.Remove(s.Key);
					ClearSplit();
				}
				else
				{
					_staffCheck.AddRange(s.Value.Staff);
				}
			}
			foreach (Actor item in from x in GameSettings.Instance.sActorManager.Staff
				where !x.OnCall
				orderby x.AItype, x.StaffOn
				select x)
			{
				if (!_staffCheck.Contains(item))
				{
					StaffKey key = new StaffKey(item);
					TimeSlotControl value;
					if (_staffSlots.TryGetValue(key, out value))
					{
						value.Staff.Add(item);
						continue;
					}
					TimeSlotControl timeSlotControl = UnityEngine.Object.Instantiate(TimeSlotPrefab);
					timeSlotControl.Init(item, this);
					timeSlotControl.transform.SetParent(TimeLine, false);
					_staffSlots[key] = timeSlotControl;
				}
			}
			_staffCheck.Clear();
		}
		else
		{
			foreach (Team item2 in _timeSlots.Keys.ToList())
			{
				if (!GameSettings.Instance.sActorManager.Teams.ContainsValue(item2))
				{
					UnityEngine.Object.Destroy(_timeSlots[item2].gameObject);
					_timeSlots.Remove(item2);
				}
			}
			foreach (Team item3 in GameSettings.Instance.sActorManager.Teams.Values.OrderBy((Team x) => x.Name))
			{
				if (!_timeSlots.ContainsKey(item3))
				{
					TimeSlotControl timeSlotControl2 = UnityEngine.Object.Instantiate(TimeSlotPrefab);
					timeSlotControl2.Init(item3, this);
					timeSlotControl2.SetVacationMode(VacationToggle.isOn);
					timeSlotControl2.transform.SetParent(TimeLine, false);
					_timeSlots[item3] = timeSlotControl2;
				}
			}
		}
		RefreshOrder();
	}

	public void RefreshOrder()
	{
		int num = 0;
		foreach (TimeSlotControl value in _timeSlots.Values)
		{
			value.Self.anchoredPosition = new Vector2(0f, -num * 36);
			value.Self.offsetMin = new Vector2(0f, value.Self.offsetMin.y);
			value.Self.offsetMax = new Vector2(0f, value.Self.offsetMax.y);
			num++;
		}
		foreach (TimeSlotControl value2 in _staffSlots.Values)
		{
			value2.Self.anchoredPosition = new Vector2(0f, -num * 36);
			value2.Self.offsetMin = new Vector2(0f, value2.Self.offsetMin.y);
			value2.Self.offsetMax = new Vector2(0f, value2.Self.offsetMax.y);
			num++;
		}
		TimeLine.sizeDelta = new Vector2(TimeLine.sizeDelta.x, num * 36 - 4);
	}

	public static int GetAITypeIndex(AI.AIType type)
	{
		switch (type)
		{
		case AI.AIType.Janitor:
			return 1;
		case AI.AIType.Cleaning:
			return 2;
		case AI.AIType.IT:
			return 3;
		case AI.AIType.Receptionist:
			return 4;
		case AI.AIType.Cook:
			return 5;
		case AI.AIType.Courier:
			return 6;
		case AI.AIType.Security:
			return 7;
		default:
			return 0;
		}
	}

	public void SetTimeLineMonth(int m = -1)
	{
	}

	public List<Actor> GetWorking(int month, bool staff)
	{
		List<Actor> list = new List<Actor>();
		int month2 = SDateTime.Now().Month;
		for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors[i];
			if (actor.GetTeam() == null)
			{
				continue;
			}
			int num = Mathf.RoundToInt(actor.GetBenefitValue("Vacation months"));
			bool flag = actor.employee.Founder || month < actor.AlternateVacation.Month || month >= actor.AlternateVacation.Month + num;
			if (flag && month >= month2 && actor.TakingCourses)
			{
				SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(actor);
				if (arriveTime.HasValue && month < arriveTime.Value.Month)
				{
					flag = false;
				}
			}
			if (flag)
			{
				list.Add(actor);
			}
		}
		if (staff)
		{
			foreach (Actor item in GameSettings.Instance.sActorManager.Staff)
			{
				if (!item.OnCall)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public void Show()
	{
		Show(false);
	}

	public void Show(bool force)
	{
		if (force)
		{
			Window.Show();
			Refresh();
		}
		else if (Window.ToggleReturn())
		{
			Refresh();
		}
	}

	public void ShowSpecific(bool staff)
	{
		Window.Show();
		if (staff)
		{
			StaffToggle.isOn = true;
		}
		else
		{
			StaffToggle.isOn = false;
			VacationToggle.isOn = false;
		}
		Refresh();
	}

	public void UpdateVacationMode()
	{
		CurrentMonthLabel.text = (VacationToggle.isOn ? "Vacation".Loc() : "Workinghours".Loc());
		VacationDelimit.SetActive(VacationToggle.isOn);
		HourDelimit.SetActive(!VacationToggle.isOn);
		_timeSlots.Values.ForEachEnum(delegate(TimeSlotControl x)
		{
			x.SetVacationMode(VacationToggle.isOn);
		});
	}

	public void UpdateStaff()
	{
		if (StaffToggle.isOn)
		{
			VacationToggle.isOn = false;
			VacationToggle.gameObject.SetActive(false);
		}
		else
		{
			VacationToggle.gameObject.SetActive(true);
		}
		_staffSlots.Values.ForEachEnum(delegate(TimeSlotControl x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		_staffSlots.Clear();
		_timeSlots.Values.ForEachEnum(delegate(TimeSlotControl x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		_timeSlots.Clear();
		ClearSplit();
		Refresh();
	}

	private void Init()
	{
		if (!_init)
		{
			UpdateVacationMode();
			for (int i = 0; i < HourDelimText.Length; i++)
			{
				HourDelimText[i].text = Utilities.HourToTime(i, Options.AMPM, true);
			}
			_init = true;
		}
	}
}
