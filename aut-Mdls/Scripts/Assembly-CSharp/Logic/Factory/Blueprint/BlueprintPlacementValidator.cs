using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.FactoryFloor;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

namespace Logic.Factory.Blueprint
{
	public static class BlueprintPlacementValidator
	{
		private static ConcurrentQueue<Vector3Int> _invalidHardLinkPositionsQueue = new ConcurrentQueue<Vector3Int>();

		public static bool CanBePlaced(Vector3Int newPosition, Blueprint blueprint, FactoryLayer factoryLayer, FactoryLayer terrainLayer, bool isBeingMoved = false)
		{
			bool canBePlaced = true;
			Parallel.ForEach(blueprint.Elements, delegate(BlueprintElement element)
			{
				foreach (Vector3Int relativePosition in element.RelativePositions)
				{
					Vector3Int position = newPosition + relativePosition;
					if (!element.ObjectData.IsValidPosition(position, blueprint.Rotation + element.Rotation % 360, newPosition + element.RelativePositions[0], factoryLayer, terrainLayer, element.CreatedId, blueprint, isBeingMoved, element))
					{
						canBePlaced = false;
					}
				}
			});
			return canBePlaced;
		}

		public static int CanBePlacedPerIndex(Vector3Int newPosition, Blueprint blueprint, FactoryLayer factoryLayer, FactoryLayer terrainLayer, List<bool> canPlaceElements, bool isBeingMoved = false)
		{
			_invalidHardLinkPositionsQueue.Clear();
			canPlaceElements.Clear();
			canPlaceElements.AddRange(new bool[blueprint.Elements.Count]);
			int count = blueprint.Elements.Count;
			List<Vector3Int> invalidHardLinkPositions = CollectionPool<List<Vector3Int>, Vector3Int>.Get();
			Parallel.For(0, blueprint.Elements.Count, delegate(int i)
			{
				BlueprintElement blueprintElement = blueprint.Elements[i];
				bool value = true;
				foreach (Vector3Int relativePosition in blueprintElement.RelativePositions)
				{
					Vector3Int position = newPosition + relativePosition;
					if (!blueprintElement.ObjectData.IsValidPosition(position, blueprint.Rotation + blueprintElement.Rotation, newPosition + blueprintElement.RelativePositions[0], factoryLayer, terrainLayer, blueprintElement.CreatedId, blueprint, isBeingMoved, blueprintElement))
					{
						value = false;
						_invalidHardLinkPositionsQueue.Enqueue(blueprintElement.RelativePositions[0]);
						break;
					}
				}
				canPlaceElements[i] = value;
			});
			invalidHardLinkPositions.AddRange(_invalidHardLinkPositionsQueue);
			_invalidHardLinkPositionsQueue.Clear();
			Parallel.For(0, blueprint.Elements.Count, delegate(int i)
			{
				if (canPlaceElements[i])
				{
					BlueprintElement blueprintElement = blueprint.Elements[i];
					if (!blueprintElement.HardLinkedToRelativePositions.IsNullOrEmpty())
					{
						foreach (Vector3Int hardLinkedToRelativePosition in blueprintElement.HardLinkedToRelativePositions)
						{
							if (invalidHardLinkPositions.Contains(hardLinkedToRelativePosition))
							{
								canPlaceElements[i] = false;
								_invalidHardLinkPositionsQueue.Enqueue(blueprintElement.RelativePositions[0]);
								break;
							}
						}
					}
				}
			});
			invalidHardLinkPositions.AddRange(_invalidHardLinkPositionsQueue);
			int result = count - invalidHardLinkPositions.Count;
			CollectionPool<List<Vector3Int>, Vector3Int>.Release(invalidHardLinkPositions);
			return result;
		}

		public static void RemoveNonPlaceableBlueprintElements(Blueprint blueprint, List<bool> canBePlaced)
		{
			for (int num = canBePlaced.Count - 1; num >= 0; num--)
			{
				if (!canBePlaced[num])
				{
					BlueprintElement blueprintElement = blueprint.Elements[num];
					if (blueprintElement.IsHardLinked)
					{
						for (int i = 0; i < blueprint.Elements.Count; i++)
						{
							Vector3Int item = blueprint.Elements[i].RelativePositions[0];
							if (blueprintElement.HardLinkedToRelativePositions.Contains(item))
							{
								if (i > num)
								{
									blueprint.Elements.RemoveAt(i);
								}
								else
								{
									canBePlaced[i] = false;
								}
							}
						}
					}
					blueprint.Elements.RemoveAt(num);
				}
			}
		}
	}
}
