using app.ent;
using haxe.lang;

namespace play.day.booth
{
	public class Magnifier : Ent
	{
		public Function whenMouseUp;

		public Array glasses;

		public Drawer drawer;

		public Magnifier(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Magnifier(InspectUi inspectUi, Booth booth, Function whenMouseUp_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Magnifier(Magnifier __hx_this, InspectUi inspectUi, Booth booth, Function whenMouseUp_)
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

		public virtual void open()
		{
		}

		public virtual void close()
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
