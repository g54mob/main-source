using System;
using UnityEngine;

namespace MalbersAnimations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
	public sealed class HideAttribute : PropertyAttribute
	{
		public string Variable = "";

		public bool inverse;

		public bool hide = true;

		public int[] EnumValue;

		public bool flag;

		public HideAttribute(string conditionalSourceField)
		{
			Variable = conditionalSourceField;
			inverse = false;
			hide = true;
			flag = false;
		}

		public HideAttribute(string conditionalSourceField, bool inverse)
		{
			Variable = conditionalSourceField;
			this.inverse = inverse;
			hide = true;
			flag = false;
		}

		public HideAttribute(string conditionalSourceField, bool inverse, bool hide)
		{
			Variable = conditionalSourceField;
			this.inverse = inverse;
			this.hide = hide;
			flag = false;
		}

		public HideAttribute(string conditionalSourceField, bool inverse, params int[] EnumValue)
		{
			Variable = conditionalSourceField;
			this.inverse = inverse;
			this.EnumValue = EnumValue;
			hide = true;
			flag = false;
		}

		public HideAttribute(string conditionalSourceField, bool inverse, bool hide, params int[] EnumValue)
		{
			Variable = conditionalSourceField;
			this.inverse = inverse;
			this.EnumValue = EnumValue;
			this.hide = hide;
		}

		public HideAttribute(string conditionalSourceField, params int[] EnumValue)
		{
			Variable = conditionalSourceField;
			inverse = false;
			this.EnumValue = EnumValue;
			hide = true;
			flag = false;
		}

		public HideAttribute(string conditionalSourceField, bool inverse, bool hide, bool flag, params int[] EnumValue)
		{
			Variable = conditionalSourceField;
			this.inverse = inverse;
			this.EnumValue = EnumValue;
			this.hide = hide;
			this.flag = flag;
		}
	}
}
