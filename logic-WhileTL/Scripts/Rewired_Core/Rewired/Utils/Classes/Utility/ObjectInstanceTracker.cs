using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker oTXHjniRGyTzeVLZslvQVRVDTchS;

			private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

			public Wrapper(T P_0)
				: this(P_0, Default)
			{
			}

			public Wrapper(T P_0, ObjectInstanceTracker P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("tracker");
				}
				instance = P_0;
				oTXHjniRGyTzeVLZslvQVRVDTchS = P_1;
				instanceId = P_1.Register(P_0);
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
				if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
				{
					if (oTXHjniRGyTzeVLZslvQVRVDTchS != null)
					{
						oTXHjniRGyTzeVLZslvQVRVDTchS.Unregister(instanceId);
					}
					JChPmMbeaoLOGQvosPYqDDInSiCs = true;
				}
			}
		}

		private static ObjectInstanceTracker bPGhEsCmNTbAPJBiQCMCWwkESCog;

		private readonly Dictionary<uint, object> dJsDpGEjafNELocKBNFILiVaQTEP = new Dictionary<uint, object>();

		private readonly object cajlaBiSXyFrieRVPNVUXzkvaTxz = new object();

		private uint jXsWptlBSLNgsqonpDkSMEmlBEjGA;

		private int HLXIthjjXyQtOJyYvvoSLBDPjbmi;

		private bool WdCBuJglGkMvUicSCfyREIySjjucb;

		public static ObjectInstanceTracker Default => bPGhEsCmNTbAPJBiQCMCWwkESCog ?? (bPGhEsCmNTbAPJBiQCMCWwkESCog = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			HLXIthjjXyQtOJyYvvoSLBDPjbmi++;
			uint num = jXsWptlBSLNgsqonpDkSMEmlBEjGA++;
			dJsDpGEjafNELocKBNFILiVaQTEP.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			HLXIthjjXyQtOJyYvvoSLBDPjbmi--;
			if (HLXIthjjXyQtOJyYvvoSLBDPjbmi < 0)
			{
				HLXIthjjXyQtOJyYvvoSLBDPjbmi = 0;
			}
			lock (cajlaBiSXyFrieRVPNVUXzkvaTxz)
			{
				dJsDpGEjafNELocKBNFILiVaQTEP.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (cajlaBiSXyFrieRVPNVUXzkvaTxz)
			{
				if (!dJsDpGEjafNELocKBNFILiVaQTEP.TryGetValue(instanceId, out var value))
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
			jZtwTxQjIMBZMEAKpWMmMcJOortz(true);
			GC.SuppressFinalize(this);
		}

		private void jZtwTxQjIMBZMEAKpWMmMcJOortz(bool P_0)
		{
			if (!WdCBuJglGkMvUicSCfyREIySjjucb)
			{
				if (this == bPGhEsCmNTbAPJBiQCMCWwkESCog)
				{
					bPGhEsCmNTbAPJBiQCMCWwkESCog = null;
				}
				WdCBuJglGkMvUicSCfyREIySjjucb = true;
			}
		}

		~ObjectInstanceTracker()
		{
			jZtwTxQjIMBZMEAKpWMmMcJOortz(false);
		}
	}
}
