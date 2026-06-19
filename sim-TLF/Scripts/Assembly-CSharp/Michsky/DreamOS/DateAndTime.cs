using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Date & Time/Date & Time")]
	public class DateAndTime : MonoBehaviour
	{
		public enum ObjectType
		{
			AnalogClock = 0,
			DigitalClock = 1,
			DigitalDate = 2
		}

		public enum DateFormat
		{
			DD_MM_YYYY = 0,
			MM_DD_YYYY = 1,
			YYYY_MM_DD = 2
		}

		[SerializeField]
		private bool enableAmPmLabel;

		[SerializeField]
		private bool addSeconds;

		public ObjectType objectType;

		public DateFormat dateFormat;

		[HideInInspector]
		public Transform clockHourHand;

		[HideInInspector]
		public Transform clockMinuteHand;

		[HideInInspector]
		public Transform clockSecondHand;

		[HideInInspector]
		public TextMeshProUGUI textObj;

		private void Awake()
		{
			if (objectType == ObjectType.DigitalClock && textObj == null)
			{
				textObj = base.gameObject.GetComponent<TextMeshProUGUI>();
			}
			else if (objectType == ObjectType.DigitalDate && textObj == null)
			{
				textObj = base.gameObject.GetComponent<TextMeshProUGUI>();
			}
		}

		private void Update()
		{
			if (objectType == ObjectType.AnalogClock)
			{
				AnalogClock();
			}
			else if (objectType == ObjectType.DigitalClock)
			{
				DigitalClock();
			}
			else if (objectType == ObjectType.DigitalDate)
			{
				DigitalDate();
			}
		}

		public void AnalogClock()
		{
			clockHourHand.localRotation = Quaternion.Euler(0f, 0f, DateAndTimeManager.instance.currentHour * -15 * 2);
			clockMinuteHand.localRotation = Quaternion.Euler(0f, 0f, DateAndTimeManager.instance.currentMinute * -6);
			if (addSeconds)
			{
				clockSecondHand.localRotation = Quaternion.Euler(0f, 0f, DateAndTimeManager.instance.currentSecond * -6f);
			}
		}

		public void DigitalClock()
		{
			if (DateAndTimeManager.instance.currentHour.ToString().Length != 1 && DateAndTimeManager.instance.currentMinute.ToString().Length == 1)
			{
				textObj.text = $"{DateAndTimeManager.instance.currentHour}:0{DateAndTimeManager.instance.currentMinute}";
			}
			else if (DateAndTimeManager.instance.currentHour.ToString().Length == 1 && DateAndTimeManager.instance.currentMinute.ToString().Length == 1)
			{
				textObj.text = $"{DateAndTimeManager.instance.currentHour}:0{DateAndTimeManager.instance.currentMinute}";
			}
			else if (DateAndTimeManager.instance.currentHour.ToString().Length == 1 && DateAndTimeManager.instance.currentMinute.ToString().Length != 1)
			{
				textObj.text = $"{DateAndTimeManager.instance.currentHour}:{DateAndTimeManager.instance.currentMinute}";
			}
			else
			{
				textObj.text = $"{DateAndTimeManager.instance.currentHour}:{DateAndTimeManager.instance.currentMinute}";
			}
			if (addSeconds)
			{
				textObj.text = textObj.text + ":" + DateAndTimeManager.instance.currentSecond.ToString("00");
			}
			if (DateAndTimeManager.instance.useShortTimeFormat)
			{
				if (DateAndTimeManager.instance.isAm && enableAmPmLabel)
				{
					textObj.text += " AM";
				}
				else if (!DateAndTimeManager.instance.isAm && enableAmPmLabel)
				{
					textObj.text += " PM";
				}
			}
		}

		public void DigitalDate()
		{
			if (dateFormat == DateFormat.DD_MM_YYYY)
			{
				textObj.text = $"{DateAndTimeManager.instance.currentDay}.{DateAndTimeManager.instance.currentMonth}.{DateAndTimeManager.instance.currentYear}";
			}
			else if (dateFormat == DateFormat.MM_DD_YYYY)
			{
				textObj.text = $"{DateAndTimeManager.instance.currentMonth}.{DateAndTimeManager.instance.currentDay}.{DateAndTimeManager.instance.currentYear}";
			}
			else if (dateFormat == DateFormat.YYYY_MM_DD)
			{
				textObj.text = $"{DateAndTimeManager.instance.currentYear}.{DateAndTimeManager.instance.currentMonth}.{DateAndTimeManager.instance.currentDay}";
			}
		}
	}
}
