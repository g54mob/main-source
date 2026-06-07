using System;
using Dhs5.Utility.Settings;

namespace Simulator.CustomSettings
{
	[Serializable]
	public abstract class UI_BasePlayerPrefMemberOptions<T> where T : PlayerPrefMember
	{
		protected T playerPrefMember;

		public void Init(T playerPrefMember)
		{
			this.playerPrefMember = playerPrefMember;
		}

		public abstract void Awake();

		public abstract void OnEnable();

		public abstract void OnDisable();

		public abstract void SelectCurrentValue();
	}
}
