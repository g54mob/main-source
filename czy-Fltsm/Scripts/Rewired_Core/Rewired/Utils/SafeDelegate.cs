using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> HapnlHqpoiBIUEXipLtBhGFdcKSZA;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return HapnlHqpoiBIUEXipLtBhGFdcKSZA;
			}
			set
			{
				HapnlHqpoiBIUEXipLtBhGFdcKSZA = value;
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
		private class qlzOzScdlwlKpNPJyDPZscxCsQDA
		{
			public readonly T yBIovHpNfsIUMfJBfpzRACTaeMCp;

			public readonly object scSUsLoicEIOLMHcsLpFvDxvVNRD;

			public readonly object BgkHrDbofqjqQMRrIhMaIwCSIZuB;

			public readonly bool qjAAiraFByvDIHOVKSVqbmbKFMxZ;

			public qlzOzScdlwlKpNPJyDPZscxCsQDA(T P_0)
			{
				yBIovHpNfsIUMfJBfpzRACTaeMCp = P_0;
				scSUsLoicEIOLMHcsLpFvDxvVNRD = ((Delegate)(object)P_0).Target;
				try
				{
					BgkHrDbofqjqQMRrIhMaIwCSIZuB = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					BgkHrDbofqjqQMRrIhMaIwCSIZuB = null;
				}
				qjAAiraFByvDIHOVKSVqbmbKFMxZ = scSUsLoicEIOLMHcsLpFvDxvVNRD != null && scSUsLoicEIOLMHcsLpFvDxvVNRD is UnityEngine.Object;
			}

			public qlzOzScdlwlKpNPJyDPZscxCsQDA(qlzOzScdlwlKpNPJyDPZscxCsQDA P_0)
				: this(MiscTools.Clone((object)P_0.yBIovHpNfsIUMfJBfpzRACTaeMCp) as T)
			{
			}

			public bool WASFBHgpcbdOiCUVKUTnnRokfSDXA()
			{
				if (scSUsLoicEIOLMHcsLpFvDxvVNRD != null)
				{
					if (scSUsLoicEIOLMHcsLpFvDxvVNRD is UnityEngine.Object)
					{
						return (UnityEngine.Object)scSUsLoicEIOLMHcsLpFvDxvVNRD == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> llvhpWNGQCBzcZTIVcFQhNhgijqzA;

		private readonly List<qlzOzScdlwlKpNPJyDPZscxCsQDA> YvpfPCNyerGeZpzncvihhFuzbrTE;

		private readonly List<qlzOzScdlwlKpNPJyDPZscxCsQDA> IYFZOXxBKPSBxigrozcyUhdQeXPHA;

		int SafeDelegate.Count => YvpfPCNyerGeZpzncvihhFuzbrTE.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return llvhpWNGQCBzcZTIVcFQhNhgijqzA;
			}
			set
			{
				llvhpWNGQCBzcZTIVcFQhNhgijqzA = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			YvpfPCNyerGeZpzncvihhFuzbrTE = new List<qlzOzScdlwlKpNPJyDPZscxCsQDA>();
			IYFZOXxBKPSBxigrozcyUhdQeXPHA = new List<qlzOzScdlwlKpNPJyDPZscxCsQDA>();
			if (llvhpWNGQCBzcZTIVcFQhNhgijqzA == null)
			{
				llvhpWNGQCBzcZTIVcFQhNhgijqzA = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			llvhpWNGQCBzcZTIVcFQhNhgijqzA = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.llvhpWNGQCBzcZTIVcFQhNhgijqzA != null)
			{
				llvhpWNGQCBzcZTIVcFQhNhgijqzA = P_0.llvhpWNGQCBzcZTIVcFQhNhgijqzA;
			}
			for (int i = 0; i < P_0.YvpfPCNyerGeZpzncvihhFuzbrTE.Count; i++)
			{
				YvpfPCNyerGeZpzncvihhFuzbrTE.Add(new qlzOzScdlwlKpNPJyDPZscxCsQDA(P_0.YvpfPCNyerGeZpzncvihhFuzbrTE[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = ybtAUgdMtqgerExBxPphsCqxvXcKA((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!YytiZlDaPvMvNrNixaireCkysdSTA(val))
				{
					YvpfPCNyerGeZpzncvihhFuzbrTE.Add(new qlzOzScdlwlKpNPJyDPZscxCsQDA(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = ybtAUgdMtqgerExBxPphsCqxvXcKA((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = YvpfPCNyerGeZpzncvihhFuzbrTE.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(YvpfPCNyerGeZpzncvihhFuzbrTE[num].yBIovHpNfsIUMfJBfpzRACTaeMCp, (T)(object)list[i]))
					{
						YvpfPCNyerGeZpzncvihhFuzbrTE.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = YvpfPCNyerGeZpzncvihhFuzbrTE.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = rJxZxbjLRDLeNAqBWbhoASQvdGysA(obj, (Delegate)(object)YvpfPCNyerGeZpzncvihhFuzbrTE[num].yBIovHpNfsIUMfJBfpzRACTaeMCp);
				if (wIfjxoVQDvGFpuHOGfQECwdKYZtj(obj2) == 0)
				{
					YvpfPCNyerGeZpzncvihhFuzbrTE.RemoveAt(num);
				}
				else
				{
					YvpfPCNyerGeZpzncvihhFuzbrTE[num] = new qlzOzScdlwlKpNPJyDPZscxCsQDA((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			YvpfPCNyerGeZpzncvihhFuzbrTE.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = YvpfPCNyerGeZpzncvihhFuzbrTE.Count;
			if (count == 0)
			{
				return;
			}
			IYFZOXxBKPSBxigrozcyUhdQeXPHA.Clear();
			for (int i = 0; i < count; i++)
			{
				IYFZOXxBKPSBxigrozcyUhdQeXPHA.Add(YvpfPCNyerGeZpzncvihhFuzbrTE[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				qlzOzScdlwlKpNPJyDPZscxCsQDA qlzOzScdlwlKpNPJyDPZscxCsQDA2 = IYFZOXxBKPSBxigrozcyUhdQeXPHA[j];
				if (qlzOzScdlwlKpNPJyDPZscxCsQDA2.qjAAiraFByvDIHOVKSVqbmbKFMxZ && qlzOzScdlwlKpNPJyDPZscxCsQDA2.WASFBHgpcbdOiCUVKUTnnRokfSDXA())
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
					invokeCallback(this, qlzOzScdlwlKpNPJyDPZscxCsQDA2.yBIovHpNfsIUMfJBfpzRACTaeMCp);
				}
				catch (Exception ex)
				{
					if (llvhpWNGQCBzcZTIVcFQhNhgijqzA != null)
					{
						llvhpWNGQCBzcZTIVcFQhNhgijqzA(ex);
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
					YvpfPCNyerGeZpzncvihhFuzbrTE.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				IYFZOXxBKPSBxigrozcyUhdQeXPHA.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (YvpfPCNyerGeZpzncvihhFuzbrTE == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < YvpfPCNyerGeZpzncvihhFuzbrTE.Count; i++)
			{
				T yBIovHpNfsIUMfJBfpzRACTaeMCp = YvpfPCNyerGeZpzncvihhFuzbrTE[i].yBIovHpNfsIUMfJBfpzRACTaeMCp;
				if (val == null)
				{
					val = yBIovHpNfsIUMfJBfpzRACTaeMCp;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)yBIovHpNfsIUMfJBfpzRACTaeMCp);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool YytiZlDaPvMvNrNixaireCkysdSTA(T P_0)
		{
			return BvdZdvLAJiQLqvGioGdcjifVkTEkA(P_0) >= 0;
		}

		private int BvdZdvLAJiQLqvGioGdcjifVkTEkA(T P_0)
		{
			int count = YvpfPCNyerGeZpzncvihhFuzbrTE.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(YvpfPCNyerGeZpzncvihhFuzbrTE[i].yBIovHpNfsIUMfJBfpzRACTaeMCp, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate rJxZxbjLRDLeNAqBWbhoASQvdGysA(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return myRLFiQNFAjLLKzyisAWBlciDaeJA((Delegate)P_0, P_1);
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

		private static Delegate myRLFiQNFAjLLKzyisAWBlciDaeJA(Delegate P_0, Delegate P_1)
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

		private static int wIfjxoVQDvGFpuHOGfQECwdKYZtj(Delegate P_0)
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

		private static List<Delegate> ybtAUgdMtqgerExBxPphsCqxvXcKA(Delegate P_0)
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
