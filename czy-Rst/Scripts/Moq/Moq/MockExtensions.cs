using System;
using System.ComponentModel;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class MockExtensions
	{
		public static void Reset(this Mock mock)
		{
			mock.ConfiguredDefaultValues.Clear();
			mock.MutableSetups.Clear();
			mock.EventHandlers.Clear();
			mock.Invocations.Clear();
		}

		[Obsolete("Use `mock.Invocations.Clear()` instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResetCalls(this Mock mock)
		{
			mock.Invocations.Clear();
		}
	}
}
