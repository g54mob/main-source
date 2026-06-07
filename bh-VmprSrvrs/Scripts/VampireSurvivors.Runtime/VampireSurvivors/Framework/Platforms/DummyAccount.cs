using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms
{
	public class DummyAccount : IBaseAccount
	{
		private DummyStorage _storage;

		private DummyAchievementsManager _dummyAchievementsManager;

		public override string LocalID => null;

		public override string OnlineID => null;

		public override string UniqueAccountID => null;

		public override IPlatformSaveUtils Storage => null;

		public override IPlatformAchievementsManager AchievementsManager => null;

		public DummyAccount(int rewiredPlayerId = 0)
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
	}
}
