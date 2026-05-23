using haxe.lang;

namespace data
{
	public class EndlessId : HxObject
	{
		public string styleId;

		public string courseId;

		public EndlessLib endlessLib;

		public EndlessId(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndlessId(EndlessLib endlessLib_, string styleId_, string courseId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_EndlessId(EndlessId __hx_this, EndlessLib endlessLib_, string styleId_, string courseId_)
		{
		}

		public EndlessStyle getStyle()
		{
			return null;
		}

		public EndlessCourse getCourse()
		{
			return null;
		}

		public bool isEqual(EndlessId other)
		{
			return false;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual string toLeaderboardId()
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

		public override string ToString()
		{
			return null;
		}
	}
}
