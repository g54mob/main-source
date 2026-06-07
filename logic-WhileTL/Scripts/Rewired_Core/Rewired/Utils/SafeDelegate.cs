using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> iGqKHEPBpzLEgDdxwWZeuomWNBUv;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return iGqKHEPBpzLEgDdxwWZeuomWNBUv;
			}
			set
			{
				iGqKHEPBpzLEgDdxwWZeuomWNBUv = value;
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
		private class GZTDGLczEBVjCElkAGNkLJBEOrToA
		{
			public readonly T tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

			public readonly object LNFmGxqdskDZYydfYKbBBRoonLzv;

			public readonly object PGKCTVFQxTZQgiwlldvAtHsWXvygA;

			public readonly bool UNSfTOmIAQREyfiWMtECJrzWtVcB;

			public GZTDGLczEBVjCElkAGNkLJBEOrToA(T P_0)
			{
				tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
				LNFmGxqdskDZYydfYKbBBRoonLzv = ((Delegate)(object)P_0).Target;
				try
				{
					PGKCTVFQxTZQgiwlldvAtHsWXvygA = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					PGKCTVFQxTZQgiwlldvAtHsWXvygA = null;
				}
				UNSfTOmIAQREyfiWMtECJrzWtVcB = LNFmGxqdskDZYydfYKbBBRoonLzv != null && LNFmGxqdskDZYydfYKbBBRoonLzv is UnityEngine.Object;
			}

			public GZTDGLczEBVjCElkAGNkLJBEOrToA(GZTDGLczEBVjCElkAGNkLJBEOrToA P_0)
				: this(MiscTools.Clone((object)P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb) as T)
			{
			}

			public bool OmZAClDaLlQJvguEIishHvDuguvzA()
			{
				if (LNFmGxqdskDZYydfYKbBBRoonLzv != null)
				{
					if (LNFmGxqdskDZYydfYKbBBRoonLzv is UnityEngine.Object)
					{
						return (UnityEngine.Object)LNFmGxqdskDZYydfYKbBBRoonLzv == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> TPYtQEvkMtQtfnkGxqJkOYenOlzO;

		private readonly List<GZTDGLczEBVjCElkAGNkLJBEOrToA> lECctcBXtRpkaiLQYdfJgrLEfyTeB;

		private readonly List<GZTDGLczEBVjCElkAGNkLJBEOrToA> gQLaiGthDwGBfIcbaexnsLGkTnZWA;

		internal override int Count => lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return TPYtQEvkMtQtfnkGxqJkOYenOlzO;
			}
			set
			{
				TPYtQEvkMtQtfnkGxqJkOYenOlzO = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			lECctcBXtRpkaiLQYdfJgrLEfyTeB = new List<GZTDGLczEBVjCElkAGNkLJBEOrToA>();
			gQLaiGthDwGBfIcbaexnsLGkTnZWA = new List<GZTDGLczEBVjCElkAGNkLJBEOrToA>();
			if (TPYtQEvkMtQtfnkGxqJkOYenOlzO == null)
			{
				TPYtQEvkMtQtfnkGxqJkOYenOlzO = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			TPYtQEvkMtQtfnkGxqJkOYenOlzO = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.TPYtQEvkMtQtfnkGxqJkOYenOlzO != null)
			{
				TPYtQEvkMtQtfnkGxqJkOYenOlzO = P_0.TPYtQEvkMtQtfnkGxqJkOYenOlzO;
			}
			for (int i = 0; i < P_0.lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count; i++)
			{
				lECctcBXtRpkaiLQYdfJgrLEfyTeB.Add(new GZTDGLczEBVjCElkAGNkLJBEOrToA(P_0.lECctcBXtRpkaiLQYdfJgrLEfyTeB[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = PSQMvlwFvjceFTscaZBeHBbPyvod((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!kUiCmZCewQfczGBdspnXBabLzrLy(val))
				{
					lECctcBXtRpkaiLQYdfJgrLEfyTeB.Add(new GZTDGLczEBVjCElkAGNkLJBEOrToA(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = PSQMvlwFvjceFTscaZBeHBbPyvod((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(lECctcBXtRpkaiLQYdfJgrLEfyTeB[num].tMUcuAfGGoFbaZBeDMMyJYJtxaOb, (T)(object)list[i]))
					{
						lECctcBXtRpkaiLQYdfJgrLEfyTeB.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = PyAhsHbUDOwcaTylaMjFjjwiRBvjA(obj, (Delegate)(object)lECctcBXtRpkaiLQYdfJgrLEfyTeB[num].tMUcuAfGGoFbaZBeDMMyJYJtxaOb);
				if (NgeyzLDdTtXXKVNzTKhSWYwKgLSw(obj2) == 0)
				{
					lECctcBXtRpkaiLQYdfJgrLEfyTeB.RemoveAt(num);
				}
				else
				{
					lECctcBXtRpkaiLQYdfJgrLEfyTeB[num] = new GZTDGLczEBVjCElkAGNkLJBEOrToA((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			lECctcBXtRpkaiLQYdfJgrLEfyTeB.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count;
			if (count == 0)
			{
				return;
			}
			gQLaiGthDwGBfIcbaexnsLGkTnZWA.Clear();
			for (int i = 0; i < count; i++)
			{
				gQLaiGthDwGBfIcbaexnsLGkTnZWA.Add(lECctcBXtRpkaiLQYdfJgrLEfyTeB[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				GZTDGLczEBVjCElkAGNkLJBEOrToA gZTDGLczEBVjCElkAGNkLJBEOrToA = gQLaiGthDwGBfIcbaexnsLGkTnZWA[j];
				if (gZTDGLczEBVjCElkAGNkLJBEOrToA.UNSfTOmIAQREyfiWMtECJrzWtVcB && gZTDGLczEBVjCElkAGNkLJBEOrToA.OmZAClDaLlQJvguEIishHvDuguvzA())
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
					invokeCallback(this, gZTDGLczEBVjCElkAGNkLJBEOrToA.tMUcuAfGGoFbaZBeDMMyJYJtxaOb);
				}
				catch (Exception ex)
				{
					if (TPYtQEvkMtQtfnkGxqJkOYenOlzO != null)
					{
						TPYtQEvkMtQtfnkGxqJkOYenOlzO(ex);
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
					lECctcBXtRpkaiLQYdfJgrLEfyTeB.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				gQLaiGthDwGBfIcbaexnsLGkTnZWA.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (lECctcBXtRpkaiLQYdfJgrLEfyTeB == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count; i++)
			{
				T tMUcuAfGGoFbaZBeDMMyJYJtxaOb = lECctcBXtRpkaiLQYdfJgrLEfyTeB[i].tMUcuAfGGoFbaZBeDMMyJYJtxaOb;
				if (val == null)
				{
					val = tMUcuAfGGoFbaZBeDMMyJYJtxaOb;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)tMUcuAfGGoFbaZBeDMMyJYJtxaOb);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool kUiCmZCewQfczGBdspnXBabLzrLy(T P_0)
		{
			return oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_0) >= 0;
		}

		private int oKnsZBCQtgEufGaLOKQQPSmAuaDB(T P_0)
		{
			int count = lECctcBXtRpkaiLQYdfJgrLEfyTeB.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(lECctcBXtRpkaiLQYdfJgrLEfyTeB[i].tMUcuAfGGoFbaZBeDMMyJYJtxaOb, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate PyAhsHbUDOwcaTylaMjFjjwiRBvjA(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return PyAhsHbUDOwcaTylaMjFjjwiRBvjA((Delegate)P_0, P_1);
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

		private static Delegate PyAhsHbUDOwcaTylaMjFjjwiRBvjA(Delegate P_0, Delegate P_1)
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

		private static int NgeyzLDdTtXXKVNzTKhSWYwKgLSw(Delegate P_0)
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

		private static List<Delegate> PSQMvlwFvjceFTscaZBeHBbPyvod(Delegate P_0)
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
