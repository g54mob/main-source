using UnityEngine;

namespace Animancer
{
	public class MixerParameterTweenFloat : MixerParameterTween<float>
	{
		public MixerParameterTweenFloat()
		{
		}

		public MixerParameterTweenFloat(MixerState<float> mixer)
			: base(mixer)
		{
		}

		protected override float CalculateCurrentValue()
		{
			return Mathf.LerpUnclamped(base.StartValue, base.EndValue, base.Progress);
		}
	}
}
