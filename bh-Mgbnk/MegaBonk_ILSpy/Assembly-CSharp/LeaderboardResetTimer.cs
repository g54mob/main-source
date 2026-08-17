using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class LeaderboardResetTimer : MonoBehaviour
{
	public TextMeshProUGUI countdownText;

	private void Update()
	{
		//IL_002e: Expected O, but got I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0210: Expected I, but got O
		DateTime utcNow = DateTime.UtcNow;
		DateTime dateTime = default(DateTime);
		DayOfWeek dayOfWeek = dateTime.DayOfWeek;
		object obj = 7 - dayOfWeek;
		DateTime date = dateTime.Date;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
		object obj2 = obj >> 2;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 7;
		double value = (double)obj - (double)obj5;
		DateTime dateTime3 = default(DateTime);
		DateTime dateTime2 = dateTime3.AddDays(value);
		DateTime dateTime4 = dateTime3.AddHours(20.0);
		if (dateTime >= dateTime4)
		{
			DateTime dateTime5 = default(DateTime);
			dateTime4 = dateTime5.AddDays(7.0);
		}
		TimeSpan timeSpan = dateTime4 - utcNow;
		nint num = (nint)typeof(TimeSpan);
		TimeSpan timeSpan2 = default(TimeSpan);
		double totalSeconds = timeSpan2.TotalSeconds;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v13 (Il2CppClass<System.TimeSpan>)+E4]");
		bool flag = (nint)0 <= (nint)0;
		timeSpan2 = timeSpan;
		if (!flag)
		{
			timeSpan2 = TimeSpan.Zero;
		}
		double totalHours = timeSpan2.TotalHours;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int minutes = timeSpan2.Minutes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int seconds = timeSpan2.Seconds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		object arg3 = default(object);
		string text = $"{arg}:{arg2:D2}:<size=90%>{arg3:D2}</size>";
		string text2 = "<size=90%>Reset</size>\n" + text;
		countdownText.text = text2;
	}

	private DateTime GetNextResetUtc(DateTime currentUtc)
	{
		//IL_0020: Expected O, but got I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		DateTime dateTime = default(DateTime);
		DayOfWeek dayOfWeek = dateTime.DayOfWeek;
		object obj = 7 - dayOfWeek;
		DateTime date = dateTime.Date;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebx\"");
		object obj2 = obj >> 2;
		object obj3 = obj2 >> 31;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 * 7;
		double value = (double)obj - (double)obj5;
		DateTime dateTime3 = default(DateTime);
		DateTime dateTime2 = dateTime3.AddDays(value);
		DateTime dateTime4 = dateTime3.AddHours(20.0);
		DateTime dateTime5 = default(DateTime);
		if (dateTime >= dateTime4)
		{
			return dateTime5.AddDays(7.0);
		}
		return dateTime4;
	}
}
