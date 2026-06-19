using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pug.Sprite
{
	[TopLevelDataBlockType]
	[IgnoreDataBlockNameWarning]
	public class SpriteAsset : SpriteAssetBase
	{
		[SerializeField]
		[SpriteDataNoFoldout]
		[SpriteDataNoInheritance]
		[SpriteDataNoEmptyWarning]
		private SpriteData m_staticSpriteData;

		[SerializeField]
		private List<SpriteData> m_staticVariants = new List<SpriteData>();

		[SerializeField]
		private List<FrameAnimation> m_animations = new List<FrameAnimation>();

		[SerializeField]
		private List<string> m_events = new List<string>();

		[SerializeField]
		private List<string> m_positionalData = new List<string>();

		private Dictionary<int, FrameAnimation> m_animationLookup;

		private Dictionary<int, int> m_animationIndexLookup;

		private Dictionary<Guid, int> m_animationHashLookup;

		private Dictionary<int, int> m_eventLookup;

		private Map<int, int> m_staticVariantLookup;

		private Dictionary<(int, int), int> m_transitionLookup;

		private Dictionary<int, int> m_positionalDataLookup;

		public SpriteData staticSpriteData => m_staticSpriteData;

		public bool hasAnyStaticTexture => m_staticSpriteData.hasAnyTexture;

		public bool hasAnimations => m_animations.Count > 0;

		public int staticVariantCount => m_staticVariants.Count;

		public int animationCount => m_animations.Count;

		public int eventCount => m_events.Count;

		public int positionalDataCount => m_positionalData.Count;

		public FrameAnimation GetAnimationAt(int index)
		{
			return m_animations[index];
		}

		public int GetIndexOfAnimation(FrameAnimation animation)
		{
			return m_animations.IndexOf(animation);
		}

		public string GetPositionalDataName(int index)
		{
			return m_positionalData[index];
		}

		public static int StringToHash(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				return Animator.StringToHash(name);
			}
			return 0;
		}

		public string GetEventAt(int index)
		{
			return m_events[index];
		}

		public int GetEventHash(int index)
		{
			return m_eventLookup[index];
		}

		public int GetTransitionHash(int from, int to)
		{
			if (!m_transitionLookup.TryGetValue((from, to), out var value))
			{
				return 0;
			}
			return value;
		}

		public bool HasStaticVariant(int variantHash)
		{
			if (variantHash != 0)
			{
				return m_staticVariantLookup.ContainsKey(variantHash);
			}
			return false;
		}

		public int GetStaticVariantIndex(int variantHash)
		{
			if (variantHash == 0 || !m_staticVariantLookup.TryGetValue(variantHash, out var value))
			{
				return -1;
			}
			return value;
		}

		public int GetStaticVariantHash(int variantIndex)
		{
			if (variantIndex < 0 || !m_staticVariantLookup.TryGetKey(variantIndex, out var key))
			{
				return 0;
			}
			return key;
		}

		public SpriteData GetStaticVariant(int index)
		{
			if (index < 0 || index >= m_staticVariants.Count)
			{
				Debug.LogError($"{index} vs {m_staticVariants.Count} for {this}");
			}
			return m_staticVariants[index];
		}

		public static string PrettifyName(string name, string assetName)
		{
			if (name.Contains(assetName))
			{
				name = name.Replace(assetName, null);
			}
			if (name.StartsWith('_') && name.Length > 1)
			{
				name = name.Substring(1, name.Length - 1);
			}
			return name;
		}

		public static Texture2D GetSrcTexture(Texture2D texture, Texture2D emissiveTexture, Texture2D normalTexture)
		{
			if (texture != null)
			{
				return texture;
			}
			if (emissiveTexture != null)
			{
				return emissiveTexture;
			}
			return normalTexture;
		}

		public override void CreateRuntimeData()
		{
			UpdateAnimationLookup();
			UpdateEventLookup();
			UpdateStaticVariantLookup();
			UpdateTransitionLookup();
			UpdatePositionalDataLookup();
		}

		public override void ReleaseSourceAssets()
		{
			m_staticSpriteData?.ReleaseSourceAssets();
			for (int i = 0; i < m_staticVariants.Count; i++)
			{
				m_staticVariants[i]?.ReleaseSourceAssets();
			}
			for (int j = 0; j < m_animations.Count; j++)
			{
				m_animations[j]?.ReleaseSourceAssets();
			}
		}

		private void UpdateAnimationLookup()
		{
			if (m_animations == null)
			{
				return;
			}
			if (m_animationLookup == null)
			{
				m_animationLookup = new Dictionary<int, FrameAnimation>();
			}
			else
			{
				m_animationLookup.Clear();
			}
			if (m_animationIndexLookup == null)
			{
				m_animationIndexLookup = new Dictionary<int, int>();
			}
			else
			{
				m_animationIndexLookup.Clear();
			}
			if (m_animationHashLookup == null)
			{
				m_animationHashLookup = new Dictionary<Guid, int>();
			}
			else
			{
				m_animationHashLookup.Clear();
			}
			int num = 0;
			animationStartIndex = new int[m_animations.Count];
			string assetName = base.name;
			for (int i = 0; i < m_animations.Count; i++)
			{
				FrameAnimation frameAnimation = m_animations[i];
				frameAnimation.name = PrettifyName(frameAnimation.spriteData.GetAssetName(), assetName);
				frameAnimation.hasShortenedName = frameAnimation.name != frameAnimation.spriteData.GetAssetName() && !frameAnimation.name.Contains('_');
				int num2 = StringToHash(frameAnimation.name);
				if (!m_animationLookup.ContainsKey(num2))
				{
					m_animationLookup.Add(num2, frameAnimation);
					m_animationIndexLookup.Add(num2, i);
					m_animationHashLookup.Add(frameAnimation.guid, num2);
				}
				animationStartIndex[i] = num;
				num += 1 + frameAnimation.variantCount;
			}
			for (int j = 0; j < m_animations.Count; j++)
			{
				m_animations[j].CreateRuntimeData(this);
			}
			int num3 = 1 + staticVariantCount;
			if (staticAtlasRects == null || staticAtlasRects.Length != num3)
			{
				staticAtlasRects = new Vector4[num3];
			}
			if (animationAtlasRects == null || animationAtlasRects.Length != num)
			{
				animationAtlasRects = new Vector4[num];
			}
		}

		private void UpdateEventLookup()
		{
			if (m_events == null)
			{
				return;
			}
			if (m_eventLookup == null)
			{
				m_eventLookup = new Dictionary<int, int>();
			}
			else
			{
				m_eventLookup.Clear();
			}
			for (int i = 0; i < m_events.Count; i++)
			{
				int value = StringToHash(m_events[i]);
				if (!m_eventLookup.ContainsKey(i))
				{
					m_eventLookup.Add(i, value);
				}
			}
		}

		private void UpdateStaticVariantLookup()
		{
			if (m_staticVariants == null)
			{
				return;
			}
			if (m_staticVariantLookup == null)
			{
				m_staticVariantLookup = new Map<int, int>();
			}
			else
			{
				m_staticVariantLookup.Clear();
			}
			for (int i = 0; i < m_staticVariants.Count; i++)
			{
				int key = StringToHash(m_staticVariants[i].GetName(this));
				if (!m_staticVariantLookup.ContainsKey(key))
				{
					m_staticVariantLookup.Add(key, i);
				}
			}
		}

		private void UpdateTransitionLookup()
		{
			if (m_animations == null)
			{
				return;
			}
			if (m_transitionLookup == null)
			{
				m_transitionLookup = new Dictionary<(int, int), int>();
			}
			else
			{
				m_transitionLookup.Clear();
			}
			for (int i = 0; i < m_animations.Count; i++)
			{
				FrameAnimation frameAnimation = m_animations[i];
				int animationHash = GetAnimationHash(i);
				for (int j = 0; j < frameAnimation.transitionCount; j++)
				{
					frameAnimation.GetTransition(j).GetHashes(this, out var toHash, out var transitionHash);
					if (animationHash != 0 && toHash != 0 && transitionHash != 0 && !m_transitionLookup.ContainsKey((animationHash, toHash)))
					{
						m_transitionLookup.Add((animationHash, toHash), transitionHash);
					}
				}
			}
		}

		private void UpdatePositionalDataLookup()
		{
			if (m_positionalDataLookup == null)
			{
				m_positionalDataLookup = new Dictionary<int, int>();
			}
			else
			{
				m_positionalDataLookup.Clear();
			}
			for (int i = 0; i < m_positionalData.Count; i++)
			{
				int key = StringToHash(m_positionalData[i]);
				if (!m_positionalDataLookup.ContainsKey(key))
				{
					m_positionalDataLookup.Add(key, i);
				}
			}
		}

		public static string GetAssetName(Texture2D texture, Texture2D emissiveTexture, Texture2D normalTexture)
		{
			string text = "empty";
			if (texture != null)
			{
				text = texture.name.Replace(' ', '_');
			}
			else if (emissiveTexture != null)
			{
				text = emissiveTexture.name.Replace(' ', '_');
				string text2 = text.ToLower();
				int num = text2.LastIndexOf("_emissive");
				if (num < 0)
				{
					num = text2.LastIndexOf("emissive");
				}
				if (num < 0)
				{
					num = text2.LastIndexOf("_emission");
				}
				if (num < 0)
				{
					num = text2.LastIndexOf("emission");
				}
				if (num > -1)
				{
					text = text.Substring(0, num);
				}
			}
			else if (normalTexture != null)
			{
				text = normalTexture.name.Replace(' ', '_');
				string text3 = text.ToLower();
				int num2 = text3.LastIndexOf("_normal");
				if (num2 < 0)
				{
					num2 = text3.LastIndexOf("normal");
				}
				if (num2 < 0)
				{
					num2 = text3.LastIndexOf("_normals");
				}
				if (num2 < 0)
				{
					num2 = text3.LastIndexOf("normals");
				}
				if (num2 > -1)
				{
					text = text.Substring(0, num2);
				}
			}
			return text;
		}

		public FrameAnimation GetAnimation(int hash)
		{
			if (!m_animationLookup.TryGetValue(hash, out var value))
			{
				Debug.LogError("SpriteAsset has no animation for hash " + hash);
			}
			return value;
		}

		public int GetPositionalDataIndex(int hash)
		{
			if (!m_positionalDataLookup.TryGetValue(hash, out var value))
			{
				Debug.LogError("SpriteAsset has no positional data for hash " + hash);
			}
			return value;
		}

		public bool HasAnimation(int hash)
		{
			return m_animationLookup.ContainsKey(hash);
		}

		public bool TryGetAnimation(int hash, out FrameAnimation animation)
		{
			return m_animationLookup.TryGetValue(hash, out animation);
		}

		public int GetAnimationIndex(int hash)
		{
			if (m_animationIndexLookup.TryGetValue(hash, out var value))
			{
				return value;
			}
			return -1;
		}

		public int GetAnimationHash(int index)
		{
			if (index <= -1 || index >= m_animations.Count)
			{
				return -1;
			}
			return StringToHash(m_animations[index].name);
		}

		public int GetAnimationHash(Guid guid)
		{
			if (m_animationHashLookup.TryGetValue(guid, out var value))
			{
				return value;
			}
			return 0;
		}

		public bool GetHasAnyEmissiveTextures()
		{
			if ((bool)m_staticSpriteData.emissiveTexture)
			{
				return true;
			}
			foreach (SpriteData staticVariant in m_staticVariants)
			{
				if ((bool)staticVariant.emissiveTexture)
				{
					return true;
				}
			}
			foreach (FrameAnimation animation in m_animations)
			{
				if ((bool)animation.spriteData.emissiveTexture)
				{
					return true;
				}
				for (int i = 0; i < animation.variantCount; i++)
				{
					if ((bool)animation.GetVariant(i).emissiveTexture)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
