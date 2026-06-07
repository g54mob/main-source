using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class YVQfKeazIqgFlQlVhbEkyBsluncmA
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum WiPBsxbVFKiUhTNXgwQUIDfAathfA
		{
			None = 0,
			Self = 1,
			Children = 4,
			Parents = 8,
			All = -1
		}

		private readonly EventFunction<THandler, TValue> kIFukHGfMFGEXbaiateJwwZmLJjKA;

		private readonly List<THandler> xsChhoDkyhMaFAQlRHIgevciLFcrA;

		private readonly WiPBsxbVFKiUhTNXgwQUIDfAathfA sAqWAPiHsYDXDXDGSWeDPCCJFbUX;

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0)
			: this(P_0, WiPBsxbVFKiUhTNXgwQUIDfAathfA.Self | WiPBsxbVFKiUhTNXgwQUIDfAathfA.Children)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0, WiPBsxbVFKiUhTNXgwQUIDfAathfA P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("delegate");
			}
			kIFukHGfMFGEXbaiateJwwZmLJjKA = P_0;
			xsChhoDkyhMaFAQlRHIgevciLFcrA = new List<THandler>();
			sAqWAPiHsYDXDXDGSWeDPCCJFbUX = P_1;
		}

		public void ExecuteOnAll(TValue value)
		{
			lLxOSNKLWvcGQNYwuHKsallqsjTX(xsChhoDkyhMaFAQlRHIgevciLFcrA, value, kIFukHGfMFGEXbaiateJwwZmLJjKA, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((sAqWAPiHsYDXDXDGSWeDPCCJFbUX & WiPBsxbVFKiUhTNXgwQUIDfAathfA.Self) != WiPBsxbVFKiUhTNXgwQUIDfAathfA.None && (sAqWAPiHsYDXDXDGSWeDPCCJFbUX & WiPBsxbVFKiUhTNXgwQUIDfAathfA.Children) != WiPBsxbVFKiUhTNXgwQUIDfAathfA.None && (sAqWAPiHsYDXDXDGSWeDPCCJFbUX & WiPBsxbVFKiUhTNXgwQUIDfAathfA.Parents) != WiPBsxbVFKiUhTNXgwQUIDfAathfA.None)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.root, xsChhoDkyhMaFAQlRHIgevciLFcrA, append: false);
				return;
			}
			if ((sAqWAPiHsYDXDXDGSWeDPCCJFbUX & WiPBsxbVFKiUhTNXgwQUIDfAathfA.Children) != WiPBsxbVFKiUhTNXgwQUIDfAathfA.None)
			{
				if ((sAqWAPiHsYDXDXDGSWeDPCCJFbUX & WiPBsxbVFKiUhTNXgwQUIDfAathfA.Self) != WiPBsxbVFKiUhTNXgwQUIDfAathfA.None)
				{
					UnityTools.GetComponentsInSelfAndChildren(transform, xsChhoDkyhMaFAQlRHIgevciLFcrA, append: true);
				}
				else
				{
					UnityTools.GetComponents(transform, xsChhoDkyhMaFAQlRHIgevciLFcrA, append: true);
				}
			}
			if ((sAqWAPiHsYDXDXDGSWeDPCCJFbUX & WiPBsxbVFKiUhTNXgwQUIDfAathfA.Parents) != WiPBsxbVFKiUhTNXgwQUIDfAathfA.None)
			{
				UnityTools.GetComponentsInParents(transform, xsChhoDkyhMaFAQlRHIgevciLFcrA, append: true);
			}
		}
	}

	public static void rtKNCgbGHZQMJoETvgDbnCJkyskW<_0001, _0002>(_0001 P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		try
		{
			P_2(P_0, P_1);
		}
		catch (Exception ex)
		{
			Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
		}
	}

	public static void XMRwTZiMzuQNYHklipHumArHnHpi<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handlers");
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null)
			{
				try
				{
					P_2(val, P_1);
				}
				catch (Exception ex)
				{
					Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
				}
			}
		}
	}

	public static void lLxOSNKLWvcGQNYwuHKsallqsjTX<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2, bool P_3) where _0001 : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handlers");
		}
		int num = P_0.Count;
		for (int i = 0; i < num; i++)
		{
			_0001 val = P_0[i];
			if (val as Component == null)
			{
				if (P_3)
				{
					P_0.RemoveAt(i);
					i--;
					num--;
				}
			}
			else
			{
				try
				{
					P_2(val, P_1);
				}
				catch (Exception ex)
				{
					Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
				}
			}
		}
	}
}
