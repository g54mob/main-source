using app.plat;
using data;
using haxe.ds;
using haxe.lang;

namespace app.aud
{
	public class Speaker : HxObject
	{
		public static int curPlayId;

		public Clock clock;

		public PlatformAudio platformAudio;

		public List playingSounds;

		public bool ignoringNonLoopingPlaysThisFrame;

		public string room;

		public SoundDefLib soundDefLib;

		static Speaker()
		{
		}

		public Speaker(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Speaker(PlatformAudio platformAudio_, Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_aud_Speaker(Speaker __hx_this, PlatformAudio platformAudio_, Res res)
		{
		}

		public static int nextPlayId()
		{
			return 0;
		}

		public bool get_canVibrate()
		{
			return false;
		}

		public virtual void update()
		{
		}

		public virtual void ignoreNonLoopingPlaysThisFrame()
		{
		}

		public void setRoom(string room_)
		{
		}

		public virtual int play(string soundId)
		{
			return 0;
		}

		public virtual int music(string songId)
		{
			return 0;
		}

		public virtual SpeakerSound findPlayingSound(int playId)
		{
			return null;
		}

		public virtual void setVolume(int playId, double vol, object fadeTo)
		{
		}

		public virtual double getPlayPosition(int playId)
		{
			return 0.0;
		}

		public virtual void stop(int playId, object fadeOut)
		{
		}

		public virtual void pauseAll()
		{
		}

		public virtual void resumeAll()
		{
		}

		public virtual void stopAll(object fadeOut, object justEffects)
		{
		}

		public virtual bool isPlaying(int playId)
		{
			return false;
		}

		public virtual void vibrate(int vibration)
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
