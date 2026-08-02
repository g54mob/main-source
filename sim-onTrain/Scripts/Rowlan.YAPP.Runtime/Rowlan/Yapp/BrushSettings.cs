using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class BrushSettings
	{
		public enum Distribution
		{
			[InspectorName("Fluent (with Preview)")]
			Fluent = 0,
			[InspectorName("Center")]
			Center = 1,
			[InspectorName("Poisson (Any Collider)")]
			Poisson_Any = 2,
			[InspectorName("Poisson (Terrain Only)")]
			Poisson_Terrain = 3
		}

		public enum SpawnTarget
		{
			PrefabContainer = 0,
			TerrainTrees = 1,
			VegetationStudioPro = 3
		}

		public enum CheckCollider
		{
			None = 0,
			Container = 1,
			All = 2
		}

		public float brushSize = 2f;

		[Range(0f, 360f)]
		public int brushRotation;

		public bool sizeGuide = true;

		public bool normalGuide = true;

		public bool rotationGuide;

		public bool alignToTerrain;

		public bool alignToTerrainSlerpRandom;

		[Range(0f, 1f)]
		public float alignToTerrainSlerpValue = 1f;

		public Distribution distribution;

		public float poissonDiscSize = 1f;

		public float poissonDiscRaycastOffset = 100f;

		public bool poissonDiscsRandomized = true;

		public bool poissonDiscsVisible;

		[Range(0f, 100f)]
		public int poissonDiscDensity = 100;

		public AnimationCurve fallOffCurve = AnimationCurve.Linear(1f, 1f, 1f, 1f);

		public AnimationCurve fallOff2dCurveX = AnimationCurve.Linear(1f, 1f, 1f, 1f);

		public AnimationCurve fallOff2dCurveZ = AnimationCurve.Linear(1f, 1f, 1f, 1f);

		[Range(1f, 50f)]
		public int curveSamplePoints = 10;

		public bool slopeEnabled;

		public float slopeMin;

		public float slopeMinLimit;

		public float slopeMax = 90f;

		public float slopeMaxLimit = 90f;

		public bool allowOverlap;

		public CheckCollider checkCollider;

		public LayerMask layerMask = int.MaxValue;

		public SpawnTarget spawnTarget;

		public Terrain targetTerrain;
	}
}
