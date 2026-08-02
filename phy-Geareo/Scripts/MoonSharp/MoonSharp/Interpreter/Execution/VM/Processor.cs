using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter.DataStructs;
using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.Interpreter.Execution.VM
{
	internal sealed class Processor
	{
		private class DebugContext
		{
			public bool DebuggerEnabled;

			public IDebugger DebuggerAttached;

			public DebuggerAction.ActionType DebuggerCurrentAction;

			public int DebuggerCurrentActionTarget;

			public SourceRef LastHlRef;

			public int ExStackDepthAtStep;

			public List<SourceRef> BreakPoints;

			public bool LineBasedBreakPoints;
		}

		private ByteCode m_RootChunk;

		private FastStack<DynValue> m_ValueStack;

		private FastStack<CallStackItem> m_ExecutionStack;

		private List<Processor> m_CoroutinesStack;

		private Table m_GlobalTable;

		private Script m_Script;

		private Processor m_Parent;

		private CoroutineState m_State;

		private bool m_CanYield;

		private int m_SavedInstructionPtr;

		private DebugContext m_Debug;

		private int m_OwningThreadID;

		private int m_ExecutionNesting;

		private const ulong DUMP_CHUNK_MAGIC = 1877195438928383261uL;

		private const int DUMP_CHUNK_VERSION = 336;

		private const int YIELD_SPECIAL_TRAP = -99;

		internal long AutoYieldCounter;

		public CoroutineState State => default(CoroutineState);

		public Coroutine AssociatedCoroutine { get; set; }

		internal bool DebuggerEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Processor(Script script, Table globalContext, ByteCode byteCode)
		{
		}

		private Processor(Processor parentProcessor)
		{
		}

		public DynValue Call(DynValue function, DynValue[] args)
		{
			return null;
		}

		private int PushClrToScriptStackFrame(CallStackItemFlags flags, DynValue function, DynValue[] args)
		{
			return 0;
		}

		private void LeaveProcessor()
		{
		}

		private int GetThreadId()
		{
			return 0;
		}

		private void EnterProcessor()
		{
		}

		internal SourceRef GetCoroutineSuspendedLocation()
		{
			return null;
		}

		internal static bool IsDumpStream(Stream stream)
		{
			return false;
		}

		internal int Dump(Stream stream, int baseAddress, bool hasUpvalues)
		{
			return 0;
		}

		private void AddSymbolToMap(Dictionary<SymbolRef, int> symbolMap, SymbolRef s)
		{
		}

		internal int Undump(Stream stream, int sourceID, Table envTable, out bool hasUpvalues)
		{
			hasUpvalues = default(bool);
			return 0;
		}

		public DynValue Coroutine_Create(Closure closure)
		{
			return null;
		}

		public DynValue Coroutine_Resume(DynValue[] args)
		{
			return null;
		}

		internal Instruction FindMeta(ref int baseAddress)
		{
			return null;
		}

		internal void AttachDebugger(IDebugger debugger)
		{
		}

		private void ListenDebugger(Instruction instr, int instructionPtr)
		{
		}

		private void ResetBreakPoints(DebuggerAction action)
		{
		}

		internal HashSet<int> ResetBreakPoints(SourceCode src, HashSet<int> lines)
		{
			return null;
		}

		private bool ToggleBreakPoint(DebuggerAction action, bool? state)
		{
			return false;
		}

		private void RefreshDebugger(bool hard, int instructionPtr)
		{
		}

		private List<WatchItem> Debugger_RefreshThreads(ScriptExecutionContext context)
		{
			return null;
		}

		private List<WatchItem> Debugger_RefreshVStack()
		{
			return null;
		}

		private List<WatchItem> Debugger_RefreshWatches(ScriptExecutionContext context, List<DynamicExpression> watchList)
		{
			return null;
		}

		private List<WatchItem> Debugger_RefreshLocals(ScriptExecutionContext context)
		{
			return null;
		}

		private WatchItem Debugger_RefreshWatch(ScriptExecutionContext context, DynamicExpression dynExpr)
		{
			return null;
		}

		internal List<WatchItem> Debugger_GetCallStack(SourceRef startingRef)
		{
			return null;
		}

		private SourceRef GetCurrentSourceRef(int instructionPtr)
		{
			return null;
		}

		private void FillDebugData(InterpreterException ex, int ip)
		{
		}

		internal Table GetMetatable(DynValue value)
		{
			return null;
		}

		internal DynValue GetBinaryMetamethod(DynValue op1, DynValue op2, string eventName)
		{
			return null;
		}

		internal DynValue GetMetamethod(DynValue value, string metamethod)
		{
			return null;
		}

		internal DynValue GetMetamethodRaw(DynValue value, string metamethod)
		{
			return null;
		}

		internal Script GetScript()
		{
			return null;
		}

		private DynValue Processing_Loop(int instructionPtr)
		{
			return null;
		}

		internal string PerformMessageDecorationBeforeUnwind(DynValue messageHandler, string decoratedMessage, SourceRef sourceRef)
		{
			return null;
		}

		private void AssignLocal(SymbolRef symref, DynValue value)
		{
		}

		private void ExecStoreLcl(Instruction i)
		{
		}

		private void ExecStoreUpv(Instruction i)
		{
		}

		private void ExecSwap(Instruction i)
		{
		}

		private DynValue GetStoreValue(Instruction i)
		{
			return null;
		}

		private void ExecClosure(Instruction i)
		{
		}

		private DynValue GetUpvalueSymbol(SymbolRef s)
		{
			return null;
		}

		private void ExecMkTuple(Instruction i)
		{
		}

		private void ExecToNum(Instruction i)
		{
		}

		private void ExecIterUpd(Instruction i)
		{
		}

		private void ExecExpTuple(Instruction i)
		{
		}

		private void ExecIterPrep(Instruction i)
		{
		}

		private int ExecJFor(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private void ExecIncr(Instruction i)
		{
		}

		private void ExecCNot(Instruction i)
		{
		}

		private void ExecNot(Instruction i)
		{
		}

		private void ExecBeginFn(Instruction i)
		{
		}

		private CallStackItem PopToBasePointer()
		{
			return null;
		}

		private int PopExecStackAndCheckVStack(int vstackguard)
		{
			return 0;
		}

		private IList<DynValue> CreateArgsListForFunctionCall(int numargs, int offsFromTop)
		{
			return null;
		}

		private void ExecArgs(Instruction I)
		{
		}

		private int Internal_ExecCall(int argsCount, int instructionPtr, CallbackFunction handler = null, CallbackFunction continuation = null, bool thisCall = false, string debugText = null, DynValue unwindHandler = null)
		{
			return 0;
		}

		private int PerformTCO(int instructionPtr, int argsCount)
		{
			return 0;
		}

		private int ExecRet(Instruction i)
		{
			return 0;
		}

		private int Internal_CheckForTailRequests(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int JumpBool(Instruction i, bool expectedValueForJump, int instructionPtr)
		{
			return 0;
		}

		private int ExecShortCircuitingOperator(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecAdd(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecSub(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecMul(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecMod(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecDiv(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecPower(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecNeg(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecEq(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecLess(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecLessEq(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecLen(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecConcat(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private void ExecTblInitI(Instruction i)
		{
		}

		private void ExecTblInitN(Instruction i)
		{
		}

		private int ExecIndexSet(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private int ExecIndex(Instruction i, int instructionPtr)
		{
			return 0;
		}

		private void ClearBlockData(Instruction I)
		{
		}

		public DynValue GetGenericSymbol(SymbolRef symref)
		{
			return null;
		}

		private DynValue GetGlobalSymbol(DynValue dynValue, string name)
		{
			return null;
		}

		private void SetGlobalSymbol(DynValue dynValue, string name, DynValue value)
		{
		}

		public void AssignGenericSymbol(SymbolRef symref, DynValue value)
		{
		}

		private CallStackItem GetTopNonClrFunction()
		{
			return null;
		}

		public SymbolRef FindSymbolByName(string name)
		{
			return null;
		}

		private DynValue[] Internal_AdjustTuple(IList<DynValue> values)
		{
			return null;
		}

		private int Internal_InvokeUnaryMetaMethod(DynValue op1, string eventName, int instructionPtr)
		{
			return 0;
		}

		private int Internal_InvokeBinaryMetaMethod(DynValue l, DynValue r, string eventName, int instructionPtr, DynValue extraPush = null)
		{
			return 0;
		}

		private DynValue[] StackTopToArray(int items, bool pop)
		{
			return null;
		}

		private DynValue[] StackTopToArrayReverse(int items, bool pop)
		{
			return null;
		}
	}
}
