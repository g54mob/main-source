using System.Collections.Generic;
using Kitchen.Layouts;
using UnityEngine;

namespace KitchenData
{
	public struct ReferableObjects
	{
		public int Menu;

		public int DefaultCustomers;

		public LayoutGraph FranchiseLayout;

		public Appliance DefaultProvider;

		public Dictionary<SoundEvent, IAudioAsset> Clips;

		public GameObject CosmeticHatSnapshotPrefab;

		public GameObject CosmeticBodySnapshotPrefab;

		public Texture2D BackIcon;
	}
}
