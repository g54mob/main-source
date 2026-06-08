using System.Collections.Generic;
using UnityEngine;

public class ShipUpgradeSubsystemObject : RoomItem, IMetaData
{
	private ShipUpgradeInGameObject _installedShipObject;

	private GameObject _actualVisualObject;

	private GameObject _capsule;

	public ShipUpgradeInGameObject InstalledShipObject { get; set; }

	public int NumberOfSlots { get; set; }

	public GameObject HookUpPoint { get; private set; }

	public bool IsPermUpgrade { get; set; }

	public Renderer renderer
	{
		get
		{
			return _actualVisualObject.GetComponent<Renderer>();
		}
	}

	public new GameObject gameObject
	{
		get
		{
			return _actualVisualObject.gameObject;
		}
	}

	protected override bool _shouldShowHelpTextByDefault
	{
		get
		{
			return false;
		}
	}

	public override string ItemName
	{
		get
		{
			if (InstalledShipObject != null && base.roomLocation.GetComponent<Collider>().bounds.Intersects(InstalledShipObject.GetComponent<Collider>().bounds))
			{
				string text = string.Empty;
				if (InstalledShipObject.ThisUpgrade != null)
				{
					if (InstalledShipObject.ThisUpgrade.BrokenState == BrokenStateEnum.Broken)
					{
						text = " (Destroyed)";
					}
					return "Ship Upgrade: " + InstalledShipObject.ThisUpgrade.Name + text;
				}
			}
			return "Ship Upgrade: <empty>";
		}
	}

	public List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

	public override void Awake()
	{
		_actualVisualObject = base.transform.FindChild("SingleSubSystemPrefab").gameObject;
		_capsule = _actualVisualObject.transform.FindChild("Capsule").gameObject;
		HookUpPoint = _actualVisualObject.transform.FindChild("HookupPoint").gameObject;
		base.Awake();
	}

	public override void Start()
	{
		base.Start();
		Transform transform = base.transform.FindChild("DroneUI");
		if (transform != null)
		{
			droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
		}
		transform = base.transform.FindChild("DVOverlay");
		if (transform != null)
		{
			dvOverlayObject = transform.gameObject;
		}
		transform = base.transform.FindChild("SVOverlay");
		if (transform != null)
		{
			svOverlayObject = transform.gameObject;
		}
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().material.color = Color.white;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().material.color = Color.white;
		}
	}

	protected override void OnDestroy()
	{
		_actualVisualObject = null;
		_capsule = null;
		HookUpPoint = null;
		base.OnDestroy();
	}

	public override void Update()
	{
		if (_actualVisualObject.GetComponent<Renderer>().enabled && !_capsule.GetComponent<Renderer>().enabled)
		{
			_capsule.GetComponent<Renderer>().enabled = true;
		}
		else if (!_actualVisualObject.GetComponent<Renderer>().enabled && _capsule.GetComponent<Renderer>().enabled)
		{
			_capsule.GetComponent<Renderer>().enabled = false;
		}
		base.Update();
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (droneUIObject != null)
			{
				_actualVisualObject.GetComponent<Renderer>().enabled = !droneUIObject.Deactivated && show;
			}
			else
			{
				_actualVisualObject.GetComponent<Renderer>().enabled = show;
			}
			ModelViewRefresh(Show);
		}
		else if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			_actualVisualObject.GetComponent<Renderer>().enabled = false;
			ModelViewRefresh();
		}
	}

	public string GetMetaData(string name)
	{
		if (metaDataList != null)
		{
			foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
			{
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
		}
		return string.Empty;
	}
}
