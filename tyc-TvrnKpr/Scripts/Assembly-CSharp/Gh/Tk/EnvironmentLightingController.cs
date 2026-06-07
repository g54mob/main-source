using System;
using UnityEngine;

namespace Gh.Tk
{
	public class EnvironmentLightingController : SingletonMonoBehaviour<EnvironmentLightingController>
	{
		[SerializeField]
		private EnvironmentLighting _defaultTavernLighting;

		[SerializeField]
		private EnvironmentLighting _defaultWorldMapLighting;

		private EnvironmentLighting _tavernLightingOverride;

		private void Start()
		{
		}

		private void OnActiveCameraChanged(object sender, EventArgs e)
		{
		}

		public void SetTavernLighting(EnvironmentLighting lighting)
		{
		}

		public void ResetToDefault()
		{
		}

		private void UpdateLightingState()
		{
		}
	}
}
