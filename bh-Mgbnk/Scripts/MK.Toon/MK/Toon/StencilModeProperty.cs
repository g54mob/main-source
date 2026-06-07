using UnityEngine;

namespace MK.Toon
{
	public class StencilModeProperty : Property<Stencil>
	{
		public StencilModeProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Stencil GetValue(Material material)
		{
			return default(Stencil);
		}

		public override void SetValue(Material material, Stencil stencil)
		{
		}
	}
}
