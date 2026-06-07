using UnityEngine;

namespace MK.Toon
{
	public class RenderPriorityProperty : Property<int, bool>
	{
		public RenderPriorityProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override int GetValue(Material material)
		{
			return 0;
		}

		public override void SetValue(Material material, int priority)
		{
		}

		public override void SetValue(Material material, int priority, bool alphaClipping)
		{
		}
	}
}
