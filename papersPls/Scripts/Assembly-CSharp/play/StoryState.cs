using app.plat;
using data;
using haxe.lang;
using play.save;

namespace play
{
	public class StoryState : HxObject
	{
		public static Array kValidUpgradesPhone;

		public static Array kValidUpgradesTablet;

		public static Array kValidUpgradesDesktop;

		public FactSet facts;

		public UpgradeSet upgradeSet;

		public string saveId;

		public double playtimeAccumulator;

		public AlltimeStats alltimeStats;

		static StoryState()
		{
		}

		public StoryState(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StoryState(Purpose purpose, AlltimeStats alltimeStats_, PlatformKind platformKind)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_StoryState(StoryState __hx_this, Purpose purpose, AlltimeStats alltimeStats_, PlatformKind platformKind)
		{
		}

		public static Array getValidUpgrades(UpgradeSet upgradeSet)
		{
			return null;
		}

		public int get_dayId()
		{
			return 0;
		}

		public int set_dayId(int v)
		{
			return 0;
		}

		public virtual void setDeviceFact()
		{
		}

		public virtual bool hasUpgrade(Upgrade upgrade)
		{
			return false;
		}

		public virtual void giveUpgrade(Upgrade upgrade)
		{
		}

		public virtual void incStat(string statId, object delta)
		{
		}

		public virtual void maxStat(string statId, int val)
		{
		}

		public virtual void incPlaytime(double dt)
		{
		}

		public virtual void load(SaveManager saveManager, string saveId_)
		{
		}

		public virtual void save(SaveManager saveManager)
		{
		}

		public virtual void restoreFromStash(FactSet storyStateFacts)
		{
		}

		public virtual void applySkipToDay(int skipToDayId)
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
