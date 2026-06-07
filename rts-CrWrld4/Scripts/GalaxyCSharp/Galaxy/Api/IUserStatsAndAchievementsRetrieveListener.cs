using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IUserStatsAndAchievementsRetrieveListener : GalaxyTypeAwareListenerUserStatsAndAchievementsRetrieve
	{
		public delegate void SwigDelegateIUserStatsAndAchievementsRetrieveListener_0(IntPtr cPtr, IntPtr userID);

		public delegate void SwigDelegateIUserStatsAndAchievementsRetrieveListener_1(IntPtr cPtr, IntPtr userID, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CONNECTION_FAILURE = 1
		}

		private static Dictionary<IntPtr, IUserStatsAndAchievementsRetrieveListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIUserStatsAndAchievementsRetrieveListener_0 swigDelegate0;

		private SwigDelegateIUserStatsAndAchievementsRetrieveListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		internal IUserStatsAndAchievementsRetrieveListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IUserStatsAndAchievementsRetrieveListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IUserStatsAndAchievementsRetrieveListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnUserStatsAndAchievementsRetrieveSuccess(GalaxyID userID);

		public abstract void OnUserStatsAndAchievementsRetrieveFailure(GalaxyID userID, FailureReason failureReason);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnUserStatsAndAchievementsRetrieveSuccess(IntPtr cPtr, IntPtr userID)
		{
		}

		private static void SwigDirectorOnUserStatsAndAchievementsRetrieveFailure(IntPtr cPtr, IntPtr userID, int failureReason)
		{
		}
	}
}
