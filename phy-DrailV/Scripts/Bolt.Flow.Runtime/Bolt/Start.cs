namespace Bolt
{
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(2)]
	public sealed class Start : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "Start";
	}
}
