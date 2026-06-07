using app.plat;
using haxe.lang;

namespace play
{
	public class Settings : HxObject
	{
		public static Array kDateFormats;

		public uint generation;

		public bool fullscreen;

		public double musicVolume;

		public double soundVolume;

		public bool nudity;

		public bool easyMode;

		public bool vibration;

		public int dateFormatIndex;

		public string languageCode;

		public bool endlessUnlocked;

		public string endlessIdStr;

		public EncryptedStore encryptedStore;

		public uint generationAtLoad;

		static Settings()
		{
		}

		public Settings(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Settings(EncryptedStore encryptedStore_, string defaultLanguageCode, bool defaultNudity)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_Settings(Settings __hx_this, EncryptedStore encryptedStore_, string defaultLanguageCode, bool defaultNudity)
		{
		}

		public static PlatformKind getPlatformKindOverride(PlatformDisk platformDisk)
		{
			return null;
		}

		public static void setPlatformKindOverride(PlatformDisk platformDisk, PlatformKind platformKindOverride)
		{
		}

		public DateFormat get_dateFormat()
		{
			return null;
		}

		public virtual void load()
		{
		}

		public virtual void save()
		{
		}

		public virtual string formatDate(double date, object @short)
		{
			return null;
		}

		public virtual bool set_nudity(bool v)
		{
			return false;
		}

		public virtual bool set_easyMode(bool v)
		{
			return false;
		}

		public virtual int set_dateFormatIndex(int v)
		{
			return 0;
		}

		public virtual bool set_endlessUnlocked(bool v)
		{
			return false;
		}

		public virtual string set_endlessIdStr(string v)
		{
			return null;
		}

		public virtual bool set_fullscreen(bool v)
		{
			return false;
		}

		public virtual double set_musicVolume(double v)
		{
			return 0.0;
		}

		public virtual double set_soundVolume(double v)
		{
			return 0.0;
		}

		public virtual string set_languageCode(string v)
		{
			return null;
		}

		public virtual bool set_vibration(bool v)
		{
			return false;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual bool setFromString(string str)
		{
			return false;
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
