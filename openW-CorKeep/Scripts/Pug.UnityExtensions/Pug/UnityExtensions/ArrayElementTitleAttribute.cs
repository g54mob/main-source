using UnityEngine;

namespace Pug.UnityExtensions
{
	public class ArrayElementTitleAttribute : PropertyAttribute
	{
		public string Varname;

		public ArrayElementTitleAttribute(string ElementTitleVar)
		{
			Varname = ElementTitleVar;
		}
	}
}
