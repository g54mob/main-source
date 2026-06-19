using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pug.Sprite
{
	[Serializable]
	public class FrameAnimation
	{
		[Serializable]
		public struct FrameData
		{
			public int holdFrames;

			public int eventMask;
		}

		[Serializable]
		public class Transition
		{
			[SerializeField]
			private string m_toGuid;

			[SerializeField]
			private string m_transitionGuid;

			public void GetHashes(SpriteAsset spriteAsset, out int toHash, out int transitionHash)
			{
				if (!Guid.TryParse(m_toGuid, out var result) || !Guid.TryParse(m_transitionGuid, out var result2))
				{
					toHash = 0;
					transitionHash = 0;
				}
				else
				{
					toHash = spriteAsset.GetAnimationHash(result);
					transitionHash = spriteAsset.GetAnimationHash(result2);
				}
			}
		}

		[NonSerialized]
		public string name;

		[NonSerialized]
		public bool hasShortenedName;

		private Guid m_cachedGuid;

		private Guid m_cachedExitAnimationGuid;

		[SerializeField]
		private string m_guid;

		[SerializeField]
		private SpriteData m_spriteData;

		[Min(1f)]
		public int srcFrameCount = 1;

		[Min(0f)]
		public float fps = 10f;

		public bool loop;

		[SerializeField]
		private string m_exitAnimationGuid;

		[SerializeField]
		private List<SpriteData> m_variants;

		[SerializeField]
		private List<Transition> m_transitions = new List<Transition>();

		public List<FrameData> frameData;

		[NonSerialized]
		public bool runtimeDataCreated;

		[NonSerialized]
		public int runtimeFrameCount;

		[NonSerialized]
		public bool runtimeHasEvents;

		[NonSerialized]
		public int[] runtimeFrameRemap;

		[NonSerialized]
		public int[] runtimeFrameEvents;

		[NonSerialized]
		public int runtimeExitAnimationHash;

		private Map<int, int> m_variantLookup;

		public bool hasAnyTexture => m_spriteData.hasAnyTexture;

		public float duration => (float)runtimeFrameCount / fps;

		public int variantCount => m_variants.Count;

		public int transitionCount => m_transitions.Count;

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

		private Guid exitAnimation
		{
			get
			{
				if (m_cachedExitAnimationGuid == Guid.Empty)
				{
					Guid.TryParse(m_exitAnimationGuid, out m_cachedExitAnimationGuid);
				}
				return m_cachedExitAnimationGuid;
			}
		}

		public SpriteData spriteData => m_spriteData;

		public FrameAnimation(Texture2D texture)
		{
			m_spriteData = new SpriteData(texture);
			srcFrameCount = Mathf.Max(1, Mathf.CeilToInt((float)texture.width / (float)texture.height));
			fps = 10f;
			loop = false;
			m_exitAnimationGuid = Guid.Empty.ToString();
			m_variants = new List<SpriteData>();
			frameData = new List<FrameData>();
			m_guid = Guid.NewGuid().ToString();
		}

		public FrameAnimation(FrameAnimation other)
		{
			m_spriteData = new SpriteData(other.spriteData);
			srcFrameCount = other.srcFrameCount;
			fps = other.fps;
			loop = other.loop;
			m_exitAnimationGuid = other.m_exitAnimationGuid;
			m_variants = new List<SpriteData>();
			foreach (SpriteData variant in other.m_variants)
			{
				m_variants.Add(new SpriteData(variant));
			}
			frameData = new List<FrameData>();
			foreach (FrameData frameDatum in other.frameData)
			{
				frameData.Add(frameDatum);
			}
			m_guid = other.m_guid;
		}

		public int GetVariantIndex(int variantHash)
		{
			if (variantHash == 0 || !m_variantLookup.TryGetValue(variantHash, out var value))
			{
				return -1;
			}
			return value;
		}

		public int GetVariantHash(int variantIndex)
		{
			if (variantIndex < 0 || !m_variantLookup.TryGetKey(variantIndex, out var key))
			{
				return 0;
			}
			return key;
		}

		public SpriteData GetVariant(int index)
		{
			return m_variants[index];
		}

		public Transition GetTransition(int index)
		{
			return m_transitions[index];
		}

		public int GetRuntimeFrame(float animationTime)
		{
			return ((int)(animationTime * fps) % runtimeFrameCount + runtimeFrameCount) % runtimeFrameCount;
		}

		public int GetSrcFrame(int runtimeFrame)
		{
			return runtimeFrameRemap[runtimeFrame % runtimeFrameRemap.Length];
		}

		public int GetEventMask(int srcFrame)
		{
			return frameData[srcFrame].eventMask;
		}

		public void UpdateInheritedPivotValues(SpriteAsset spriteAsset)
		{
			if (this.spriteData.inheritPivot)
			{
				if (spriteAsset.staticSpriteData.hasAnyTexture)
				{
					this.spriteData.pivot = spriteAsset.staticSpriteData.pivot;
				}
				else
				{
					int indexOfAnimation = spriteAsset.GetIndexOfAnimation(this);
					for (int i = 0; i < Mathf.Min(indexOfAnimation, spriteAsset.animationCount); i++)
					{
						if (spriteAsset.GetAnimationAt(i).hasAnyTexture)
						{
							this.spriteData.pivot = spriteAsset.GetAnimationAt(i).spriteData.pivot;
							break;
						}
					}
				}
			}
			for (int j = 0; j < m_variants.Count; j++)
			{
				SpriteData spriteData = m_variants[j];
				if (spriteData.inheritPivot)
				{
					spriteData.pivot = this.spriteData.pivot;
				}
			}
		}

		public void CreateRuntimeData(SpriteAsset spriteAsset)
		{
			if (exitAnimation != Guid.Empty)
			{
				int animationHash = spriteAsset.GetAnimationHash(exitAnimation);
				if (animationHash != 0)
				{
					runtimeExitAnimationHash = animationHash;
				}
				else
				{
					Debug.LogError("Invalid exit Guid for animation " + SpriteAsset.PrettifyName(spriteData.GetAssetName(), spriteAsset.name) + " on asset " + spriteAsset.name + ": " + exitAnimation.ToString() + ", hash: " + animationHash);
					runtimeExitAnimationHash = 0;
				}
			}
			else
			{
				runtimeExitAnimationHash = 0;
			}
			UpdateInheritedPivotValues(spriteAsset);
			runtimeFrameCount = 0;
			for (int i = 0; i < frameData.Count; i++)
			{
				runtimeFrameCount += 1 + frameData[i].holdFrames;
			}
			if (runtimeFrameRemap == null || runtimeFrameRemap.Length != runtimeFrameCount)
			{
				runtimeFrameRemap = new int[runtimeFrameCount];
			}
			if (runtimeFrameEvents == null || runtimeFrameEvents.Length != runtimeFrameCount)
			{
				runtimeFrameEvents = new int[runtimeFrameCount];
			}
			int num = 0;
			runtimeHasEvents = false;
			for (int j = 0; j < srcFrameCount; j++)
			{
				int holdFrames = frameData[j].holdFrames;
				int eventMask = frameData[j].eventMask;
				if (eventMask != 0)
				{
					runtimeHasEvents = true;
				}
				for (int k = 0; k < holdFrames + 1; k++)
				{
					if (k == 0)
					{
						runtimeFrameEvents[num] = eventMask;
					}
					else
					{
						runtimeFrameEvents[num] = 0;
					}
					if (runtimeFrameRemap[num] != j)
					{
						runtimeFrameRemap[num] = j;
					}
					num++;
				}
			}
			UpdateVariantLookup();
			runtimeDataCreated = true;
		}

		public void ReleaseSourceAssets()
		{
			m_spriteData?.ReleaseSourceAssets();
			for (int i = 0; i < m_variants.Count; i++)
			{
				m_variants[i]?.ReleaseSourceAssets();
			}
		}

		private void UpdateVariantLookup()
		{
			if (m_variantLookup == null)
			{
				m_variantLookup = new Map<int, int>();
			}
			else
			{
				m_variantLookup.Clear();
			}
			for (int i = 0; i < m_variants.Count; i++)
			{
				int key = SpriteAsset.StringToHash(m_variants[i].GetName(this));
				if (!m_variantLookup.ContainsKey(key))
				{
					m_variantLookup.Add(key, i);
				}
			}
		}
	}
}
