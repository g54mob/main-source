using app.ent;
using haxe.lang;
using play.day.border;

namespace play.day.booth
{
	public class Tutor : Ent
	{
		public static int kBulletinPaperW;

		public static int kBulletinPaperH;

		public Booth booth;

		public Border border;

		public TutorCover boothCover;

		public TutorCover carouselCover;

		public TutorCover rackCover;

		public Paper bulletinPaper;

		public Array covers;

		public Array lessons;

		public int curLessonIndex;

		static Tutor()
		{
		}

		public Tutor(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Tutor(Booth booth_, Border border_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Tutor(Tutor __hx_this, Booth booth_, Border border_)
		{
		}

		public StampDesk get_stampDesk()
		{
			return null;
		}

		public TutorLesson get_curLesson()
		{
			return null;
		}

		public virtual Paper get_bulletinPaper()
		{
			return null;
		}

		public virtual void onReactBulletinPassthrough(TutorLesson lesson, Input input)
		{
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void abort()
		{
		}

		public virtual Array autoActions()
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
