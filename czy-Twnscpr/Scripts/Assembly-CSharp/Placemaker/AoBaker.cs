using System;
using System.Collections.Generic;
using Placemaker.Graphs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Placemaker
{
	public class AoBaker : MonoBehaviour
	{
		public const int shadowMeshMaxVertCount = 65532;

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public List<ShadowMesh> shadowMeshes;

		[SerializeField]
		private Shader shader;

		[SerializeField]
		private Shader spreaderShader;

		[SerializeField]
		private Shader marchingSquaresShader;

		[SerializeField]
		private Material material;

		[SerializeField]
		private Material spreaderMaterial;

		[SerializeField]
		private Material marchingSquaresMaterial;

		[SerializeField]
		private Material stackMaterial;

		[SerializeField]
		public RenderTexture renderTexture0;

		[SerializeField]
		public RenderTexture renderTexture1;

		[SerializeField]
		public RenderTexture coloredMarchingSquaresTex;

		[SerializeField]
		public Texture2D marchingSquaresTex;

		[SerializeField]
		public float2 size;

		[SerializeField]
		public Vector4 texParams;

		[SerializeField]
		public int countX;

		[SerializeField]
		public int countY;

		[SerializeField]
		public int totalCount;

		[SerializeField]
		private Camera cam;

		[SerializeField]
		private Shader stackShader;

		public static readonly Color uncoveredCol;

		public static readonly Color32 uncoveredCol32;

		public static Action<RenderTexture, RenderTexture> onTextures;

		public const int texSize = 2048;

		public const float texelSize = 0.00048828125f;

		public int4 powers;

		public static readonly int tex3dUvSize;

		public static readonly int tex3dWorldBounds;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void OnStart()
		{
		}

		public (ShadowMesh, int) GetShadowMesh(int shadowIndex)
		{
			return default((ShadowMesh, int));
		}

		private void Restore()
		{
		}

		public void ApplyMaterialColors()
		{
		}

		public void BakeAo()
		{
		}

		private void AfterCameraRender(ScriptableRenderContext context, Camera camera)
		{
		}
	}
}
