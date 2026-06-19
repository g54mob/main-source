using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class ReminderManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject reminderPreset;

		[SerializeField]
		private Transform reminderParent;

		[SerializeField]
		private ModalWindowManager reminderModal;

		[SerializeField]
		private TMP_InputField eventTitleObject;

		[SerializeField]
		private HorizontalSelector typeSelector;

		[SerializeField]
		private HorizontalSelector hourSelector;

		[SerializeField]
		private HorizontalSelector minuteSelector;

		[SerializeField]
		private HorizontalSelector meridiemSelector;

		private int reminderLimit = 10;

		private List<ReminderItem> activeItems = new List<ReminderItem>();

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.DateAndTime;

		private void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (DateAndTimeManager.instance == null)
			{
				return;
			}
			GetCurrentItemCount();
			foreach (Transform item in reminderParent)
			{
				Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < reminderLimit; i++)
			{
				if (DreamOSDataManager.ContainsJsonKey(dataCat, "ReminderItem#" + i + "_IsEnabled"))
				{
					GameObject gameObject = Object.Instantiate(reminderPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject.name = "ReminderItem#" + i;
					gameObject.transform.SetParent(reminderParent, worldPositionStays: false);
					ReminderItem rItem = gameObject.GetComponent<ReminderItem>();
					rItem.manager = this;
					rItem.reminderID = gameObject.name;
					rItem.mainButton.onClick.AddListener(delegate
					{
						rItem.InitializeWindow(reminderModal, eventTitleObject, typeSelector, minuteSelector, hourSelector, meridiemSelector);
					});
					rItem.switchManager.onEvents.AddListener(delegate
					{
						EnableReminder(rItem.reminderID, value: true, updateSwitch: false);
					});
					rItem.switchManager.offEvents.AddListener(delegate
					{
						EnableReminder(rItem.reminderID, value: false, updateSwitch: false);
					});
					activeItems.Add(rItem);
					DateAndTimeManager.TimedEvent timedEvent = new DateAndTimeManager.TimedEvent();
					timedEvent.eventID = gameObject.name;
					timedEvent.eventMinute = DreamOSDataManager.ReadIntData(dataCat, gameObject.name + "_Minute");
					timedEvent.eventHour = DreamOSDataManager.ReadIntData(dataCat, gameObject.name + "_Hour");
					if (DreamOSDataManager.ReadIntData(dataCat, gameObject.name + "_IsPM") == 0)
					{
						timedEvent.meridiemFormat = DateAndTimeManager.DefaultShortTime.AM;
						rItem.isAM = true;
					}
					else
					{
						timedEvent.meridiemFormat = DateAndTimeManager.DefaultShortTime.PM;
						rItem.isAM = false;
					}
					timedEvent.eventTitle = DreamOSDataManager.ReadStringData(dataCat, gameObject.name + "_Title");
					timedEvent.isReminderItem = true;
					timedEvent.isEnabled = DreamOSDataManager.ReadBooleanData(dataCat, gameObject.name + "_IsEnabled");
					if (DreamOSDataManager.ReadIntData(dataCat, gameObject.name + "_Type") == 0)
					{
						rItem.SetOnce();
						timedEvent.eventType = DateAndTimeManager.TimedEventType.Once;
					}
					else if (DreamOSDataManager.ReadIntData(dataCat, gameObject.name + "_Type") == 1)
					{
						rItem.SetDaily();
						timedEvent.eventType = DateAndTimeManager.TimedEventType.Daily;
					}
					if (timedEvent.isEnabled)
					{
						rItem.switchManager.isOn = true;
						rItem.switchManager.UpdateUI();
					}
					else if (!timedEvent.isEnabled)
					{
						rItem.switchManager.isOn = false;
						rItem.switchManager.UpdateUI();
					}
					rItem.SetTitle(DreamOSDataManager.ReadStringData(dataCat, gameObject.name + "_Title"));
					if (timedEvent.eventMinute < 10)
					{
						rItem.SetTime($"{timedEvent.eventHour}:0{timedEvent.eventMinute} {timedEvent.meridiemFormat}");
					}
					else
					{
						rItem.SetTime($"{timedEvent.eventHour}:{timedEvent.eventMinute} {timedEvent.meridiemFormat}");
					}
					activeItems.Add(rItem);
					DateAndTimeManager.instance.timedEvents.Add(timedEvent);
				}
			}
		}

		public void EnableReminder(string itemID, bool value, bool updateSwitch = true)
		{
			ReminderItem reminderItem = null;
			for (int i = 0; i < activeItems.Count; i++)
			{
				if (activeItems[i].reminderID == itemID)
				{
					reminderItem = activeItems[i];
					break;
				}
			}
			if (reminderItem == null)
			{
				return;
			}
			for (int j = 0; j < DateAndTimeManager.instance.timedEvents.Count; j++)
			{
				if (DateAndTimeManager.instance.timedEvents[j].eventID == itemID)
				{
					DateAndTimeManager.instance.timedEvents[j].isEnabled = value;
					break;
				}
			}
			DreamOSDataManager.WriteBooleanData(dataCat, reminderItem.reminderID + "_IsEnabled", value);
			if (updateSwitch)
			{
				reminderItem.switchManager.isOn = value;
				reminderItem.switchManager.UpdateUI();
			}
		}

		public void DeleteReminder(string itemID, bool disableBefore = true)
		{
			if (disableBefore)
			{
				EnableReminder(itemID, value: false, updateSwitch: false);
			}
			DreamOSDataManager.DeleteData(dataCat, itemID + "_IsEnabled");
			DreamOSDataManager.DeleteData(dataCat, itemID + "_Title");
			DreamOSDataManager.DeleteData(dataCat, itemID + "_Type");
			DreamOSDataManager.DeleteData(dataCat, itemID + "_Minute");
			DreamOSDataManager.DeleteData(dataCat, itemID + "_Hour");
			DreamOSDataManager.DeleteData(dataCat, itemID + "_IsPM");
			int currentItemCount = GetCurrentItemCount();
			DreamOSDataManager.WriteIntData(dataCat, "ReminderItemCount", currentItemCount - 1);
		}

		public void CreateReminder()
		{
			int currentItemCount = GetCurrentItemCount();
			if (currentItemCount != reminderLimit)
			{
				DreamOSDataManager.WriteIntData(dataCat, "ReminderItemCount", currentItemCount + 1);
				GameObject gameObject = Object.Instantiate(reminderPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.name = "ReminderItem#" + currentItemCount;
				gameObject.transform.SetParent(reminderParent, worldPositionStays: false);
				ReminderItem rItem = gameObject.GetComponent<ReminderItem>();
				rItem.manager = this;
				rItem.isAM = true;
				rItem.reminderID = gameObject.name;
				rItem.mainButton.onClick.AddListener(delegate
				{
					rItem.InitializeWindow(reminderModal, eventTitleObject, typeSelector, minuteSelector, hourSelector, meridiemSelector);
				});
				rItem.switchManager.onEvents.AddListener(delegate
				{
					EnableReminder(rItem.reminderID, value: true, updateSwitch: false);
				});
				rItem.switchManager.offEvents.AddListener(delegate
				{
					EnableReminder(rItem.reminderID, value: false, updateSwitch: false);
				});
				DateAndTimeManager.TimedEvent timedEvent = new DateAndTimeManager.TimedEvent();
				timedEvent.eventID = gameObject.name;
				timedEvent.eventMinute = 0;
				timedEvent.eventHour = 8;
				timedEvent.meridiemFormat = DateAndTimeManager.DefaultShortTime.AM;
				timedEvent.eventTitle = "Reminder " + (currentItemCount + 1);
				timedEvent.isReminderItem = true;
				timedEvent.isEnabled = true;
				DreamOSDataManager.WriteBooleanData(dataCat, gameObject.name + "_IsEnabled", value: true);
				DreamOSDataManager.WriteStringData(dataCat, gameObject.name + "_Title", "Reminder " + (currentItemCount + 1));
				DreamOSDataManager.WriteIntData(dataCat, gameObject.name + "_Type", 0);
				DreamOSDataManager.WriteIntData(dataCat, gameObject.name + "_Minute", 0);
				DreamOSDataManager.WriteIntData(dataCat, gameObject.name + "_Hour", 8);
				DreamOSDataManager.WriteIntData(dataCat, gameObject.name + "_IsPM", 0);
				rItem.SetOnce();
				rItem.SetTitle("Reminder " + (currentItemCount + 1));
				if (timedEvent.eventMinute < 10)
				{
					rItem.SetTime($"{timedEvent.eventHour}:0{timedEvent.eventMinute} {timedEvent.meridiemFormat}");
				}
				else
				{
					rItem.SetTime($"{timedEvent.eventHour}:{timedEvent.eventMinute} {timedEvent.meridiemFormat}");
				}
				rItem.switchManager.isOn = true;
				rItem.switchManager.UpdateUI();
				activeItems.Add(rItem);
				DateAndTimeManager.instance.timedEvents.Add(timedEvent);
			}
		}

		public void UpdateReminderData(string itemID, string itemTitle, int itemType, int itemMinute, int itemHour, int isPM)
		{
			DreamOSDataManager.WriteIntData(dataCat, itemID + "_Type", itemType);
			DreamOSDataManager.WriteStringData(dataCat, itemID + "_Title", itemTitle);
			DreamOSDataManager.WriteIntData(dataCat, itemID + "_Minute", itemMinute);
			DreamOSDataManager.WriteIntData(dataCat, itemID + "_Hour", itemHour);
			DreamOSDataManager.WriteIntData(dataCat, itemID + "_IsPM", isPM);
		}

		private int GetCurrentItemCount()
		{
			int result = 0;
			if (DreamOSDataManager.ContainsJsonKey(dataCat, "ReminderItemCount"))
			{
				result = DreamOSDataManager.ReadIntData(dataCat, "ReminderItemCount");
			}
			return result;
		}
	}
}
