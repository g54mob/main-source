using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> PYeyHxlCnlmFvvgfYUQrvxmpAVjg;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return PYeyHxlCnlmFvvgfYUQrvxmpAVjg;
			}
			set
			{
				PYeyHxlCnlmFvvgfYUQrvxmpAVjg = value;
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
		private class gJmnDVjQaaTFzrfUcjctyHFnHezZ
		{
			public readonly T cBVwdatwdPkpVKACrAbhPsgvAbX;

			public readonly object adBiPxfChZyswsFIXTyfCHsdrJyT;

			public readonly object RplNUZkblacRHewSCYKyepZOIEagb;

			public readonly bool aWVuvNrJGxAvddtAfVqYAYOGjYEqA;

			public gJmnDVjQaaTFzrfUcjctyHFnHezZ(T P_0)
			{
				cBVwdatwdPkpVKACrAbhPsgvAbX = P_0;
				adBiPxfChZyswsFIXTyfCHsdrJyT = ((Delegate)(object)P_0).Target;
				try
				{
					RplNUZkblacRHewSCYKyepZOIEagb = ReflectionTools.GetMethodInfo((Delegate)(object)P_0);
				}
				catch
				{
					RplNUZkblacRHewSCYKyepZOIEagb = null;
				}
				aWVuvNrJGxAvddtAfVqYAYOGjYEqA = adBiPxfChZyswsFIXTyfCHsdrJyT != null && adBiPxfChZyswsFIXTyfCHsdrJyT is UnityEngine.Object;
			}

			public gJmnDVjQaaTFzrfUcjctyHFnHezZ(gJmnDVjQaaTFzrfUcjctyHFnHezZ P_0)
				: this(MiscTools.Clone((object)P_0.cBVwdatwdPkpVKACrAbhPsgvAbX) as T)
			{
			}

			public bool WeBZUpdaliwkLqgEvRiPumRsCGkHA()
			{
				if (adBiPxfChZyswsFIXTyfCHsdrJyT != null)
				{
					if (adBiPxfChZyswsFIXTyfCHsdrJyT is UnityEngine.Object)
					{
						return (UnityEngine.Object)adBiPxfChZyswsFIXTyfCHsdrJyT == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> rumaQmGLWZVIFpTrwytyyCwsxrJd;

		private readonly List<gJmnDVjQaaTFzrfUcjctyHFnHezZ> SourchIqfkQssPoeZGUHKkipCvix;

		private readonly List<gJmnDVjQaaTFzrfUcjctyHFnHezZ> WHQdHnwFRGZrSIvwLIFWbJIQKPip;

		int SafeDelegate.Count => SourchIqfkQssPoeZGUHKkipCvix.Count;

		Action<Exception> SafeDelegate.ExceptionHandler
		{
			get
			{
				return rumaQmGLWZVIFpTrwytyyCwsxrJd;
			}
			set
			{
				rumaQmGLWZVIFpTrwytyyCwsxrJd = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			SourchIqfkQssPoeZGUHKkipCvix = new List<gJmnDVjQaaTFzrfUcjctyHFnHezZ>();
			WHQdHnwFRGZrSIvwLIFWbJIQKPip = new List<gJmnDVjQaaTFzrfUcjctyHFnHezZ>();
			if (rumaQmGLWZVIFpTrwytyyCwsxrJd == null)
			{
				rumaQmGLWZVIFpTrwytyyCwsxrJd = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			rumaQmGLWZVIFpTrwytyyCwsxrJd = P_0;
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_0.rumaQmGLWZVIFpTrwytyyCwsxrJd != null)
			{
				rumaQmGLWZVIFpTrwytyyCwsxrJd = P_0.rumaQmGLWZVIFpTrwytyyCwsxrJd;
			}
			for (int i = 0; i < P_0.SourchIqfkQssPoeZGUHKkipCvix.Count; i++)
			{
				SourchIqfkQssPoeZGUHKkipCvix.Add(new gJmnDVjQaaTFzrfUcjctyHFnHezZ(P_0.SourchIqfkQssPoeZGUHKkipCvix[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = qEiUJSixqncASLPMCsGBzdXvtLXR((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				T val = (T)(object)list[i];
				if (!SlcAVRYGCmNuqFVvAFBZlIVedItH(val))
				{
					SourchIqfkQssPoeZGUHKkipCvix.Add(new gJmnDVjQaaTFzrfUcjctyHFnHezZ(val));
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			List<Delegate> list = qEiUJSixqncASLPMCsGBzdXvtLXR((Delegate)(object)@delegate);
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = SourchIqfkQssPoeZGUHKkipCvix.Count;
			for (int i = 0; i < list.Count; i++)
			{
				for (int num = count - 1; num >= 0; num--)
				{
					if (EqualityComparer<T>.Default.Equals(SourchIqfkQssPoeZGUHKkipCvix[num].cBVwdatwdPkpVKACrAbhPsgvAbX, (T)(object)list[i]))
					{
						SourchIqfkQssPoeZGUHKkipCvix.RemoveAt(num);
					}
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			for (int num = SourchIqfkQssPoeZGUHKkipCvix.Count - 1; num >= 0; num--)
			{
				Delegate obj2 = pEoggNeWAAQbesCAlEQYdBzpxWDN(obj, (Delegate)(object)SourchIqfkQssPoeZGUHKkipCvix[num].cBVwdatwdPkpVKACrAbhPsgvAbX);
				if (wauikASwDsbiKQNLvsMavcQCYMEU(obj2) == 0)
				{
					SourchIqfkQssPoeZGUHKkipCvix.RemoveAt(num);
				}
				else
				{
					SourchIqfkQssPoeZGUHKkipCvix[num] = new gJmnDVjQaaTFzrfUcjctyHFnHezZ((T)(object)obj2);
				}
			}
		}

		internal override void Clear()
		{
			SourchIqfkQssPoeZGUHKkipCvix.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			int count = SourchIqfkQssPoeZGUHKkipCvix.Count;
			if (count == 0)
			{
				return;
			}
			WHQdHnwFRGZrSIvwLIFWbJIQKPip.Clear();
			for (int i = 0; i < count; i++)
			{
				WHQdHnwFRGZrSIvwLIFWbJIQKPip.Add(SourchIqfkQssPoeZGUHKkipCvix[i]);
			}
			List<int> list = null;
			for (int j = 0; j < count; j++)
			{
				gJmnDVjQaaTFzrfUcjctyHFnHezZ gJmnDVjQaaTFzrfUcjctyHFnHezZ2 = WHQdHnwFRGZrSIvwLIFWbJIQKPip[j];
				if (gJmnDVjQaaTFzrfUcjctyHFnHezZ2.aWVuvNrJGxAvddtAfVqYAYOGjYEqA && gJmnDVjQaaTFzrfUcjctyHFnHezZ2.WeBZUpdaliwkLqgEvRiPumRsCGkHA())
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
					invokeCallback(this, gJmnDVjQaaTFzrfUcjctyHFnHezZ2.cBVwdatwdPkpVKACrAbhPsgvAbX);
				}
				catch (Exception ex)
				{
					if (rumaQmGLWZVIFpTrwytyyCwsxrJd != null)
					{
						rumaQmGLWZVIFpTrwytyyCwsxrJd(ex);
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
					SourchIqfkQssPoeZGUHKkipCvix.RemoveAt(list[num]);
				}
				TempListPool.Return(list);
			}
			if (count > 0)
			{
				WHQdHnwFRGZrSIvwLIFWbJIQKPip.Clear();
			}
		}

		protected T GetCombinedDelegate()
		{
			if (SourchIqfkQssPoeZGUHKkipCvix == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < SourchIqfkQssPoeZGUHKkipCvix.Count; i++)
			{
				T cBVwdatwdPkpVKACrAbhPsgvAbX = SourchIqfkQssPoeZGUHKkipCvix[i].cBVwdatwdPkpVKACrAbhPsgvAbX;
				if (val == null)
				{
					val = cBVwdatwdPkpVKACrAbhPsgvAbX;
					continue;
				}
				try
				{
					val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)cBVwdatwdPkpVKACrAbhPsgvAbX);
				}
				catch
				{
				}
			}
			return val;
		}

		private bool SlcAVRYGCmNuqFVvAFBZlIVedItH(T P_0)
		{
			return TuuAoNWPYzJvXFFjFCAEJxIVCFfeA(P_0) >= 0;
		}

		private int TuuAoNWPYzJvXFFjFCAEJxIVCFfeA(T P_0)
		{
			int count = SourchIqfkQssPoeZGUHKkipCvix.Count;
			for (int i = 0; i < count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(SourchIqfkQssPoeZGUHKkipCvix[i].cBVwdatwdPkpVKACrAbhPsgvAbX, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		private static Delegate pEoggNeWAAQbesCAlEQYdBzpxWDN(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return uKBMGTfUBczaewjTbveKaDkUqPdA((Delegate)P_0, P_1);
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

		private static Delegate uKBMGTfUBczaewjTbveKaDkUqPdA(Delegate P_0, Delegate P_1)
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

		private static int wauikASwDsbiKQNLvsMavcQCYMEU(Delegate P_0)
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

		private static List<Delegate> qEiUJSixqncASLPMCsGBzdXvtLXR(Delegate P_0)
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
