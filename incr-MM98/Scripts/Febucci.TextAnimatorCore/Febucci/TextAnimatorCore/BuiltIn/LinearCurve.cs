using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Febucci.Numbers;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct LinearCurve : IEffectCurve
	{
		public int BakeResolution => 90;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			return Mathf.Clamp01(time);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			if (time < 0.25f)
			{
				return 4f * time;
			}
			if (time < 0.75f)
			{
				return 2f - 4f * time;
			}
			return 4f * time - 4f;
		}

		public void Initialize()
		{
		}
	}
}
