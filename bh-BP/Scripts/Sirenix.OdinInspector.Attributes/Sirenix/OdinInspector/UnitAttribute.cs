using System;

namespace Sirenix.OdinInspector
{
	public class UnitAttribute : Attribute
	{
		public Units Base;

		public Units Display;

		public string BaseName;

		public string DisplayName;

		public bool DisplayAsString;

		public bool ForceDisplayUnit;

		public UnitAttribute(Units unit)
		{
		}

		public UnitAttribute(string unit)
		{
		}

		public UnitAttribute(Units @base, Units display)
		{
		}

		public UnitAttribute(Units @base, string display)
		{
		}

		public UnitAttribute(string @base, Units display)
		{
		}

		public UnitAttribute(string @base, string display)
		{
		}
	}
}
