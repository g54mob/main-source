using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HoldCurve : IEffectCurve
	{
		private const float ArbitraryZeroThreshold = 0.1f;

		public int BakeResolution => 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			return (time > 0.1f) ? 1 : 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			return 1f;
		}

		public void Initialize()
		{
		}
	}
}
