using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Vehicle.VanShelf
{
	[CreateAssetMenu(fileName = "VanShelfConfig", menuName = "Vehicle/Van Shelf Config", order = 1)]
	public class VanShelfConfig : ScriptableObject
	{
		[Header("Van Identity")]
		[Tooltip("Display name for this van configuration")]
		public string vanName;

		[Header("Shelf Configuration")]
		[Tooltip("List of all shelves in the van")]
		public List<SingleShelfConfig> shelves;

		[Header("Editor Preview")]
		[Tooltip("Enable real-time preview updates when changing display settings in play mode")]
		public bool enableRealtimePreview;

		public int TotalSlotCount => 0;

		public int ShelfCount => 0;

		public static event Action OnConfigChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public IEnumerable<SingleShelfConfig> GetShelvesByWall(VanWall wall)
		{
			return null;
		}

		public int GetShelfStartIndex(int shelfIndex)
		{
			return 0;
		}

		public (int, int) GetShelfSlotRange(int shelfIndex)
		{
			return default((int, int));
		}

		public int GetShelfIndexForSlot(int globalSlotIndex)
		{
			return 0;
		}

		public int GetLocalSlotIndex(int globalSlotIndex)
		{
			return 0;
		}

		public SingleShelfConfig GetShelfConfigForSlot(int globalSlotIndex)
		{
			return null;
		}
	}
}
