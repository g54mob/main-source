using System;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution.VM;
using MoonSharp.Interpreter.Interop.LuaStateInterop;

namespace MoonSharp.Interpreter
{
	public class ScriptExecutionContext : IScriptPrivateResource
	{
		private Processor m_Processor;

		private CallbackFunction m_Callback;

		public bool IsDynamicExecution { get; private set; }

		public SourceRef CallingLocation { get; private set; }

		public object AdditionalData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Table CurrentGlobalEnv => null;

		public Script OwnerScript => null;

		internal ScriptExecutionContext(Processor p, CallbackFunction callBackFunction, SourceRef sourceRef, bool isDynamic = false)
		{
		}

		public Table GetMetatable(DynValue value)
		{
			return null;
		}

		public DynValue GetMetamethod(DynValue value, string metamethod)
		{
			return null;
		}

		public DynValue GetMetamethodTailCall(DynValue value, string metamethod, params DynValue[] args)
		{
			return null;
		}

		public DynValue GetBinaryMetamethod(DynValue op1, DynValue op2, string eventName)
		{
			return null;
		}

		public Script GetScript()
		{
			return null;
		}

		public Coroutine GetCallingCoroutine()
		{
			return null;
		}

		public DynValue EmulateClassicCall(CallbackArguments args, string functionName, Func<LuaState, int> callback)
		{
			return null;
		}

		public DynValue Call(DynValue func, params DynValue[] args)
		{
			return null;
		}

		public DynValue EvaluateSymbol(SymbolRef symref)
		{
			return null;
		}

		public DynValue EvaluateSymbolByName(string symbol)
		{
			return null;
		}

		public SymbolRef FindSymbolByName(string symbol)
		{
			return null;
		}

		public void PerformMessageDecorationBeforeUnwind(DynValue messageHandler, ScriptRuntimeException exception)
		{
		}
	}
}
