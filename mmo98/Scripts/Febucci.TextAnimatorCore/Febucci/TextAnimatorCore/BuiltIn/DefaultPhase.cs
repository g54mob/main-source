using System;
using System.Runtime.CompilerServices;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct DefaultPhase : IEffectPhase, IParameterUpdater
	{
		public float charOffset;

		public float wordOffset;

		public float speed;

		public float MaxSpeed => speed;

		public DefaultPhase(float charOffset, float wordOffset, float speed)
		{
			this.charOffset = charOffset;
			this.wordOffset = wordOffset;
			this.speed = speed;
		}

		public void UpdateParameters(RegionParameters parameters)
		{
			charOffset = parameters.ModifyFloat("i", charOffset);
			wordOffset = parameters.ModifyFloat("w", wordOffset);
			speed = parameters.ModifyFloat("s", speed);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetSpeedFor(int charIndex, int wordIndex)
		{
			return speed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetOffsetFor(int charIndex, int wordIndex)
		{
			return (float)charIndex * charOffset + (float)wordIndex * wordOffset;
		}
	}
}
