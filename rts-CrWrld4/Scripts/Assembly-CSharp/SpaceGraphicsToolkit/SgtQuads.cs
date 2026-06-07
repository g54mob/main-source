using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtQuads : MonoBehaviour
	{
		public enum BlendModeType
		{
			Default = 0,
			Additive = 1,
			AlphaTest = 2,
			AdditiveSmooth = 3
		}

		public enum LayoutType
		{
			Grid = 0,
			Custom = 1
		}

		[SerializeField]
		private Color color;

		[SerializeField]
		private float brightness;

		public Texture MainTex;

		public LayoutType Layout;

		public int LayoutColumns;

		public int LayoutRows;

		public List<Rect> LayoutRects;

		public BlendModeType BlendMode;

		public SgtRenderQueue RenderQueue;

		[SerializeField]
		protected List<SgtQuadsModel> models;

		[NonSerialized]
		protected Material material;

		[SerializeField]
		private bool startCalled;

		[NonSerialized]
		private bool updateMaterialCalled;

		[NonSerialized]
		private bool updateMeshesAndModelsCalled;

		protected static List<Vector4> tempCoords;

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float Brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected abstract string ShaderName { get; }

		public void SetColor(Color value)
		{
		}

		public void SetBrightness(float value)
		{
		}

		public void UpdateMainTex()
		{
		}

		public void UpdateMaterial()
		{
		}

		public void UpdateMeshesAndModels()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected abstract int BeginQuads();

		protected abstract void EndQuads();

		protected virtual void BuildMaterial()
		{
		}

		protected virtual void StartOnce()
		{
		}

		protected void BuildAdditive()
		{
		}

		protected void BuildAlphaTest()
		{
		}

		protected void BuildAdditiveSmooth()
		{
		}

		protected void BuildRects()
		{
		}

		protected abstract void BuildMesh(Mesh mesh, int starIndex, int starCount);

		protected static void ExpandBounds(ref bool minMaxSet, ref Vector3 min, ref Vector3 max, Vector3 position, float radius)
		{
		}

		private void ConvertRectsToCoords()
		{
		}

		private SgtQuadsModel GetOrNewModel(int index)
		{
			return null;
		}

		private Mesh GetOrNewMesh(SgtQuadsModel model)
		{
			return null;
		}

		private void CheckUpdateCalls()
		{
		}
	}
}
