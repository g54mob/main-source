using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SquareCurve : IEffectCurve
	{
		public int BakeResolution => 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			if (!(time < 0.5f))
			{
				return 1f;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			if (!(time < 0.5f))
			{
				return -1f;
			}
			return 1f;
		}

		public void Initialize()
		{
		}
	}
}
