using System;

namespace MoonSharp.Interpreter.Debugging
{
	public class DebuggerAction
	{
		public enum ActionType
		{
			ByteCodeStepIn = 0,
			ByteCodeStepOver = 1,
			ByteCodeStepOut = 2,
			StepIn = 3,
			StepOver = 4,
			StepOut = 5,
			Run = 6,
			ToggleBreakpoint = 7,
			SetBreakpoint = 8,
			ClearBreakpoint = 9,
			Refresh = 10,
			HardRefresh = 11,
			None = 12
		}

		public ActionType Action { get; set; }

		public DateTime TimeStampUTC { get; private set; }

		public int SourceID { get; set; }

		public int SourceLine { get; set; }

		public int SourceCol { get; set; }

		public TimeSpan Age
		{
			get
			{
				return DateTime.UtcNow - TimeStampUTC;
			}
		}

		public DebuggerAction()
		{
			TimeStampUTC = DateTime.UtcNow;
		}

		public override string ToString()
		{
			if (Action == ActionType.ToggleBreakpoint || Action == ActionType.SetBreakpoint || Action == ActionType.ClearBreakpoint)
			{
				return string.Format("{0} {1}:({2},{3})", Action, SourceID, SourceLine, SourceCol);
			}
			return Action.ToString();
		}
	}
}
