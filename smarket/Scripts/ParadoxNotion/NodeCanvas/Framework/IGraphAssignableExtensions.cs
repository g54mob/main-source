using System;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public static class IGraphAssignableExtensions
	{
		public static Graph CheckInstance(this IGraphAssignable assignable)
		{
			return null;
		}

		public static bool TryStartSubGraph(this IGraphAssignable assignable, Component agent, Action<bool> callback = null)
		{
			return false;
		}

		public static bool TryStopSubGraph(this IGraphAssignable assignable)
		{
			return false;
		}

		public static bool TryPauseSubGraph(this IGraphAssignable assignable)
		{
			return false;
		}

		public static bool TryResumeSubGraph(this IGraphAssignable assignable)
		{
			return false;
		}

		public static bool TryUpdateSubGraph(this IGraphAssignable assignable)
		{
			return false;
		}

		public static void TryWriteAndBindMappedVariables(this IGraphAssignable assignable)
		{
		}

		public static void TryReadAndUnbindMappedVariables(this IGraphAssignable assignable)
		{
		}

		public static void ValidateSubGraphAndParameters(this IGraphAssignable assignable)
		{
		}
	}
}
