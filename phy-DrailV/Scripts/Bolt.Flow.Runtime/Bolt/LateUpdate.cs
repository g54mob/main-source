namespace Bolt
{
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(5)]
	public sealed class LateUpdate : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "LateUpdate";
	}
}
