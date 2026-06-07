using UnityEngine;

public class PatchPanel : UsableObject
{
	private CableLink[] cableLinkPorts;

	public string patchPanelId;

	public int patchPanelType;

	public override void Awake()
	{
	}

	public CableLink GetPairedLink(CableLink link)
	{
		return null;
	}

	public bool IsAnyCableConnected()
	{
		return false;
	}

	public override void InteractOnClick()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public void InsertedInRack(PatchPanelSaveData saveData = null)
	{
	}

	public bool ValidateRackPosition()
	{
		return false;
	}

	public override void OnDestroy()
	{
	}
}
