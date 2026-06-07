using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> HftbzhekgRjDobLeoKhwPlAmfgVfA;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return HftbzhekgRjDobLeoKhwPlAmfgVfA;
			}
			set
			{
				HftbzhekgRjDobLeoKhwPlAmfgVfA = value;
			}
		}

		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		internal abstract void Clear();

		public abstract object Clone();
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class ggnZKXiQzSDeizFJQjPcbMvcsEPuA
		{
			public readonly T sgCdFjlUxFBDkTQNsznaNQUhskRL;

			public readonly object qZISAlqNctzFhsuHpcVukiSyNhKn;

			public readonly object RLkeZTFveINcKAgDwqffFZxTPgGAA;

			public readonly bool iqYDuPqJNBPScjHDLXBPgHmZEyax;

			public ggnZKXiQzSDeizFJQjPcbMvcsEPuA(T P_0)
			{
				sgCdFjlUxFBDkTQNsznaNQUhskRL = P_0;
				qZISAlqNctzFhsuHpcVukiSyNhKn = ((Delegate)(object)P_0).Target;
				try
				{
					RLkeZTFveINcKAgDwqffFZxTPgGAA = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					RLkeZTFveINcKAgDwqffFZxTPgGAA = null;
				}
				iqYDuPqJNBPScjHDLXBPgHmZEyax = qZISAlqNctzFhsuHpcVukiSyNhKn != null && qZISAlqNctzFhsuHpcVukiSyNhKn is UnityEngine.Object;
			}

			public ggnZKXiQzSDeizFJQjPcbMvcsEPuA(ggnZKXiQzSDeizFJQjPcbMvcsEPuA P_0)
				: this(MiscTools.Clone((object)P_0.sgCdFjlUxFBDkTQNsznaNQUhskRL) as T)
			{
			}

			public bool WHKIDhuJqWkZWaSNTPLEUKvjbgGO()
			{
				if (qZISAlqNctzFhsuHpcVukiSyNhKn != null)
				{
					if (qZISAlqNctzFhsuHpcVukiSyNhKn is UnityEngine.Object)
					{
						return (UnityEngine.Object)qZISAlqNctzFhsuHpcVukiSyNhKn == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> rQrjJiVIEpjiExAEKZNlCmmzpBvm;

		private readonly List<ggnZKXiQzSDeizFJQjPcbMvcsEPuA> WUxfjzDXyMZLbTAnvbxWhkWupPONA;

		private readonly List<ggnZKXiQzSDeizFJQjPcbMvcsEPuA> IBFSKdhBAsIBXWqrhyqHJfgTarIx;

		int SafeDelegate.Count => WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return rQrjJiVIEpjiExAEKZNlCmmzpBvm;
			}
			set
			{
				rQrjJiVIEpjiExAEKZNlCmmzpBvm = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			WUxfjzDXyMZLbTAnvbxWhkWupPONA = new List<ggnZKXiQzSDeizFJQjPcbMvcsEPuA>();
			IBFSKdhBAsIBXWqrhyqHJfgTarIx = new List<ggnZKXiQzSDeizFJQjPcbMvcsEPuA>();
			if (rQrjJiVIEpjiExAEKZNlCmmzpBvm == null)
			{
				rQrjJiVIEpjiExAEKZNlCmmzpBvm = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			rQrjJiVIEpjiExAEKZNlCmmzpBvm = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.rQrjJiVIEpjiExAEKZNlCmmzpBvm != null)
			{
				rQrjJiVIEpjiExAEKZNlCmmzpBvm = P_0.rQrjJiVIEpjiExAEKZNlCmmzpBvm;
			}
			for (int i = 0; i < P_0.WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count; i++)
			{
				WUxfjzDXyMZLbTAnvbxWhkWupPONA.Add(new ggnZKXiQzSDeizFJQjPcbMvcsEPuA(P_0.WUxfjzDXyMZLbTAnvbxWhkWupPONA[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = aidDOWnmnXbpLNHDgClAgFdmhjrxA((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!WRtbLDNBBYfcpDPkopcQHFjlkJNdb(val))
				{
					WUxfjzDXyMZLbTAnvbxWhkWupPONA.Add(new ggnZKXiQzSDeizFJQjPcbMvcsEPuA(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = aidDOWnmnXbpLNHDgClAgFdmhjrxA((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(WUxfjzDXyMZLbTAnvbxWhkWupPONA[num].sgCdFjlUxFBDkTQNsznaNQUhskRL, (T)(object)list[i]))
					{
						WUxfjzDXyMZLbTAnvbxWhkWupPONA.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = bxSbBBtNaaznHwZyHpFUNNMgihCB(obj, (Delegate)(object)WUxfjzDXyMZLbTAnvbxWhkWupPONA[num].sgCdFjlUxFBDkTQNsznaNQUhskRL);
				if (kGvUrEFNGKBHTOJERBfjbVgFqeaXA(obj2) == 0)
				{
					WUxfjzDXyMZLbTAnvbxWhkWupPONA.RemoveAt(num);
				}
				else
				{
					WUxfjzDXyMZLbTAnvbxWhkWupPONA[num] = new ggnZKXiQzSDeizFJQjPcbMvcsEPuA((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			WUxfjzDXyMZLbTAnvbxWhkWupPONA.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count;
			if (count == 0)
			{
				return;
			}
			IBFSKdhBAsIBXWqrhyqHJfgTarIx.Clear();
			for (int i = 0; i < count; i++)
			{
				IBFSKdhBAsIBXWqrhyqHJfgTarIx.Add(WUxfjzDXyMZLbTAnvbxWhkWupPONA[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				ggnZKXiQzSDeizFJQjPcbMvcsEPuA ggnZKXiQzSDeizFJQjPcbMvcsEPuA2 = IBFSKdhBAsIBXWqrhyqHJfgTarIx[j];
				if (ggnZKXiQzSDeizFJQjPcbMvcsEPuA2.iqYDuPqJNBPScjHDLXBPgHmZEyax && ggnZKXiQzSDeizFJQjPcbMvcsEPuA2.WHKIDhuJqWkZWaSNTPLEUKvjbgGO())
				{
					if (list == null)
					{
						list = TempListPool.Get<int>();
					}
					list.Add(j);
					continue;
				}
				try
				{
					invokeCallback(this, ggnZKXiQzSDeizFJQjPcbMvcsEPuA2.sgCdFjlUxFBDkTQNsznaNQUhskRL);
				}
				catch (Exception ex)
				{
					if (rQrjJiVIEpjiExAEKZNlCmmzpBvm != null)
					{
						rQrjJiVIEpjiExAEKZNlCmmzpBvm(ex);
					}
					else if (ex.InnerException != null)
					{
						Logger.LogError(ex.InnerException, requiredThreadSafety: true);
					}
					if (list == null)
					{
						list = TempListPool.Get<int>();
					}
					list.Add(j);
				}
			}
			if (list != null)
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					WUxfjzDXyMZLbTAnvbxWhkWupPONA.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				IBFSKdhBAsIBXWqrhyqHJfgTarIx.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (WUxfjzDXyMZLbTAnvbxWhkWupPONA == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count; i++)
			{
				T sgCdFjlUxFBDkTQNsznaNQUhskRL = WUxfjzDXyMZLbTAnvbxWhkWupPONA[i].sgCdFjlUxFBDkTQNsznaNQUhskRL;
				if (val == null)
				{
					val = sgCdFjlUxFBDkTQNsznaNQUhskRL;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)sgCdFjlUxFBDkTQNsznaNQUhskRL);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool WRtbLDNBBYfcpDPkopcQHFjlkJNdb(T P_0)
		{
			return TXfvzXBDPNMtSZqpnxjXdheSpHDI(P_0) >= 0;
		}

		private int TXfvzXBDPNMtSZqpnxjXdheSpHDI(T P_0)
		{
			int count = WUxfjzDXyMZLbTAnvbxWhkWupPONA.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(WUxfjzDXyMZLbTAnvbxWhkWupPONA[i].sgCdFjlUxFBDkTQNsznaNQUhskRL, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate bxSbBBtNaaznHwZyHpFUNNMgihCB(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return gCBNfGMUXxSbxysubGivMpjnStbG((Delegate)P_0, P_1);
			}
			try
			{
				Delegate[] invocationList = P_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					if (invocationList[i].Target == P_0 || ReflectionTools.GetMethodInfo(invocationList[i]) == P_0)
					{
						if ((object)P_1 == null)
						{
							return P_1;
						}
						P_1 = Delegate.RemoveAll(P_1, invocationList[i]);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception caught while removing delegates from list (1):\n" + ex);
			}
			return P_1;
		}

		private static Delegate gCBNfGMUXxSbxysubGivMpjnStbG(Delegate P_0, Delegate P_1)
		{
			if ((object)P_0 == null || (object)P_1 == null)
			{
				return P_1;
			}
			if ((object)P_0.GetType() != P_0.GetType())
			{
				return P_1;
			}
			try
			{
				Delegate[] invocationList = P_0.GetInvocationList();
				Delegate[] invocationList2 = P_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					object methodInfo = ReflectionTools.GetMethodInfo(invocationList[i]);
					foreach (Delegate obj in invocationList2)
					{
						object methodInfo2 = ReflectionTools.GetMethodInfo(obj);
						if (methodInfo == methodInfo2)
						{
							if ((object)P_1 == null)
							{
								return P_1;
							}
							P_1 = Delegate.RemoveAll(P_1, obj);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception caught while removing delegates from list (2):\n" + ex);
			}
			return P_1;
		}

		private static int kGvUrEFNGKBHTOJERBfjbVgFqeaXA(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return 0;
			}
			Delegate[] invocationList = P_0.GetInvocationList();
			if (invocationList == null)
			{
				return 0;
			}
			return invocationList.Length;
		}

		private static List<Delegate> aidDOWnmnXbpLNHDgClAgFdmhjrxA(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return null;
			}
			Delegate[] invocationList = P_0.GetInvocationList();
			if (invocationList == null)
			{
				return null;
			}
			List<Delegate> list = new List<Delegate>(invocationList.Length);
			for (int i = 0; i < invocationList.Length; i++)
			{
				list.Add(invocationList[i]);
			}
			return list;
		}
	}
}
