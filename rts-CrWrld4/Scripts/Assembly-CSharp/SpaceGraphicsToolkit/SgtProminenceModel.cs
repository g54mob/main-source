using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class SgtProminenceModel : MonoBehaviour
	{
		public class CameraState : SgtCameraState
		{
			public Vector3 LocalPosition;
		}

		public SgtProminence Prominence;

		[NonSerialized]
		private MeshFilter cachedMeshFilter;

		[NonSerialized]
		private bool cachedMeshFilterSet;

		[NonSerialized]
		private MeshRenderer cachedMeshRenderer;

		[NonSerialized]
		private bool cachedMeshRendererSet;

		[NonSerialized]
		private Transform cachedTransform;

		[NonSerialized]
		private bool cachedTransformSet;

		[NonSerialized]
		private List<CameraState> cameraStates;

		public void SetMesh(Mesh mesh)
		{
		}

		public void SetMaterial(Material material)
		{
		}

		public void SetRotation(Quaternion rotation)
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

		public static SgtProminenceModel Create(SgtProminence prominence)
		{
			return null;
		}

		public static void Pool(SgtProminenceModel plane)
		{
		}

		public static void MarkForDestruction(SgtProminenceModel plane)
		{
		}

		protected virtual void Update()
		{
		}
	}
}
