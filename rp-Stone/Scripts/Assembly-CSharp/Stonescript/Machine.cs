using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Antlr4.Runtime;
using Stonescript.Compiler;
using Stonescript.Runtime;
using Stonescript.Runtime.Unity;
using Stonescript.Types;
using Stonescript.Util;
using UnityEngine;
using UnityEngine.Networking;

namespace Stonescript
{
	public class Machine
	{
		public delegate void CompileCallback(Executable executable, List<Exception> exception);

		private class AsyncCompileOrder
		{
			private static int instanceCount;

			public Script script;

			public CompileCallback callback;

			public Scope scope;

			public bool cache = true;

			public int instanceId;

			public AsyncCompileOrder()
			{
				instanceId = instanceCount++;
			}
		}

		protected static int instanceCounter = 0;

		public int id;

		public bool suppressWarnings;

		private List<StonescriptResult> allResults = new List<StonescriptResult>();

		public int MAX_IMPORT_DEPTH = 100;

		public int MAX_CALL_DEPTH = 215;

		public int MAX_EXECUTION_TIME = 250;

		public Action<Exception> OnError;

		protected Stonescript.Runtime.Unity.Machine component;

		private Processor processor;

		private int objectInstanceCounter;

		private Dictionary<string, List<Executable>> executablesByScript = new Dictionary<string, List<Executable>>();

		private StonescriptLexer lexer = new StonescriptLexer(null);

		private StonescriptParser parser = new StonescriptParser(null);

		private Stonescript.Compiler.Compiler compiler;

		private Linker linker;

		private Dictionary<string, Script> scripts = new Dictionary<string, Script>();

		private List<string> recompileKeys = new List<string>();

		private Dictionary<string, Executable> expressions = new Dictionary<string, Executable>();

		private static Regex varReplaceRegex = new Regex("@([^@\\r\\n]+)@", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		private Stack<string> importStack = new Stack<string>();

		private Stack<string> newStack = new Stack<string>();

		private Dictionary<string, Executable> importInstances = new Dictionary<string, Executable>();

		private Dictionary<string, object> globals = new Dictionary<string, object>();

		private Dictionary<string, NativeFunction> functions = new Dictionary<string, NativeFunction>();

		private Dictionary<string, Command> commands = new Dictionary<string, Command>();

		private List<string> commandList = new List<string>();

		private static List<string> reservedVariableIds = new List<string>
		{
			"this", "for", "in", "var", "const", "perm", "null", "true", "false", "func",
			"return", "new", "import", "break", "continue"
		};

		public Dictionary<string, ScriptProfiler> profilers = new Dictionary<string, ScriptProfiler>();

		public Pool<Scope> scopePool = new Pool<Scope>(() => new Scope(), delegate(Scope scope)
		{
			scope.Reset();
		}, 512);

		public Pool<StonescriptObject> objectPool = new Pool<StonescriptObject>(() => new StonescriptObject(), delegate(StonescriptObject obj)
		{
			obj.Reset();
		}, 512);

		public Pool<Stonescript.Runtime.ExecutionContext> execCtxPool = new Pool<Stonescript.Runtime.ExecutionContext>(() => new Stonescript.Runtime.ExecutionContext(), delegate(Stonescript.Runtime.ExecutionContext obj)
		{
			obj.Reset();
		}, 8);

		public Pool<InvocationContext> invCtxPool = new Pool<InvocationContext>(() => new InvocationContext(), delegate(InvocationContext obj)
		{
			obj.Reset();
		}, 512);

		public Pool<List<object>> objectListPool = new Pool<List<object>>(() => new List<object>(), delegate(List<object> obj)
		{
			obj.Clear();
		}, 32);

		public Pool<List<string>> stringListPool = new Pool<List<string>>(() => new List<string>(), delegate(List<string> obj)
		{
			obj.Clear();
		}, 32);

		public AStorage Storage { get; set; }

		public List<StonescriptResult> Results => allResults;

		public Stonescript.Runtime.Unity.Machine Component => component;

		public Processor Processor => processor;

		public Stonescript.Compiler.Compiler Compiler => compiler;

		public void HandleException(Exception ex)
		{
			StonescriptException.Level level = StonescriptException.Level.Error;
			if (ex is StonescriptException)
			{
				level = (ex as StonescriptException).level;
			}
			if (suppressWarnings && level < StonescriptException.Level.Error)
			{
				Debug.LogWarning(ex.Message);
				return;
			}
			StonescriptResult stonescriptResult = new StonescriptResult();
			stonescriptResult.type = ((level < StonescriptException.Level.Error) ? StonescriptResult.Type.Warning : StonescriptResult.Type.Error);
			stonescriptResult.param = ex.Message;
			Results.Add(stonescriptResult);
			OnError?.Invoke(ex);
		}

		public Machine()
		{
			Init();
		}

		public Machine(Stonescript.Runtime.Unity.Machine component)
		{
			this.component = component;
			Init();
		}

		protected void Init()
		{
			id = instanceCounter++;
			compiler = new Stonescript.Compiler.Compiler(this);
			compiler.onWarning = HandleException;
			compiler.CacheSubstituteExpression = CompileSubstituteExpressions;
			linker = new Linker(this);
			processor = new Processor(this);
			Reset();
		}

		public Stonescript.Runtime.Unity.Machine CreateComponent(string name = null)
		{
			if (component == null)
			{
				if (name == null)
				{
					name = id.ToString();
				}
				GameObject gameObject = new GameObject("Stonescript (" + name + ")");
				component = gameObject.AddComponent<Stonescript.Runtime.Unity.Machine>();
				component.instance = this;
			}
			return component;
		}

		public void Reset()
		{
			allResults.Clear();
		}

		public void ClearResults()
		{
			allResults.Clear();
		}

		public Stonescript.Runtime.ExecutionContext CreateExecutionContext()
		{
			Stonescript.Runtime.ExecutionContext executionContext = execCtxPool.Get();
			executionContext.machine = this;
			executionContext.processor = processor;
			return executionContext;
		}

		private Executable NewExecutable(Script script, Scope scope = null, bool cache = true)
		{
			Executable executable = new Executable();
			executable.machine = this;
			executable.script = script;
			if (scope == null)
			{
				Scope scope2 = scopePool.Get();
				string name = script.name;
				int num = ++objectInstanceCounter;
				scope = scope2.Init(name + num);
				scope.Name = script.name;
				scope.ObjectType = script.name;
			}
			executable.Target = scope;
			if (cache)
			{
				if (!executablesByScript.ContainsKey(script.name))
				{
					executablesByScript[script.name] = new List<Executable>();
				}
				executablesByScript[script.name].Add(executable);
			}
			return executable;
		}

		public object Execute(Executable executable, Stonescript.Runtime.ExecutionContext execCtx = null)
		{
			Stonescript.Runtime.ExecutionContext executionContext = null;
			if (execCtx == null)
			{
				execCtx = CreateExecutionContext();
				executionContext = execCtx;
			}
			object result = processor.Execute(executable, execCtx);
			if (executionContext != null)
			{
				execCtxPool.Return(executionContext);
			}
			return result;
		}

		public object Execute(Executable executable, IFunction function, IEnumerable<object> parameters = null, Stonescript.Runtime.ExecutionContext execCtx = null)
		{
			if (execCtx == null)
			{
				execCtx = CreateExecutionContext();
			}
			return processor.Execute(executable, function, parameters, execCtx);
		}

		public object Execute(string[] program, string programName = null, bool cache = false)
		{
			return Execute(string.Join("\n", program), programName, cache);
		}

		public object Execute(string program, string programName = null, bool cache = false)
		{
			Script script = new Script(program, programName);
			cache = cache && programName != null;
			Executable executable = Compile(script, cache);
			if (executable == null)
			{
				return null;
			}
			return Execute(executable);
		}

		public object Execute(Script script, bool cache = true)
		{
			Executable executable = Compile(script, cache);
			if (executable == null)
			{
				return null;
			}
			return Execute(executable);
		}

		protected bool CompileScriptImpl(Script script, bool cache = true)
		{
			AntlrInputStream inputStream = new AntlrInputStream(script.Source.Replace("\r", "").Replace("\t", "  "));
			lexer.SetInputStream(inputStream);
			lexer.registeredCommands = commandList;
			CommonTokenStream tokenStream = new CommonTokenStream(lexer);
			parser.TokenStream = tokenStream;
			parser.Reset();
			ParseTree parseTree = script.parseTree;
			try
			{
				StonescriptParser.ProgramContext root = parser.program();
				script.parseTree = new ParseTree(script, root);
				if (!compiler.Compile(script, cache))
				{
					script.parseTree = parseTree;
					return false;
				}
				script.buildTimestamp = script.modifiedTimestamp;
				if (cache && (!scripts.ContainsKey(script.name) || scripts[script.name] != script))
				{
					scripts[script.name] = script;
				}
				return true;
			}
			catch (Exception ex)
			{
				script.parseTree = parseTree;
				HandleException(ex);
				return false;
			}
		}

		protected Executable CompileExecutableImpl(Script script, Executable executable, bool cache = true)
		{
			if (!CompileScriptImpl(script, cache))
			{
				return null;
			}
			if (executable == null)
			{
				executable = NewExecutable(script, null, cache);
			}
			try
			{
				linker.Link(executable);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
			executable.buildTimestamp = executable.script.buildTimestamp;
			return executable;
		}

		public Executable Compile(Script script, bool cache = true)
		{
			return CompileExecutableImpl(script, null, cache);
		}

		public Executable Compile(string[] program, string programName = null, bool cache = true)
		{
			return Compile(string.Join("\n", program), programName);
		}

		public Executable Compile(string program, string programName = null, bool cache = true)
		{
			Script script = null;
			if (programName != null && scripts.ContainsKey(programName))
			{
				script = scripts[programName];
			}
			if (script == null)
			{
				script = new Script(program, programName);
			}
			cache = cache && programName != null;
			return CompileExecutableImpl(script, null, cache);
		}

		public Executable Compile(Scope target, string program, string programName = null, bool cache = true)
		{
			Script script = null;
			if (programName != null && scripts.ContainsKey(programName))
			{
				script = scripts[programName];
			}
			if (script == null)
			{
				script = new Script(program, programName);
			}
			cache = cache && programName != null;
			Executable executable = NewExecutable(script, target, cache);
			CompileExecutableImpl(script, executable, cache);
			return executable;
		}

		public void CompileAsync(Script script, Scope scope, CompileCallback callback, bool cache = true)
		{
			if (component == null)
			{
				CreateComponent();
			}
			AsyncCompileOrder asyncCompileOrder = new AsyncCompileOrder
			{
				script = script,
				scope = scope,
				callback = callback
			};
			Thread thread = new Thread(CompileAsyncImpl);
			thread.Name = $"Compile {script.name} {asyncCompileOrder.instanceId}";
			thread.Start(asyncCompileOrder);
		}

		private void CompileAsyncImpl(object obj)
		{
			bool success = false;
			AsyncCompileOrder order = obj as AsyncCompileOrder;
			Script script = order.script;
			Executable executable = null;
			List<Exception> exceptions = new List<Exception>();
			HashSet<string> expressionsToCompile = new HashSet<string>();
			Stonescript.Compiler.Compiler compiler = new Stonescript.Compiler.Compiler(this);
			compiler.compileImports = this.compiler.compileImports;
			compiler.onWarning = delegate(Exception ex)
			{
				exceptions.Add(ex);
			};
			compiler.CacheSubstituteExpression = delegate(string expression)
			{
				expressionsToCompile.Add(expression);
			};
			Linker linker = new Linker(this);
			lock (script)
			{
				string source = script.Source;
				source = source.Replace("\r", "");
				source = source.Replace("\t", "  ");
				if (SSSystemProperties.IsRemoteFilePath())
				{
					RemoteScriptImporter.singleton.PreloadRemoteDependencies(source);
					while (RemoteScriptImporter.singleton.IsPreloading())
					{
						Thread.Sleep(200);
					}
				}
				StonescriptParser stonescriptParser = new StonescriptParser(new CommonTokenStream(new StonescriptLexer(new AntlrInputStream(source))
				{
					registeredCommands = commandList
				}));
				ParseTree parseTree = script.parseTree;
				try
				{
					StonescriptParser.ProgramContext root = stonescriptParser.program();
					script.parseTree = new ParseTree(script, root);
					success = compiler.Compile(script, order.cache);
					if (!success)
					{
						script.parseTree = parseTree;
					}
					else
					{
						script.buildTimestamp = script.modifiedTimestamp;
						executable = new Executable();
						executable.machine = this;
						executable.script = script;
						executable.Target = order.scope;
						linker.Link(executable);
						executable.buildTimestamp = script.modifiedTimestamp;
					}
				}
				catch (Exception item)
				{
					script.parseTree = parseTree;
					exceptions.Add(item);
				}
			}
			lock (component.callbacks)
			{
				component.callbacks.Add(delegate
				{
					if (success)
					{
						foreach (string item2 in expressionsToCompile)
						{
							CompileSubstituteExpressions(item2);
						}
						if (order.cache)
						{
							if (!scripts.ContainsKey(script.name) || scripts[script.name] != script)
							{
								scripts[script.name] = script;
							}
							if (!executablesByScript.ContainsKey(script.name))
							{
								executablesByScript[script.name] = new List<Executable>();
							}
							executablesByScript[script.name].Add(executable);
						}
					}
					order.callback(executable, exceptions);
				});
			}
		}

		public Script GetScript(string scriptName)
		{
			if (scripts.ContainsKey(scriptName))
			{
				return scripts[scriptName];
			}
			return null;
		}

		public void Recompile(string scriptName)
		{
			Script script = scripts[scriptName];
			Recompile(script);
		}

		public bool Recompile(Script script)
		{
			if (!CompileScriptImpl(script))
			{
				return false;
			}
			if (executablesByScript.ContainsKey(script.name))
			{
				foreach (Executable item in executablesByScript[script.name])
				{
					if (item.buildTimestamp != item.script.buildTimestamp)
					{
						try
						{
							linker.Link(item);
						}
						catch (Exception ex)
						{
							HandleException(ex);
						}
						item.buildTimestamp = item.script.buildTimestamp;
					}
				}
			}
			return true;
		}

		public void Recompile(Executable executable)
		{
			Recompile(executable.script);
			if (executable.buildTimestamp != executable.script.buildTimestamp)
			{
				try
				{
					linker.Link(executable);
				}
				catch (Exception ex)
				{
					HandleException(ex);
				}
				executable.buildTimestamp = executable.script.buildTimestamp;
			}
		}

		public void RecompileDirty()
		{
			recompileKeys.Clear();
			recompileKeys.AddRange(scripts.Keys);
			foreach (string recompileKey in recompileKeys)
			{
				Script script = scripts[recompileKey];
				ReloadIfNecessary(script);
				if (script.buildTimestamp != script.modifiedTimestamp)
				{
					Recompile(script);
				}
			}
		}

		public void Invalidate(string scriptName, string source, DateTime modifiedTimestamp)
		{
			if (!scripts.ContainsKey(scriptName))
			{
				Debug.LogWarning("Unable to invalidate script \"" + scriptName + "\" because it is not cached.");
				return;
			}
			Script script = scripts[scriptName];
			script.Source = source;
			script.modifiedTimestamp = modifiedTimestamp;
		}

		public void ReloadIfNecessary(Script script)
		{
			AStorage aStorage = Storage ?? SaveFiles.singleton.storage;
			string relFilename = Path.Combine("Stonescript/", script.name + ".txt");
			if (!aStorage.Exists(relFilename))
			{
				relFilename = Path.Combine("Stonescript/", script.name + ".stonescript.txt");
				if (!aStorage.Exists(relFilename))
				{
					return;
				}
			}
			DateTime modifiedTime = aStorage.GetModifiedTime(relFilename);
			if (modifiedTime != script.modifiedTimestamp)
			{
				script.Source = aStorage.LoadTextFile(relFilename);
				script.modifiedTimestamp = modifiedTime;
			}
		}

		public Executable CompileExpression(string expression, bool cache = true)
		{
			if (cache && expressions.ContainsKey(expression))
			{
				return expressions[expression];
			}
			StonescriptParser.ExpressionContext root = new StonescriptParser(new CommonTokenStream(new StonescriptLexer(new AntlrInputStream(expression))
			{
				registeredCommands = commandList
			})).expression();
			Script script = new Script(expression, expression);
			script.parseTree = new ParseTree(script, root);
			Executable executable = new Executable();
			executable.machine = this;
			executable.script = script;
			if (cache)
			{
				expressions[expression] = executable;
			}
			return executable;
		}

		public object EvaluateExpression(string expression, Stonescript.Runtime.ExecutionContext ctx = null)
		{
			if (expression == null)
			{
				return null;
			}
			Executable executable = CompileExpression(expression);
			if (executable == null)
			{
				return null;
			}
			bool flag = false;
			if (ctx == null)
			{
				flag = true;
				ctx = execCtxPool.Get();
				ctx.machine = this;
				ctx.processor = processor;
				executable.Target = scopePool.Get().Init();
			}
			else
			{
				executable.Target = ctx.CurrentTarget;
			}
			object result = processor.ExecuteExpression(executable, ctx);
			if (flag)
			{
				execCtxPool.Return(ctx);
			}
			return result;
		}

		public object EvaluateExpression(Executable executable, string expression, Stonescript.Runtime.ExecutionContext ctx = null)
		{
			if (expression == null || expression.Trim().Length == 0)
			{
				return null;
			}
			if (ctx == null)
			{
				ctx = new Stonescript.Runtime.ExecutionContext();
				ctx.machine = this;
				ctx.processor = processor;
			}
			return EvaluateExpression(expression, ctx);
		}

		public void CompileSubstituteExpressions(string message)
		{
			foreach (Match item in varReplaceRegex.Matches(message))
			{
				string expression = (item.Groups[1].Success ? item.Groups[1].Value : item.Groups[2].Value);
				CompileExpression(expression);
			}
		}

		public string SubstituteExpressions(string message, Stonescript.Runtime.ExecutionContext execCtx)
		{
			string text = message;
			foreach (Match item in varReplaceRegex.Matches(message))
			{
				string expression = (item.Groups[1].Success ? item.Groups[1].Value : item.Groups[2].Value);
				string newValue = DataTypes.ToString(EvaluateExpression(expression, execCtx));
				text = text.Replace(item.Value, newValue);
			}
			return text;
		}

		public Script CompileImport(string scriptName)
		{
			if (importStack.Contains(scriptName))
			{
				return null;
			}
			importStack.Push(scriptName);
			try
			{
				Script result = CacheScript(scriptName);
				importStack.Pop();
				return result;
			}
			catch (Exception)
			{
				importStack.Pop();
				throw;
			}
		}

		public Executable Import(string scriptName, Stonescript.Runtime.ExecutionContext execCtx = null)
		{
			importStack.Push(scriptName);
			CheckStackOverflow(importStack);
			try
			{
				Executable executable;
				if (importInstances.ContainsKey(scriptName))
				{
					executable = importInstances[scriptName];
					Execute(executable, execCtx);
				}
				else
				{
					executable = New(scriptName, execCtx);
					importInstances[scriptName] = executable;
				}
				importStack.Pop();
				return executable;
			}
			catch (Exception)
			{
				importStack.Pop();
				throw;
			}
		}

		protected void CheckStackOverflow(Stack<string> stack)
		{
			if (stack.Count <= MAX_IMPORT_DEPTH)
			{
				return;
			}
			List<string> list = new List<string>(new HashSet<string>(stack));
			string text;
			if (list.Count == 1)
			{
				text = "\"" + list[0] + "\" references itself.";
			}
			else if (list.Count == 2)
			{
				text = "\"" + list[0] + "\" and \"" + list[1] + "\" reference each other.";
			}
			else
			{
				text = "The following scripts may be involved: ";
				for (int i = 0; i < list.Count; i++)
				{
					string text2 = list[i];
					text = ((i != list.Count - 1) ? (text + text2 + ", ") : (text + "and " + text2 + "."));
				}
			}
			throw new StackOverflowException("Max import depth exceeded. " + text);
		}

		public Script CacheScript(string scriptName, string requirerName = null)
		{
			Script script = null;
			if (!scripts.ContainsKey(scriptName))
			{
				if (SSSystemProperties.IsRemoteFilePath())
				{
					script = new Script();
					script.name = scriptName;
					RemoteScriptImporter.singleton.LoadRemoteScript(scriptName, RemoteScriptImporter.Cache.Optional, delegate(UnityWebRequest.Result result, string body)
					{
						if (result == UnityWebRequest.Result.Success)
						{
							script.Source = body;
							CompileScriptImpl(script);
							return;
						}
						throw new FileNotFoundException("Failed to load remote script \"" + scriptName + "\". " + body);
					});
					if (script.Source != null)
					{
					}
				}
				else
				{
					scriptName = scriptName.Replace("\\", "/");
					AStorage aStorage = Storage ?? SaveFiles.singleton.storage;
					string relFilename = Path.Combine("Stonescript/", scriptName + ".txt");
					if (!aStorage.Exists(relFilename))
					{
						relFilename = Path.Combine("Stonescript/", scriptName + ".stonescript.txt");
						if (!aStorage.Exists(relFilename))
						{
							throw new FileNotFoundException("Unable to find script \"" + scriptName + "\".");
						}
					}
					script = new Script();
					script.name = scriptName;
					script.Source = aStorage.LoadTextFile(relFilename);
					script.modifiedTimestamp = aStorage.GetModifiedTime(relFilename);
					CompileScriptImpl(script);
				}
			}
			else
			{
				script = scripts[scriptName];
			}
			return script;
		}

		public Executable New(string scriptName, Stonescript.Runtime.ExecutionContext execCtx = null)
		{
			return New(scriptName, null, execCtx);
		}

		public Executable New(Script script, Scope scope = null, Stonescript.Runtime.ExecutionContext execCtx = null)
		{
			return New(script.name, scope, execCtx);
		}

		public Executable New(string scriptName, Scope scope = null, Stonescript.Runtime.ExecutionContext execCtx = null)
		{
			newStack.Push(scriptName);
			CheckStackOverflow(newStack);
			try
			{
				Script script = CacheScript(scriptName);
				Executable executable = NewExecutable(script, scope);
				linker.Link(executable);
				executable.buildTimestamp = script.modifiedTimestamp;
				Execute(executable, execCtx);
				newStack.Pop();
				return executable;
			}
			catch (Exception)
			{
				newStack.Pop();
				throw;
			}
		}

		public void RegisterFunction(string funcName, NativeFunction.Callback func, List<string> parameterNames = null)
		{
			funcName = funcName.ToLower();
			NativeFunction value = new NativeFunction(null, funcName, func, parameterNames);
			functions.Add(funcName, value);
			globals.Add(funcName, value);
		}

		public void RegisterCommand(string commandId, Command command, bool overrideExisting = false)
		{
			commandId = commandId.ToLower();
			if (commands.ContainsKey(commandId) && !overrideExisting)
			{
				Debug.LogWarning("Command \"" + commandId + "\" has already been registered and the new registration will be ignored.");
				return;
			}
			bool num = commands.ContainsKey(commandId);
			commands[commandId] = command;
			if (!num)
			{
				commandList.Add(commandId);
			}
		}

		public List<StonescriptResult> ExecuteCommand(string commandId, string parameters, Stonescript.Runtime.ExecutionContext ctx = null)
		{
			string command = commandId + parameters;
			commandId = commandId.ToLower();
			Command obj = SearchCommand(commandId) ?? throw new Exception("\"" + commandId + "\" is not a valid command.");
			List<StonescriptResult> list = new List<StonescriptResult>();
			if (obj(command, list, ctx))
			{
				allResults.AddRange(list);
			}
			return list;
		}

		public Command SearchCommand(string commandId)
		{
			if (commands.ContainsKey(commandId))
			{
				return commands[commandId];
			}
			foreach (KeyValuePair<string, Command> command in commands)
			{
				string key = command.Key;
				Command value = command.Value;
				if (commandId.StartsWith(key, ignoreCase: true, CultureInfo.InvariantCulture))
				{
					return value;
				}
			}
			return null;
		}

		public void RegisterVariable(string varId, StonescriptObject.Getter getter)
		{
			RegisterGlobal(varId, getter);
		}

		public void RegisterGlobal(string varId, object value)
		{
			globals.Add(varId.ToLower(), value);
		}

		public void RegisterGlobals(Dictionary<string, object> newGlobals)
		{
			foreach (KeyValuePair<string, object> newGlobal in newGlobals)
			{
				globals.Add(newGlobal.Key.ToLower(), newGlobal.Value);
			}
		}

		public bool HasGlobal(string varId)
		{
			varId = varId.ToLower();
			if (!globals.ContainsKey(varId))
			{
				return functions.ContainsKey(varId);
			}
			return true;
		}

		public bool HasGlobal<T>(string varId)
		{
			varId = varId.ToLower();
			if (!globals.ContainsKey(varId) || !(globals[varId] is T))
			{
				if (functions.ContainsKey(varId))
				{
					return functions[varId] is T;
				}
				return false;
			}
			return true;
		}

		public bool TryGetGlobal(string varId, out object value)
		{
			varId = varId.ToLower();
			if (globals.ContainsKey(varId))
			{
				value = globals[varId];
				if (value is StonescriptObject.Getter)
				{
					value = ((StonescriptObject.Getter)value)();
				}
				return true;
			}
			value = null;
			return false;
		}

		public bool TryGetGlobal<T>(string varId, ref T value)
		{
			varId = varId.ToLower();
			if (globals.ContainsKey(varId))
			{
				object obj = globals[varId];
				if (obj is StonescriptObject.Getter)
				{
					obj = ((StonescriptObject.Getter)obj)();
				}
				if (obj is T)
				{
					value = (T)obj;
					return true;
				}
			}
			return false;
		}

		public object GetGlobal(string varId)
		{
			varId = varId.ToLower();
			if (globals.ContainsKey(varId))
			{
				object obj = globals[varId];
				if (obj is StonescriptObject.Getter)
				{
					obj = ((StonescriptObject.Getter)obj)();
				}
				return obj;
			}
			throw new Exception("Variable \"" + varId + "\" is not declared.");
		}

		public T GetGlobal<T>(string varId)
		{
			object global = GetGlobal(varId);
			if (!(global is T))
			{
				throw new Exception("Variable \"" + varId + "\" is not a " + typeof(T).Name + ".");
			}
			return (T)global;
		}

		public bool IsReserved(string varId)
		{
			varId = varId.ToLower();
			if (!globals.ContainsKey(varId) && !commands.ContainsKey(varId))
			{
				return reservedVariableIds.Contains(varId);
			}
			return true;
		}

		public string ValidateVariableName(string varId)
		{
			if (varId == null)
			{
				return "Variable name cannot be a reserved word.";
			}
			if (varId.Contains("."))
			{
				return "Variable declaration \"" + varId + "\" cannot be nested";
			}
			if (IsReserved(varId))
			{
				return "Variable \"" + varId + "\" is reserved";
			}
			return null;
		}

		public void ClearVariables()
		{
			foreach (KeyValuePair<string, List<Executable>> item in executablesByScript)
			{
				foreach (Executable item2 in item.Value)
				{
					item2.Target.ClearData();
				}
			}
		}

		public void AddProfiler(string scriptName)
		{
			if (!profilers.ContainsKey(scriptName))
			{
				_ = scripts[scriptName];
				ScriptProfiler scriptProfiler = new GameObject(scriptName + " Profiler").AddComponent<ScriptProfiler>();
				scriptProfiler.script = scripts[scriptName];
				profilers[scriptName] = scriptProfiler;
			}
		}
	}
}
