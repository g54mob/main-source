using UnityEngine;

public class DropableItem : MonoBehaviour, IToggleVisibilityInSchematic, IUpdateCameraView
{
	public Material DeathMtl;

	public Color ActiveColor = Color.white;

	public Color InactiveColor = Color.white;

	public Color DamageColor = Color.white;

	public Color DeadColor = Color.grey;

	protected DroneUIObject droneUIObject;

	protected GameObject dvOverlayObject;

	protected Material dvOverlayObjectMat;

	protected GameObject svOverlayObject;

	protected Material svOverlayObjectMat;

	private bool _isActive;

	protected Material thisMat;

	public virtual DropItemType DropType
	{
		get
		{
			return DropItemType.None;
		}
	}

	public IDropperUpgrade DroppingUpgrade { get; set; }

	public DroneItemDropper DroneItemDropperUpgrade { get; set; }

	public bool Destroyed { get; protected set; }

	public bool IsConnectedToBoardingShip { get; set; }

	public bool IsActive
	{
		get
		{
			return _isActive;
		}
	}

	public bool Deactivated { get; private set; }

	public bool IsInSpace { get; private set; }

	public ModificationStorageIdEnum ParentAppliedModifications { get; set; }

	public bool IsInvisibleDueToToggle { get; set; }

	protected virtual void Initialize()
	{
		Deactivated = false;
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
		GetComponent<Renderer>().material.color = ActiveColor;
		if (dvOverlayObject != null)
		{
			dvOverlayObjectMat = dvOverlayObject.GetComponent<Renderer>().material;
			dvOverlayObjectMat.color = ActiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObjectMat = svOverlayObject.GetComponent<Renderer>().material;
			svOverlayObjectMat.color = ActiveColor;
		}
		thisMat = GetComponent<Renderer>().material;
		if (GameplayManager.Instance != null && !GameplayManager.Instance.showSchematicToggleItems)
		{
			droneUIObject.HideOnSchematic();
			GetComponent<Renderer>().enabled = false;
			IsInvisibleDueToToggle = true;
		}
	}

	public virtual void Start()
	{
		Initialize();
	}

	protected virtual void OnDestroy()
	{
	}

	protected virtual void Update()
	{
		if (IsConnectedToBoardingShip)
		{
			thisMat = ResourceManager.GenericTransparantDiffuseMaterial;
			Color color = thisMat.color;
			color.a = DungeonManager.Instance.BoardingVessel.ShipAlpha;
			thisMat.color = color;
			droneUIObject.SetOverlayAlpha(DungeonManager.Instance.BoardingVessel.ShipAlpha);
		}
	}

	public virtual void SetDeactivated()
	{
		_isActive = false;
		Deactivated = true;
		if (!GameObjectPool.Instance.PushObject(base.gameObject))
		{
			GetComponent<Renderer>().enabled = false;
			if (droneUIObject != null)
			{
				droneUIObject.Deactivated = true;
			}
			if (dvOverlayObject != null)
			{
				dvOverlayObject.GetComponent<Renderer>().enabled = false;
			}
			if (svOverlayObject != null)
			{
				svOverlayObject.GetComponent<Renderer>().enabled = false;
			}
		}
	}

	protected virtual void SetActive()
	{
		_isActive = true;
		thisMat.color = ActiveColor;
		if (dvOverlayObject != null)
		{
			dvOverlayObjectMat.color = ActiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObjectMat.color = ActiveColor;
		}
	}

	protected virtual void SetInactive()
	{
		_isActive = false;
		GetComponent<Renderer>().material.color = InactiveColor;
		if (dvOverlayObject != null)
		{
			dvOverlayObjectMat.color = InactiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObjectMat.color = InactiveColor;
		}
	}

	protected void SetDead()
	{
		_isActive = false;
		if (GetComponent<Renderer>() != null)
		{
			GetComponent<Renderer>().material = DeathMtl;
			GetComponent<Renderer>().material.color = DeadColor;
			if (dvOverlayObject != null)
			{
				dvOverlayObjectMat.color = DeadColor;
			}
			if (svOverlayObject != null)
			{
				svOverlayObjectMat.color = DeadColor;
			}
		}
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

	public virtual void UpdateCameraView()
	{
	}

	public virtual void Vaporize()
	{
		if (!GameObjectPool.Instance.PushObject(base.gameObject))
		{
			GetComponent<Renderer>().enabled = false;
			base.gameObject.GetComponent<Renderer>().enabled = false;
			base.gameObject.SetActive(false);
			Object.Destroy(base.gameObject);
			droneUIObject.Deactivate();
			Object.Destroy(droneUIObject.gameObject);
		}
		IsInSpace = true;
	}
}
