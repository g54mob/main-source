using UnityEngine;

namespace MK.Toon
{
	public class SurfaceProperty : Property<Surface, bool>
	{
		public SurfaceProperty(Uniform uniform, params string[] keywords)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Surface GetValue(Material material)
		{
			return default(Surface);
		}

		public override void SetValue(Material material, Surface surface)
		{
		}

		public override void SetValue(Material material, Surface surface, bool alphaClipping)
		{
		}
	}
}
