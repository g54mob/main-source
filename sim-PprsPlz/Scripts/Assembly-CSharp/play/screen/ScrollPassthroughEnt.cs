using app.ent;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class ScrollPassthroughEnt : Ent
	{
		public Ent scrollPassthroughTarget;

		public Rect hitAreaWorldRect;

		public ScrollPassthroughEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ScrollPassthroughEnt(Ent parent, Ent scrollPassthroughTarget_, Rect hitAreaWorldRect_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_ScrollPassthroughEnt(ScrollPassthroughEnt __hx_this, Ent parent, Ent scrollPassthroughTarget_, Rect hitAreaWorldRect_)
		{
		}

		public override void react(Input input)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
