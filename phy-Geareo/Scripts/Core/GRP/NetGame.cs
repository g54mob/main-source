using System;
using System.Collections.Generic;
using GRP.Net;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class NetGame
	{
		public State<string> address;

		public State<ushort> port;

		public NetParty party;

		public NetPresence presence;

		public NetProjectSession projectSession;

		public NetSimSession simSession;

		public Context context;

		public NetGameConfig config;

		public NetManager manager;

		public List<NetModule> modules;

		public bool connected => false;

		public NetGame(Context context, NetGameConfig config, NetManager netManager)
		{
		}

		private void OnNetManagerError(string message)
		{
		}

		public void Destroy()
		{
		}

		public T AddModule<T>(Context context, T module, NetModuleConfig config) where T : NetModule
		{
			return null;
		}

		public void RemoveModule(NetModule module)
		{
		}

		public bool WithPlayer(NetConn conn, out NetPlayer player)
		{
			player = null;
			return false;
		}

		public void ServerRegisterHandler<T>(Action<NetPlayer, T> handler) where T : struct, NetMessage
		{
		}

		public void SendText(string message)
		{
		}

		public void SendText(NetConn conn, string message)
		{
		}

		public void SendAlert(string message)
		{
		}

		public void SendAlert(NetConn conn, string message)
		{
		}

		public void StartHost()
		{
		}

		public void StartClient()
		{
		}

		public void Stop()
		{
		}

		private void BuildServer(NetServer server)
		{
		}

		private void BuildClient(NetClient client)
		{
		}

		public static NetGame Of(Context context)
		{
			return null;
		}
	}
}
