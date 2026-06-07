using System;
using DV.Utils;
using UnityEngine;

namespace DV.TimeKeeping
{
	public class AnalogClock : MonoBehaviour
	{
		protected enum HandleRotationAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[SerializeField]
		private Transform[] hoursHandleTransforms;

		[SerializeField]
		private Transform[] minutesHandleTransforms;

		[SerializeField]
		protected HandleRotationAxis rotationAxis;

		protected bool unsubscribeOnDisable = true;

		private bool isSubscribed;

		protected virtual void Start()
		{
			if (hoursHandleTransforms == null || hoursHandleTransforms.Length == 0)
			{
				Debug.LogError("AnalogClock: Missing references to hoursHandleTransforms. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
			}
			else if (minutesHandleTransforms == null)
			{
				Debug.LogError("AnalogClock: Missing reference to minutesHandleTransforms. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
			}
		}

		protected virtual void OnEnable()
		{
			if (!(SingletonBehaviour<WorldClockController>.Instance == null) && !isSubscribed)
			{
				var (flag, hourHandleAngle, minuteHandleAngle, currentTime) = SingletonBehaviour<WorldClockController>.Instance.GetCurrentAnglesAndTimeOfDay();
				if (flag)
				{
					OnTimeChanged(hourHandleAngle, minuteHandleAngle, currentTime);
				}
				SingletonBehaviour<WorldClockController>.Instance.TimeChanged += OnTimeChanged;
				isSubscribed = true;
			}
		}

		protected virtual void OnDisable()
		{
			if (!UnloadWatcher.isUnloading && SingletonBehaviour<WorldClockController>.Instance != null && unsubscribeOnDisable)
			{
				SingletonBehaviour<WorldClockController>.Instance.TimeChanged -= OnTimeChanged;
				isSubscribed = false;
			}
		}

		protected virtual void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && isSubscribed)
			{
				SingletonBehaviour<WorldClockController>.Instance.TimeChanged -= OnTimeChanged;
			}
		}

		protected virtual void OnTimeChanged(float hourHandleAngle, float minuteHandleAngle, DateTime currentTime)
		{
			Quaternion localRotation;
			Quaternion localRotation2;
			if (rotationAxis == HandleRotationAxis.X)
			{
				localRotation = Quaternion.Euler(hourHandleAngle, 0f, 0f);
				localRotation2 = Quaternion.Euler(minuteHandleAngle, 0f, 0f);
			}
			else if (rotationAxis == HandleRotationAxis.Y)
			{
				localRotation = Quaternion.Euler(0f, hourHandleAngle, 0f);
				localRotation2 = Quaternion.Euler(0f, minuteHandleAngle, 0f);
			}
			else
			{
				localRotation = Quaternion.Euler(0f, 0f, hourHandleAngle);
				localRotation2 = Quaternion.Euler(0f, 0f, minuteHandleAngle);
			}
			Transform[] array = hoursHandleTransforms;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].localRotation = localRotation;
			}
			array = minutesHandleTransforms;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].localRotation = localRotation2;
			}
		}
	}
}
