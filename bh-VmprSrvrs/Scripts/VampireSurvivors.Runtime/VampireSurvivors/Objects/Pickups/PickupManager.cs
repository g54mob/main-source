using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Items;
using Zenject;

namespace VampireSurvivors.Objects.Pickups
{
	[UsedImplicitly]
	public class PickupManager : IInitializable, IDisposable
	{
		private static PickupFactory _pickupFactory;

		private static readonly List<Pickup> PickupItems;

		public static List<Pickup> Pickups => null;

		public static PickupFactory PickupFactory => null;

		[Inject]
		private void Construct(PickupFactory pickupFactory)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static Pickup CreatePickup(Vector2 pos, ItemType itemType, bool onlineSynchronization = true)
		{
			return null;
		}

		public static void ReturnPickup(Pickup pickup)
		{
		}

		public static void RemovePickup(Pickup pickup)
		{
		}

		public static void AddPickup(Pickup pickup)
		{
		}

		public static void Cleanup()
		{
		}

		public static bool IsPickupItemInWorld(ItemType itemType)
		{
			return false;
		}

		public static Pickup GetPickupItemFromWorld(ItemType itemType)
		{
			return null;
		}

		public static PickupRelic GetRelicItemFromWorld(ItemType relicType)
		{
			return null;
		}

		public static List<Pickup> GetAllPickupsOfTypes(params ItemType[] types)
		{
			return null;
		}

		public static bool IsWeaponPickupItemInWorld(WeaponType weaponType)
		{
			return false;
		}

		public static PickupWeapon GetPickupWeaponFromWorld(WeaponType weaponType)
		{
			return null;
		}

		private void GeneratePools()
		{
		}

		public static ObjectPool GetPool(ItemType itemType)
		{
			return null;
		}
	}
}
