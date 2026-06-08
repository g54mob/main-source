using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	private sealed class _003CUpdateScoreToCurrent_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScoreUI _003C_003E4__this;

		public float duration;

		public int startScore;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CUpdateScoreToCurrent_003Ed__18(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			ScoreUI scoreUI = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (scoreUI.counting)
				{
					return false;
				}
				_003Ctimer_003E5__2 = 0f;
				scoreUI.counting = true;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Ctimer_003E5__2 < duration)
			{
				float time = _003Ctimer_003E5__2 / duration;
				scoreUI.SetScoreLabelText(Mathf.RoundToInt(Mathf.Lerp(startScore, scoreUI.rewardSystem.Score, scoreUI.scoreCountingCurve.Evaluate(time))).ToString());
				_003Ctimer_003E5__2 += Time.deltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			scoreUI.counting = false;
			scoreUI.UpdateScoreInstantly();
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TextMeshProUGUI scoreLabel;

	private float originalFontSize;

	[SerializeField]
	private float wobbleMultiplier = 0.3f;

	[SerializeField]
	private float wobbleDuration = 0.1f;

	[SerializeField]
	private float scoreSpeed = 1f;

	[SerializeField]
	private AnimationCurve scoreCountingCurve;

	[SerializeField]
	private bool showProgressIndicators;

	[SerializeField]
	private List<GameObject> progressMarkers;

	[SerializeField]
	private List<int> scoreLevels = new List<int> { 50000, 100000, 250000, 500000 };

	private bool counting;

	private int currentScore;

	private Coroutine updateScoreCoroutine;

	private void Awake()
	{
		originalFontSize = scoreLabel.fontSize;
	}

	private void Start()
	{
		UpdateScoreInstantly();
		OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup += UpdateScoreInstantly;
	}

	private void OnEnable()
	{
		rewardSystem.OnScoreChanged += UpdateScore;
		UpdateScoreInstantly();
	}

	private void UpdateScoreInstantly()
	{
		SetScoreLabelText(rewardSystem.Score.ToString());
		currentScore = rewardSystem.Score;
	}

	private void UpdateScore(int addedScore)
	{
		float duration = wobbleDuration * 3f;
		if (base.gameObject.activeInHierarchy)
		{
			StartCoroutine(UpdateScoreToCurrent(currentScore, duration));
		}
		else
		{
			SetScoreLabelText(rewardSystem.Score.ToString());
			currentScore = rewardSystem.Score;
		}
		if (showProgressIndicators)
		{
			for (int i = 0; i < scoreLevels.Count; i++)
			{
				progressMarkers[i].SetActive(rewardSystem.Score >= scoreLevels[i]);
			}
		}
	}

	private IEnumerator UpdateScoreToCurrent(int startScore, float duration)
	{
		return new _003CUpdateScoreToCurrent_003Ed__18(0)
		{
			_003C_003E4__this = this,
			startScore = startScore,
			duration = duration
		};
	}

	private void SetScoreLabelText(string newText)
	{
		scoreLabel.text = newText + (OverwritingSingleton<GameSession>.Instance ? OverwritingSingleton<GameSession>.Instance.GameMode.gameModeIconRichTextSuffix : "");
	}

	private void OnDisable()
	{
		rewardSystem.OnScoreChanged -= UpdateScore;
		counting = false;
		UpdateScoreInstantly();
	}

	private void OnDestroy()
	{
		if ((bool)OverwritingSingleton<GameSession>.Instance)
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= UpdateScoreInstantly;
		}
	}
}
