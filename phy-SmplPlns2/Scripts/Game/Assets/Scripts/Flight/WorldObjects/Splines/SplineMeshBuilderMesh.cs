using System;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[Serializable]
	public class SplineMeshBuilderMesh
	{
		[SerializeField]
		public Mesh Mesh;

		[SerializeField]
		public Vector3 Offset;

		[SerializeField]
		public Vector3 Rotation;

		[SerializeField]
		public Vector3 Scale = Vector3.one;
	}
}
