using UnityEngine;

namespace CTS
{
	public class ArrayElementTitleAttribute : PropertyAttribute
	{
		public string VarName;

		public bool UseType;

		public ArrayElementTitleAttribute(string ElementTitleVar)
		{
			VarName = ElementTitleVar;
			UseType = false;
		}

		public ArrayElementTitleAttribute()
		{
			VarName = "";
			UseType = true;
		}
	}
}
