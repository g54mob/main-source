using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class MainMenuPage : Page
	{
		[TextCrew]
		public string version;

		[SelectableCrew]
		public bool openCampaign;

		[SelectableCrew]
		public bool openMultiplayer;

		[SelectableCrew]
		public bool openSteamWorkshop;

		public override void OnContext()
		{
		}

		[CrewMethod]
		public void OpenSandbox()
		{
		}

		[CrewMethod]
		public void OpenCampaign()
		{
		}

		[CrewMethod]
		public void OpenMultiplayer()
		{
		}

		[CrewMethod]
		public void OpenSteamWorkshop()
		{
		}

		[CrewMethod]
		public void OpenWorkshop()
		{
		}

		[CrewMethod]
		public void OpenSettings()
		{
		}

		[CrewMethod]
		public void NewProject()
		{
		}

		[CrewMethod]
		public void ReloadProject()
		{
		}

		[CrewMethod]
		public void Quit()
		{
		}
	}
}
