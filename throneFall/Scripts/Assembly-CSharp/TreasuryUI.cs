using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasuryUI : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public enum AnimationState
	{
		Off = 0,
		ScaleIn = 1,
		On = 2,
		ScaleOut = 3,
		WaitToScaleOut = 4
	}

	public const int PHYSICAL_COIN_LIMIT = 200;

	public Transform coinsParent;

	public GameObject renderCamera;

	public GameObject coinPrefab;

	public Transform spawn;

	public float removalInterval;

	public float addInterval = 0.35f;

	public float activationLifetime = 1f;

	public AnimationCurve scaleCurve;

	public float scaleAnimationSpeed;

	private Transform scaleTarget;

	public float waitTimeBeforeScaleOut = 0.3f;

	private TextMeshProUGUI displayText;

	public Animator treasureChestAnimator;

	private List<GameObject> instantiatedCoins = new List<GameObject>();

	private PlayerInteraction targetPlayer;

	private int bufferedBalance;

	private int coinQeue;

	private float addCounter;

	private float removalCounter;

	private float activationCounter;

	private bool overrideActivation;

	private AnimationState currentState;

	private float scaleAnimationProgress;

	private float scaleOutWaitClock;

	private bool shouldBeActive
	{
		get
		{
			if (!(activationCounter > 0f))
			{
				return overrideActivation;
			}
			return true;
		}
	}

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		scaleTarget = UIFrameManager.instance.TreasureChest.scaleTarget;
		displayText = UIFrameManager.instance.TreasureChest.balanceNumber;
		targetPlayer = TagManager.instance.Players[0].GetComponent<PlayerInteraction>();
		targetPlayer.onFocusPaymentInteraction.AddListener(LockActivation);
		targetPlayer.onUnfocusPaymentInteraction.AddListener(UnlockActivation);
		SetState(currentState);
	}

	private void SetState(AnimationState newState)
	{
		switch (newState)
		{
		case AnimationState.Off:
			scaleTarget.localScale = Vector3.one * scaleCurve.Evaluate(0f);
			scaleAnimationProgress = 0f;
			break;
		case AnimationState.On:
			scaleTarget.localScale = Vector3.one * scaleCurve.Evaluate(1f);
			scaleAnimationProgress = 1f;
			treasureChestAnimator.SetBool("Open", value: true);
			break;
		case AnimationState.WaitToScaleOut:
			treasureChestAnimator.SetBool("Open", value: false);
			scaleOutWaitClock = 0f;
			break;
		}
		currentState = newState;
	}

	private void Update()
	{
		if (addCounter > 0f)
		{
			addCounter -= Time.deltaTime;
		}
		if (removalCounter > 0f)
		{
			removalCounter -= Time.deltaTime;
		}
		if (activationCounter > 0f)
		{
			activationCounter -= Time.deltaTime;
		}
		bufferedBalance = Mathf.Min(targetPlayer.Balance, 200);
		coinQeue = bufferedBalance - instantiatedCoins.Count;
		if (currentState != AnimationState.Off)
		{
			displayText.text = "<sprite name=\"coin\">" + targetPlayer.Balance;
		}
		if (coinQeue > 0 && addCounter <= 0f)
		{
			GameObject item = Object.Instantiate(coinPrefab, spawn.position, Random.rotation, coinsParent);
			instantiatedCoins.Add(item);
			addCounter = addInterval;
			activationCounter = activationLifetime;
		}
		if (coinQeue < 0 && addCounter <= 0f && instantiatedCoins.Count > 0)
		{
			GameObject obj = instantiatedCoins[instantiatedCoins.Count - 1];
			instantiatedCoins.RemoveAt(instantiatedCoins.Count - 1);
			Object.Destroy(obj);
			removalCounter = removalInterval;
			activationCounter = activationLifetime;
		}
		switch (currentState)
		{
		case AnimationState.Off:
			if (shouldBeActive)
			{
				SetState(AnimationState.ScaleIn);
			}
			break;
		case AnimationState.On:
			if (!shouldBeActive)
			{
				SetState(AnimationState.WaitToScaleOut);
			}
			break;
		case AnimationState.WaitToScaleOut:
			scaleOutWaitClock += Time.deltaTime;
			if (scaleOutWaitClock >= waitTimeBeforeScaleOut)
			{
				SetState(AnimationState.ScaleOut);
			}
			break;
		case AnimationState.ScaleOut:
			scaleAnimationProgress -= Time.deltaTime * scaleAnimationSpeed;
			scaleTarget.localScale = Vector3.one * scaleCurve.Evaluate(scaleAnimationProgress);
			if (scaleAnimationProgress <= 0f)
			{
				SetState(AnimationState.Off);
			}
			else if (shouldBeActive)
			{
				SetState(AnimationState.ScaleIn);
			}
			break;
		case AnimationState.ScaleIn:
			scaleAnimationProgress += Time.deltaTime * scaleAnimationSpeed;
			scaleTarget.localScale = Vector3.one * scaleCurve.Evaluate(scaleAnimationProgress);
			if (scaleAnimationProgress >= 1f)
			{
				SetState(AnimationState.On);
			}
			else if (!shouldBeActive)
			{
				SetState(AnimationState.ScaleIn);
			}
			break;
		}
	}

	private void LockActivation()
	{
		overrideActivation = true;
	}

	private void UnlockActivation()
	{
		overrideActivation = false;
		activationCounter = activationLifetime;
	}

	public void OnDusk()
	{
		renderCamera.SetActive(value: false);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		renderCamera.SetActive(value: true);
	}

	public void OnDuskEarly()
	{
	}
}
