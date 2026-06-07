using UnityEngine;

namespace MK.Toon
{
	public class BlendProperty : Property<Blend>
	{
		public BlendProperty(Uniform uniform, params string[] keywords)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Blend GetValue(Material material)
		{
			return default(Blend);
		}

		public override void SetValue(Material material, Blend blend)
		{
		}
	}
}
