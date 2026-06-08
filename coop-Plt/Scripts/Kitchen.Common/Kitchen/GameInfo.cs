using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public static class GameInfo
	{
		public static List<Dish> CurrentlyAvailableDishes = new List<Dish>();

		public static List<ICard> AllCurrentCards = new List<ICard>();

		public static List<Dish> DishUpgrades = new List<Dish>();

		public static SceneType CurrentScene;

		public static int CurrentDay;

		public static bool IsPreparationTime;

		public static RestaurantSetting CurrentSetting;

		public static Bounds CurrentGameplayBounds;

		public static Bounds GetCurrentPlayableBounds(bool expand_slightly = true, bool contract_slightly = false)
		{
			Bounds result = CurrentGameplayBounds;
			result.Encapsulate(result.min + new Vector3(0f, 0f, -2f));
			if (expand_slightly)
			{
				result.Expand(0.1f);
			}
			if (contract_slightly)
			{
				result = new Bounds(result.center, new Vector3(result.size.x - 0.1f, result.size.y, result.size.z - 0.1f));
			}
			return result;
		}

		public static Vector3 RestrictToPlayableBounds(Vector3 source)
		{
			return GetCurrentPlayableBounds().ClosestPoint(source);
		}
	}
}
