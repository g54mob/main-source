using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace DV.Radio
{
	public class FilePlayer : BasePlayer
	{
		private string filePath;

		private long lastPosition;

		private AudioClip clip;

		private bool hasFocus;

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			this.hasFocus = hasFocus;
		}

		public void SetFile(string filePath, long samplePosition = 0L)
		{
			this.filePath = filePath;
			lastPosition = samplePosition;
		}

		public override void Play()
		{
			if (!IsStopped)
			{
				ErrorInfo_Fire("FilePlayer is already playing");
			}
			else
			{
				StartCoroutine(PlayFile(filePath, lastPosition));
			}
		}

		private void Stop(bool resetSeek)
		{
			IsStopped = true;
			if (resetSeek)
			{
				lastPosition = 0L;
			}
			if (audioSource != null && audioSource.clip == clip && clip != null)
			{
				audioSource.Stop();
				audioSource.clip = null;
			}
			if (clip != null)
			{
				UnityEngine.Object.Destroy(clip);
				clip = null;
			}
		}

		public override void Stop()
		{
			Stop(resetSeek: true);
		}

		public override bool Pause()
		{
			if (IsStopped)
			{
				return false;
			}
			Stop(resetSeek: false);
			return true;
		}

		public override long GetSeekPosition()
		{
			if ((bool)audioSource && (bool)clip)
			{
				lastPosition = audioSource.timeSamples;
			}
			return lastPosition;
		}

		public override void SetSeekPosition(long position)
		{
			lastPosition = position;
		}

		private static AudioType GetAudioTypeForFile(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return AudioType.UNKNOWN;
			}
			string extension = Path.GetExtension(path.ToLower());
			switch (extension)
			{
			case ".mp3":
				return AudioType.MPEG;
			case ".ogg":
				return AudioType.OGGVORBIS;
			case ".wav":
				return AudioType.WAV;
			default:
				throw new NotImplementedException("Support for '" + extension + "' files is not implemented yet.");
			}
		}

		protected virtual IEnumerator PlayFile(string path, long seekTo)
		{
			AudioType audioTypeForFile = GetAudioTypeForFile(path);
			using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(path, audioTypeForFile))
			{
				((DownloadHandlerAudioClip)req.downloadHandler).streamAudio = true;
				yield return req.SendWebRequest();
				if (req.isHttpError || req.isNetworkError)
				{
					ErrorInfo_Fire(req.error);
					Stop();
					yield break;
				}
				clip = DownloadHandlerAudioClip.GetContent(req);
			}
			while (clip.loadState != AudioDataLoadState.Loaded)
			{
				Debug.Log($"Clip not loaded yet, state is: {clip.loadState}");
				yield return null;
			}
			audioSource.clip = clip;
			audioSource.timeSamples = (int)seekTo;
			audioSource.Play();
			IsStopped = false;
			PlaybackStarted_Fire();
			SongInfoChanged_Fire(Path.GetFileNameWithoutExtension(path));
			while ((!IsStopped && (bool)audioSource && audioSource.isPlaying) || (StopOnFocusLost && !hasFocus))
			{
				if (StopOnFocusLost && !hasFocus)
				{
					yield return null;
					continue;
				}
				if (audioSource.timeSamples < seekTo && !audioSource.loop)
				{
					audioSource.timeSamples = (int)seekTo;
				}
				lastPosition = audioSource.timeSamples;
				yield return null;
			}
			Stop(resetSeek: false);
			PlaybackStopped_Fire();
		}

		private void LogDataError(Exception ex)
		{
			lastPosition = 0L;
			string info = "Could not read audio data";
			ErrorInfo_Fire(info);
		}
	}
}
