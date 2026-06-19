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
				SQXHGfuqwhQCjZUDURhLmtnTxcOg = P_1;
				instanceId = P_1.Register(P_0);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			~Wrapper()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!UyQbQcDzMfWpeIHJxIanBLwCYkuyB)
				{
					if (SQXHGfuqwhQCjZUDURhLmtnTxcOg != null)
					{
						SQXHGfuqwhQCjZUDURhLmtnTxcOg.Unregister(instanceId);
					}
					UyQbQcDzMfWpeIHJxIanBLwCYkuyB = true;
				}
			}
		}

		private static ObjectInstanceTracker yZPSKjbJYtCnEMnXalybLZpIFFFM;

		private readonly Dictionary<uint, object> CTGOZCQuVSsmAAiMPcEgmEpVyeGm = new Dictionary<uint, object>();

		private readonly object YBHtVuTTWRvylZerfmWNdPFFWIng = new object();

		private uint hvyTdadqZexwUAlBJwSztEOvJooN;

		private int CryIrUpHUqgJbBszUnelPbmLqnSA;

		private bool mdXMHlNnhjNNiyiHFYopQrwjLZRl;

		public static ObjectInstanceTracker Default => yZPSKjbJYtCnEMnXalybLZpIFFFM ?? (yZPSKjbJYtCnEMnXalybLZpIFFFM = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			CryIrUpHUqgJbBszUnelPbmLqnSA++;
			uint num = hvyTdadqZexwUAlBJwSztEOvJooN++;
			CTGOZCQuVSsmAAiMPcEgmEpVyeGm.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			CryIrUpHUqgJbBszUnelPbmLqnSA--;
			if (CryIrUpHUqgJbBszUnelPbmLqnSA < 0)
			{
				CryIrUpHUqgJbBszUnelPbmLqnSA = 0;
			}
			lock (YBHtVuTTWRvylZerfmWNdPFFWIng)
			{
				CTGOZCQuVSsmAAiMPcEgmEpVyeGm.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (YBHtVuTTWRvylZerfmWNdPFFWIng)
			{
				if (!CTGOZCQuVSsmAAiMPcEgmEpVyeGm.TryGetValue(instanceId, out var value))
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
			haXzqtcVbedhrKgxQDvOLzHeuwqt(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void haXzqtcVbedhrKgxQDvOLzHeuwqt(bool P_0)
		{
			if (!mdXMHlNnhjNNiyiHFYopQrwjLZRl)
			{
				if (this == yZPSKjbJYtCnEMnXalybLZpIFFFM)
				{
					yZPSKjbJYtCnEMnXalybLZpIFFFM = null;
				}
				mdXMHlNnhjNNiyiHFYopQrwjLZRl = true;
			}
		}

		~ObjectInstanceTracker()
		{
			haXzqtcVbedhrKgxQDvOLzHeuwqt(false);
		}
	}
}
