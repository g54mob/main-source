using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> EdsISpthWUkFinNbIIHlKPNsLeq;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return EdsISpthWUkFinNbIIHlKPNsLeq;
			}
			set
			{
				EdsISpthWUkFinNbIIHlKPNsLeq = value;
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
		private class eOXaFVHkUaVHlFKMebIldSucBnd
		{
			public readonly T PsKJxyXhYxofEzkrjdXLrJdXdjYc;

			public readonly object jWJUzdYygPEtnMmJufqABlNORLBB;

			public readonly object xfEBYTmvtkyIVAQDVwCBjwFohJW;

			public readonly bool ikSggXGRAtBjlJIUyBwFirKkIzrX;

			public eOXaFVHkUaVHlFKMebIldSucBnd(T item)
			{
				PsKJxyXhYxofEzkrjdXLrJdXdjYc = item;
				jWJUzdYygPEtnMmJufqABlNORLBB = ((Delegate)(object)item).Target;
				try
				{
					xfEBYTmvtkyIVAQDVwCBjwFohJW = ReflectionTools.GetMethodInfo((Delegate)(object)item);
				}
				catch
				{
					xfEBYTmvtkyIVAQDVwCBjwFohJW = null;
				}
				ikSggXGRAtBjlJIUyBwFirKkIzrX = jWJUzdYygPEtnMmJufqABlNORLBB != null && jWJUzdYygPEtnMmJufqABlNORLBB is UnityEngine.Object;
			}

			public eOXaFVHkUaVHlFKMebIldSucBnd(eOXaFVHkUaVHlFKMebIldSucBnd source)
				: this(MiscTools.Clone((object)source.PsKJxyXhYxofEzkrjdXLrJdXdjYc) as T)
			{
			}

			public bool wBTEHtKpBQdnKDKukwrcjNaIKcFJ()
			{
				if (jWJUzdYygPEtnMmJufqABlNORLBB != null)
				{
					if (jWJUzdYygPEtnMmJufqABlNORLBB is UnityEngine.Object)
					{
						return (UnityEngine.Object)jWJUzdYygPEtnMmJufqABlNORLBB == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> hnQJxUDTWILFSPPsRMntiIFBfwH;

		private readonly List<eOXaFVHkUaVHlFKMebIldSucBnd> VIIciojtjkGDPpreiotUFLwBasd;

		private readonly List<eOXaFVHkUaVHlFKMebIldSucBnd> MLPDbWfPHNzhQBMFEJqeEpbGwfl;

		internal override int Count => VIIciojtjkGDPpreiotUFLwBasd.Count;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return hnQJxUDTWILFSPPsRMntiIFBfwH;
			}
			set
			{
				hnQJxUDTWILFSPPsRMntiIFBfwH = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			VIIciojtjkGDPpreiotUFLwBasd = new List<eOXaFVHkUaVHlFKMebIldSucBnd>();
			MLPDbWfPHNzhQBMFEJqeEpbGwfl = new List<eOXaFVHkUaVHlFKMebIldSucBnd>();
			if (hnQJxUDTWILFSPPsRMntiIFBfwH == null)
			{
				hnQJxUDTWILFSPPsRMntiIFBfwH = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> exceptionHandler)
			: this()
		{
			if (exceptionHandler == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			hnQJxUDTWILFSPPsRMntiIFBfwH = exceptionHandler;
		}

		protected SafeDelegate(SafeDelegate<T> source)
			: this()
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.hnQJxUDTWILFSPPsRMntiIFBfwH != null)
			{
				hnQJxUDTWILFSPPsRMntiIFBfwH = source.hnQJxUDTWILFSPPsRMntiIFBfwH;
			}
			for (int i = 0; i < source.VIIciojtjkGDPpreiotUFLwBasd.Count; i++)
			{
				VIIciojtjkGDPpreiotUFLwBasd.Add(new eOXaFVHkUaVHlFKMebIldSucBnd(source.VIIciojtjkGDPpreiotUFLwBasd[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = hpUiJtMfPWEUZCpASCUnBpydpwGC((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!YRagHVGgqrxCGUgBYtkIqvCxSddL(val))
				{
					VIIciojtjkGDPpreiotUFLwBasd.Add(new eOXaFVHkUaVHlFKMebIldSucBnd(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = hpUiJtMfPWEUZCpASCUnBpydpwGC((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = VIIciojtjkGDPpreiotUFLwBasd.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(VIIciojtjkGDPpreiotUFLwBasd[num].PsKJxyXhYxofEzkrjdXLrJdXdjYc, (T)(object)list[i]))
					{
						VIIciojtjkGDPpreiotUFLwBasd.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			int count = VIIciojtjkGDPpreiotUFLwBasd.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				Delegate obj2 = fgAzSJgIVxgCTCwPUjcKBqXUzDH(obj, (Delegate)(object)VIIciojtjkGDPpreiotUFLwBasd[num].PsKJxyXhYxofEzkrjdXLrJdXdjYc);
				if (fWeyYPrNSSlEbfJBtaADaIVuaFc(obj2) == 0)
				{
					VIIciojtjkGDPpreiotUFLwBasd.RemoveAt(num);
				}
				else
				{
					VIIciojtjkGDPpreiotUFLwBasd[num] = new eOXaFVHkUaVHlFKMebIldSucBnd((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			VIIciojtjkGDPpreiotUFLwBasd.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = VIIciojtjkGDPpreiotUFLwBasd.Count;
			if (count == 0)
			{
				return;
			}
			MLPDbWfPHNzhQBMFEJqeEpbGwfl.Clear();
			for (int i = 0; i < count; i++)
			{
				MLPDbWfPHNzhQBMFEJqeEpbGwfl.Add(VIIciojtjkGDPpreiotUFLwBasd[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				eOXaFVHkUaVHlFKMebIldSucBnd eOXaFVHkUaVHlFKMebIldSucBnd2 = MLPDbWfPHNzhQBMFEJqeEpbGwfl[j];
				if (eOXaFVHkUaVHlFKMebIldSucBnd2.ikSggXGRAtBjlJIUyBwFirKkIzrX && eOXaFVHkUaVHlFKMebIldSucBnd2.wBTEHtKpBQdnKDKukwrcjNaIKcFJ())
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
					invokeCallback(this, eOXaFVHkUaVHlFKMebIldSucBnd2.PsKJxyXhYxofEzkrjdXLrJdXdjYc);
				}
				catch (Exception ex)
				{
					if (hnQJxUDTWILFSPPsRMntiIFBfwH != null)
					{
						hnQJxUDTWILFSPPsRMntiIFBfwH(ex);
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
					VIIciojtjkGDPpreiotUFLwBasd.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				MLPDbWfPHNzhQBMFEJqeEpbGwfl.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (VIIciojtjkGDPpreiotUFLwBasd == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < VIIciojtjkGDPpreiotUFLwBasd.Count; i++)
			{
				T psKJxyXhYxofEzkrjdXLrJdXdjYc = VIIciojtjkGDPpreiotUFLwBasd[i].PsKJxyXhYxofEzkrjdXLrJdXdjYc;
				if (val == null)
				{
					val = psKJxyXhYxofEzkrjdXLrJdXdjYc;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)psKJxyXhYxofEzkrjdXLrJdXdjYc);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool YRagHVGgqrxCGUgBYtkIqvCxSddL(T P_0)
		{
			return EZvGxHsqIFFuTapSiFVRnGzgbyW(P_0) >= 0;
		}

		private int EZvGxHsqIFFuTapSiFVRnGzgbyW(T P_0)
		{
			int count = VIIciojtjkGDPpreiotUFLwBasd.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(VIIciojtjkGDPpreiotUFLwBasd[i].PsKJxyXhYxofEzkrjdXLrJdXdjYc, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate fgAzSJgIVxgCTCwPUjcKBqXUzDH(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return fgAzSJgIVxgCTCwPUjcKBqXUzDH((Delegate)P_0, P_1);
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

		private static Delegate fgAzSJgIVxgCTCwPUjcKBqXUzDH(Delegate P_0, Delegate P_1)
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

		private static int fWeyYPrNSSlEbfJBtaADaIVuaFc(Delegate P_0)
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

		private static List<Delegate> hpUiJtMfPWEUZCpASCUnBpydpwGC(Delegate P_0)
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
