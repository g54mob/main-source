using UnityEngine;

namespace Radio
{
	[CreateAssetMenu(menuName = "Radio/Radio Channel")]
	public class RadioChannel : ScriptableObject
	{
		[Tooltip("Display name shown in UI")]
		public string channelName;

		public RadioTrack[] musicTracks;

		public RadioTrack[] adTracks;

		public RadioTrack[] specialTracks;

		[Range(1f, 20f)]
		[Tooltip("Play one ad after every N music tracks")]
		public int adEveryNTracks = 4;

		[Tooltip("Play an ad immediately when the channel starts")]
		public bool playAdFirst;

		[Tooltip("Signal radius in world units. 0 = everywhere")]
		public float signalRadius;

		[Tooltip("World position of the signal source (used when signalRadius > 0)")]
		public Vector3 signalOrigin;
	}
}
