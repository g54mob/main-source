using Ludiq;

namespace Bolt
{
	[UnitCategory("Math/Generic")]
	[UnitTitle("Subtract")]
	public sealed class GenericSubtract : Subtract<object>
	{
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Subtract(a, b);
		}
	}
}
