using UnityEngine;

public class ComputerFrontPort : MonoBehaviour
{
	[Header("Components")]
	public InventoryManager inventoryManager;

	public ComputerPortsInterface computerPortsInterface;

	public DirectoryManager computerDirectoryManager;

	public appExplorer appExplorer;

	public ComputerStation computerStation;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Ports")]
	public InventoryItem[] Ports;

	private void OnValidate()
	{
	}

	private bool CheckAndAddCollider(Transform obj)
	{
		return false;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private void OpenInterface(KeyCode key, object[] param)
	{
	}

	public void StepAwayDevice()
	{
	}

	public void SelectSlot(int item)
	{
	}

	public void ConnectMemoryDeviceToComputer(FileSystemObject deviceFileSystemObject)
	{
	}
}
