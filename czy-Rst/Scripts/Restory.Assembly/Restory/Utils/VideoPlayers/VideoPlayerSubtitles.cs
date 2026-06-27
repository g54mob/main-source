using System;
using System.Collections;
using System.Collections.Generic;
using Restory.UserInterface;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Restory.Utils.VideoPlayers
{
	public class VideoPlayerSubtitles : MonoBehaviour
	{
		[Serializable]
		public struct Subtitle
		{
			[SerializeField]
			private string locTextId;

			[SerializeField]
			private double time;

			[SerializeField]
			private double duration;

			public string LocTextId => locTextId;

			public double StartTime => time;

			public double Duration => duration;

			public double EndTime => time + duration;

			public Subtitle(string locTextId, double time, double duration)
			{
				this.locTextId = locTextId;
				this.time = time;
				this.duration = duration;
			}
		}

		[SerializeField]
		protected VideoPlayer videoPlayer;

		[SerializeField]
		protected Graphic graphic;

		[SerializeField]
		protected GUI_LocalisedText text;

		[SerializeField]
		protected float durationFadeOut = 0.5f;

		[SerializeField]
		protected List<Subtitle> subtitles = new List<Subtitle>();

		protected Coroutine update;

		protected virtual void Awake()
		{
			videoPlayer.started += OnStarted;
			videoPlayer.loopPointReached += OnEndReached;
			graphic.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
			if (videoPlayer.isPlaying)
			{
				StartUpdateSubtitles();
			}
		}

		protected virtual void StartUpdateSubtitles()
		{
			if (update == null)
			{
				update = StartCoroutine(UpdateSubtitles());
			}
		}

		protected virtual void StopUpdateSubtitles()
		{
			if (update != null)
			{
				StopCoroutine(update);
				graphic.CrossFadeAlpha(0f, durationFadeOut, ignoreTimeScale: false);
			}
		}

		protected virtual IEnumerator UpdateSubtitles()
		{
			while (videoPlayer.isPlaying)
			{
				if (TryGetCurrentSubtitle(videoPlayer.time, out var subtitle))
				{
					text.LocalizationID = subtitle.LocTextId;
					graphic.CrossFadeAlpha(1f, durationFadeOut, ignoreTimeScale: false);
					yield return new WaitWhile(() => videoPlayer.time <= subtitle.EndTime);
				}
				else
				{
					graphic.CrossFadeAlpha(0f, durationFadeOut, ignoreTimeScale: false);
				}
				yield return null;
			}
			graphic.CrossFadeAlpha(0f, durationFadeOut, ignoreTimeScale: false);
			update = null;
		}

		protected bool TryGetCurrentSubtitle(double time, out Subtitle outSubtitle)
		{
			foreach (Subtitle subtitle in subtitles)
			{
				if (time >= subtitle.StartTime && time <= subtitle.EndTime)
				{
					outSubtitle = subtitle;
					return true;
				}
			}
			outSubtitle = default(Subtitle);
			return false;
		}

		private void OnStarted(VideoPlayer source)
		{
			StartUpdateSubtitles();
		}

		private void OnEndReached(VideoPlayer source)
		{
			StopUpdateSubtitles();
		}
	}
}
