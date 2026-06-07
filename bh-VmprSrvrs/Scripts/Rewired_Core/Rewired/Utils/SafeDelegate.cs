using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> LBnYkZaTlPvmRsJBawFzKCpecKsG;

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
		private class cMpFvtiFWCVKFiHqAWKzPvUueCeV
		{
			public readonly T gGKENBlWqVthHQahmuvzCnjxsLse;

			public readonly object afQpxFolNjHzMnFclNUrtMfaizzW;

			public readonly object RncGgbzYREKYhnjmmrguMkOFAyxL;

			public readonly bool cwCBBrEsaZFsPBaqbBCIrnHLHuZgB;

			public cMpFvtiFWCVKFiHqAWKzPvUueCeV(T P_0)
			{
			}

			public cMpFvtiFWCVKFiHqAWKzPvUueCeV(cMpFvtiFWCVKFiHqAWKzPvUueCeV P_0)
			{
			}

			public bool YDYGkZJkDGabhPpaJBYNPPUzOujxA()
			{
				return false;
			}
		}

		private Action<Exception> tnZSMGBthhIjyqrSvIgwLLxpBMxA;

		private readonly List<cMpFvtiFWCVKFiHqAWKzPvUueCeV> SmnkUHDIZMFpOWXGzBkLhvnwiDbab;

		private readonly List<cMpFvtiFWCVKFiHqAWKzPvUueCeV> WFBtfPtHreFwyTvOjwxAOlTFshfx;

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

		private bool SjnmjxRaOQQAKOPiwhWPQYCxXmgD(T P_0)
		{
			return false;
		}

		private int VPfCsnXMeVkBxIwFreOWelTWnIwK(T P_0)
		{
			return 0;
		}

		private static Delegate tBvIstxvywDeSxeqDqSEGVwcqKSG(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate skNuNcMwqdgkQvDnjXhkDArrEsGe(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int yZfnQyRDbCHbuERvFxsoAKTFJaHlA(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> ojzBrwHdIRSRqpAucnwNiAOwatMxA(Delegate P_0)
		{
			return null;
		}
	}
}
