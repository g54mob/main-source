using haxe.lang;

namespace app.plat
{
	public class PlatformSocialLocalAchievements : PlatformSocialLocal_Bool
	{
		public PlatformSocialService service;

		public PlatformSocialLocalAchievements(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSocialLocalAchievements(Array ids_, PlatformSocialService service_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSocialLocalAchievements(PlatformSocialLocalAchievements __hx_this, Array ids_, PlatformSocialService service_)
		{
		}

		public override void push(string id, bool value)
		{
		}

		public override void pull()
		{
		}

		public override bool matches(bool a, bool b)
		{
			return false;
		}

		public virtual bool hasValueTrue(string id)
		{
			return false;
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
