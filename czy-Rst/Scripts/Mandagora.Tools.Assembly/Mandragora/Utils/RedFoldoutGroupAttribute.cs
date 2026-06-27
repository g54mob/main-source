using UnityEngine;

namespace Mandragora.Utils
{
	public class RedFoldoutGroupAttribute : ColorFoldoutGroupAttribute
	{
		public RedFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.red;
		}
	}
}
