using UnityEngine;

namespace Mandragora.Utils
{
	public class MagentaBoxGroupAttribute : ColorBoxGroupAttribute
	{
		public MagentaBoxGroupAttribute(string path, bool showLabel = true)
			: base(path, showLabel)
		{
			Color = Color.magenta;
		}
	}
}
