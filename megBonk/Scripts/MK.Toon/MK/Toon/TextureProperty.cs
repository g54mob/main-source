using UnityEngine;

namespace MK.Toon
{
	public class TextureProperty : Property<Texture>
	{
		public TextureProperty(Uniform uniform, string keyword)
			: base((Uniform)null, (string[])null)
		{
		}

		public TextureProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Texture GetValue(Material material)
		{
			return null;
		}

		public override void SetValue(Material material, Texture texture)
		{
		}
	}
}
