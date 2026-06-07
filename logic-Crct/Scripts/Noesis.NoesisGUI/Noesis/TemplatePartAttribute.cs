using System;

namespace Noesis
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class TemplatePartAttribute : Attribute
	{
		private string _name;

		private Type _type;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type Type
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
