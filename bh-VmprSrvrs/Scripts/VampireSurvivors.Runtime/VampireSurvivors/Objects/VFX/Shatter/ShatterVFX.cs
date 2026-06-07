using System;
using UnityEngine;

namespace VampireSurvivors.Objects.VFX.Shatter
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(SpriteRenderer))]
	public class ShatterVFX : GameMonoBehaviour
	{
		public enum ShatterType
		{
			Grid = 0,
			Radial = 1
		}

		[Serializable]
		public class ShatterDetails
		{
			public ShatterType shatterType;

			public int horizontalCuts;

			public int verticalCuts;

			public int horizontalZigzagPoints;

			public float horizontalZigzagSize;

			public int verticalZigzagPoints;

			public float verticalZigzagSize;

			public int radialSectors;

			public int radials;

			public Vector2 radialCentre;

			public bool randomizeAtRunTime;

			public int randomSeed;

			public float randomness;
		}

		public ShatterDetails shatterDetails;

		private Vector3[] originalShatterPieceLocations;

		private Quaternion[] originalShatterPieceRotations;

		private Transform shatterGameObjectTransform;

		private bool error;

		private void Reset()
		{
		}

		public SpriteRenderer[] Shatter()
		{
			return null;
		}

		public Vector2[][] generateShatterShapes()
		{
			return null;
		}

		private static bool transformArrayContainsGameObject(Transform[] transformArray, string gameObjectName)
		{
			return false;
		}

		private void shatter()
		{
		}

		public void Destroy()
		{
		}

		private ushort[] generateMeshTriangles(Vector2[] vertices)
		{
			return null;
		}
	}
}
