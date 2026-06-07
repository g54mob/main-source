using System;
using System.Collections;
using DV;
using DV.CabControls;
using DV.Interaction;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BoomboxInteractionController : MonoBehaviour
{
	private const string POWER_ON_SAVE_KEY = "powerOn";

	private const string RADIO_MODE_ON_SAVE_KEY = "radioMode";

	private const string VOLUME_SAVE_KEY = "vol";

	private const string ANTENNA_SAVE_KEY = "antenna";

	private const string RADIO_STATION_INDEX_SAVE_KEY = "rsIndex";

	private const string CASSETTE_PLAYLIST_INDEX_SAVE_KEY = "cpIndex";

	private const string CASSETTE_PLAYING_SAVE_KEY = "cassettePlaying";

	public GameObject powerKnob;

	public GameObject volumeKnob;

	public GameObject tuneKnob;

	public GameObject radioCasetteModeKnob;

	public GameObject cassetteDoor;

	public GameObject cassetteInteractionArea;

	public GameObject antenna;

	public GameObject noDisable;

	public VolumeAndInterferenceController volumeAndInterferenceController;

	private ControlImplBase powerKnobControl;

	private ControlImplBase volumeKnobControl;

	private SteppedJoint tuneKnobSteppedJoint;

	private ControlImplBase modeKnobControl;

	private ControlImplBase cassetteDoorControl;

	private ControlImplBase antennaControl;

	private PowerAndModeController powerAndModeController;

	private CassetteInteractionArea cassetteInteractionAreaScript;

	private CassettePlayerController cassetteController;

	private CassettePlayerButtonController buttonController;

	private RadioPlayerController radioController;

	private ItemScrolling volumeScrolling;

	private Vector3 volumeScrollingRelativeTorque = new Vector3(0f, 1.5E-05f, 0f);

	private Rigidbody volumeKnobRigidbody;

	private ItemBase boomboxItem;

	private Cassette currentCassette;

	private Coroutine initCoro;

	private Coroutine resetButtonCoro;

	private Coroutine syncInteractablesCoro;

	private Grabber grabber;

	private ItemSaveData itemSaveData;

	[NonSerialized]
	public bool initialized;

	private bool syncInteractablesFlag;

	public bool HasCassetteInserted => cassetteInteractionAreaScript.IsCassetteInserted();

	public bool HasDoorOpen => cassetteInteractionAreaScript.IsDoorOpen();

	public bool HasPlayButtonPressed => buttonController.IsPlayButtonPressed();

	public bool IsPoweredOn => powerAndModeController.IsPoweredOn();

	public bool IsInRadioMode => powerAndModeController.IsInRadioMode();

	public float AntennaPosition => antennaControl.Value;

	public event Action<float> AntennaMoved;

	public event Action<float> VolumeChanged;

	public event Action<bool> PowerSwitched;

	public event Action<bool> ModeSwitched;

	public event Action<bool> RadioTuneChanged;

	private void Awake()
	{
		powerAndModeController = new PowerAndModeController();
		cassetteInteractionAreaScript = cassetteInteractionArea.GetComponent<CassetteInteractionArea>();
		buttonController = GetComponent<CassettePlayerButtonController>();
		AudioSource musicAudioSource = volumeAndInterferenceController.musicAudioSource;
		musicAudioSource.ignoreListenerPause = true;
		cassetteController = new CassettePlayerController(noDisable, musicAudioSource, cassetteInteractionAreaScript);
		OnPauseInBackgroundPreferenceChanged();
		radioController = new RadioPlayerController(noDisable, musicAudioSource);
		itemSaveData = GetComponent<ItemSaveData>();
		itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
		itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
		itemSaveData.AfterContainerSaveDataLoaded += OnAfterMagazineDataLoaded;
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
	}

	private void OnEnable()
	{
		if (syncInteractablesFlag)
		{
			SyncInteractables();
		}
	}

	private void OnDestroy()
	{
		if (UnloadWatcher.isQuitting)
		{
			return;
		}
		CoroutineManager instance = SingletonBehaviour<CoroutineManager>.Instance;
		if (instance != null)
		{
			if (initCoro != null)
			{
				instance.Stop(initCoro);
			}
			if (syncInteractablesCoro != null)
			{
				instance.Stop(syncInteractablesCoro);
			}
		}
		SetupListeners(on: false);
		UnityEngine.Object.Destroy(noDisable);
	}

	private IEnumerator Initialize()
	{
		yield return WaitFor.EndOfFrame;
		tuneKnobSteppedJoint = tuneKnob.GetComponent<SteppedJoint>();
		modeKnobControl = radioCasetteModeKnob.GetComponent<ControlImplBase>();
		powerKnobControl = powerKnob.GetComponent<ControlImplBase>();
		volumeKnobControl = volumeKnob.GetComponent<ControlImplBase>();
		antennaControl = antenna.GetComponent<ControlImplBase>();
		volumeKnobRigidbody = volumeKnobControl.GetComponent<Rigidbody>();
		if (VRManager.IsVREnabled())
		{
			volumeScrolling = base.gameObject.AddComponent<ItemScrollingVR>();
		}
		else
		{
			volumeScrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
		}
		boomboxItem = GetComponent<ItemBase>();
		SetupListeners(on: true);
		SetupInteractableListeners(on: true);
		PowerSwitched += powerAndModeController.OnPowerSwitched;
		ModeSwitched += powerAndModeController.OnModeSwitched;
		VolumeChanged += volumeAndInterferenceController.OnVolumeChanged;
		AntennaMoved += volumeAndInterferenceController.OnAntennaChanged;
		powerAndModeController.PowerAndModeChanged += volumeAndInterferenceController.OnPowerAndModeChanged;
		powerAndModeController.PowerAndModeChanged += cassetteController.OnPowerAndModeChanged;
		buttonController.PlayPressed += cassetteController.Play;
		buttonController.StopPressed += cassetteController.StopOrEject;
		buttonController.PausePressed += cassetteController.Pause;
		buttonController.NextPressed += cassetteController.Next;
		buttonController.PreviousPressed += cassetteController.Previous;
		cassetteInteractionAreaScript.CassetteRemoved += OnCassetteRemoved;
		powerAndModeController.PowerAndModeChanged += radioController.OnPowerAndModeChanged;
		RadioTuneChanged += radioController.OnTuneChanged;
		BoomboxDisplayController component = GetComponent<BoomboxDisplayController>();
		powerAndModeController.PowerAndModeChanged += component.OnPowerAndModeChanged;
		VolumeAndInterferenceController obj = volumeAndInterferenceController;
		obj.VolumeChanged = (Action<float>)Delegate.Combine(obj.VolumeChanged, new Action<float>(component.OnVolumeChanged));
		VolumeAndInterferenceController obj2 = volumeAndInterferenceController;
		obj2.SignalChanged = (Action<float>)Delegate.Combine(obj2.SignalChanged, new Action<float>(component.OnAntennaSignalChanged));
		cassetteController.SongChanged += component.OnCassetteSongChanged;
		cassetteController.TrackIndexChanged += component.OnCassetteTrackIndexChanged;
		cassetteController.PlaybackStarted += component.OnCassetteStartedPlaying;
		cassetteController.PlaybackStopped += component.OnCassetteStoppedPlaying;
		radioController.SongChanged += component.OnRadioSongChanged;
		radioController.BufferingStarted += component.OnRadioBufferingStarted;
		radioController.BufferingEnded += component.OnRadioBufferingEnded;
		radioController.BufferingProgress += component.OnRadioBufferingProgress;
		radioController.PlaybackStopped += component.OnRadioStopped;
		radioController.StationIndexChanged += component.OnRadioStationIndexChanged;
		radioController.StationNameChanged += component.OnRadioStationNameChanged;
		initCoro = null;
		initialized = true;
	}

	private void OnCassetteRemoved()
	{
		if (cassetteController.IsPlaying)
		{
			cassetteController.StopOrEject();
		}
	}

	private void SetupListeners(bool on)
	{
		AppUtil instance = SingletonBehaviour<AppUtil>.Instance;
		if (on)
		{
			if (instance != null)
			{
				instance.GamePaused += OnGamePaused;
				instance.GameUnpaused += OnGameUnpaused;
			}
			if (!VRManager.IsVREnabled())
			{
				GamePreferences.RegisterToPreferenceUpdated(Preferences.PauseInBackground, OnPauseInBackgroundPreferenceChanged);
			}
		}
		else
		{
			if (instance != null)
			{
				instance.GamePaused -= OnGamePaused;
				instance.GameUnpaused -= OnGameUnpaused;
			}
			if (!VRManager.IsVREnabled())
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.PauseInBackground, OnPauseInBackgroundPreferenceChanged);
			}
		}
	}

	private void OnPauseInBackgroundPreferenceChanged()
	{
		if (!VRManager.IsVREnabled())
		{
			cassetteController?.OnPauseInBackgroundPreferenceChanged(GamePreferences.Get<bool>(Preferences.PauseInBackground));
		}
	}

	private void OnGamePaused()
	{
		if (!(modeKnobControl == null))
		{
			if (powerAndModeController.IsInRadioMode())
			{
				radioController.OnGamePaused();
			}
			else
			{
				cassetteController.OnGamePaused();
			}
		}
	}

	private void OnGameUnpaused()
	{
		if (powerAndModeController.IsInRadioMode())
		{
			radioController.OnGameUnpaused();
		}
		else
		{
			cassetteController.OnGameUnpaused();
		}
	}

	public void SetupInteractableListeners(bool on)
	{
		if (on)
		{
			tuneKnobSteppedJoint.PositionChanged += OnRadioTuneKnobChanged;
			modeKnobControl.ValueChanged += OnModeKnobChanged;
			powerKnobControl.ValueChanged += OnPowerKnobChanged;
			volumeKnobControl.ValueChanged += OnVolumeKnobChanged;
			volumeScrolling.Scrolled += OnScrolled;
			antennaControl.ValueChanged += OnAntennaLeverChanged;
			boomboxItem.Used += OnUsed;
		}
		else
		{
			tuneKnobSteppedJoint.PositionChanged -= OnRadioTuneKnobChanged;
			modeKnobControl.ValueChanged -= OnModeKnobChanged;
			powerKnobControl.ValueChanged -= OnPowerKnobChanged;
			volumeKnobControl.ValueChanged -= OnVolumeKnobChanged;
			volumeScrolling.Scrolled -= OnScrolled;
			antennaControl.ValueChanged -= OnAntennaLeverChanged;
			boomboxItem.Used -= OnUsed;
		}
	}

	private void OnRadioTuneKnobChanged(ValueChangedEventArgs e)
	{
		this.RadioTuneChanged?.Invoke(e.delta > 0f);
	}

	private void OnModeKnobChanged(ValueChangedEventArgs e)
	{
		this.ModeSwitched?.Invoke(e.newValue >= 0.5f);
	}

	private void OnPowerKnobChanged(ValueChangedEventArgs e)
	{
		this.PowerSwitched?.Invoke(e.newValue >= 0.5f);
	}

	private void OnVolumeKnobChanged(ValueChangedEventArgs e)
	{
		this.VolumeChanged?.Invoke(e.newValue);
	}

	private void OnScrolled(ScrollAction direction)
	{
		volumeKnobRigidbody.AddRelativeTorque(volumeScrollingRelativeTorque * direction.IsPositive().ToDir(), ForceMode.Impulse);
	}

	private void OnUsed()
	{
		if (cassetteController.IsPlaying)
		{
			buttonController.ForcePressStopExternal();
		}
		else
		{
			buttonController.ForcePressPlayExternal();
		}
	}

	private void OnAntennaLeverChanged(ValueChangedEventArgs e)
	{
		this.AntennaMoved?.Invoke(e.newValue);
	}

	private void OnItemSaveDataLoaded(JObject data)
	{
		bool? flag = data.GetBool("radioMode");
		if (flag.HasValue)
		{
			SetMode(flag.Value);
		}
		else
		{
			Debug.LogError("Unexpected state: Missing radioMode data, ignoring state load for this field.");
		}
		int? num = data.GetInt("rsIndex");
		if (num.HasValue)
		{
			OverrideLastPlayedStationIndex(num.Value);
		}
		else
		{
			Debug.LogError("Unexpected state: Missing rsIndex data, ignoring state load for this field.");
		}
		float? num2 = data.GetFloat("vol");
		if (num2.HasValue)
		{
			SetVolume(num2.Value);
		}
		else
		{
			Debug.LogError("Unexpected state: Missing vol data, ignoring state load for this field.");
		}
		float? num3 = data.GetFloat("antenna");
		if (num3.HasValue)
		{
			SetAntenna(num3.Value);
		}
		else
		{
			Debug.LogError("Unexpected state: Missing antenna data, ignoring state load for this field.");
		}
		bool? flag2 = data.GetBool("powerOn");
		if (flag2.HasValue)
		{
			SetPower(flag2.Value);
		}
		else
		{
			Debug.LogError("Unexpected state: Missing powerOn data, ignoring state load for this field.");
		}
		SyncInteractables();
	}

	private void OnAfterMagazineDataLoaded(JObject data)
	{
		if (data == null)
		{
			return;
		}
		Cassette insertedCassette = cassetteInteractionAreaScript.GetInsertedCassette();
		if (!(insertedCassette != null))
		{
			return;
		}
		int? num = data.GetInt("cpIndex");
		if (num.HasValue)
		{
			int value = num.Value;
			if (value >= 0)
			{
				insertedCassette.lastPlayedPlaylistEntry = value;
			}
		}
		else
		{
			Debug.LogError("Unexpected state: Missing cpIndex data, ignoring state load for this field.");
		}
		bool? flag = data.GetBool("cassettePlaying");
		if (flag.HasValue)
		{
			if (flag.Value)
			{
				CassettePlay();
			}
		}
		else
		{
			Debug.LogError("Unexpected state: Missing cassettePlaying data, ignoring state load for this field.");
		}
	}

	private JObject OnItemSaveDataRequested(JObject data)
	{
		data.SetBool("powerOn", IsPoweredOn);
		data.SetBool("radioMode", IsInRadioMode);
		data.SetFloat("vol", volumeAndInterferenceController.GetVolume());
		data.SetFloat("antenna", volumeAndInterferenceController.GetAntennaControlValue());
		data.SetInt("rsIndex", radioController.CurrentStationIndex);
		Cassette insertedCassette = cassetteInteractionAreaScript.GetInsertedCassette();
		if (insertedCassette != null)
		{
			if (insertedCassette.GetComponent<InventoryItemSpec>() != null)
			{
				data.SetInt("cpIndex", cassetteController.CurrentPlaylistIndex);
				data.SetBool("cassettePlaying", cassetteController.IsPlaying);
			}
			else
			{
				Debug.LogError("Unexpected state: cassette " + insertedCassette.BoomboxErrorName + " doesn't have InventoryItemSpec attached! Cassette will not be saved!");
				data.Remove("cpIndex");
				data.Remove("cassettePlaying");
			}
		}
		else
		{
			data.Remove("cpIndex");
			data.Remove("cassettePlaying");
		}
		return data;
	}

	public void SyncInteractables()
	{
		if (syncInteractablesCoro != null)
		{
			Debug.LogError("Unexpected state: SyncInteractables called while there is already ongoing syncInteractablesCoro. Ignoring request.");
		}
		else if (!base.gameObject.activeInHierarchy)
		{
			Debug.LogWarning("Attempted to call SyncInteractables while GO is disabled. Setting syncInteractablesFlag, so sync will happen when GO gets enabled.", this);
			syncInteractablesFlag = true;
		}
		else
		{
			syncInteractablesCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(SyncInteractablesCoro());
		}
	}

	private IEnumerator SyncInteractablesCoro()
	{
		while (!initialized)
		{
			yield return null;
		}
		SetupInteractableListeners(on: false);
		yield return null;
		yield return null;
		if (!base.gameObject.activeInHierarchy)
		{
			Debug.LogWarning("BoomboxInteractionController GO got disabled while in SyncInteractablesCoro. Setting syncInteractablesFlag, so sync will happen when GO gets enabled.", this);
			SetupInteractableListeners(on: true);
			syncInteractablesFlag = true;
			syncInteractablesCoro = null;
			yield break;
		}
		modeKnobControl.SetValue(powerAndModeController.IsInRadioMode() ? 1f : 0f);
		powerKnobControl.SetValue(powerAndModeController.IsPoweredOn() ? 1f : 0f);
		volumeKnobControl.SetValue(volumeAndInterferenceController.GetVolume());
		antennaControl.SetValue(volumeAndInterferenceController.GetAntennaControlValue());
		yield return WaitFor.Seconds(1f);
		SetupInteractableListeners(on: true);
		syncInteractablesFlag = false;
		syncInteractablesCoro = null;
	}

	public void SetPower(bool powerOn)
	{
		if (powerOn)
		{
			powerAndModeController.TurnOn();
		}
		else
		{
			powerAndModeController.TurnOff();
		}
	}

	public void SetMode(bool setRadioMode)
	{
		if (setRadioMode)
		{
			powerAndModeController.SwitchToRadio();
		}
		else
		{
			powerAndModeController.SwitchToCassette();
		}
	}

	public void SetVolume(float volume)
	{
		volumeAndInterferenceController.OnVolumeChanged(volume);
	}

	public void InsertCassette(Cassette cassetteToInsert, bool removeFromStorage = true)
	{
		cassetteInteractionAreaScript.RequestInsertCassette(cassetteToInsert, removeFromStorage);
	}

	public void RemoveCassette()
	{
		cassetteInteractionAreaScript.CassetteRemoveToWorld();
	}

	public void CassettePlay()
	{
		cassetteController.Play();
	}

	public void CassetteStopOrEject()
	{
		cassetteController.StopOrEject();
	}

	public void CassetteDoorClose()
	{
		cassetteInteractionAreaScript.CloseDoor();
	}

	public void CassettePause()
	{
		cassetteController.Pause();
	}

	public void CassetteNext()
	{
		cassetteController.Next();
	}

	public void CassettePrevious()
	{
		cassetteController.Previous();
	}

	public void SetAntenna(float antennaValue)
	{
		volumeAndInterferenceController.OnAntennaChanged(antennaValue);
	}

	public void UpdateRadioTune(bool next)
	{
		radioController.OnTuneChanged(next);
	}

	public void OverrideLastPlayedStationIndex(int stationIndex)
	{
		radioController.OverrideLastPlayedStationIndex(stationIndex);
	}
}
