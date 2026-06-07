using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IStats : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IStats(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		~IStats()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual void RequestUserStatsAndAchievements()
		{
		}

		public virtual int GetStatInt(string name)
		{
			return 0;
		}

		public virtual float GetStatFloat(string name)
		{
			return 0f;
		}

		public virtual void SetStatInt(string name, int value)
		{
		}

		public virtual void SetStatFloat(string name, float value)
		{
		}

		public virtual void GetAchievement(string name, ref bool unlocked, ref uint unlockTime)
		{
		}

		public virtual void SetAchievement(string name)
		{
		}

		public virtual void StoreStatsAndAchievements()
		{
		}

		public virtual void ResetStatsAndAchievements()
		{
		}

		public virtual string GetAchievementDisplayName(string name)
		{
			return null;
		}
	}
}
