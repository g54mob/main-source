using System;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Surfaces
{
	[Serializable]
	[CreateAssetMenu(menuName = "HQ FPS Template/Surface Info")]
	public class SurfaceInfo : ScriptableObject
	{
		[Serializable]
		public class EffectPair
		{
			public SoundPlayer AudioEffect;

			public GameObject VisualEffect;
		}

		public Texture[] RegisteredTextures;

		[Space]
		[Group]
		public EffectPair SoftFootstepEffect;

		[Group]
		public EffectPair HardFootstepEffect;

		[Group]
		public EffectPair FallImpactEffect;

		[Space]
		[Group]
		public EffectPair BulletHitEffect;

		[Group]
		public EffectPair SlashEffect;

		[Group]
		public EffectPair StabEffect;

		private HashSet<Texture> m_CachedTextures = new HashSet<Texture>();

		public void CacheTextures()
		{
			m_CachedTextures = new HashSet<Texture>();
			Texture[] registeredTextures = RegisteredTextures;
			foreach (Texture item in registeredTextures)
			{
				m_CachedTextures.Add(item);
			}
		}

		public bool HasTexture(Texture texture)
		{
			return m_CachedTextures.Contains(texture);
		}
	}
}
