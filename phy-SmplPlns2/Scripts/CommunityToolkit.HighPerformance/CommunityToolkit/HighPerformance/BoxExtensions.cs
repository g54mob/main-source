using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance
{
	public static class BoxExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T GetReference<T>(this Box<T> box) where T : struct
		{
			return ref Unsafe.Unbox<T>(box);
		}
	}
}
