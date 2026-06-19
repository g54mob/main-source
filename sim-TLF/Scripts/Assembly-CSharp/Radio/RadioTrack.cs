using UnityEngine;

namespace Radio
{
	[CreateAssetMenu(menuName = "Radio/RadioTrack")]
	public class RadioTrack : ScriptableObject
	{
		[Tooltip("Track display name")]
		public string trackName;

		[Tooltip("JSAM AudioManager key, e.g. Music/Track01")]
		public AudioClip musicFileObject;

		public TrackType type;

		[Tooltip("Required conditions for Special tracks (OR logic)")]
		public RadioCondition requiredConditions;

		[Range(0.1f, 10f)]
		[Tooltip("Random pick weight")]
		public float weight = 1f;
	}
}
