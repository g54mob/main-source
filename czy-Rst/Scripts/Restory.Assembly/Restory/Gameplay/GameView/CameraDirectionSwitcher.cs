using System;
using System.Collections.Generic;
using DG.Tweening;
using Restory.Gameplay.Common;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.UserInterface;
using Restory.Gameplay.Work.StateMachine;
using Restory.UI.Presenters;
using Restory.UI.Presenters.Inventory;
using Restory.UI.Presenters.Notepad;
using Restory.UI.Presenters.RegularPayment;
using Restory.Utils;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameView
{
	public class CameraDirectionSwitcher : MonoBehaviour, IInitializable, IDisposable
	{
		[Space]
		[Header("Camera Settings")]
		[SerializeField]
		private CinemachineCamera virtualCamera;

		[SerializeField]
		private Transform lookAtTarget;

		[Space]
		[Header("View Points")]
		[SerializeField]
		private Transform mainViewPoint;

		[SerializeField]
		private Transform leftViewPoint;

		[SerializeField]
		private Transform rightViewPoint;

		[SerializeField]
		private Transform disassembleViewPoint;

		[SerializeField]
		private Transform bottomViewPoint;

		[Space]
		[Header("Direction Settings")]
		[SerializeField]
		[Range(0.01f, 0.99f)]
		private float sideTriggerRange = 0.01f;

		[SerializeField]
		[Range(0.01f, 0.99f)]
		private float sideToCenterTriggerRange = 0.25f;

		[SerializeField]
		[Range(0.01f, 0.99f)]
		private float bottomTriggerRange = 0.01f;

		[SerializeField]
		[Range(0.01f, 0.99f)]
		private float bottomToMainTriggerRange = 0.8f;

		[SerializeField]
		[Range(0.01f, 0.99f)]
		private float bottomToDisassembleTriggerRange = 0.6f;

		[SerializeField]
		[Range(0f, 2f)]
		private float sideToCenterDuration = 1f;

		[SerializeField]
		[Range(0f, 2f)]
		private float sideToBottomDuration = 1f;

		[SerializeField]
		[Range(0f, 2f)]
		private float bottomToMainDuration = 0.7f;

		[SerializeField]
		[Range(0f, 2f)]
		private float bottomToDisassembleDuration = 0.5f;

		[SerializeField]
		[Range(0f, 2f)]
		private float cooldownDuration;

		[SerializeField]
		private Ease sideDirectionEase = Ease.InOutSine;

		[SerializeField]
		private Ease bottomDirectionEase = Ease.OutQuad;

		private IPlayerInput playerInput;

		private ScreenSizeCacheService screenSize;

		private TweenSequencesService tweenSequences;

		private ActiveStateSwitcher mainActiveStateSwitcher;

		private List<Type> mainDirectionTriggerTypes;

		private CameraDirection currentDirection;

		private CameraDirection lastDirection;

		private Sequence transitionSequence;

		public CameraDirection CurrentDirection => currentDirection;

		public event Action OnCameraDirectionChanged;

		[Inject]
		private void Construct(IPlayerInput playerInput, ScreenSizeCacheService screenSize, TweenSequencesService tweenSequences)
		{
			this.playerInput = playerInput;
			this.screenSize = screenSize;
			this.tweenSequences = tweenSequences;
			InitActiveStateSwitchers();
			currentDirection = CameraDirection.Main;
			lastDirection = CameraDirection.Main;
		}

		public void Initialize()
		{
			UpdateLookAtTargetParent();
			lookAtTarget.localPosition = Vector3.zero;
		}

		public void Dispose()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
		}

		private void InitActiveStateSwitchers()
		{
			mainActiveStateSwitcher = new ActiveStateSwitcher(ActiveStateSwitcher.WorkMode.ActiveByDefaultAndRequestersMakeItInactive);
			mainDirectionTriggerTypes = new List<Type>
			{
				typeof(DialogueWorkState),
				typeof(GUI_RegularPayment)
			};
		}

		public void OnUpdate()
		{
			CheckCameraDirectionTriggers();
		}

		public void AddBlocker(IActiveStateSwitchRequester blocker)
		{
			mainActiveStateSwitcher.AddRequester(blocker);
			TrackCameraDirectionBlockingIssue();
			if (currentDirection != CameraDirection.Main && mainDirectionTriggerTypes.Contains(blocker.GetType()))
			{
				ApplyCameraDirection(CameraDirection.Main, sideDirectionEase, sideToCenterDuration);
			}
		}

		public void RemoveBlocker(IActiveStateSwitchRequester blocker)
		{
			mainActiveStateSwitcher.RemoveRequester(blocker);
			TrackCameraDirectionBlockingIssue();
		}

		public void ApplyCameraDirection(CameraDirection targetDirection, Ease ease, float duration)
		{
			lastDirection = currentDirection;
			currentDirection = targetDirection;
			UpdateLookAtTargetParent();
			this.OnCameraDirectionChanged?.Invoke();
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(lookAtTarget.DOLocalMove(Vector3.zero, duration).SetEase(ease)).AppendInterval(cooldownDuration);
		}

		private void UpdateLookAtTargetParent()
		{
			Transform parent = currentDirection switch
			{
				CameraDirection.Main => mainViewPoint, 
				CameraDirection.Disassemble => disassembleViewPoint, 
				CameraDirection.Left => leftViewPoint, 
				CameraDirection.Right => rightViewPoint, 
				_ => throw new ArgumentOutOfRangeException("currentDirection", currentDirection, null), 
			};
			lookAtTarget.SetParent(parent);
		}

		private void CheckCameraDirectionTriggers()
		{
			switch (currentDirection)
			{
			case CameraDirection.Main:
				CheckMainDirection();
				break;
			case CameraDirection.Left:
				CheckLeftDirection();
				break;
			case CameraDirection.Right:
				CheckRightDirection();
				break;
			default:
				throw new ArgumentOutOfRangeException("currentDirection", currentDirection, null);
			case CameraDirection.Disassemble:
				break;
			}
		}

		private void CheckMainDirection()
		{
			if (!mainActiveStateSwitcher.ShouldSystemBeActive)
			{
				return;
			}
			Vector2 mousePosition = playerInput.GetMousePosition();
			if (mousePosition.x < (float)screenSize.ScreenWidth * sideTriggerRange)
			{
				if (lastDirection != CameraDirection.Right || !IsTransitionInProgress())
				{
					ApplyCameraDirection(CameraDirection.Left, sideDirectionEase, sideToCenterDuration);
				}
			}
			else if (mousePosition.x > (float)screenSize.ScreenWidth * (1f - sideTriggerRange) && (lastDirection != CameraDirection.Left || !IsTransitionInProgress()))
			{
				ApplyCameraDirection(CameraDirection.Right, sideDirectionEase, sideToCenterDuration);
			}
		}

		private void CheckLeftDirection()
		{
			if (mainActiveStateSwitcher.ShouldSystemBeActive && playerInput.GetMousePosition().x > (float)screenSize.ScreenWidth * (1f - sideToCenterTriggerRange))
			{
				ApplyCameraDirection(CameraDirection.Main, sideDirectionEase, sideToCenterDuration);
			}
		}

		private void CheckRightDirection()
		{
			if (mainActiveStateSwitcher.ShouldSystemBeActive && playerInput.GetMousePosition().x < (float)screenSize.ScreenWidth * sideToCenterTriggerRange)
			{
				ApplyCameraDirection(CameraDirection.Main, sideDirectionEase, sideToCenterDuration);
			}
		}

		private bool IsTransitionInProgress()
		{
			if (transitionSequence != null)
			{
				return transitionSequence.IsPlaying();
			}
			return false;
		}

		private void TrackCameraDirectionBlockingIssue()
		{
			foreach (IActiveStateSwitchRequester requester in mainActiveStateSwitcher.Requesters)
			{
				if (requester is DialogueWorkState)
				{
					continue;
				}
				if (!(requester is GUI_GameDialogueCanvas gUI_GameDialogueCanvas))
				{
					if (!(requester is GUI_PcWindowsXpScreen gUI_PcWindowsXpScreen))
					{
						if (!(requester is InventoryPanel inventoryPanel))
						{
							if (!(requester is GUI_NotepadWindow gUI_NotepadWindow))
							{
								if (requester is GUI_RegularPayment gUI_RegularPayment)
								{
									if (!gUI_RegularPayment.IsVisible)
									{
										Debug.LogException(new Exception("Inactive GUI_RegularPayment still blocks CameraDirectionSwitcher"));
									}
								}
								else
								{
									Debug.LogException(new Exception($"Unexpected blocker {requester.GetType()}" + " in CameraDirectionSwitcher"));
								}
							}
							else if (!gUI_NotepadWindow.IsVisible)
							{
								Debug.LogException(new Exception("Inactive GUI_NotepadWindow still blocks CameraDirectionSwitcher." + $" Notepad is rolled out: {gUI_NotepadWindow.IsRolledOut}." + $" Last camera direction: {lastDirection}." + $" Current camera direction: {currentDirection}."));
							}
						}
						else if (!inventoryPanel.IsVisible)
						{
							Debug.LogException(new Exception("Inactive InventoryPanel still blocks CameraDirectionSwitcher"));
						}
					}
					else if (!gUI_PcWindowsXpScreen.IsVisible)
					{
						Debug.LogException(new Exception("Inactive GUI_PcWindowsXpScreen still blocks CameraDirectionSwitcher"));
					}
				}
				else if (!gUI_GameDialogueCanvas.isActiveAndEnabled)
				{
					Debug.LogException(new Exception("Inactive GUI_GameDialogueCanvas still blocks CameraDirectionSwitcher"));
				}
			}
		}
	}
}
