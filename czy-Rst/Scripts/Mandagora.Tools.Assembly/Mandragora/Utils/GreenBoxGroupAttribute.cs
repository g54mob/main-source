using UnityEngine;

namespace Mandragora.Utils
{
	public class GreenBoxGroupAttribute : ColorBoxGroupAttribute
	{
		public GreenBoxGroupAttribute(string path, bool showLabel = true)
			: base(path, showLabel)
		{
			Color = Color.green;
		}
	}
}
