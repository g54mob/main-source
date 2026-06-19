using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravityMachineGUIController : MonoBehaviour
{
	public enum GravSetting
	{
		Earth = 0,
		Mars = 1,
		Moon = 2,
		None = 3,
		Neptune = 4,
		Jupiter = 5,
		Flipped = 6,
		Random = 7
	}

	public static Dictionary<GravSetting, float> gravityValues = new Dictionary<GravSetting, float>
	{
		{
			GravSetting.Mars,
			0.38f
		},
		{
			GravSetting.Moon,
			0.17f
		},
		{
			GravSetting.None,
			0f
		},
		{
			GravSetting.Earth,
			1f
		},
		{
			GravSetting.Neptune,
			1.14f
		},
		{
			GravSetting.Jupiter,
			2.4f
		}
	};

	public TMP_InputField gravityInputField;

	private float maxGrav = 5f;

	private float minGrav = -5f;

	private float currentGravMod = 1f;

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private GravityMachine machineRef;

	private GUIManagerPens guiManagerRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		guiManagerRef.DisableBG(LockReason.GRAVITY_MACHINE_GUI);
		guiManagerRef.RegisterNewPopup(LockReason.GRAVITY_MACHINE_GUI, stomp: true, CloseGUI);
		AudioController.Play(windowOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			CloseGUI();
		}
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.GRAVITY_MACHINE_GUI);
		guiManagerRef.ClearPopupRegistration(LockReason.GRAVITY_MACHINE_GUI);
		Object.Destroy(base.gameObject);
		AudioController.Play(windowCloseSound);
	}

	public void SetGravMachineRef(GravityMachine newRef, float existingMod)
	{
		machineRef = newRef;
		currentGravMod = existingMod;
		ApplyNewGravityValue();
	}

	public void OnManualGravEditEnd()
	{
		if (!float.TryParse(gravityInputField.text, out var result))
		{
			result = 1f;
		}
		result = Mathf.Clamp(result, minGrav, maxGrav);
		result *= 100f;
		result = Mathf.RoundToInt(result);
		result /= 100f;
		currentGravMod = result;
		ApplyNewGravityValue();
	}

	private void ApplyNewGravityValue()
	{
		machineRef.SetGravMod(currentGravMod);
		gravityInputField.SetTextWithoutNotify(currentGravMod.ToString());
	}

	public void ApplyPresetMars()
	{
		currentGravMod = gravityValues[GravSetting.Mars];
		ApplyNewGravityValue();
	}

	public void ApplyPresetMoon()
	{
		currentGravMod = gravityValues[GravSetting.Moon];
		ApplyNewGravityValue();
	}

	public void ApplyPresetAnti()
	{
		currentGravMod = gravityValues[GravSetting.None];
		ApplyNewGravityValue();
	}

	public void ApplyPresetEarth()
	{
		currentGravMod = gravityValues[GravSetting.Earth];
		ApplyNewGravityValue();
	}

	public void ApplyPresetNeptune()
	{
		currentGravMod = gravityValues[GravSetting.Neptune];
		ApplyNewGravityValue();
	}

	public void ApplyPresetJupiter()
	{
		currentGravMod = gravityValues[GravSetting.Jupiter];
		ApplyNewGravityValue();
	}
}
