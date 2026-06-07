using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SunController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRunAllDeviceDataTime_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private List<DeviceDataTime> _003ClistTimers_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRunAllDeviceDataTime_003Ed__26(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static SunController Instance;

	[Header("Sun Settings")]
	public int offsetSunrise;

	public TimeGame sunriseTime;

	private TimeGame offsetSunriseTime;

	public int offsetSunset;

	public TimeGame sunsetTime;

	private TimeGame offsetSunsetTime;

	[Header("Rotation Settings")]
	public AnimationCurve xRotationCurve;

	public AnimationCurve yRotationCurve;

	public AnimationCurve zRotationCurve;

	public AnimationCurve lightIntensityCurve;

	[Range(0f, 360f)]
	[Header("Sun Rotation Offset")]
	public float rotationOffset;

	[Header("Time Scale Settings")]
	public float secondsPerHour;

	[Header("Light Settings")]
	public Transform LightSun;

	public Light sunLight;

	[Header("Current Time")]
	public TimeGame currentTimeGame;

	public DateGame currentDateGame;

	public float speedTime;

	[Header("UI Time")]
	public TMP_Text UI_hour;

	public TMP_Text UI_minute;

	public TMP_Text UI_date;

	public float currentTime;

	public float elapsedTime;

	public bool stopTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CRunAllDeviceDataTime_003Ed__26))]
	private IEnumerator RunAllDeviceDataTime()
	{
		return null;
	}

	public static void SetDeviceDataTimeToAllDevices(int day, int month, int year, int hour, int minute)
	{
	}

	private TimeGame AddSecondsToTime(TimeGame time, int sec)
	{
		return null;
	}

	private void Update()
	{
	}

	public void SetSun(int H, int M, int S, int day, int month, int year)
	{
	}

	public void SetTime(int H, int M, int S)
	{
	}

	public int GetTimeH()
	{
		return 0;
	}

	public int GetTimeM()
	{
		return 0;
	}

	public int GetTimeS()
	{
		return 0;
	}

	private void UpdateCurrentTimeGame()
	{
	}

	private void AdvanceDay()
	{
	}

	private int GetDaysInMonth(int month, int year)
	{
		return 0;
	}

	private void UpdateSunRotation()
	{
	}

	public static bool IsAfterTime(int targetHour, int targetMinute)
	{
		return false;
	}
}
