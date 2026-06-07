using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.day.booth
{
	public class CriminalPosterPin : Ent
	{
		public static string kGameFactPath;

		public Carousel carousel;

		public CriminalPoster criminalPoster;

		public Paper bulletinPaper;

		public StoryState storyState;

		public Button button;

		public Sprite arrowSprite;

		public Array boxSprites;

		public double appearWaitCountup;

		public double flashStartTime;

		public double clickTime;

		public double appearWaitDuration;

		static CriminalPosterPin()
		{
		}

		public CriminalPosterPin(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CriminalPosterPin(Ent parent, Carousel carousel_, CriminalPoster criminalPoster_, StoryState storyState_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CriminalPosterPin(CriminalPosterPin __hx_this, Ent parent, Carousel carousel_, CriminalPoster criminalPoster_, StoryState storyState_)
		{
		}

		public bool get_flashOn()
		{
			return false;
		}

		public virtual void setBulletinPaper(Paper bulletinPaper_)
		{
		}

		public virtual void button_onClick(Button button)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
