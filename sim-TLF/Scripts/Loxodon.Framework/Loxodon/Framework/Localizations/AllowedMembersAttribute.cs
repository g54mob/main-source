using System;

namespace Loxodon.Framework.Localizations
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class AllowedMembersAttribute : Attribute
	{
		private Type type;

		private string[] names;

		public Type Type => type;

		public string[] Names => names;

		public AllowedMembersAttribute(Type type, params string[] names)
		{
			this.type = type;
			this.names = names;
			if (this.names == null)
			{
				this.names = new string[0];
			}
		}
	}
}
