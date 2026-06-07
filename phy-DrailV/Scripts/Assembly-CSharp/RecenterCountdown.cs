using DV;
using DV.Utils;
using TMPro;
using UnityEngine;
using VRTK;

public class RecenterCountdown : MonoBehaviour
{
	private const string LABEL_PRESS_TRIGGER = "Press <color=#F29839>Trigger</color> to recenter.";

	private const string LABEL_PRESS_TRIGGER_FORCED = "Camera recentering is required.\r\n\r\nPress <color=#F29839>Trigger</color> to continue.";

	private const string LABEL_LOOK_STRAIGHT_AHEAD = "Look straight ahead";

	private const string LABEL_MOVE_TO_CAB_CENTER = "Walk to where cab center should be";

	private const string LABEL_RECENTERING = "Recentering in {0}";

	private const string RECENTER_FLOATIE_NAME = "[recenter_floatie]";

	public float seatedCountdownStartNumber = 4f;

	public float roomscaleCountdownStartNumber = 7f;

	public float countdownSpeedupFactor = 2f;

	public bool forced;

	private TextMeshProUGUI triggerLabel;

	private TextMeshProUGUI facingLabel;

	private TextMeshProUGUI countdownLabel;

	private float startTime;

	private bool calledDestroy;

	private bool calledRecenter;

	private bool isPaused;

	private bool canStartTimer;

	private static Floatie activeFloatie;

	private void Start()
	{
		Transform transform = base.transform.Find("Image");
		triggerLabel = transform.Find("trigger").GetComponent<TextMeshProUGUI>();
		facingLabel = transform.Find("facing").GetComponent<TextMeshProUGUI>();
		countdownLabel = transform.Find("countdown").GetComponent<TextMeshProUGUI>();
		triggerLabel.text = (forced ? "Camera recentering is required.\r\n\r\nPress <color=#F29839>Trigger</color> to continue." : "Press <color=#F29839>Trigger</color> to recenter.");
		countdownLabel.text = string.Empty;
		facingLabel.text = string.Empty;
		SetupControllerListeners(on: true);
		SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
			SetupControllerListeners(on: false);
		}
	}

	private void OnGamePaused()
	{
		SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnGamePaused;
		isPaused = true;
		Floatie component = GetComponent<Floatie>();
		component.waitBeforeDestroy = 0f;
		component.Destroy();
	}

	private void SetupControllerListeners(bool on)
	{
		VRTK_ControllerEvents componentInChildren = VRTK_DeviceFinder.GetControllerLeftHand(getActual: true).GetComponentInChildren<VRTK_ControllerEvents>(includeInactive: true);
		VRTK_ControllerEvents componentInChildren2 = VRTK_DeviceFinder.GetControllerRightHand(getActual: true).GetComponentInChildren<VRTK_ControllerEvents>(includeInactive: true);
		if (on)
		{
			componentInChildren.TriggerPressed += OnTriggerPressed;
			componentInChildren2.TriggerPressed += OnTriggerPressed;
		}
		else
		{
			componentInChildren.TriggerPressed -= OnTriggerPressed;
			componentInChildren2.TriggerPressed -= OnTriggerPressed;
		}
	}

	private void OnTriggerPressed(object sender, ControllerInteractionEventArgs e)
	{
		triggerLabel.text = string.Empty;
		facingLabel.text = "Look straight ahead";
		countdownLabel.text = $"Recentering in {Mathf.Clamp(Mathf.Ceil(seatedCountdownStartNumber), 0f, 99f)}";
		canStartTimer = true;
		startTime = Time.timeSinceLevelLoad;
		SetupControllerListeners(on: false);
	}

	private void Update()
	{
		if (isPaused || !canStartTimer)
		{
			return;
		}
		float num = (Time.timeSinceLevelLoad - startTime) * countdownSpeedupFactor;
		string text;
		float num2;
		if (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType))
		{
			text = "Look straight ahead";
			num2 = seatedCountdownStartNumber;
		}
		else
		{
			text = "Walk to where cab center should be";
			num2 = roomscaleCountdownStartNumber;
		}
		facingLabel.text = text;
		countdownLabel.text = $"Recentering in {Mathf.Clamp(Mathf.Ceil(num2 - num), 0f, 99f)}";
		if (!calledDestroy && num > num2 - 0.4f)
		{
			calledDestroy = true;
			GetComponent<Floatie>().Destroy();
		}
		if (!calledRecenter && num > num2)
		{
			calledRecenter = true;
			if (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType))
			{
				SingletonBehaviour<VRManager>.Instance.ResetSeatedPosition();
			}
		}
	}

	public static void RequestRecenter(bool forced)
	{
		if (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType))
		{
			if (activeFloatie != null)
			{
				activeFloatie.Destroy();
			}
			activeFloatie = Floatie.Spawn(Resources.Load("[recenter_floatie]") as GameObject);
			if (forced)
			{
				activeFloatie.GetComponent<RecenterCountdown>().forced = true;
			}
			activeFloatie.transform.SetParent(VRTK_DeviceFinder.PlayAreaTransform());
		}
	}
}
