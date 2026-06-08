using KitchenData;
using MessagePack;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[MessagePackObject(false)]
	public struct CLocationChoice : IApplianceProperty, IAttachableProperty, IComponentData
	{
		[Key(0)]
		public SaveState State;

		[Key(1)]
		public int Slot;

		[Key(2)]
		public int Setting;

		[Key(3)]
		public Seed Seed;

		[Key(4)]
		public int FranchiseTier;

		[Key(5)]
		public FixedString64 RestaurantName;

		[Key(6)]
		public FixedString64 RestaurantSafeName;

		[Key(7)]
		public int Day;

		[Key(8)]
		public int MainDish;

		[Key(9)]
		public int RunID;
	}
}
