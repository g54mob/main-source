using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker SQXHGfuqwhQCjZUDURhLmtnTxcOg;

			private bool UyQbQcDzMfWpeIHJxIanBLwCYkuyB;

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

		private static ObjectInstanceTracker yZPSKjbJYtCnEMnXalybLZpIFFFM;

		private readonly Dictionary<uint, object> CTGOZCQuVSsmAAiMPcEgmEpVyeGm;

		private readonly object YBHtVuTTWRvylZerfmWNdPFFWIng;

		private uint hvyTdadqZexwUAlBJwSztEOvJooN;

		private int CryIrUpHUqgJbBszUnelPbmLqnSA;

		private bool mdXMHlNnhjNNiyiHFYopQrwjLZRl;

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

		private void haXzqtcVbedhrKgxQDvOLzHeuwqt(bool P_0)
		{
		}

		~ObjectInstanceTracker()
		{
		}
	}
}
