using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomClassObfuscation]
		[CustomObfuscation]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker oTXHjniRGyTzeVLZslvQVRVDTchS;

			private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

			public Wrapper(T P_0)
			{
			}

			public Wrapper(T P_0, ObjectInstanceTracker P_1)
			{
			}

			public void Dispose()
			{
			}

			~Wrapper()
			{
			}

			protected virtual void Dispose(bool disposing)
			{
			}
		}

		private static ObjectInstanceTracker bPGhEsCmNTbAPJBiQCMCWwkESCog;

		private readonly Dictionary<uint, object> dJsDpGEjafNELocKBNFILiVaQTEP;

		private readonly object cajlaBiSXyFrieRVPNVUXzkvaTxz;

		private uint jXsWptlBSLNgsqonpDkSMEmlBEjGA;

		private int HLXIthjjXyQtOJyYvvoSLBDPjbmi;

		private bool WdCBuJglGkMvUicSCfyREIySjjucb;

		public static ObjectInstanceTracker Default => null;

		public uint Register(object instance)
		{
			return 0u;
		}

		public void Unregister(uint instanceId)
		{
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			instance = null;
			return false;
		}

		public void Dispose()
		{
		}

		private void jZtwTxQjIMBZMEAKpWMmMcJOortz(bool P_0)
		{
		}

		~ObjectInstanceTracker()
		{
		}
	}
}
