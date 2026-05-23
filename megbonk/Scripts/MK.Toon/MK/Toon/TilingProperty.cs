using UnityEngine;

namespace MK.Toon
{
	public class TilingProperty : Property<Vector2>
	{
		public TilingProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Vector2 GetValue(Material material)
		{
			return default(Vector2);
		}

		public override void SetValue(Material material, Vector2 value)
		{
		}
	}
}
