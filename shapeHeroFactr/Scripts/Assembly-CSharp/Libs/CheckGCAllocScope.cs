using System;
using Unity.Profiling;
using UnityEngine;

namespace Libs
{
	public class CheckGCAllocScope : IDisposable
	{
		private readonly string m_name;

		private readonly long m_startValue;

		private static ProfilerRecorder m_profilerRecorder;

		private CheckGCAllocScope(string name)
		{
		}

		public void Dispose()
		{
		}

		public static CheckGCAllocScope Create(string name)
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RuntimeInitializeOnLoadMethod()
		{
		}
	}
}
