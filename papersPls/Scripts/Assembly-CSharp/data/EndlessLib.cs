using haxe.lang;

namespace data
{
	public class EndlessLib : HxObject
	{
		public Array styles;

		public Array courses;

		public EndlessLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndlessLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_EndlessLib(EndlessLib __hx_this, Res res)
		{
		}

		public EndlessStyle get_defaultStyle()
		{
			return null;
		}

		public EndlessCourse get_defaultCourse()
		{
			return null;
		}

		public virtual EndlessStyle getStyle(string id)
		{
			return null;
		}

		public virtual EndlessCourse getCourse(string id)
		{
			return null;
		}

		public virtual EndlessId getEndlessIdFromString(string str)
		{
			return null;
		}

		public virtual EndlessId getEndlessIdFromLeaderboardId(string leaderboardId)
		{
			return null;
		}

		public virtual Array getCourses()
		{
			return null;
		}

		public virtual Array getStyles()
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
