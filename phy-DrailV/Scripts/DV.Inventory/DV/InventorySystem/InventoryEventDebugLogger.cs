using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public class InventoryEventDebugLogger : MonoBehaviour
	{
		private void Awake()
		{
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryStatusChanged;
			}
			else if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
			}
		}

		private string GetFlags(InventoryActionType flags)
		{
			bool flag = flags.HasAnyIntFlag(InventoryActionType.Add);
			bool flag2 = flags.HasAnyIntFlag(InventoryActionType.Drop);
			bool flag3 = flags.HasAnyIntFlag(InventoryActionType.Move);
			bool flag4 = flags.HasAnyIntFlag(InventoryActionType.Swap);
			bool flag5 = flags.HasAnyIntFlag(InventoryActionType.Purge);
			bool flag6 = flags.HasAnyIntFlag(InventoryActionType.Equip);
			bool flag7 = flags.HasAnyIntFlag(InventoryActionType.Unequip);
			bool flag8 = flags.HasAnyIntFlag(InventoryActionType.Lock);
			bool flag9 = flags.HasAnyIntFlag(InventoryActionType.Unlock);
			bool flag10 = flags.HasAnyIntFlag(InventoryActionType.Reserve);
			bool flag11 = flags.HasAnyIntFlag(InventoryActionType.Unreserve);
			bool flag12 = flags.HasAnyIntFlag(InventoryActionType.Destroy);
			return Mark(flag) + " Add       \n" + Mark(flag2) + " Drop      \n" + Mark(flag3) + " Move      \n" + Mark(flag4) + " Swap      \n" + Mark(flag5) + " Purge     \n" + Mark(flag6) + " Equip     \n" + Mark(flag7) + " Unequip   \n" + Mark(flag8) + " Lock      \n" + Mark(flag9) + " Unlock    \n" + Mark(flag10) + " Reserve   \n" + Mark(flag11) + " Unreserve \n" + Mark(flag12) + " Destroy   ";
			string Mark(bool on)
			{
				if (!on)
				{
					return " ";
				}
				return "X";
			}
		}

		private string GetSlotState(InventorySlotState state)
		{
			return $"slot: {state.slotIndex}\n" + "item: " + ((state.item == null) ? "(null)" : state.item.name) + "\n" + $"itemState: {state.itemState}\n" + $"isLocked: {state.isLocked}\n" + $"isReserved: {state.isReserved}\n" + $"equipSlot: {state.equipSlot}";
		}

		private void OnInventoryStatusChanged(InventorySlotState primarySlotState, InventoryActionType primaryActionType, InventorySlotState secondarySlotState, InventoryActionType secondaryActionType)
		{
			string left = Title("Primary", Horizontal(GetSlotState(primarySlotState), GetFlags(primaryActionType), " "));
			string right = Title("Secondary", Horizontal(GetSlotState(secondarySlotState), GetFlags(secondaryActionType), " "));
			string content = Horizontal(left, right, " | ");
			Debug.Log(Title($"frame: {Time.frameCount}", content));
		}

		private static string Horizontal(string left, string right, string separator)
		{
			(string, string) tuple = MakeSameNumberOfLines(MakeLinesSameLength(left), MakeLinesSameLength(right));
			left = tuple.Item1;
			right = tuple.Item2;
			string[] first = left.Split('\n');
			string[] second = right.Split('\n');
			IEnumerable<string> values = first.Zip(second, (string l, string r) => l + separator + r);
			return string.Join("\n", values);
		}

		private static (string, string) MakeSameNumberOfLines(string left, string right)
		{
			string[] array = left.Split('\n');
			string[] array2 = right.Split('\n');
			int num = Mathf.Max(array.Length, array2.Length);
			if (array.Length < num)
			{
				int count = array.Max((string l) => l.Length);
				int count2 = num - array.Length;
				array = array.Concat(Enumerable.Repeat(new string(' ', count), count2)).ToArray();
			}
			if (array2.Length < num)
			{
				int count3 = array2.Max((string l) => l.Length);
				int count4 = num - array.Length;
				array2 = array2.Concat(Enumerable.Repeat(new string(' ', count3), count4)).ToArray();
			}
			return (string.Join("\n", array), string.Join("\n", array2));
		}

		private static string MakeLinesSameLength(string content)
		{
			string[] array = content.Split('\n');
			int totalWidth = array.Max((string line) => line.Length);
			for (int num = 0; num < array.Length; num++)
			{
				array[num] = array[num].PadRight(totalWidth);
			}
			return string.Join("\n", array);
		}

		private static string Title(string title, string content)
		{
			string text = new string('\u00af', title.Length);
			int num = content.Split('\n').Max((string line) => line.Length);
			int num2 = (num - title.Length) / 2;
			string text2 = new string(' ', num2);
			string text3 = new string(' ', num - title.Length - num2);
			title = text2 + title + text3;
			text = text2 + text + text3;
			return title + "\n" + text + "\n" + content;
		}
	}
}
