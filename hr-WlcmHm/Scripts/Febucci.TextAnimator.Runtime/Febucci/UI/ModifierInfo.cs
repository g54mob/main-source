using System;

namespace Febucci.UI
{
	public struct ModifierInfo : IEquatable<ModifierInfo>
	{
		public string name;

		public float value;

		public ModifierInfo(string name, float value)
		{
			this.name = name;
			this.value = value;
		}

		public bool Equals(ModifierInfo other)
		{
			if (value.Equals(other.value))
			{
				return name.Equals(other.name);
			}
			return false;
		}

		public override string ToString()
		{
			return $"{name}={value}";
		}
	}
}
