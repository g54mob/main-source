using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class SettingsPage : Page
	{
		public Settings settings;

		public SettingsPage(Settings settings)
		{
		}

		[CrewMethod]
		public void Close()
		{
		}
	}
}
