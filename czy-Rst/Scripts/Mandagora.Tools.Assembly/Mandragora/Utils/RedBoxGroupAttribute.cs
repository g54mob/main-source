using UnityEngine;

namespace Mandragora.Utils
{
	public class RedBoxGroupAttribute : ColorBoxGroupAttribute
	{
		public RedBoxGroupAttribute(string path, bool showLabel = true)
			: base(path, showLabel)
		{
			Color = Color.red;
		}
	}
}
