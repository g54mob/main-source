using System;
using ModApi.Craft.Program.Instructions;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public class Thread
	{
		private static int _debugId;

		private ProgramInstruction _nextInstruction;

		public ThreadContext Context { get; private set; }

		public int DebugId { get; }

		public bool IsDone => Context.NextInstruction == null;

		public Thread(ThreadContext context)
		{
			Context = context;
			DebugId = _debugId++;
		}

		public int ProcessNext(int maxInstructions)
		{
			int num = 0;
			while (num < maxInstructions && Context.NextInstruction != null)
			{
				if (Context.NextInstruction.Style != "comment")
				{
					num++;
				}
				try
				{
					ProgramInstruction programInstruction = Context.NextInstruction.Execute(Context);
					while (programInstruction == null && Context.CallStackSize > 0)
					{
						programInstruction = Context.PopStackFrame().ReturnInstruction;
					}
					Context.NextInstruction = programInstruction;
					if (Context.BreakExecutionFlag == BreakExecutionType.Wait)
					{
						Context.BreakExecutionFlag = BreakExecutionType.None;
						break;
					}
					if (Context.BreakExecutionFlag == BreakExecutionType.Exit)
					{
						Context.NextInstruction = null;
						break;
					}
				}
				catch (Exception ex)
				{
					Context.Log.LogError("Error running flight program: " + ex.Message, Context);
					Debug.LogError("Error running flight program.");
					Debug.LogException(ex);
					Context.BreakExecutionFlag = BreakExecutionType.Exit;
					Context.NextInstruction = null;
					break;
				}
			}
			return num;
		}
	}
}
