namespace Ink.Runtime
{
	public class ControlCommand : Object
	{
		public enum CommandType
		{
			NotSet = -1,
			EvalStart = 0,
			EvalOutput = 1,
			EvalEnd = 2,
			Duplicate = 3,
			PopEvaluatedValue = 4,
			PopFunction = 5,
			PopTunnel = 6,
			BeginString = 7,
			EndString = 8,
			NoOp = 9,
			ChoiceCount = 10,
			Turns = 11,
			TurnsSince = 12,
			ReadCount = 13,
			Random = 14,
			SeedRandom = 15,
			VisitIndex = 16,
			SequenceShuffleIndex = 17,
			StartThread = 18,
			Done = 19,
			End = 20,
			ListFromInt = 21,
			ListRange = 22,
			ListRandom = 23,
			TOTAL_VALUES = 24
		}

		public CommandType commandType { get; protected set; }

		public ControlCommand(CommandType commandType)
		{
		}

		public ControlCommand()
		{
		}

		public override Object Copy()
		{
			return null;
		}

		public static ControlCommand EvalStart()
		{
			return null;
		}

		public static ControlCommand EvalOutput()
		{
			return null;
		}

		public static ControlCommand EvalEnd()
		{
			return null;
		}

		public static ControlCommand Duplicate()
		{
			return null;
		}

		public static ControlCommand PopEvaluatedValue()
		{
			return null;
		}

		public static ControlCommand PopFunction()
		{
			return null;
		}

		public static ControlCommand PopTunnel()
		{
			return null;
		}

		public static ControlCommand BeginString()
		{
			return null;
		}

		public static ControlCommand EndString()
		{
			return null;
		}

		public static ControlCommand NoOp()
		{
			return null;
		}

		public static ControlCommand ChoiceCount()
		{
			return null;
		}

		public static ControlCommand Turns()
		{
			return null;
		}

		public static ControlCommand TurnsSince()
		{
			return null;
		}

		public static ControlCommand ReadCount()
		{
			return null;
		}

		public static ControlCommand Random()
		{
			return null;
		}

		public static ControlCommand SeedRandom()
		{
			return null;
		}

		public static ControlCommand VisitIndex()
		{
			return null;
		}

		public static ControlCommand SequenceShuffleIndex()
		{
			return null;
		}

		public static ControlCommand StartThread()
		{
			return null;
		}

		public static ControlCommand Done()
		{
			return null;
		}

		public static ControlCommand End()
		{
			return null;
		}

		public static ControlCommand ListFromInt()
		{
			return null;
		}

		public static ControlCommand ListRange()
		{
			return null;
		}

		public static ControlCommand ListRandom()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
