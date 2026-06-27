using Sirenix.OdinInspector;

namespace Mandragora.Utils
{
	public class ReadOnlyFoldoutAttribute : PropertyGroupAttribute
	{
		public ReadOnlyFoldoutAttribute(string path)
			: base(path)
		{
		}
	}
}
