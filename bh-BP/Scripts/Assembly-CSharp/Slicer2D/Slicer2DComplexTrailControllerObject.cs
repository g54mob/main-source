using System;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DComplexTrailControllerObject : Slicer2DControllerObject
	{
		public ComplexSlicerTrail[] complexTrail;

		public Vector3[][] trailPositions;

		public TrailRenderer[] trailRenderer;

		public int trailRendererCount;

		public bool addForce;

		public float addForceAmount;

		public void Initialize()
		{
		}

		public void Update()
		{
		}

		public void Draw(Transform transform)
		{
		}

		public void SetTrailPosition(TrailRenderer trail, int id)
		{
		}
	}
}
