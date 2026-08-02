using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Diagnostics;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter
{
	public class Script : IScriptPrivateResource
	{
		public const string VERSION = "2.0.0.0";

		public const string LUA_VERSION = "5.2";

		private Processor m_MainProcessor;

		private ByteCode m_ByteCode;

		private List<SourceCode> m_Sources;

		private Table m_GlobalTable;

		private IDebugger m_Debugger;

		private Table[] m_TypeMetatables;

		public static ScriptOptions DefaultOptions { get; private set; }

		public ScriptOptions Options { get; private set; }

		public static ScriptGlobalOptions GlobalOptions { get; private set; }

		public PerformanceStatistics PerformanceStats { get; private set; }

		public Table Globals => null;

		public bool DebuggerEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int SourceCodeCount => 0;

		public Table Registry { get; private set; }

		Script IScriptPrivateResource.OwnerScript => null;

		static Script()
		{
		}

		public Script()
		{
		}

		public Script(CoreModules coreModules)
		{
		}

		public DynValue LoadFunction(string code, Table globalTable = null, string funcFriendlyName = null)
		{
			return null;
		}

		private void SignalByteCodeChange()
		{
		}

		private void SignalSourceCodeChange(SourceCode source)
		{
		}

		public DynValue LoadString(string code, Table globalTable = null, string codeFriendlyName = null)
		{
			return null;
		}

		public DynValue LoadStream(Stream stream, Table globalTable = null, string codeFriendlyName = null)
		{
			return null;
		}

		public void Dump(DynValue function, Stream stream)
		{
		}

		public DynValue LoadFile(string filename, Table globalContext = null, string friendlyFilename = null)
		{
			return null;
		}

		public DynValue DoString(string code, Table globalContext = null, string codeFriendlyName = null)
		{
			return null;
		}

		public DynValue DoStream(Stream stream, Table globalContext = null, string codeFriendlyName = null)
		{
			return null;
		}

		public DynValue DoFile(string filename, Table globalContext = null, string codeFriendlyName = null)
		{
			return null;
		}

		public static DynValue RunFile(string filename)
		{
			return null;
		}

		public static DynValue RunString(string code)
		{
			return null;
		}

		private DynValue MakeClosure(int address, Table envTable = null)
		{
			return null;
		}

		public DynValue Call(DynValue function)
		{
			return null;
		}

		public DynValue Call(DynValue function, params DynValue[] args)
		{
			return null;
		}

		public DynValue Call(DynValue function, params object[] args)
		{
			return null;
		}

		public DynValue Call(object function)
		{
			return null;
		}

		public DynValue Call(object function, params object[] args)
		{
			return null;
		}

		public DynValue CreateCoroutine(DynValue function)
		{
			return null;
		}

		public DynValue CreateCoroutine(object function)
		{
			return null;
		}

		public void AttachDebugger(IDebugger debugger)
		{
		}

		public SourceCode GetSourceCode(int sourceCodeID)
		{
			return null;
		}

		public DynValue RequireModule(string modname, Table globalContext = null)
		{
			return null;
		}

		public Table GetTypeMetatable(DataType type)
		{
			return null;
		}

		public void SetTypeMetatable(DataType type, Table metatable)
		{
		}

		public static void WarmUp()
		{
		}

		public DynamicExpression CreateDynamicExpression(string code)
		{
			return null;
		}

		public DynamicExpression CreateConstantDynamicExpression(string code, DynValue constant)
		{
			return null;
		}

		internal ScriptExecutionContext CreateDynamicExecutionContext(CallbackFunction func = null)
		{
			return null;
		}

		public static string GetBanner(string subproduct = null)
		{
			return null;
		}
	}
}
