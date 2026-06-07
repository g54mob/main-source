using haxe.lang;

namespace app.plat
{
	public class PlatformSocial : HxObject
	{
		public PlatformSocialService service;

		public PlatformSocialLocalAchievements localAchievements;

		public PlatformSocialLocalLeaderboards localLeaderboards;

		public PlatformSocial(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSocial(PlatformSocialService service_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSocial(PlatformSocial __hx_this, PlatformSocialService service_)
		{
		}

		public virtual void registerIds(Array achievementIds, Array leaderboardIds)
		{
		}

		public bool isConnected()
		{
			return false;
		}

		public virtual void attemptManualConnectIfNotConnected()
		{
		}

		public virtual int getGeneration()
		{
			return 0;
		}

		public virtual string versionCode()
		{
			return null;
		}

		public virtual bool hasLeaderboards()
		{
			return false;
		}

		public virtual void showLeaderboard(string leaderboardId)
		{
		}

		public virtual void reportLeaderboardScore(string leaderboardId, int score, int time)
		{
		}

		public virtual PlatformSocialLeaderboardScore getLeaderboardScore(string leaderboardId)
		{
			return null;
		}

		public virtual void awardAchievement(string achievementId)
		{
		}

		public virtual bool getAchievementAwarded(string achievementId)
		{
			return false;
		}

		public virtual void clearAchievements()
		{
		}

		public virtual void reportStat(string name, int value)
		{
		}

		public virtual void processFrame()
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
