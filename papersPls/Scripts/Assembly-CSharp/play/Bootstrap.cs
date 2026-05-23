using app;
using app.aud;
using app.ent;
using app.plat;
using data;
using haxe.lang;
using play.day;
using play.save;

namespace play
{
	public class Bootstrap : HxObject
	{
		public Platform platform;

		public EncryptedStore encryptedStore;

		public Res res;

		public Unbug unbug;

		public AlltimeStats alltimeStats;

		public FaceCycler faceCycler;

		public Settings settings;

		public SaveManager saveManager;

		public Layout layout;

		public GameTransition gameTransition;

		public CommandLine commandLine;

		public Db db;

		public DayRun dayRun;

		public BoothEnvRun boothEnvRun;

		public StoryState storyState;

		public NameCycler nameCycler;

		public EntEnv entEnv;

		public Speaker speaker;

		public Music music;

		public int randomSeed;

		public Rand endlessSeedGenRand;

		public Rand storySeedGenRand;

		public Bootstrap(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Bootstrap(Platform platform_, CommandLine commandLine_, int randomSeed_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_Bootstrap(Bootstrap __hx_this, Platform platform_, CommandLine commandLine_, int randomSeed_)
		{
		}

		public virtual void setLanguage(string languageCode)
		{
		}

		public virtual void advanceStorySeed()
		{
		}

		public virtual void autoReapplyRandomSeed()
		{
		}

		public virtual StoryState set_storyState(StoryState storyState_)
		{
			return null;
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
