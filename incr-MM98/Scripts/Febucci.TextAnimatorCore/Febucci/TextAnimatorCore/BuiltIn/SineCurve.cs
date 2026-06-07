using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SineCurve : IEffectCurve
	{
		public int BakeResolution => 360;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			return MathF.Sin(time * MathF.PI * 0.5f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			return MathF.Sin(time * MathF.PI * 2f);
		}

		public void Initialize()
		{
		}
	}
}
