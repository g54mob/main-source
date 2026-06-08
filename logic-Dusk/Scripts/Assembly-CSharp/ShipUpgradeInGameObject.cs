using System.Collections.Generic;
using UnityEngine;

public class ShipUpgradeInGameObject : MonoBehaviour, IToggleVisibilityInSchematic, ITowItem, IUpdateCameraView
{
	public enum ShipUpgradeStatusEnum
	{
		InstalledBroken = 0,
		InstalledBrokenLoose = 1,
		InstalledWorking = 2,
		InstalledWorkingLoose = 3,
		Loose = 4
	}

	public GameObject droneViewModel;

	public GameObject svReference;

	private bool _show;

	private ShipUpgradeStatusEnum _shipUpgradeStatus;

	public Color WorkingColor = Color.blue;

	public Color BrokenColor = Color.red;

	private Color _currentBaseColor;

	private BrokenStateEnum _lastBrokenState = BrokenStateEnum.OK;

	private Material defaultMaterial;

	private bool firstUpdate = true;

	private float _velocityScale = 2.4f;

	protected DroneUIObject droneUIObject;

	protected GameObject dvOverlayObject;

	protected GameObject svOverlayObject;

	private ColorBlinkManager blinkManager = new ColorBlinkManager();

	public BaseShipUpgrade ThisUpgrade { get; set; }

	public Room roomLocation { get; set; }

	public bool IsKnown
	{
		get
		{
			if (droneUIObject != null)
			{
				return droneUIObject.Visible;
			}
			return false;
		}
	}

	public bool Show
	{
		get
		{
			return _show;
		}
		set
		{
			_show = value;
			UpdateCameraView();
		}
	}

	public bool IsConnectedToBoardingShip { get; set; }

	public ShipUpgradeStatusEnum ShipUpgradeStatus
	{
		get
		{
			return _shipUpgradeStatus;
		}
		set
		{
			_shipUpgradeStatus = value;
			if (value == ShipUpgradeStatusEnum.InstalledWorkingLoose || value == ShipUpgradeStatusEnum.InstalledBrokenLoose || value == ShipUpgradeStatusEnum.Loose)
			{
				if (value == ShipUpgradeStatusEnum.InstalledWorkingLoose || value == ShipUpgradeStatusEnum.InstalledBrokenLoose)
				{
					base.transform.Rotate(new Vector3(0f, 0f, 1f), Random.Range(-20, 20));
				}
				if (value != ShipUpgradeStatusEnum.InstalledBrokenLoose)
				{
					CanBeTowed = true;
				}
				else
				{
					CanBeTowed = false;
				}
			}
			else
			{
				CanBeTowed = false;
			}
		}
	}

	public bool IsInstalled
	{
		get
		{
			return ShipUpgradeStatus != ShipUpgradeStatusEnum.InstalledBroken;
		}
	}

	public bool Found
	{
		get
		{
			if (droneUIObject != null)
			{
				return droneUIObject.Visible;
			}
			return false;
		}
	}

	public bool WasScanned { get; private set; }

	public string TowId
	{
		get
		{
			return ThisUpgrade.Name + "_" + ThisUpgrade.Id;
		}
	}

	public string TowFriendlyId
	{
		get
		{
			return string.Format("'{0}'", ThisUpgrade.Name);
		}
	}

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public bool CanBeTowed { get; set; }

	public string CantTowReason
	{
		get
		{
			string result = string.Empty;
			if (ThisUpgrade.BrokenState == BrokenStateEnum.Broken || ShipUpgradeStatus == ShipUpgradeStatusEnum.InstalledBroken || ShipUpgradeStatus == ShipUpgradeStatusEnum.InstalledBrokenLoose)
			{
				result = "Cannot tow a broken ship upgrade";
			}
			else if (ShipUpgradeStatus == ShipUpgradeStatusEnum.InstalledWorking)
			{
				result = ((ThisUpgrade == null || !ThisUpgrade.IsPermanentUpgrade) ? "Ship upgrade is firmly installed, cannot tow" : "Ship upgrade is permanently installed, cannot tow");
			}
			return result;
		}
	}

	public bool IsBeingTowed { get; set; }

	public Transform TowItemTransform
	{
		get
		{
			return base.transform;
		}
	}

	public Color TowColor
	{
		get
		{
			return new Color(1f, 0f, 0.5f);
		}
	}

	public bool IsInvisibleDueToToggle { get; set; }

	private void Awake()
	{
		_shipUpgradeStatus = ShipUpgradeStatusEnum.Loose;
		Transform transform = base.transform.Find("DroneUI");
		if (transform != null)
		{
			droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
		}
		transform = base.transform.Find("DVOverlay");
		if (transform != null)
		{
			dvOverlayObject = transform.gameObject;
		}
		transform = base.transform.Find("SVOverlay");
		if (transform != null)
		{
			svOverlayObject = transform.gameObject;
		}
		if (dvOverlayObject != null)
		{
			dvOverlayObject.GetComponent<Renderer>().material.color = WorkingColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObject.GetComponent<Renderer>().material.color = WorkingColor;
		}
		_currentBaseColor = WorkingColor;
		defaultMaterial = GetComponent<Renderer>().material;
	}

	private void Start()
	{
		droneUIObject.InitHelpTextInfo("Ship Upgrade", HelpTextTypeEnum.ShipUpgrade, true);
		droneUIObject.AddInfoCommand("info");
		droneUIObject.RefreshInfoLabelPos();
		TowManager.Instance.RegisterTowableItem(this);
	}

	private void OnDestroy()
	{
		droneViewModel = null;
		defaultMaterial = null;
		droneUIObject = null;
		dvOverlayObject = null;
		svOverlayObject = null;
	}

	private void Update()
	{
		if (firstUpdate)
		{
			if (droneUIObject != null && roomLocation != null)
			{
				if (droneUIObject.roomLst == null)
				{
					droneUIObject.roomLst = new List<Room>();
				}
				droneUIObject.roomLst.Add(roomLocation);
				roomLocation.AddDroneOverlayUI(droneUIObject);
			}
			firstUpdate = false;
		}
		if (ThisUpgrade != null && _lastBrokenState != ThisUpgrade.BrokenState)
		{
			BrokenStateEnum brokenState = ThisUpgrade.BrokenState;
			if (brokenState == BrokenStateEnum.Broken)
			{
				_currentBaseColor = BrokenColor;
			}
			else
			{
				_currentBaseColor = WorkingColor;
			}
			_lastBrokenState = ThisUpgrade.BrokenState;
		}
		Color color = _currentBaseColor;
		if (blinkManager.IsActive)
		{
			color = blinkManager.Update(Time.deltaTime);
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			dvOverlayObject.GetComponent<Renderer>().material.color = color;
		}
		else
		{
			svOverlayObject.GetComponent<Renderer>().material.color = color;
		}
		if (IsConnectedToBoardingShip)
		{
			GetComponent<Renderer>().material = ResourceManager.GenericTransparantDiffuseMaterial;
			color = GetComponent<Renderer>().material.color;
			color.a = DungeonManager.Instance.BoardingVessel.ShipAlpha;
			GetComponent<Renderer>().material.color = color;
			droneUIObject.SetOverlayAlpha(DungeonManager.Instance.BoardingVessel.ShipAlpha);
		}
		else if (GetComponent<Renderer>().material.color.a < 1f)
		{
			GetComponent<Renderer>().material = defaultMaterial;
		}
		if (droneUIObject.Visible)
		{
			Vector3 pos = new Vector3(base.transform.position.x + 3.5f, base.transform.position.y + 1.25f, base.transform.position.z);
			droneUIObject.OverrideInfoLabelPos(pos);
		}
	}

	public void MoveToPosition(Vector3 newPosition)
	{
		base.transform.position = new Vector3(newPosition.x, newPosition.y, 0f);
	}

	public void MoveForwardForced(float speed)
	{
		Vector3 velocityVector = GetVelocityVector(speed);
		base.transform.position += velocityVector;
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
	}

	public void PreRotation()
	{
	}

	public void PostRotation()
	{
	}

	public void StartColorBlink(Color colorToFadeTo, float cycleTime, int numberOfCycles)
	{
		blinkManager.Start(WorkingColor, colorToFadeTo, cycleTime, numberOfCycles);
	}

	private Vector3 GetVelocityVector(float speed)
	{
		return base.transform.up * _velocityScale * speed * Time.deltaTime;
	}

	public void SetSchematicVisibility(bool show)
	{
		if (droneUIObject != null)
		{
			if (!show && droneUIObject.Visible)
			{
				GetComponent<Renderer>().enabled = false;
				IsInvisibleDueToToggle = true;
				droneUIObject.HideOnSchematic();
			}
			else if (show && IsInvisibleDueToToggle)
			{
				IsInvisibleDueToToggle = false;
				droneUIObject.RevealOnSchematic();
			}
		}
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (droneUIObject != null)
			{
				GetComponent<Renderer>().enabled = !droneUIObject.Deactivated && Show;
			}
			else
			{
				GetComponent<Renderer>().enabled = Show;
			}
			ModelViewRefresh(Show);
			ReconnectSvVisuals();
		}
		else if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			GetComponent<Renderer>().enabled = false;
			ModelViewRefresh();
		}
	}

	protected void ModelViewRefresh()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			ModelViewRefresh(true);
		}
		else
		{
			ModelViewRefresh(false);
		}
	}

	protected void ModelViewRefresh(bool status)
	{
		if (droneViewModel != null)
		{
			droneViewModel.SetActive(status);
		}
	}

	public void Scanned()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Visible = true;
		}
		WasScanned = true;
	}

	public void DisconnectSvVisuals()
	{
		if (svReference != null)
		{
			svOverlayObject.transform.parent = null;
		}
	}

	public void ReconnectSvVisuals()
	{
		if (svReference != null)
		{
			svOverlayObject.transform.parent = base.transform;
			svOverlayObject.transform.position = svReference.transform.position;
			svOverlayObject.transform.rotation = svReference.transform.rotation;
			svOverlayObject.transform.localScale = svReference.transform.localScale;
		}
	}
}
