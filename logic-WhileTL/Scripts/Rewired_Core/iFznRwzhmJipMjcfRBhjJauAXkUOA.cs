using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class iFznRwzhmJipMjcfRBhjJauAXkUOA
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum gYZKKIgDAQutNujWygeIsJVHdpADA
		{
			None = 0,
			Self = 1,
			Children = 4,
			Parents = 8,
			All = -1
		}

		private readonly EventFunction<THandler, TValue> tNqNLJQXMCViKpJugIapXBfbbljl;

		private readonly List<THandler> TUzWvWqqZQkGtgJURgxQDhXyddIuA;

		private readonly gYZKKIgDAQutNujWygeIsJVHdpADA RHTnPnfQMfJjQNfDOtxXYDsEbKMu;

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0)
			: this(P_0, gYZKKIgDAQutNujWygeIsJVHdpADA.Self | gYZKKIgDAQutNujWygeIsJVHdpADA.Children)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0, gYZKKIgDAQutNujWygeIsJVHdpADA P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("delegate");
			}
			tNqNLJQXMCViKpJugIapXBfbbljl = P_0;
			TUzWvWqqZQkGtgJURgxQDhXyddIuA = new List<THandler>();
			RHTnPnfQMfJjQNfDOtxXYDsEbKMu = P_1;
		}

		public void ExecuteOnAll(TValue value)
		{
			UzdQgmCiJqoJoIfcBjMmkuzTbQXJA(TUzWvWqqZQkGtgJURgxQDhXyddIuA, value, tNqNLJQXMCViKpJugIapXBfbbljl, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((RHTnPnfQMfJjQNfDOtxXYDsEbKMu & gYZKKIgDAQutNujWygeIsJVHdpADA.Self) != gYZKKIgDAQutNujWygeIsJVHdpADA.None && (RHTnPnfQMfJjQNfDOtxXYDsEbKMu & gYZKKIgDAQutNujWygeIsJVHdpADA.Children) != gYZKKIgDAQutNujWygeIsJVHdpADA.None && (RHTnPnfQMfJjQNfDOtxXYDsEbKMu & gYZKKIgDAQutNujWygeIsJVHdpADA.Parents) != gYZKKIgDAQutNujWygeIsJVHdpADA.None)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.root, TUzWvWqqZQkGtgJURgxQDhXyddIuA, append: false);
				return;
			}
			if ((RHTnPnfQMfJjQNfDOtxXYDsEbKMu & gYZKKIgDAQutNujWygeIsJVHdpADA.Children) != gYZKKIgDAQutNujWygeIsJVHdpADA.None)
			{
				if ((RHTnPnfQMfJjQNfDOtxXYDsEbKMu & gYZKKIgDAQutNujWygeIsJVHdpADA.Self) != gYZKKIgDAQutNujWygeIsJVHdpADA.None)
				{
					UnityTools.GetComponentsInSelfAndChildren(transform, TUzWvWqqZQkGtgJURgxQDhXyddIuA, append: true);
				}
				else
				{
					UnityTools.GetComponents(transform, TUzWvWqqZQkGtgJURgxQDhXyddIuA, append: true);
				}
			}
			if ((RHTnPnfQMfJjQNfDOtxXYDsEbKMu & gYZKKIgDAQutNujWygeIsJVHdpADA.Parents) != gYZKKIgDAQutNujWygeIsJVHdpADA.None)
			{
				UnityTools.GetComponentsInParents(transform, TUzWvWqqZQkGtgJURgxQDhXyddIuA, append: true);
			}
		}
	}

	public static void rnYWqnyinEgpdPPvyOIBALYfHbVH<_0001, _0002>(_0001 P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
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

	public static void rnYWqnyinEgpdPPvyOIBALYfHbVH<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
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

	public static void UzdQgmCiJqoJoIfcBjMmkuzTbQXJA<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2, bool P_3) where _0001 : class
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
