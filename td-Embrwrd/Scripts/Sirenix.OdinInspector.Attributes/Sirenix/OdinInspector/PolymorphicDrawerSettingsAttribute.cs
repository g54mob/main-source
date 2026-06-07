using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class PolymorphicDrawerSettingsAttribute : Attribute
	{
		public bool ReadOnlyIfNotNullReference;

		public string CreateInstanceFunction;

		[Obsolete("Use OnValueChangedAttribute instead.", false)]
		public string OnInstanceAssigned;

		private bool? showBaseType;

		private NonDefaultConstructorPreference? nonDefaultConstructorPreference;

		public bool ShowBaseType
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public NonDefaultConstructorPreference NonDefaultConstructorPreference
		{
			get
			{
				return default(NonDefaultConstructorPreference);
			}
			set
			{
			}
		}

		public bool ShowBaseTypeIsSet => false;

		public bool NonDefaultConstructorPreferenceIsSet => false;
	}
}
