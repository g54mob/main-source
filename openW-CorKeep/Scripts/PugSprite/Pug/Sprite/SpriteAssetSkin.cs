using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pug.Sprite
{
	[TopLevelDataBlockType]
	[IgnoreDataBlockNameWarning]
	public class SpriteAssetSkin : SpriteAssetBase
	{
		[Serializable]
		public class ReplacementData
		{
			private Guid m_cachedGuid;

			[SerializeField]
			private string m_guid;

			[SerializeField]
			[SpriteDataNoFoldout]
			private SpriteData m_spriteData;

			[SerializeField]
			private List<SpriteData> m_variants;

			public Guid guid
			{
				get
				{
					if (m_cachedGuid == Guid.Empty)
					{
						Guid.TryParse(m_guid, out m_cachedGuid);
					}
					return m_cachedGuid;
				}
			}

			public SpriteData spriteData => m_spriteData;

			public int variantCount => m_variants.Count;

			public SpriteData GetVariant(int index)
			{
				return m_variants[index];
			}

			public bool Validate(int variantCount)
			{
				bool result = false;
				if (m_spriteData == null)
				{
					m_spriteData = new SpriteData();
					result = true;
				}
				if (m_variants == null)
				{
					m_variants = new List<SpriteData>();
					result = true;
				}
				while (m_variants.Count < variantCount)
				{
					m_variants.Add(new SpriteData());
					result = true;
				}
				while (m_variants.Count > variantCount)
				{
					m_variants.RemoveAt(m_variants.Count - 1);
					result = true;
				}
				return result;
			}

			public ReplacementData(Guid guid)
			{
				m_guid = guid.ToString();
			}

			public void ReleaseSourceAssets()
			{
				spriteData?.ReleaseSourceAssets();
				for (int i = 0; i < m_variants.Count; i++)
				{
					m_variants[i]?.ReleaseSourceAssets();
				}
			}
		}

		[SerializeField]
		[AllowDirectDataBlockReference]
		private SpriteAsset m_targetAsset;

		[SerializeField]
		private DataBlockRef<SpriteAsset> m_targetAssetRef;

		[SerializeField]
		private ReplacementData m_staticReplacementData;

		[SerializeField]
		private List<ReplacementData> m_replacementData = new List<ReplacementData>();

		private readonly Dictionary<Guid, ReplacementData> m_replacementLookup = new Dictionary<Guid, ReplacementData>();

		public SpriteAsset targetAsset
		{
			get
			{
				if (!m_targetAssetRef.hasAddress)
				{
					return m_targetAsset;
				}
				return m_targetAssetRef.Get();
			}
		}

		public DataBlockAddress targetAssetAddress => m_targetAssetRef.address;

		public ReplacementData staticReplacementData => m_staticReplacementData;

		public int replacementDataCount => m_replacementData.Count;

		public string GetPrettyName()
		{
			if (!(targetAsset != null))
			{
				return base.name;
			}
			return SpriteAsset.PrettifyName(base.name, targetAsset.name);
		}

		public bool TryGetReplacement(Guid guid, out ReplacementData replacementData)
		{
			return m_replacementLookup.TryGetValue(guid, out replacementData);
		}

		public ReplacementData GetReplacementAt(int i)
		{
			return m_replacementData[i];
		}

		public override void CreateRuntimeData()
		{
			UpdateLookup();
			if (!(targetAsset == null))
			{
				UpdateInheritedPivotValues(targetAsset);
				int num = 0;
				animationStartIndex = new int[m_replacementData.Count];
				for (int i = 0; i < m_replacementData.Count; i++)
				{
					ReplacementData replacementData = m_replacementData[i];
					animationStartIndex[i] = num;
					num += 1 + replacementData.variantCount;
				}
				int num2 = 1 + targetAsset.staticVariantCount;
				if (staticAtlasRects == null || staticAtlasRects.Length != num2)
				{
					staticAtlasRects = new Vector4[num2];
				}
				if (animationAtlasRects == null || animationAtlasRects.Length != num)
				{
					animationAtlasRects = new Vector4[num];
				}
			}
		}

		public override void ReleaseSourceAssets()
		{
			m_staticReplacementData?.spriteData?.ReleaseSourceAssets();
			for (int i = 0; i < m_replacementData.Count; i++)
			{
				m_replacementData[i].ReleaseSourceAssets();
			}
		}

		public void UpdateInheritedPivotValues(SpriteAsset spriteAsset)
		{
			if (staticReplacementData.spriteData.inheritPivot)
			{
				staticReplacementData.spriteData.pivot = spriteAsset.staticSpriteData.pivot;
			}
			for (int i = 0; i < staticReplacementData.variantCount; i++)
			{
				SpriteData variant = staticReplacementData.GetVariant(i);
				if (variant.inheritPivot)
				{
					variant.pivot = spriteAsset.GetStaticVariant(i).pivot;
				}
			}
			for (int j = 0; j < m_replacementData.Count; j++)
			{
				ReplacementData replacementData = m_replacementData[j];
				FrameAnimation animationAt = spriteAsset.GetAnimationAt(j);
				if (replacementData.spriteData.inheritPivot)
				{
					replacementData.spriteData.pivot = animationAt.spriteData.pivot;
				}
				for (int k = 0; k < replacementData.variantCount; k++)
				{
					SpriteData variant2 = replacementData.GetVariant(k);
					if (variant2.inheritPivot)
					{
						variant2.pivot = animationAt.GetVariant(k).pivot;
					}
				}
			}
		}

		private void UpdateLookup()
		{
			m_replacementLookup.Clear();
			for (int i = 0; i < m_replacementData.Count; i++)
			{
				ReplacementData replacementAt = GetReplacementAt(i);
				m_replacementLookup.Add(replacementAt.guid, replacementAt);
			}
		}

		public bool HasCorrectName()
		{
			if (!targetAsset)
			{
				return true;
			}
			return base.name.StartsWith(targetAsset.name);
		}
	}
}
