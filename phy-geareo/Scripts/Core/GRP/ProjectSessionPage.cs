using GRP.Net;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ProjectSessionPage : Page
	{
		[SelectableCrew]
		public StateSelector<bool> startSession;

		[SelectableCrew]
		public StateSelector<bool> joinSession;

		public ProjectSession projectSession;

		public NetGame netGame;

		public override void OnContext()
		{
		}

		[CrewMethod]
		public void OpenMainMenu()
		{
		}

		[CrewMethod]
		public void OpenMultiplayer()
		{
		}

		[CrewMethod]
		public void StartSession()
		{
		}

		[CrewMethod]
		public void JoinSession()
		{
		}
	}
}
