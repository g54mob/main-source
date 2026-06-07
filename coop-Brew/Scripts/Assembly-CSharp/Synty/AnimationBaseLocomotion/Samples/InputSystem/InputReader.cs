using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Synty.AnimationBaseLocomotion.Samples.InputSystem
{
	public class InputReader : MonoBehaviour, MyControls.IPlayerActions
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInputValidation_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InputReader _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayedInputValidation_003Ed__60(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}
		}

		public Vector2 _mouseDelta;

		public Vector2 _moveComposite;

		public float _movementInputDuration;

		public bool _movementInputDetected;

		private int _suppressMouseFrames;

		private bool _appHasFocus;

		private MyControls _controls;

		public Action onAimActivated;

		public Action onAimDeactivated;

		public Action onCrouchActivated;

		public Action onCrouchDeactivated;

		public Action onJumpPerformed;

		public Action onLockOnToggled;

		public Action onSprintActivated;

		public Action onSprintDeactivated;

		public Action onWalkToggled;

		public Action onInteractPerformed;

		public Action onPickupPerformed;

		public Action onDropPerformed;

		public Action<int> onQuickSlotSelected;

		public Action onRightClickPerformed;

		public Action onAction1Performed;

		public Action onAction2Performed;

		public Action onAction3Performed;

		public Action onFirePerformed;

		public Action onCancelPerformed;

		public Action onCursorToggled;

		public Action onMapToggled;

		public Action onQuestLogToggled;

		public Action onSkillTreeToggled;

		public Action<float> onZoomPerformed;

		public Action onMenuEscapePerformed;

		public Action onBarControlsPerformed;

		public Action onBarControlsStarted;

		public Action onBarControlsCanceled;

		public Action onEmoteStarted;

		public Action onEmoteCanceled;

		public Action onTrailerCamToggled;

		public Action onCarLightPerformed;

		public Action onMicTogglePerformed;

		private NetworkObject _networkObject;

		public static InputReader LocalInstance { get; private set; }

		public bool IsPickupHeld => false;

		public bool IsRightClickHeld => false;

		public bool IsFireHeld => false;

		public bool IsAction1Held => false;

		public bool IsAction2Held => false;

		public static event Action<InputReader> OnLocalInputReaderReady
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInputValidation_003Ed__60))]
		private IEnumerator DelayedInputValidation()
		{
			return null;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnEnable()
		{
		}

		private bool ShouldEnableControls()
		{
			return false;
		}

		public void TryRegisterAsLocalPlayer()
		{
		}

		private void RegisterAsLocalInstanceIfOwner()
		{
		}

		private void EnsureControlsEnabledForOwner()
		{
		}

		public void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private bool ShouldProcessInput()
		{
			return false;
		}

		public void OnLook(InputAction.CallbackContext context)
		{
		}

		public void OnMove(InputAction.CallbackContext context)
		{
		}

		public void OnJump(InputAction.CallbackContext context)
		{
		}

		public void OnToggleWalk(InputAction.CallbackContext context)
		{
		}

		public void OnSprint(InputAction.CallbackContext context)
		{
		}

		public void OnCrouch(InputAction.CallbackContext context)
		{
		}

		public void OnAim(InputAction.CallbackContext context)
		{
		}

		public void OnLockOn(InputAction.CallbackContext context)
		{
		}

		public void OnInteract(InputAction.CallbackContext context)
		{
		}

		public void OnPickup(InputAction.CallbackContext context)
		{
		}

		public void OnMenuEscape(InputAction.CallbackContext context)
		{
		}

		public void OnBuild(InputAction.CallbackContext context)
		{
		}

		public void OnZoom(InputAction.CallbackContext context)
		{
		}

		public void OnDrop(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard1(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard2(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard3(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard4(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard5(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard6(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard7(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard8(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard9(InputAction.CallbackContext context)
		{
		}

		public void OnKeyboard0(InputAction.CallbackContext context)
		{
		}

		public void OnRightClick(InputAction.CallbackContext context)
		{
		}

		public void OnAction1(InputAction.CallbackContext context)
		{
		}

		public void OnAction2(InputAction.CallbackContext context)
		{
		}

		public void OnAction3(InputAction.CallbackContext context)
		{
		}

		public void OnFire(InputAction.CallbackContext context)
		{
		}

		public void OnCancel(InputAction.CallbackContext context)
		{
		}

		public void OnCursor(InputAction.CallbackContext context)
		{
		}

		public void OnMap(InputAction.CallbackContext context)
		{
		}

		public void OnQuestLogOpen(InputAction.CallbackContext context)
		{
		}

		public void OnSkillTree(InputAction.CallbackContext context)
		{
		}

		public void OnCameraView(InputAction.CallbackContext context)
		{
		}

		public void OnBarControls(InputAction.CallbackContext context)
		{
		}

		public void OnEmotes(InputAction.CallbackContext context)
		{
		}

		public void OnTrailerCam(InputAction.CallbackContext context)
		{
		}

		public void OnCarLight(InputAction.CallbackContext context)
		{
		}

		public void OnMic(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMode(InputAction.CallbackContext context)
		{
		}

		private void HandleQuickSlotSelection(InputAction.CallbackContext context, int slotIndex)
		{
		}
	}
}
