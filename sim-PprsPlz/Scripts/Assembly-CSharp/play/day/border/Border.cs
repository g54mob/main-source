using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.day.booth;
using play.stash;
using play.ui;

namespace play.day.border
{
	public class Border : Ent
	{
		public static int kSnipingColorKill;

		public static int kSnipingColorTranq;

		public static double kGrenadeRange;

		public Ent nonScrollingEnt;

		public Sprite backgroundSprite;

		public Sprite truckWreckSprite;

		public Sprite bombedWallSprite;

		public Sprite headerSprite;

		public Clock localClock;

		public double localClockTimescale;

		public WaitingLine waitingLine;

		public Booth booth;

		public SpeechBubble callNextSpeechBubble;

		public SpeechBubble bomberSpeechBubble;

		public Button outerBoothButton;

		public Stater stater;

		public bool haveDispersedWaitingLine;

		public Image bulletHolesImage;

		public ShuffledSequence bulletHoleSequence;

		public Fill whiteFlashFill;

		public double whiteFlashTime;

		public Array people;

		public Person guard0;

		public Person guard1;

		public Person guard2;

		public Person guard3;

		public Person guard4;

		public Person runningPerson;

		public Person truck;

		public Person trafficCar;

		public Person bossCar;

		public Person bossLeavingPerson;

		public Array leavingPeople;

		public Array enemies;

		public CustomTile explosionClip;

		public Day day;

		public bool havePanicked;

		public double alarmLastPlayTime;

		public RifleButton killRifleButton;

		public RifleButton tranqRifleButton;

		public int snipingGuardReactBits;

		public bool snipingEnabled;

		public bool trafficEnabled;

		public EndlessScoreboard endlessScoreboard;

		public bool attackerWillBeStoppedEarlyByGuards;

		public bool waitingForAttack;

		public BorderPan borderPan;

		public StoryState storyState;

		public Array grenades;

		public Array visuals;

		public Frame snipingFrame;

		public bool tutorBlockingOuterBoothButton;

		public int pauseUntilFrame;

		public Atlas atlas;

		public Rand rand;

		static Border()
		{
		}

		public Border(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Border(Ent parent, Day day_, Booth booth_, Rand rand_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_Border(Border __hx_this, Ent parent, Day day_, Booth booth_, Rand rand_)
		{
		}

		public bool get_isWaitingToFadeToNight()
		{
			return false;
		}

		public virtual StashedBorder makeStash()
		{
			return null;
		}

		public virtual bool restoreFromStash(StashedBorder s)
		{
			return false;
		}

		public virtual void panToPeople(Person p0, Person p1, Person p2, object offsetX)
		{
		}

		public virtual void panToSide(bool left)
		{
		}

		public virtual int get_overlayObjectFlags()
		{
			return 0;
		}

		public virtual int set_overlayObjectFlags(int flags)
		{
			return 0;
		}

		public virtual void resetLeavingPeopleAndEnemies()
		{
		}

		public virtual void prepareForAttack(object initGuards)
		{
		}

		public virtual bool checkEnemiesDead()
		{
			return false;
		}

		public virtual void standDownRightGuards()
		{
		}

		public virtual void rifleButton_onClick(RifleButton rifleButton)
		{
		}

		public virtual bool set_snipingEnabled(bool s)
		{
			return false;
		}

		public override void react(Input input)
		{
		}

		public virtual bool checkSniped(Person person, PointData pos, string shotAnim)
		{
			return false;
		}

		public virtual RifleButton getSelectedRifleButton()
		{
			return null;
		}

		public virtual bool set_trafficEnabled(bool t)
		{
			return false;
		}

		public virtual void debugSnipeAll()
		{
		}

		public virtual void snipe(PointData pos_)
		{
		}

		public virtual Person addPerson(string id, string prefix, string idleAnimSuffix)
		{
			return null;
		}

		public virtual void booth_onTravelerLeaves(string direction)
		{
		}

		public virtual Person getFreeLeavingPerson()
		{
			return null;
		}

		public virtual Person makeEnemy(string id)
		{
			return null;
		}

		public virtual void spawnExplosion(PointData pos, object killGuardsAndEndDay)
		{
		}

		public virtual void booth_onDetainStart(bool resisting)
		{
		}

		public virtual void booth_onDetaineeLeaves(bool resisting)
		{
		}

		public virtual void sendRunner()
		{
		}

		public virtual void sendRunnerShot()
		{
		}

		public virtual void sendTruck()
		{
		}

		public virtual void sendBoss()
		{
		}

		public virtual void sendBikeAttack()
		{
		}

		public virtual void sendBikeRunner()
		{
		}

		public virtual void sendBikeAttackShot()
		{
		}

		public virtual void outerBoothButton_onClick(Button b)
		{
		}

		public virtual void showPersonSpeech(Person person, string text, string playSoundId)
		{
		}

		public virtual void person_onEvent(Person person, string @event)
		{
		}

		public virtual void panic()
		{
		}

		public virtual void panicLeavingPersonRight()
		{
		}

		public virtual void playAlarmSound()
		{
		}

		public virtual void throwGrenade(PointData pos, PointData vel)
		{
		}

		public virtual void grenade_onHit(CustomTile tile)
		{
		}

		public virtual void waitingLine_onArriveInBooth(Person person)
		{
		}

		public virtual void pauseForOneFrame()
		{
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual Person autoGetLivingTargetPerson(AutoSnipeTarget target)
		{
			return null;
		}

		public virtual bool getPersonIsNearGuards(Person person)
		{
			return false;
		}

		public virtual PointData autoGetNextSnipeWorldPoint(AutoSnipeTarget target)
		{
			return null;
		}

		public virtual bool autoIsAttackUnderway()
		{
			return false;
		}

		public virtual Button tutorGetOuterBoothButton()
		{
			return null;
		}

		public virtual void tutorBlockOuterBoothButton(bool tutorBlockingOuterBoothButton_)
		{
		}

		public virtual bool tutorIsReadyToCallNextTraveler()
		{
			return false;
		}

		public virtual void tutorForcePanLeft()
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
