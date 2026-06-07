using app.ent;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class ReactPassthroughEnt : GroupEnt
	{
		public Ent reactPassthroughTarget;

		public Rect hitAreaWorldRect;

		public ReactPassthroughEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ReactPassthroughEnt(Ent parent, Ent reactPassthroughTarget_, Rect hitAreaWorldRect_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_ReactPassthroughEnt(ReactPassthroughEnt __hx_this, Ent parent, Ent reactPassthroughTarget_, Rect hitAreaWorldRect_)
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
