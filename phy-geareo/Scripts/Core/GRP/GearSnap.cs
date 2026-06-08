using System;
using UnityEngine;

namespace GRP
{
	public class GearSnap
	{
		public struct GearSnapRadialItem
		{
			public Transform transform;

			public int teeth;

			public float angle;

			public float radius;

			public float height;

			public bool insideOut;

			public GearModule module;

			public float Radius()
			{
				return 0f;
			}
		}

		private static CreatedPartContainer createdPart;

		private static GearConfig gearConfig;

		public static bool Snap(CreatedPartContainer createdPart, object gearObj, GearConfig gearConfig)
		{
			return false;
		}

		private static bool Snap<TGear, TOther>(TGear gear, Func<TGear, TOther, bool> func)
		{
			return false;
		}

		private static bool SnapRadial(GearSnapRadialItem gear, GearSnapRadialItem other)
		{
			return false;
		}

		private static bool Snap(SpurGearPartView gear, SpurGearPartView other)
		{
			return false;
		}

		private static bool Snap(SpurGearPartView gear, BevelGearPartView other)
		{
			return false;
		}

		private static bool SnapLinear(GearSnapRadialItem gear, LinearGearPartView other)
		{
			return false;
		}

		private static bool Snap(SpurGearPartView gear, LinearGearPartView other)
		{
			return false;
		}

		private static bool Snap(BevelGearPartView gear, SpurGearPartView other)
		{
			return false;
		}

		private static bool Snap(BevelGearPartView gear, BevelGearPartView other)
		{
			return false;
		}

		private static bool Snap(BevelGearPartView gear, LinearGearPartView other)
		{
			return false;
		}

		private static bool Snap(LinearGearPartView gear, SpurGearPartView other)
		{
			return false;
		}

		private static bool Snap(LinearGearPartView gear, BevelGearPartView other)
		{
			return false;
		}

		private static bool Snap(SpurGearPartView gear, RingGearPartView other)
		{
			return false;
		}
	}
}
