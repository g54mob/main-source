using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[Serializable]
	public class SplineMeshBuilderConfig
	{
		[SerializeField]
		public SplineMeshBuilderConfigSegment[] Segments;

		[SerializeField]
		public Transform SegmentRootTransform;

		[SerializeField]
		public Material Material;

		[SerializeField]
		public SplineComputer.SampleMode SplineSampleMode = SplineComputer.SampleMode.Uniform;

		[SerializeField]
		public SplineMeshBuilderMeshDataFlags MeshData;

		[SerializeField]
		public bool SaveGeneratedAssets;

		[SerializeField]
		public string GeneratedAssetsRootPath;

		[SerializeField]
		public SplineMesh SplineMesh;

		[SerializeField]
		public Vector2 Offset;

		[SerializeField]
		public Vector3 Rotation;

		[SerializeField]
		public Vector3 Scale = Vector3.one;

		[SerializeField]
		public Vector2 UVOffset = Vector2.zero;

		[SerializeField]
		public Vector2 UVScale = Vector2.one;

		[SerializeField]
		public List<SplineMeshBuilderPass> Passes;
	}
}
