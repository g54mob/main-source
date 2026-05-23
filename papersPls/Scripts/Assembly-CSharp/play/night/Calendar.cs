using data;
using haxe.lang;

namespace play.night
{
	public class Calendar : HxObject
	{
		public NightLib nightLib;

		public Array calendarEvents;

		public Calendar(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Calendar(NightLib nightLib_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_Calendar(Calendar __hx_this, NightLib nightLib_)
		{
		}

		public static Calendar fromString(NightLib nightLib, string str)
		{
			return null;
		}

		public virtual void addEvent(int dayId, string eventId)
		{
		}

		public virtual Array getEvents(int dayId)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
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

		public override string ToString()
		{
			return null;
		}
	}
}
