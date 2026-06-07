using UnityEngine;

namespace MK.Toon
{
	public class EnvironmentReflectionProperty : Property<EnvironmentReflection>
	{
		public EnvironmentReflectionProperty(Uniform uniform, params string[] keywords)
			: base((Uniform)null, (string[])null)
		{
		}

		public override EnvironmentReflection GetValue(Material material)
		{
			return default(EnvironmentReflection);
		}

		public override void SetValue(Material material, EnvironmentReflection environmentReflection)
		{
		}
	}
}
