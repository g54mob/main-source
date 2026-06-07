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

			private readonly ObjectInstanceTracker TkFybwAyTyQKvivIZVbuOoMQyufe;

			private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

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
				TkFybwAyTyQKvivIZVbuOoMQyufe = P_1;
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
				if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
				{
					if (TkFybwAyTyQKvivIZVbuOoMQyufe != null)
					{
						TkFybwAyTyQKvivIZVbuOoMQyufe.Unregister(instanceId);
					}
					wFtxnVROnubhehGUBaPWAtQsiPAD = true;
				}
			}
		}

		private static ObjectInstanceTracker OYQiqncsATCGrosbfEmmNOJBdCuX;

		private readonly Dictionary<uint, object> OagqPDkGBjzEhDwvixCuOwcbVMAD = new Dictionary<uint, object>();

		private readonly object RdtpEIEjuiOYUejCuvEcoZpwZnMc = new object();

		private uint IoawWcNomVFNETiBYYTkXbZcCCzP;

		private int yUPBRkbHziNrmggsaWDwmAeIAxgMc;

		private bool naUIpMhEkuOKcTwgnAGdAJBLqhmlA;

		public static ObjectInstanceTracker Default => OYQiqncsATCGrosbfEmmNOJBdCuX ?? (OYQiqncsATCGrosbfEmmNOJBdCuX = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			yUPBRkbHziNrmggsaWDwmAeIAxgMc++;
			uint num = IoawWcNomVFNETiBYYTkXbZcCCzP++;
			OagqPDkGBjzEhDwvixCuOwcbVMAD.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			yUPBRkbHziNrmggsaWDwmAeIAxgMc--;
			if (yUPBRkbHziNrmggsaWDwmAeIAxgMc < 0)
			{
				yUPBRkbHziNrmggsaWDwmAeIAxgMc = 0;
			}
			lock (RdtpEIEjuiOYUejCuvEcoZpwZnMc)
			{
				OagqPDkGBjzEhDwvixCuOwcbVMAD.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (RdtpEIEjuiOYUejCuvEcoZpwZnMc)
			{
				if (!OagqPDkGBjzEhDwvixCuOwcbVMAD.TryGetValue(instanceId, out var value))
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
			IqfGwssNeOuHmhjiKHsCvtuZOnrU(true);
			GC.SuppressFinalize(this);
		}

		private void IqfGwssNeOuHmhjiKHsCvtuZOnrU(bool P_0)
		{
			if (!naUIpMhEkuOKcTwgnAGdAJBLqhmlA)
			{
				if (this == OYQiqncsATCGrosbfEmmNOJBdCuX)
				{
					OYQiqncsATCGrosbfEmmNOJBdCuX = null;
				}
				naUIpMhEkuOKcTwgnAGdAJBLqhmlA = true;
			}
		}

		~ObjectInstanceTracker()
		{
			IqfGwssNeOuHmhjiKHsCvtuZOnrU(false);
		}
	}
}
