using app.vis;
using haxe.lang;

namespace data
{
	public class MogrifierHelper : HxObject
	{
		public MogrifierHelper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public MogrifierHelper()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_MogrifierHelper(MogrifierHelper __hx_this)
		{
		}

		public static bool wantProcessAfter_RifleSelection(string assetPath)
		{
			return false;
		}

		public static bool processAfterLoad_RifleSelection(Res res, string assetPath, Image image)
		{
			return false;
		}
	}
}
