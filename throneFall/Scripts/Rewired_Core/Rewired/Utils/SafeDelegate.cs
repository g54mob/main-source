using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> yoNfAluHfaTFHcNhDDLiCmgPOQDy;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return yoNfAluHfaTFHcNhDDLiCmgPOQDy;
			}
			set
			{
				yoNfAluHfaTFHcNhDDLiCmgPOQDy = value;
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
		private class XTFvHtwonbuVRoChlzoJRRKBkLIc
		{
			public readonly T PYeNUhfJqkYLFWtIZPTmWckSaUFy;

			public readonly object XNgdQhcDfIPFQxPAAdourCkRFXEs;

			public readonly object maCaRVhxtngDpvKxZJlxWLMcECAE;

			public readonly bool JIqcXXgQAqnUVmhIaejFHlIuLOweA;

			public XTFvHtwonbuVRoChlzoJRRKBkLIc(T P_0)
			{
				PYeNUhfJqkYLFWtIZPTmWckSaUFy = P_0;
				XNgdQhcDfIPFQxPAAdourCkRFXEs = ((Delegate)(object)P_0).Target;
				try
				{
					maCaRVhxtngDpvKxZJlxWLMcECAE = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					maCaRVhxtngDpvKxZJlxWLMcECAE = null;
				}
				JIqcXXgQAqnUVmhIaejFHlIuLOweA = XNgdQhcDfIPFQxPAAdourCkRFXEs != null && XNgdQhcDfIPFQxPAAdourCkRFXEs is UnityEngine.Object;
			}

			public XTFvHtwonbuVRoChlzoJRRKBkLIc(XTFvHtwonbuVRoChlzoJRRKBkLIc P_0)
				: this(MiscTools.Clone((object)P_0.PYeNUhfJqkYLFWtIZPTmWckSaUFy) as T)
			{
			}

			public bool drumLpyjfniBtfkAcZhGZTJWRWET()
			{
				if (XNgdQhcDfIPFQxPAAdourCkRFXEs != null)
				{
					if (XNgdQhcDfIPFQxPAAdourCkRFXEs is UnityEngine.Object)
					{
						return (UnityEngine.Object)XNgdQhcDfIPFQxPAAdourCkRFXEs == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> KHBKOmZkJEhkdogTxGhlJBWOLlpcb;

		private readonly List<XTFvHtwonbuVRoChlzoJRRKBkLIc> fFoCbyFhtJHOiQaOODKFpoGPtSrb;

		private readonly List<XTFvHtwonbuVRoChlzoJRRKBkLIc> rxbunnppXHOQiBeuYNSHOLMmVJOs;

		int SafeDelegate.Count => fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return KHBKOmZkJEhkdogTxGhlJBWOLlpcb;
			}
			set
			{
				KHBKOmZkJEhkdogTxGhlJBWOLlpcb = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			fFoCbyFhtJHOiQaOODKFpoGPtSrb = new List<XTFvHtwonbuVRoChlzoJRRKBkLIc>();
			rxbunnppXHOQiBeuYNSHOLMmVJOs = new List<XTFvHtwonbuVRoChlzoJRRKBkLIc>();
			if (KHBKOmZkJEhkdogTxGhlJBWOLlpcb == null)
			{
				KHBKOmZkJEhkdogTxGhlJBWOLlpcb = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			KHBKOmZkJEhkdogTxGhlJBWOLlpcb = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.KHBKOmZkJEhkdogTxGhlJBWOLlpcb != null)
			{
				KHBKOmZkJEhkdogTxGhlJBWOLlpcb = P_0.KHBKOmZkJEhkdogTxGhlJBWOLlpcb;
			}
			for (int i = 0; i < P_0.fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count; i++)
			{
				fFoCbyFhtJHOiQaOODKFpoGPtSrb.Add(new XTFvHtwonbuVRoChlzoJRRKBkLIc(P_0.fFoCbyFhtJHOiQaOODKFpoGPtSrb[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = VRPavWtqwijGmOZGBNqCEITJiFrT((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!nALHmZTUOzVcWSlbBMUCWyLERzZK(val))
				{
					fFoCbyFhtJHOiQaOODKFpoGPtSrb.Add(new XTFvHtwonbuVRoChlzoJRRKBkLIc(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = VRPavWtqwijGmOZGBNqCEITJiFrT((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(fFoCbyFhtJHOiQaOODKFpoGPtSrb[num].PYeNUhfJqkYLFWtIZPTmWckSaUFy, (T)(object)list[i]))
					{
						fFoCbyFhtJHOiQaOODKFpoGPtSrb.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = AuBFGBcpEXShKZnCmWRRdWjNZIbAA(obj, (Delegate)(object)fFoCbyFhtJHOiQaOODKFpoGPtSrb[num].PYeNUhfJqkYLFWtIZPTmWckSaUFy);
				if (JLTSOOLENpLoiXFvoFXnYGmeGYkC(obj2) == 0)
				{
					fFoCbyFhtJHOiQaOODKFpoGPtSrb.RemoveAt(num);
				}
				else
				{
					fFoCbyFhtJHOiQaOODKFpoGPtSrb[num] = new XTFvHtwonbuVRoChlzoJRRKBkLIc((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			fFoCbyFhtJHOiQaOODKFpoGPtSrb.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count;
			if (count == 0)
			{
				return;
			}
			rxbunnppXHOQiBeuYNSHOLMmVJOs.Clear();
			for (int i = 0; i < count; i++)
			{
				rxbunnppXHOQiBeuYNSHOLMmVJOs.Add(fFoCbyFhtJHOiQaOODKFpoGPtSrb[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				XTFvHtwonbuVRoChlzoJRRKBkLIc xTFvHtwonbuVRoChlzoJRRKBkLIc = rxbunnppXHOQiBeuYNSHOLMmVJOs[j];
				if (xTFvHtwonbuVRoChlzoJRRKBkLIc.JIqcXXgQAqnUVmhIaejFHlIuLOweA && xTFvHtwonbuVRoChlzoJRRKBkLIc.drumLpyjfniBtfkAcZhGZTJWRWET())
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
					invokeCallback(this, xTFvHtwonbuVRoChlzoJRRKBkLIc.PYeNUhfJqkYLFWtIZPTmWckSaUFy);
				}
				catch (Exception ex)
				{
					if (KHBKOmZkJEhkdogTxGhlJBWOLlpcb != null)
					{
						KHBKOmZkJEhkdogTxGhlJBWOLlpcb(ex);
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
					fFoCbyFhtJHOiQaOODKFpoGPtSrb.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				rxbunnppXHOQiBeuYNSHOLMmVJOs.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (fFoCbyFhtJHOiQaOODKFpoGPtSrb == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count; i++)
			{
				T pYeNUhfJqkYLFWtIZPTmWckSaUFy = fFoCbyFhtJHOiQaOODKFpoGPtSrb[i].PYeNUhfJqkYLFWtIZPTmWckSaUFy;
				if (val == null)
				{
					val = pYeNUhfJqkYLFWtIZPTmWckSaUFy;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)pYeNUhfJqkYLFWtIZPTmWckSaUFy);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool nALHmZTUOzVcWSlbBMUCWyLERzZK(T P_0)
		{
			return ohDuMRNHIuBUfCYxGPRTquMfQLPcA(P_0) >= 0;
		}

		private int ohDuMRNHIuBUfCYxGPRTquMfQLPcA(T P_0)
		{
			int count = fFoCbyFhtJHOiQaOODKFpoGPtSrb.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(fFoCbyFhtJHOiQaOODKFpoGPtSrb[i].PYeNUhfJqkYLFWtIZPTmWckSaUFy, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate AuBFGBcpEXShKZnCmWRRdWjNZIbAA(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return FXhNeICJQCYAYzBrAvyfRoNAvepS((Delegate)P_0, P_1);
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

		private static Delegate FXhNeICJQCYAYzBrAvyfRoNAvepS(Delegate P_0, Delegate P_1)
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

		private static int JLTSOOLENpLoiXFvoFXnYGmeGYkC(Delegate P_0)
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

		private static List<Delegate> VRPavWtqwijGmOZGBNqCEITJiFrT(Delegate P_0)
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
