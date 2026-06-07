namespace Bolt
{
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(4)]
	public sealed class FixedUpdate : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "FixedUpdate";
	}
}
