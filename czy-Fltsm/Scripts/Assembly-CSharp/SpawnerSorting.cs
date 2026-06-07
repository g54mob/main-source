using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public static class SpawnerSorting
{
	private static Vector2 _townheartPosition;

	public static void ByDistanceToTownheart<T>(List<T> listToSort) where T : ISpawner
	{
		_townheartPosition = GameManager.WorldManager.World.TownheartMapPosition;
		Sorting.SlowSort(listToSort, DistanceToTownheart);
	}

	private static int DistanceToTownheart<T>(T lhs, T rhs) where T : ISpawner
	{
		if (_townheartPosition.DistanceToSquared(lhs.WorldPosition2D) - _townheartPosition.DistanceToSquared(rhs.WorldPosition2D) < 0f)
		{
			return -1;
		}
		return 1;
	}
}
