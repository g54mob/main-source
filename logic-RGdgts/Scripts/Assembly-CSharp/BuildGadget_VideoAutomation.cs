using System.Collections;
using UnityEngine;

public class BuildGadget_VideoAutomation : VideoAutomation
{
	public float pickupModuleAfterCloseDelay;

	public float pickupModuleSrollDelay;

	public float pickupModuleAfterMoveToModuleDelay;

	private IEnumerator PickupFromModulesDrawer(object id)
	{
		return null;
	}

	public void Build(SerializedGadgetMetaData metadata, SerializedGadget serializedGadget)
	{
	}

	private IEnumerator BuildGadgetCoroutine(SerializedGadgetMetaData metadata, SerializedGadget serializedGadget)
	{
		return null;
	}

	private IEnumerator BuildMotherboard(Vector3 gadgetPosition, SerializedMotherboard serializedMotherboard)
	{
		return null;
	}

	private IEnumerator RotateModule(int rotation)
	{
		return null;
	}

	private IEnumerator FlipPcb()
	{
		return null;
	}

	private IEnumerator CloseCover()
	{
		return null;
	}
}
