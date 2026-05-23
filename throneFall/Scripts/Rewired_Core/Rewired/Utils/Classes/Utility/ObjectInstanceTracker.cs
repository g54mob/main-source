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

			private readonly ObjectInstanceTracker pClDorEZDpcLpDDfxHwBetSCSgNUA;

			private bool lZiEbRFyxbiaTXLwKcNvSTHJErxV;

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
				pClDorEZDpcLpDDfxHwBetSCSgNUA = P_1;
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
				if (!lZiEbRFyxbiaTXLwKcNvSTHJErxV)
				{
					if (pClDorEZDpcLpDDfxHwBetSCSgNUA != null)
					{
						pClDorEZDpcLpDDfxHwBetSCSgNUA.Unregister(instanceId);
					}
					lZiEbRFyxbiaTXLwKcNvSTHJErxV = true;
				}
			}
		}

		private static ObjectInstanceTracker XrhvUkJfxnahRCoBNHzEOGXHWKdb;

		private readonly Dictionary<uint, object> nucxAtaeDKfxxIEXwKNmzLEABlBHA = new Dictionary<uint, object>();

		private readonly object rKnKIBhgRBwFIRiVMRlPgboSFumm = new object();

		private uint GyAmCHJSiqVrpMtkoOJlyfdianpFA;

		private int ftVxhWPYyEfayLMLSWOsMiMjfpmK;

		private bool XVpcwCHtUroIXKeqkUVzPDXylYUeb;

		public static ObjectInstanceTracker Default => XrhvUkJfxnahRCoBNHzEOGXHWKdb ?? (XrhvUkJfxnahRCoBNHzEOGXHWKdb = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			ftVxhWPYyEfayLMLSWOsMiMjfpmK++;
			uint num = GyAmCHJSiqVrpMtkoOJlyfdianpFA++;
			nucxAtaeDKfxxIEXwKNmzLEABlBHA.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			ftVxhWPYyEfayLMLSWOsMiMjfpmK--;
			if (ftVxhWPYyEfayLMLSWOsMiMjfpmK < 0)
			{
				ftVxhWPYyEfayLMLSWOsMiMjfpmK = 0;
			}
			lock (rKnKIBhgRBwFIRiVMRlPgboSFumm)
			{
				nucxAtaeDKfxxIEXwKNmzLEABlBHA.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (rKnKIBhgRBwFIRiVMRlPgboSFumm)
			{
				if (!nucxAtaeDKfxxIEXwKNmzLEABlBHA.TryGetValue(instanceId, out var value))
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
			CsrEyAOMDeeUSYCNjOeCShcfbkdG(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void CsrEyAOMDeeUSYCNjOeCShcfbkdG(bool P_0)
		{
			if (!XVpcwCHtUroIXKeqkUVzPDXylYUeb)
			{
				if (this == XrhvUkJfxnahRCoBNHzEOGXHWKdb)
				{
					XrhvUkJfxnahRCoBNHzEOGXHWKdb = null;
				}
				XVpcwCHtUroIXKeqkUVzPDXylYUeb = true;
			}
		}

		~ObjectInstanceTracker()
		{
			CsrEyAOMDeeUSYCNjOeCShcfbkdG(false);
		}
	}
}
