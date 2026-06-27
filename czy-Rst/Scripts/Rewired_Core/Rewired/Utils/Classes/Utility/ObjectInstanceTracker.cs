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

			private readonly ObjectInstanceTracker XTqrREXdPlIkDYTysCrufGqJAGvEb;

			private bool LIjIToORbpThtAStPUMSrjtGRDXJ;

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
				XTqrREXdPlIkDYTysCrufGqJAGvEb = P_1;
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
				if (!LIjIToORbpThtAStPUMSrjtGRDXJ)
				{
					if (XTqrREXdPlIkDYTysCrufGqJAGvEb != null)
					{
						XTqrREXdPlIkDYTysCrufGqJAGvEb.Unregister(instanceId);
					}
					LIjIToORbpThtAStPUMSrjtGRDXJ = true;
				}
			}
		}

		private static ObjectInstanceTracker vMgSUjALtnnFVZIlEYCKfmkMRecv;

		private readonly Dictionary<uint, object> ZmbIYQlLTIhWVJtCbqGZUHkFhJlhA = new Dictionary<uint, object>();

		private readonly object PgmdbgCosFsNmStIDFYuhVIBorWZA = new object();

		private uint yGBbjwMHgybWBDBxxGGGxHHnULHDA;

		private int NkQMYhGAuSFECAOGBaZZllciLXKpA;

		private bool zaeHpbqaGhnNphjzxIwUspmjobaf;

		public static ObjectInstanceTracker Default => vMgSUjALtnnFVZIlEYCKfmkMRecv ?? (vMgSUjALtnnFVZIlEYCKfmkMRecv = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			NkQMYhGAuSFECAOGBaZZllciLXKpA++;
			uint num = yGBbjwMHgybWBDBxxGGGxHHnULHDA++;
			ZmbIYQlLTIhWVJtCbqGZUHkFhJlhA.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			NkQMYhGAuSFECAOGBaZZllciLXKpA--;
			if (NkQMYhGAuSFECAOGBaZZllciLXKpA < 0)
			{
				NkQMYhGAuSFECAOGBaZZllciLXKpA = 0;
			}
			lock (PgmdbgCosFsNmStIDFYuhVIBorWZA)
			{
				ZmbIYQlLTIhWVJtCbqGZUHkFhJlhA.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (PgmdbgCosFsNmStIDFYuhVIBorWZA)
			{
				if (!ZmbIYQlLTIhWVJtCbqGZUHkFhJlhA.TryGetValue(instanceId, out var value))
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
			khugvvhPYkkBqZNBmcVjtjSmnXXXA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void khugvvhPYkkBqZNBmcVjtjSmnXXXA(bool P_0)
		{
			if (!zaeHpbqaGhnNphjzxIwUspmjobaf)
			{
				if (this == vMgSUjALtnnFVZIlEYCKfmkMRecv)
				{
					vMgSUjALtnnFVZIlEYCKfmkMRecv = null;
				}
				zaeHpbqaGhnNphjzxIwUspmjobaf = true;
			}
		}

		~ObjectInstanceTracker()
		{
			khugvvhPYkkBqZNBmcVjtjSmnXXXA(false);
		}
	}
}
