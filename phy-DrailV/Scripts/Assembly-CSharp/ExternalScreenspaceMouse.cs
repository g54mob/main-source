using DV;
using DV.Interaction.Inputs;
using DV.UI;
using DV.Utils;
using UnityEngine;

public class ExternalScreenspaceMouse : MonoBehaviour
{
	private ExternalCamera externalCamera;

	private JunctionSwitcher switcher;

	private bool tempDisable;

	private GameParams gameParams;

	private void Awake()
	{
		externalCamera = GetComponent<ExternalCamera>();
		switcher = new GameObject("JunctionSwitcher of ExternalScreenspaceMouse").AddComponent<JunctionSwitcher>();
		switcher.pointerOrigin = switcher.transform;
		switcher.transform.parent = base.transform;
		gameParams = Globals.G.GameParams;
	}

	private void OnEnable()
	{
		SetupListeners(on: true);
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			SetupListeners(on: false);
			switcher.enabled = false;
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceChanged;
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += CanvasElementToggled;
		}
		else
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= ScreenspaceChanged;
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += CanvasElementToggled;
		}
		ScreenspaceChanged(SingletonBehaviour<ScreenspaceMouse>.Instance.on);
	}

	private void CanvasElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
	{
		if (CanvasController.ElementType.Blockers.HasIntFlag(element.Type))
		{
			RefreshExtCamInput();
		}
	}

	private void ScreenspaceChanged(bool on)
	{
		RefreshExtCamInput();
	}

	private void RefreshExtCamInput()
	{
		externalCamera.acceptKeyboardInput = !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers);
		externalCamera.acceptMouseInput = externalCamera.acceptKeyboardInput && (!SingletonBehaviour<ScreenspaceMouse>.Instance.on || tempDisable);
	}

	private void Update()
	{
		bool flag = externalCamera.IsOn && SingletonBehaviour<ScreenspaceMouse>.Instance.on && gameParams.SwitchJunctionsViaMouse;
		Ray ray = externalCamera.cam.ScreenPointToRay(Input.mousePosition);
		switcher.transform.position = ray.origin;
		switcher.transform.forward = ray.direction;
		switcher.enabled = flag;
		if (flag && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary))
		{
			switcher.Use();
		}
		bool num = InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionSecondary) || InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionMiddle);
		bool flag2 = InputManager.NewPlayer.GetButton(InputManager.Actions.InteractionSecondary) || InputManager.NewPlayer.GetButton(InputManager.Actions.InteractionMiddle);
		if (num && SingletonBehaviour<ScreenspaceMouse>.Instance.on)
		{
			tempDisable = true;
			SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: false, 1);
			externalCamera.blockFOVChange = true;
			RefreshExtCamInput();
		}
		if (tempDisable && !flag2)
		{
			tempDisable = false;
			SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			externalCamera.blockFOVChange = false;
			RefreshExtCamInput();
		}
	}
}
