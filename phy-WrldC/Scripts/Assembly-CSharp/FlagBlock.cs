using UnityEngine;

public class FlagBlock : BaseComponentView
{
	private SkinnedMeshRenderer skinnedMesh;

	private Cloth flagCloth;

	private Texture flagTexture;

	private Color flagColor;

	private OverridablePropertyModel flagPaintProperty;

	private OverridablePropertyModel flagColorProperty;

	private CustomBlockMaterial customBlockMaterial;

	private void Awake()
	{
		if (skinnedMesh == null)
		{
			skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
		}
		if (flagCloth == null)
		{
			flagCloth = GetComponentInChildren<Cloth>();
		}
		customBlockMaterial = skinnedMesh.gameObject.GetComponent<CustomBlockMaterial>();
		if (customBlockMaterial == null)
		{
			customBlockMaterial = skinnedMesh.gameObject.AddComponent<CustomBlockMaterial>();
		}
		VisualEffectStylesData.CustomBlockMaterialModel customBlockMaterialModel = GameManager.Instance.GameStylesData.visualEffectStylesData.GetCustomBlockMaterialModel("flag_block");
		customBlockMaterial.SetMaterials(customBlockMaterialModel.mainNormal, customBlockMaterialModel.mainTransparent, customBlockMaterialModel.placeholderGreen, customBlockMaterialModel.placeholderRed);
		flagCloth.enabled = false;
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		flagCloth.enabled = true;
	}

	private void FlagInitilize()
	{
		base.BlockBodyView.OnSetMaterialEvent += delegate(bool isMainMaterial)
		{
			SetFlagTransparency(isMainMaterial ? 1f : 0.333f);
		};
		base.BlockBodyView.OnSetMaterialTransparencyEvent += SetFlagTransparency;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		FlagInitilize();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		FlagPropertyConfiguration();
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		FlagPropertyReset();
		flagCloth.enabled = false;
	}

	protected override void InternalInitializeModel()
	{
		base.InternalInitializeModel();
		FlagInitilize();
	}

	protected override void SetModelConfiguration()
	{
		base.SetModelConfiguration();
		FlagPropertyConfiguration();
	}

	protected override void InternalResetModel()
	{
		base.InternalResetModel();
		FlagPropertyReset();
	}

	private void FlagPropertyConfiguration()
	{
		flagPaintProperty = base.ComponentModel.ParentBlockBodyModel.GetOverridableProperty("flag_paint");
		SetFlagTexture(flagPaintProperty);
		flagPaintProperty.NotifyChangeEvent += FlagPaintEventHandler;
		flagColorProperty = base.ComponentModel.ParentBlockBodyModel.GetOverridableProperty("flag_color");
		SetFlagColor(flagColorProperty);
		flagColorProperty.NotifyChangeEvent += FlagColorEventHandler;
	}

	private void FlagPropertyReset()
	{
		if (flagPaintProperty != null)
		{
			flagPaintProperty.NotifyChangeEvent -= FlagPaintEventHandler;
		}
		if (flagColorProperty != null)
		{
			flagColorProperty.NotifyChangeEvent -= FlagColorEventHandler;
		}
		flagPaintProperty = null;
		flagColorProperty = null;
		flagTexture = null;
		flagColor = Color.white;
		skinnedMesh.material = customBlockMaterial.Normal;
		skinnedMesh.material.SetTexture("_MainTex", null);
		skinnedMesh.material.SetColor("_Color", Color.white);
	}

	private void FlagPaintEventHandler(string eventName, object[] data)
	{
		if (eventName == "OverridablePropertyModel.ValueChangeEvent")
		{
			OverridablePropertyModel overridablePropertyModel = data[0] as OverridablePropertyModel;
			SetFlagTexture(overridablePropertyModel);
		}
	}

	private void FlagColorEventHandler(string eventName, object[] data)
	{
		if (eventName == "OverridablePropertyModel.ValueChangeEvent")
		{
			OverridablePropertyModel overridablePropertyModel = data[0] as OverridablePropertyModel;
			SetFlagColor(overridablePropertyModel);
		}
	}

	private void SetFlagTexture(OverridablePropertyModel flagTypeProperty)
	{
		if (flagTypeProperty is ComboBoxPropertyModel comboBoxPropertyModel)
		{
			flagTexture = GameManager.Instance.FlagTextureCollection.GetTexture(comboBoxPropertyModel.Value);
			skinnedMesh.material.SetTexture("_MainTex", flagTexture);
		}
	}

	private void SetFlagColor(OverridablePropertyModel flagTypeProperty)
	{
		if (flagTypeProperty is ColorPickerPropertyModel colorPickerPropertyModel)
		{
			flagColor = Util.HexToColor(colorPickerPropertyModel.Value);
			skinnedMesh.material.SetColor("_Color", flagColor);
		}
	}

	private void SetFlagTransparency(float value)
	{
		skinnedMesh.material = ((value >= 1f) ? customBlockMaterial.Normal : customBlockMaterial.Transparent);
		skinnedMesh.material.SetFloat("_IntensityTransparentMap", 1f - value);
		skinnedMesh.material.SetTexture("_MainTex", flagTexture);
		skinnedMesh.material.SetColor("_Color", flagColor);
	}

	public override string GetComponentName()
	{
		return typeof(FlagBlock).Name;
	}
}
