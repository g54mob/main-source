using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker QDTwlcEAFBLbLvvPEgfLfqwtcaB;

			private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

			public Wrapper(T instance)
				: this(instance, Default)
			{
			}

			public Wrapper(T instance, ObjectInstanceTracker tracker)
			{
				if (instance == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (tracker == null)
				{
					throw new ArgumentNullException("tracker");
				}
				this.instance = instance;
				QDTwlcEAFBLbLvvPEgfLfqwtcaB = tracker;
				instanceId = tracker.Register(instance);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			~Wrapper()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
				{
					if (QDTwlcEAFBLbLvvPEgfLfqwtcaB != null)
					{
						QDTwlcEAFBLbLvvPEgfLfqwtcaB.Unregister(instanceId);
					}
					jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
				}
			}
		}

		private static ObjectInstanceTracker NsGEioaOmaBNobdbukRVCkFCuYKO;

		private readonly Dictionary<uint, object> BAqklEmwFGieyQHubUJHhGgOFNc = new Dictionary<uint, object>();

		private readonly object ShlfPKvVVHQTrWnjCOXDiNVPDL = new object();

		private uint DMourjZnQwQoRWMPDfoJwFPVGXV;

		private int xaZfXpDJRPDilddeCRmPttiFxpUS;

		private bool ebMCxFEMIZhPjCYaqdrKDwRcNzWc;

		public static ObjectInstanceTracker Default => NsGEioaOmaBNobdbukRVCkFCuYKO ?? (NsGEioaOmaBNobdbukRVCkFCuYKO = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			xaZfXpDJRPDilddeCRmPttiFxpUS++;
			uint num = DMourjZnQwQoRWMPDfoJwFPVGXV++;
			BAqklEmwFGieyQHubUJHhGgOFNc.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			xaZfXpDJRPDilddeCRmPttiFxpUS--;
			if (xaZfXpDJRPDilddeCRmPttiFxpUS < 0)
			{
				xaZfXpDJRPDilddeCRmPttiFxpUS = 0;
			}
			lock (ShlfPKvVVHQTrWnjCOXDiNVPDL)
			{
				BAqklEmwFGieyQHubUJHhGgOFNc.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (ShlfPKvVVHQTrWnjCOXDiNVPDL)
			{
				if (!BAqklEmwFGieyQHubUJHhGgOFNc.TryGetValue(instanceId, out var value))
				{
					instance = null;
					return false;
				}
				if (value is T)
				{
					instance = (T)value;
					return true;
				}
				instance = null;
				return false;
			}
		}

		public void Dispose()
		{
			TKtGozqoOtxUzimyRPnpCnmqxwZ(true);
			GC.SuppressFinalize(this);
		}

		private void TKtGozqoOtxUzimyRPnpCnmqxwZ(bool P_0)
		{
			if (!ebMCxFEMIZhPjCYaqdrKDwRcNzWc)
			{
				if (this == NsGEioaOmaBNobdbukRVCkFCuYKO)
				{
					NsGEioaOmaBNobdbukRVCkFCuYKO = null;
				}
				ebMCxFEMIZhPjCYaqdrKDwRcNzWc = true;
			}
		}

		~ObjectInstanceTracker()
		{
			TKtGozqoOtxUzimyRPnpCnmqxwZ(false);
		}
	}
}
