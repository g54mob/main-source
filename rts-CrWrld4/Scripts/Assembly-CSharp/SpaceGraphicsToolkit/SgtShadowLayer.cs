using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtShadowLayer : MonoBehaviour
	{
		public float Radius;

		public List<MeshRenderer> Renderers;

		[NonSerialized]
		private Material material;

		public void ApplyMaterial()
		{
		}

		public void RemoveMaterial()
		{
		}

		public void AddRenderer(MeshRenderer renderer)
		{
		}

		public void RemoveRenderer(MeshRenderer renderer)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void CameraPreRender(Camera camera)
		{
		}
	}
}
