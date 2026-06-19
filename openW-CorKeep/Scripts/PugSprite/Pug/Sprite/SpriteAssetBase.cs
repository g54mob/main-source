using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pug.Sprite
{
	public abstract class SpriteAssetBase : ScriptableDataBlock
	{
		[NonSerialized]
		public Vector4[] staticAtlasRects;

		[NonSerialized]
		public Vector4[] animationAtlasRects;

		[NonSerialized]
		public int[] animationStartIndex;

		[SerializeField]
		[FormerlySerializedAs("m_defaultGradientMap")]
		private Texture2D m_defaultPrimaryGradientMap;

		[SerializeField]
		private Texture2D m_defaultSecondaryGradientMap;

		[SerializeField]
		private Texture2D m_defaultTertiaryGradientMap;

		[SerializeField]
		private DataBlockRef<GradientMapDataBlock> m_defaultPrimaryGradientMapRef;

		[SerializeField]
		private DataBlockRef<GradientMapDataBlock> m_defaultSecondaryGradientMapRef;

		[SerializeField]
		private DataBlockRef<GradientMapDataBlock> m_defaultTertiaryGradientMapRef;

		[SerializeField]
		private bool m_editorHideEmissive;

		public DataBlockRef<GradientMapDataBlock> defaultPrimaryGradientMapRef => m_defaultPrimaryGradientMapRef;

		public DataBlockRef<GradientMapDataBlock> defaultSecondaryGradientMapRef => m_defaultSecondaryGradientMapRef;

		public DataBlockRef<GradientMapDataBlock> defaultTertiaryGradientMapRef => m_defaultTertiaryGradientMapRef;

		public bool editorHideEmissive => m_editorHideEmissive;

		public Vector4 GetAtlasData(int animation, int variant)
		{
			variant++;
			if (animation < 0)
			{
				return staticAtlasRects[variant];
			}
			int num = animationStartIndex[animation];
			return animationAtlasRects[num + variant];
		}

		public abstract void CreateRuntimeData();

		public abstract void ReleaseSourceAssets();
	}
}
