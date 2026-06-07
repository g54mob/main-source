using UnityEngine;

namespace MK.Toon
{
	public class OffsetProperty : Property<Vector2>
	{
		public OffsetProperty(Uniform uniform)
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
