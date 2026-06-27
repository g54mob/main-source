using System;

namespace Restory.Data.Localization
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public class LocalizationKeyAttribute : Attribute
	{
		public bool Optional;
	}
}
