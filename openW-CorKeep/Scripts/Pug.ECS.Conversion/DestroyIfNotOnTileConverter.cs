using System.Collections.Generic;
using Pug.Conversion;
using UnityEngine;

public class DestroyIfNotOnTileConverter : Converter
{
	private List<ObjectID> _allowedObjects = new List<ObjectID>();

	private List<ObjectID> _disallowedObjects = new List<ObjectID>();

	public override void Convert(GameObject authoring)
	{
		bool flag = false;
		DestroyEntityIfNotOnTileCD component = default(DestroyEntityIfNotOnTileCD);
		_allowedObjects.Clear();
		_disallowedObjects.Clear();
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		if (TryGetActiveComponent<PlaceableObjectAuthoring>(authoring, out var component2) && !TryGetActiveComponent<CritterAuthoring>(authoring, out var _) && !component2.dontDestroyObjectIfInvalidPlacement)
		{
			flag = true;
			component = new DestroyEntityIfNotOnTileCD
			{
				timer = 1f
			};
			flag2 |= component2.canBePlacedOnAnyWalkableTile;
			flag3 |= component2.canBePlacedOnWater;
			flag4 |= component2.canBePlacedOnLava;
			flag5 |= component2.canBePlacedOnPit;
			flag6 |= component2.canPlaceOnSideOfWall;
			flag7 |= component2.canBePlacedOnBlockingObjects;
			flag8 |= component2.canBePlacedOnLowColliders;
			foreach (ObjectID canBePlacedOnObject in component2.canBePlacedOnObjects)
			{
				_allowedObjects.Add(canBePlacedOnObject);
			}
			foreach (ObjectID canNotBePlacedOnObject in component2.canNotBePlacedOnObjects)
			{
				_disallowedObjects.Add(canNotBePlacedOnObject);
			}
		}
		if (TryGetActiveComponent<DestroyIfNotOnTileAuthoring>(authoring, out var component4))
		{
			flag = true;
			ObjectID validTileObject = component4.validTileObject;
			if (validTileObject != ObjectID.None && !_allowedObjects.Contains(validTileObject))
			{
				_allowedObjects.Add(validTileObject);
			}
			flag2 |= component4.canBePlacedOnAnyWalkableTile;
			flag3 |= component4.canBePlacedOnWater;
			flag4 |= component4.canBePlacedOnLava;
			flag5 |= component4.canBePlacedOnPit;
		}
		if (flag)
		{
			AddComponentData(component);
		}
		if (flag2)
		{
			SetProperty("CanBePlaced/onAnyWalkableTile");
		}
		if (flag3)
		{
			SetProperty("CanBePlaced/onWater");
		}
		if (flag4)
		{
			SetProperty("CanBePlaced/onLava");
		}
		if (flag5)
		{
			SetProperty("CanBePlaced/onPit");
		}
		if (flag6)
		{
			SetProperty("CanBePlaced/canPlaceOnSideOfWall");
		}
		if (flag7)
		{
			SetProperty("CanBePlaced/onBlockingObjects");
		}
		if (flag8)
		{
			SetProperty("CanBePlaced/onLowColliders");
		}
		if (_allowedObjects.Count > 0)
		{
			SetPropertyList("CanBePlaced/allowedObjects", _allowedObjects.ToArray());
		}
		if (_disallowedObjects.Count > 0)
		{
			SetPropertyList("CanBePlaced/disallowedObjects", _disallowedObjects.ToArray());
		}
	}
}
