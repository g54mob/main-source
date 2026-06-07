using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> VADXHfVJioweJPuIokdEhhvfHuaP;

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
		private class kwPseNRlbdMFBDbvAeGYcyUzaCwSA
		{
			public readonly T qTcFChCdMuwLZtnBikeKjzPicEed;

			public readonly object yAeKmhByiGtgUELhnLSCQIvtWfro;

			public readonly object DwQNxJKVqhvHbOKvaUiFhtSGhcln;

			public readonly bool ypozSDHQLuHpFfTxFwKxgORWOgZMA;

			public kwPseNRlbdMFBDbvAeGYcyUzaCwSA(T P_0)
			{
			}

			public kwPseNRlbdMFBDbvAeGYcyUzaCwSA(kwPseNRlbdMFBDbvAeGYcyUzaCwSA P_0)
			{
			}

			public bool CHwWxxDEkdocfUZbJvEqaLWmKebN()
			{
				return false;
			}
		}

		private Action<Exception> vKDFpuoSrYBGjJamKOLBoHTwZxMD;

		private readonly List<kwPseNRlbdMFBDbvAeGYcyUzaCwSA> KWFMFzsjyjTqKztBvmoeEftrEDjCA;

		private readonly List<kwPseNRlbdMFBDbvAeGYcyUzaCwSA> CarAivIKOFCraiTXtexfFlPAkfpjb;

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

		private bool CTFtWLgRyxBgSdAkenRyrEsgPruE(T P_0)
		{
			return false;
		}

		private int HNPARFqKDatjvroQhAwdTrFJntcw(T P_0)
		{
			return 0;
		}

		private static Delegate jBPVsFErBLQmKCjzZkXrnPelcnEK(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate cSjvCEbDMMhLSWSTpVhByKisOASC(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int ujRKJIsAElWuecSiPnsPxmFWgaLN(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> cCFciQCKfyFGsDvbBksyRdQhvxAYA(Delegate P_0)
		{
			return null;
		}
	}
}
