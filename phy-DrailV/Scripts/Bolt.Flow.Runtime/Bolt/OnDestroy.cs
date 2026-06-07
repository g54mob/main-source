namespace Bolt
{
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(7)]
	public sealed class OnDestroy : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "OnDestroy";
	}
}
