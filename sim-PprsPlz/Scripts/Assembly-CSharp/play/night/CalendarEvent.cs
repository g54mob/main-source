using data;
using haxe.lang;

namespace play.night
{
	public class CalendarEvent : HxObject
	{
		public int dayId;

		public string eventId;

		public CalendarEvent(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CalendarEvent(int dayId_, string eventId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_CalendarEvent(CalendarEvent __hx_this, int dayId_, string eventId_)
		{
		}

		public static CalendarEvent fromString(NightLib nightLib, string str)
		{
			return null;
		}

		public virtual string toString()
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

		public override string ToString()
		{
			return null;
		}
	}
}
