using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Craft;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;

namespace ModApi.Craft.Program
{
	public class ThreadContext : IThreadContext
	{
		public const string ThreadContextElementName = "Thread";

		private FlightProgram _flightProgram;

		private VariableSet _globalVariables;

		private Dictionary<string, Variable> _localVariableLookup = new Dictionary<string, Variable>();

		private bool _resetLookup = true;

		public BreakExecutionType BreakExecutionFlag { get; set; }

		public int CallStackSize => CallStack.Count;

		public ICraftService Craft { get; set; }

		public double DeltaTime { get; set; }

		public ILogService Log { get; set; }

		public int MaxCallStackSize { get; set; } = 100;

		public ProgramInstruction NextInstruction { get; set; }

		private Stack<StackFrame> CallStack { get; set; } = new Stack<StackFrame>();

		private StackFrame CurrentStackFrame => CallStack.Peek();

		public ThreadContext(FlightProgram program, VariableSet globalVariables, ProgramInstruction instruction)
		{
			_flightProgram = program;
			_globalVariables = globalVariables;
			CallStack.Push(new StackFrame());
			NextInstruction = instruction;
		}

		public static ThreadContext Deserialize(XElement xml, FlightProgram program, VariableSet globalVariables, ILogService logService)
		{
			int intAttribute = xml.GetIntAttribute("nextInstruction", -1);
			ProgramInstruction instructionById = ((IGetInstructionById)program).GetInstructionById(intAttribute);
			ThreadContext threadContext = new ThreadContext(program, globalVariables, instructionById);
			threadContext.CallStack.Clear();
			IEnumerable<XElement> enumerable = xml.Element("CallStack")?.Elements();
			if (enumerable != null)
			{
				foreach (XElement item2 in enumerable)
				{
					StackFrame item = StackFrame.Deserialize(item2, program);
					threadContext.CallStack.Push(item);
				}
			}
			return threadContext;
		}

		public void BreakExecution(BreakExecutionType breakExecutionType)
		{
			BreakExecutionFlag = breakExecutionType;
		}

		public Variable CreateLocalVariable(string name)
		{
			_resetLookup = true;
			StackFrame currentStackFrame = CurrentStackFrame;
			Variable variable = new Variable(name);
			currentStackFrame.LocalVariables.AddVariable(variable);
			return variable;
		}

		public CustomExpression GetCustomExpression(string name)
		{
			return _flightProgram.GetCustomExpression(name);
		}

		public CustomInstruction GetCustomInstruction(string name)
		{
			return _flightProgram.GetCustomInstruction(name);
		}

		public double GetInstructionState(ProgramInstruction instruction)
		{
			CurrentStackFrame.NodeStates.TryGetValue(instruction, out var value);
			return value;
		}

		public Variable GetLocalVariable(string name)
		{
			if (_resetLookup)
			{
				_localVariableLookup.Clear();
				_resetLookup = false;
			}
			if (_localVariableLookup.TryGetValue(name, out var value))
			{
				return value;
			}
			foreach (StackFrame item in CallStack)
			{
				Variable variable = item.LocalVariables.GetVariable(name);
				if (variable != null)
				{
					_localVariableLookup[name] = variable;
					return variable;
				}
			}
			_localVariableLookup[name] = null;
			return null;
		}

		public Variable GetOrCreateGlobalVariable(string name)
		{
			return _globalVariables.GetOrCreateVariable(name);
		}

		public bool HasInstructionState(ProgramInstruction instruction)
		{
			return CurrentStackFrame.NodeStates.ContainsKey(instruction);
		}

		public StackFrame PopStackFrame()
		{
			_resetLookup = true;
			return CallStack.Pop();
		}

		public void PushStackFrame(ProgramInstruction returnInstruction)
		{
			_resetLookup = true;
			if (CallStackSize < MaxCallStackSize)
			{
				StackFrame stackFrame = new StackFrame();
				stackFrame.ReturnInstruction = returnInstruction;
				CallStack.Push(stackFrame);
				return;
			}
			throw new StackOverflowException($"Flight Program Call Stack has exceeded max size of {MaxCallStackSize}");
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("Thread");
			if (NextInstruction != null)
			{
				xElement.Add(new XAttribute("nextInstruction", ((IInstructionId)NextInstruction).Id));
			}
			XElement xElement2 = new XElement("CallStack");
			xElement.Add(xElement2);
			foreach (StackFrame item in CallStack)
			{
				xElement2.AddFirst(item.Serialize());
			}
			return xElement;
		}

		public void SetInstructionState(ProgramInstruction instruction, double state)
		{
			CurrentStackFrame.NodeStates[instruction] = state;
		}
	}
}
