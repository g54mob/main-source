using System;
using System.Collections.Generic;
using System.Reflection;
using MoonSharp.Interpreter.DataStructs;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class EventMemberDescriptor : IMemberDescriptor
	{
		private delegate void EventWrapper00();

		private delegate void EventWrapper01(object o1);

		private delegate void EventWrapper02(object o1, object o2);

		private delegate void EventWrapper03(object o1, object o2, object o3);

		private delegate void EventWrapper04(object o1, object o2, object o3, object o4);

		private delegate void EventWrapper05(object o1, object o2, object o3, object o4, object o5);

		private delegate void EventWrapper06(object o1, object o2, object o3, object o4, object o5, object o6);

		private delegate void EventWrapper07(object o1, object o2, object o3, object o4, object o5, object o6, object o7);

		private delegate void EventWrapper08(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8);

		private delegate void EventWrapper09(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9);

		private delegate void EventWrapper10(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10);

		private delegate void EventWrapper11(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10, object o11);

		private delegate void EventWrapper12(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10, object o11, object o12);

		private delegate void EventWrapper13(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10, object o11, object o12, object o13);

		private delegate void EventWrapper14(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10, object o11, object o12, object o13, object o14);

		private delegate void EventWrapper15(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10, object o11, object o12, object o13, object o14, object o15);

		private delegate void EventWrapper16(object o1, object o2, object o3, object o4, object o5, object o6, object o7, object o8, object o9, object o10, object o11, object o12, object o13, object o14, object o15, object o16);

		public const int MAX_ARGS_IN_DELEGATE = 16;

		private object m_Lock;

		private MultiDictionary<object, Closure> m_Callbacks;

		private Dictionary<object, Delegate> m_Delegates;

		private MethodInfo m_Add;

		private MethodInfo m_Remove;

		public EventInfo EventInfo { get; private set; }

		public bool IsStatic { get; private set; }

		public string Name => null;

		public MemberDescriptorAccess MemberAccess => default(MemberDescriptorAccess);

		public static EventMemberDescriptor TryCreateIfVisible(EventInfo ei, InteropAccessMode accessMode)
		{
			return null;
		}

		public static bool CheckEventIsCompatible(EventInfo ei, bool throwException)
		{
			return false;
		}

		public EventMemberDescriptor(EventInfo ei, InteropAccessMode accessMode = InteropAccessMode.Default)
		{
		}

		public DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		internal DynValue AddCallback(object o, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
		}

		internal DynValue RemoveCallback(object o, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
		}

		private void RegisterCallback(object o)
		{
		}

		private void UnregisterCallback(object o)
		{
		}

		private Delegate CreateDelegate(object sender)
		{
			return null;
		}

		private void DispatchEvent(object sender, object o01 = null, object o02 = null, object o03 = null, object o04 = null, object o05 = null, object o06 = null, object o07 = null, object o08 = null, object o09 = null, object o10 = null, object o11 = null, object o12 = null, object o13 = null, object o14 = null, object o15 = null, object o16 = null)
		{
		}

		public void SetValue(Script script, object obj, DynValue v)
		{
		}
	}
}
