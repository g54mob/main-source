using System;

namespace Febucci.UI
{
	public struct ModifierInfo : IEquatable<ModifierInfo>
	{
		public string name;

		public float value;

		public ModifierInfo(string name, float value)
		{
			this.name = null;
			this.value = 0f;
		}

		public bool Equals(ModifierInfo other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
