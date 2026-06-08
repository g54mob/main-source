using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class MissionPage : Page
	{
		[TextCrew]
		public string name;

		public MissionPoint missionPoint;

		public MissionPage(MissionPoint missionPoint)
		{
		}

		public override void OnContext()
		{
		}

		[CrewMethod]
		public void Play()
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
