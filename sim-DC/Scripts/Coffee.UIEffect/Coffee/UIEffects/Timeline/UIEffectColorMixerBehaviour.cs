using UnityEngine;

namespace Coffee.UIEffects.Timeline
{
	public abstract class UIEffectColorMixerBehaviour : UIEffectMixerBehaviour<Color, UIEffectColorBehaviour>
	{
		protected override Color Add(Color baseValue, Color value, float weight)
		{
			return default(Color);
		}

		protected override Color Lerp(Color defaultValue, Color value, float weight)
		{
			return default(Color);
		}
	}
}
