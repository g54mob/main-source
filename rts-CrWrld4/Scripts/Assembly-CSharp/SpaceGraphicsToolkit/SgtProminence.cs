using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtProminence : MonoBehaviour
	{
		public Texture MainTex;

		public Color Color;

		public float Brightness;

		public SgtRenderQueue RenderQueue;

		[SgtSeed]
		public int Seed;

		public int PlaneCount;

		public int PlaneDetail;

		public float RadiusMin;

		public float RadiusMax;

		public bool FadeEdge;

		public float FadePower;

		public bool ClipNear;

		public float ClipPower;

		public float CameraOffset;

		public bool Distort;

		public Texture DistortTex;

		public float DistortScaleX;

		public int DistortScaleY;

		public float DistortStrength;

		public Vector2 DistortOffset;

		public Vector2 DistortSpeed;

		public bool Detail;

		public Texture DetailTex;

		public float DetailScaleX;

		public int DetailScaleY;

		public float DetailStrength;

		public Vector2 DetailOffset;

		public Vector2 DetailSpeed;

		[SerializeField]
		private List<SgtProminenceModel> models;

		[NonSerialized]
		private Material material;

		[NonSerialized]
		private Mesh mesh;

		public float Width => 0f;

		public void UpdateMaterial()
		{
		}

		public void UpdateMesh()
		{
		}

		public void UpdateModels()
		{
		}

		public static SgtProminence Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtProminence Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		private void CameraPreCull(Camera camera)
		{
		}

		private void CameraPreRender(Camera camera)
		{
		}
	}
}
