using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[CreateAssetMenu(fileName = "New FootstepTextureMaterial", menuName = "Footstepper/Footstep Texture Material")]
	public class FootstepTextureMaterial : ScriptableObject
	{
		[Tooltip("Set up which footstep material will be used for which textures to allow terrains to find the correct effects.")]
		public List<FootstepTextureEffect> textureData = new List<FootstepTextureEffect>();

		public virtual void LoadFromTerrain(Terrain terrain)
		{
			if (!(terrain != null))
			{
				return;
			}
			textureData.Clear();
			for (int i = 0; i < terrain.terrainData.terrainLayers.Length; i++)
			{
				Texture diffuseTexture = terrain.terrainData.terrainLayers[i].diffuseTexture;
				if (diffuseTexture != null)
				{
					textureData.Add(new FootstepTextureEffect(diffuseTexture));
				}
			}
		}

		public virtual FootstepEffect GetEffect(Texture texture, string effectTag)
		{
			for (int i = 0; i < textureData.Count; i++)
			{
				if (textureData[i].Contains(texture))
				{
					return textureData[i].GetEffect(effectTag);
				}
			}
			return null;
		}

		public virtual FootstepEffect GetEffect(Sprite sprite, string effectTag)
		{
			for (int i = 0; i < textureData.Count; i++)
			{
				if (textureData[i].Contains(sprite))
				{
					return textureData[i].GetEffect(effectTag);
				}
			}
			return null;
		}
	}
}
