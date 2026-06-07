using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.day;
using play.ui;

namespace play.night.ent
{
	public class BudgetEnt : Ent
	{
		public static int kMessageColor;

		public static uint kTallyLineColor;

		public static int kSleepButtonHeight;

		public static int kLineSpacing;

		public Button sleepButton;

		public Text dayTextField;

		public Array messageTextFields;

		public Array budgetLineEnts;

		public DiagramLine budgetDiagramLine;

		public Text budgetTotalTextField;

		public Stater stater;

		public Family family;

		public Day day;

		public int numVisibleBudgetLines;

		public Array visuals;

		public StoryState storyState;

		public Function whenClickSleep;

		public bool budgetTotalVisible;

		public double budgetTotalFlashStartTime;

		public Sprite budgetLineCantSprite;

		public Ent messagesParentEnt;

		public GroupEnt tallyGroupEnt;

		public Array debugFills;

		public Rect budgetRect;

		static BudgetEnt()
		{
		}

		public BudgetEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BudgetEnt(Ent parent, AlltimeStats alltimeStats, StoryState storyState_, Day day_, Function whenClickSleep_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_ent_BudgetEnt(BudgetEnt __hx_this, Ent parent, AlltimeStats alltimeStats, StoryState storyState_, Day day_, Function whenClickSleep_)
		{
		}

		public static object calcSplit(Rect budgetRect, double messagesHeight, double tallyHeight)
		{
			return null;
		}

		public virtual void sleepButton_onClick(Button b)
		{
		}

		public virtual void updateBudgetTotal()
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void skipRevealAnimation()
		{
		}

		public virtual bool autoIsAnimating()
		{
			return false;
		}

		public virtual double createMessageTexts(string fontId, object asWideAsPossible)
		{
			return 0.0;
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
