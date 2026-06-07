using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Febucci.Numbers;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BounceCurve : IEffectCurve
	{
		public int BakeResolution => 360;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			return Tween.BounceTween(time);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			return Evaluate01(time);
		}

		public void Initialize()
		{
		}
	}
}
