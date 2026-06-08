using System.Collections.Generic;
using UnityEngine;

public abstract class RoomItem : MonoBehaviour, IToggleVisibilityInSchematic, IUpdateCameraView
{
	public Collider itemCollider;

	public GameObject droneViewModel;

	public Material StunMtl;

	public Material DamageMtl;

	public Material DeathMtl;

	public Color InactiveColor = Color.white;

	public Color ActiveColor = Color.white;

	public Color DamageColor = Color.white;

	public Color DeadColor = Color.white;

	protected Material baseMtl;

	protected DungeonManager dungeonManager;

	protected DroneManager droneManager;

	protected GameplayManager gameplayManager;

	protected DroneUIObject droneUIObject;

	protected GameObject dvOverlayObject;

	protected Material dvOverlayObjectMat;

	protected GameObject svOverlayObject;

	protected Material svOverlayObjectMat;

	protected Renderer dvOverlayObjectRenderer;

	protected Renderer svOverlayObjectRenderer;

	protected Transform droneViewModelDefaultTransform;

	protected Material droneViewModelDefaultTransformMat;

	protected bool show;

	private bool scanned;

	private bool firstUpdate = true;

	protected GameObject dvStatusOverlay;

	protected Material dvStatusOverlayMat;

	protected ColorBlinkManager statusOverlayBlinkManager;

	protected Renderer itemRenderer;

	public abstract string ItemName { get; }

	public Room roomLocation { get; set; }

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

	public bool IsDead { get; protected set; }

	public bool WasScanned { get; private set; }

	public bool IsInSpace { get; private set; }

	protected virtual bool _shouldShowHelpTextByDefault
	{
		get
		{
			return true;
		}
	}

	protected virtual HelpTextTypeEnum _helpTextType
	{
		get
		{
			return HelpTextTypeEnum.None;
		}
	}

	public virtual bool Show
	{
		get
		{
			return show;
		}
		set
		{
			show = value;
			UpdateCameraView();
		}
	}

	public virtual bool Powered
	{
		get
		{
			return roomLocation != null && roomLocation.isPowered;
		}
	}

	public virtual bool Explored
	{
		get
		{
			if (roomLocation != null)
			{
				return roomLocation.isExplored;
			}
			Debug.Log("Uh oh, room item not hooked up right: " + GetType().ToString());
			return false;
		}
	}

	public bool IsInvisibleDueToToggle { get; set; }

	protected virtual void OnDestroy()
	{
		itemCollider = null;
		droneViewModel = null;
		StunMtl = null;
		DamageMtl = null;
		DeathMtl = null;
		dvOverlayObject = null;
		Object.DestroyImmediate(dvOverlayObjectMat);
		svOverlayObject = null;
		Object.DestroyImmediate(svOverlayObjectMat);
		dvOverlayObjectRenderer = null;
		svOverlayObjectRenderer = null;
		droneViewModelDefaultTransform = null;
		dvStatusOverlay = null;
		Object.DestroyImmediate(dvStatusOverlayMat);
		itemRenderer = null;
	}

	public virtual void Awake()
	{
		itemRenderer = GetComponent<Renderer>();
		itemCollider = GetComponent<Collider>();
		if (itemRenderer != null)
		{
			baseMtl = itemRenderer.material;
		}
		if (!(droneViewModel != null))
		{
			return;
		}
		Transform[] componentsInChildren = droneViewModel.GetComponentsInChildren<Transform>();
		Transform[] array = componentsInChildren;
		foreach (Transform transform in array)
		{
			if (transform.name.StartsWith("default"))
			{
				droneViewModelDefaultTransform = transform;
			}
		}
	}

	public virtual void Start()
	{
		if (itemRenderer == null)
		{
			itemRenderer = GetComponent<Renderer>();
		}
		if (itemCollider == null)
		{
			itemCollider = GetComponent<Collider>();
		}
		dungeonManager = DungeonManager.Instance;
		droneManager = DroneManager.Instance;
		gameplayManager = GameplayManager.Instance;
		Transform transform = base.transform.Find("DroneUI");
		if (transform == null && base.transform.parent != null)
		{
			transform = base.transform.parent.Find("DroneUI");
		}
		if (transform != null && droneUIObject == null)
		{
			droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
			droneUIObject.InitHelpTextInfo(ItemName, _helpTextType, _shouldShowHelpTextByDefault);
		}
		transform = base.transform.Find("DVOverlay");
		if (transform != null)
		{
			dvOverlayObject = transform.gameObject;
			dvOverlayObjectRenderer = dvOverlayObject.GetComponent<Renderer>();
			dvOverlayObjectMat = dvOverlayObjectRenderer.material;
		}
		transform = base.transform.Find("SVOverlay");
		if (transform != null)
		{
			svOverlayObject = transform.gameObject;
			svOverlayObjectRenderer = svOverlayObject.GetComponent<Renderer>();
			svOverlayObjectMat = svOverlayObjectRenderer.material;
		}
		if (!IsDead)
		{
			if (itemRenderer != null)
			{
				itemRenderer.material.color = ActiveColor;
			}
			if (dvOverlayObjectRenderer != null)
			{
				dvOverlayObjectMat.color = ActiveColor;
			}
			if (svOverlayObjectRenderer != null)
			{
				svOverlayObjectRenderer.material.color = ActiveColor;
			}
		}
		else
		{
			SetDead();
		}
		if (gameplayManager != null)
		{
			SetSchematicVisibility(gameplayManager.showSchematicToggleItems);
		}
	}

	public virtual void PowerUp(Drone drone)
	{
	}

	public virtual void PowerDown(Drone drone)
	{
	}

	public virtual void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (itemRenderer != null)
			{
				itemRenderer.enabled = show;
			}
		}
		else if (itemRenderer != null)
		{
			itemRenderer.enabled = Explored;
		}
		ModelViewRefresh();
	}

	public virtual void BeginPowerFlow()
	{
	}

	public virtual void EndPowerFlow()
	{
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
		if (droneViewModel != null && droneViewModel.activeSelf != status)
		{
			droneViewModel.SetActive(status);
		}
	}

	public virtual void Update()
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
		if (scanned && droneUIObject != null)
		{
			droneUIObject.Deactivated = false;
			droneUIObject.MakeVisible();
			scanned = false;
		}
		if (statusOverlayBlinkManager != null)
		{
			Color color = statusOverlayBlinkManager.Update(Time.deltaTime);
			if (!dvStatusOverlayMat)
			{
				dvStatusOverlayMat = dvStatusOverlay.GetComponent<Renderer>().material;
			}
			if (statusOverlayBlinkManager.IsActive)
			{
				dvStatusOverlayMat.color = color;
				return;
			}
			statusOverlayBlinkManager = null;
			dvStatusOverlay.GetComponent<Renderer>().enabled = false;
		}
	}

	public bool HasBeenSeen()
	{
		if (droneUIObject != null)
		{
			return !droneUIObject.Deactivated && droneUIObject.Visible;
		}
		return false;
	}

	public void Scanned()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = false;
			droneUIObject.MakeVisible();
			if (!gameplayManager.showSchematicToggleItems)
			{
				droneUIObject.HideOnSchematic();
			}
		}
		else
		{
			scanned = true;
		}
		WasScanned = true;
	}

	public virtual string toString()
	{
		return ToString();
	}

	public virtual void SetSchematicVisibility(bool show)
	{
		if (!(droneUIObject != null) || droneUIObject.Deactivated)
		{
			return;
		}
		if (!show && droneUIObject.Visible)
		{
			if (itemRenderer != null)
			{
				itemRenderer.enabled = false;
			}
			IsInvisibleDueToToggle = true;
			droneUIObject.HideOnSchematic();
		}
		else if (show && IsInvisibleDueToToggle)
		{
			IsInvisibleDueToToggle = false;
			droneUIObject.RevealOnSchematic();
		}
	}

	public void SetActive()
	{
		if (itemRenderer != null)
		{
			itemRenderer.material.color = ActiveColor;
		}
		if (dvOverlayObjectRenderer != null)
		{
			dvOverlayObjectMat.color = ActiveColor;
		}
		if (svOverlayObjectRenderer != null)
		{
			svOverlayObjectRenderer.material.color = ActiveColor;
		}
	}

	public void SetDamaged()
	{
		if (itemRenderer != null)
		{
			itemRenderer.material.color = DamageColor;
		}
		if (dvOverlayObjectRenderer != null)
		{
			dvOverlayObjectMat.color = DamageColor;
		}
		if (svOverlayObjectRenderer != null)
		{
			svOverlayObjectRenderer.material.color = DamageColor;
		}
	}

	protected void SetInactive()
	{
		if (itemRenderer != null)
		{
			itemRenderer.material.color = InactiveColor;
		}
		if (dvOverlayObjectRenderer != null)
		{
			dvOverlayObjectMat.color = InactiveColor;
		}
		if (svOverlayObjectRenderer != null)
		{
			svOverlayObjectRenderer.material.color = InactiveColor;
		}
	}

	protected void SetDead()
	{
		if (itemRenderer != null)
		{
			itemRenderer.material = DeathMtl;
			itemRenderer.material.color = DeadColor;
		}
		if (dvOverlayObjectRenderer != null)
		{
			dvOverlayObjectMat.color = DeadColor;
		}
		if (svOverlayObjectRenderer != null)
		{
			svOverlayObjectRenderer.material.color = DeadColor;
		}
	}

	public void Vaporize()
	{
		if (droneUIObject != null)
		{
			droneUIObject.enabled = false;
			droneUIObject.Deactivated = true;
		}
		if (dvOverlayObjectRenderer != null)
		{
			dvOverlayObjectRenderer.enabled = false;
		}
		if (svOverlayObjectRenderer != null)
		{
			svOverlayObjectRenderer.enabled = false;
		}
		itemRenderer.enabled = false;
		base.gameObject.SetActive(false);
		IsInSpace = true;
	}

	public override string ToString()
	{
		return ItemName;
	}

	public void OverrideInfoLabelPos(Vector3 pos)
	{
		if (droneUIObject == null)
		{
			Transform transform = base.transform.Find("DroneUI");
			if (transform == null && base.transform.parent != null)
			{
				transform = base.transform.parent.Find("DroneUI");
			}
			if (transform != null)
			{
				droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
				droneUIObject.InitHelpTextInfo(ItemName, _helpTextType, _shouldShowHelpTextByDefault);
			}
		}
		droneUIObject.OverrideInfoLabelPos(pos);
	}
}
