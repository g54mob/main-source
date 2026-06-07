using Ludiq;

namespace Bolt
{
	[UnitCategory("Math/Generic")]
	[UnitTitle("Add")]
	public sealed class GenericAdd : Add<object>
	{
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Add(a, b);
		}
	}
}
