using System;
using System.Collections;
using DV.CabControls;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.TimeKeeping
{
	public class AnalogAlarmClock : AnalogClock
	{
		private const string ALARM_TIME = "alarmTime";

		private const string ALARM_SET = "alarmSet";

		private const int ALARM_INCREMENT_MINUTES = 12;

		private const int WRAPAROUND_ALARM_HOURS = 12;

		private const int WRAPAROUND_ALARM_MINUTES = 720;

		private const int ALARM_OFFSET_GRANULATION = 6;

		private const int MAX_ALARM_MINUTES = 4308;

		private const float MINUTES_TO_ANGLE = 0.5f;

		private const float OFFSET_TO_ANGLE = 60f;

		[SerializeField]
		private Transform alarmHandle;

		[SerializeField]
		private Transform alarmIncrementHandle;

		[SerializeField]
		private GameObject alarmKnob;

		[SerializeField]
		private AnalogAlarmClockAudioController audioController;

		private ButtonBase alarmButton;

		private ItemScrolling alarmScrolling;

		private ItemSaveData itemSaveData;

		private ItemBase item;

		private DateTime alarmTime;

		private int alarmTimeInMinutes;

		private int alarmOffset;

		private bool alarmSet;

		private bool initialized;

		protected override void Start()
		{
			base.Start();
			unsubscribeOnDisable = false;
			if (VRManager.IsVREnabled())
			{
				alarmScrolling = base.gameObject.AddComponent<ItemScrollingVR>();
			}
			else
			{
				alarmScrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
			}
			itemSaveData = GetComponent<ItemSaveData>();
			item = GetComponent<ItemBase>();
			if (item.BelongsToPlayer())
			{
				SingletonBehaviour<WorldClockController>.Instance.RegisterPlayerOwnedClock(item);
			}
			alarmButton = GetComponentInChildren<ButtonBase>();
			StartCoroutine(DelayedInitialize());
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (alarmSet)
			{
				audioController.PlayTickSound();
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (!UnloadWatcher.isUnloading)
			{
				audioController.StopTickSound();
			}
		}

		private IEnumerator DelayedInitialize()
		{
			yield return WaitFor.EndOfFrame;
			initialized = true;
			SetupListeners(on: true);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
				SingletonBehaviour<WorldClockController>.Instance.UnregisterPlayerOwnedClock(item);
			}
		}

		private void SetupListeners(bool on)
		{
			if (initialized)
			{
				if (on)
				{
					alarmButton.Used += OnButtonPressed;
					alarmKnob.GetComponent<SteppedJoint>().PositionChanged += OnKnobChanged;
					item.Used += PressButton;
					alarmScrolling.Scrolled += OnScrolled;
					itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
					itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
				}
				else
				{
					alarmButton.Used -= OnButtonPressed;
					alarmKnob.GetComponent<SteppedJoint>().PositionChanged -= OnKnobChanged;
					item.Used -= PressButton;
					alarmScrolling.Scrolled -= OnScrolled;
					itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
					itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
				}
			}
		}

		protected override void OnTimeChanged(float hourHandleAngle, float minuteHandleAngle, DateTime currentTime)
		{
			base.OnTimeChanged(hourHandleAngle, minuteHandleAngle, currentTime);
			AlarmTick(currentTime);
		}

		private void OnItemSaveDataLoaded(JObject data)
		{
			alarmTimeInMinutes = data.GetInt("alarmTime") ?? 0;
			ClampAlarmTime();
			SetAlarmTime();
			alarmSet = data.GetBool("alarmSet") ?? false;
			if (alarmSet)
			{
				audioController.PlayTickSound();
				alarmTime = SingletonBehaviour<WorldClockController>.Instance.CalculateAlarmTime(GetUsableAlarmTime());
			}
		}

		private JObject OnItemSaveDataRequested(JObject data)
		{
			data.SetInt("alarmTime", alarmTimeInMinutes);
			data.SetBool("alarmSet", alarmSet);
			return data;
		}

		private void OnScrolled(ScrollAction direction)
		{
			SetAlarmHandleManually(direction.IsPositive());
		}

		private void PressButton()
		{
			alarmButton.GetComponent<ControlImplBase>().Use();
		}

		private void OnKnobChanged(ValueChangedEventArgs obj)
		{
			SetAlarmHandleManually(obj.delta > 0f);
		}

		private void SetAlarmHandleManually(bool increment)
		{
			if (!alarmSet)
			{
				alarmTimeInMinutes += (increment ? 12 : (-12));
				ClampAlarmTime();
				SetAlarmTime();
			}
		}

		private void ClampAlarmTime()
		{
			if (alarmTimeInMinutes <= -720)
			{
				alarmTimeInMinutes = 0;
			}
			else if (alarmTimeInMinutes > 4308)
			{
				alarmTimeInMinutes = 3600;
			}
		}

		private void OnButtonPressed()
		{
			alarmSet = !alarmSet;
			if (alarmSet)
			{
				alarmTime = SingletonBehaviour<WorldClockController>.Instance.CalculateAlarmTime(GetUsableAlarmTime());
				audioController.PlayTickSound();
			}
			else
			{
				audioController.StopTickSound();
			}
		}

		private int GetUsableAlarmTime()
		{
			if (alarmTimeInMinutes < 0)
			{
				return 720 + alarmTimeInMinutes;
			}
			return alarmTimeInMinutes;
		}

		private void SetAlarmTime()
		{
			int num = alarmOffset;
			int usableAlarmTime = GetUsableAlarmTime();
			alarmOffset = Mathf.Max(0, usableAlarmTime / 720);
			UpdateAlarmHandle(usableAlarmTime);
			if (num != alarmOffset)
			{
				audioController.PlayIncrementSound();
				UpdateIncrementHandle();
			}
			else
			{
				audioController.PlayAlarmHandleMoveSound();
			}
		}

		private void UpdateIncrementHandle()
		{
			float num = (float)alarmOffset * 60f;
			Quaternion localRotation = ((rotationAxis == HandleRotationAxis.X) ? Quaternion.Euler(num, 0f, 0f) : ((rotationAxis != HandleRotationAxis.Y) ? Quaternion.Euler(0f, 0f, num) : Quaternion.Euler(0f, num, 0f)));
			alarmIncrementHandle.localRotation = localRotation;
		}

		private void UpdateAlarmHandle(int alarmMinutes)
		{
			float num = (float)(alarmMinutes % 720) * 0.5f;
			Quaternion localRotation = ((rotationAxis == HandleRotationAxis.X) ? Quaternion.Euler(num, 0f, 0f) : ((rotationAxis != HandleRotationAxis.Y) ? Quaternion.Euler(0f, 0f, num) : Quaternion.Euler(0f, num, 0f)));
			alarmHandle.localRotation = localRotation;
		}

		private void AlarmTick(DateTime time)
		{
			if (alarmSet)
			{
				TimeSpan timeSpan = alarmTime - time;
				int num = Mathd.FloorToInt(timeSpan.TotalHours) / 12;
				if (alarmOffset > num)
				{
					alarmOffset = num;
					alarmTimeInMinutes -= 720;
					UpdateIncrementHandle();
					audioController.PlayIncrementSound();
				}
				if (!(timeSpan.TotalMinutes > 0.0))
				{
					alarmSet = false;
					audioController.PlayAlarmSound();
					audioController.StopTickSound();
				}
			}
		}
	}
}
