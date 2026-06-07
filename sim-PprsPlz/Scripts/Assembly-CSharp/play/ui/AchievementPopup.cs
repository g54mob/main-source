using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class AchievementPopup : Ent
	{
		public static int kSpacing;

		public static int kMarginR;

		public Sprite sprite;

		public Stater stater;

		public int slotIndex;

		public double createTime;

		static AchievementPopup()
		{
		}

		public AchievementPopup(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AchievementPopup(Ent parent, Image image)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_AchievementPopup(AchievementPopup __hx_this, Ent parent, Image image)
		{
		}

		public static void show(Ent parent, Res res, string achievementId)
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
