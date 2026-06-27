using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	public abstract class FXProfile : ScriptableObject
	{
		[TransitionTime]
		[Tooltip("A curve modifier that is used to impact the speed of the transition for this effect.")]
		public AnimationCurve transitionTimeModifier = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		protected CozyWeather weatherSphere;

		public abstract void PlayEffect(float weight);

		public virtual bool InitializeEffect(CozyWeather weather)
		{
			weatherSphere = (weather ? weather : CozyWeather.instance);
			return true;
		}
	}
}
