using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/ReSound/FX", order = 361)]
	public class ReSoundFX : FXProfile
	{
		public ReSoundTrack track;

		private ReSoundModule module;

		public override void PlayEffect(float weight)
		{
			if ((bool)module || InitializeEffect(null))
			{
				module.fXes[this] = weight;
				module.fxWeight += weight;
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			base.InitializeEffect(weather);
			if (!weatherSphere.GetModule<ReSoundModule>())
			{
				return false;
			}
			module = weatherSphere.GetModule<ReSoundModule>();
			if (!module.fXes.ContainsKey(this))
			{
				module.fXes.Add(this, 0f);
			}
			return true;
		}
	}
}
