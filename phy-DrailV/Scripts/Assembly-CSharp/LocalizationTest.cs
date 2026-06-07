using DV;
using DV.Damage;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationTest : MonoBehaviour
{
	public WeatherPresetManager weatherPresetManager;

	[Header("Pit stop")]
	public GameObject pitStopGO;

	public Button carInPitStopButton;

	public Button carNotInPitStopButton;

	public Button giveLicenseButton;

	public Button damageWheelsButton;

	private Vector3? pitStopOriginalPos;

	private void Awake()
	{
		AStartGameData.carsAndJobsLoadingFinished = true;
		SingletonBehaviour<LicenseManager>.Instance.AcquireGeneralLicense(GeneralLicenseType.DE6.ToV2());
		Globals.G.GameParams.CommsRadioCheatMode = true;
		SetupListeners();
	}

	private void Start()
	{
		weatherPresetManager.SetTimeOfDay(0.5f);
		weatherPresetManager.DayLengthInMinutes.EngageOverride(9999f);
		WeatherDriver component = weatherPresetManager.GetComponent<WeatherDriver>();
		component.overriddenPoint = Vector2.zero;
		component.overridePoint = true;
	}

	private void SetupListeners()
	{
		carInPitStopButton.onClick.AddListener(OnCarInPitStopClicked);
		carNotInPitStopButton.onClick.AddListener(OnCarNotInPitStopClicked);
		giveLicenseButton.onClick.AddListener(OnGiveLicenseButtonClicked);
		damageWheelsButton.onClick.AddListener(OnDamageWheelsClicked);
	}

	private void OnCarInPitStopClicked()
	{
		if (pitStopOriginalPos.HasValue)
		{
			pitStopGO.transform.position = pitStopOriginalPos.Value;
		}
	}

	private void OnCarNotInPitStopClicked()
	{
		if (!pitStopOriginalPos.HasValue)
		{
			pitStopOriginalPos = pitStopGO.transform.position;
		}
		pitStopGO.transform.position = pitStopOriginalPos.Value + Vector3.forward * 50f;
	}

	private void OnGiveLicenseButtonClicked()
	{
		SingletonBehaviour<LicenseManager>.Instance.AcquireGeneralLicense(GeneralLicenseType.ManualService.ToV2());
	}

	private void OnDamageWheelsClicked()
	{
		Object.FindObjectOfType<DamageController>().wheels.ApplyDamage(100f);
	}
}
