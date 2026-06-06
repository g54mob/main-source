using UnityEngine;

namespace MyStuff.Environment
{
	public class AtmosphereController : MonoBehaviour
	{
		[Header("Configuration")]
		[Tooltip("Settings asset")]
		[SerializeField]
		private TimeOfDaySettings settings;

		private float timeSinceLastUpdate;

		private float updateInterval;

		private Material skyboxMaterial;

		private bool skyboxMaterialCached;

		private ReflectionProbe reflectionProbe;

		private TimePhase lastPhaseForProbeUpdate;

		private void Start()
		{
		}

		public void AssignSettings(TimeOfDaySettings newSettings)
		{
		}

		private void CacheSkyboxMaterial()
		{
		}

		private void FindReflectionProbe()
		{
		}

		public void UpdateAtmosphere(float normalizedTime, TimePhase currentPhase, float deltaTime)
		{
		}

		private void UpdateFog(float normalizedTime)
		{
		}

		private void UpdateAmbient(float normalizedTime)
		{
		}

		private void UpdateSkybox(float normalizedTime)
		{
		}

		private void UpdateReflectionProbe()
		{
		}

		public void ForceUpdate(float normalizedTime, TimePhase currentPhase)
		{
		}
	}
}
