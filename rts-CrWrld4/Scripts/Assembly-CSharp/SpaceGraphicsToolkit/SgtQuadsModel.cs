using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class SgtQuadsModel : MonoBehaviour
	{
		public class CameraState : SgtCameraState
		{
			public Vector3 LocalPosition;
		}

		public SgtQuads Quads;

		[NonSerialized]
		private MeshFilter meshFilter;

		[NonSerialized]
		private MeshRenderer meshRenderer;

		[NonSerialized]
		private Mesh mesh;

		[NonSerialized]
		private Material material;

		[NonSerialized]
		private List<CameraState> cameraStates;

		public Mesh Mesh => null;

		public void PoolMeshNow()
		{
		}

		public void SetMesh(Mesh newMesh)
		{
		}

		public void SetMaterial(Material newMaterial)
		{
		}

		public static SgtQuadsModel Create(SgtQuads quads)
		{
			return null;
		}

		public static void Pool(SgtQuadsModel model)
		{
		}

		public static void MarkForDestruction(SgtQuadsModel model)
		{
		}

		public void Save(Camera camera)
		{
		}

		public void Restore(Camera camera)
		{
		}

		public void Revert()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
