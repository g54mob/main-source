using haxe.lang;

namespace app.plat
{
	public class PlatformSys : HxObject
	{
		public bool wantExit;

		public PlatformSys(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSys()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSys(PlatformSys __hx_this)
		{
		}

		public virtual string osName()
		{
			return null;
		}

		public virtual void log(string str)
		{
		}

		public virtual double memUsage()
		{
			return 0.0;
		}

		public virtual void memFlush()
		{
		}

		public virtual bool canExit()
		{
			return false;
		}

		public virtual void requestExit()
		{
		}

		public virtual void openUrl(string url)
		{
		}

		public virtual void setFullscreen(bool fullscreen)
		{
		}

		public virtual bool getFullscreen()
		{
			return false;
		}

		public virtual string defaultLanguageISO639_1()
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
	}
}
