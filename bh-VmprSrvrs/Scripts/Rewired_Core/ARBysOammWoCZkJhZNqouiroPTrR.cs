using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

internal static class ARBysOammWoCZkJhZNqouiroPTrR
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum YDYYwFgvfmNtPUFrKgfGjEaJBPeO
		{
			None = 0,
			Self = 1,
			Children = 4,
			Parents = 8,
			All = -1
		}

		private readonly EventFunction<THandler, TValue> oFMbYlPsqtBHdBhMSHYTpPMdKpcpA;

		private readonly List<THandler> xuBORGMOSJDbfKHNlgciyUjhKtbGA;

		private readonly YDYYwFgvfmNtPUFrKgfGjEaJBPeO qbjslglQPwEjeYklykVnoRUQHTzB;

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> P_0, YDYYwFgvfmNtPUFrKgfGjEaJBPeO P_1)
		{
		}

		public void ExecuteOnAll(TValue value)
		{
		}

		public void GetHandlers(Transform transform)
		{
		}
	}

	public static void nwVxMNsxStVnmxzIBjhWECVhYnjB<_0001, _0002>(_0001 P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
	{
	}

	public static void BkObGlzDRMQJsEtSEmFkLkmYzVyO<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2) where _0001 : class
	{
	}

	public static void nhoHcpFcoLgHmcAKEWgaZuqvELYdA<_0001, _0002>(IList<_0001> P_0, _0002 P_1, EventFunction<_0001, _0002> P_2, bool P_3) where _0001 : class
	{
	}
}
