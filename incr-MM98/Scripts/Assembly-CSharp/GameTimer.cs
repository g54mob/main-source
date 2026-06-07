using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[SerializeField]
	private float gameSpeedMultiplier = 1f;

	[SerializeField]
	private float maxStepTime = 0.1f;

	[SerializeField]
	private float autoSaveInterval = 60f;

	private CancellationTokenSource _tickCts;

	private CancellationTokenSource _autosaveCts;

	public float GameSpeedMultiplier
	{
		get
		{
			return gameSpeedMultiplier;
		}
		set
		{
			gameSpeedMultiplier = Mathf.Max(0f, value);
		}
	}

	public void Resume()
	{
		TickAsync(this.GenerateToken(ref _tickCts)).Forget();
		UniTaskUtility.Interval(autoSaveInterval, Database.Save, this.GenerateToken(ref _autosaveCts)).Forget();
	}

	public void Interrupt()
	{
		this.CancelToken(ref _tickCts);
		this.CancelToken(ref _autosaveCts);
	}

	private void OnDestroy()
	{
		this.CancelToken(ref _tickCts);
		this.CancelToken(ref _autosaveCts);
		IncrementalSimulation.ClearSystems();
		Database.Dispose();
	}

	private async UniTask TickAsync(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			await UniTask.Yield(PlayerLoopTiming.Update, token, cancelImmediately: true);
			token.ThrowIfCancellationRequested();
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			if (unscaledDeltaTime <= 0f)
			{
				continue;
			}
			float num = unscaledDeltaTime * gameSpeedMultiplier;
			while (num > 0f)
			{
				float num2 = Mathf.Min(num, maxStepTime);
				try
				{
					IncrementalSimulation.AdvanceTime(Database.State.Studio.Paused.Value ? 0f : num2);
				}
				catch (OperationCanceledException)
				{
				}
				catch (Exception innerException)
				{
					ApplicationController.SimulationException(new SimulationException("An exception occurred in the the Incremental Simulation flow.", innerException));
					Interrupt();
					return;
				}
				num -= num2;
			}
		}
	}
}
