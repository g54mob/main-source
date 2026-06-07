using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct StepCurve : IEffectCurve
	{
		public int BakeResolution => 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate01(float time)
		{
			if (time < 0.25f)
			{
				return 0f;
			}
			if (time < 0.5f)
			{
				return 1f / 3f;
			}
			if (time < 0.75f)
			{
				return 2f / 3f;
			}
			return 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateRange(float time)
		{
			if (time < 0.25f)
			{
				return 0f;
			}
			if (time < 0.5f)
			{
				return 1f;
			}
			if (time < 0.75f)
			{
				return 0f;
			}
			return -1f;
		}

		public void Initialize()
		{
		}
	}
}
