using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class SlotLibrary : SlotLibraryBase
	{
		[SerializeField]
		protected SlotDataAsset[] slotElementList;

		[NonSerialized]
		private Dictionary<int, SlotDataAsset> slotDictionary;

		private void Awake()
		{
		}

		public override void UpdateDictionary()
		{
		}

		public override void ValidateDictionary()
		{
		}

		public override void AddSlotAsset(SlotDataAsset slot)
		{
		}

		public override bool HasSlot(string name)
		{
			return false;
		}

		public override bool HasSlot(int nameHash)
		{
			return false;
		}

		public override SlotData InstantiateSlot(string name)
		{
			return null;
		}

		public override SlotData InstantiateSlot(int nameHash)
		{
			return null;
		}

		public override SlotData InstantiateSlot(string name, List<OverlayData> overlayList)
		{
			return null;
		}

		public override SlotData InstantiateSlot(int nameHash, List<OverlayData> overlayList)
		{
			return null;
		}

		private SlotData Internal_InstantiateSlot(int nameHash)
		{
			return null;
		}

		public override SlotDataAsset[] GetAllSlotAssets()
		{
			return null;
		}
	}
}
