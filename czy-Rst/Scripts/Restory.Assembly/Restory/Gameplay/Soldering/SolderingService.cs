using System;
using System.Collections.Generic;
using Restory.Gameplay.Effects;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class SolderingService : IDisposable
	{
		private readonly SolderingProcessController solderingProcessController;

		private readonly SolderingVfxController solderingVfxController;

		private readonly VfxService vfxService;

		private readonly HashSet<SolderPoint> cleanedPoints = new HashSet<SolderPoint>();

		private ContactLinesHandler contactLinesHandler;

		private Coroutine switchingToSolderingModeCoroutine;

		private bool inSolderingMode;

		public bool IsActive => contactLinesHandler;

		public bool InSolderingMode => inSolderingMode;

		public event Action OnTraceSuccessfullyResoldered;

		[Inject]
		public SolderingService(SolderingProcessController solderingProcessController, SolderingVfxController solderingVfxController, VfxService vfxService)
		{
			this.solderingProcessController = solderingProcessController;
			this.solderingVfxController = solderingVfxController;
			this.vfxService = vfxService;
		}

		public void Init(ContactLinesHandler contactLinesHandler, bool isElementCleaned)
		{
			if (!contactLinesHandler)
			{
				Debug.LogError("contactLinesHandler is null on SolderingService initialization");
				return;
			}
			solderingProcessController.Init(contactLinesHandler);
			this.contactLinesHandler = contactLinesHandler;
			if (GetSolderPointsCountWithState(SolderPointState.Sooty) > 0)
			{
				EnterToCleaningMode();
			}
			else if (isElementCleaned)
			{
				EnterToSolderingMode();
			}
		}

		public void Dispose()
		{
			if (solderingProcessController != null)
			{
				solderingProcessController.OnTraceDisappeared -= ResolveTraceDisappeared;
			}
		}

		public SolderingProgressInPercentage GetCurrentProgress()
		{
			if (!IsActive)
			{
				return SolderingProgressInPercentage.FullProgress;
			}
			int num = contactLinesHandler.InitialPointsCount;
			int num2 = contactLinesHandler.InitialPointsCount;
			foreach (SolderPoint allPoint in contactLinesHandler.AllPoints)
			{
				switch (allPoint.State)
				{
				case SolderPointState.Sooty:
					num--;
					num2--;
					break;
				case SolderPointState.Cleaned:
				case SolderPointState.Burnt:
					num2--;
					break;
				}
			}
			return new SolderingProgressInPercentage
			{
				Soot = (float)num / (float)contactLinesHandler.InitialPointsCount,
				Burnt = (float)num2 / (float)contactLinesHandler.InitialPointsCount,
				UnconfirmedProgress = solderingProcessController.CurrentSolderingTraceNotCompleted
			};
		}

		public void UpdateCleaningProcess()
		{
			if (IsActive && inSolderingMode)
			{
				PlayVfxOnRecentlyChangedPoints(cleanedPoints, SolderPointState.Cleaned, vfxService.PlaySootCleaningEffect);
			}
		}

		public void SwitchFromCleaningToSolderingMode()
		{
			if (!IsActive)
			{
				Debug.LogError("Failed to switch to soldering mode, contactLinesHandler is lost");
				return;
			}
			if (inSolderingMode)
			{
				Debug.LogError("Failed to switch to soldering mode, it is active already");
				return;
			}
			inSolderingMode = true;
			solderingProcessController.PerformSwitchingToSolderingMode();
			solderingVfxController.Activate();
		}

		public void UpdateSolderingProcess()
		{
			if (inSolderingMode)
			{
				if (solderingProcessController.IsProcessInterrupted(out var resolderedNewPoints))
				{
					solderingVfxController.Stop();
				}
				else if (resolderedNewPoints)
				{
					solderingVfxController.Play();
				}
			}
		}

		public void StopSolderingProcess()
		{
			if (inSolderingMode)
			{
				solderingProcessController.StopProcess();
				solderingVfxController.Stop();
			}
		}

		public void ForceCompleteSoldering()
		{
			if (!IsActive)
			{
				return;
			}
			solderingProcessController.Clear();
			foreach (SolderPoint allPoint in contactLinesHandler.AllPoints)
			{
				allPoint.SetState(SolderPointState.None);
			}
			Clear();
		}

		public void Clear()
		{
			if (IsActive)
			{
				CaptureCurrentProgress();
				solderingVfxController.Deactivate();
				solderingProcessController.Clear();
				cleanedPoints.Clear();
				contactLinesHandler = null;
				inSolderingMode = false;
				solderingProcessController.OnTraceDisappeared -= ResolveTraceDisappeared;
			}
		}

		private void EnterToCleaningMode()
		{
			cleanedPoints.Clear();
			foreach (SolderPoint allPoint in contactLinesHandler.AllPoints)
			{
				switch (allPoint.State)
				{
				case SolderPointState.Sooty:
					allPoint.ToggleCollider(isEnabled: true);
					break;
				case SolderPointState.Cleaned:
					cleanedPoints.Add(allPoint);
					break;
				}
			}
		}

		private void EnterToSolderingMode()
		{
			bool flag = false;
			bool flag2 = false;
			foreach (SolderPoint allPoint in contactLinesHandler.AllPoints)
			{
				switch (allPoint.State)
				{
				case SolderPointState.Sooty:
					flag = true;
					break;
				case SolderPointState.Cleaned:
					allPoint.SetState(SolderPointState.Burnt);
					allPoint.ToggleCollider(isEnabled: true);
					flag2 = true;
					break;
				case SolderPointState.Burnt:
					allPoint.ToggleCollider(isEnabled: true);
					flag2 = true;
					break;
				}
			}
			if (flag)
			{
				Debug.LogError(string.Format("{0} contains unexpected {1} points", "contactLinesHandler", SolderPointState.Sooty));
				return;
			}
			if (!flag2)
			{
				Debug.LogError(string.Format("{0} not contains {1} points to solder", "contactLinesHandler", SolderPointState.Burnt));
				return;
			}
			inSolderingMode = true;
			solderingVfxController.Activate();
			solderingProcessController.OnTraceDisappeared += ResolveTraceDisappeared;
		}

		private void CaptureCurrentProgress()
		{
			foreach (SolderPoint allPoint in contactLinesHandler.AllPoints)
			{
				allPoint.ToggleCollider(isEnabled: false);
			}
			contactLinesHandler.CaptureSolderPoints();
		}

		private int GetSolderPointsCountWithState(SolderPointState state)
		{
			int num = 0;
			foreach (SolderPoint allPoint in contactLinesHandler.AllPoints)
			{
				if (allPoint.State == state)
				{
					num++;
				}
			}
			return num;
		}

		private void PlayVfxOnRecentlyChangedPoints(HashSet<SolderPoint> changedPoints, SolderPointState targetState, Action<Transform> playVfxAction)
		{
			List<int> value;
			using (CollectionPool<List<int>, int>.Get(out value))
			{
				for (int i = 0; i < contactLinesHandler.AllPoints.Count; i++)
				{
					SolderPoint solderPoint = contactLinesHandler.AllPoints[i];
					if (solderPoint.State == targetState && changedPoints.Add(solderPoint))
					{
						value.Add(i);
					}
				}
				if (value.Count != 0)
				{
					int num = value[value.Count / 2];
					SolderPoint solderPoint2 = contactLinesHandler.AllPoints[num];
					if (!solderPoint2)
					{
						Debug.LogError($"Failed to get central {targetState} point by index {num}," + " it is null");
					}
					else
					{
						playVfxAction(solderPoint2.transform);
					}
				}
			}
		}

		private void ResolveTraceDisappeared()
		{
			this.OnTraceSuccessfullyResoldered?.Invoke();
		}
	}
}
