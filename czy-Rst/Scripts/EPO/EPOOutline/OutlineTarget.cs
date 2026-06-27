using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	[Serializable]
	public class OutlineTarget
	{
		private static List<Material> TempSharedMaterials = new List<Material>();

		internal bool IsVisible;

		[SerializeField]
		public ColorMask CutoutMask = ColorMask.A;

		[SerializeField]
		internal Renderer renderer;

		[SerializeField]
		public int SubmeshIndex;

		[SerializeField]
		public BoundsMode BoundsMode;

		[SerializeField]
		public Bounds Bounds = new Bounds(Vector3.zero, Vector3.one);

		[SerializeField]
		[Range(0f, 1f)]
		public float CutoutThreshold = 0.5f;

		[SerializeField]
		public CullMode CullMode;

		[SerializeField]
		private string cutoutTextureName;

		[SerializeField]
		private int cutoutTextureIndex;

		private int? cutoutTextureId;

		public Renderer Renderer => renderer;

		internal bool UsesCutout => !string.IsNullOrEmpty(cutoutTextureName);

		internal Material SharedMaterial
		{
			get
			{
				if (renderer == null)
				{
					return null;
				}
				TempSharedMaterials.Clear();
				renderer.GetSharedMaterials(TempSharedMaterials);
				if (TempSharedMaterials.Count != 0)
				{
					return TempSharedMaterials[ShiftedSubmeshIndex % TempSharedMaterials.Count];
				}
				return null;
			}
		}

		internal Texture CutoutTexture
		{
			get
			{
				Material sharedMaterial = SharedMaterial;
				if (!(sharedMaterial == null))
				{
					return sharedMaterial.GetTexture(CutoutTextureId);
				}
				return null;
			}
		}

		internal bool IsValidForCutout
		{
			get
			{
				Material sharedMaterial = SharedMaterial;
				if (UsesCutout && sharedMaterial != null && sharedMaterial.HasProperty(CutoutTextureId))
				{
					return CutoutTexture != null;
				}
				return false;
			}
		}

		public int CutoutTextureIndex
		{
			get
			{
				return cutoutTextureIndex;
			}
			set
			{
				cutoutTextureIndex = value;
				if (cutoutTextureIndex < 0)
				{
					Debug.LogError("Trying to set cutout texture index less than zero");
					cutoutTextureIndex = 0;
				}
			}
		}

		internal int ShiftedSubmeshIndex => SubmeshIndex;

		internal int CutoutTextureId
		{
			get
			{
				if (!cutoutTextureId.HasValue)
				{
					cutoutTextureId = Shader.PropertyToID(cutoutTextureName);
				}
				return cutoutTextureId.Value;
			}
		}

		public string CutoutTextureName
		{
			get
			{
				return cutoutTextureName;
			}
			set
			{
				cutoutTextureName = value;
				cutoutTextureId = null;
			}
		}

		public OutlineTarget()
		{
		}

		public OutlineTarget(Renderer renderer, int submesh = 0)
		{
			SubmeshIndex = submesh;
			this.renderer = renderer;
			CutoutThreshold = 0.5f;
			cutoutTextureId = null;
			cutoutTextureName = string.Empty;
			CullMode = ((!(renderer is SpriteRenderer)) ? CullMode.Back : CullMode.Off);
		}

		public OutlineTarget(Renderer renderer, string cutoutTextureName, float cutoutThreshold = 0.5f)
		{
			SubmeshIndex = 0;
			this.renderer = renderer;
			cutoutTextureId = Shader.PropertyToID(cutoutTextureName);
			CutoutThreshold = cutoutThreshold;
			this.cutoutTextureName = cutoutTextureName;
			CullMode = ((!(renderer is SpriteRenderer)) ? CullMode.Back : CullMode.Off);
		}

		public OutlineTarget(Renderer renderer, int submeshIndex, string cutoutTextureName, float cutoutThreshold = 0.5f)
		{
			SubmeshIndex = submeshIndex;
			this.renderer = renderer;
			cutoutTextureId = Shader.PropertyToID(cutoutTextureName);
			CutoutThreshold = cutoutThreshold;
			this.cutoutTextureName = cutoutTextureName;
			CullMode = ((!(renderer is SpriteRenderer)) ? CullMode.Back : CullMode.Off);
		}
	}
}
