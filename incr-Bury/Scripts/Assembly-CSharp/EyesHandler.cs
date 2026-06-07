using System;
using UnityEngine;

public class EyesHandler : MonoBehaviour
{
	public enum EyeState
	{
		Open = 0,
		Closed = 1,
		Blink = 2
	}

	public EyeState eyeState;

	private const float upperLid_ClosedTarget = 0f;

	private const float bottomLid_ClosedTarget = 180f;

	private const float upperLid_OpenTarget = 90f;

	private const float bottomLid_OpenTarget = 270f;

	[Header("Left Eye")]
	[SerializeField]
	private float leftEye_Blink_Delay;

	private float leftEye_Blink_Delay_Curr;

	[SerializeField]
	private float leftEye_BlinkSpeed;

	[SerializeField]
	private float leftEye_OpenSpeed;

	[Header("Right Eye")]
	[SerializeField]
	private float rightEye_Blink_Delay;

	private float rightEye_Blink_Delay_Curr;

	[SerializeField]
	private float rightEye_BlinkSpeed;

	[SerializeField]
	private float rightEye_OpenSpeed;

	[Header("Refs")]
	[SerializeField]
	private GameObject right_Eyeball;

	[SerializeField]
	private GameObject left_Eyeball;

	[SerializeField]
	private GameObject right_Lid_Upper;

	[SerializeField]
	private GameObject right_Lid_Lower;

	[SerializeField]
	private GameObject left_Lid_Upper;

	[SerializeField]
	private GameObject left_Lid_Lower;

	[Header("Blinking")]
	[SerializeField]
	private Vector2 nextBlinkMinMax;

	private float nextBlink_Curr;

	[SerializeField]
	private bool randomOneEyeBlinksDifferent;

	[SerializeField]
	private float randomOneEyeDelayLimit;

	private Quaternion L_Up_Open;

	private Quaternion R_Up_Open;

	private Quaternion L_Lower_Open;

	private Quaternion R_Lower_Open;

	private Quaternion closed_Up;

	private Quaternion closed_Lower;

	[Header("Looking At Player")]
	public bool lookAtPlayer;

	[SerializeField]
	private float lookAtPlayer_DistanceThreshold;

	[SerializeField]
	private float lookAtPlayer_ViewAngle;

	[SerializeField]
	private float lookAtPlayer_EyeSpeed;

	private bool playerIsLookable;

	[SerializeField]
	private Transform forwardFacingHelper;

	[Header("Misc")]
	public bool nocturnal;

	public bool disableBlinking;

	private void Start()
	{
		CalculateLidVectors();
		if (nocturnal)
		{
			ChangeEyeState(EyeState.Closed);
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNight));
		}
		else
		{
			ChangeEyeState(EyeState.Open);
		}
	}

	private void OnDestroy()
	{
		try
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNight));
		}
		catch
		{
		}
	}

	private void OnNight()
	{
		if (nocturnal)
		{
			ChangeEyeState(EyeState.Open);
		}
	}

	private void CalculateLidVectors()
	{
		L_Up_Open = left_Lid_Upper.transform.localRotation;
		R_Up_Open = right_Lid_Upper.transform.localRotation;
		L_Lower_Open = left_Lid_Lower.transform.localRotation;
		R_Lower_Open = right_Lid_Lower.transform.localRotation;
		closed_Up = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		closed_Lower = Quaternion.Euler(new Vector3(180f, 0f, 0f));
	}

	private void Update()
	{
		HandleEye();
	}

	private void HandleEye()
	{
		if (eyeState == EyeState.Open)
		{
			right_Lid_Upper.transform.localRotation = Quaternion.RotateTowards(right_Lid_Upper.transform.localRotation, R_Up_Open, Time.deltaTime * rightEye_OpenSpeed);
			right_Lid_Lower.transform.localRotation = Quaternion.RotateTowards(right_Lid_Lower.transform.localRotation, R_Lower_Open, Time.deltaTime * rightEye_OpenSpeed);
			left_Lid_Upper.transform.localRotation = Quaternion.RotateTowards(left_Lid_Upper.transform.localRotation, L_Up_Open, Time.deltaTime * leftEye_OpenSpeed);
			left_Lid_Lower.transform.localRotation = Quaternion.RotateTowards(left_Lid_Lower.transform.localRotation, L_Lower_Open, Time.deltaTime * leftEye_OpenSpeed);
			if ((!GameManager.Singleton || (!GameManager.Singleton.hasTimerElapsed_IsNighttime && !disableBlinking)) && nextBlink_Curr > 0f)
			{
				nextBlink_Curr -= Time.deltaTime;
				if (nextBlink_Curr <= 0f)
				{
					ChangeEyeState(EyeState.Blink);
				}
			}
		}
		else if (eyeState == EyeState.Closed)
		{
			right_Lid_Upper.transform.localRotation = Quaternion.RotateTowards(right_Lid_Upper.transform.localRotation, closed_Up, Time.deltaTime * rightEye_BlinkSpeed);
			right_Lid_Lower.transform.localRotation = Quaternion.RotateTowards(right_Lid_Lower.transform.localRotation, closed_Lower, Time.deltaTime * rightEye_BlinkSpeed);
			left_Lid_Upper.transform.localRotation = Quaternion.RotateTowards(left_Lid_Upper.transform.localRotation, closed_Up, Time.deltaTime * leftEye_BlinkSpeed);
			left_Lid_Lower.transform.localRotation = Quaternion.RotateTowards(left_Lid_Lower.transform.localRotation, closed_Lower, Time.deltaTime * leftEye_BlinkSpeed);
		}
		else if (eyeState == EyeState.Blink)
		{
			if (rightEye_Blink_Delay_Curr > 0f)
			{
				rightEye_Blink_Delay_Curr -= Time.deltaTime;
			}
			else
			{
				right_Lid_Upper.transform.localRotation = Quaternion.RotateTowards(right_Lid_Upper.transform.localRotation, closed_Up, Time.deltaTime * rightEye_BlinkSpeed);
				right_Lid_Lower.transform.localRotation = Quaternion.RotateTowards(right_Lid_Lower.transform.localRotation, closed_Lower, Time.deltaTime * rightEye_BlinkSpeed);
			}
			if (leftEye_Blink_Delay_Curr > 0f)
			{
				leftEye_Blink_Delay_Curr -= Time.deltaTime;
				return;
			}
			left_Lid_Upper.transform.localRotation = Quaternion.RotateTowards(left_Lid_Upper.transform.localRotation, closed_Up, Time.deltaTime * leftEye_BlinkSpeed);
			left_Lid_Lower.transform.localRotation = Quaternion.RotateTowards(left_Lid_Lower.transform.localRotation, closed_Lower, Time.deltaTime * leftEye_BlinkSpeed);
		}
	}

	private void FixedUpdate()
	{
		if (lookAtPlayer)
		{
			HandleLookingAtPlayerConditions();
			HandleLookingAtPlayer();
		}
		if (eyeState == EyeState.Blink && Quaternion.Angle(left_Lid_Upper.transform.localRotation, closed_Up) < 1f && Quaternion.Angle(left_Lid_Lower.transform.localRotation, closed_Lower) < 1f && Quaternion.Angle(right_Lid_Upper.transform.localRotation, closed_Up) < 1f && Quaternion.Angle(right_Lid_Lower.transform.localRotation, closed_Lower) < 1f)
		{
			ChangeEyeState(EyeState.Open);
		}
	}

	public void ChangeEyeState(EyeState _newState)
	{
		eyeState = _newState;
		if (eyeState == EyeState.Open)
		{
			GetNewRandomBlinkTime();
		}
		else if (eyeState != EyeState.Closed && eyeState == EyeState.Blink)
		{
			if (randomOneEyeBlinksDifferent)
			{
				leftEye_Blink_Delay_Curr = 0f;
				rightEye_Blink_Delay_Curr = 0f;
				SetRandomBlinkDelayForOneEye();
			}
			else
			{
				leftEye_Blink_Delay_Curr = leftEye_Blink_Delay;
				rightEye_Blink_Delay_Curr = rightEye_Blink_Delay;
			}
		}
	}

	private void GetNewRandomBlinkTime()
	{
		nextBlink_Curr = UnityEngine.Random.Range(nextBlinkMinMax.x, nextBlinkMinMax.y);
	}

	private void SetRandomBlinkDelayForOneEye()
	{
		bool num = UnityEngine.Random.Range(0, 2) == 0;
		float num2 = UnityEngine.Random.Range(0f, randomOneEyeDelayLimit);
		if (num)
		{
			leftEye_Blink_Delay_Curr = num2;
		}
		else
		{
			rightEye_Blink_Delay_Curr = num2;
		}
	}

	private void HandleLookingAtPlayerConditions()
	{
		if (!GameManager.Singleton || !GameManager.Singleton.playerCamera)
		{
			return;
		}
		if (lookAtPlayer && (eyeState == EyeState.Open || eyeState == EyeState.Blink))
		{
			Vector3 to = GameManager.Singleton.playerCamera.transform.position - base.transform.position;
			if (to.magnitude <= lookAtPlayer_DistanceThreshold && Vector3.Angle(forwardFacingHelper.forward, to) <= lookAtPlayer_ViewAngle * 0.5f)
			{
				playerIsLookable = true;
				return;
			}
		}
		playerIsLookable = false;
	}

	private void HandleLookingAtPlayer()
	{
		if ((bool)GameManager.Singleton && (bool)GameManager.Singleton.playerCamera)
		{
			if (playerIsLookable)
			{
				Quaternion b = Quaternion.LookRotation(GameManager.Singleton.playerCamera.transform.position - left_Eyeball.transform.position);
				left_Eyeball.transform.rotation = Quaternion.Slerp(left_Eyeball.transform.rotation, b, lookAtPlayer_EyeSpeed * Time.fixedDeltaTime);
				b = Quaternion.LookRotation(GameManager.Singleton.playerCamera.transform.position - right_Eyeball.transform.position);
				right_Eyeball.transform.rotation = Quaternion.Slerp(right_Eyeball.transform.rotation, b, lookAtPlayer_EyeSpeed * Time.fixedDeltaTime);
			}
			else
			{
				left_Eyeball.transform.localRotation = Quaternion.identity;
				right_Eyeball.transform.localRotation = Quaternion.identity;
			}
		}
	}
}
