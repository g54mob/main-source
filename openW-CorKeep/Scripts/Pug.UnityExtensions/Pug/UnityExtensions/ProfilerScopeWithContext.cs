using System;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;

namespace Pug.UnityExtensions
{
	[IgnoredByDeepProfiler]
	public struct ProfilerScopeWithContext : IDisposable
	{
		private ProfilerMarker _marker;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ProfilerScopeWithContext(ProfilerMarker marker, UnityEngine.Object obj)
		{
			_marker = marker;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
		}
	}
}
