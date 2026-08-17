using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class ReleaseDateData
{
	[Serializable]
	public struct DateInt
	{
		public int _Day;

		public int _Month;

		public int _Year;
	}

	[Serializable]
	public struct TimeInt
	{
		public int _Hour;

		public int _Minute;

		public int _Second;
	}

	public DateInt _Date;

	public TimeInt _Time;

	public DateTime GetUtcDateTime()
	{
		//IL_0037: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.ReleaseDateData)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.ReleaseDateData)+14]");
		int hour = default(int);
		int minute = default(int);
		int second = default(int);
		DateTimeKind kind = default(DateTimeKind);
		DateTime result = new DateTime((int)num, 0, (int)_Date, hour, minute, second, kind);
		return result;
	}

	public bool HasDatePassed()
	{
		//IL_0045: Expected I4, but got O
		//IL_0058: Expected O, but got I4
		DateTime utcNow = DateTime.UtcNow;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.ReleaseDateData)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.ReleaseDateData)+14]");
		int hour = default(int);
		int minute = default(int);
		int second = default(int);
		DateTimeKind kind = default(DateTimeKind);
		DateTime dateTime = new DateTime((int)num, 0, (int)_Date, hour, minute, second, kind);
		return utcNow > (DateTime)0;
	}
}
