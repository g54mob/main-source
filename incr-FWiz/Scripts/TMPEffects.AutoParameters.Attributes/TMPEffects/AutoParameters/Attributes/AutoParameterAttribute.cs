using System;

namespace TMPEffects.AutoParameters.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class AutoParameterAttribute : Attribute
	{
		private bool required;

		private string name;

		private string[] aliases;

		public AutoParameterAttribute(string name, params string[] aliases)
		{
		}

		public AutoParameterAttribute(bool required, string name, params string[] aliases)
		{
		}
	}
}
