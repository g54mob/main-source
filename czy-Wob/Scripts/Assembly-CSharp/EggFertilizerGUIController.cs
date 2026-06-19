using UnityEngine;

public class EggFertilizerGUIController : MonoBehaviour
{
	private GUIManagerPens guiManagerRef;

	private void Initialize()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		guiManagerRef.DisableBG(LockReason.EGG_FERTILIZER);
	}

	public void SetMachineRef(EggFertilizerMachine newRef)
	{
		Initialize();
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.EGG_FERTILIZER);
		Object.Destroy(base.gameObject);
	}
}
