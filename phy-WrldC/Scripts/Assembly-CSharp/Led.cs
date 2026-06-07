using UnityEngine;

public class Led : BaseComponentView
{
	private LogicIO activeInput;

	private LogicIO colorInput;

	private Renderer thisRenderer;

	private Light ledLight;

	private bool isToggleMode;

	private bool isToggleChanged;

	private bool isLedActive;

	public float CurrentIntensity { get; private set; }

	public float MaxIntensity { get; private set; }

	public int ColorIndex { get; private set; }

	private void Awake()
	{
		thisRenderer = GetComponentInChildren<Renderer>(includeInactive: true);
		SetMaterialEmission(0f, Color.black);
	}

	private void Update()
	{
		float num = activeInput.ReadAnalogSignal();
		if (isToggleMode)
		{
			if (num >= 0.5f)
			{
				if (!isToggleChanged)
				{
					isLedActive = !isLedActive;
					isToggleChanged = true;
				}
			}
			else if (isToggleMode)
			{
				isToggleChanged = false;
			}
			CurrentIntensity = (isLedActive ? 1f : 0f);
		}
		else
		{
			CurrentIntensity = num;
		}
		ColorIndex = (int)colorInput.ReadAnalogSignal();
		SetMaterialEmission(CurrentIntensity * MaxIntensity, GetColor(ColorIndex));
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		int propertyAsInt = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("led_btn_type");
		isToggleMode = propertyAsInt != 0;
		isToggleChanged = false;
		isLedActive = false;
		int propertyAsInt2 = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("led_color");
		colorInput.SetSignal(propertyAsInt2);
		MaxIntensity = base.BlockBodyView.OverridableProperties.GetPropertyAsFloat("led_intensity");
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("SmallLedLight"));
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.name = "Light";
		ledLight = gameObject.GetComponent<Light>();
		base.BlockBodyView.OnSetMaterialEvent += delegate
		{
			SetMaterialEmission(0f, Color.black);
		};
		base.gameObject.AddComponent<LedReplay>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("led_active", LogicIODirection.Input, 0f));
		colorInput = base.BlockBodyView.AddLogicIO(new LogicIO("led_color_input", LogicIODirection.Input, 0f)
		{
			IsInputWithoutKey = true,
			ValueType = LogicIOValueType.Raw
		});
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		SetMaterialEmission(0f, Color.black);
	}

	protected override void InternalInitializeModel()
	{
		base.InternalInitializeModel();
		base.BlockBodyView.OnSetMaterialEvent += delegate
		{
			SetMaterialEmission(0f, Color.black);
		};
	}

	public Color GetColor(int colorIndex)
	{
		switch (colorIndex)
		{
		case 0:
			return Color.red;
		case 1:
			return Color.green;
		case 2:
			return Color.blue;
		case 3:
			return Color.yellow;
		case 4:
			return Color.white;
		default:
			return Color.green;
		}
	}

	public void SetMaterialEmission(float intensity, Color color)
	{
		if (intensity > 0f)
		{
			thisRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
			thisRenderer.material.EnableKeyword("_EMISSION");
			thisRenderer.material.SetColor("_EmissionColor", color * intensity);
			if (ledLight != null)
			{
				ledLight.intensity = intensity;
				ledLight.color = color;
			}
		}
		else
		{
			thisRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
			thisRenderer.material.DisableKeyword("_EMISSION");
			thisRenderer.material.SetColor("_EmissionColor", Color.black);
			if (ledLight != null)
			{
				ledLight.intensity = 0f;
			}
		}
	}

	public override string GetComponentName()
	{
		return typeof(Led).Name;
	}
}
