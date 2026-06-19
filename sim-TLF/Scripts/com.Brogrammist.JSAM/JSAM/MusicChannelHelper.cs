using System.Collections;
using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(AudioSource))]
	public class MusicChannelHelper : BaseAudioChannelHelper<MusicFileObject>
	{
		protected override VolumeChannel DefaultChannel => VolumeChannel.Music;

		protected override void OnDisable()
		{
			base.OnDisable();
			if ((bool)audioFile && audioFile.maxPlayingInstances != 0)
			{
				AudioManager.InternalInstance.RemovePlayingMusic(audioFile, this);
			}
		}

		public override void Stop(bool stopInstantly = true)
		{
			base.Stop(stopInstantly);
			if (stopInstantly)
			{
				base.AudioSource.Stop();
			}
		}

		protected override IEnumerator FadeOut(float fadeTime)
		{
			if (fadeTime != 0f)
			{
				float startingVolume = base.AudioSource.volume;
				float timer = 0f;
				while (timer < fadeTime)
				{
					timer = ((!audioFile.ignoreTimeScale) ? (timer + Time.deltaTime) : (timer + Time.unscaledDeltaTime));
					base.AudioSource.volume = Mathf.Lerp(startingVolume, 0f, timer / fadeTime);
					yield return null;
				}
				base.AudioSource.Stop();
			}
		}
	}
}
