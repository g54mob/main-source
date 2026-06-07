using AmplifyOcclusion;
using DV.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DV
{
	public class PostProcessingVolumeAOController : MonoBehaviour
	{
		[SerializeField]
		private GameObject postProcessAmbientOcclusionVolumeGO;

		private void OnEnable()
		{
			OnPreferenceChanged();
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				GamePreferences.RegisterToPreferenceUpdated(Preferences.AmbientOcclusionQualityIndex, OnPreferenceChanged);
			}
			else
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.AmbientOcclusionQualityIndex, OnPreferenceChanged);
			}
		}

		private void OnPreferenceChanged()
		{
			bool isSSAOOn = SingletonBehaviour<GraphicsOptions>.Instance.IsSSAOOn;
			if (postProcessAmbientOcclusionVolumeGO.GetComponent<PostProcessVolume>().profile.TryGetSettings<AmplifyOcclusionEffect>(out var outSetting))
			{
				outSetting.enabled.value = isSSAOOn;
			}
		}

		public void ForceUpdate()
		{
			OnPreferenceChanged();
		}
	}
}
