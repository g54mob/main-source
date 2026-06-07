namespace Coffee.UIEffects.Timeline
{
	public abstract class UIEffectFloatMixerBehaviour : UIEffectMixerBehaviour<float, UIEffectFloatBehaviour>
	{
		protected override float Add(float baseValue, float value, float weight)
		{
			return 0f;
		}

		protected override float Lerp(float defaultValue, float value, float weight)
		{
			return 0f;
		}
	}
}
