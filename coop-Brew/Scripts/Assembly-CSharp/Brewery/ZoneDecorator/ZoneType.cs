using UnityEngine;

namespace Brewery.ZoneDecorator
{
	public enum ZoneType
	{
		[Tooltip("Side areas of houses - barrels, pots, chairs, tools")]
		HouseSide = 0,
		[Tooltip("Behind houses/barns - hay bales, wood stacks, equipment")]
		HouseBack = 1,
		[Tooltip("Along roads (not ON roads) - letterboxes, signs, grass")]
		Roadside = 2,
		[Tooltip("Gravel/dirt areas - pebbles, small rocks")]
		GravelArea = 3,
		[Tooltip("Near trees/forests - stumps, flowers, rocks")]
		ForestEdge = 4,
		[Tooltip("Along fences (outside) - pots, tools, produce boxes")]
		FenceLine = 5,
		[Tooltip("Open meadows/pastures - grass, wildflowers")]
		OpenField = 6,
		[Tooltip("Around ponds/water - reeds, lily pads, shore rocks")]
		WaterEdge = 7,
		[Tooltip("Around barns - hay stacks, troughs, farm tools")]
		BarnYard = 8,
		[Tooltip("Decorative focal points - pumpkins, sunflowers, beehives")]
		DecorativeCorner = 9
	}
}
