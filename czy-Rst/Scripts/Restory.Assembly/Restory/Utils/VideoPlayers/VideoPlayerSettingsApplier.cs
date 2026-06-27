using Restory.Gameplay.GameSettings;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

namespace Restory.Utils.VideoPlayers
{
	public class VideoPlayerSettingsApplier : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer videoPlayer;

		private GameSettingsManager gameSettingsManager;

		[Inject]
		public void Construct(GameSettingsManager gameSettingsManager)
		{
			this.gameSettingsManager = gameSettingsManager;
		}

		private void Awake()
		{
			videoPlayer.started += ResolveOnVideoPlayerStart;
		}

		private void ResolveOnVideoPlayerStart(VideoPlayer source)
		{
			if (!videoPlayer.canSetDirectAudioVolume)
			{
				Debug.LogError($"IAF Error: [{this}] cannot set volume for the clip played in VideoPlayer. Probably video format of the clip does not support that.", base.gameObject);
				return;
			}
			for (ushort num = 0; num < videoPlayer.audioTrackCount; num++)
			{
				videoPlayer.SetDirectAudioVolume(num, gameSettingsManager.AudioSettings.Master.Volume);
			}
		}
	}
}
