using System.Collections;
using System.Linq;
using DV.Common;
using DV.Interaction.Inputs;
using DV.UI.Inventory;
using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VRTK;

namespace DV.UI
{
	public class CanvasProviderDV : ACanvasControllerProvider<CanvasController.ElementType>
	{
		private const float MOUSE_MODE_HOLD_THRESHOLD = 0.3f;

		[Header("VR")]
		public float openInventoryDistance = 3f;

		public GameObject inventoryFloatiePrefab;

		private GameObject floatieGO;

		private Transform headsetTransform;

		private CustomMouseLook playerMouseLook;

		private ExternalCamera externalCamera;

		private GameParams gameParams;

		private bool loaded;

		private SettingsController settingsController;

		private bool attemptedToFindSettingsController;

		public override bool IsVR()
		{
			return VRManager.IsVREnabled();
		}

		public override bool IsGameLoaded()
		{
			if (WorldStreamingInit.IsLoaded)
			{
				return loaded;
			}
			return false;
		}

		private IEnumerator Start()
		{
			gameParams = Globals.G.GameParams;
			while (!WorldStreamingInit.IsLoaded)
			{
				yield return null;
			}
			if (!IsVR())
			{
				while (!PlayerManager.PlayerTransform)
				{
					yield return null;
				}
				while (!SingletonBehaviour<HotbarController>.Instance)
				{
					yield return null;
				}
				GetNonVRReferences();
			}
			else
			{
				yield return VRSetup();
			}
			base.enabled = !IsVR();
			loaded = true;
			if (!IsVR())
			{
				SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(CrosshairHackFix());
			}
		}

		private IEnumerator CrosshairHackFix()
		{
			while (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Crosshair))
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Crosshair, on: true);
				yield return null;
			}
		}

		private void Update()
		{
			if (loaded && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.MouseLook))
			{
				StartCoroutine(MouseModeCoro());
			}
		}

		private IEnumerator MouseModeCoro()
		{
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.MouseMode))
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.MouseMode, on: false);
			}
			else if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.MouseMode))
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.MouseMode, on: true);
				float start = Time.unscaledTime;
				int frameCounter = 0;
				while (InputManager.NewPlayer.GetButton(InputManager.Actions.MouseLook))
				{
					yield return null;
					frameCounter++;
				}
				if (Time.unscaledTime - start > 0.3f && frameCounter > 3)
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.MouseMode, on: false);
				}
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				externalCamera.IsOnChanged -= ExternalCameraToggled;
				SingletonBehaviour<HotbarController>.Instance.OpenChanged -= HotbarToggled;
			}
		}

		private void GetNonVRReferences()
		{
			playerMouseLook = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>().m_MouseLook;
			externalCamera = SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera;
			externalCamera.IsOnChanged += ExternalCameraToggled;
			SingletonBehaviour<HotbarController>.Instance.OpenChanged += HotbarToggled;
		}

		private void HotbarToggled()
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Hotbar, SingletonBehaviour<HotbarController>.Instance.IsOpen);
		}

		private void ExternalCameraToggled(bool on)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.ExternalCamera, on);
		}

		public override bool ShouldTryToggle(CanvasController.ElementType type)
		{
			if (!loaded)
			{
				return false;
			}
			switch (type)
			{
			case CanvasController.ElementType.Inventory:
				if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.Inventory))
				{
					if (!InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventoryOpen))
					{
						if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory))
						{
							return InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Escape);
						}
						return false;
					}
					return true;
				}
				return false;
			case CanvasController.ElementType.PauseMenu:
				if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory) && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Escape))
				{
					return !PauseMenuHasUnappliedSettingsChanges();
				}
				return false;
			case CanvasController.ElementType.FastTravel:
				if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.FastTravel))
				{
					if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.FastTravel))
					{
						return InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Escape);
					}
					return false;
				}
				return false;
			case CanvasController.ElementType.BedSleeping:
				if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.Sleep))
				{
					if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.BedSleeping))
					{
						return InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Escape);
					}
					return false;
				}
				return false;
			default:
				return false;
			}
		}

		public override void Toggle(GameObject reference, CanvasController.ElementType type, bool on)
		{
			if (!loaded)
			{
				return;
			}
			switch (type)
			{
			case CanvasController.ElementType.Inventory:
				reference.GetComponentInChildren<AInventoryUIController>().Toggle(on);
				break;
			case CanvasController.ElementType.MouseMode:
				SingletonBehaviour<ScreenspaceMouse>.Instance.SetScreenspaceDefaultValue(on);
				return;
			case CanvasController.ElementType.HUD:
				if (on && !gameParams.LocoHUDAllowed)
				{
					return;
				}
				break;
			}
			if (reference == null)
			{
				return;
			}
			if (reference.TryGetComponent<UIOptimizedEnableDisable>(out var component))
			{
				if (on)
				{
					component.Enable();
				}
				else
				{
					component.Disable();
				}
			}
			else
			{
				reference.SetActive(on);
			}
		}

		public override bool IsOn(GameObject reference, CanvasController.ElementType type)
		{
			if (!loaded)
			{
				return false;
			}
			switch (type)
			{
			case CanvasController.ElementType.MouseMode:
				return SingletonBehaviour<ScreenspaceMouse>.Instance.on;
			case CanvasController.ElementType.Hotbar:
				return SingletonBehaviour<HotbarController>.Instance.IsOpen;
			case CanvasController.ElementType.ExternalCamera:
				if ((bool)externalCamera)
				{
					return externalCamera.IsOn;
				}
				return false;
			case CanvasController.ElementType.Popup:
			case CanvasController.ElementType.PopupNoPause:
			{
				if (!reference || !reference.activeSelf)
				{
					return false;
				}
				if (!reference.TryGetComponent<PopupManager>(out var component))
				{
					return false;
				}
				Popup nextPopup = component.NextPopup;
				if ((bool)nextPopup)
				{
					if (type != CanvasController.ElementType.Popup)
					{
						return !nextPopup.pauseOnOpen;
					}
					return nextPopup.pauseOnOpen;
				}
				Popup activePopup = component.ActivePopup;
				if ((bool)activePopup)
				{
					if (type != CanvasController.ElementType.Popup)
					{
						return !activePopup.pauseOnOpen;
					}
					return activePopup.pauseOnOpen;
				}
				return false;
			}
			default:
				if (reference == null)
				{
					return false;
				}
				return reference.activeSelf;
			}
		}

		public override void RequirePointer(bool on)
		{
			if (loaded)
			{
				if (IsVR())
				{
					SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, on);
				}
				else if (on)
				{
					SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: true);
					playerMouseLook?.RequestMouseSensitivityState(this, MouseSensitivityState.Locked);
				}
				else
				{
					SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
					playerMouseLook?.RemoveRequest(this);
				}
			}
		}

		public override void RequirePause(bool on)
		{
			if (loaded)
			{
				if (on)
				{
					SingletonBehaviour<AppUtil>.Instance.RequestPause(this, paused: true);
				}
				else
				{
					SingletonBehaviour<AppUtil>.Instance.RemovePauseRequest(this);
				}
			}
		}

		private IEnumerator VRSetup()
		{
			Canvas canvas = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas;
			while (PlayerManager.PlayerCamera == null)
			{
				yield return null;
			}
			canvas.renderMode = RenderMode.WorldSpace;
			canvas.worldCamera = PlayerManager.PlayerCamera.transform.parent.GetComponentsInChildren<Camera>().First((Camera cam) => (cam.cullingMask & LayerMask.GetMask("UI")) != 0);
			canvas.gameObject.AddComponent<VRTK_UICanvasDV>();
			canvas.transform.localPosition = Vector3.zero;
			canvas.transform.localRotation = Quaternion.identity;
			canvas.transform.localScale = Vector3.one * 0.00125f;
			headsetTransform = VRTK_DeviceFinder.HeadsetTransform();
			GameObject gameObject = new GameObject("[Floatie Container]");
			gameObject.AddComponent<FloatiePlayerCameraFollower>();
			floatieGO = Object.Instantiate(inventoryFloatiePrefab, gameObject.transform, worldPositionStays: false);
			Floatie component = floatieGO.GetComponent<Floatie>();
			component.distanceFromHead = openInventoryDistance;
			component.enabled = true;
			component.head = headsetTransform;
			canvas.transform.SetParent(floatieGO.transform, worldPositionStays: false);
			canvas.gameObject.AddComponent<Image>().raycastTarget = false;
			canvas.gameObject.AddComponent<Mask>().showMaskGraphic = false;
			EventSystem componentInChildren = canvas.GetComponentInChildren<EventSystem>();
			BaseInputModule component2 = canvas.GetComponent<BaseInputModule>();
			if (component2 != null)
			{
				Object.Destroy(component2);
			}
			if (componentInChildren != null)
			{
				Object.Destroy(componentInChildren);
			}
		}

		private Quaternion CalculateCanvasOpenRotation(Vector3 desiredInventoryPosition)
		{
			Vector3 vector = Vector3.ProjectOnPlane(desiredInventoryPosition - headsetTransform.position, Vector3.up);
			if (vector == Vector3.zero)
			{
				vector = headsetTransform.forward;
			}
			return Quaternion.LookRotation(vector, floatieGO.transform.parent.up);
		}

		private Vector3 CalculateCanvasOpenPosition()
		{
			float num = Mathf.Sign(Vector3.Dot(headsetTransform.forward, Vector3.up));
			float num2 = Mathf.Sign(Vector3.Dot(headsetTransform.up, Vector3.up));
			Vector3 vector = Vector3.ProjectOnPlane(headsetTransform.forward, Vector3.up);
			if (vector.sqrMagnitude < 0.1f)
			{
				vector = Vector3.ProjectOnPlane((0f - num2) * num * headsetTransform.up, Vector3.up);
			}
			return vector.normalized * num2 * openInventoryDistance + headsetTransform.position;
		}

		public override void RepositionVRCanvas()
		{
			if ((bool)headsetTransform)
			{
				Vector3 vector = CalculateCanvasOpenPosition();
				Quaternion rotation = CalculateCanvasOpenRotation(vector);
				floatieGO.transform.SetPositionAndRotation(vector, rotation);
			}
		}

		private bool PauseMenuHasUnappliedSettingsChanges()
		{
			if (!attemptedToFindSettingsController)
			{
				attemptedToFindSettingsController = true;
				if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.PauseMenu, out var element))
				{
					settingsController = element.reference.GetComponentInChildren<SettingsController>(includeInactive: true);
				}
				if (settingsController == null)
				{
					Debug.LogError("CanvasProviderDV: Could not find SettingsController");
				}
			}
			if (settingsController != null)
			{
				return settingsController.HasChanges;
			}
			return false;
		}
	}
}
