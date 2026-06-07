using UnityEngine;

namespace AudioSystem
{
	public class SceneMusicController : MonoBehaviour
	{
		[Header("Music Source")]
		[Tooltip("Single track to play. If assigned, playlist is ignored.")]
		[SerializeField]
		private MusicTrack singleTrack;

		[Tooltip("Playlist to play. Used if singleTrack is not assigned.")]
		[SerializeField]
		private MusicPlaylist playlist;

		[Header("Playback Settings")]
		[Tooltip("Start playing music when the scene loads.")]
		[SerializeField]
		private bool playOnStart;

		[Tooltip("Fade in duration when starting music.")]
		[SerializeField]
		private float fadeInDuration;

		[Tooltip("Stop music with fade out when this object is destroyed.")]
		[SerializeField]
		private bool stopOnDestroy;

		[Tooltip("Fade out duration when stopping music.")]
		[SerializeField]
		private float fadeOutDuration;

		[Tooltip("If true, stops any playing music when no track/playlist is assigned. Use this for scenes that should have no music.")]
		[SerializeField]
		private bool stopMusicIfNoneAssigned;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void StartMusic()
		{
		}

		public void StopMusic()
		{
		}

		public void CrossfadeTo(MusicTrack track, float duration = -1f)
		{
		}

		public void CrossfadeTo(MusicPlaylist newPlaylist, float duration = -1f)
		{
		}
	}
}
