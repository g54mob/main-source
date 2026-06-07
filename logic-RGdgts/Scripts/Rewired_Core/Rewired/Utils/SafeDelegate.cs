using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> iGqKHEPBpzLEgDdxwWZeuomWNBUv;

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
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class GZTDGLczEBVjCElkAGNkLJBEOrToA
		{
			public readonly T tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

			public readonly object LNFmGxqdskDZYydfYKbBBRoonLzv;

			public readonly object PGKCTVFQxTZQgiwlldvAtHsWXvygA;

			public readonly bool UNSfTOmIAQREyfiWMtECJrzWtVcB;

			public GZTDGLczEBVjCElkAGNkLJBEOrToA(T P_0)
			{
			}

			public GZTDGLczEBVjCElkAGNkLJBEOrToA(GZTDGLczEBVjCElkAGNkLJBEOrToA P_0)
			{
			}

			public bool OmZAClDaLlQJvguEIishHvDuguvzA()
			{
				return false;
			}
		}

		private Action<Exception> TPYtQEvkMtQtfnkGxqJkOYenOlzO;

		private readonly List<GZTDGLczEBVjCElkAGNkLJBEOrToA> lECctcBXtRpkaiLQYdfJgrLEfyTeB;

		private readonly List<GZTDGLczEBVjCElkAGNkLJBEOrToA> gQLaiGthDwGBfIcbaexnsLGkTnZWA;

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

		private bool kUiCmZCewQfczGBdspnXBabLzrLy(T P_0)
		{
			return false;
		}

		private int oKnsZBCQtgEufGaLOKQQPSmAuaDB(T P_0)
		{
			return 0;
		}

		private static Delegate PyAhsHbUDOwcaTylaMjFjjwiRBvjA(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate PyAhsHbUDOwcaTylaMjFjjwiRBvjA(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int NgeyzLDdTtXXKVNzTKhSWYwKgLSw(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> PSQMvlwFvjceFTscaZBeHBbPyvod(Delegate P_0)
		{
			return null;
		}
	}
}
