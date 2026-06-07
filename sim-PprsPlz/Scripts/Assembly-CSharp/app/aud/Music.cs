using haxe.lang;

namespace app.aud
{
	public class Music : HxObject
	{
		public Clock clock;

		public string songId;

		public bool wantFadeOut;

		public MusicBeat musicBeat;

		public Speaker speaker;

		public int speakerPlayId;

		public Music(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Music(Speaker speaker_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_aud_Music(Music __hx_this, Speaker speaker_)
		{
		}

		public bool get_isPlaying()
		{
			return false;
		}

		public virtual void play(string songId_)
		{
		}

		public virtual void playNow(string songId_)
		{
		}

		public virtual void update()
		{
		}

		public virtual double get_beat()
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
