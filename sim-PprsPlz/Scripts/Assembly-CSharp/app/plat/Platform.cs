using haxe.lang;

namespace app.plat
{
	public class Platform : HxObject
	{
		public PlatformKind kind;

		public int width;

		public int height;

		public PlatformSys sys;

		public PlatformDisk disk;

		public PlatformAudio audio;

		public PlatformSocial social;

		public Platform(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Platform(PlatformKind kind_, int width_, int height_, PlatformSys sys_, PlatformDisk disk_, PlatformAudio audio_, PlatformSocial social_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_Platform(Platform __hx_this, PlatformKind kind_, int width_, int height_, PlatformSys sys_, PlatformDisk disk_, PlatformAudio audio_, PlatformSocial social_)
		{
		}

		public static string convertLangSysCodeToDiskCode(PlatformDisk disk, string sysCode)
		{
			return null;
		}

		public static Platform makeDesktop(int width, int height, PlatformSys sys, PlatformDisk disk, PlatformAudio audio, PlatformSocial social)
		{
			return null;
		}

		public static Platform makePhone(int width, int height, PlatformSys sys, PlatformDisk disk, PlatformAudio audio, PlatformSocial social)
		{
			return null;
		}

		public virtual string resOverrideDir()
		{
			return null;
		}

		public virtual string decoratedVersion()
		{
			return null;
		}

		public virtual string defaultLanguageCode()
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
	}
}
