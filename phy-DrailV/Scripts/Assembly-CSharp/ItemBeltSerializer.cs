using System.Collections.Generic;
using DV.CabControls.VRTK;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

public static class ItemBeltSerializer
{
	private const int BELT_VISIBLE_SAVE_VALUE = 0;

	private const int BELT_HIDDEN_SAVE_VALUE = 1;

	private static Vector3[] positions;

	private static Vector3[] rotations;

	private static int[] states;

	private static List<StorageItemData> items;

	public static void SaveBeltSlotTransformData(ItemBeltVR itemBeltVR)
	{
		if (!SingletonBehaviour<SaveGameManager>.Instance || SingletonBehaviour<SaveGameManager>.Instance.data == null || !VRManager.IsVREnabled())
		{
			return;
		}
		BeltSnapPointAdjuster[] beltAdjusters = itemBeltVR.GetBeltAdjusters();
		if (beltAdjusters == null)
		{
			Debug.LogWarning("There are no BeltSnapPointAdjusters. Saving belt slot transform values skipped.");
			return;
		}
		CheckAndInitializeCaches(beltAdjusters.Length);
		for (int i = 0; i < beltAdjusters.Length; i++)
		{
			Transform transform = beltAdjusters[i].transform;
			positions[i] = transform.localPosition;
			rotations[i] = transform.localRotation.eulerAngles;
		}
		SingletonBehaviour<SaveGameManager>.Instance.data.SetVector3Array("Belt_slot_positions", positions);
		SingletonBehaviour<SaveGameManager>.Instance.data.SetVector3Array("Belt_slot_rotations", rotations);
	}

	private static void CheckAndInitializeCaches(int desiredLength)
	{
		if (positions == null || rotations == null || positions.Length != desiredLength || rotations.Length != desiredLength || states == null || states.Length != desiredLength)
		{
			positions = new Vector3[desiredLength];
			rotations = new Vector3[desiredLength];
			states = new int[desiredLength];
		}
	}

	public static void LoadBeltSlotTransformData(ItemBeltVR itemBeltVR)
	{
		if (!SingletonBehaviour<SaveGameManager>.Instance || SingletonBehaviour<SaveGameManager>.Instance.data == null)
		{
			return;
		}
		BeltSnapPointAdjuster[] beltAdjusters = itemBeltVR.GetBeltAdjusters();
		Vector3?[] vector3Array = SingletonBehaviour<SaveGameManager>.Instance.data.GetVector3Array("Belt_slot_positions");
		Vector3?[] vector3Array2 = SingletonBehaviour<SaveGameManager>.Instance.data.GetVector3Array("Belt_slot_rotations");
		if (vector3Array != null)
		{
			if (vector3Array.Length == beltAdjusters.Length)
			{
				for (int i = 0; i < vector3Array.Length; i++)
				{
					Vector3? vector = vector3Array[i];
					if (vector.HasValue && !NumberUtil.AnyInfinityMinMaxNaN(vector.Value))
					{
						beltAdjusters[i].UpdatePosition(vector.Value);
					}
					else
					{
						Debug.LogWarning($"Belt slot position at index '{i}' has a null or an illegal value '{vector}'.");
					}
				}
			}
			else
			{
				Debug.LogWarning($"Item belt slot position save data size mismatch - expected '{beltAdjusters.Length}', loaded '{vector3Array.Length}'. Positions not loaded.");
			}
		}
		if (vector3Array2 == null)
		{
			return;
		}
		if (vector3Array2.Length == beltAdjusters.Length)
		{
			for (int j = 0; j < vector3Array2.Length; j++)
			{
				Vector3? vector2 = vector3Array2[j];
				BeltSnapPointAdjuster beltSnapPointAdjuster = beltAdjusters[j];
				Transform transform = beltSnapPointAdjuster.transform;
				if (vector2.HasValue && !NumberUtil.AnyInfinityMinMaxNaN(vector2.Value))
				{
					transform.localRotation = Quaternion.Euler(vector2.Value);
					beltSnapPointAdjuster.UpdateSnapPointRotation();
				}
				else
				{
					Debug.LogWarning($"Belt slot rotation at index '{j}' has a null or an illegal value '{vector2}'.");
				}
			}
		}
		else
		{
			Debug.LogWarning($"Item belt slot rotation save data size mismatch - expected '{beltAdjusters.Length}', loaded '{vector3Array2.Length}'. Rotations not loaded.");
		}
	}

	public static void SaveBeltSlotState(ItemBeltVR itemBeltVR, int index, bool state)
	{
		if ((bool)SingletonBehaviour<SaveGameManager>.Instance && SingletonBehaviour<SaveGameManager>.Instance.data != null)
		{
			if (!SingletonBehaviour<Inventory>.Instance.IsValidVRBeltIndex(index))
			{
				Debug.LogError(string.Format("{0}: Index out of range: {1}, max index: {2}. State not saved.", "ItemBeltSerializer", index, states.Length - 1));
				return;
			}
			CheckAndInitializeCaches(itemBeltVR.GetBeltAdjusters().Length);
			int num = SingletonBehaviour<Inventory>.Instance.BeltIndexFromInventoryIndex(index);
			states[num] = ((!state) ? 1 : 0);
			SingletonBehaviour<SaveGameManager>.Instance.data.SetIntArray("Belt_slot_states", states);
		}
	}

	public static void LoadBeltSlotStatesData(ItemBeltVR itemBeltVR)
	{
		CheckAndInitializeCaches(itemBeltVR.GetBeltAdjusters().Length);
		int[] intArray = SingletonBehaviour<SaveGameManager>.Instance.data.GetIntArray("Belt_slot_states");
		if (intArray == null)
		{
			return;
		}
		BeltSlotState defaultBeltSlotState = SingletonBehaviour<Inventory>.Instance.DefaultBeltSlotState;
		int num = ((defaultBeltSlotState != BeltSlotState.VisibleAndEnabled && defaultBeltSlotState != BeltSlotState.VisibleAndDisabled) ? 1 : 0);
		for (int i = 0; i < intArray.Length; i++)
		{
			int num2 = intArray[i];
			if (!num2.IsInRange(0, 1))
			{
				num2 = num;
				Debug.LogError(string.Format("{0}: Belt slot state at index '{1}' has an illegal state value '{2}'.", "ItemBeltSerializer", i, num2));
			}
			int slot = SingletonBehaviour<Inventory>.Instance.InventoryIndexFromBeltIndex(i);
			BeltSlotState item = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(slot).beltSlotState;
			if (item == BeltSlotState.InvalidSlot)
			{
				Debug.LogError(string.Format("{0}: Given belt slot index is invalid: {1}. State not loaded.", "ItemBeltSerializer", i));
				continue;
			}
			states[i] = num2;
			BeltSlotState desiredState;
			switch (item)
			{
			case BeltSlotState.VisibleAndEnabled:
			case BeltSlotState.HiddenAndEnabled:
				desiredState = ((num2 != 0) ? BeltSlotState.HiddenAndEnabled : BeltSlotState.VisibleAndEnabled);
				break;
			case BeltSlotState.VisibleAndDisabled:
			case BeltSlotState.HiddenAndDisabled:
				desiredState = ((num2 == 0) ? BeltSlotState.VisibleAndDisabled : BeltSlotState.HiddenAndDisabled);
				break;
			default:
				desiredState = defaultBeltSlotState;
				break;
			}
			SingletonBehaviour<Inventory>.Instance.SetBeltVisibilityState(slot, desiredState);
		}
	}
}
