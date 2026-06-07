using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.Standalone
{
	public class StandaloneAccount : IBaseAccount
	{
		private StandaloneStorage m_Storage;

		private DummyAchievementsManager m_DummyAchievementsManager;

		public override string LocalID => null;

		public override string OnlineID => null;

		public override string UniqueAccountID => null;

		public override IPlatformSaveUtils Storage => null;

		public override IPlatformAchievementsManager AchievementsManager => null;

		public StandaloneAccount(int rewiredPlayerId = 0)
			: base(0)
		{
		}

		public override void LoginAsync(LoginOptions options, Action<LoginResult> onComplete)
		{
		}

		public override void GetAvailableDlc(Action<List<DlcType>> onComplete)
		{
		}

		public override void GetLicensedDlc(Action<List<DlcType>> onComplete)
		{
		}

		public override void UpdateInstalledDlc(Action onComplete)
		{
		}

		public override void MountDlc(DlcType dlcType, Action<string> onComplete)
		{
		}

		public override void UnmountDlc(DlcType dlcType, Action onComplete)
		{
		}

		public override bool DoesSupportWindowModes()
		{
			return false;
		}

		public override bool DoesSupportVSync()
		{
			return false;
		}

		public override bool DoesPlayer1NeedController()
		{
			return false;
		}

		private void OnUpdate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
