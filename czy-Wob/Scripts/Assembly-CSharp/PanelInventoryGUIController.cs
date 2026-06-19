using UnityEngine;

public class PanelInventoryGUIController : MonoBehaviour
{
	public PanelInventoryBoxes boxesRef;

	public GameObject mainUIObject;

	public GameObject placementUIObject;

	private string panelOpenSound = "toyboxOpen";

	private string panelCloseSound = "toyboxClose";

	private InventoryPanel panelRef;

	private void Awake()
	{
		Initialize();
		AudioController.Play(panelOpenSound);
	}

	private void Initialize()
	{
		InitializeGUI();
	}

	private void InitializeGUI()
	{
		boxesRef.CreateBoxes();
	}

	public void SetPanelRef(InventoryPanel newRef)
	{
		panelRef = newRef;
	}

	public void CloseGUI()
	{
		if (boxesRef != null)
		{
			boxesRef.ExitPlacementMode();
		}
		Object.Destroy(base.gameObject);
		AudioController.Play(panelCloseSound);
		panelRef.ClearNewObjects();
	}

	public void ShowPlacementUI()
	{
		mainUIObject.SetActive(value: false);
		placementUIObject.SetActive(value: true);
	}

	public void ShowMainUI()
	{
		mainUIObject.SetActive(value: true);
		placementUIObject.SetActive(value: false);
	}
}
