using System;
using System.Collections.Generic;

[Serializable]
[AltDeprecate("Rooms", typeof(HashSet<uint>))]
public class FireReport
{
	public HashSet<uint> SprinklerRooms = new HashSet<uint>();

	public HashSet<uint> AlarmRooms = new HashSet<uint>();

	public HashSet<uint> EscapeRooms = new HashSet<uint>();

	public List<List<SVector3>> EscapePaths = new List<List<SVector3>>();

	public int AlarmViolations;

	public int SprinklerViolations;

	public int EscapeViolations;

	public int ITFixCount;

	public int MaintenanceFixCount;

	public bool SprinklerWarning;

	public bool MaintenanceWarning;

	public bool ITWarning;

	public bool IncludeFee;

	public float Fee;

	public bool Complete;

	public bool Warnings
	{
		get
		{
			if (!SprinklerWarning && !MaintenanceWarning)
			{
				return ITWarning;
			}
			return true;
		}
	}

	public FireReport Copy()
	{
		FireReport obj = new FireReport
		{
			AlarmViolations = AlarmViolations,
			SprinklerViolations = SprinklerViolations,
			EscapeViolations = EscapeViolations,
			ITFixCount = ITFixCount,
			MaintenanceFixCount = MaintenanceFixCount
		};
		obj.AlarmRooms.AddRange(AlarmRooms);
		obj.EscapeRooms.AddRange(EscapeRooms);
		obj.SprinklerRooms.AddRange(SprinklerRooms);
		obj.IncludeFee = IncludeFee;
		obj.Fee = Fee;
		obj.SprinklerWarning = SprinklerWarning;
		obj.MaintenanceWarning = MaintenanceWarning;
		obj.ITWarning = ITWarning;
		return obj;
	}

	public void Reset()
	{
		AlarmViolations = 0;
		SprinklerViolations = 0;
		EscapeViolations = 0;
		ITFixCount = 0;
		MaintenanceFixCount = 0;
		EscapeRooms.Clear();
		AlarmRooms.Clear();
		SprinklerRooms.Clear();
		Fee = 0f;
		SprinklerWarning = false;
		MaintenanceWarning = false;
		ITWarning = false;
	}

	public bool Finish()
	{
		Complete = true;
		int actors = GameSettings.Instance.sActorManager.Staff.Count((Actor x) => !x.OnCall && x.AItype == AI.AIType.Janitor);
		int actors2 = GameSettings.Instance.sActorManager.Staff.Count((Actor x) => !x.OnCall && x.AItype == AI.AIType.IT);
		MaintenanceWarning = CheckWarning(MaintenanceFixCount, actors);
		ITWarning = CheckWarning(ITFixCount, actors2);
		double val = Math.Max(5000.0, GameSettings.Instance.MyCompany.GetMoneyWithInsurance(true, true) * 0.25);
		int count = GameSettings.Instance.sActorManager.Actors.Count;
		Fee = (float)(IncludeFee ? Math.Min(val, (float)count * ((float)EscapeViolations * 200f + (float)AlarmViolations * 100f + (float)SprinklerViolations * 50f)) : 0.0);
		if (EscapeViolations == 0 && AlarmViolations == 0)
		{
			return SprinklerViolations == 0;
		}
		return false;
	}

	public bool Passed()
	{
		if (EscapeViolations == 0 && AlarmViolations == 0)
		{
			return SprinklerViolations == 0;
		}
		return false;
	}

	private bool CheckWarning(int items, int actors)
	{
		if (actors > 0)
		{
			return items / actors > 300;
		}
		if (items > 0)
		{
			return true;
		}
		return false;
	}
}
