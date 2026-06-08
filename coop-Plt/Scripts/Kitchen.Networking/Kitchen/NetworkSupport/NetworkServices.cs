using System.Collections.Generic;
using System.Threading.Tasks;
using Platforms;

namespace Kitchen.NetworkSupport
{
	public static class NetworkServices
	{
		public static List<INetworkService> Available = new List<INetworkService>();

		public static bool HasCrossplayEnabled;

		public static HasAvailableNetworkState HasAvailableNetwork
		{
			get
			{
				if (Available == null)
				{
					return HasAvailableNetworkState.NoNetworkServicesAvailable;
				}
				HasAvailableNetworkState result = HasAvailableNetworkState.NoNetworkServicesAvailable;
				foreach (INetworkService item in Available)
				{
					if (item != null)
					{
						if (item.State == PlatformState.Ready)
						{
							return HasAvailableNetworkState.Success;
						}
						if (item.State == PlatformState.Starting || item.State == PlatformState.Ready || item.ShouldConnect)
						{
							result = HasAvailableNetworkState.NoNetworksReady;
						}
					}
				}
				return result;
			}
		}

		public static T Get<T>() where T : INetworkService
		{
			foreach (INetworkService item in Available)
			{
				if (item is T)
				{
					return (T)item;
				}
			}
			return default(T);
		}

		public static bool HasAvailableJoinCodePlatform()
		{
			foreach (INetworkService item in Available)
			{
				if (item.CanAcceptJoinCode)
				{
					return true;
				}
			}
			return false;
		}

		public static List<INetworkTransport> GetAllTransports()
		{
			JoinCode join_code = JoinCodeHelpers.Generate();
			List<INetworkTransport> list = new List<INetworkTransport>();
			foreach (INetworkService item in Available)
			{
				list.Add(item.GetNewTransport(join_code));
			}
			return list;
		}

		public static async Task<INetworkTarget> GetTargetForInvite(NetworkInviteData invite_data)
		{
			foreach (INetworkService item in Available)
			{
				Result<INetworkTarget> result = await item.CanHandleInvite(invite_data);
				if (result.Success)
				{
					return result.Value;
				}
			}
			return null;
		}

		public static INetworkTransport GetTransportForTarget(INetworkTarget target)
		{
			JoinCode join_code = JoinCodeHelpers.Generate();
			foreach (INetworkService item in Available)
			{
				if (item.CanHandleTarget(target))
				{
					return item.GetNewTransport(join_code);
				}
			}
			return null;
		}

		public static async Task<INetworkTarget> CreateTargetFromJoinCode(JoinCode join_code)
		{
			PlatformType remote_platform = join_code.SourcePlatform;
			bool needs_crossplay = PlatformSettings.RemotePlatformConnectionRequiresCrossplay(remote_platform);
			foreach (INetworkService item in Available)
			{
				if (needs_crossplay == item.IsCrossplay)
				{
					Result<INetworkTarget> result = await item.GetTargetFromJoinCode(join_code);
					if (result.Success)
					{
						return result.Value;
					}
				}
			}
			if (!needs_crossplay)
			{
				foreach (INetworkService item2 in Available)
				{
					if (item2.IsCrossplay)
					{
						Result<INetworkTarget> result2 = await item2.GetTargetFromJoinCode(join_code);
						if (result2.Success)
						{
							return result2.Value;
						}
					}
				}
			}
			EventLog.Networking.Report(NetworkEvent.UnableToFindService, $"{join_code} (Platform: {remote_platform}, Crossplay: {needs_crossplay}), checked {Available.Count} services");
			return null;
		}

		public static int GetMaxJoinCodeLength()
		{
			return JoinCodeHelpers.FullLength;
		}
	}
}
