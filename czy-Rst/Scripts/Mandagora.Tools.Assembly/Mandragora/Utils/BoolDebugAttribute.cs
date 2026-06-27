using System;

namespace Mandragora.Utils
{
	public class BoolDebugAttribute : Attribute
	{
		public string Label;

		public BoolDebugAttribute(string label = null)
		{
			Label = label;
		}
	}
}
