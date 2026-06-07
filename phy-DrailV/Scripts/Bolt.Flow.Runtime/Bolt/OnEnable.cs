namespace Bolt
{
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(1)]
	public sealed class OnEnable : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "OnEnable";
	}
}
