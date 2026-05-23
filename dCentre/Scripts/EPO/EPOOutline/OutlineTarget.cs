using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	[Serializable]
	public class OutlineTarget
	{
		private static List<Material> TempSharedMaterials;

		internal bool IsVisible;

		[SerializeField]
		public ColorMask CutoutMask;

		[SerializeField]
		internal Renderer renderer;

		[SerializeField]
		public int SubmeshIndex;

		[SerializeField]
		public BoundsMode BoundsMode;

		[SerializeField]
		public Bounds Bounds;

		[SerializeField]
		[Range(0f, 1f)]
		public float CutoutThreshold;

		[SerializeField]
		public CullMode CullMode;

		[SerializeField]
		private string cutoutTextureName;

		[SerializeField]
		private int cutoutTextureIndex;

		private int? cutoutTextureId;

		public Renderer Renderer => null;

		internal bool UsesCutout => false;

		internal Material SharedMaterial => null;

		internal Texture CutoutTexture => null;

		internal bool IsValidForCutout => false;

		public int CutoutTextureIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal int ShiftedSubmeshIndex => 0;

		internal int CutoutTextureId => 0;

		public string CutoutTextureName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OutlineTarget()
		{
		}

		public OutlineTarget(Renderer renderer, int submesh = 0)
		{
		}

		public OutlineTarget(Renderer renderer, string cutoutTextureName, float cutoutThreshold = 0.5f)
		{
		}

		public OutlineTarget(Renderer renderer, int submeshIndex, string cutoutTextureName, float cutoutThreshold = 0.5f)
		{
		}
	}
}
