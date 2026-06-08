using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public static class Add
	{
		public static TutorialAction Appliance(int appliance, Vector3 pos, Vector3 facing)
		{
			return new TutorialSpawnAppliance(appliance, pos, facing);
		}

		public static TutorialAction Provider(int provider_of, Vector3 pos, Vector3 facing)
		{
			return new TutorialSpawnAppliance(provider_of, pos, facing, is_provider: true);
		}

		public static TutorialAction Table(Vector3 pos, Vector3 facing)
		{
			return new TutorialSpawnTable(pos, facing);
		}

		public static TutorialAction Item(int item_id, Vector3 pos)
		{
			return new TutorialSpawnItem(item_id, pos);
		}

		public static TutorialAction Customer(Vector3 pos, int count = 1, bool order_sides = false, bool low_patience = false)
		{
			return new TutorialSpawnCustomer(pos, count, order_sides, low_patience);
		}

		public static TutorialAction Main(int item, params int[] ingredients)
		{
			return new TutorialAddMenuItem(item, MenuPhase.Main, ingredients);
		}

		public static TutorialAction Side(int item, params int[] ingredients)
		{
			return new TutorialAddMenuItem(item, MenuPhase.Side, ingredients);
		}

		public static TutorialAction Fire(Vector3 location)
		{
			return new TutorialSetFire(location);
		}
	}
}
