using System;

namespace Sirenix.OdinInspector
{
	public class TypeFilterAttribute : Attribute
	{
		public string FilterGetter;

		public string DropdownTitle;

		public bool DrawValueNormally;

		[Obsolete]
		public string MemberName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TypeFilterAttribute(string filterGetter)
		{
		}
	}
}
