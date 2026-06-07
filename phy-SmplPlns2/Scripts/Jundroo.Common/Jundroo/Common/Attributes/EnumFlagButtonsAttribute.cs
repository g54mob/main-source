using UnityEngine;

namespace Jundroo.Common.Attributes
{
	public class EnumFlagButtonsAttribute : PropertyAttribute
	{
		public string DisplayName { get; private set; }

		public EnumFlagButtonsAttribute()
		{
		}

		public EnumFlagButtonsAttribute(string displayName)
		{
			DisplayName = displayName;
		}
	}
}
