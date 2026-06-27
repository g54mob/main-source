using UnityEngine;

namespace Mandragora.Utils
{
	public class BlueBoxGroupAttribute : ColorBoxGroupAttribute
	{
		public BlueBoxGroupAttribute(string path, bool showLabel = true)
			: base(path, showLabel)
		{
			Color = Color.blue;
		}
	}
}
