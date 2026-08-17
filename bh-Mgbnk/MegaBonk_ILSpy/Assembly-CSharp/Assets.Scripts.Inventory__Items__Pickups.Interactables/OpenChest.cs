using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class OpenChest : MonoBehaviour
{
	public EChest chestType;

	private float delay = 0.6f;

	private float readyForPickupTime;

	private bool pickedup;

	public static Action A_Open;

	private void Awake()
	{
		float num = MyTime.time + delay;
		readyForPickupTime = num;
	}

	private void OnTriggerStay(Collider other)
	{
		if (pickedup || !(MyTime.time > readyForPickupTime))
		{
			return;
		}
		GameObject gameObject = other.gameObject;
		int layer = gameObject.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer == num)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			if (cfGameSettings.skip_chest_animation != 1)
			{
				UiManager instance = UiManager.Instance;
				EEncounter rewardWindowType = ChestUtility.ChestTypeToEncounter(chestType);
				instance.encounterWindows.AddEncounter(rewardWindowType);
			}
			else
			{
				ChestUtility.OpenChestNoAnimation(chestType);
			}
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			Action a_Open = A_Open;
			if (A_Open != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v85.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private bool CanPickup()
	{
		//IL_005b: Invalid comparison between F4 and I4
		if (pickedup)
		{
			return false;
		}
		bool flag = MyTime.time < readyForPickupTime;
		float num = MyTime.time - readyForPickupTime;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}
