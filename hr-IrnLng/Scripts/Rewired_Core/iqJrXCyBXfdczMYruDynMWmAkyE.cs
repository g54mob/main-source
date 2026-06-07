using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class iqJrXCyBXfdczMYruDynMWmAkyE
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum eoqVozKoVpQDHcDRYIryKVUpJfR
		{
			xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
			ZMYAZXfiENPsSzRTvLkQyXchoDP = 1,
			zwEKtzVRLPfgUvGJKidDuMqeCXxA = 4,
			QxOLrkkikqCTNHdmONuqsNQIriLJ = 8,
			HtsblyglEXzTYliwpLPEWwCOpmrI = -1
		}

		private readonly EventFunction<THandler, TValue> jBOHxffZesaYlkIXVcLbSdztwzvs;

		private readonly List<THandler> XRuNmbtiFoFOlLQxiwIuLDhmlIq;

		private readonly eoqVozKoVpQDHcDRYIryKVUpJfR JgnkFFypvBXGlslVdTwDaukYJAW;

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate)
			: this(executeDelegate, eoqVozKoVpQDHcDRYIryKVUpJfR.ZMYAZXfiENPsSzRTvLkQyXchoDP | eoqVozKoVpQDHcDRYIryKVUpJfR.zwEKtzVRLPfgUvGJKidDuMqeCXxA)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate, eoqVozKoVpQDHcDRYIryKVUpJfR executeOn)
		{
			if (executeDelegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			jBOHxffZesaYlkIXVcLbSdztwzvs = executeDelegate;
			XRuNmbtiFoFOlLQxiwIuLDhmlIq = new List<THandler>();
			JgnkFFypvBXGlslVdTwDaukYJAW = executeOn;
		}

		public void ExecuteOnAll(TValue value)
		{
			ESFYiAJakQeWTfBwulHqQtpNvWZ(XRuNmbtiFoFOlLQxiwIuLDhmlIq, value, jBOHxffZesaYlkIXVcLbSdztwzvs, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((JgnkFFypvBXGlslVdTwDaukYJAW & eoqVozKoVpQDHcDRYIryKVUpJfR.ZMYAZXfiENPsSzRTvLkQyXchoDP) != eoqVozKoVpQDHcDRYIryKVUpJfR.xHdBaRgdNDZThJOvnpmpFtvdLIun && (JgnkFFypvBXGlslVdTwDaukYJAW & eoqVozKoVpQDHcDRYIryKVUpJfR.zwEKtzVRLPfgUvGJKidDuMqeCXxA) != eoqVozKoVpQDHcDRYIryKVUpJfR.xHdBaRgdNDZThJOvnpmpFtvdLIun && (JgnkFFypvBXGlslVdTwDaukYJAW & eoqVozKoVpQDHcDRYIryKVUpJfR.QxOLrkkikqCTNHdmONuqsNQIriLJ) != eoqVozKoVpQDHcDRYIryKVUpJfR.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.root, XRuNmbtiFoFOlLQxiwIuLDhmlIq, append: false);
				return;
			}
			if ((JgnkFFypvBXGlslVdTwDaukYJAW & eoqVozKoVpQDHcDRYIryKVUpJfR.zwEKtzVRLPfgUvGJKidDuMqeCXxA) != eoqVozKoVpQDHcDRYIryKVUpJfR.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				if ((JgnkFFypvBXGlslVdTwDaukYJAW & eoqVozKoVpQDHcDRYIryKVUpJfR.ZMYAZXfiENPsSzRTvLkQyXchoDP) != eoqVozKoVpQDHcDRYIryKVUpJfR.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					UnityTools.GetComponentsInSelfAndChildren(transform, XRuNmbtiFoFOlLQxiwIuLDhmlIq, append: true);
				}
				else
				{
					UnityTools.GetComponents(transform, XRuNmbtiFoFOlLQxiwIuLDhmlIq, append: true);
				}
			}
			if ((JgnkFFypvBXGlslVdTwDaukYJAW & eoqVozKoVpQDHcDRYIryKVUpJfR.QxOLrkkikqCTNHdmONuqsNQIriLJ) != eoqVozKoVpQDHcDRYIryKVUpJfR.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				UnityTools.GetComponentsInParents(transform, XRuNmbtiFoFOlLQxiwIuLDhmlIq, append: true);
			}
		}
	}

	public static void bIgByVfNGaBnSdqtBIRNfoKijZPl<T, TArgs>(T P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
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

	public static void bIgByVfNGaBnSdqtBIRNfoKijZPl<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
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
			T val = P_0[i];
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

	public static void ESFYiAJakQeWTfBwulHqQtpNvWZ<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2, bool P_3) where T : class
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
			T val = P_0[i];
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
