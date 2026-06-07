using System;
using System.Collections.Generic;

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
			}

			public cTlcOwMwFvmteeovYQwkEggIctAt(cTlcOwMwFvmteeovYQwkEggIctAt P_0)
			{
			}

			public bool KcYXICCEQfESIbhoXQGYEcGJLXjB()
			{
				return false;
			}
		}

		private Action<Exception> nqlEnNDhyCjbCByshWEdGGtsHciVB;

		private readonly List<cTlcOwMwFvmteeovYQwkEggIctAt> QTbfISdbOrHEtAFVvRcQwAHSigXeA;

		private readonly List<cTlcOwMwFvmteeovYQwkEggIctAt> IaXoUUXpoRDFBBfTtYnBRnfnpAXw;

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

		protected SafeDelegate(Action<Exception> P_0)
		{
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
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

		private bool QWnAFgjxfvzlxYIIsNfUJLsVxeMT(T P_0)
		{
			return false;
		}

		private int PqvohybAhytVSSoIrTkBnSpemSOw(T P_0)
		{
			return 0;
		}

		private static Delegate nelJhaRkhPyaljvbRpiNVVEWIJwv(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate qVHzFbimvASVzvXWlrPdOMeLpfiy(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int kgvjyhlUudQQPZXqBaqvDntdFqvi(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> uWbQEtVRkuuPZWlvmcdCLqGCUniD(Delegate P_0)
		{
			return null;
		}
	}
}
