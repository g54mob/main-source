using UnityEngine;

namespace MK.Toon
{
	public class AlphaClippingProperty : Property<bool>
	{
		public AlphaClippingProperty(Uniform uniform, string keyword)
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
