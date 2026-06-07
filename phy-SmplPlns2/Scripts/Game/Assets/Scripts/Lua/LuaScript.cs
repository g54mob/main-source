using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using UnityEngine;

namespace Assets.Scripts.Lua
{
	public class LuaScript
	{
		private List<DynValue> _coroutines = new List<DynValue>();

		private Script _script;

		public int CoroutineAutoYieldCounter { get; set; } = 1000;

		public LuaScript(bool registerDefaultTypes = true)
		{
			_script = new Script();
			_script.Options.ScriptLoader = new FileSystemScriptLoader();
			_script.Options.DebugPrint = delegate(string s)
			{
				Debug.Log(s);
			};
			if (registerDefaultTypes)
			{
				RegisterType<Vector3>(includeStatic: true);
				RegisterType<EventArgs>();
			}
		}

		public void Call(string functionName, params object[] args)
		{
			try
			{
				if (args.Length == 0)
				{
					_script.Call(_script.Globals[functionName]);
				}
				else
				{
					_script.Call(_script.Globals[functionName], args);
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		public void RegisterObject(string name, object obj)
		{
			UserData.RegisterType(obj.GetType());
			_script.Globals[name] = UserData.Create(obj);
		}

		public void RegisterType<T>(bool includeStatic = false)
		{
			if (!UserData.IsTypeRegistered<T>())
			{
				UserData.RegisterType<T>();
			}
			if (includeStatic)
			{
				Type typeFromHandle = typeof(T);
				_script.Globals[typeFromHandle.Name] = typeFromHandle;
			}
		}

		public DynValue RunScript(string script)
		{
			return _script.DoString(script);
		}

		public void RunScriptFromFile(string filename)
		{
			try
			{
				_script.DoFile(filename);
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		public void StartCoroutine(string functionName, params object[] args)
		{
			try
			{
				object function = _script.Globals[functionName];
				DynValue dynValue = _script.CreateCoroutine(function);
				if (CoroutineAutoYieldCounter > 0)
				{
					dynValue.Coroutine.AutoYieldCounter = CoroutineAutoYieldCounter;
				}
				dynValue.Coroutine.Resume(args);
				_coroutines.Add(dynValue);
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		public void UpdateCoroutines()
		{
			List<DynValue> list = new List<DynValue>();
			foreach (DynValue coroutine in _coroutines)
			{
				if (coroutine.Coroutine.State != CoroutineState.Dead)
				{
					try
					{
						coroutine.Coroutine.Resume();
					}
					catch (Exception ex)
					{
						HandleError(ex);
						list.Add(coroutine);
					}
				}
				if (coroutine.Coroutine.State == CoroutineState.Dead)
				{
					list.Add(coroutine);
				}
			}
			foreach (DynValue item in list)
			{
				_coroutines.Remove(item);
			}
		}

		private void HandleError(Exception ex)
		{
			if (ex is ScriptRuntimeException ex2)
			{
				Debug.LogError("Lua script error: " + ex2.DecoratedMessage);
				return;
			}
			if (ex is SyntaxErrorException ex3)
			{
				Debug.LogError("Lua syntax error: " + ex3.DecoratedMessage);
				return;
			}
			throw ex;
		}
	}
}
