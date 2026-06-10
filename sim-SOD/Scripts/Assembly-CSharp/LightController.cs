using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
	public bool isSetup;

	[Header("Location")]
	public NewRoom room;

	[NonSerialized]
	public Interactable interactable;

	[Header("Profile")]
	public LightingPreset preset;

	[Header("Light")]
	public bool isOn;

	public bool isUnscrewed;

	public bool closedBreaker;

	public bool isCulled;

	public float lightState;

	public Light lightComponent;

	public HDAdditionalLightData hdrpLightData;

	[Tooltip("Colour of the light")]
	[Space(7f)]
	public Color lightColour;

	[Tooltip("If flicker is present, flicker to this colour")]
	private Color flickerColour;

	[Tooltip("The model's emissive colour (instaned materials only)")]
	private Color emissionColour;

	[Tooltip("Intensity of the light")]
	public float intensity;

	[Tooltip("A timer that dictates the minimum amount of time this light can be unculled. Prevents flickering with frequent raycast checks.")]
	public float cullingTimer;

	[Tooltip("Change material on this model")]
	[Header("Model")]
	public MeshRenderer rend;

	[Tooltip("The material of the parent model: For altering emission")]
	public Material mat;

	[Header("Voumetrics")]
	public bool useVolumetrics;

	[Header("Shadows")]
	public bool useShadows;

	[Tooltip("Does this light flicker?")]
	[Header("Flicker")]
	public bool flicker;

	[Tooltip("When flickering, use this multiplier on the flicker colour to determin the actual colour (basically a darker version of flicker colour)")]
	public float flickerColourMultiplier;

	public float pulseSpeed;

	private float flickerState;

	private bool flickerSwitch;

	private bool flickerInterval;

	private float interval;

	private float intervalTime;

	[Header("Ceiling Fan")]
	public Transform ceilingFan;

	public bool ceilingFanOn;

	public float ceilingFanSpeed;

	public void Setup(NewRoom newRoom, Interactable newInteractable, Interactable.LightConfiguration configData, LightingPreset newPreset, int lightZoneSize = -1, Transform newCeilingFan = null)
	{
	}

	public void UpdateFadeDistances()
	{
	}

	public void SetColour(Color newCol)
	{
	}

	public void SetIntensity(float newInt)
	{
	}

	public void SetShadows(bool val)
	{
	}

	public void SetVolumetrics(bool val)
	{
	}

	public void SetVolumentricAtmosphere(float newVal)
	{
	}

	public void SetFlicker(bool val)
	{
	}

	private void Update()
	{
	}

	public void SetOn(bool val, bool forceInstant = false)
	{
	}

	public void SetUnscrewed(bool val, bool forceInstance = false)
	{
	}

	public void SetClosedBreaker(bool val, bool forceInstance = false)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void UpdateLight()
	{
	}

	public void SetCulled(bool val, bool respectTimer)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CullToggle()
	{
	}

	private void OnDestroy()
	{
	}
}
