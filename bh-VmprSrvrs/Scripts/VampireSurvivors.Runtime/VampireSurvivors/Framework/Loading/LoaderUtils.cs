using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading
{
	public static class LoaderUtils
	{
		public static readonly Type TEX2DType;

		public static readonly Type VideoClipType;

		public static string GetDynamicLabel(DlcType? dlcType)
		{
			return null;
		}

		public static void WaitForAsyncLoad<T>(AsyncOperationHandle<T> operationHandle, Action<T> onComplete, Action<T> onError, string errorPrefix = "WaitForAsyncLoad", bool forceSync = false)
		{
		}
	}
}
