using UnityEngine;

namespace MK.Toon
{
	public class ColorProperty : Property<Color>
	{
		public ColorProperty(Uniform uniform, string keyword)
			: base((Uniform)null, (string[])null)
		{
		}

		public ColorProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Color GetValue(Material material)
		{
			return default(Color);
		}

		public override void SetValue(Material material, Color color)
		{
		}
	}
}
