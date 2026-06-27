using Sirenix.OdinInspector;

namespace Mandragora.Utils
{
	public class ReadOnlyBoxGroupAttribute : PropertyGroupAttribute
	{
		public ReadOnlyBoxGroupAttribute(string path)
			: base(path)
		{
		}
	}
}
