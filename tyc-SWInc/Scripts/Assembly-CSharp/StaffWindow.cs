using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StaffWindow : MonoBehaviour
{
	public const float JanitorPay = 1500f;

	public const float CleanerPay = 1000f;

	public const float ITPay = 2500f;

	public const float ReceptionPay = 2500f;

	public const float CookPay = 2000f;

	public const float CourierPay = 2000f;

	public const float SecurityPay = 1500f;

	public const float TempJanitorPay = 400f;

	public const float TempCleanerPay = 300f;

	public const float TempITPay = 700f;

	public const float TempITRepair = 500f;

	public const float TempCourierPay = 500f;

	public const float TempCourierBox = 125f;

	public GUIWindow Window;

	public GUIListView StaffList;

	public GUIButton CJan;

	public GUIButton HJan;

	public GUIButton CCle;

	public GUIButton HCle;

	public GUIButton HIT;

	public GUIButton CIT;

	public GUIButton HRec;

	public GUIButton HCo;

	public GUIButton HCor;

	public GUIButton CCor;

	public GUIButton HSec;

	public InputField ArrivalText;

	public Toggle LeaveWhenDone;

	private bool _leaveInit;

	public static bool CanLeaveWhenDone(Actor a)
	{
		if (!a.OnCall)
		{
			if (a.AItype != AI.AIType.Janitor && a.AItype != AI.AIType.IT && a.AItype != AI.AIType.Cleaning)
			{
				return a.AItype == AI.AIType.Courier;
			}
			return true;
		}
		return false;
	}

	private void UpdateLeaveButton()
	{
		Actor[] selected = StaffList.GetSelected<Actor>();
		if (selected.Any(CanLeaveWhenDone))
		{
			_leaveInit = true;
			LeaveWhenDone.gameObject.SetActive(true);
			LeaveWhenDone.isOn = selected.Where(CanLeaveWhenDone).Mode((Actor x) => x.LeaveWhenDone, false);
			_leaveInit = false;
		}
		else
		{
			LeaveWhenDone.gameObject.SetActive(false);
		}
	}

	public void UpdateLeave()
	{
		if (_leaveInit)
		{
			return;
		}
		foreach (Actor item in StaffList.GetSelected<Actor>().Where(CanLeaveWhenDone))
		{
			item.LeaveWhenDone = LeaveWhenDone.isOn;
		}
	}

	private void Start()
	{
		StaffList.OnSelectChange = delegate(bool direct)
		{
			if (direct)
			{
				Actor[] selected = StaffList.GetSelected<Actor>();
				SelectorController instance = SelectorController.Instance;
				Selectable[] selection = selected;
				instance.SetSelection(selection);
				if (selected.Length != 0)
				{
					ArrivalText.text = Utilities.HourToTime(selected[0].StaffOn, SDateTime.AMPM);
				}
			}
			UpdateLeaveButton();
		};
		StaffList.OnDoubleClick = delegate
		{
			Actor firstSelected = StaffList.GetFirstSelected<Actor>();
			if (firstSelected != null && firstSelected.isActiveAndEnabled)
			{
				CameraScript.Instance.MoveTo(firstSelected.GetFlatPos(), firstSelected.GetFloor());
			}
		};
	}

	private int GetArrivalTime()
	{
		return ArrivalText.text.TimeToHour(8);
	}

	public void ApplyArrival()
	{
		Actor[] selected = StaffList.GetSelected<Actor>();
		if (selected.Length != 0 && ArrivalText.text.Trim().Length > 0)
		{
			int arrivalTime = GetArrivalTime();
			Actor[] array = selected;
			foreach (Actor actor in array)
			{
				actor.StaffOn = arrivalTime;
				actor.StaffOff = (actor.StaffOn + actor.GetStaffHours()) % 24;
				RefreshStaffTime(actor);
			}
			CalendarWindow.ScheduleRefresh = true;
		}
	}

	public static void RefreshStaffTime(Actor x)
	{
		if (!x.isActiveAndEnabled)
		{
			SDateTime sDateTime = SDateTime.Now();
			SDateTime sDateTime2 = new SDateTime(Utilities.GaussRange(0.5f, 0, 40), x.StaffOn - 1, sDateTime.Day, sDateTime.Month, sDateTime.Year);
			if (sDateTime2 < SDateTime.Now())
			{
				sDateTime2 += SDateTime.GetDay(1);
			}
			GameSettings.Instance.sActorManager.AddToAwaiting(x, sDateTime2, true);
		}
	}

	private Employee GenerateStaffEmployee(float salary, string style)
	{
		Employee employee = new Employee(SDateTime.Now(), Random.value > 0.5f, salary, style);
		employee.Employ(GameSettings.Instance.MyCompany, SDateTime.Now(), false);
		return employee;
	}

	public void Show()
	{
		if (Window.ToggleReturn())
		{
			CJan.ToolTipValue = 400f.Currency() + "PerHour".Loc();
			HJan.ToolTipValue = 1500f.Currency() + "PerMonth".Loc();
			CCle.ToolTipValue = 300f.Currency() + "PerHour".Loc();
			HCle.ToolTipValue = 1000f.Currency() + "PerMonth".Loc();
			CIT.ToolTipValue = "ITPayment2".Loc(700f.Currency(), 500f.Currency());
			HIT.ToolTipValue = 2500f.Currency() + "PerMonth".Loc();
			HRec.ToolTipValue = 2500f.Currency() + "PerMonth".Loc();
			HCo.ToolTipValue = 2000f.Currency() + "PerMonth".Loc();
			HCor.ToolTipValue = 2000f.Currency() + "PerMonth".Loc();
			CCor.ToolTipValue = "CourierPayment".Loc(500f.Currency(), 125f.Currency());
			CCor.TooltipDescription = "<color=#FF0000>" + "CallCourierWarning".LocColor() + "</color>\n" + "CourierDesc".LocColor();
			HSec.ToolTipValue = 1500.CurrencyInt() + "PerMonth".Loc();
			TutorialSystem.Instance.StartTutorial("Staff");
		}
	}

	public void EmployActor(int type)
	{
		Actor actor = null;
		switch (type)
		{
		case 0:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.Janitor;
			actor.employee = GenerateStaffEmployee(1500f, "Handy");
			break;
		case 1:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.Cleaning;
			actor.employee = GenerateStaffEmployee(1000f, "Cleaning");
			break;
		case 2:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.IT;
			actor.employee = GenerateStaffEmployee(2500f, "Default");
			break;
		case 3:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.Receptionist;
			actor.employee = GenerateStaffEmployee(2500f, "Default");
			break;
		case 4:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.Cook;
			actor.employee = GenerateStaffEmployee(2000f, "Cook");
			break;
		case 5:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.Courier;
			actor.employee = GenerateStaffEmployee(2000f, "Handy");
			break;
		case 6:
			actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = AI.AIType.Security;
			actor.employee = GenerateStaffEmployee(1500f, "Security");
			break;
		}
		if (actor != null)
		{
			actor.StaffOn = GetArrivalTime();
			actor.StaffOff = (actor.StaffOn + actor.GetStaffHours()) % 24;
			SDateTime sDateTime = SDateTime.Now();
			GameSettings.Instance.sActorManager.AddToAwaiting(actor, new SDateTime(Utilities.GaussRange(0.5f, 0, 40), actor.StaffOn - 1, sDateTime.Day + ((actor.StaffOn <= TimeOfDay.Instance.Hour) ? 1 : 0), sDateTime.Month, sDateTime.Year));
		}
	}

	private void SpawnOnCallActor(AI.AIType ai, float upfront, float hourly, string style)
	{
		if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - upfront))
		{
			UISoundFX.PlaySFX("Kaching");
			GameSettings.Instance.MyCompany.MakeTransaction(0f - upfront, Company.TransactionCategory.Staff, true, "Upfront");
			Actor actor = GameSettings.Instance.SpawnActor(Random.value > 0.5f, false);
			actor.AItype = ai;
			actor.WaitSpawn = true;
			GameSettings.Instance.sActorManager.AddToAwaiting(actor, SDateTime.Now(), true);
			actor.StaffOn = TimeOfDay.Instance.Hour;
			actor.employee = GenerateStaffEmployee(hourly, style);
			actor.OnCall = true;
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	public void CallActor(int type)
	{
		switch (type)
		{
		case 0:
			SpawnOnCallActor(AI.AIType.Janitor, 400f, 400f, "Handy");
			break;
		case 1:
			SpawnOnCallActor(AI.AIType.Cleaning, 300f, 300f, "Cleaning");
			break;
		case 2:
			SpawnOnCallActor(AI.AIType.IT, 700f, 0f, "Default");
			break;
		case 3:
			SpawnOnCallActor(AI.AIType.Courier, 500f, 0f, "Handy");
			break;
		}
	}

	public void AssignRoomSelected()
	{
		AssignRoomGroups(StaffList.GetSelected<Actor>().ToList());
	}

	public static void AssignRoomGroups(List<Actor> staff)
	{
		if (staff.Count <= 0)
		{
			return;
		}
		List<string> groups = GameSettings.Instance.GetRoomGroups(true, true).ToList();
		if (groups.Count == 0)
		{
			WindowManager.Instance.ShowMessageBox("NoRoomGroupPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				HUD.Instance.roomGroupWindow.Window.Show();
			});
			return;
		}
		bool[] selected = groups.Select((string x) => staff.Any((Actor z) => z.AssignedRoomGroups.Contains(x))).ToArray();
		string[] values = groups.Select(delegate(string x)
		{
			RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(x);
			return ((roomGroup != null) ? roomGroup.Name : null) ?? "";
		}).ToArray();
		WindowManager.Instance.MultiWindow.ShowMulti("Room groups", values, selected, delegate(int[] r)
		{
			List<string> range = r.Select((int x) => groups[x]).ToList();
			foreach (Actor item in staff)
			{
				item.AssignedRoomGroups.Clear();
				item.AssignedRoomGroups.AddRange(range);
			}
		});
	}
}
