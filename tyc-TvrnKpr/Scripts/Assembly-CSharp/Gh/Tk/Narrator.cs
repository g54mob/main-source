using System;
using System.Collections.Generic;
using Gh.Tk.Story;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	[PersistenceOptIn]
	public class Narrator : MonoBehaviour, IPersistable
	{
		private class TimedAction
		{
			public float TimeLeft;

			public Action Callback;
		}

		public GameObject SubTitleParent;

		public TextMeshProI18n SubTitle;

		public TextMeshProI18n SubTitleBackground;

		[PersistenceOptIn]
		private NarratorData _lastNarratorData;

		[PersistenceOptIn]
		private NarratorData _currentNarratorData;

		[PersistenceOptIn]
		private float _continueInSeconds;

		[PersistenceOptIn]
		private float _minSubtitleShowTime;

		[PersistenceOptIn]
		private bool _voiceOverIsPlaying;

		[PersistenceOptIn]
		private readonly List<NarratorData> _narratorData;

		[PersistenceOptIn]
		private NarratorData _forcedNarratorData;

		private bool _started;

		private const float WordsPerSecondsReadingSpeed = 4.2f;

		private bool _isPaused;

		private readonly List<TimedAction> _timedActions;

		private float _lastStopTime;

		private Vector3 _origPosition;

		[PersistenceOptIn]
		public float SecondsSinceLastAdvisorOrNarratorWasPlaying { get; private set; }

		public bool IsNarratorActive => false;

		public static bool IsNarratorPaused => false;

		public void PlayNarrator(ActiveStory story)
		{
		}

		public void PlayNarrator(string textKey, string voTextKey, bool isAutoSkipped)
		{
		}

		public void ForcePlayNarrator(string textKey, string voTextKey)
		{
		}

		public void PlayAdvisor(string adviceKey, float displaySeconds, string voTextKey, AdvisorState state = AdvisorState.Neutral, int storyId = -1, string eventId = null)
		{
		}

		private void Update()
		{
		}

		private void Play()
		{
		}

		private void PlayCameraVo()
		{
		}

		private void PlayAdvisor()
		{
		}

		private void ExecuteIn(float seconds, Action action)
		{
		}

		private void PlayNarrator()
		{
		}

		private bool ShouldShowSubtitles()
		{
			return false;
		}

		private void SetText(string text)
		{
		}

		private void UnPause()
		{
		}

		private void Pause()
		{
		}

		private void Stop(NarratorData narratorData = null, bool ignoreLastStopTime = true)
		{
		}

		public void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnConfirmDialogIsActiveChanged(object sender, EventArgs<bool> e)
		{
		}

		public void Reset()
		{
		}

		public void StopAdvisor(int cameraEventId)
		{
		}

		public void PlayEventCameraVo(string cameraID)
		{
		}

		public void StopEventCameraVo(string cameraID)
		{
		}
	}
}
