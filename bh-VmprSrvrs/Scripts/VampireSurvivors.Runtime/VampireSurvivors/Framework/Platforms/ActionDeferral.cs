using System;

namespace VampireSurvivors.Framework.Platforms
{
	public class ActionDeferral
	{
		private Action m_OnUnlock;

		private int m_Locks;

		public ActionDeferral(Action onUnlock)
		{
		}

		public void Lock()
		{
		}

		public bool Unlock()
		{
			return false;
		}
	}
}
