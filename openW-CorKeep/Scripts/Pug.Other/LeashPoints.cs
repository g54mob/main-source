using System;
using Pug.UnityExtensions;
using UnityEngine;

[Serializable]
public class LeashPoints
{
	public Vector3 behind;

	public Vector3 infront;

	public Vector3 left;

	public Vector3 right;

	public Vector3 GetLeashPoint(Vector3 direction)
	{
		return Direction.FromVector(direction).id switch
		{
			Direction.Id.back => infront, 
			Direction.Id.forward => behind, 
			Direction.Id.left => left, 
			Direction.Id.right => right, 
			_ => infront, 
		};
	}
}
