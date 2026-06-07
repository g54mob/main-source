using UnityEngine;

namespace MK.Toon
{
	public class IntProperty : Property<int>
	{
		private int _keywordDisabled;

		public IntProperty(Uniform uniform, string keyword, int keywordDisabled = 0)
			: base((Uniform)null, (string[])null)
		{
		}

		public IntProperty(Uniform uniform)
			: base((Uniform)null, (string[])null)
		{
		}

		public override int GetValue(Material material)
		{
			return 0;
		}

		public override void SetValue(Material material, int value)
		{
		}
	}
}
