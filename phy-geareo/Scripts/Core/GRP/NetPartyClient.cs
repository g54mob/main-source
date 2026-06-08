using GRP.Net;
using Rhizomatic.Reactive;

namespace GRP
{
	public class NetPartyClient : NetModuleClient<NetParty>
	{
		public StateList<NetPlayer> players;

		public StateList<PartyLogMessage> logs;

		public NetPlayer player;

		public State<string> username;

		public override void Setup()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void ClientSendChat(string message)
		{
		}

		public override void Build()
		{
		}
	}
}
