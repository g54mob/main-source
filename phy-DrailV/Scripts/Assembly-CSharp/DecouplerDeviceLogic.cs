using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

public class DecouplerDeviceLogic : MonoBehaviour
{
	public const float COUPLER_RADAR_SCAN_RATE = 7f;

	public GameObject LCDPrefab;

	public GameObject coupleButton;

	public GameObject uncoupleButton;

	[Header("Debug (read-only)")]
	public int numCarsFront;

	public int numCarsRear;

	public int blinkFlagsFront;

	public int blinkFlagsRear;

	public Coupler frontCouplerInRange;

	public Coupler rearCouplerInRange;

	public float frontCouplerDistance;

	public float rearCouplerDistance;

	public bool canUncoupleFront;

	public bool canUncoupleRear;

	public int selectedCoupler;

	[Tooltip("Changing this from inspector might not work correctly")]
	[Header("LCD Notification")]
	public string notificationText = string.Empty;

	public float notificationBeepDelay = 2f;

	public float notificationTimeRemaining;

	public AudioClip beepSound;

	public Transform soundOrigin;

	private TrainCar car;

	private int nextAssignmentToDisplay = 1;

	private Queue<KeyValuePair<string, float>> notificationQueue = new Queue<KeyValuePair<string, float>>();

	private bool wasDerailed;

	private bool notifiedAboutBadCoupling;

	private void Start()
	{
		car = TrainCar.Resolve(base.gameObject);
		SetupComponents();
		StartCoroutine(ScanForCouplersInRange(0.4f));
		StartCoroutine(UpdateNotification(0.4f));
		StartCoroutine(UpdateBlinkFlags(0.05f));
		StartCoroutine(WireUpButtons(1f));
		StartCoroutine(CheckAirHose(2f));
		CouplerBreakDetector.OnCoupleBreak += NotifyAboutBrokenCouple;
	}

	public void OnMissionWin()
	{
		DisplayNotification("    Good job     ");
	}

	public void OnMissionLose()
	{
		DisplayNotification("  You are fired  ");
	}

	public void OnGoalAchieved()
	{
		DisplayNotification("Assignment " + nextAssignmentToDisplay + " OK", 7f);
		nextAssignmentToDisplay++;
	}

	public void OnGoalFailed()
	{
		DisplayNotification("Assignment " + nextAssignmentToDisplay + " FAIL", 7f);
		nextAssignmentToDisplay++;
	}

	private void SetupComponents()
	{
		Transform transform = base.transform.Find("lcd anchor");
		if (!transform)
		{
			Debug.LogError("DecouplerDeviceLogic must have a child named 'lcd anchor'", this);
		}
		GameObject obj = Object.Instantiate(LCDPrefab, base.transform);
		obj.transform.localPosition = transform.localPosition;
		obj.transform.localRotation = transform.localRotation;
		Object.Destroy(transform.gameObject);
		DecouplerIndicatorRowDriver decouplerIndicatorRowDriver = obj.AddComponent<DecouplerIndicatorRowDriver>();
		DecouplerTextRowDriver decouplerTextRowDriver = obj.AddComponent<DecouplerTextRowDriver>();
		decouplerIndicatorRowDriver.device = this;
		decouplerTextRowDriver.device = this;
	}

	private IEnumerator WireUpButtons(float timeout)
	{
		yield return WaitFor.Seconds(timeout);
		coupleButton.GetComponent<ButtonBase>().Used += Couple;
		uncoupleButton.GetComponent<ButtonBase>().Used += Uncouple;
	}

	private IEnumerator CheckAirHose(float timeout)
	{
		WaitForSeconds wait = WaitFor.Seconds(timeout);
		while (true)
		{
			yield return wait;
			bool flag = true;
			if (!flag && !notifiedAboutBadCoupling)
			{
				string text = "";
				notifiedAboutBadCoupling = true;
				DisplayNotification(text, 2f);
			}
			else if (flag || notificationQueue.Count == 0)
			{
				notifiedAboutBadCoupling = false;
			}
		}
	}

	private IEnumerator UpdateNotification(float timeout)
	{
		if (!beepSound)
		{
			Debug.LogWarning("DecouplerDeviceLogic has no sound assigned", base.gameObject);
		}
		float notificationBeepTimeRemaining = 0f;
		float notificationLastUpdateTime = Time.timeSinceLevelLoad;
		WaitForSeconds wait = WaitFor.Seconds(timeout);
		while (true)
		{
			float num = Time.timeSinceLevelLoad - notificationLastUpdateTime;
			if (notificationTimeRemaining <= 0f)
			{
				if (notificationQueue.Count == 0)
				{
					notificationText = string.Empty;
				}
				else
				{
					KeyValuePair<string, float> keyValuePair = notificationQueue.Dequeue();
					notificationText = keyValuePair.Key;
					notificationTimeRemaining = keyValuePair.Value;
				}
			}
			else
			{
				notificationTimeRemaining -= num;
			}
			if (notificationBeepTimeRemaining <= 0f)
			{
				notificationBeepTimeRemaining = notificationBeepDelay;
				if (!SingletonBehaviour<AudioManager>.Instance)
				{
					Debug.LogWarning("DecouplerDeviceLogic couldn't find an AudioManager instance, will not play sound", this);
				}
				else if (!string.IsNullOrEmpty(notificationText))
				{
					beepSound.Play(soundOrigin.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), SingletonBehaviour<AudioManager>.Instance.cabGroup);
				}
			}
			else
			{
				notificationBeepTimeRemaining -= num;
			}
			notificationLastUpdateTime = Time.timeSinceLevelLoad;
			yield return wait;
		}
	}

	private void DisplayNotification(string text, float durationSeconds = 15f)
	{
		if (text.Length > 17)
		{
			Debug.LogWarning(string.Format("Text passed to {0} is too long (\"{1}\", {2} chars)", "DecouplerDeviceLogic", text, text.Length), this);
		}
		notificationQueue.Enqueue(new KeyValuePair<string, float>(text, durationSeconds));
	}

	private IEnumerator ScanForCouplersInRange(float timeBetweenScans)
	{
		WaitForSeconds wait = WaitFor.Seconds(timeBetweenScans);
		while (true)
		{
			yield return wait;
			Coupler lastCoupler = CouplerLogic.GetLastCoupler(car.frontCoupler);
			Coupler lastCoupler2 = CouplerLogic.GetLastCoupler(car.rearCoupler);
			frontCouplerInRange = lastCoupler.GetFirstCouplerInRange(7f);
			rearCouplerInRange = lastCoupler2.GetFirstCouplerInRange(7f);
			frontCouplerDistance = (frontCouplerInRange ? Vector3.Magnitude(lastCoupler.transform.position - frontCouplerInRange.transform.position) : float.PositiveInfinity);
			rearCouplerDistance = (rearCouplerInRange ? Vector3.Magnitude(lastCoupler2.transform.position - rearCouplerInRange.transform.position) : float.PositiveInfinity);
		}
	}

	private IEnumerator UpdateBlinkFlags(float iterationTimeout)
	{
		WaitForSeconds pause = WaitFor.Seconds(iterationTimeout);
		while (true)
		{
			yield return pause;
		}
	}

	private void Couple()
	{
		if ((bool)frontCouplerInRange && frontCouplerDistance <= 1.5f)
		{
			frontCouplerInRange.TryCouple();
			Anal.Coupled();
		}
		else if ((bool)rearCouplerInRange && rearCouplerDistance <= 1.5f)
		{
			rearCouplerInRange.TryCouple();
			Anal.Coupled();
		}
	}

	private void Uncouple()
	{
		Coupler nthCouplerFrom;
		if (selectedCoupler > 0)
		{
			nthCouplerFrom = CouplerLogic.GetNthCouplerFrom(car.frontCoupler, selectedCoupler - 1);
		}
		else
		{
			if (selectedCoupler >= 0)
			{
				return;
			}
			nthCouplerFrom = CouplerLogic.GetNthCouplerFrom(car.rearCoupler, -selectedCoupler - 1);
		}
		nthCouplerFrom.Uncouple();
		Anal.Decoupled();
	}

	private void Update()
	{
		UpdateValues();
		UpdateKeyboardControls();
	}

	private void UpdateValues()
	{
		numCarsFront = 0;
		numCarsRear = 0;
		int min = -numCarsRear;
		int max = numCarsFront;
		if (numCarsRear == 0 && numCarsFront != 0)
		{
			min = 1;
		}
		if (numCarsFront == 0 && numCarsRear != 0)
		{
			max = -1;
		}
		selectedCoupler = Mathf.Clamp(selectedCoupler, min, max);
		if (car.derailed && !wasDerailed)
		{
			DisplayNotification("    DERAILED     ");
			wasDerailed = true;
		}
	}

	private void UpdateKeyboardControls()
	{
		if (!SingletonBehaviour<InputFocusManager>.Instance.hasKeyboardFocus)
		{
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Couple))
			{
				coupleButton.GetComponent<ButtonBase>().Use();
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Uncouple))
			{
				uncoupleButton.GetComponent<ButtonBase>().Use();
			}
		}
	}

	private void NotifyAboutBrokenCouple(Coupler brokenCoupler)
	{
		if (brokenCoupler.train.trainset == car.trainset)
		{
			DisplayNotification(" Coupler broken  ", 10f);
		}
	}

	private void OnDestroy()
	{
		CouplerBreakDetector.OnCoupleBreak -= NotifyAboutBrokenCouple;
	}
}
