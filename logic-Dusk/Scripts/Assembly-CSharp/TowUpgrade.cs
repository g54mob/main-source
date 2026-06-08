using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "tow";

	private const float MAX_TOW_DISTANCE = 1.2f;

	private const float TOW_BREAK_DISTANCE = 5f;

	private const float VISUAL_TOGGLE_DURATION = 0.6f;

	private static List<CommandDefinition> commandList;

	private ITowItem _itemBeingTowed;

	private float _visualToggleTimer;

	public override string CommandValue
	{
		get
		{
			return "tow";
		}
	}

	public TowUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	protected override void OnUpdate()
	{
		if (base.IsActivated && _itemBeingTowed != null)
		{
			_visualToggleTimer -= Time.deltaTime;
			if (_visualToggleTimer <= 0f)
			{
				_visualToggleTimer = 0.6f;
				_itemBeingTowed.StartColorBlink(_itemBeingTowed.TowColor, 0.6f, 1);
			}
			float num = Vector3.Distance(drone.transform.position, _itemBeingTowed.TowItemTransform.position);
			if (num > 5f)
			{
				CancelAbility();
			}
			else if (num > 1.2f)
			{
				Quaternion rotation = Quaternion.LookRotation(drone.transform.position - _itemBeingTowed.TowItemTransform.position, Vector3.back);
				rotation.x = 0f;
				rotation.y = 0f;
				_itemBeingTowed.PreRotation();
				_itemBeingTowed.TowItemTransform.rotation = rotation;
				_itemBeingTowed.PostRotation();
				_itemBeingTowed.MoveForwardForced(drone.CurrentMaxSpeed + 0.2f);
			}
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("TowUpgrade"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "tow":
		{
			if (base.IsActivated)
			{
				command.Handled = true;
				CancelAbility();
				break;
			}
			command.Handled = true;
			_itemBeingTowed = null;
			string target = string.Empty;
			if (command.Arguments.Count > 0)
			{
				foreach (string argument in command.Arguments)
				{
					if (argument != "all")
					{
						target = argument;
						break;
					}
				}
			}
			List<ITowItem> towableItemsInRange = GetTowableItemsInRange(target);
			if (towableItemsInRange.Count == 0)
			{
				if (!MoveAndTowItemInRange(command, target))
				{
					SendConsoleResponseMessage("Nothing to tow within range", ConsoleMessageType.Info);
					ReportReasonsForTowNotAllowed();
				}
				else
				{
					command.Handled = true;
				}
				break;
			}
			if (command.Arguments.Count == 0 || (command.Arguments.Count == 1 && command.Arguments[0] == "all"))
			{
				if (towableItemsInRange.Count > 0)
				{
					_itemBeingTowed = towableItemsInRange.First();
				}
			}
			else if (command.Arguments.Count == 1 || (command.Arguments.Count == 2 && command.Arguments[0] == "all"))
			{
				string value = command.Arguments.Last().ToLower();
				foreach (ITowItem item in towableItemsInRange)
				{
					if (item.TowId.ToLower().StartsWith(value))
					{
						_itemBeingTowed = item;
						break;
					}
					if (item is IDrone && ((IDrone)item).DroneName.ToLower().StartsWith(value))
					{
						_itemBeingTowed = item;
						break;
					}
				}
				if (_itemBeingTowed == null)
				{
					SendConsoleResponseMessage(string.Format("Could not locate: {0}", command.Arguments.Last()), ConsoleMessageType.Info);
				}
			}
			else
			{
				SendConsoleResponseMessage("Too many arguments specified", ConsoleMessageType.Info);
			}
			if (_itemBeingTowed != null && ActivateAbility())
			{
				drone.BeginTowItem(_itemBeingTowed);
				_itemBeingTowed.CanBeTowed = false;
				_itemBeingTowed.IsBeingTowed = true;
				SendConsoleResponseMessage(string.Format("Towing {0}\r\nAll salvage must be placed in docking bay prior to departure.", _itemBeingTowed.TowFriendlyId), ConsoleMessageType.Info);
			}
			break;
		}
		}
	}

	private List<ITowItem> GetTowableItemsInRange(string target)
	{
		List<ITowItem> list = new List<ITowItem>();
		target = target.ToLower();
		int count = TowManager.Instance.knownTowableItems.Count;
		for (int i = 0; i < count; i++)
		{
			object obj = TowManager.Instance.knownTowableItems[i];
			if (!(obj is ITowItem))
			{
				continue;
			}
			if (target != string.Empty)
			{
				if (obj is IDrone)
				{
					if (!((IDrone)obj).DroneName.ToLower().StartsWith(target))
					{
						continue;
					}
				}
				else if (!TowManager.Instance.knownTowableItems[i].TowId.ToLower().StartsWith(target))
				{
					continue;
				}
			}
			ITowItem towItem = (ITowItem)obj;
			if (towItem.CanBeTowed && towItem != drone && towItem != null && towItem.TowItemTransform != null)
			{
				float num = Vector3.Distance(drone.transform.position, towItem.TowItemTransform.position);
				if (num <= 1.2f)
				{
					list.Add(towItem);
				}
			}
		}
		return list;
	}

	private bool MoveAndTowItemInRange(ExecutedCommand command, string target)
	{
		bool result = false;
		Object[] array = Object.FindObjectsOfType(typeof(MonoBehaviour));
		List<ITowItem> list = null;
		Object[] array2 = array;
		foreach (object obj in array2)
		{
			if (!(obj is ITowItem))
			{
				continue;
			}
			if (target != string.Empty)
			{
				if (obj is IDrone)
				{
					if (!((IDrone)obj).DroneName.ToLower().StartsWith(target.ToLower()))
					{
						continue;
					}
				}
				else if (!((ITowItem)obj).TowId.ToLower().StartsWith(target))
				{
					continue;
				}
			}
			ITowItem towItem = (ITowItem)obj;
			if (!towItem.CanBeTowed || towItem == drone || towItem.IsBeingTowed)
			{
				continue;
			}
			bool flag = false;
			if (!(drone.CurrentRoom != null))
			{
				continue;
			}
			flag = drone.CurrentRoom.GetComponent<Collider>().bounds.Intersects(towItem.UnderlyingGameObject.GetComponent<Collider>().bounds);
			bool flag2 = false;
			if (!flag && drone.CurrentRoom.corridors != null)
			{
				foreach (Corridor corridor in drone.CurrentRoom.corridors)
				{
					flag2 = corridor.GetComponent<Collider>().bounds.Intersects(towItem.UnderlyingGameObject.GetComponent<Collider>().bounds);
					if (flag2)
					{
						break;
					}
				}
			}
			if (flag || flag2)
			{
				if (list == null)
				{
					list = new List<ITowItem>();
				}
				list.Add(towItem);
			}
		}
		if (list != null)
		{
			float num = float.MaxValue;
			ITowItem towItem2 = null;
			foreach (ITowItem item in list)
			{
				float num2 = Vector3.Distance(drone.transform.position, item.TowItemTransform.position);
				if (num2 < num)
				{
					num = num2;
					towItem2 = item;
				}
			}
			if (towItem2 != null)
			{
				drone.NavigateToAndExecuteCommand(towItem2.UnderlyingGameObject, command, CollisionType.Proximity, 1.2f);
				result = true;
			}
		}
		return result;
	}

	private void ReportReasonsForTowNotAllowed()
	{
		Object[] array = Object.FindObjectsOfType(typeof(MonoBehaviour));
		Object[] array2 = array;
		foreach (object obj in array2)
		{
			if (!(obj is ITowItem))
			{
				continue;
			}
			ITowItem towItem = (ITowItem)obj;
			if (towItem != drone && !towItem.CanBeTowed)
			{
				float num = Vector3.Distance(drone.transform.position, towItem.TowItemTransform.position);
				if (num <= 1.2f && !string.IsNullOrEmpty(towItem.CantTowReason))
				{
					SendConsoleResponseMessage(towItem.CantTowReason, ConsoleMessageType.Info);
				}
			}
		}
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		if (_itemBeingTowed != null)
		{
			_itemBeingTowed.CanBeTowed = true;
			_itemBeingTowed.IsBeingTowed = false;
			drone.EndTowItem();
		}
		_itemBeingTowed = null;
		SendConsoleResponseMessage("Stopped towing", ConsoleMessageType.Info);
	}
}
