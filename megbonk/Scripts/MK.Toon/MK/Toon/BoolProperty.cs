using UnityEngine;

namespace MK.Toon
{
	public class BoolProperty : Property<bool>
	{
		public BoolProperty(Uniform uniform, string keyword)
			: base((Uniform)null, (string[])null)
		{
		}

		public BoolProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override bool GetValue(Material material)
		{
			return false;
		}

		public override void SetValue(Material material, bool value)
		{
		}
	}
}
