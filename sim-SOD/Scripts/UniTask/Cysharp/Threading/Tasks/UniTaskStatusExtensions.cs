using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public static class UniTaskStatusExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsCompleted(this UniTaskStatus status)
		{
			return false;
		}
	}
}
