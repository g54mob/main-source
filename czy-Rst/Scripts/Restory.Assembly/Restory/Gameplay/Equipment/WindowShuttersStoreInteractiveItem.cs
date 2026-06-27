using System;
using DG.Tweening;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Common;
using Restory.Gameplay.Equipment.Levers;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class WindowShuttersStoreInteractiveItem : MonoBehaviour, IActiveStateSwitchRequester, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private VerticalLever lever;

		[SerializeField]
		private Transform objectToAnimate;

		[SerializeField]
		private float closedShuttersXRotationValue;

		[SerializeField]
		private float openShuttersXRotationValue = 85.5f;

		[SerializeField]
		private float animationDuration = 3f;

		[SerializeField]
		private Ease animationEase = Ease.Linear;

		private TweenSequencesService tweenSequencesService;

		private bool isWindowOpen;

		private float windowOpenProgress;

		private bool wasWindowOpenAtLeastOnce;

		private Sequence sequence;

		public bool IsWindowOpen
		{
			get
			{
				return isWindowOpen;
			}
			private set
			{
				if (value != isWindowOpen)
				{
					isWindowOpen = value;
					if (!wasWindowOpenAtLeastOnce && value)
					{
						wasWindowOpenAtLeastOnce = true;
					}
					this.OnIsOpenStatusChanged?.Invoke();
				}
			}
		}

		public bool WasWindowOpenAtLeastOnce => wasWindowOpenAtLeastOnce;

		public float WindowOpenProgress
		{
			get
			{
				return windowOpenProgress;
			}
			private set
			{
				if (value != windowOpenProgress)
				{
					windowOpenProgress = value;
					this.OnWindowOpenProgressChanged?.Invoke();
				}
			}
		}

		public event Action OnIsOpenStatusChanged;

		public event Action OnWindowOpenProgressChanged;

		public event Action OnOpeningAnimationStarted;

		public event Action OnOpeningAnimationEnded;

		public event Action OnClosingAnimationStarted;

		public event Action OnClosingAnimationEnded;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void OnEnable()
		{
			lever.OnPositionChanged += ResolveLeverPositionChanged;
		}

		private void OnDisable()
		{
			if (lever.MonoShellExists())
			{
				lever.OnPositionChanged -= ResolveLeverPositionChanged;
			}
		}

		public void BlockWindow(IActiveStateSwitchRequester blockingSource)
		{
			lever.BlockLever(blockingSource);
		}

		public void UnblockWindow(IActiveStateSwitchRequester blockingSource)
		{
			lever.UnblockLever(blockingSource);
		}

		public void SetInitialState(bool shouldBeOpen)
		{
			Vector3 eulerAngles = objectToAnimate.rotation.eulerAngles;
			Vector3 euler = new Vector3(shouldBeOpen ? openShuttersXRotationValue : closedShuttersXRotationValue, eulerAngles.y, eulerAngles.z);
			objectToAnimate.rotation = Quaternion.Euler(euler);
			isWindowOpen = shouldBeOpen;
			windowOpenProgress = (shouldBeOpen ? 1f : 0f);
			if (!wasWindowOpenAtLeastOnce && shouldBeOpen)
			{
				wasWindowOpenAtLeastOnce = true;
			}
			lever.SetInitialState(isWindowOpen, wasWindowOpenAtLeastOnce);
			this.OnIsOpenStatusChanged?.Invoke();
			this.OnWindowOpenProgressChanged?.Invoke();
		}

		private void ResolveLeverPositionChanged()
		{
			if ((lever.CurrentPosition != LeverPositions.Bottom || !isWindowOpen) && (lever.CurrentPosition != LeverPositions.Top || isWindowOpen))
			{
				SwitchState();
			}
		}

		private void SwitchState()
		{
			StartAnimation();
		}

		private void StartAnimation()
		{
			if (sequence.IsActive())
			{
				return;
			}
			lever.BlockLever(this);
			bool flag = !IsWindowOpen;
			sequence = tweenSequencesService.Create();
			Vector3 eulerAngles = objectToAnimate.rotation.eulerAngles;
			Vector3 endValue = new Vector3(flag ? openShuttersXRotationValue : closedShuttersXRotationValue, eulerAngles.y, eulerAngles.z);
			sequence.Append(objectToAnimate.DORotate(endValue, animationDuration).SetEase(animationEase)).Join(DOTween.To(() => WindowOpenProgress, delegate(float value)
			{
				WindowOpenProgress = value;
			}, flag ? 1f : 0f, animationDuration).SetEase(animationEase)).OnKill(delegate
			{
				lever.UnblockLever(this);
			});
			if (flag)
			{
				sequence.OnStart(delegate
				{
					this.OnOpeningAnimationStarted?.Invoke();
				});
				sequence.OnComplete(delegate
				{
					IsWindowOpen = true;
				});
				Sequence obj = sequence;
				obj.onKill = (TweenCallback)Delegate.Combine(obj.onKill, (TweenCallback)delegate
				{
					this.OnOpeningAnimationEnded?.Invoke();
				});
			}
			else
			{
				sequence.OnStart(delegate
				{
					IsWindowOpen = false;
					this.OnClosingAnimationStarted?.Invoke();
				});
				Sequence obj2 = sequence;
				obj2.onKill = (TweenCallback)Delegate.Combine(obj2.onKill, (TweenCallback)delegate
				{
					this.OnClosingAnimationEnded?.Invoke();
				});
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				WindowShuttersSaveData windowShuttersSaveData = DataMigrationWizard.Migrate<WindowShuttersSaveData>(state, base.gameObject);
				isWindowOpen = windowShuttersSaveData.IsOpen;
				wasWindowOpenAtLeastOnce = windowShuttersSaveData.WasOpenAtLeastOnce;
				SetInitialState(isWindowOpen);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new WindowShuttersSaveData
				{
					IsOpen = isWindowOpen,
					WasOpenAtLeastOnce = wasWindowOpenAtLeastOnce
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
