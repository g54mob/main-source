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

			private readonly ObjectInstanceTracker aAvRORfqvOcbLewHLuoOncRTbgz;

			private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

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
				aAvRORfqvOcbLewHLuoOncRTbgz = tracker;
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
				if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
				{
					if (aAvRORfqvOcbLewHLuoOncRTbgz != null)
					{
						aAvRORfqvOcbLewHLuoOncRTbgz.Unregister(instanceId);
					}
					JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
				}
			}
		}

		private static ObjectInstanceTracker pEcSNMNyRjNgkciRzMRMgPmMISw;

		private readonly Dictionary<uint, object> lnSFvwZOVFBkyRmOeUuQpPHuBRY = new Dictionary<uint, object>();

		private readonly object wNZEYhjgeGerJsKZeEXADbalVOv = new object();

		private uint hEITRealHhlTqTpjGhEksgGjCdt;

		private int VDrqqRiZcOVXbgoGEweIzJFRsjs;

		private bool COkoShjyvQhibNYCjAvNiryCxNq;

		public static ObjectInstanceTracker Default => pEcSNMNyRjNgkciRzMRMgPmMISw ?? (pEcSNMNyRjNgkciRzMRMgPmMISw = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			VDrqqRiZcOVXbgoGEweIzJFRsjs++;
			uint num = hEITRealHhlTqTpjGhEksgGjCdt++;
			lnSFvwZOVFBkyRmOeUuQpPHuBRY.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			VDrqqRiZcOVXbgoGEweIzJFRsjs--;
			if (VDrqqRiZcOVXbgoGEweIzJFRsjs < 0)
			{
				VDrqqRiZcOVXbgoGEweIzJFRsjs = 0;
			}
			lock (wNZEYhjgeGerJsKZeEXADbalVOv)
			{
				lnSFvwZOVFBkyRmOeUuQpPHuBRY.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (wNZEYhjgeGerJsKZeEXADbalVOv)
			{
				if (!lnSFvwZOVFBkyRmOeUuQpPHuBRY.TryGetValue(instanceId, out var value))
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
			hPYtPMXxgzKzMhWWBZyeOBKCxhk(true);
			GC.SuppressFinalize(this);
		}

		private void hPYtPMXxgzKzMhWWBZyeOBKCxhk(bool P_0)
		{
			if (!COkoShjyvQhibNYCjAvNiryCxNq)
			{
				if (this == pEcSNMNyRjNgkciRzMRMgPmMISw)
				{
					pEcSNMNyRjNgkciRzMRMgPmMISw = null;
				}
				COkoShjyvQhibNYCjAvNiryCxNq = true;
			}
		}

		~ObjectInstanceTracker()
		{
			hPYtPMXxgzKzMhWWBZyeOBKCxhk(false);
		}
	}
}
