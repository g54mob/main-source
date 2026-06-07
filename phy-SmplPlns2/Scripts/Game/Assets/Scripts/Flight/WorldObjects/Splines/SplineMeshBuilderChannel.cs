using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[Serializable]
	public class SplineMeshBuilderChannel
	{
		[SerializeField]
		public List<SplineMeshBuilderMesh> Meshes;

		[SerializeField]
		public float MeshCountPerKilometer;

		[SerializeField]
		public SplineMesh.Channel.Type Type;

		[SerializeField]
		public bool RandomOrder;

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
	}
}
