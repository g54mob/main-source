using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IAchievementChangeListener : GalaxyTypeAwareListenerAchievementChange
	{
		public delegate void SwigDelegateIAchievementChangeListener_0(IntPtr cPtr, string name);

		private static Dictionary<IntPtr, IAchievementChangeListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIAchievementChangeListener_0 swigDelegate0;

		private static Type[] swigMethodTypes0;

		internal IAchievementChangeListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IAchievementChangeListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IAchievementChangeListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnAchievementUnlocked(string name);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnAchievementUnlocked(IntPtr cPtr, string name)
		{
		}
	}
}
