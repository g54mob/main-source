using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Seasonal Layout", menuName = "Kitchen/Seasonal Decoration Layout", order = 3)]
	public class SeasonalDecorationLayout : GameDataObject
	{
		public struct Decoration
		{
			public Appliance Appliance;

			public Vector3 Position;

			public Vector3 Facing;
		}

		public struct DecorOverride
		{
			public int RoomID;

			public Decor Decor;
		}

		public Season SeasonActive;

		public List<Decoration> Decorations = new List<Decoration>();

		public List<DecorOverride> DecorOverrides = new List<DecorOverride>();

		protected override void InitialiseDefaults()
		{
		}
	}
}
