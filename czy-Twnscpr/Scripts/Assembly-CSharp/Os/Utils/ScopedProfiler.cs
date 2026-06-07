using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Os.Utils
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ScopedProfiler : IDisposable
	{
		public ScopedProfiler(string name)
		{
		}

		public ScopedProfiler(string name, UnityEngine.Object targetObject)
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
