using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Metagame Map Ambience", order = 1025)]
	public class MetagameMapAmbienceConfig : ScriptableObjectWithID
	{
		public AnimationCurve HeightVolumeCurve = AnimationCurve.Linear(0f, 100f, 1f, 0f);

		public float AmbienceFadeDuration = 1f;

		public int HorizontalSamples = 5;

		public int VerticalSamples = 4;

		[Header("Sky Ambience")]
		public string SkyAmbienceAudioEvent;

		public AnimationCurve SkyAmbienceHeightVolumeCurve = AnimationCurve.Linear(0f, 100f, 0f, 1f);
	}
}
