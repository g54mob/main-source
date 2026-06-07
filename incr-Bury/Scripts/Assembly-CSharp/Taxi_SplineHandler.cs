using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class Taxi_SplineHandler : MonoBehaviour
{
	public enum TaxiAnimState
	{
		idle = 0,
		movingToStop = 1,
		stopped = 2,
		movingToExit = 3,
		Completed = 4
	}

	[SerializeField]
	private SplineAnimate splineAnim;

	[SerializeField]
	private PickUppable ourPickUpScript;

	private Rigidbody rb;

	[SerializeField]
	private bool hasBeenActivated;

	public bool isPlayingSplineAnimation;

	[SerializeField]
	private float stopAtPoint;

	[SerializeField]
	private float stopTime;

	[Header("Speed")]
	[SerializeField]
	private float moveSpeed_Max;

	[SerializeField]
	private float moveSpeed_Curr;

	[SerializeField]
	private float moveSpeed_Accel;

	[SerializeField]
	private float moveSpeed_Braking;

	public TaxiAnimState taxiAnimState;

	[SerializeField]
	private float elapsedTime_Display;

	private bool roundIsActive;

	private bool hasPlayedAnim;

	[SerializeField]
	private float animationStartTime;

	private float startTime_CountDown;

	[Header("Audio")]
	[SerializeField]
	private AudioSource audioSource_Horn;

	private void Awake()
	{
		splineAnim = GetComponent<SplineAnimate>();
		ourPickUpScript = GetComponent<PickUppable>();
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnRoundStart()
	{
		startTime_CountDown = animationStartTime;
		roundIsActive = true;
	}

	private void Update()
	{
		elapsedTime_Display = splineAnim.ElapsedTime;
		CheckForActivation();
		HandleSplineAnimPlaying();
		HandleAnimPlayCountdown();
	}

	private void CheckForActivation()
	{
		if (!hasBeenActivated && !rb.isKinematic)
		{
			OnBeenActivated();
			hasBeenActivated = true;
		}
	}

	private void OnBeenActivated()
	{
		isPlayingSplineAnimation = false;
		rb.linearVelocity = Vector3.zero;
		rb.AddForce((GameManager.Singleton.GetYardObject().transform.position - base.transform.position) * 5f, ForceMode.VelocityChange);
		base.enabled = false;
	}

	private void HandleSplineAnimPlaying()
	{
		if (isPlayingSplineAnimation)
		{
			splineAnim.ElapsedTime += Time.deltaTime * moveSpeed_Curr;
			if (GameManager.Singleton.hasTimerElapsed_IsNighttime)
			{
				isPlayingSplineAnimation = false;
			}
			if (GameManager.Singleton.gameState != GameManager.GameState.Playing)
			{
				isPlayingSplineAnimation = false;
			}
		}
		switch (taxiAnimState)
		{
		case TaxiAnimState.movingToStop:
			if (splineAnim.ElapsedTime >= stopAtPoint)
			{
				HandleSpeedingDown();
				if (moveSpeed_Curr <= 0f)
				{
					taxiAnimState = TaxiAnimState.stopped;
					StartCoroutine(WaitAtStopForXTime());
					PlayHornHonk();
				}
			}
			else
			{
				HandleSpeedingUp();
			}
			break;
		case TaxiAnimState.stopped:
			moveSpeed_Curr = 0f;
			break;
		case TaxiAnimState.movingToExit:
			HandleSpeedingUp();
			if (splineAnim.ElapsedTime >= 22f)
			{
				isPlayingSplineAnimation = false;
				taxiAnimState = TaxiAnimState.Completed;
			}
			break;
		case TaxiAnimState.idle:
		case TaxiAnimState.Completed:
			break;
		}
	}

	private void HandleSpeedingUp()
	{
		if (moveSpeed_Curr < moveSpeed_Max)
		{
			moveSpeed_Curr += Time.deltaTime * moveSpeed_Accel;
		}
		else
		{
			moveSpeed_Curr = moveSpeed_Max;
		}
	}

	private void HandleSpeedingDown()
	{
		if (moveSpeed_Curr > 0f)
		{
			moveSpeed_Curr -= Time.deltaTime * moveSpeed_Braking;
		}
		else
		{
			moveSpeed_Curr = 0f;
		}
	}

	private IEnumerator WaitAtStopForXTime()
	{
		isPlayingSplineAnimation = false;
		moveSpeed_Curr = 0f;
		yield return new WaitForSeconds(stopTime);
		taxiAnimState = TaxiAnimState.movingToExit;
		isPlayingSplineAnimation = true;
	}

	public void PlaySplineAnim()
	{
		isPlayingSplineAnimation = true;
		taxiAnimState = TaxiAnimState.movingToStop;
	}

	public void HandleAnimPlayCountdown()
	{
		if (roundIsActive && !hasPlayedAnim)
		{
			if (startTime_CountDown > 0f)
			{
				startTime_CountDown -= Time.deltaTime;
				return;
			}
			PlaySplineAnim();
			hasPlayedAnim = true;
		}
	}

	public void PlayHornHonk()
	{
		audioSource_Horn.volume = AudioManager.Singleton.sfxVolume;
		audioSource_Horn.Play();
	}
}
