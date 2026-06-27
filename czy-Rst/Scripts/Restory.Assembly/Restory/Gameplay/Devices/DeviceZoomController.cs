using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.GameView;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters;
using Restory.UI.Presenters.Inventory;
using Restory.UI.Presenters.Notepad;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceZoomController : MonoBehaviour
	{
		[SerializeField]
		private DeviceContainer deviceContainer;

		[SerializeField]
		[RewiredActionsDropdown]
		private int zoomAxisId = -1;

		[SerializeField]
		[Range(0.1f, 0.8f)]
		[Tooltip("How far the device can move toward the camera at full zoom (0 = no move, 1 = camera target).")]
		public float maxZoom = 0.7f;

		[SerializeField]
		[Range(0f, 0.4f)]
		[Tooltip("Zoom percent added/removed per mouse-wheel notch. Higher values make movement more sensitive.")]
		public float percentPerNotch = 0.2f;

		[SerializeField]
		[Range(0f, 0.2f)]
		[Tooltip("Zoom percent added/removed per keyboard/controller step. Higher values make button zoom faster.")]
		public float percentPerNotchButton = 0.05f;

		[SerializeField]
		[Range(4f, 20f)]
		[Tooltip("Smoothing strength for zoom movement. Higher values reach target position faster.")]
		public float damping = 12f;

		[SerializeField]
		[Range(1f, 20f)]
		[Tooltip("Maximum input notches processed in one frame to prevent sudden jumps from large scroll spikes.")]
		public int maxNotchesPerFrame = 10;

		[SerializeField]
		[Range(1f, 10f)]
		[Tooltip("Speed of automatic zoom-out.")]
		public float resetZoomSpeed = 4f;

		private IPlayerInput playerInput;

		private GameViewController gameViewController;

		private GUI_NotepadWindow notepadWindow;

		private InventoryPanel inventoryPanel;

		private GUI_PcWindowsXpScreen pcScreen;

		private CleanedElementDestinationHandler cleanedElementDestinationHandler;

		private DisassembleStateMachine disassembleStateMachine;

		private Transform zoomSubject;

		private Vector3 zoomSubjectDefaultLocalPosition;

		private Vector3 minZoomPosition;

		private Vector3 maxZoomPosition;

		private Vector3 deviceMaxZoomPosition;

		private float currentZoom;

		private float targetZoom;

		private bool isActive;

		private float deviceLastZoom;

		[Inject]
		private void Construct(IPlayerInput playerInput, GameViewController gameViewController, GUI_NotepadWindow notepadWindow, InventoryPanel inventoryPanel, GUI_PcWindowsXpScreen pcScreen, CleanedElementDestinationHandler cleanedElementDestinationHandler, DisassembleStateMachine disassembleStateMachine)
		{
			this.playerInput = playerInput;
			this.gameViewController = gameViewController;
			this.notepadWindow = notepadWindow;
			this.inventoryPanel = inventoryPanel;
			this.pcScreen = pcScreen;
			this.cleanedElementDestinationHandler = cleanedElementDestinationHandler;
			this.disassembleStateMachine = disassembleStateMachine;
			zoomSubject = deviceContainer.DisassemblePoint;
			zoomSubjectDefaultLocalPosition = zoomSubject.localPosition;
		}

		private void OnEnable()
		{
			deviceContainer.OnDeviceActivated += ResolveDeviceActivated;
			deviceContainer.OnDeviceDeactivated += ResolveDeviceDeactivated;
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		private void OnDisable()
		{
			isActive = false;
			zoomSubject.localPosition = zoomSubjectDefaultLocalPosition;
			deviceContainer.OnDeviceActivated -= ResolveDeviceActivated;
			deviceContainer.OnDeviceDeactivated -= ResolveDeviceDeactivated;
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
		}

		private void LateUpdate()
		{
			if (isActive)
			{
				UpdateTargetZoom();
				UpdateZoomSubjectPosition();
			}
		}

		private void UpdateTargetZoom()
		{
			if (disassembleStateMachine.ActiveState is CheckDeviceDisassembleState)
			{
				targetZoom = Mathf.Clamp01(targetZoom - resetZoomSpeed * Time.deltaTime);
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is TransitionToCleaningDisassembleState) && !(activeState is TransitionFromCleaningDisassembleState) && !notepadWindow.IsPointerInside && !inventoryPanel.IsPointerOverInventory && !pcScreen.IsVisible)
			{
				float axisRaw = playerInput.GetAxisRaw(zoomAxisId);
				if (axisRaw != 0f)
				{
					float num = Mathf.Clamp(axisRaw, -maxNotchesPerFrame, maxNotchesPerFrame);
					float num2 = (playerInput.IsCurrentInputSource(zoomAxisId, ControllerType.Keyboard) ? percentPerNotchButton : percentPerNotch);
					float num3 = num * num2;
					targetZoom = Mathf.Clamp01(targetZoom + num3);
				}
			}
		}

		private void UpdateZoomSubjectPosition()
		{
			float t = 1f - Mathf.Exp((0f - damping) * Time.deltaTime);
			currentZoom = Mathf.Lerp(currentZoom, targetZoom, t);
			zoomSubject.position = Vector3.Lerp(minZoomPosition, maxZoomPosition, currentZoom);
		}

		private void ResolveDeviceActivated()
		{
			minZoomPosition = zoomSubject.position;
			maxZoomPosition = (deviceMaxZoomPosition = Vector3.Lerp(minZoomPosition, gameViewController.CameraTargetPosition, Mathf.Clamp01(maxZoom)));
			currentZoom = 0f;
			targetZoom = 0f;
			isActive = true;
		}

		private void ResolveDeviceDeactivated()
		{
			isActive = false;
			zoomSubject.localPosition = zoomSubjectDefaultLocalPosition;
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!isActive)
			{
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is CleaningDisassembleState))
			{
				if (activeState is TransitionFromCleaningDisassembleState)
				{
					SwitchToDeviceZoom();
				}
			}
			else
			{
				SwitchToElementZoom();
			}
		}

		private void SwitchToElementZoom()
		{
			float num = maxZoom;
			if ((bool)cleanedElementDestinationHandler.TargetElement)
			{
				num = Mathf.Max(maxZoom, cleanedElementDestinationHandler.TargetElement.MaxZoom);
			}
			deviceLastZoom = currentZoom;
			currentZoom = (targetZoom = currentZoom * maxZoom / num);
			maxZoomPosition = Vector3.Lerp(minZoomPosition, gameViewController.CameraTargetPosition, Mathf.Clamp01(num));
		}

		private void SwitchToDeviceZoom()
		{
			maxZoomPosition = deviceMaxZoomPosition;
			currentZoom = (targetZoom = deviceLastZoom);
			zoomSubject.position = Vector3.Lerp(minZoomPosition, maxZoomPosition, currentZoom);
		}
	}
}
