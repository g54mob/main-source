using GRP.Net;

namespace GRP
{
	public class NetModuleClient
	{
		public NetClient client;

		public NetModule module;

		public NetManager netManager;

		public NetGame netGame;

		public void _Setup(NetModule module)
		{
		}

		public virtual void Setup()
		{
		}

		public void _Build(NetClient client)
		{
		}

		public virtual void Build()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
	public class NetModuleClient<T> : NetModuleClient where T : NetModule
	{
		public new T module => null;
	}
}
