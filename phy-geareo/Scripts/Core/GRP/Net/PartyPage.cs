using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Net
{
	public class PartyPage : Page
	{
		[InputFieldCrew]
		public State<string> username;

		[InputFieldCrew]
		public State<string> address;

		[InputFieldCrew]
		public State<string> port;

		[InputFieldCrew]
		public State<string> chatMessage;

		[GameObjectCrew]
		public StateSelector<bool> connecting;

		[GameObjectCrew]
		public StateSelector<bool> connected;

		[GameObjectCrew]
		public StateSelector<bool> notConnected;

		[GameObjectCrew]
		public StateSelector<bool> isHost;

		[GameObjectCrew]
		public StateSelector<bool> isClient;

		[ListLoaderCrew]
		public StateSelector<List<NetPlayerItemViewable>> players;

		[TextCrew]
		public StateSelector<string> logs;

		private NetGame netGame;

		public override void OnContext()
		{
		}

		public bool Init()
		{
			return false;
		}

		[CrewMethod]
		public void StartHost()
		{
		}

		[CrewMethod]
		public void StartClient()
		{
		}

		[CrewMethod]
		public void Stop()
		{
		}

		[CrewMethod]
		public void SendMessage()
		{
		}

		[CrewMethod]
		public void OpenProjectSession()
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
