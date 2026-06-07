using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> xXNgKalPSnJQINFxnEUVUulowRZ;

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
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class FPqCndHkoNCgkDtYTeKForFeNGYM
		{
			public readonly T kmrhFEFDaShGTGJfMUBdPlMLPWnH;

			public readonly object QXkxRHWAIexUminBPlmsdpmAaXw;

			public readonly object MKnmhzefXPRhWodPiFazlwuamKx;

			public readonly bool RlvIOrOHeQgOmdiANwsdhMvouEU;

			public FPqCndHkoNCgkDtYTeKForFeNGYM(T item)
			{
			}

			public FPqCndHkoNCgkDtYTeKForFeNGYM(FPqCndHkoNCgkDtYTeKForFeNGYM source)
			{
			}

			public bool JcsdXVOylnAGNwyoXdICJfTCJFc()
			{
				return false;
			}
		}

		private Action<Exception> KhxblaJmqzokNhBuqDQPuxaNNYu;

		private readonly List<FPqCndHkoNCgkDtYTeKForFeNGYM> aIbKgEfyDXtmYNDqRhsyRaXXBXWf;

		private readonly List<FPqCndHkoNCgkDtYTeKForFeNGYM> vMigDqbPludMDmuZdPwIidCMsMIQ;

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

		private bool rQHDjpEgUKClDGGZBneqPdtEvWcW(T P_0)
		{
			return false;
		}

		private int jTSeZjeBekaFMSAMDMPlzbScDBjH(T P_0)
		{
			return 0;
		}

		private static Delegate OAbDThawpOonQmTFpbweRMwAUak(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate OAbDThawpOonQmTFpbweRMwAUak(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int KwFCypzUlrMBcXvHUwrxoCcyenX(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> OqpKbFEplzabCbRSzFQPLjVzgThn(Delegate P_0)
		{
			return null;
		}
	}
}
