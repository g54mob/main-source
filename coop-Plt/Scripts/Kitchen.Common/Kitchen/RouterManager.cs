using System.Collections.Generic;
using Controllers;
using Kitchen.NetworkSupport;
using Kitchen.Serializers;
using UnityEngine;

namespace Kitchen
{
	[FilterModes(AllowedModes = GameSetupMode.All)]
	public class RouterManager : GenericSystemBase
	{
		public List<IViewRouter> Routers = new List<IViewRouter>();

		public IViewRouter Entrypoint;

		public IViewRouter LocalInputEntrypoint;

		private IInputSource InputSource;

		private ViewBoundsMaintainer ViewBoundsMaintainer;

		private INetworkTarget CurrentNetworkTarget;

		public T GetRouter<T>() where T : IViewRouter
		{
			foreach (IViewRouter router in Routers)
			{
				if (router is T)
				{
					return (T)router;
				}
			}
			return default(T);
		}

		public void AddInputSource(IInputSource source)
		{
			InputSource = source;
			InputSource.OnInputUpdate += InputSourceOnInputUpdate;
		}

		public void SetViewBoundsMaintainer(ViewBoundsMaintainer vbm)
		{
			ViewBoundsMaintainer = vbm;
		}

		protected override void Initialise()
		{
			base.Initialise();
			Routers = new List<IViewRouter>();
		}

		protected override void OnUpdate()
		{
			if (Routers == null)
			{
				return;
			}
			foreach (IViewRouter router in Routers)
			{
				router.Update();
				if (router is LocalViewRouter localViewRouter)
				{
					localViewRouter.UpdateBounds(base.UIBounds);
				}
				if (router is NetworkRouter networkRouter && !CurrentNetworkTarget.IsHostMode)
				{
					if (!networkRouter.IsLive)
					{
						EventLog.Networking.Report(NetworkEvent.ClientRouterNotLive);
						Debug.LogWarning("Network router no longer live");
						Session.ResetGame();
						break;
					}
					if (!networkRouter.IsConnectedTo(CurrentNetworkTarget))
					{
						EventLog.Networking.Report(NetworkEvent.ClientNotConnectedToHost);
						Session.ResetGame();
						break;
					}
				}
			}
		}

		public void OnLateUpdate()
		{
			foreach (IViewRouter router in Routers)
			{
				if (router is ILateUpdateRouter lateUpdateRouter)
				{
					lateUpdateRouter.LateUpdate();
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (InputSource != null)
			{
				InputSource.OnInputUpdate -= InputSourceOnInputUpdate;
			}
			if (Routers == null)
			{
				return;
			}
			foreach (IViewRouter router in Routers)
			{
				router.Dispose();
			}
		}

		public void SetupRouters(INetworkTarget target, bool start_networked)
		{
			if (Routers != null)
			{
				foreach (IViewRouter router in Routers)
				{
					router.Dispose();
				}
				Routers.Clear();
			}
			else
			{
				Routers = new List<IViewRouter>();
			}
			CurrentNetworkTarget = target;
			if (target.IsHostMode)
			{
				MessagePackSerializer<List<INetworkData>> serializer = new MessagePackSerializer<List<INetworkData>>();
				LocalViewRouter localViewRouter = new LocalViewRouter(base.AssetDirectory, base.EntityViewManager, base.UIContainer, ViewBoundsMaintainer, base.UIBounds);
				PerformCommandRouter performCommandRouter = new PerformCommandRouter(base.World.GetExistingSystem<PlayerManager>(), base.World);
				List<INetworkTransport> allTransports = NetworkServices.GetAllTransports();
				NetworkRouter networkRouter = new NetworkRouter(allTransports, performCommandRouter, serializer);
				localViewRouter.SetBroadcastTarget(performCommandRouter);
				SplitRouter splitRouter = new SplitRouter();
				splitRouter.AddDestination(localViewRouter);
				splitRouter.AddDestination(networkRouter);
				LocalInputRouter localInputRouter = new LocalInputRouter(performCommandRouter);
				Entrypoint = splitRouter;
				LocalInputEntrypoint = localInputRouter;
				foreach (INetworkTransport item2 in allTransports)
				{
					item2.Initialise();
				}
				networkRouter.StartServer(start_networked);
				Routers.Add(localInputRouter);
				Routers.Add(localViewRouter);
				Routers.Add(performCommandRouter);
				Routers.Add(networkRouter);
				Routers.Add(splitRouter);
				return;
			}
			Debug.LogWarning($"Trying to join {target}");
			MessagePackSerializer<List<INetworkData>> serializer2 = new MessagePackSerializer<List<INetworkData>>();
			LocalViewRouter localViewRouter2 = new LocalViewRouter(base.AssetDirectory, base.EntityViewManager, base.UIContainer, ViewBoundsMaintainer, base.UIBounds);
			List<INetworkTransport> obj = new List<INetworkTransport> { NetworkServices.GetTransportForTarget(target) };
			NetworkRouter networkRouter2 = new NetworkRouter(obj, localViewRouter2, serializer2);
			networkRouter2.OnRequestReconnection += delegate
			{
				Debug.LogWarning($"Automatically reconnecting to {target}");
				Session.JoinGame(target);
			};
			localViewRouter2.SetBroadcastTarget(networkRouter2);
			Entrypoint = localViewRouter2;
			LocalInputRouter item = (LocalInputRouter)(LocalInputEntrypoint = new LocalInputRouter(networkRouter2));
			foreach (INetworkTransport item3 in obj)
			{
				item3.Initialise();
			}
			networkRouter2.JoinServer(target);
			Routers.Add(item);
			Routers.Add(localViewRouter2);
			Routers.Add(networkRouter2);
		}

		private void InputSourceOnInputUpdate(object sender, InputUpdateEvent e)
		{
			LocalInputEntrypoint?.BroadcastCommand((UserInputUpdate)e);
		}

		public bool HasActiveNetworkRouter()
		{
			foreach (IViewRouter router in Routers)
			{
				if (router is NetworkRouter networkRouter && networkRouter.HasTransports)
				{
					return true;
				}
			}
			return false;
		}

		public void GetConnectedPlayers(ref List<NetworkTargetDescription> users)
		{
			foreach (IViewRouter router in Routers)
			{
				if (router is NetworkRouter networkRouter)
				{
					networkRouter.GetConnectedPlayers(ref users);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
