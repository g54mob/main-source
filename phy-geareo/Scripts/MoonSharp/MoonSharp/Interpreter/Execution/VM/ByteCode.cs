using System;
using System.Collections.Generic;
using System.Diagnostics;
using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.Interpreter.Execution.VM
{
	internal class ByteCode : RefIdObject
	{
		private class SourceCodeStackGuard : IDisposable
		{
			private ByteCode m_Bc;

			public SourceCodeStackGuard(SourceRef sref, ByteCode bc)
			{
			}

			public void Dispose()
			{
			}
		}

		public List<Instruction> Code;

		private List<SourceRef> m_SourceRefStack;

		private SourceRef m_CurrentSourceRef;

		internal LoopTracker LoopTracker;

		public Script Script { get; private set; }

		public ByteCode(Script script)
		{
		}

		public IDisposable EnterSource(SourceRef sref)
		{
			return null;
		}

		public void PushSourceRef(SourceRef sref)
		{
		}

		public void PopSourceRef()
		{
		}

		public void Dump(string file)
		{
		}

		public int GetJumpPointForNextInstruction()
		{
			return 0;
		}

		public int GetJumpPointForLastInstruction()
		{
			return 0;
		}

		public Instruction GetLastInstruction()
		{
			return null;
		}

		private Instruction AppendInstruction(Instruction c)
		{
			return null;
		}

		public Instruction Emit_Nop(string comment)
		{
			return null;
		}

		public Instruction Emit_Invalid(string type)
		{
			return null;
		}

		public Instruction Emit_Pop(int num = 1)
		{
			return null;
		}

		public void Emit_Call(int argCount, string debugName)
		{
		}

		public void Emit_ThisCall(int argCount, string debugName)
		{
		}

		public Instruction Emit_Literal(DynValue value)
		{
			return null;
		}

		public Instruction Emit_Jump(OpCode jumpOpCode, int idx, int optPar = 0)
		{
			return null;
		}

		public Instruction Emit_MkTuple(int cnt)
		{
			return null;
		}

		public Instruction Emit_Operator(OpCode opcode)
		{
			return null;
		}

		[Conditional("EMIT_DEBUG_OPS")]
		public void Emit_Debug(string str)
		{
		}

		public Instruction Emit_Enter(RuntimeScopeBlock runtimeScopeBlock)
		{
			return null;
		}

		public Instruction Emit_Leave(RuntimeScopeBlock runtimeScopeBlock)
		{
			return null;
		}

		public Instruction Emit_Exit(RuntimeScopeBlock runtimeScopeBlock)
		{
			return null;
		}

		public Instruction Emit_Clean(RuntimeScopeBlock runtimeScopeBlock)
		{
			return null;
		}

		public Instruction Emit_Closure(SymbolRef[] symbols, int jmpnum)
		{
			return null;
		}

		public Instruction Emit_Args(params SymbolRef[] symbols)
		{
			return null;
		}

		public Instruction Emit_Ret(int retvals)
		{
			return null;
		}

		public Instruction Emit_ToNum(int stage = 0)
		{
			return null;
		}

		public Instruction Emit_Incr(int i)
		{
			return null;
		}

		public Instruction Emit_NewTable(bool shared)
		{
			return null;
		}

		public Instruction Emit_IterPrep()
		{
			return null;
		}

		public Instruction Emit_ExpTuple(int stackOffset)
		{
			return null;
		}

		public Instruction Emit_IterUpd()
		{
			return null;
		}

		public Instruction Emit_Meta(string funcName, OpCodeMetadataType metaType, DynValue value = null)
		{
			return null;
		}

		public Instruction Emit_BeginFn(RuntimeScopeFrame stackFrame)
		{
			return null;
		}

		public Instruction Emit_Scalar()
		{
			return null;
		}

		public int Emit_Load(SymbolRef sym)
		{
			return 0;
		}

		public int Emit_Store(SymbolRef sym, int stackofs, int tupleidx)
		{
			return 0;
		}

		public Instruction Emit_TblInitN()
		{
			return null;
		}

		public Instruction Emit_TblInitI(bool lastpos)
		{
			return null;
		}

		public Instruction Emit_Index(DynValue index = null, bool isNameIndex = false, bool isExpList = false)
		{
			return null;
		}

		public Instruction Emit_IndexSet(int stackofs, int tupleidx, DynValue index = null, bool isNameIndex = false, bool isExpList = false)
		{
			return null;
		}

		public Instruction Emit_Copy(int numval)
		{
			return null;
		}

		public Instruction Emit_Swap(int p1, int p2)
		{
			return null;
		}
	}
}
