using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

internal static class stlYYrlogjOzidIPUgNgkVVVmZH
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum GnkBsHVqYSvntkHXngAgYXABqDp
		{
			bANLksuTeREfmxvNVHxsLpYEtSv = 0,
			TSqsmccRvNbfPGIlRzVFcIXcyqCo = 1,
			dngEdQQTqZfkVeQzyfYQJAFhxugp = 4,
			WfgYZYbDMgIWTQYHgPjTplgPDQS = 8,
			PLECMBkvlZEUHNuUXumZQFhRZZs = -1
		}

		private readonly EventFunction<THandler, TValue> nbaGeEAcBoEZszLtdkaqTGQosMy;

		private readonly List<THandler> ZhdmuDgmRckSHkZoMBRXxvahuSP;

		private readonly GnkBsHVqYSvntkHXngAgYXABqDp VUDiNopUQDTaiTKlFNpMOwTVpPT;

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate, GnkBsHVqYSvntkHXngAgYXABqDp executeOn)
		{
		}

		public void ExecuteOnAll(TValue value)
		{
		}

		public void GetHandlers(Transform transform)
		{
		}
	}

	public static void jbQPjmoofycQRBoLfkrQSbpmoJM<T, TArgs>(T P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
	}

	public static void jbQPjmoofycQRBoLfkrQSbpmoJM<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
	}

	public static void QmtWrrAbVKcPYbGIQJcrcmIBClQR<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2, bool P_3) where T : class
	{
	}
}
