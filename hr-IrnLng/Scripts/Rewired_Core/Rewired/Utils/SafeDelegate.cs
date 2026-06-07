using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> oJGxosYTUDHJPoAzNgGiCsyEHRI;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return oJGxosYTUDHJPoAzNgGiCsyEHRI;
			}
			set
			{
				oJGxosYTUDHJPoAzNgGiCsyEHRI = value;
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
		private class IYxcTxgxTlyirQoUdWTmdDOWjBG
		{
			public readonly T hzyzSQgZhspWAcbHyINMHjYrItoh;

			public readonly object FGdfYZnSDUbKvZGpdheRKxuypZdG;

			public readonly object DpmfAhBHGfDaZLAhGbsQjvgIGhu;

			public readonly bool UgaVLrbAvoKQjUqetXaMrHlOPtF;

			public IYxcTxgxTlyirQoUdWTmdDOWjBG(T item)
			{
				hzyzSQgZhspWAcbHyINMHjYrItoh = item;
				FGdfYZnSDUbKvZGpdheRKxuypZdG = ((Delegate)(object)item).Target;
				try
				{
					DpmfAhBHGfDaZLAhGbsQjvgIGhu = ReflectionTools.GetMethodInfo((Delegate)(object)item);
				}
				catch
				{
					DpmfAhBHGfDaZLAhGbsQjvgIGhu = null;
				}
				UgaVLrbAvoKQjUqetXaMrHlOPtF = FGdfYZnSDUbKvZGpdheRKxuypZdG != null && FGdfYZnSDUbKvZGpdheRKxuypZdG is UnityEngine.Object;
			}

			public IYxcTxgxTlyirQoUdWTmdDOWjBG(IYxcTxgxTlyirQoUdWTmdDOWjBG source)
				: this(MiscTools.Clone((object)source.hzyzSQgZhspWAcbHyINMHjYrItoh) as T)
			{
			}

			public bool AmzmSNxCgTKEOLVYhhphZIHuajr()
			{
				if (FGdfYZnSDUbKvZGpdheRKxuypZdG != null)
				{
					if (FGdfYZnSDUbKvZGpdheRKxuypZdG is UnityEngine.Object)
					{
						return (UnityEngine.Object)FGdfYZnSDUbKvZGpdheRKxuypZdG == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> FAieLuklWPmbQOWqOUSquwlfdbU;

		private readonly List<IYxcTxgxTlyirQoUdWTmdDOWjBG> nagDGhQOnkvVymKpSwLnBFhuiLs;

		private readonly List<IYxcTxgxTlyirQoUdWTmdDOWjBG> kfnpUwuouWCQSNbvBpudhsCyDvL;

		internal override int Count => nagDGhQOnkvVymKpSwLnBFhuiLs.Count;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return FAieLuklWPmbQOWqOUSquwlfdbU;
			}
			set
			{
				FAieLuklWPmbQOWqOUSquwlfdbU = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			nagDGhQOnkvVymKpSwLnBFhuiLs = new List<IYxcTxgxTlyirQoUdWTmdDOWjBG>();
			kfnpUwuouWCQSNbvBpudhsCyDvL = new List<IYxcTxgxTlyirQoUdWTmdDOWjBG>();
			if (FAieLuklWPmbQOWqOUSquwlfdbU == null)
			{
				FAieLuklWPmbQOWqOUSquwlfdbU = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> exceptionHandler)
			: this()
		{
			if (exceptionHandler == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			FAieLuklWPmbQOWqOUSquwlfdbU = exceptionHandler;
		}

		protected SafeDelegate(SafeDelegate<T> source)
			: this()
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.FAieLuklWPmbQOWqOUSquwlfdbU != null)
			{
				FAieLuklWPmbQOWqOUSquwlfdbU = source.FAieLuklWPmbQOWqOUSquwlfdbU;
			}
			for (int i = 0; i < source.nagDGhQOnkvVymKpSwLnBFhuiLs.Count; i++)
			{
				nagDGhQOnkvVymKpSwLnBFhuiLs.Add(new IYxcTxgxTlyirQoUdWTmdDOWjBG(source.nagDGhQOnkvVymKpSwLnBFhuiLs[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = BBiwmPtbkRidZDsiXrUwsdJDooyM((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!qUMsmxJoDabnMgpnPbuRnplJapZC(val))
				{
					nagDGhQOnkvVymKpSwLnBFhuiLs.Add(new IYxcTxgxTlyirQoUdWTmdDOWjBG(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = BBiwmPtbkRidZDsiXrUwsdJDooyM((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = nagDGhQOnkvVymKpSwLnBFhuiLs.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(nagDGhQOnkvVymKpSwLnBFhuiLs[num].hzyzSQgZhspWAcbHyINMHjYrItoh, (T)(object)list[i]))
					{
						nagDGhQOnkvVymKpSwLnBFhuiLs.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			int count = nagDGhQOnkvVymKpSwLnBFhuiLs.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				Delegate obj2 = LTuYrfVkVozDBLbiReFDTAmoBfd(obj, (Delegate)(object)nagDGhQOnkvVymKpSwLnBFhuiLs[num].hzyzSQgZhspWAcbHyINMHjYrItoh);
				if (LkCBpxKiiDYjgmxpyoKfmuGODAO(obj2) == 0)
				{
					nagDGhQOnkvVymKpSwLnBFhuiLs.RemoveAt(num);
				}
				else
				{
					nagDGhQOnkvVymKpSwLnBFhuiLs[num] = new IYxcTxgxTlyirQoUdWTmdDOWjBG((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			nagDGhQOnkvVymKpSwLnBFhuiLs.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = nagDGhQOnkvVymKpSwLnBFhuiLs.Count;
			if (count == 0)
			{
				return;
			}
			kfnpUwuouWCQSNbvBpudhsCyDvL.Clear();
			for (int i = 0; i < count; i++)
			{
				kfnpUwuouWCQSNbvBpudhsCyDvL.Add(nagDGhQOnkvVymKpSwLnBFhuiLs[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				IYxcTxgxTlyirQoUdWTmdDOWjBG yxcTxgxTlyirQoUdWTmdDOWjBG = kfnpUwuouWCQSNbvBpudhsCyDvL[j];
				if (yxcTxgxTlyirQoUdWTmdDOWjBG.UgaVLrbAvoKQjUqetXaMrHlOPtF && yxcTxgxTlyirQoUdWTmdDOWjBG.AmzmSNxCgTKEOLVYhhphZIHuajr())
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
					invokeCallback(this, yxcTxgxTlyirQoUdWTmdDOWjBG.hzyzSQgZhspWAcbHyINMHjYrItoh);
				}
				catch (Exception ex)
				{
					if (FAieLuklWPmbQOWqOUSquwlfdbU != null)
					{
						FAieLuklWPmbQOWqOUSquwlfdbU(ex);
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
					nagDGhQOnkvVymKpSwLnBFhuiLs.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				kfnpUwuouWCQSNbvBpudhsCyDvL.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (nagDGhQOnkvVymKpSwLnBFhuiLs == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < nagDGhQOnkvVymKpSwLnBFhuiLs.Count; i++)
			{
				T hzyzSQgZhspWAcbHyINMHjYrItoh = nagDGhQOnkvVymKpSwLnBFhuiLs[i].hzyzSQgZhspWAcbHyINMHjYrItoh;
				if (val == null)
				{
					val = hzyzSQgZhspWAcbHyINMHjYrItoh;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)hzyzSQgZhspWAcbHyINMHjYrItoh);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool qUMsmxJoDabnMgpnPbuRnplJapZC(T P_0)
		{
			return iFNXApJjlWtDZdwedJFKpfGAMok(P_0) >= 0;
		}

		private int iFNXApJjlWtDZdwedJFKpfGAMok(T P_0)
		{
			int count = nagDGhQOnkvVymKpSwLnBFhuiLs.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(nagDGhQOnkvVymKpSwLnBFhuiLs[i].hzyzSQgZhspWAcbHyINMHjYrItoh, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate LTuYrfVkVozDBLbiReFDTAmoBfd(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return LTuYrfVkVozDBLbiReFDTAmoBfd((Delegate)P_0, P_1);
			}
			try
			{
				Delegate[] invocationList = P_1.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					if (object.ReferenceEquals(invocationList[i].Target, P_0) || object.ReferenceEquals(ReflectionTools.GetMethodInfo(invocationList[i]), P_0))
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

		private static Delegate LTuYrfVkVozDBLbiReFDTAmoBfd(Delegate P_0, Delegate P_1)
		{
			if ((object)P_0 == null || (object)P_1 == null)
			{
				return P_1;
			}
			if (!object.ReferenceEquals(P_0.GetType(), P_0.GetType()))
			{
				return P_1;
			}
			try
			{
				Delegate[] invocationList = P_0.GetInvocationList();
				Delegate[] invocationList2 = P_1.GetInvocationList();
				foreach (Delegate obj in invocationList)
				{
					object methodInfo = ReflectionTools.GetMethodInfo(obj);
					foreach (Delegate obj2 in invocationList2)
					{
						object methodInfo2 = ReflectionTools.GetMethodInfo(obj2);
						if (object.ReferenceEquals(methodInfo, methodInfo2))
						{
							if ((object)P_1 == null)
							{
								return P_1;
							}
							P_1 = Delegate.RemoveAll(P_1, obj2);
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

		private static int LkCBpxKiiDYjgmxpyoKfmuGODAO(Delegate P_0)
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

		private static List<Delegate> BBiwmPtbkRidZDsiXrUwsdJDooyM(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return null;
			}
			Delegate obj = P_0;
			Delegate[] invocationList = obj.GetInvocationList();
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
