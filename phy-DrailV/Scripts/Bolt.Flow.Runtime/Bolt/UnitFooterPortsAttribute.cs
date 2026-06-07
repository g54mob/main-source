using System;

namespace Bolt
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitFooterPortsAttribute : Attribute
	{
		public bool ControlInputs { get; set; }

		public bool ControlOutputs { get; set; }

		public bool ValueInputs { get; set; } = true;

		public bool ValueOutputs { get; set; } = true;
	}
}
