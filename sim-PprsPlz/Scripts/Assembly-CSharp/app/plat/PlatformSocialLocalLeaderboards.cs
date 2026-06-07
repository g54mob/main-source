using haxe.lang;

namespace app.plat
{
	public class PlatformSocialLocalLeaderboards : PlatformSocialLocal_app_plat_PlatformSocialLeaderboardScore
	{
		public PlatformSocialService service;

		public PlatformSocialLocalLeaderboards(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSocialLocalLeaderboards(Array ids_, PlatformSocialService service_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSocialLocalLeaderboards(PlatformSocialLocalLeaderboards __hx_this, Array ids_, PlatformSocialService service_)
		{
		}

		public override void push(string id, PlatformSocialLeaderboardScore value)
		{
		}

		public override void pull()
		{
		}

		public override bool matches(PlatformSocialLeaderboardScore a, PlatformSocialLeaderboardScore b)
		{
			return false;
		}

		public override void set(string id, PlatformSocialLeaderboardScore value, bool fromPush)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
