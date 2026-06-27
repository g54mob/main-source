using UnityEngine;

namespace Mandragora.Utils
{
	public class CyanFoldoutGroupAttribute : ColorFoldoutGroupAttribute
	{
		public CyanFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.cyan;
		}
	}
}
