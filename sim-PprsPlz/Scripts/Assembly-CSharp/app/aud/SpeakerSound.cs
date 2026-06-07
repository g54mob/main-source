using app.plat;
using haxe.lang;

namespace app.aud
{
	public class SpeakerSound : HxObject
	{
		public int playId;

		public PlayState playState;

		public double playPosition;

		public double volume;

		public int frameCount;

		public int category;

		public double age;

		public double volScale;

		public double targetVolume0;

		public double targetVolume1;

		public double targetTime0;

		public double targetTime1;

		public double fadeDuration;

		public PlatformAudio platformAudio;

		public SpeakerSound(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SpeakerSound(PlatformAudio platformAudio_, int playId_, int category_, object volScale_, object fadeDuration_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_aud_SpeakerSound(SpeakerSound __hx_this, PlatformAudio platformAudio_, int playId_, int category_, object volScale_, object fadeDuration_)
		{
		}

		public virtual void stop(object fadeOut)
		{
		}

		public virtual void update(double dt)
		{
		}

		public virtual void setVolume(double vol, object fadeTo)
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
