using System;

namespace Mandragora.Utils
{
	public class TextureBoxAttribute : Attribute
	{
		public string Label;

		public TextureBoxAttribute(string label = null)
		{
			Label = label;
		}
	}
}
