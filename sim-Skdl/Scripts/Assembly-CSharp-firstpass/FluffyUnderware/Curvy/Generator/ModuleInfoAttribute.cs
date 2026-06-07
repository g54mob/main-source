using System;

namespace FluffyUnderware.Curvy.Generator
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ModuleInfoAttribute : Attribute, IComparable
	{
		public readonly string MenuName;

		public string ModuleName;

		public string Description;

		public bool UsesRandom;

		public ModuleInfoAttribute(string name)
		{
		}

		public int CompareTo(object obj)
		{
			return 0;
		}
	}
}
