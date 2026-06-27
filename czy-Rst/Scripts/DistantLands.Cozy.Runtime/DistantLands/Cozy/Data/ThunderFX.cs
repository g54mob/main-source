using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Thunder FX", order = 361)]
	public class ThunderFX : FXProfile
	{
		public Vector2 timeBetweenStrikes;

		public GameObject thunderPrefab;

		public float weight;

		public CozyThunderManager runtimeRef;

		public float minimumDistance = 700f;

		public float maximumDistance = 1200f;

		public float minScreenXmultiplier = 0.1f;

		public float maxScreenXmultiplier = 0.9f;

		public float minScreenYmultiplier;

		public float maxScreenYmultiplier = 0.1f;

		[Range(0f, 1f)]
		[Tooltip("What percentage of the time should the lightning and thunder be forced to spawn in the camera's view?")]
		public float spawnInFrustumPercentage = 0.5f;

		public override void PlayEffect(float weight)
		{
			if ((bool)runtimeRef || InitializeEffect(weatherSphere))
			{
				runtimeRef.PlayEffect(transitionTimeModifier.Evaluate(weight));
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
				if ((bool)weather.GetFXRuntimeRef<CozyThunderManager>(base.name))
				{
					runtimeRef = weather.GetFXRuntimeRef<CozyThunderManager>(base.name);
					return true;
				}
				runtimeRef = new GameObject().AddComponent<CozyThunderManager>();
				runtimeRef.gameObject.name = base.name;
				runtimeRef.transform.parent = weather.thunderFXParent;
				runtimeRef.transform.localPosition = Vector3.zero;
				runtimeRef.transform.localRotation = Quaternion.identity;
				runtimeRef.weatherSphere = weather;
				runtimeRef.thunderFX = this;
			}
			return true;
		}
	}
}
