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

			private readonly ObjectInstanceTracker KPYvWlRvLicrLQblmEzOQaCmaybt;

			private bool ImNXkFEHrsFOjYuaFYNqrCVzzfDj;

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
				KPYvWlRvLicrLQblmEzOQaCmaybt = P_1;
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
				if (!ImNXkFEHrsFOjYuaFYNqrCVzzfDj)
				{
					if (KPYvWlRvLicrLQblmEzOQaCmaybt != null)
					{
						KPYvWlRvLicrLQblmEzOQaCmaybt.Unregister(instanceId);
					}
					ImNXkFEHrsFOjYuaFYNqrCVzzfDj = true;
				}
			}
		}

		private static ObjectInstanceTracker iKIsXIOYxuGNLXGwCWGcppOzzQgR;

		private readonly Dictionary<uint, object> GJLeRfgrHLkQLVRDzKYnPWAclpxRA = new Dictionary<uint, object>();

		private readonly object MZAkwLgasOzHqOLRTeGMBwymAFEQ = new object();

		private uint djrqJRWywjIRnVeelSmXRfVAnDbc;

		private int EhwxPWMQwDUtIIgDREHjxaILHhQbA;

		private bool oFECaUcnOcvRftDslEtmeAVKEKuS;

		public static ObjectInstanceTracker Default => iKIsXIOYxuGNLXGwCWGcppOzzQgR ?? (iKIsXIOYxuGNLXGwCWGcppOzzQgR = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			EhwxPWMQwDUtIIgDREHjxaILHhQbA++;
			uint num = djrqJRWywjIRnVeelSmXRfVAnDbc++;
			GJLeRfgrHLkQLVRDzKYnPWAclpxRA.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			EhwxPWMQwDUtIIgDREHjxaILHhQbA--;
			if (EhwxPWMQwDUtIIgDREHjxaILHhQbA < 0)
			{
				EhwxPWMQwDUtIIgDREHjxaILHhQbA = 0;
			}
			lock (MZAkwLgasOzHqOLRTeGMBwymAFEQ)
			{
				GJLeRfgrHLkQLVRDzKYnPWAclpxRA.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (MZAkwLgasOzHqOLRTeGMBwymAFEQ)
			{
				if (!GJLeRfgrHLkQLVRDzKYnPWAclpxRA.TryGetValue(instanceId, out var value))
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
			bGCEcWPcUrpFuLmCyTFJpFePmlFO(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void bGCEcWPcUrpFuLmCyTFJpFePmlFO(bool P_0)
		{
			if (!oFECaUcnOcvRftDslEtmeAVKEKuS)
			{
				if (this == iKIsXIOYxuGNLXGwCWGcppOzzQgR)
				{
					iKIsXIOYxuGNLXGwCWGcppOzzQgR = null;
				}
				oFECaUcnOcvRftDslEtmeAVKEKuS = true;
			}
		}

		~ObjectInstanceTracker()
		{
			bGCEcWPcUrpFuLmCyTFJpFePmlFO(false);
		}
	}
}
