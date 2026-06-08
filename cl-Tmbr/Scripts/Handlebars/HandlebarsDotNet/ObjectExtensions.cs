using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet
{
	internal static class ObjectExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerStepThrough]
		public static T As<T>(this object source)
		{
			return (T)source;
		}
	}
}
