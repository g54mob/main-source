using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feel
{
	[AddComponentMenu("")]
	public class PlaylistDemo : MonoBehaviour
	{
		public MMSMPlaylistManager PlaylistManager;

		public MMProgressBar ProgressBar;

		public TMP_Text SongName;

		public TMP_Text SongDuration;

		protected virtual void Update()
		{
			if (PlaylistManager.CurrentClipDuration == 0f)
			{
				ProgressBar.SetBar(0f, 0f, 1f);
				return;
			}
			ProgressBar.SetBar(PlaylistManager.CurrentTime, 0f, PlaylistManager.CurrentClipDuration);
			SongDuration.text = MMTime.FloatToTimeString(PlaylistManager.CurrentTime) + " / " + MMTime.FloatToTimeString(PlaylistManager.CurrentClipDuration);
		}

		protected virtual void UpdateSongName()
		{
			int num = PlaylistManager.CurrentSongIndex + 1;
			SongName.text = num + ". " + PlaylistManager.CurrentSongName;
		}

		protected virtual void OnPlayEvent(int channel)
		{
			UpdateSongName();
		}

		protected virtual void OnEnable()
		{
			MMPlaylistNewSongStartedEvent.Register(OnPlayEvent);
		}

		protected virtual void OnDisable()
		{
			MMPlaylistNewSongStartedEvent.Unregister(OnPlayEvent);
		}
	}
}
