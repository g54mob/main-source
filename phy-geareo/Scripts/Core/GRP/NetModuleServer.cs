using GRP.Net;

namespace GRP
{
	public class NetModuleServer
	{
		public NetServer server;

		public NetModule module;

		public NetGame netGame;

		public void _Setup(NetModule module)
		{
		}

		public virtual void Setup()
		{
		}

		public void _Build(NetServer server)
		{
		}

		public virtual void Build()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
	public class NetModuleServer<T> : NetModuleServer where T : NetModule
	{
		public new T module => null;
	}
}
