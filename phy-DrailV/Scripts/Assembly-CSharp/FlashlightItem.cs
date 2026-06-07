using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Items;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class FlashlightItem : MonoBehaviour
{
	private const string STATE_SAVE_KEY = "On";

	private const string EMISSION_COLOR_NAME = "_EmissionColor";

	private const string GLARE_COLOR_NAME = "_TintColor";

	private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

	private static readonly int TintColor = Shader.PropertyToID("_TintColor");

	[SerializeField]
	private float perlinFlickerFactor = 10f;

	[SerializeField]
	private AnimationCurve lowPowerIntensityCurve;

	[SerializeField]
	private Material unlitMaterial;

	[SerializeField]
	private Material litMaterial;

	[SerializeField]
	private List<Renderer> lightDependentRenderers = new List<Renderer>();

	[SerializeField]
	private Renderer glareRenderer;

	[SerializeField]
	private ItemVolumetricBeamController beamController;

	private Light spotlight;

	[ColorUsage(true, true)]
	private Color originalBeamColor;

	[ColorUsage(true, true)]
	private Color originalGlassEmissionColor;

	[ColorUsage(true, true)]
	private Color originalGlareEmissionColor;

	private ItemBase item;

	private ButtonBase button;

	private Battery battery;

	private SolarPanel solarPanel;

	private BatteryConsumer batteryConsumer;

	private float noiseOffset;

	private Coroutine flickerCoro;

	private float originalLightIntensity;

	private MaterialPropertyBlock glassPropertyBlock;

	private MaterialPropertyBlock glarePropertyBlock;

	private ItemSaveData itemSaveData;

	private TrainItemActivityHandlerOverrideDynamic activityHandler;

	private bool initialized;

	private void Awake()
	{
		activityHandler = GetComponent<TrainItemActivityHandlerOverrideDynamic>();
		solarPanel = GetComponent<SolarPanel>();
		batteryConsumer = GetComponent<BatteryConsumer>();
		battery = GetComponent<Battery>();
		if (battery != null)
		{
			battery.Initialize();
		}
		if (TryGetComponent<ItemSaveData>(out itemSaveData))
		{
			itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
			itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
		}
		glassPropertyBlock = new MaterialPropertyBlock();
		glarePropertyBlock = new MaterialPropertyBlock();
		originalGlassEmissionColor = litMaterial.GetColor(EmissionColor);
		originalGlareEmissionColor = glareRenderer.sharedMaterial.GetColor(TintColor);
		noiseOffset = Random.value * 10f;
	}

	private void Start()
	{
		button = GetComponentInChildren<ButtonBase>(includeInactive: true);
		item = GetComponent<ItemBase>();
		spotlight = GetComponentInChildren<Light>(includeInactive: true);
		if (button == null || item == null || spotlight == null || beamController == null || battery == null || solarPanel == null || batteryConsumer == null)
		{
			Debug.LogError("FlashlightItem is missing at least one component. Destroying self.", base.gameObject);
			Object.Destroy(this);
			return;
		}
		originalLightIntensity = spotlight.intensity;
		originalBeamColor = beamController.GetBeamColor();
		spotlight.gameObject.SetActive(value: false);
		beamController.ToggleActive(on: false);
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
		foreach (Collider collider in componentsInChildren)
		{
			solarPanel.IgnoreSunBlocking(collider);
		}
		SetupListeners(on: true);
		initialized = true;
	}

	private void OnEnable()
	{
		if (initialized)
		{
			ToggleFlashlight(button.Value > 0f);
		}
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			button.ValueChanged += OnButtonToggled;
			item.Used += OnUsed;
			return;
		}
		if (item != null)
		{
			item.Used -= OnUsed;
		}
		if (button != null)
		{
			button.ValueChanged -= OnButtonToggled;
		}
		if (battery != null)
		{
			battery.PowerDepleted -= OnPowerDepleted;
			battery.PowerRestored -= OnPowerRestored;
			battery.LowPower -= OnLowPower;
			battery.NominalPower -= OnNominalPower;
		}
		if (itemSaveData != null)
		{
			itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
			itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
		}
	}

	private void OnItemSaveDataLoaded(JObject data)
	{
		if (data == null)
		{
			Debug.LogError("Failed to load FlashlightItem save data. Using default.", this);
			battery.LoadSavedState(null);
			return;
		}
		if (!initialized)
		{
			Debug.LogError("Could not load FlashlightItem data because it was not initialized. This should not happen.", base.gameObject);
			return;
		}
		battery.LoadSavedState(data);
		bool? flag = data.GetBool("On");
		bool valueOrDefault = flag == true;
		if (flag.HasValue && valueOrDefault)
		{
			button.SetValue(1f);
			ToggleFlashlight(base.gameObject.activeInHierarchy);
		}
	}

	private JObject OnItemSaveDataRequested(JObject data)
	{
		if (button.Value > 0.5f)
		{
			data.SetBool("On", value: true);
		}
		else
		{
			data.Remove("On");
		}
		battery.SaveState(data);
		return data;
	}

	private void OnLowPower()
	{
		ToggleFlicker(on: true);
	}

	private void ToggleFlicker(bool on)
	{
		if (flickerCoro != null)
		{
			StopCoroutine(flickerCoro);
			flickerCoro = null;
		}
		if (on)
		{
			flickerCoro = StartCoroutine(LowPowerFlicker());
		}
	}

	private IEnumerator LowPowerFlicker()
	{
		while (true)
		{
			float num = lowPowerIntensityCurve.Evaluate(battery.CurrentPower / 5f);
			float num2 = Mathf.Clamp01(Mathf.Lerp(-0.3f, 3f, Mathf.PerlinNoise(noiseOffset, Time.time * perlinFlickerFactor)));
			float num3 = num * num2;
			spotlight.intensity = originalLightIntensity * num3;
			beamController.SetBeamColor(Color.Lerp(Color.clear, originalBeamColor, num3));
			Color color = Color.Lerp(Color.clear, originalGlassEmissionColor, num3);
			Color value = Color.Lerp(Color.clear, originalGlareEmissionColor, num3);
			SetGlassMaterialAndColor(litMaterial, color);
			glarePropertyBlock.SetColor(TintColor, value);
			glareRenderer.SetPropertyBlock(glarePropertyBlock);
			yield return null;
		}
	}

	private void OnNominalPower()
	{
		ToggleFlicker(on: false);
		spotlight.intensity = originalLightIntensity;
		beamController.SetBeamColor(originalBeamColor);
		SetGlassMaterialAndColor(litMaterial, originalGlassEmissionColor);
		glarePropertyBlock.SetColor(TintColor, originalGlareEmissionColor);
		glareRenderer.SetPropertyBlock(glarePropertyBlock);
	}

	private void OnButtonToggled(ValueChangedEventArgs args)
	{
		if (base.gameObject.activeInHierarchy)
		{
			bool flag = args.newValue > 0f;
			ToggleFlashlight(flag);
		}
	}

	private void ToggleFlashlight(bool on)
	{
		ToggleFlicker(on: false);
		battery.PowerDepleted -= OnPowerDepleted;
		battery.PowerRestored -= OnPowerRestored;
		battery.LowPower -= OnLowPower;
		battery.NominalPower -= OnNominalPower;
		if (on)
		{
			battery.PowerDepleted += OnPowerDepleted;
			battery.PowerRestored += OnPowerRestored;
			battery.LowPower += OnLowPower;
			battery.NominalPower += OnNominalPower;
		}
		else
		{
			SetGlassMaterialAndColor(unlitMaterial, originalGlassEmissionColor);
		}
		batteryConsumer.TogglePowerConsumption(on);
		bool flag = on && !battery.Depleted;
		spotlight.gameObject.SetActive(flag);
		beamController.ToggleActive(flag);
		if (flag)
		{
			if (battery.ProvidesNominalPower)
			{
				OnNominalPower();
			}
			else
			{
				OnLowPower();
			}
		}
		activityHandler.ToggleRange(flag);
	}

	private void OnPowerRestored()
	{
		spotlight.gameObject.SetActive(value: true);
		beamController.ToggleActive(on: true);
	}

	private void OnPowerDepleted()
	{
		ToggleFlicker(on: false);
		spotlight.gameObject.SetActive(value: false);
		beamController.ToggleActive(on: false);
		SetGlassMaterialAndColor(unlitMaterial, originalGlassEmissionColor);
	}

	private void OnUsed()
	{
		button.Use();
	}

	private void SetGlassMaterialAndColor(Material material, Color color)
	{
		glassPropertyBlock.SetColor(EmissionColor, color);
		foreach (Renderer lightDependentRenderer in lightDependentRenderers)
		{
			lightDependentRenderer.sharedMaterial = material;
			lightDependentRenderer.SetPropertyBlock(glassPropertyBlock);
		}
	}
}
