using app.ent;
using data;
using haxe.ds;
using haxe.lang;
using play.day;
using play.ui;

namespace play.screen
{
	public class EndlessScreen : GameScreen
	{
		public static double kTitleY;

		public static double kScoreSpacingY;

		public static int kCourseTextAlignLeftPadding;

		public static int kTextColor;

		public Menu menu;

		public Confirm confirm;

		public Array scoreTextFields;

		public DiagramLine diagramLine;

		public StringMap styleButtons;

		public StringMap courseButtons;

		public AlltimeStats alltimeStats;

		public int alltimeStatsGeneration;

		public int resetAchievementsTapCount;

		public double resetAchievementsTapTime;

		public Button backButton;

		public double backButtonDefaultX;

		public Button leaderboardsButton;

		static EndlessScreen()
		{
		}

		public EndlessScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndlessScreen(Ent parent, AlltimeStats alltimeStats_, EndlessResult endlessResult)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_EndlessScreen(EndlessScreen __hx_this, Ent parent, AlltimeStats alltimeStats_, EndlessResult endlessResult)
		{
		}

		public virtual EndlessId get_endlessId()
		{
			return null;
		}

		public virtual EndlessId set_endlessId(EndlessId e)
		{
			return null;
		}

		public virtual void setLeaderboardsButtonActive(bool v)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public virtual void secretConfirm_onClick(string id)
		{
		}

		public virtual void refreshScoreTexts()
		{
		}

		public virtual void select(EndlessId id)
		{
		}

		public virtual void alltimeStats_onGotRankedScore(RankedScoreEntry s)
		{
		}

		public virtual void menu_onClick(string id)
		{
		}

		public virtual void styleButton_onClick(Button b)
		{
		}

		public virtual void courseButton_onClick(Button b)
		{
		}

		public virtual void presskit_prep()
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
