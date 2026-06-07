using System;
using System.Text;

namespace CLanguage.Interpreter
{
	public class CInterpreter
	{
		private Executable exe;

		private BaseFunction? entrypoint;

		public readonly Value[] Stack;

		public int SP;

		private readonly ExecutionFrame[] Frames;

		private int FI;

		public int CpuSpeed;

		private static readonly BaseFunction unusedStackFrameFunction;

		public float Sleep;

		public Executable Executable => null;

		public int YieldedValue { get; private set; }

		public int SleepTime { get; set; }

		public int RemainingTime { get; set; }

		public ExecutionFrame? ActiveFrame => null;

		public int CallStackDepth => 0;

		public CInterpreter(Executable exe, int maxStack = 512000, int maxFrames = 72)
		{
		}

		public Value ReadMemory(int address)
		{
			return default(Value);
		}

		public string ReadStringWithEncoding(int address, Encoding encoding)
		{
			return null;
		}

		public string ReadString(int address)
		{
			return null;
		}

		public Value ReadThis()
		{
			return default(Value);
		}

		public Value ReadArg(int index)
		{
			return default(Value);
		}

		public void Call(Value functionAddress)
		{
		}

		public void Call(BaseFunction function)
		{
		}

		public void Push(Value value)
		{
		}

		public void Yield(int yieldedValue)
		{
		}

		public void Return()
		{
		}

		public void Reset(string entrypoint)
		{
		}

		public void Reset()
		{
		}

		public void Run()
		{
		}

		public static void Run(string code)
		{
		}

		[Obsolete("Please use Run() which Steps for 1 machine second.")]
		public void Step()
		{
		}

		public void Step(int microseconds)
		{
		}

		public Value RunFunction(Value functionAddress, int microseconds)
		{
			return default(Value);
		}

		public Value RunFunction(Value functionAddress, Value arg0, int microseconds)
		{
			return default(Value);
		}

		public Value RunFunction(Value functionAddress, Value arg0, Value arg1, int microseconds)
		{
			return default(Value);
		}

		public Value RunFunction(Value functionAddress, Value arg0, Value arg1, Value arg2, int microseconds)
		{
			return default(Value);
		}

		private Value StepFunction(int microseconds)
		{
			return default(Value);
		}
	}
}
