using haxe.lang;

namespace data
{
	public class StampApproval : HxObject
	{
		public int flags;

		public StampApproval(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StampApproval(StampApprovalKind approvalType)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_StampApproval(StampApproval __hx_this, StampApprovalKind approvalType)
		{
		}

		public static StampApproval fromString(string str)
		{
			return null;
		}

		public static StampApproval combine(StampApproval a, StampApproval b)
		{
			return null;
		}

		public bool get(StampApprovalKind t)
		{
			return false;
		}

		public virtual void set(StampApprovalKind t)
		{
		}

		public bool isApproved()
		{
			return false;
		}

		public bool isDenied()
		{
			return false;
		}

		public bool isReasoned()
		{
			return false;
		}

		public bool isApprovedOrDenied()
		{
			return false;
		}

		public virtual string toString()
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

		public override string ToString()
		{
			return null;
		}
	}
}
