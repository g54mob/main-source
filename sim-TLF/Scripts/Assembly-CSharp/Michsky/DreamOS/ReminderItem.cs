using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class ReminderItem : MonoBehaviour
	{
		[Header("Resources")]
		public ButtonManager mainButton;

		public SwitchManager switchManager;

		[SerializeField]
		private TextMeshProUGUI titleObject;

		[SerializeField]
		private TextMeshProUGUI timeObject;

		[SerializeField]
		private GameObject onceObject;

		[SerializeField]
		private GameObject dailyObject;

		[HideInInspector]
		public string reminderID;

		[HideInInspector]
		public bool isAM;

		[HideInInspector]
		public ReminderManager manager;

		public void SetTitle(string text)
		{
			titleObject.text = text;
		}

		public void SetTime(string text)
		{
			timeObject.text = text;
		}

		public void SetOnce()
		{
			onceObject.SetActive(value: true);
			dailyObject.SetActive(value: false);
		}

		public void SetDaily()
		{
			onceObject.SetActive(value: false);
			dailyObject.SetActive(value: true);
		}

		public void DeleteReminder()
		{
			manager.DeleteReminder(reminderID);
			Object.Destroy(base.gameObject);
		}

		public void InitializeWindow(ModalWindowManager modal, TMP_InputField title, HorizontalSelector type, HorizontalSelector minute, HorizontalSelector hour, HorizontalSelector meridiem)
		{
			int index = 7;
			int index2 = 0;
			modal.onConfirm.RemoveAllListeners();
			modal.onConfirm.AddListener(delegate
			{
				modal.CloseWindow();
				manager.UpdateReminderData(reminderID, title.text, type.index, minute.index, hour.index + 1, meridiem.index);
				for (int i = 0; i < DateAndTimeManager.instance.timedEvents.Count; i++)
				{
					if (DateAndTimeManager.instance.timedEvents[i].eventID == reminderID)
					{
						if (meridiem.index == 0)
						{
							DateAndTimeManager.instance.timedEvents[i].meridiemFormat = DateAndTimeManager.DefaultShortTime.AM;
						}
						else
						{
							DateAndTimeManager.instance.timedEvents[i].meridiemFormat = DateAndTimeManager.DefaultShortTime.PM;
						}
						if (type.index == 0)
						{
							DateAndTimeManager.instance.timedEvents[i].eventType = DateAndTimeManager.TimedEventType.Once;
						}
						else if (type.index == 1)
						{
							DateAndTimeManager.instance.timedEvents[i].eventType = DateAndTimeManager.TimedEventType.Daily;
						}
						DateAndTimeManager.instance.timedEvents[i].eventTitle = title.text;
						DateAndTimeManager.instance.timedEvents[i].eventHour = hour.index + 1;
						DateAndTimeManager.instance.timedEvents[i].eventMinute = minute.index;
						break;
					}
				}
				SetTitle(title.text);
				if (minute.index < 10)
				{
					SetTime($"{hour.items[hour.index].itemTitle}:0{minute.items[minute.index].itemTitle} {meridiem.items[meridiem.index].itemTitle}");
				}
				else
				{
					SetTime($"{hour.items[hour.index].itemTitle}:{minute.items[minute.index].itemTitle} {meridiem.items[meridiem.index].itemTitle}");
				}
				if (type.index == 0)
				{
					SetOnce();
				}
				else if (type.index == 1)
				{
					SetDaily();
				}
				if (meridiem.index == 0)
				{
					isAM = true;
				}
				else
				{
					isAM = false;
				}
			});
			hour.items.Clear();
			minute.items.Clear();
			for (int num = 0; num < 12; num++)
			{
				hour.CreateNewItem((num + 1).ToString());
			}
			for (int num2 = 0; num2 < 59; num2++)
			{
				minute.CreateNewItem(num2.ToString());
			}
			hour.index = index;
			minute.index = index2;
			title.text = titleObject.text;
			hour.UpdateUI();
			minute.UpdateUI();
			if (onceObject.activeInHierarchy)
			{
				type.index = 0;
				type.UpdateUI();
			}
			else if (dailyObject.activeInHierarchy)
			{
				type.index = 1;
				type.UpdateUI();
			}
			if (isAM)
			{
				meridiem.index = 0;
				meridiem.UpdateUI();
			}
			else
			{
				meridiem.index = 1;
				meridiem.UpdateUI();
			}
			modal.OpenWindow();
		}
	}
}
