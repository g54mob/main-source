using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[Serializable]
	public class FootstepTextureEffect
	{
		[Tooltip("Select the textures that will use the defined footstep material.")]
		public List<Texture> texture = new List<Texture>();

		[Tooltip("Select the sprites that will use the defined footstep material.")]
		public List<Sprite> sprite = new List<Sprite>();

		[Space(10f)]
		[Tooltip("The footstep material defines the footstep effects (audio clips and prefabs) for these textures.")]
		public FootstepMaterial material;

		public FootstepTextureEffect()
		{
		}

		public FootstepTextureEffect(Texture texture)
		{
			this.texture.Add(texture);
		}

		public virtual bool Contains(Texture texture)
		{
			return this.texture.Contains(texture);
		}

		public virtual bool Contains(Sprite sprite)
		{
			return this.sprite.Contains(sprite);
		}

		public virtual FootstepEffect GetEffect(string effectTag)
		{
			if (material != null)
			{
				return material.GetEffect(effectTag);
			}
			return null;
		}
	}
}
