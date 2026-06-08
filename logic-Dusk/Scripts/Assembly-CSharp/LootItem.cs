using UnityEngine;

public class LootItem : RoomItem
{
	public bool collected;

	public Color HiddenLootColor = Color.white;

	public override string ItemName
	{
		get
		{
			return "Scrap";
		}
	}

	public bool DefaultVisible { get; set; }

	protected override HelpTextTypeEnum _helpTextType
	{
		get
		{
			return HelpTextTypeEnum.Ration;
		}
	}

	public override bool Show
	{
		get
		{
			return Explored && !collected;
		}
		set
		{
			base.Show = value;
		}
	}

	public override bool Explored
	{
		get
		{
			if (base.roomLocation != null)
			{
				return (DefaultVisible && base.roomLocation.isExplored) || base.roomLocation.isScanned;
			}
			return true;
		}
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
		base.Start();
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			itemRenderer.enabled = Explored;
		}
		else
		{
			itemRenderer.enabled = false;
		}
		Material material = null;
		material = (DefaultVisible ? ResourceManager.GetAsset<Material>("LootFixedMtl") : ResourceManager.GetAsset<Material>("LootMtl"));
		if (material != null)
		{
			itemRenderer.material = material;
		}
		if (!DefaultVisible)
		{
			DisableUI();
		}
		if (!DefaultVisible && HiddenLootColor != Color.white)
		{
			dvOverlayObjectRenderer.material.color = HiddenLootColor;
			svOverlayObjectRenderer.material.color = HiddenLootColor;
		}
		string text = "default";
		SkinEnum currentSkin = GlobalSettings.GameState.CurrentSkin;
		if (currentSkin == SkinEnum.Halloween)
		{
			text = "halloween";
		}
		Texture2D dvTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/droneview/ration_vector");
		Texture2D svTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/schematic/rationSchematic");
		droneUIObject.SetTextureOnObject(0, dvTexture, 0, svTexture);
		droneUIObject.AdjustInfoLabelPos(-0.5f, -1f);
		droneUIObject.AddInfoCommand("gather");
	}

	public new void OnDestroy()
	{
		if (!DefaultVisible)
		{
			ResourceManager.UnloadAsset("LootMtl");
		}
		else
		{
			ResourceManager.UnloadAsset("LootFixedMtl");
		}
	}

	public void DisableUI()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = true;
		}
	}

	public void EnableUI()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = false;
		}
		SetSchematicVisibility(GameplayManager.Instance.showSchematicToggleItems);
	}

	public bool CanGather()
	{
		if (droneUIObject != null)
		{
			return !droneUIObject.Deactivated && droneUIObject.Visible;
		}
		return false;
	}

	public override void UpdateCameraView()
	{
		if (!collected)
		{
			if (itemRenderer != null)
			{
				if (GlobalSettings.cameraMode == CameraMode.Drone)
				{
					itemRenderer.enabled = Explored;
				}
				else
				{
					itemRenderer.enabled = false;
				}
			}
			if (!DefaultVisible && (droneUIObject == null || !droneUIObject.Visible))
			{
				DisableUI();
			}
			else
			{
				EnableUI();
			}
		}
		else
		{
			itemRenderer.enabled = false;
			if (dvOverlayObjectRenderer != null)
			{
				dvOverlayObjectRenderer.enabled = false;
			}
			if (svOverlayObjectRenderer != null)
			{
				svOverlayObjectRenderer.enabled = false;
			}
		}
	}

	public void Collect()
	{
		collected = true;
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
	}
}
