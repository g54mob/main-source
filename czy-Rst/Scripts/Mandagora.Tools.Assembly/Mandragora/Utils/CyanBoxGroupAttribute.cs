using UnityEngine;

namespace Mandragora.Utils
{
	public class CyanBoxGroupAttribute : ColorBoxGroupAttribute
	{
		public CyanBoxGroupAttribute(string path, bool showLabel = true)
			: base(path, showLabel)
		{
			Color = Color.cyan;
		}
	}
}
