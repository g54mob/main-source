using System.Collections.Generic;
using UnityEngine;

namespace Pug.Sprite
{
	[CreateAssetMenu(fileName = "SpriteAssetManifest", menuName = "2D/Sprite Asset Manifest", order = 2)]
	public class SpriteAssetManifest : ScriptableObject
	{
		public List<SpriteAssetBase> spriteAssets = new List<SpriteAssetBase>();

		public List<Texture2D> gradientMaps = new List<Texture2D>();

		public List<TransformAnimation> transformAnimations = new List<TransformAnimation>();

		private static SpriteAssetManifest m_manifest;

		public static SpriteAssetManifest GetManifest()
		{
			if (m_manifest == null)
			{
				m_manifest = Resources.Load<SpriteAssetManifest>("SpriteAssetManifest");
			}
			return m_manifest;
		}

		public static bool TryGetManifest(out SpriteAssetManifest manifest)
		{
			manifest = GetManifest();
			return manifest != null;
		}
	}
}
