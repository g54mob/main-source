using System;
using Cpp2ILInjected;

namespace Assets.Scripts.UI.HUD.Chatbox;

public class TimerUtility
{
	public static string TimerToString(float time)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		TimeSpan timeSpan = TimeSpan.FromSeconds(0.0);
		TimeSpan timeSpan2 = default(TimeSpan);
		int minutes = timeSpan2.Minutes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int seconds = timeSpan2.Seconds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int milliseconds = timeSpan2.Milliseconds;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		object arg3 = default(object);
		return $"{arg}:{arg2:D2}<size=75%>.{arg3:00}</size>";
	}
}
