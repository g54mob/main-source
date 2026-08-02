using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FishingRodController))]
public class FishingRodInputHandler : MonoBehaviour
{
	[Serializable]
	public class FloatEvent : UnityEvent<float>
	{
	}

	[Header("Charge")]
	[SerializeField]
	private float maxChargeTime = 1.5f;

	[SerializeField]
	private float minPower = 0.2f;

	[Header("Input")]
	[SerializeField]
	private string fireButton = "Fire1";

	[SerializeField]
	private string reelButton = "Fire2";

	public UnityEvent OnChargeStart = new UnityEvent();

	public FloatEvent OnChargeUpdate = new FloatEvent();

	public UnityEvent OnChargeRelease = new UnityEvent();

	private FishingRodController rod;

	private EastUpPlayerItemManager itemManager;

	private float holdStartTime;

	private bool isCharging;

	public bool IsCharging => isCharging;

	public FishingRodController Rod => rod;

	private void Awake()
	{
		rod = GetComponent<FishingRodController>();
		itemManager = GetComponentInParent<EastUpPlayerItemManager>();
		if (itemManager != null)
		{
			rod.SetHoldingPlayer(itemManager.transform);
			rod.SetArmsAnimator(itemManager.GetFPSArmsAnimator());
		}
	}

	private void OnEnable()
	{
		if (rod == null || itemManager == null)
		{
			return;
		}
		Animator fPSArmsAnimator = itemManager.GetFPSArmsAnimator();
		rod.SetArmsAnimator(fPSArmsAnimator);
		if (fPSArmsAnimator != null)
		{
			TSAnimationEvent component = fPSArmsAnimator.GetComponent<TSAnimationEvent>();
			if (component != null)
			{
				component.SetActiveFishingRod(rod);
			}
		}
	}

	private void OnDisable()
	{
		if (isCharging)
		{
			CancelCharge();
		}
		if (rod == null || itemManager == null)
		{
			return;
		}
		Animator fPSArmsAnimator = itemManager.GetFPSArmsAnimator();
		if (fPSArmsAnimator != null)
		{
			TSAnimationEvent component = fPSArmsAnimator.GetComponent<TSAnimationEvent>();
			if (component != null)
			{
				component.ClearActiveFishingRod(rod);
			}
		}
	}

	private void Update()
	{
		if (itemManager == null || rod == null)
		{
			return;
		}
		bool flag = itemManager.fpsInventory != null && itemManager.fpsInventory.player != null && itemManager.fpsInventory.player.Run.Active;
		if (flag && isCharging)
		{
			CancelCharge();
		}
		if (Input.GetButtonDown(reelButton))
		{
			if (isCharging)
			{
				CancelCharge();
			}
			rod.Reel();
		}
		bool buttonDown = Input.GetButtonDown(fireButton);
		bool buttonUp = Input.GetButtonUp(fireButton);
		if (buttonDown && !isCharging && !flag && rod.State == FishingRodController.RodState.Idle)
		{
			isCharging = true;
			holdStartTime = Time.time;
			OnChargeStart.Invoke();
			OnChargeUpdate.Invoke(0f);
		}
		if (isCharging)
		{
			float arg = Mathf.Clamp01((Time.time - holdStartTime) / maxChargeTime);
			OnChargeUpdate.Invoke(arg);
			if (buttonUp)
			{
				ReleaseThrow();
			}
		}
	}

	private void ReleaseThrow()
	{
		isCharging = false;
		float power = Mathf.Clamp((Time.time - holdStartTime) / maxChargeTime, minPower, 1f);
		rod.PlayThrowAnimation(power);
		OnChargeRelease.Invoke();
	}

	private void CancelCharge()
	{
		isCharging = false;
		OnChargeRelease.Invoke();
	}
}
