using haxe.lang;

namespace app.aud
{
	public class MusicBeat : HxObject
	{
		public static int kBeatsPerBar;

		public Array measures;

		public double initialBpm;

		static MusicBeat()
		{
		}

		public MusicBeat(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public MusicBeat(object fixedBpm)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_aud_MusicBeat(MusicBeat __hx_this, object fixedBpm)
		{
		}

		public virtual double getBeat(double time)
		{
			return 0.0;
		}

		public virtual double getTime(double beat)
		{
			return 0.0;
		}

		public virtual double getBpm(double beat)
		{
			return 0.0;
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
