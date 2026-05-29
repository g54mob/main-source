using UnityEngine;

namespace MK.Toon
{
	public class Vector3Property : Property<Vector3>
	{
		public Vector3Property(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Vector3 GetValue(Material material)
		{
			return default(Vector3);
		}

		public override void SetValue(Material material, Vector3 value)
		{
		}
	}
}
