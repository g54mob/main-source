using System;
using System.Collections.Generic;
using System.Reflection;

namespace MoonSharp.Interpreter
{
	public sealed class CallbackFunction : RefIdObject
	{
		private static InteropAccessMode m_DefaultAccessMode;

		public string Name { get; private set; }

		public Func<ScriptExecutionContext, CallbackArguments, DynValue> ClrCallback { get; private set; }

		public static InteropAccessMode DefaultAccessMode
		{
			get
			{
				return default(InteropAccessMode);
			}
			set
			{
			}
		}

		public object AdditionalData { get; set; }

		public CallbackFunction(Func<ScriptExecutionContext, CallbackArguments, DynValue> callBack, string name = null)
		{
		}

		public DynValue Invoke(ScriptExecutionContext executionContext, IList<DynValue> args, bool isMethodCall = false)
		{
			return null;
		}

		public static CallbackFunction FromDelegate(Script script, Delegate del, InteropAccessMode accessMode = InteropAccessMode.Default)
		{
			return null;
		}

		public static CallbackFunction FromMethodInfo(Script script, MethodInfo mi, object obj = null, InteropAccessMode accessMode = InteropAccessMode.Default)
		{
			return null;
		}

		public static bool CheckCallbackSignature(MethodInfo mi, bool requirePublicVisibility)
		{
			return false;
		}
	}
}
