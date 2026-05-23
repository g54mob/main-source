using UnityEngine;

namespace MK.Toon
{
	public class Vector2Property : Property<Vector2>
	{
		public Vector2Property(Uniform uniform)
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
