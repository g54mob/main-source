using app;
using app.ent;
using app.plat;
using app.vis;
using haxe.lang;
using play;
using play.day;
using play.screen;
using play.stash;
using play.ui;

public class Game : HxObject, IGame, IHxObject
{
	public Platform platform;

	public Bootstrap bootstrap;

	public Stater stater;

	public Day day;

	public GameScreen gameScreen;

	public PauseScreen pauseScreen;

	public ScreenChange pendingScreenChange;

	public ScreenFlash screenFlash;

	public Drawer drawer;

	public QuadIter quadIter;

	public uint settingsGeneration;

	public bool wantSoak_;

	public PlatformKind wantPlatformKind_;

	public CursorEnt cursorEnt;

	public GameParams @params;

	public Game(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Game(GameParams params_)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Game(Game __hx_this, GameParams params_)
	{
	}

	public static double convertVolume(double vol)
	{
		return 0.0;
	}

	public Trunk get_trunk()
	{
		return null;
	}

	public virtual void boot()
	{
	}

	public virtual void prependRatingScreenIfNecessary(Function doneFunc)
	{
	}

	public virtual void createDefaultEnts()
	{
	}

	public virtual void createStater()
	{
	}

	public virtual void setupDevMenu()
	{
	}

	public virtual void devMenu_setLeaderboardScore(int delta)
	{
	}

	public virtual void applyScreenChange(ScreenChange screenChange)
	{
	}

	public virtual Day getDaySafe()
	{
		return null;
	}

	public virtual void update(Input input)
	{
	}

	public virtual void applySettings()
	{
	}

	public virtual void queueScreenChangeToSettings()
	{
	}

	public virtual QuadIter draw()
	{
		return null;
	}

	public virtual void fadeToTitle(bool instant)
	{
	}

	public virtual void queueScreenChange(string screenName, GameTransitionKind gameTransitionKind, object instant)
	{
	}

	public virtual void applyTransition(GameTransitionKind kind)
	{
	}

	public virtual void stashSaveDay()
	{
	}

	public virtual void stashSaveNight()
	{
	}

	public virtual void stashSaveEnd(string endId)
	{
	}

	public virtual void stashSave(StashedGame stashedGame)
	{
	}

	public virtual bool restoreFromStash(StashedGame s)
	{
		return false;
	}

	public virtual int width()
	{
		return 0;
	}

	public virtual int height()
	{
		return 0;
	}

	public virtual int subpixelCount()
	{
		return 0;
	}

	public virtual Image phantomCursorImage()
	{
		return null;
	}

	public virtual Image deviceTestMaskImage()
	{
		return null;
	}

	public virtual bool wantSoak()
	{
		return false;
	}

	public virtual PlatformKind wantPlatformKind()
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
