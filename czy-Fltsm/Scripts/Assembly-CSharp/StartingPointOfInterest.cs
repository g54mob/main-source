using System;
using UnityEngine;

[Serializable]
public struct StartingPointOfInterest
{
	[Tooltip("Point of interest that the game will start at.")]
	public PointOfInterestProperties PointOfInterest;

	[Tooltip("Position to place the starting point of interest at.")]
	[ConditionalHide("StartingPointOfInterest")]
	public Vector3 PositionPointOfInterest;
}
