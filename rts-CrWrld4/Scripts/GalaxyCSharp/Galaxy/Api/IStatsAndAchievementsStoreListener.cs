using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IStatsAndAchievementsStoreListener : GalaxyTypeAwareListenerStatsAndAchievementsStore
	{
		public delegate void SwigDelegateIStatsAndAchievementsStoreListener_0(IntPtr cPtr);

		public delegate void SwigDelegateIStatsAndAchievementsStoreListener_1(IntPtr cPtr, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CONNECTION_FAILURE = 1
		}

		private static Dictionary<IntPtr, IStatsAndAchievementsStoreListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIStatsAndAchievementsStoreListener_0 swigDelegate0;

		private SwigDelegateIStatsAndAchievementsStoreListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		internal IStatsAndAchievementsStoreListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IStatsAndAchievementsStoreListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IStatsAndAchievementsStoreListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnUserStatsAndAchievementsStoreSuccess();

		public abstract void OnUserStatsAndAchievementsStoreFailure(FailureReason failureReason);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnUserStatsAndAchievementsStoreSuccess(IntPtr cPtr)
		{
		}

		private static void SwigDirectorOnUserStatsAndAchievementsStoreFailure(IntPtr cPtr, int failureReason)
		{
		}
	}
}
