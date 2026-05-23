using haxe.lang;

namespace app.plat
{
	public class PlatformAudio : HxObject
	{
		public PlatformAudio(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformAudio()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformAudio(PlatformAudio __hx_this)
		{
		}

		public virtual void start(int playId, int category, string filename, bool loop, float volume)
		{
		}

		public virtual void setVolume(int playId, float volume)
		{
		}

		public virtual float getPlayPosition(int playId)
		{
			return 0f;
		}

		public virtual void stop(int playId)
		{
		}

		public virtual void setCategoryPause(int category, bool pause)
		{
		}

		public virtual void setCategoryVolume(int category, float volume)
		{
		}

		public virtual bool canVibrate()
		{
			return false;
		}

		public virtual void vibrate(int vibration)
		{
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}
	}
}
