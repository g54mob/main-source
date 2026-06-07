using System;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIBillboard : ScriptableObject
	{
		public enum GPUIBillboardResolution
		{
			x256 = 0x100,
			x512 = 0x200,
			x1024 = 0x400,
			x2048 = 0x800,
			x4096 = 0x1000,
			x8192 = 0x2000
		}

		public enum GPUIBillboardShaderType
		{
			Default = 0,
			SpeedTree = 1,
			TreeCreator = 2,
			SoftOcclusion = 3
		}

		[SerializeField]
		public GameObject prefabObject;

		[SerializeField]
		public GPUIBillboardResolution atlasResolution = GPUIBillboardResolution.x2048;

		[Range(1f, 32f)]
		[SerializeField]
		public int frameCount = 8;

		[Range(0f, 1f)]
		[SerializeField]
		public float brightness = 0.5f;

		[Range(0f, 1f)]
		[SerializeField]
		public float cutoffOverride = 0.5f;

		[Range(0f, 1f)]
		[SerializeField]
		public float normalStrength = 0.5f;

		[SerializeField]
		public GPUIBillboardShaderType billboardShaderType;

		[SerializeField]
		public Vector2 quadSize;

		[SerializeField]
		public float yPivotOffset;

		[SerializeField]
		public Texture2D albedoAtlasTexture;

		[SerializeField]
		public Texture2D normalAtlasTexture;

		[NonSerialized]
		public RenderTexture albedoAtlasRT;

		[NonSerialized]
		public RenderTexture normalAtlasRT;

		[NonSerialized]
		internal Mesh _quadMesh;

		[NonSerialized]
		internal Material _billboardMaterial;

		public override string ToString()
		{
			return prefabObject.name;
		}

		public Texture GetAlbedoTexture()
		{
			if (albedoAtlasTexture != null)
			{
				return albedoAtlasTexture;
			}
			return albedoAtlasRT;
		}

		public Texture GetNormalTexture()
		{
			if (normalAtlasTexture != null)
			{
				return normalAtlasTexture;
			}
			return normalAtlasRT;
		}
	}
}
