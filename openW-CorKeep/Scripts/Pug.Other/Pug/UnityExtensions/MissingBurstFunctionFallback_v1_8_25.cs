using System;
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using Unity.Burst;
using UnityEngine;
using UnityEngine.Scripting;

namespace Pug.UnityExtensions
{
	[HarmonyPatch(typeof(BurstCompiler))]
	[HarmonyPatch("Compile")]
	[HarmonyPatch(new Type[]
	{
		typeof(object),
		typeof(MethodInfo),
		typeof(bool),
		typeof(bool),
		typeof(bool)
	})]
	public static class MissingBurstFunctionFallback_v1_8_25
	{
		private const string EXCEPTION_MESSAGE = "Burst failed to compile the function pointer";

		[Preserve]
		private unsafe static Exception Finalizer(object delegateObj, bool isILPostProcessing, ref void* __result, Exception __exception)
		{
			if (isILPostProcessing)
			{
				return __exception;
			}
			if (!(__exception is InvalidOperationException) || !__exception.Message.StartsWith("Burst failed to compile the function pointer"))
			{
				return __exception;
			}
			Debug.LogWarning(__exception.Message + "; trying fallback");
			Delegate obj = delegateObj as Delegate;
			GCHandle.Alloc(obj);
			__result = (void*)Marshal.GetFunctionPointerForDelegate(obj);
			return null;
		}
	}
}
