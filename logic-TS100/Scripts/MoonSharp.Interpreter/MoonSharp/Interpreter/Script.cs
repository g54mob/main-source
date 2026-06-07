using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Diagnostics;
using MoonSharp.Interpreter.Execution.VM;
using MoonSharp.Interpreter.IO;
using MoonSharp.Interpreter.Platforms;
using MoonSharp.Interpreter.Tree.Expressions;
using MoonSharp.Interpreter.Tree.Fast_Interface;

namespace MoonSharp.Interpreter
{
	public class Script
	{
		public const string VERSION = "0.9.5.0";

		public const string LUA_VERSION = "5.2";

		private Processor m_MainProcessor;

		private ByteCode m_ByteCode;

		private List<SourceCode> m_Sources = new List<SourceCode>();

		private Table m_GlobalTable;

		private IDebugger m_Debugger;

		private Table[] m_TypeMetatables = new Table[6];

		public static ScriptOptions DefaultOptions { get; private set; }

		public ScriptOptions Options { get; private set; }

		public static ScriptGlobalOptions GlobalOptions { get; private set; }

		public PerformanceStatistics PerformanceStats { get; private set; }

		public Table Globals
		{
			get
			{
				return m_GlobalTable;
			}
		}

		public int SourceCodeCount
		{
			get
			{
				return m_Sources.Count;
			}
		}

		public Table Registry { get; private set; }

		static Script()
		{
			GlobalOptions = new ScriptGlobalOptions();
			DefaultOptions = new ScriptOptions
			{
				DebugPrint = delegate(string s)
				{
					GlobalOptions.Platform.DefaultPrint(s);
				},
				DebugInput = (string s) => GlobalOptions.Platform.DefaultInput(s),
				CheckThreadAccess = true,
				ScriptLoader = PlatformAutoDetector.GetDefaultScriptLoader(),
				TailCallOptimizationThreshold = 65536
			};
		}

		public Script()
			: this(CoreModules.Preset_Default)
		{
		}

		public Script(CoreModules coreModules)
		{
			Options = new ScriptOptions(DefaultOptions);
			PerformanceStats = new PerformanceStatistics();
			Registry = new Table(this);
			m_ByteCode = new ByteCode(this);
			m_GlobalTable = new Table(this).RegisterCoreModules(coreModules);
			m_MainProcessor = new Processor(this, m_GlobalTable, m_ByteCode);
		}

		public DynValue LoadFunction(string code, Table globalTable = null, string funcFriendlyName = null)
		{
			string name = string.Format("libfunc_{0}", funcFriendlyName ?? m_Sources.Count.ToString());
			SourceCode sourceCode = new SourceCode(name, code, m_Sources.Count, this);
			m_Sources.Add(sourceCode);
			int address = Loader_Fast.LoadFunction(this, sourceCode, m_ByteCode, globalTable ?? m_GlobalTable);
			SignalSourceCodeChange(sourceCode);
			SignalByteCodeChange();
			return MakeClosure(address);
		}

		private void SignalByteCodeChange()
		{
			if (m_Debugger != null)
			{
				m_Debugger.SetByteCode(m_ByteCode.Code.Select((Instruction s) => s.ToString()).ToArray());
			}
		}

		private void SignalSourceCodeChange(SourceCode source)
		{
			if (m_Debugger != null)
			{
				m_Debugger.SetSourceCode(source);
			}
		}

		public DynValue LoadString(string code, Table globalTable = null, string codeFriendlyName = null)
		{
			if (code.StartsWith("MoonSharp_dump_b64::"))
			{
				code = code.Substring("MoonSharp_dump_b64::".Length);
				byte[] buffer = Convert.FromBase64String(code);
				using (MemoryStream stream = new MemoryStream(buffer))
				{
					return LoadStream(stream, globalTable, codeFriendlyName);
				}
			}
			string text = string.Format("{0}", codeFriendlyName ?? ("chunk_" + m_Sources.Count));
			SourceCode sourceCode = new SourceCode(codeFriendlyName ?? text, code, m_Sources.Count, this);
			m_Sources.Add(sourceCode);
			int address = Loader_Fast.LoadChunk(this, sourceCode, m_ByteCode, globalTable ?? m_GlobalTable);
			SignalSourceCodeChange(sourceCode);
			SignalByteCodeChange();
			return MakeClosure(address);
		}

		public DynValue LoadStream(Stream stream, Table globalTable = null, string codeFriendlyName = null)
		{
			Stream stream2 = new UndisposableStream(stream);
			if (!Processor.IsDumpStream(stream2))
			{
				using (StreamReader streamReader = new StreamReader(stream2))
				{
					string code = streamReader.ReadToEnd();
					return LoadString(code, globalTable, codeFriendlyName);
				}
			}
			string text = string.Format("{0}", codeFriendlyName ?? ("dump_" + m_Sources.Count));
			SourceCode sourceCode = new SourceCode(codeFriendlyName ?? text, string.Format("-- This script was decoded from a binary dump - dump_{0}", m_Sources.Count), m_Sources.Count, this);
			m_Sources.Add(sourceCode);
			bool hasUpvalues;
			int address = m_MainProcessor.Undump(stream2, m_Sources.Count - 1, globalTable ?? m_GlobalTable, out hasUpvalues);
			SignalSourceCodeChange(sourceCode);
			SignalByteCodeChange();
			if (hasUpvalues)
			{
				return MakeClosure(address, globalTable ?? m_GlobalTable);
			}
			return MakeClosure(address);
		}

		public void Dump(DynValue function, Stream stream)
		{
			if (function.Type != DataType.Function)
			{
				throw new ArgumentException("function arg is not a function!");
			}
			if (!stream.CanWrite)
			{
				throw new ArgumentException("stream is readonly!");
			}
			Closure.UpvaluesType upvaluesType = function.Function.GetUpvaluesType();
			if (upvaluesType == Closure.UpvaluesType.Closure)
			{
				throw new ArgumentException("function arg has upvalues other than _ENV");
			}
			UndisposableStream stream2 = new UndisposableStream(stream);
			m_MainProcessor.Dump(stream2, function.Function.EntryPointByteCodeLocation, upvaluesType == Closure.UpvaluesType.Environment);
		}

		public DynValue LoadFile(string filename, Table globalContext = null, string friendlyFilename = null)
		{
			filename = Options.ScriptLoader.ResolveFileName(filename, globalContext ?? m_GlobalTable);
			object obj = Options.ScriptLoader.LoadFile(filename, globalContext ?? m_GlobalTable);
			if (obj is string)
			{
				return LoadString((string)obj, globalContext, friendlyFilename ?? filename);
			}
			if (obj is byte[])
			{
				using (MemoryStream stream = new MemoryStream((byte[])obj))
				{
					return LoadStream(stream, globalContext, friendlyFilename ?? filename);
				}
			}
			if (obj is Stream)
			{
				try
				{
					return LoadStream((Stream)obj, globalContext, friendlyFilename ?? filename);
				}
				finally
				{
					((Stream)obj).Dispose();
				}
			}
			if (obj == null)
			{
				throw new InvalidCastException("Unexpected null from IScriptLoader.LoadFile");
			}
			throw new InvalidCastException(string.Format("Unsupported return type from IScriptLoader.LoadFile : {0}", obj.GetType()));
		}

		public DynValue DoString(string code, Table globalContext = null)
		{
			DynValue function = LoadString(code, globalContext);
			return Call(function);
		}

		public DynValue DoStream(Stream stream, Table globalContext = null)
		{
			DynValue function = LoadStream(stream, globalContext);
			return Call(function);
		}

		public DynValue DoFile(string filename, Table globalContext = null)
		{
			DynValue function = LoadFile(filename, globalContext);
			return Call(function);
		}

		public static DynValue RunFile(string filename)
		{
			Script script = new Script();
			return script.DoFile(filename);
		}

		public static DynValue RunString(string code)
		{
			Script script = new Script();
			return script.DoString(code);
		}

		private DynValue MakeClosure(int address, Table envTable = null)
		{
			Closure function;
			if (envTable == null)
			{
				function = new Closure(this, address, new SymbolRef[0], new DynValue[0]);
			}
			else
			{
				SymbolRef[] symbols = new SymbolRef[1]
				{
					new SymbolRef
					{
						i_Env = null,
						i_Index = 0,
						i_Name = "_ENV",
						i_Type = SymbolRefType.DefaultEnv
					}
				};
				DynValue[] resolvedLocals = new DynValue[1] { DynValue.NewTable(envTable) };
				function = new Closure(this, address, symbols, resolvedLocals);
			}
			return DynValue.NewClosure(function);
		}

		public DynValue Call(DynValue function)
		{
			return Call(function, new DynValue[0]);
		}

		public DynValue Call(DynValue function, params DynValue[] args)
		{
			if (function.Type == DataType.ClrFunction)
			{
				return function.Callback.ClrCallback(CreateDynamicExecutionContext(function.Callback), new CallbackArguments(args, false));
			}
			if (function.Type != DataType.Function)
			{
				throw new ArgumentException("function is not of DataType.Function");
			}
			return m_MainProcessor.Call(function, args);
		}

		public DynValue Call(DynValue function, params object[] args)
		{
			DynValue[] array = new DynValue[args.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = DynValue.FromObject(this, args[i]);
			}
			return Call(function, array);
		}

		public DynValue Call(object function)
		{
			return Call(DynValue.FromObject(this, function));
		}

		public DynValue Call(object function, params object[] args)
		{
			return Call(DynValue.FromObject(this, function), args);
		}

		public DynValue CreateCoroutine(DynValue function)
		{
			if (function.Type == DataType.Function)
			{
				return m_MainProcessor.Coroutine_Create(function.Function);
			}
			if (function.Type == DataType.ClrFunction)
			{
				return DynValue.NewCoroutine(new Coroutine(function.Callback));
			}
			throw new ArgumentException("function is not of DataType.Function or DataType.ClrFunction");
		}

		public DynValue CreateCoroutine(object function)
		{
			return CreateCoroutine(DynValue.FromObject(this, function));
		}

		public DynValue GetMainChunk()
		{
			return MakeClosure(0);
		}

		public void AttachDebugger(IDebugger debugger)
		{
			m_Debugger = debugger;
			m_MainProcessor.AttachDebugger(debugger);
			foreach (SourceCode source in m_Sources)
			{
				SignalSourceCodeChange(source);
			}
			SignalByteCodeChange();
		}

		public SourceCode GetSourceCode(int sourceCodeID)
		{
			return m_Sources[sourceCodeID];
		}

		public DynValue RequireModule(string modname, Table globalContext = null)
		{
			Table globalContext2 = globalContext ?? m_GlobalTable;
			string text = Options.ScriptLoader.ResolveModuleName(modname, globalContext2);
			if (text == null)
			{
				throw new ScriptRuntimeException("module '{0}' not found", modname);
			}
			return LoadFile(text, globalContext, text);
		}

		public Table GetTypeMetatable(DataType type)
		{
			if (type >= DataType.Nil && (int)type < m_TypeMetatables.Length)
			{
				return m_TypeMetatables[(int)type];
			}
			return null;
		}

		public void SetTypeMetatable(DataType type, Table metatable)
		{
			if (type >= DataType.Nil && (int)type < m_TypeMetatables.Length)
			{
				m_TypeMetatables[(int)type] = metatable;
				return;
			}
			throw new ArgumentException("Specified type not supported : " + type);
		}

		public static void WarmUp()
		{
			Script script = new Script(CoreModules.Basic);
			script.LoadString("return 1;");
		}

		public DynamicExpression CreateDynamicExpression(string code)
		{
			DynamicExprExpression expr = Loader_Fast.LoadDynamicExpr(this, new SourceCode("__dynamic", code, -1, this));
			return new DynamicExpression(this, code, expr);
		}

		public DynamicExpression CreateConstantDynamicExpression(string code, DynValue constant)
		{
			return new DynamicExpression(this, code, constant);
		}

		internal ScriptExecutionContext CreateDynamicExecutionContext(CallbackFunction func = null)
		{
			return new ScriptExecutionContext(m_MainProcessor, func, null, true);
		}
	}
}
