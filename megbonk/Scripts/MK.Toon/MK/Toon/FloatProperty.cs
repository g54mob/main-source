using UnityEngine;

namespace MK.Toon
{
	public class FloatProperty : Property<float>
	{
		private float _keywordDisabled;

		public FloatProperty(Uniform uniform, string keyword, float keywordDisabled = 0f)
			: base((Uniform)null, (string[])null)
		{
		}

		public FloatProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override float GetValue(Material material)
		{
			return 0f;
		}

		public override void SetValue(Material material, float value)
		{
		}
	}
}
