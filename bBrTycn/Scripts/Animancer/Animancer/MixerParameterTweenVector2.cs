using UnityEngine;

namespace Animancer
{
	public class MixerParameterTweenVector2 : MixerParameterTween<Vector2>
	{
		public MixerParameterTweenVector2()
		{
		}

		public MixerParameterTweenVector2(MixerState<Vector2> mixer)
			: base(mixer)
		{
		}

		protected override Vector2 CalculateCurrentValue()
		{
			return Vector2.LerpUnclamped(base.StartValue, base.EndValue, base.Progress);
		}
	}
}
