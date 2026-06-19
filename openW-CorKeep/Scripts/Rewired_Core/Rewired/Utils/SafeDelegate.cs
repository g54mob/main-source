using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> VeldrWfWCyaQkVmAuVqgRRZIONWbb;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return VeldrWfWCyaQkVmAuVqgRRZIONWbb;
			}
			set
			{
				VeldrWfWCyaQkVmAuVqgRRZIONWbb = value;
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
		private class cTlcOwMwFvmteeovYQwkEggIctAt
		{
			public readonly T yzIzpIVZXcgKmWobiBqoBJPNnLIpA;

			public readonly object ebAAyCGOAIQzxbqpzSHckqBYQwRf;

			public readonly object PSkaBaHKGjItYlkzsYedFTojKZVN;

			public readonly bool gkQcBeYxqqRZgglkLWOJufmjNNvC;

			public cTlcOwMwFvmteeovYQwkEggIctAt(T P_0)
			{
				yzIzpIVZXcgKmWobiBqoBJPNnLIpA = P_0;
				ebAAyCGOAIQzxbqpzSHckqBYQwRf = ((Delegate)(object)P_0).Target;
				try
				{
					PSkaBaHKGjItYlkzsYedFTojKZVN = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					PSkaBaHKGjItYlkzsYedFTojKZVN = null;
				}
				gkQcBeYxqqRZgglkLWOJufmjNNvC = ebAAyCGOAIQzxbqpzSHckqBYQwRf != null && ebAAyCGOAIQzxbqpzSHckqBYQwRf is UnityEngine.Object;
			}

			public cTlcOwMwFvmteeovYQwkEggIctAt(cTlcOwMwFvmteeovYQwkEggIctAt P_0)
				: this(MiscTools.Clone((object)P_0.yzIzpIVZXcgKmWobiBqoBJPNnLIpA) as T)
			{
			}

			public bool KcYXICCEQfESIbhoXQGYEcGJLXjB()
			{
				if (ebAAyCGOAIQzxbqpzSHckqBYQwRf != null)
				{
					if (ebAAyCGOAIQzxbqpzSHckqBYQwRf is UnityEngine.Object)
					{
						return (UnityEngine.Object)ebAAyCGOAIQzxbqpzSHckqBYQwRf == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> nqlEnNDhyCjbCByshWEdGGtsHciVB;

		private readonly List<cTlcOwMwFvmteeovYQwkEggIctAt> QTbfISdbOrHEtAFVvRcQwAHSigXeA;

		private readonly List<cTlcOwMwFvmteeovYQwkEggIctAt> IaXoUUXpoRDFBBfTtYnBRnfnpAXw;

		int SafeDelegate.Count => QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return nqlEnNDhyCjbCByshWEdGGtsHciVB;
			}
			set
			{
				nqlEnNDhyCjbCByshWEdGGtsHciVB = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			QTbfISdbOrHEtAFVvRcQwAHSigXeA = new List<cTlcOwMwFvmteeovYQwkEggIctAt>();
			IaXoUUXpoRDFBBfTtYnBRnfnpAXw = new List<cTlcOwMwFvmteeovYQwkEggIctAt>();
			if (nqlEnNDhyCjbCByshWEdGGtsHciVB == null)
			{
				nqlEnNDhyCjbCByshWEdGGtsHciVB = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			nqlEnNDhyCjbCByshWEdGGtsHciVB = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.nqlEnNDhyCjbCByshWEdGGtsHciVB != null)
			{
				nqlEnNDhyCjbCByshWEdGGtsHciVB = P_0.nqlEnNDhyCjbCByshWEdGGtsHciVB;
			}
			for (int i = 0; i < P_0.QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count; i++)
			{
				QTbfISdbOrHEtAFVvRcQwAHSigXeA.Add(new cTlcOwMwFvmteeovYQwkEggIctAt(P_0.QTbfISdbOrHEtAFVvRcQwAHSigXeA[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = uWbQEtVRkuuPZWlvmcdCLqGCUniD((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!QWnAFgjxfvzlxYIIsNfUJLsVxeMT(val))
				{
					QTbfISdbOrHEtAFVvRcQwAHSigXeA.Add(new cTlcOwMwFvmteeovYQwkEggIctAt(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = uWbQEtVRkuuPZWlvmcdCLqGCUniD((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(QTbfISdbOrHEtAFVvRcQwAHSigXeA[num].yzIzpIVZXcgKmWobiBqoBJPNnLIpA, (T)(object)list[i]))
					{
						QTbfISdbOrHEtAFVvRcQwAHSigXeA.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = nelJhaRkhPyaljvbRpiNVVEWIJwv(obj, (Delegate)(object)QTbfISdbOrHEtAFVvRcQwAHSigXeA[num].yzIzpIVZXcgKmWobiBqoBJPNnLIpA);
				if (kgvjyhlUudQQPZXqBaqvDntdFqvi(obj2) == 0)
				{
					QTbfISdbOrHEtAFVvRcQwAHSigXeA.RemoveAt(num);
				}
				else
				{
					QTbfISdbOrHEtAFVvRcQwAHSigXeA[num] = new cTlcOwMwFvmteeovYQwkEggIctAt((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			QTbfISdbOrHEtAFVvRcQwAHSigXeA.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count;
			if (count == 0)
			{
				return;
			}
			IaXoUUXpoRDFBBfTtYnBRnfnpAXw.Clear();
			for (int i = 0; i < count; i++)
			{
				IaXoUUXpoRDFBBfTtYnBRnfnpAXw.Add(QTbfISdbOrHEtAFVvRcQwAHSigXeA[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				cTlcOwMwFvmteeovYQwkEggIctAt cTlcOwMwFvmteeovYQwkEggIctAt2 = IaXoUUXpoRDFBBfTtYnBRnfnpAXw[j];
				if (cTlcOwMwFvmteeovYQwkEggIctAt2.gkQcBeYxqqRZgglkLWOJufmjNNvC && cTlcOwMwFvmteeovYQwkEggIctAt2.KcYXICCEQfESIbhoXQGYEcGJLXjB())
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
					invokeCallback(this, cTlcOwMwFvmteeovYQwkEggIctAt2.yzIzpIVZXcgKmWobiBqoBJPNnLIpA);
				}
				catch (Exception ex)
				{
					if (nqlEnNDhyCjbCByshWEdGGtsHciVB != null)
					{
						nqlEnNDhyCjbCByshWEdGGtsHciVB(ex);
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
					QTbfISdbOrHEtAFVvRcQwAHSigXeA.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				IaXoUUXpoRDFBBfTtYnBRnfnpAXw.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (QTbfISdbOrHEtAFVvRcQwAHSigXeA == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count; i++)
			{
				T yzIzpIVZXcgKmWobiBqoBJPNnLIpA = QTbfISdbOrHEtAFVvRcQwAHSigXeA[i].yzIzpIVZXcgKmWobiBqoBJPNnLIpA;
				if (val == null)
				{
					val = yzIzpIVZXcgKmWobiBqoBJPNnLIpA;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)yzIzpIVZXcgKmWobiBqoBJPNnLIpA);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool QWnAFgjxfvzlxYIIsNfUJLsVxeMT(T P_0)
		{
			return PqvohybAhytVSSoIrTkBnSpemSOw(P_0) >= 0;
		}

		private int PqvohybAhytVSSoIrTkBnSpemSOw(T P_0)
		{
			int count = QTbfISdbOrHEtAFVvRcQwAHSigXeA.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(QTbfISdbOrHEtAFVvRcQwAHSigXeA[i].yzIzpIVZXcgKmWobiBqoBJPNnLIpA, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate nelJhaRkhPyaljvbRpiNVVEWIJwv(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return qVHzFbimvASVzvXWlrPdOMeLpfiy((Delegate)P_0, P_1);
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

		private static Delegate qVHzFbimvASVzvXWlrPdOMeLpfiy(Delegate P_0, Delegate P_1)
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

		private static int kgvjyhlUudQQPZXqBaqvDntdFqvi(Delegate P_0)
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

		private static List<Delegate> uWbQEtVRkuuPZWlvmcdCLqGCUniD(Delegate P_0)
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
