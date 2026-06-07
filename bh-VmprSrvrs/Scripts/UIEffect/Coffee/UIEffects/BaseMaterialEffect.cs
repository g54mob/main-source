using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[DisallowMultipleComponent]
	public abstract class BaseMaterialEffect : BaseMeshEffect, IParameterTexture, IMaterialModifier
	{
		protected static readonly Hash128 k_InvalidHash;

		protected static readonly List<UIVertex> s_TempVerts;

		private static readonly StringBuilder s_StringBuilder;

		private Hash128 _effectMaterialHash;

		public int parameterIndex { get; set; }

		public virtual ParameterTexture paramTex => null;

		public void SetMaterialDirty()
		{
		}

		public virtual Hash128 GetMaterialHash(Material baseMaterial)
		{
			return default(Hash128);
		}

		public Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		public virtual Material GetModifiedMaterial(Material baseMaterial, Graphic graphic)
		{
			return null;
		}

		public virtual void ModifyMaterial(Material newMaterial, Graphic graphic)
		{
		}

		protected void SetShaderVariants(Material newMaterial, params object[] variants)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
