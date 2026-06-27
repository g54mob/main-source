using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Particle FX", order = 361)]
	public class ParticleFX : FXProfile
	{
		public CozyParticles particleSystem;

		private CozyParticles runtimeRef;

		public bool autoScale;

		public override void PlayEffect(float intensity)
		{
			if ((bool)runtimeRef || InitializeEffect(weatherSphere))
			{
				if (autoScale)
				{
					runtimeRef.transform.localScale = weatherSphere.transform.GetChild(0).localScale;
				}
				if (intensity == 0f)
				{
					runtimeRef.Stop();
				}
				else
				{
					runtimeRef.Play(transitionTimeModifier.Evaluate(intensity));
				}
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			if (!Application.isPlaying)
			{
				return false;
			}
			base.InitializeEffect(weather);
			if (runtimeRef == null)
			{
				runtimeRef = weather.GetFXRuntimeRef<CozyParticles>(base.name);
				if ((bool)runtimeRef)
				{
					return true;
				}
				runtimeRef = UnityEngine.Object.Instantiate(particleSystem).GetComponent<CozyParticles>();
				runtimeRef.gameObject.name = base.name;
				runtimeRef.transform.parent = weather.particleFXParent;
				runtimeRef.transform.localPosition = Vector3.zero;
				runtimeRef.transform.localRotation = Quaternion.identity;
				runtimeRef.SetupTriggers();
				if (autoScale)
				{
					runtimeRef.transform.localScale *= weather.transform.GetChild(0).localScale.x;
				}
			}
			return true;
		}
	}
}
