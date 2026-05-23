using app.ent;
using app.vis;
using haxe.lang;

namespace play.night.ent
{
	public class BudgetLineEnt : Ent
	{
		public static int kPlusColor;

		public static int kMinusColor;

		public static int kDisabledColor;

		public static int kLineHeightTall;

		public static int kLineHeightShort;

		public double lineHeight;

		public Function whenClick;

		public Line budgetLine;

		public Text textFieldL;

		public Text textFieldR;

		public Sprite checkEnabledSprite;

		public Sprite checkDisabledSprite;

		public double totalWidth;

		static BudgetLineEnt()
		{
		}

		public BudgetLineEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BudgetLineEnt(Ent parent, Line budgetLine_, double textWidth, bool tall)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_ent_BudgetLineEnt(BudgetLineEnt __hx_this, Ent parent, Line budgetLine_, double textWidth, bool tall)
		{
		}

		public virtual bool get_enabled()
		{
			return false;
		}

		public double get_checkCenterX()
		{
			return 0.0;
		}

		public double get_checkCenterY()
		{
			return 0.0;
		}

		public virtual void flashCheck()
		{
		}

		public virtual void tween_flashCheck(double t)
		{
		}

		public override void react(Input input)
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

		public override void draw(Drawer drawer)
		{
		}

		public virtual bool set_enabled(bool e)
		{
			return false;
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
