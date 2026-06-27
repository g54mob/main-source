using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Soldering;
using Restory.Infrastructure.ProjectServices;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class SolderingProcessController : IDisposable
	{
		private readonly HashSet<SolderPoint> awaitingSolderingCompletionPoints = new HashSet<SolderPoint>();

		private readonly List<SolderPoint> resolderStateCandidates = new List<SolderPoint>();

		private readonly List<SolderPoint> interferingPoints = new List<SolderPoint>();

		private readonly List<SolderPoint> allPoints = new List<SolderPoint>();

		private readonly ICoroutineRunner coroutineRunner;

		private readonly SolderingProcessSettings settings;

		private readonly float solderingAffectionSquareDistance;

		private Coroutine switchingToSolderingModeCoroutine;

		private int currentSolderingTraceIndex;

		private int currentSolderingTraceCapacity;

		private bool isProcessStarted;

		private bool isProcessFailed;

		public bool CurrentSolderingTraceNotCompleted => awaitingSolderingCompletionPoints.Count > 0;

		public event Action OnTraceDisappeared;

		[Inject]
		public SolderingProcessController(ICoroutineRunner coroutineRunner, SolderingProcessSettings settings)
		{
			this.coroutineRunner = coroutineRunner;
			this.settings = settings;
			solderingAffectionSquareDistance = Mathf.Pow(settings.SolderingAffectionDistance, 2f);
		}

		public void Dispose()
		{
			ClearCoroutines();
		}

		public void Init(ContactLinesHandler contactLinesHandler)
		{
			allPoints.Clear();
			allPoints.AddRange(contactLinesHandler.AllPoints.OrderBy((SolderPoint point) => point.PositionRatioInTrace));
		}

		public void PerformSwitchingToSolderingMode()
		{
			if (switchingToSolderingModeCoroutine != null)
			{
				coroutineRunner.Stop(switchingToSolderingModeCoroutine);
				switchingToSolderingModeCoroutine = null;
			}
			switchingToSolderingModeCoroutine = coroutineRunner.Run(SwitchingToSolderingModeCoroutine());
		}

		public bool IsProcessInterrupted(out bool resolderedNewPoints)
		{
			int count = awaitingSolderingCompletionPoints.Count;
			ProcessRecentlySolderedPoints();
			resolderedNewPoints = awaitingSolderingCompletionPoints.Count > count;
			if (isProcessFailed)
			{
				StopProcess();
				return true;
			}
			if (IsTraceResoldered())
			{
				DisappearTrace();
			}
			return false;
		}

		public void StopProcess()
		{
			ReleaseInterferingPoints();
			if (awaitingSolderingCompletionPoints.Count == 0)
			{
				isProcessFailed = false;
				return;
			}
			foreach (SolderPoint awaitingSolderingCompletionPoint in awaitingSolderingCompletionPoints)
			{
				awaitingSolderingCompletionPoint.SetState(SolderPointState.Burnt);
			}
			Reset();
		}

		public void Clear()
		{
			Reset();
			ClearCoroutines();
			interferingPoints.Clear();
			allPoints.Clear();
		}

		private void StartNewSolderingProcess(SolderPoint initialSolderPoint)
		{
			ReleaseInterferingPoints();
			isProcessStarted = true;
			currentSolderingTraceIndex = initialSolderPoint.TraceIndex;
			foreach (SolderPoint allPoint in allPoints)
			{
				if (allPoint.TraceIndex == currentSolderingTraceIndex)
				{
					currentSolderingTraceCapacity++;
				}
			}
		}

		private void ProcessRecentlySolderedPoints()
		{
			resolderStateCandidates.Clear();
			Vector3 zero = Vector3.zero;
			foreach (SolderPoint allPoint in allPoints)
			{
				if (!allPoint.JustTouchedBySolderer)
				{
					continue;
				}
				allPoint.JustTouchedBySolderer = false;
				if (!isProcessFailed)
				{
					if (!isProcessStarted)
					{
						StartNewSolderingProcess(allPoint);
					}
					if (allPoint.TraceIndex == currentSolderingTraceIndex)
					{
						resolderStateCandidates.Add(allPoint);
						zero += allPoint.transform.position;
					}
					else
					{
						allPoint.ToggleCollider(isEnabled: false);
						interferingPoints.Add(allPoint);
					}
				}
			}
			if (resolderStateCandidates.Count == 0)
			{
				isProcessFailed = true;
				return;
			}
			Vector3 vector = zero / resolderStateCandidates.Count;
			Vector3 vector2 = vector;
			float num = float.MaxValue;
			foreach (SolderPoint resolderStateCandidate in resolderStateCandidates)
			{
				float sqrMagnitude = (resolderStateCandidate.transform.position - vector).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					vector2 = resolderStateCandidate.transform.position;
				}
			}
			foreach (SolderPoint resolderStateCandidate2 in resolderStateCandidates)
			{
				if (resolderStateCandidate2.State == SolderPointState.Burnt && (resolderStateCandidate2.transform.position - vector2).sqrMagnitude < solderingAffectionSquareDistance)
				{
					resolderStateCandidate2.SetState(SolderPointState.Resoldered);
					awaitingSolderingCompletionPoints.Add(resolderStateCandidate2);
				}
			}
		}

		private bool IsTraceResoldered()
		{
			if (awaitingSolderingCompletionPoints.Count == currentSolderingTraceCapacity)
			{
				return true;
			}
			if (awaitingSolderingCompletionPoints.Count > currentSolderingTraceCapacity)
			{
				Debug.LogError("awaitingSolderingCompletionPoints count" + $" {awaitingSolderingCompletionPoints.Count} is grater than" + string.Format(" {0} {1}", "currentSolderingTraceCapacity", currentSolderingTraceCapacity));
			}
			return false;
		}

		private void DisappearTrace()
		{
			if (awaitingSolderingCompletionPoints.Count > 0)
			{
				foreach (SolderPoint awaitingSolderingCompletionPoint in awaitingSolderingCompletionPoints)
				{
					awaitingSolderingCompletionPoint.SetState(SolderPointState.Disappearing);
				}
			}
			ReleaseInterferingPoints();
			Reset();
			this.OnTraceDisappeared?.Invoke();
		}

		private void ReleaseInterferingPoints()
		{
			foreach (SolderPoint interferingPoint in interferingPoints)
			{
				if (interferingPoint.State != SolderPointState.Burnt)
				{
					Debug.LogError(string.Format("Unexpected {0} point in {1} collection", interferingPoint.State, "interferingPoints"));
				}
				interferingPoint.ToggleCollider(isEnabled: true);
			}
			interferingPoints.Clear();
		}

		private void Reset()
		{
			awaitingSolderingCompletionPoints.Clear();
			resolderStateCandidates.Clear();
			currentSolderingTraceIndex = -1;
			currentSolderingTraceCapacity = 0;
			isProcessStarted = false;
			isProcessFailed = false;
		}

		private IEnumerator SwitchingToSolderingModeCoroutine()
		{
			float startTime = Time.time;
			foreach (SolderPoint solderPoint in allPoints)
			{
				if (solderPoint.State != SolderPointState.Cleaned)
				{
					Debug.LogError(string.Format("Unexpected {0} point in {1} collection", solderPoint.State, "allPoints"));
					continue;
				}
				float num = startTime + solderPoint.PositionRatioInTrace * settings.CleanedTracesTransitionDurationInSeconds - Time.time;
				if (num > 0f)
				{
					yield return new WaitForSeconds(num);
				}
				solderPoint.SetState(SolderPointState.Burnt);
				solderPoint.ToggleCollider(isEnabled: true);
			}
			switchingToSolderingModeCoroutine = null;
		}

		private void ClearCoroutines()
		{
			if (switchingToSolderingModeCoroutine == null)
			{
				return;
			}
			coroutineRunner.Stop(switchingToSolderingModeCoroutine);
			switchingToSolderingModeCoroutine = null;
			foreach (SolderPoint allPoint in allPoints)
			{
				if (allPoint.State == SolderPointState.Cleaned)
				{
					allPoint.SetState(SolderPointState.Burnt);
				}
			}
		}
	}
}
