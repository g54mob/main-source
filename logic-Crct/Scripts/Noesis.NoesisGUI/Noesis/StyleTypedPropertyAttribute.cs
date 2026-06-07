using System;

namespace Noesis
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class StyleTypedPropertyAttribute : Attribute
	{
		private string _property;

		private Type _styleTargetType;

		public string Property
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type StyleTargetType
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
