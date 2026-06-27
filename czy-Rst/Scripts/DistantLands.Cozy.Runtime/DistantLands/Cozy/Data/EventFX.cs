using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Event FX", order = 361)]
	public class EventFX : FXProfile
	{
		public delegate void OnCall();

		public delegate void OnEnd();

		public CozyEventModule events;

		public bool isPlaying;

		public event OnCall onCall;

		public event OnEnd onEnd;

		public void RaiseOnCall()
		{
			this.onCall?.Invoke();
		}

		public void RaiseOnEnd()
		{
			this.onEnd?.Invoke();
		}

		public void PlayEffect()
		{
			if (!isPlaying)
			{
				isPlaying = true;
				this.onCall?.Invoke();
			}
		}

		public override void PlayEffect(float weight)
		{
			if (weight > 0.5f)
			{
				PlayEffect();
			}
			else
			{
				StopEffect();
			}
		}

		public void StopEffect()
		{
			if (isPlaying)
			{
				isPlaying = false;
				this.onEnd?.Invoke();
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			base.InitializeEffect(weather);
			if (!weatherSphere.GetModule<CozyEventModule>())
			{
				return false;
			}
			events = weatherSphere.GetModule<CozyEventModule>();
			return true;
		}
	}
}
