using System;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal struct CurveEffectParameters
	{
		public Axis position;

		public ScaleAxis scale;

		public Axis rotation;

		public GradientParam color;
	}
}
