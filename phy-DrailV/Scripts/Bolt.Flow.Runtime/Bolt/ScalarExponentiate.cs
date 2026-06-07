using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Exponentiate")]
	[UnitOrder(105)]
	public sealed class ScalarExponentiate : Unit
	{
		[DoNotSerialize]
		[PortLabel("x")]
		public ValueInput @base { get; private set; }

		[DoNotSerialize]
		[PortLabel("n")]
		public ValueInput exponent { get; private set; }

		[DoNotSerialize]
		[PortLabel("xⁿ")]
		public ValueOutput power { get; private set; }

		protected override void Definition()
		{
			@base = ValueInput("base", 1f);
			exponent = ValueInput("exponent", 2f);
			power = ValueOutput("power", Exponentiate);
			Requirement(@base, power);
			Requirement(exponent, power);
		}

		public float Exponentiate(Flow flow)
		{
			return Mathf.Pow(flow.GetValue<float>(@base), flow.GetValue<float>(exponent));
		}
	}
}
