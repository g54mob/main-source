using System.Collections.Generic;

namespace Loxodon.Framework.Localizations
{
	public class LocalizedString : LocalizedObject<string>
	{
		public LocalizedString()
			: base((IDictionary<string, string>)null, Localization.Current)
		{
		}

		public LocalizedString(IDictionary<string, string> source)
			: base(source, Localization.Current)
		{
		}

		public LocalizedString(IDictionary<string, string> source, Localization localization)
			: base(source, localization)
		{
		}
	}
}
