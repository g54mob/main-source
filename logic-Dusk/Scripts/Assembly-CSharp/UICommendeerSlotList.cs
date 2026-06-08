using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICommendeerSlotList : MonoBehaviour
{
	public Text numberOfSlotsLabel;

	public UICommandeerSlot slotPrefab;

	private List<UICommandeerSlot> slots;

	private int looseUpgradeCount;

	private int fixedUpgradeCount;

	public int Count
	{
		get
		{
			if (slots != null)
			{
				return slots.Count;
			}
			return 0;
		}
	}

	public void Clear()
	{
		if (slots != null)
		{
			foreach (UICommandeerSlot slot in slots)
			{
				if (slot != null)
				{
					Object.Destroy(slot.gameObject);
				}
			}
			slots.Clear();
		}
		looseUpgradeCount = 0;
		fixedUpgradeCount = 0;
		numberOfSlotsLabel.text = "Upgrade Slots: 0";
	}

	public void AddSlot(BaseShipUpgrade upgrade, bool isFixed)
	{
		if (slots == null)
		{
			slots = new List<UICommandeerSlot>();
		}
		GameObject gameObject = (GameObject)Object.Instantiate(slotPrefab.gameObject, Vector3.zero, Quaternion.identity);
		UICommandeerSlot component = gameObject.GetComponent<UICommandeerSlot>();
		if (upgrade != null)
		{
			component.SetFilled(DroneManager.GetShipUpgradeText(upgrade), DroneManager.GetUpgradeStatus(upgrade, false));
		}
		else
		{
			component.SetFilled(string.Empty, Color.gray);
		}
		if (isFixed)
		{
			component.SetIsPermanent();
		}
		component.transform.parent = base.gameObject.transform;
		slots.Add(component);
		if (!isFixed)
		{
			looseUpgradeCount++;
		}
		else
		{
			fixedUpgradeCount++;
		}
		if (fixedUpgradeCount == 0)
		{
			numberOfSlotsLabel.text = string.Format("Upgrade Slots: {0}", looseUpgradeCount);
		}
		else
		{
			numberOfSlotsLabel.text = string.Format("Upgrade Slots: {0} ({1})", looseUpgradeCount, fixedUpgradeCount);
		}
	}

	public void UpdateSlotStatus(SlotInfo slot)
	{
		if (slots != null && slot.SlotNumber < slots.Count)
		{
			if (slot.BrokenState == BrokenStateEnum.Broken)
			{
				slots[slot.SlotNumber].borderImage.color = Color.red;
			}
			else if (slot.BreakProbability > 25f)
			{
				slots[slot.SlotNumber].borderImage.color = GlobalSettings.Constants.ORANGE;
			}
			else if (slot.BreakProbability > 15f)
			{
				slots[slot.SlotNumber].borderImage.color = Color.yellow;
			}
		}
	}
}
