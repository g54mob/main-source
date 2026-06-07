using System.Collections.Generic;

namespace Yarn
{
	internal class VirtualMachine
	{
		internal class State
		{
			public string currentNodeName;

			public int programCounter;

			public List<(Line line, string destination, bool enabled)> currentOptions;

			private Stack<Value> stack;

			public void PushValue(Value v)
			{
			}

			public void PushValue(string s)
			{
			}

			public void PushValue(float f)
			{
			}

			public void PushValue(bool b)
			{
			}

			public Value PopValue()
			{
				return null;
			}

			public Value PeekValue()
			{
				return null;
			}

			public void ClearStack()
			{
			}
		}

		public enum ExecutionState
		{
			Stopped = 0,
			WaitingOnOptionSelection = 1,
			WaitingForContinue = 2,
			DeliveringContent = 3,
			Running = 4
		}

		public LineHandler LineHandler;

		public OptionsHandler OptionsHandler;

		public CommandHandler CommandHandler;

		public NodeStartHandler NodeStartHandler;

		public NodeCompleteHandler NodeCompleteHandler;

		public DialogueCompleteHandler DialogueCompleteHandler;

		public PrepareForLinesHandler PrepareForLinesHandler;

		private Dialogue dialogue;

		private State state;

		private ExecutionState _executionState;

		private Node currentNode;

		internal Program Program { get; set; }

		public string currentNodeName => null;

		public ExecutionState CurrentExecutionState
		{
			get
			{
				return default(ExecutionState);
			}
			private set
			{
			}
		}

		internal VirtualMachine(Dialogue d)
		{
		}

		internal void ResetState()
		{
		}

		public bool SetNode(string nodeName)
		{
			return false;
		}

		public void Stop()
		{
		}

		public void SetSelectedOption(int selectedOptionID)
		{
		}

		internal void Continue()
		{
		}

		private void CheckCanContinue()
		{
		}

		internal int FindInstructionPointForLabel(string labelName)
		{
			return 0;
		}

		internal void RunInstruction(Instruction i)
		{
		}
	}
}
