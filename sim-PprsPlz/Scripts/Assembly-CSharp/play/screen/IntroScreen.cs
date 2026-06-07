using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.screen
{
	public class IntroScreen : GameScreen
	{
		public Intro intro;

		public Fill backgroundFill;

		public IntroScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public IntroScreen(Ent parent, FactSet storyFacts)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_IntroScreen(IntroScreen __hx_this, Ent parent, FactSet storyFacts)
		{
		}

		public virtual void intro_onDone()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
