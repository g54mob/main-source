using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamSensHandler : MonoBehaviour
{
	[SerializeField]
	private CinemachineInputAxisController camInputController;

	[SerializeField]
	private CinemachineCamera cam;

	[SerializeField]
	private PlayerMovement playerMovementScript;

	private int _prevFrameMouseSens;

	private float sensitivityMult = 0.1f;

	private float sensitivityMult_Controller = 0.25f;

	private void Start()
	{
		HandleFovChanged(_force: true);
		HandleSensitivity(_force: true);
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
		HandleInputContext();
		HandleSensitivity();
		HandleFovChanged();
	}

	private void HandleSensitivity(bool _force = false)
	{
		if (OptionsManager.Singleton.mouseSens_Setting != _prevFrameMouseSens || OptionsManager.Singleton.invertY_HasChanged || _force)
		{
			float num = ((OptionsManager.Singleton.invertY_Setting == 1) ? 1f : (-1f));
			camInputController.Controllers[0].Input.Gain = (float)OptionsManager.Singleton.mouseSens_Setting * sensitivityMult;
			camInputController.Controllers[1].Input.Gain = (float)OptionsManager.Singleton.mouseSens_Setting * sensitivityMult * num;
		}
		_prevFrameMouseSens = OptionsManager.Singleton.mouseSens_Setting;
	}

	private void HandleInputContext()
	{
		if (GenericMenuManager.Singleton.menuState == GenericMenuManager.MenuState.idle)
		{
			camInputController.Controllers[0].Enabled = true;
			camInputController.Controllers[1].Enabled = true;
		}
		else if (GenericMenuManager.Singleton.menuState == GenericMenuManager.MenuState.open)
		{
			camInputController.Controllers[0].Enabled = false;
			camInputController.Controllers[1].Enabled = false;
		}
	}

	private void HandleFovChanged(bool _force = false)
	{
		if (OptionsManager.Singleton.fov_HasChanged || _force)
		{
			cam.Lens.FieldOfView = OptionsManager.Singleton.fov_Setting;
			Debug.Log("NEW FOV SET");
			playerMovementScript.cameraFov_FovRange.x = OptionsManager.Singleton.fov_Setting;
			playerMovementScript.cameraFov_FovRange.y = (float)OptionsManager.Singleton.fov_Setting + 3.5f;
			OptionsManager.Singleton.fov_HasChanged = false;
		}
	}

	private void OnControllerChanged()
	{
		HandleSensitivity(_force: true);
	}
}
