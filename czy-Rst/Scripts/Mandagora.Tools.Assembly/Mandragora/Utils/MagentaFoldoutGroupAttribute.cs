using UnityEngine;

namespace Mandragora.Utils
{
	public class MagentaFoldoutGroupAttribute : ColorFoldoutGroupAttribute
	{
		public MagentaFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.magenta;
		}
	}
}
