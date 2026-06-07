using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Tilemap Footstep Source")]
	public class TilemapFootstepSource : FootstepSource
	{
		[Tooltip("The tilemap that will be used.")]
		public Tilemap[] tilemap;

		[Tooltip("The texture materials define the footstep effects (audio clips and prefabs) that are linked to the tilemap's sprites.\nThe sprite of the tile at the position is used to find the correct effect.")]
		public List<FootstepTextureMaterial> textureMaterials = new List<FootstepTextureMaterial>();

		protected virtual void Reset()
		{
			tilemap = GetComponentsInChildren<Tilemap>();
		}

		public override FootstepEffect GetFootstepAt(Vector3 position, string effectTag)
		{
			if (tilemap != null && tilemap.Length != 0)
			{
				for (int i = 0; i < tilemap.Length; i++)
				{
					Sprite sprite = tilemap[i].GetSprite(tilemap[i].WorldToCell(position));
					if (!(sprite != null))
					{
						continue;
					}
					for (int j = 0; j < textureMaterials.Count; j++)
					{
						FootstepEffect effect = textureMaterials[j].GetEffect(sprite, effectTag);
						if (effect != null)
						{
							return effect;
						}
					}
					if (FootstepManager.Instance != null)
					{
						FootstepEffect footstepFor = FootstepManager.Instance.GetFootstepFor(sprite, effectTag);
						if (footstepFor != null)
						{
							return footstepFor;
						}
					}
				}
			}
			return null;
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/TilemapFootstepSource Icon.png");
		}
	}
}
