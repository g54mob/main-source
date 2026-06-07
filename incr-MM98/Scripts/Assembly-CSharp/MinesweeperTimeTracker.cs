using System;
using Cysharp.Text;
using MessagePipe;
using TMPro;
using UnityEngine;

public class MinesweeperTimeTracker : MonoBehaviour
{
	[SerializeField]
	private TMP_Text timerText;

	private float _time;

	private bool _isPlaying;

	private IDisposable _disposable;

	private const float MaxTime = 999f;

	private void Awake()
	{
		EventHub.Scene.For().Subscribe(delegate
		{
			MinesweeperFinished();
		}, Array.Empty<MessageHandlerFilter<MinesweeperFinished>>()).Subscribe(delegate
		{
			MinesweeperStarted();
		}, Array.Empty<MessageHandlerFilter<MinesweeperTimerStarted>>())
			.Build(out _disposable);
	}

	private void Update()
	{
		if (_isPlaying)
		{
			_time = Mathf.Min(_time + Time.deltaTime, 999f);
			timerText.SetTextFormat("{0:000}", _time);
		}
	}

	private void OnDestroy()
	{
		_disposable?.Dispose();
	}

	private void MinesweeperFinished()
	{
		_isPlaying = false;
	}

	private void MinesweeperStarted()
	{
		_time = 0f;
		_isPlaying = true;
	}
}
