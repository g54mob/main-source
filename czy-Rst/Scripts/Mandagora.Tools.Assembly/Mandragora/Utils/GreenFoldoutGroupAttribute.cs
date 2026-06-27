using UnityEngine;

namespace Mandragora.Utils
{
	public class GreenFoldoutGroupAttribute : ColorFoldoutGroupAttribute
	{
		public GreenFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.green;
		}
	}
}
