using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class WaitingLine : HxObject
	{
		public Function whenArriveInBooth;

		public Array people;

		public EntEnv entEnv;

		public Rand rand;

		public Atlas atlas;

		public bool havePlayedPanicSound;

		public bool haveDispersed;

		public WaitingLine(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public WaitingLine(EntEnv entEnv_, Rand rand_, Atlas atlas_, int numPeople, bool hasTarget)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_WaitingLine(WaitingLine __hx_this, EntEnv entEnv_, Rand rand_, Atlas atlas_, int numPeople, bool hasTarget)
		{
		}

		public virtual void onEnterFrame(double dt)
		{
		}

		public virtual void advance()
		{
		}

		public virtual void disperse()
		{
		}

		public virtual void playPanicSound()
		{
		}

		public virtual void panic()
		{
		}

		public virtual void poisonPanic(PointData pos)
		{
		}

		public virtual void rushWall()
		{
		}

		public virtual void person_onEvent(Person person, string @event)
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
