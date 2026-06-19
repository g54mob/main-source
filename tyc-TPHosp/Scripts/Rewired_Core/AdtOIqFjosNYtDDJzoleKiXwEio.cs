using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class AdtOIqFjosNYtDDJzoleKiXwEio
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum nktfWLolDRlBWoAjBMmrdPfLReF
		{
			DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
			fWukRdAdyKHOYqfRsegHsTUFHRj = 1,
			FawtDJycoEGHCgffFtoIeJAIHMJ = 4,
			sJiaCQhBZzCyLtsAVHwzpZhqrybC = 8,
			vMQMIUYjbKgmGAnSwvFDckfsucBe = -1
		}

		private readonly EventFunction<THandler, TValue> HliqQTuTVbOllZMbAIZqzFAXdtD;

		private readonly List<THandler> hgzcPCYlHxsHWQxixkrLNryErfm;

		private readonly nktfWLolDRlBWoAjBMmrdPfLReF tSPWkvZKWOkzhlBzoqqKijHaRMw;

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate)
			: this(executeDelegate, nktfWLolDRlBWoAjBMmrdPfLReF.fWukRdAdyKHOYqfRsegHsTUFHRj | nktfWLolDRlBWoAjBMmrdPfLReF.FawtDJycoEGHCgffFtoIeJAIHMJ)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate, nktfWLolDRlBWoAjBMmrdPfLReF executeOn)
		{
			if (executeDelegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			HliqQTuTVbOllZMbAIZqzFAXdtD = executeDelegate;
			hgzcPCYlHxsHWQxixkrLNryErfm = new List<THandler>();
			tSPWkvZKWOkzhlBzoqqKijHaRMw = executeOn;
		}

		public void ExecuteOnAll(TValue value)
		{
			scdjPqiZnJliJmcKpXAxSTUnYFb(hgzcPCYlHxsHWQxixkrLNryErfm, value, HliqQTuTVbOllZMbAIZqzFAXdtD, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((tSPWkvZKWOkzhlBzoqqKijHaRMw & nktfWLolDRlBWoAjBMmrdPfLReF.fWukRdAdyKHOYqfRsegHsTUFHRj) != nktfWLolDRlBWoAjBMmrdPfLReF.DVDMTdEnkAaktJFJqNakDhECjSAS && (tSPWkvZKWOkzhlBzoqqKijHaRMw & nktfWLolDRlBWoAjBMmrdPfLReF.FawtDJycoEGHCgffFtoIeJAIHMJ) != nktfWLolDRlBWoAjBMmrdPfLReF.DVDMTdEnkAaktJFJqNakDhECjSAS && (tSPWkvZKWOkzhlBzoqqKijHaRMw & nktfWLolDRlBWoAjBMmrdPfLReF.sJiaCQhBZzCyLtsAVHwzpZhqrybC) != nktfWLolDRlBWoAjBMmrdPfLReF.DVDMTdEnkAaktJFJqNakDhECjSAS)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.root, hgzcPCYlHxsHWQxixkrLNryErfm, append: false);
				return;
			}
			if ((tSPWkvZKWOkzhlBzoqqKijHaRMw & nktfWLolDRlBWoAjBMmrdPfLReF.FawtDJycoEGHCgffFtoIeJAIHMJ) != nktfWLolDRlBWoAjBMmrdPfLReF.DVDMTdEnkAaktJFJqNakDhECjSAS)
			{
				if ((tSPWkvZKWOkzhlBzoqqKijHaRMw & nktfWLolDRlBWoAjBMmrdPfLReF.fWukRdAdyKHOYqfRsegHsTUFHRj) != nktfWLolDRlBWoAjBMmrdPfLReF.DVDMTdEnkAaktJFJqNakDhECjSAS)
				{
					UnityTools.GetComponentsInSelfAndChildren(transform, hgzcPCYlHxsHWQxixkrLNryErfm, append: true);
				}
				else
				{
					UnityTools.GetComponents(transform, hgzcPCYlHxsHWQxixkrLNryErfm, append: true);
				}
			}
			if ((tSPWkvZKWOkzhlBzoqqKijHaRMw & nktfWLolDRlBWoAjBMmrdPfLReF.sJiaCQhBZzCyLtsAVHwzpZhqrybC) != nktfWLolDRlBWoAjBMmrdPfLReF.DVDMTdEnkAaktJFJqNakDhECjSAS)
			{
				UnityTools.GetComponentsInParents(transform, hgzcPCYlHxsHWQxixkrLNryErfm, append: true);
			}
		}
	}

	public static void PwYmRrUuztbGQzvBQbDKqplLqRn<T, TArgs>(T P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
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

	public static void PwYmRrUuztbGQzvBQbDKqplLqRn<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
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

	public static void scdjPqiZnJliJmcKpXAxSTUnYFb<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2, bool P_3) where T : class
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
