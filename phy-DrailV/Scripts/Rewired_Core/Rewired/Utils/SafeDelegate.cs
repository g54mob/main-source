using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> RxeKDZdTZrjJKsLUZxDQtBtZTNOD;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return RxeKDZdTZrjJKsLUZxDQtBtZTNOD;
			}
			set
			{
				RxeKDZdTZrjJKsLUZxDQtBtZTNOD = value;
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
		private class lqJBNMFOuPBOcMgEdqtASkgTupDx
		{
			public readonly T ELAgrvFVeGaxXkehkhmyIodmtbsp;

			public readonly object kxVVfsEvIkmogZXRbQDbWrFdzRdN;

			public readonly object gkUCNCiyPJxGKTZJGVRyOPoNddaf;

			public readonly bool lKCkyGEcmAAyyFSUdKLunMWPctHYA;

			public lqJBNMFOuPBOcMgEdqtASkgTupDx(T P_0)
			{
				ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
				kxVVfsEvIkmogZXRbQDbWrFdzRdN = ((Delegate)(object)P_0).Target;
				try
				{
					gkUCNCiyPJxGKTZJGVRyOPoNddaf = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					gkUCNCiyPJxGKTZJGVRyOPoNddaf = null;
				}
				lKCkyGEcmAAyyFSUdKLunMWPctHYA = kxVVfsEvIkmogZXRbQDbWrFdzRdN != null && kxVVfsEvIkmogZXRbQDbWrFdzRdN is UnityEngine.Object;
			}

			public lqJBNMFOuPBOcMgEdqtASkgTupDx(lqJBNMFOuPBOcMgEdqtASkgTupDx P_0)
				: this(MiscTools.Clone((object)P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp) as T)
			{
			}

			public bool pCLXQiIHjraXVTEwdBIXqqolTepV()
			{
				if (kxVVfsEvIkmogZXRbQDbWrFdzRdN != null)
				{
					if (kxVVfsEvIkmogZXRbQDbWrFdzRdN is UnityEngine.Object)
					{
						return (UnityEngine.Object)kxVVfsEvIkmogZXRbQDbWrFdzRdN == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> eGEFuPRuanCuZKfyClcOZNumnGtf;

		private readonly List<lqJBNMFOuPBOcMgEdqtASkgTupDx> UHSwxvvsTPZRMwCsbLFjsUisaUJF;

		private readonly List<lqJBNMFOuPBOcMgEdqtASkgTupDx> BNBfhBiBtaKcXNwTVxJDIrtvixVQ;

		internal override int Count => UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return eGEFuPRuanCuZKfyClcOZNumnGtf;
			}
			set
			{
				eGEFuPRuanCuZKfyClcOZNumnGtf = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			UHSwxvvsTPZRMwCsbLFjsUisaUJF = new List<lqJBNMFOuPBOcMgEdqtASkgTupDx>();
			BNBfhBiBtaKcXNwTVxJDIrtvixVQ = new List<lqJBNMFOuPBOcMgEdqtASkgTupDx>();
			if (eGEFuPRuanCuZKfyClcOZNumnGtf == null)
			{
				eGEFuPRuanCuZKfyClcOZNumnGtf = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			eGEFuPRuanCuZKfyClcOZNumnGtf = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.eGEFuPRuanCuZKfyClcOZNumnGtf != null)
			{
				eGEFuPRuanCuZKfyClcOZNumnGtf = P_0.eGEFuPRuanCuZKfyClcOZNumnGtf;
			}
			for (int i = 0; i < P_0.UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count; i++)
			{
				UHSwxvvsTPZRMwCsbLFjsUisaUJF.Add(new lqJBNMFOuPBOcMgEdqtASkgTupDx(P_0.UHSwxvvsTPZRMwCsbLFjsUisaUJF[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = iPGJRqCHdtgPQqjSNElOAEmWYckx((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!XrqcBMeuSMEFFHtBARTfiYGSMlVMB(val))
				{
					UHSwxvvsTPZRMwCsbLFjsUisaUJF.Add(new lqJBNMFOuPBOcMgEdqtASkgTupDx(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = iPGJRqCHdtgPQqjSNElOAEmWYckx((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(UHSwxvvsTPZRMwCsbLFjsUisaUJF[num].ELAgrvFVeGaxXkehkhmyIodmtbsp, (T)(object)list[i]))
					{
						UHSwxvvsTPZRMwCsbLFjsUisaUJF.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = ubKczAkVfUgHGHSBVVTvmULbIJhP(obj, (Delegate)(object)UHSwxvvsTPZRMwCsbLFjsUisaUJF[num].ELAgrvFVeGaxXkehkhmyIodmtbsp);
				if (qWmgdQvXpneCgcXPaTRyBnHDVkOk(obj2) == 0)
				{
					UHSwxvvsTPZRMwCsbLFjsUisaUJF.RemoveAt(num);
				}
				else
				{
					UHSwxvvsTPZRMwCsbLFjsUisaUJF[num] = new lqJBNMFOuPBOcMgEdqtASkgTupDx((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			UHSwxvvsTPZRMwCsbLFjsUisaUJF.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count;
			if (count == 0)
			{
				return;
			}
			BNBfhBiBtaKcXNwTVxJDIrtvixVQ.Clear();
			for (int i = 0; i < count; i++)
			{
				BNBfhBiBtaKcXNwTVxJDIrtvixVQ.Add(UHSwxvvsTPZRMwCsbLFjsUisaUJF[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				lqJBNMFOuPBOcMgEdqtASkgTupDx lqJBNMFOuPBOcMgEdqtASkgTupDx2 = BNBfhBiBtaKcXNwTVxJDIrtvixVQ[j];
				if (lqJBNMFOuPBOcMgEdqtASkgTupDx2.lKCkyGEcmAAyyFSUdKLunMWPctHYA && lqJBNMFOuPBOcMgEdqtASkgTupDx2.pCLXQiIHjraXVTEwdBIXqqolTepV())
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
					invokeCallback(this, lqJBNMFOuPBOcMgEdqtASkgTupDx2.ELAgrvFVeGaxXkehkhmyIodmtbsp);
				}
				catch (Exception ex)
				{
					if (eGEFuPRuanCuZKfyClcOZNumnGtf != null)
					{
						eGEFuPRuanCuZKfyClcOZNumnGtf(ex);
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
					UHSwxvvsTPZRMwCsbLFjsUisaUJF.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				BNBfhBiBtaKcXNwTVxJDIrtvixVQ.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (UHSwxvvsTPZRMwCsbLFjsUisaUJF == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count; i++)
			{
				T eLAgrvFVeGaxXkehkhmyIodmtbsp = UHSwxvvsTPZRMwCsbLFjsUisaUJF[i].ELAgrvFVeGaxXkehkhmyIodmtbsp;
				if (val == null)
				{
					val = eLAgrvFVeGaxXkehkhmyIodmtbsp;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)eLAgrvFVeGaxXkehkhmyIodmtbsp);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool XrqcBMeuSMEFFHtBARTfiYGSMlVMB(T P_0)
		{
			return PujFpIgnaejxCcbCzrcoRIpZaecab(P_0) >= 0;
		}

		private int PujFpIgnaejxCcbCzrcoRIpZaecab(T P_0)
		{
			int count = UHSwxvvsTPZRMwCsbLFjsUisaUJF.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(UHSwxvvsTPZRMwCsbLFjsUisaUJF[i].ELAgrvFVeGaxXkehkhmyIodmtbsp, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate ubKczAkVfUgHGHSBVVTvmULbIJhP(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return ubKczAkVfUgHGHSBVVTvmULbIJhP((Delegate)P_0, P_1);
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

		private static Delegate ubKczAkVfUgHGHSBVVTvmULbIJhP(Delegate P_0, Delegate P_1)
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

		private static int qWmgdQvXpneCgcXPaTRyBnHDVkOk(Delegate P_0)
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

		private static List<Delegate> iPGJRqCHdtgPQqjSNElOAEmWYckx(Delegate P_0)
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
