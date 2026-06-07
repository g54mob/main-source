using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Terrain Footstep Source")]
	public class TerrainFootstepSource : FootstepSource
	{
		[Tooltip("The terrain that will be used.")]
		public Terrain terrain;

		[Tooltip("The texture materials define the footstep effects (audio clips and prefabs) that are linked to the terrain's textures.\nThe main texture used at a position is used to find the correct effect.")]
		public List<FootstepTextureMaterial> textureMaterials = new List<FootstepTextureMaterial>();

		protected float[,,] splatmapData;

		protected int textureCount;

		protected virtual void Reset()
		{
			terrain = GetComponent<Terrain>();
		}

		protected virtual void Awake()
		{
			if (terrain != null)
			{
				splatmapData = terrain.terrainData.GetAlphamaps(0, 0, terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight);
				textureCount = splatmapData.Length / (terrain.terrainData.alphamapWidth * terrain.terrainData.alphamapHeight);
			}
		}

		public override FootstepEffect GetFootstepAt(Vector3 position, string effectTag)
		{
			if (terrain != null)
			{
				Texture textureAt = GetTextureAt(position);
				if (textureMaterials.Count > 0 && textureAt != null)
				{
					for (int i = 0; i < textureMaterials.Count; i++)
					{
						FootstepEffect effect = textureMaterials[i].GetEffect(textureAt, effectTag);
						if (effect != null)
						{
							return effect;
						}
					}
				}
				if (FootstepManager.Instance != null)
				{
					return FootstepManager.Instance.GetFootstepFor(textureAt, effectTag);
				}
			}
			return null;
		}

		protected virtual Texture GetTextureAt(Vector3 position)
		{
			int num = (int)((position.x - terrain.transform.position.x) / terrain.terrainData.size.x * (float)terrain.terrainData.alphamapWidth);
			int num2 = (int)((position.z - terrain.transform.position.z) / terrain.terrainData.size.z * (float)terrain.terrainData.alphamapHeight);
			int num3 = 0;
			float num4 = 0f;
			for (int i = 0; i < textureCount; i++)
			{
				if (num4 < splatmapData[num2, num, i])
				{
					num3 = i;
					num4 = splatmapData[num2, num, i];
				}
			}
			return terrain.terrainData.terrainLayers[num3].diffuseTexture;
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/TerrainFootstepSource Icon.png");
		}
	}
}
