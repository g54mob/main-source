using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> cwiASPIZvBrGUATZhxnxueTBTuZQ;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		internal abstract void Clear();

		public abstract object Clone();
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class YjTDPOjpGbzdajAYXOhnFGsTSSQ
		{
			public readonly T rfSbltlVUsOPLDEjCGyLCVnkdObe;

			public readonly object BaTtacyeRYNBocHXDZsGDxVdgZg;

			public readonly object HSEkUKCmnxfGGguHalRZJGBDrOb;

			public readonly bool OdWomEsdOkaVerXEHoPZBsOLRWO;

			public YjTDPOjpGbzdajAYXOhnFGsTSSQ(T item)
			{
			}

			public YjTDPOjpGbzdajAYXOhnFGsTSSQ(YjTDPOjpGbzdajAYXOhnFGsTSSQ source)
			{
			}

			public bool UWLgXymaPDbBHhagBKOcEjokjPcg()
			{
				return false;
			}
		}

		private Action<Exception> XCEsZJlqGJDvRbiccAnlWITivCm;

		private readonly List<YjTDPOjpGbzdajAYXOhnFGsTSSQ> brSochNMhpayANQgFAJOKjiiWZAu;

		private readonly List<YjTDPOjpGbzdajAYXOhnFGsTSSQ> JOnJbtLBULBliVqdHwFVtDhCAO;

		internal override int Count => 0;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected SafeDelegate()
		{
		}

		protected SafeDelegate(Action<Exception> exceptionHandler)
		{
		}

		protected SafeDelegate(SafeDelegate<T> source)
		{
		}

		public void AddDelegate(T @delegate)
		{
		}

		public void RemoveDelegate(T @delegate)
		{
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
		}

		internal override void Clear()
		{
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
		}

		protected T GetCombinedDelegate()
		{
			return null;
		}

		private bool afcHaYQkdckJVUZrxHnIFEkSGBE(T P_0)
		{
			return false;
		}

		private int kZxCnSMtUSDYMIgGLhsPHPbPwHn(T P_0)
		{
			return 0;
		}

		private static Delegate HiAhdQGnVkGeYwuTzgJIgzNlQgck(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate HiAhdQGnVkGeYwuTzgJIgzNlQgck(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int HRsMyWHYRTgRgLtLIDLHYkVNfaJ(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> JiGJlcaAXDiiQHbSpRzbVYmIXzr(Delegate P_0)
		{
			return null;
		}
	}
}
