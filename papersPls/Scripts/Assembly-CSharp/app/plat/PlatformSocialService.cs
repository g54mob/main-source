using haxe.lang;

namespace app.plat
{
	public class PlatformSocialService : HxObject
	{
		public PlatformSocialLocalAchievements localAchievements;

		public PlatformSocialLocalLeaderboards localLeaderboards;

		public PlatformSocialService(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSocialService()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSocialService(PlatformSocialService __hx_this)
		{
		}

		public virtual string versionCode()
		{
			return null;
		}

		public virtual void connect(PlatformSocialLocalAchievements localAchievements_, PlatformSocialLocalLeaderboards localLeaderboards_)
		{
		}

		public virtual bool isConnected()
		{
			return false;
		}

		public virtual void attemptManualConnectIfNotConnected()
		{
		}

		public virtual void processFrame()
		{
		}

		public virtual void pullAchievements()
		{
		}

		public virtual void pushAchievement(string achievementId)
		{
		}

		public virtual void clearAchievements()
		{
		}

		public virtual bool hasLeaderboards()
		{
			return false;
		}

		public virtual void pullLeaderboards()
		{
		}

		public virtual void pushLeaderboard(string leaderboardId, int score, int time)
		{
		}

		public virtual void showLeaderboard(string leaderboardId)
		{
		}

		public virtual void reportStat(string name, int value)
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
