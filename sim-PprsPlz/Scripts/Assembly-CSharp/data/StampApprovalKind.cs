using haxe.lang;

namespace data
{
	public class StampApprovalKind : Enum
	{
		public static readonly StampApprovalKind NONE;

		public static readonly StampApprovalKind APPROVED;

		public static readonly StampApprovalKind DENIED;

		public static readonly StampApprovalKind REASONED;

		protected static readonly string[] __hx_constructs;

		protected StampApprovalKind(int index)
			: base(0)
		{
		}
	}
}
