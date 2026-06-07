using Ludiq;

namespace Bolt
{
	[UnitCategory("Math/Generic")]
	[UnitTitle("Multiply")]
	public sealed class GenericMultiply : Multiply<object>
	{
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Multiply(a, b);
		}
	}
}
