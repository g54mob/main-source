using UnityEngine;

namespace MK.Toon
{
	public class Vector4Property : Property<Vector4>
	{
		public Vector4Property(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Vector4 GetValue(Material material)
		{
			return default(Vector4);
		}

		public override void SetValue(Material material, Vector4 value)
		{
		}
	}
}
