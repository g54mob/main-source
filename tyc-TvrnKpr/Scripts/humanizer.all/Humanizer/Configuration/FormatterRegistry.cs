using Humanizer.Localisation.Formatters;

namespace Humanizer.Configuration
{
	internal class FormatterRegistry : LocaliserRegistry<IFormatter>
	{
		public FormatterRegistry()
			: base((IFormatter)default(_00210))
		{
		}

		private void RegisterDefaultFormatter(string localeCode)
		{
		}

		private void RegisterCzechSlovakPolishFormatter(string localeCode)
		{
		}
	}
}
