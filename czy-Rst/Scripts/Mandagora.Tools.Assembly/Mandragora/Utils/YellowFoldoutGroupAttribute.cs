using UnityEngine;

namespace Mandragora.Utils
{
	public class YellowFoldoutGroupAttribute : ColorFoldoutGroupAttribute
	{
		public YellowFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.yellow;
		}
	}
}
