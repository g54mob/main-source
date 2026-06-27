using UnityEngine;

namespace Mandragora.Utils
{
	public class BlueFoldoutGroupAttribute : ColorFoldoutGroupAttribute
	{
		public BlueFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.blue;
		}
	}
}
