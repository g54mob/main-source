using System;
using System.Reflection;
using UnityEngine;

namespace Tantawowa.TimelineEvents
{
	public class EventInvocationInfo
	{
		public Behaviour TargetBehaviour;

		public MethodInfo MethodInfo;

		public static Type[] SupportedTypes;

		public string Key;

		public EventInvocationInfo(string key, Behaviour targetBehaviour, MethodInfo methodInfo)
		{
		}

		public void Invoke(object value)
		{
		}

		public void InvokEnum(int value)
		{
		}

		public void InvokeNoArgs()
		{
		}

		public void Invoke(bool isSingleArg, string value)
		{
		}
	}
}
