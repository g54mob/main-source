using GRP.Net;
using Rhizomatic;

namespace GRP
{
	public abstract class NetModule
	{
		public NetGame netGame;

		public NetManager netManager;

		public Context context;

		public NetModuleServer server;

		public NetModuleClient client;

		public NetModuleConfig config;

		public bool connected => false;

		public NetServer netServer => null;

		public NetClient netClient => null;

		public abstract NetModuleServer CreateServer();

		public abstract NetModuleClient CreateClient();

		public void _Setup(Context context, NetGame netGame, NetModuleConfig config)
		{
		}

		public void _Destroy()
		{
		}

		protected virtual void Setup()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
	public abstract class NetModule<TConfig, TServer, TClient> : NetModule where TConfig : NetModuleConfig where TServer : NetModuleServer where TClient : NetModuleClient
	{
		public new TConfig config => null;

		public new TServer server => null;

		public new TClient client => null;

		public override NetModuleServer CreateServer()
		{
			return null;
		}

		public override NetModuleClient CreateClient()
		{
			return null;
		}
	}
}
