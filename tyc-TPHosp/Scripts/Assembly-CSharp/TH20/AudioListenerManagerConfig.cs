using System.Collections.Generic;
using FullInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Audio Listener Manager", order = 1104)]
	public class AudioListenerManagerConfig : BaseScriptableObject
	{
		public List<AudioMixerGroup> InHositalAudioMixerGroups = new List<AudioMixerGroup>();

		[InspectorMargin(8)]
		[InspectorHeader("Radius Falloff System")]
		[InspectorComment("How far away from the hospital floor is the listener")]
		public float ListenerHeight = 3.5f;

		[InspectorMargin(4)]
		[InspectorComment("Approximately how much of the screen the radius of sound effects should cover")]
		public float MinRadiusFraction = 0.1f;

		public float MaxRadiusFraction = 1.2f;

		[InspectorMargin(4)]
		[InspectorComment("These cap values are to keep sfx radius values at sensible amounts")]
		public float MinRadiusCap = 0.1f;

		public float MaxRadiusCap = 500f;

		[InspectorMargin(8)]
		[InspectorHeader("Low Pass Filter Falloff")]
		public float ClosestLowPassRadius = 0.1f;

		public float FurthestLowPassRadius = 500f;

		public float ClosestLowPassCutoffFrequency = 22000f;

		public float FurthestLowPassCutoffFrequency = 1000f;

		[InspectorMargin(8)]
		[InspectorHeader("Camera Frustum Falloff System")]
		[FormerlySerializedAs("SilentFrustrumDistance")]
		public float SilentFrustumDistance = 1f;

		protected override void OnValidate()
		{
			base.OnValidate();
			ClosestLowPassRadius = Mathf.Max(0f, ClosestLowPassRadius);
			FurthestLowPassRadius = Mathf.Max(0f, FurthestLowPassRadius);
			ClosestLowPassCutoffFrequency = Mathf.Clamp(ClosestLowPassCutoffFrequency, 0f, 22000f);
			FurthestLowPassCutoffFrequency = Mathf.Clamp(FurthestLowPassCutoffFrequency, 0f, 22000f);
			SilentFrustumDistance = Mathf.Max(0f, SilentFrustumDistance);
		}
	}
}
