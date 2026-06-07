using app;
using app.ent;
using app.plat;
using haxe.ds;
using haxe.lang;

namespace play
{
	public class AlltimeStats : HxObject
	{
		public static Array kAllAchievementIds;

		public static Array kAllLeaderboardIds;

		public int generation;

		public StringMap hash;

		public StringMap rankedScoreEntries;

		public double saveCountdown;

		public PlatformSocial platformSocial;

		public EncryptedStore encryptedStore;

		public Array pendingAchievementIds;

		public int internalGeneration;

		static AlltimeStats()
		{
		}

		public AlltimeStats(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AlltimeStats(EncryptedStore encryptedStore_, PlatformSocial platformSocial_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_AlltimeStats(AlltimeStats __hx_this, EncryptedStore encryptedStore_, PlatformSocial platformSocial_)
		{
		}

		public virtual void update(Clock clock, Ent popupParent, Res res)
		{
		}

		public virtual bool get_hasLeaderboards()
		{
			return false;
		}

		public virtual void showLeaderboards(string leaderboardId)
		{
		}

		public virtual void inc(string statId, object delta)
		{
		}

		public virtual void max(string statId, int val)
		{
		}

		public virtual int get(string statId)
		{
			return 0;
		}

		public virtual void or(string statId, int val)
		{
		}

		public string toScoreKey(string leaderboardId)
		{
			return null;
		}

		public virtual void addScore(string leaderboardId, ScoreEntry entry)
		{
		}

		public virtual void addScoreLocal(string leaderboardId, ScoreEntry entry)
		{
		}

		public ScoreEntry getScoreInHash(string key)
		{
			return null;
		}

		public virtual RankedScoreEntry getRankedScore(string leaderboardId)
		{
			return null;
		}

		public virtual void connectToSocialIfNotConnected()
		{
		}

		public virtual void awardAchievement(string achievementId)
		{
		}

		public virtual void clearAchievements()
		{
		}

		public virtual void queSave()
		{
		}

		public virtual void load()
		{
		}

		public virtual void save()
		{
		}

		public virtual void publishStats()
		{
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
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
