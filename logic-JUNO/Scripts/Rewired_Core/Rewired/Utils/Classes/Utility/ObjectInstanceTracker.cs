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

			private readonly ObjectInstanceTracker GjRHRzGBEOLJAYDyQbSBKmcnuYRnA;

			private bool QSIdYBVTkUFymGbpnJxdZuxgfJdr;

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
				GjRHRzGBEOLJAYDyQbSBKmcnuYRnA = P_1;
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
				if (!QSIdYBVTkUFymGbpnJxdZuxgfJdr)
				{
					if (GjRHRzGBEOLJAYDyQbSBKmcnuYRnA != null)
					{
						GjRHRzGBEOLJAYDyQbSBKmcnuYRnA.Unregister(instanceId);
					}
					QSIdYBVTkUFymGbpnJxdZuxgfJdr = true;
				}
			}
		}

		private static ObjectInstanceTracker uhJECQJswGEaIFXjmGjbmJkydoMyA;

		private readonly Dictionary<uint, object> KnKNGrmUKnmvCJdYJsrscjcttXPN = new Dictionary<uint, object>();

		private readonly object IwDydNzDxcYqnCrQhOnZzYOrTheY = new object();

		private uint hPqddLLYnVtwWJPvHlydrvFTTBhm;

		private int QAhKIWXezbmpDYYIhQmkZxcGTSkK;

		private bool cTTFSzJNIIIexxzTGtlKWlJlkKnA;

		public static ObjectInstanceTracker Default => uhJECQJswGEaIFXjmGjbmJkydoMyA ?? (uhJECQJswGEaIFXjmGjbmJkydoMyA = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			QAhKIWXezbmpDYYIhQmkZxcGTSkK++;
			uint num = hPqddLLYnVtwWJPvHlydrvFTTBhm++;
			KnKNGrmUKnmvCJdYJsrscjcttXPN.Add(num, instance);
			return num;
		}

		public void Unregister(uint instanceId)
		{
			QAhKIWXezbmpDYYIhQmkZxcGTSkK--;
			if (QAhKIWXezbmpDYYIhQmkZxcGTSkK < 0)
			{
				QAhKIWXezbmpDYYIhQmkZxcGTSkK = 0;
			}
			lock (IwDydNzDxcYqnCrQhOnZzYOrTheY)
			{
				KnKNGrmUKnmvCJdYJsrscjcttXPN.Remove(instanceId);
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			lock (IwDydNzDxcYqnCrQhOnZzYOrTheY)
			{
				if (!KnKNGrmUKnmvCJdYJsrscjcttXPN.TryGetValue(instanceId, out var value))
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
			fnRTpYSdRROkjLNNSAmMGXWQDHpgb(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		private void fnRTpYSdRROkjLNNSAmMGXWQDHpgb(bool P_0)
		{
			if (!cTTFSzJNIIIexxzTGtlKWlJlkKnA)
			{
				if (this == uhJECQJswGEaIFXjmGjbmJkydoMyA)
				{
					uhJECQJswGEaIFXjmGjbmJkydoMyA = null;
				}
				cTTFSzJNIIIexxzTGtlKWlJlkKnA = true;
			}
		}

		~ObjectInstanceTracker()
		{
			fnRTpYSdRROkjLNNSAmMGXWQDHpgb(false);
		}
	}
}
