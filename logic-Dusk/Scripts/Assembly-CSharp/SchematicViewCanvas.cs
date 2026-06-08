using UnityEngine;

public class SchematicViewCanvas : MonoBehaviour
{
	private const int MAX_DRONES = 4;

	public static SchematicViewCanvas Instance;

	public SchematicViewDronePanel[] dronePanels;

	private SchematicViewShipPanel _shipPanel;

	private bool _initialized;

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			if (base.gameObject.activeSelf != value)
			{
				base.gameObject.SetActive(value);
			}
		}
	}

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
		Instance = this;
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("ShipInfo");
		if (transform != null)
		{
			_shipPanel = transform.gameObject.GetComponent<SchematicViewShipPanel>();
		}
		if (_shipPanel == null)
		{
			Debug.LogError("SchematicViewCanvas did not resolve all fields properly");
		}
		_initialized = true;
	}

	public void SetData()
	{
		if (!_initialized)
		{
			Initialize();
		}
		for (int i = 0; i < 4; i++)
		{
			Drone drone = DroneManager.Instance.GetDrone(i + 1);
			dronePanels[i].SetDrone(drone);
		}
		_shipPanel.SetData();
	}

	public void RefreshDrone(int droneNumber)
	{
		int num = dronePanels.Length;
		for (int i = 0; i < num; i++)
		{
			if (dronePanels[i] != null && dronePanels[i].ThisDrone != null && dronePanels[i].ThisDrone.DroneNumber == droneNumber)
			{
				dronePanels[i].UpgradesChanged = true;
				break;
			}
		}
	}
}
