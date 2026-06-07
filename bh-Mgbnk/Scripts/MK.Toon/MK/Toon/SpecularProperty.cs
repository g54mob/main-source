using UnityEngine;

namespace MK.Toon
{
	public class SpecularProperty : Property<Specular>
	{
		public SpecularProperty(Uniform uniform, params string[] keywords)
			: base((Uniform)null, (string[])null)
		{
		}

		public override Specular GetValue(Material material)
		{
			return default(Specular);
		}

		public override void SetValue(Material material, Specular specular)
		{
		}
	}
}
