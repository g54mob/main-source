using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> ODQbXMzCfwcqzpecWMURzFQEijlk;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return ODQbXMzCfwcqzpecWMURzFQEijlk;
			}
			set
			{
				ODQbXMzCfwcqzpecWMURzFQEijlk = value;
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
		private class xICXKspPevpDhbNRaliBehhUoYlM
		{
			public readonly T pHfCzModmeQixNuNEoGLxzAFgodW;

			public readonly object lBfhIGdpnQTyyeiFLnmTHSKSTpwDb;

			public readonly object QuDZBcoCjltBVsVPQNIIlrnvKsmR;

			public readonly bool dbxPecpMGwgpdtfRrumaAyudQkCt;

			public xICXKspPevpDhbNRaliBehhUoYlM(T P_0)
			{
				pHfCzModmeQixNuNEoGLxzAFgodW = P_0;
				lBfhIGdpnQTyyeiFLnmTHSKSTpwDb = ((Delegate)(object)P_0).Target;
				try
				{
					QuDZBcoCjltBVsVPQNIIlrnvKsmR = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					QuDZBcoCjltBVsVPQNIIlrnvKsmR = null;
				}
				dbxPecpMGwgpdtfRrumaAyudQkCt = lBfhIGdpnQTyyeiFLnmTHSKSTpwDb != null && lBfhIGdpnQTyyeiFLnmTHSKSTpwDb is UnityEngine.Object;
			}

			public xICXKspPevpDhbNRaliBehhUoYlM(xICXKspPevpDhbNRaliBehhUoYlM P_0)
				: this(MiscTools.Clone((object)P_0.pHfCzModmeQixNuNEoGLxzAFgodW) as T)
			{
			}

			public bool DibLTClMdbLiDqOJdPerohzVLuwr()
			{
				if (lBfhIGdpnQTyyeiFLnmTHSKSTpwDb != null)
				{
					if (lBfhIGdpnQTyyeiFLnmTHSKSTpwDb is UnityEngine.Object)
					{
						return (UnityEngine.Object)lBfhIGdpnQTyyeiFLnmTHSKSTpwDb == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> axGtmJYqDUNOXzKFaqjAsfyFTFLh;

		private readonly List<xICXKspPevpDhbNRaliBehhUoYlM> NMSVlGWsvlskcPJjReOxCYGOwDgy;

		private readonly List<xICXKspPevpDhbNRaliBehhUoYlM> VsSGQwlXRGpGEInJXZunngzpdeS;

		int SafeDelegate.Count => NMSVlGWsvlskcPJjReOxCYGOwDgy.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return axGtmJYqDUNOXzKFaqjAsfyFTFLh;
			}
			set
			{
				axGtmJYqDUNOXzKFaqjAsfyFTFLh = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			NMSVlGWsvlskcPJjReOxCYGOwDgy = new List<xICXKspPevpDhbNRaliBehhUoYlM>();
			VsSGQwlXRGpGEInJXZunngzpdeS = new List<xICXKspPevpDhbNRaliBehhUoYlM>();
			if (axGtmJYqDUNOXzKFaqjAsfyFTFLh == null)
			{
				axGtmJYqDUNOXzKFaqjAsfyFTFLh = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			axGtmJYqDUNOXzKFaqjAsfyFTFLh = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.axGtmJYqDUNOXzKFaqjAsfyFTFLh != null)
			{
				axGtmJYqDUNOXzKFaqjAsfyFTFLh = P_0.axGtmJYqDUNOXzKFaqjAsfyFTFLh;
			}
			for (int i = 0; i < P_0.NMSVlGWsvlskcPJjReOxCYGOwDgy.Count; i++)
			{
				NMSVlGWsvlskcPJjReOxCYGOwDgy.Add(new xICXKspPevpDhbNRaliBehhUoYlM(P_0.NMSVlGWsvlskcPJjReOxCYGOwDgy[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = nCKqMlkuksuSUZCXSRAtjGxEAbPiA((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!FJOFIoSUGvTCkVrkAHfbjUxVLhtg(val))
				{
					NMSVlGWsvlskcPJjReOxCYGOwDgy.Add(new xICXKspPevpDhbNRaliBehhUoYlM(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = nCKqMlkuksuSUZCXSRAtjGxEAbPiA((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = NMSVlGWsvlskcPJjReOxCYGOwDgy.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(NMSVlGWsvlskcPJjReOxCYGOwDgy[num].pHfCzModmeQixNuNEoGLxzAFgodW, (T)(object)list[i]))
					{
						NMSVlGWsvlskcPJjReOxCYGOwDgy.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = NMSVlGWsvlskcPJjReOxCYGOwDgy.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = wZSdtsaiEHMyookTbEzinRSMwxRC(obj, (Delegate)(object)NMSVlGWsvlskcPJjReOxCYGOwDgy[num].pHfCzModmeQixNuNEoGLxzAFgodW);
				if (jAYhntgQRzcgIPMEzZOKlbepnsCEb(obj2) == 0)
				{
					NMSVlGWsvlskcPJjReOxCYGOwDgy.RemoveAt(num);
				}
				else
				{
					NMSVlGWsvlskcPJjReOxCYGOwDgy[num] = new xICXKspPevpDhbNRaliBehhUoYlM((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			NMSVlGWsvlskcPJjReOxCYGOwDgy.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = NMSVlGWsvlskcPJjReOxCYGOwDgy.Count;
			if (count == 0)
			{
				return;
			}
			VsSGQwlXRGpGEInJXZunngzpdeS.Clear();
			for (int i = 0; i < count; i++)
			{
				VsSGQwlXRGpGEInJXZunngzpdeS.Add(NMSVlGWsvlskcPJjReOxCYGOwDgy[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				xICXKspPevpDhbNRaliBehhUoYlM xICXKspPevpDhbNRaliBehhUoYlM2 = VsSGQwlXRGpGEInJXZunngzpdeS[j];
				if (xICXKspPevpDhbNRaliBehhUoYlM2.dbxPecpMGwgpdtfRrumaAyudQkCt && xICXKspPevpDhbNRaliBehhUoYlM2.DibLTClMdbLiDqOJdPerohzVLuwr())
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
					invokeCallback(this, xICXKspPevpDhbNRaliBehhUoYlM2.pHfCzModmeQixNuNEoGLxzAFgodW);
				}
				catch (Exception ex)
				{
					if (axGtmJYqDUNOXzKFaqjAsfyFTFLh != null)
					{
						axGtmJYqDUNOXzKFaqjAsfyFTFLh(ex);
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
					NMSVlGWsvlskcPJjReOxCYGOwDgy.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				VsSGQwlXRGpGEInJXZunngzpdeS.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (NMSVlGWsvlskcPJjReOxCYGOwDgy == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < NMSVlGWsvlskcPJjReOxCYGOwDgy.Count; i++)
			{
				T pHfCzModmeQixNuNEoGLxzAFgodW = NMSVlGWsvlskcPJjReOxCYGOwDgy[i].pHfCzModmeQixNuNEoGLxzAFgodW;
				if (val == null)
				{
					val = pHfCzModmeQixNuNEoGLxzAFgodW;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)pHfCzModmeQixNuNEoGLxzAFgodW);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool FJOFIoSUGvTCkVrkAHfbjUxVLhtg(T P_0)
		{
			return KEMfqFGAigtRtDqRnSmRHkoWrfCA(P_0) >= 0;
		}

		private int KEMfqFGAigtRtDqRnSmRHkoWrfCA(T P_0)
		{
			int count = NMSVlGWsvlskcPJjReOxCYGOwDgy.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(NMSVlGWsvlskcPJjReOxCYGOwDgy[i].pHfCzModmeQixNuNEoGLxzAFgodW, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate wZSdtsaiEHMyookTbEzinRSMwxRC(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return fGycJhNdMMQtucJkVstWsMhZOGTR((Delegate)P_0, P_1);
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

		private static Delegate fGycJhNdMMQtucJkVstWsMhZOGTR(Delegate P_0, Delegate P_1)
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

		private static int jAYhntgQRzcgIPMEzZOKlbepnsCEb(Delegate P_0)
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

		private static List<Delegate> nCKqMlkuksuSUZCXSRAtjGxEAbPiA(Delegate P_0)
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
