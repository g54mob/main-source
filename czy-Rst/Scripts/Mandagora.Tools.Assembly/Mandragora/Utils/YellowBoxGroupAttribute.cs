using UnityEngine;

namespace Mandragora.Utils
{
	public class YellowBoxGroupAttribute : ColorBoxGroupAttribute
	{
		public YellowBoxGroupAttribute(string path, bool showLabel = true)
			: base(path, showLabel)
		{
			Color = Color.yellow;
		}
	}
}
