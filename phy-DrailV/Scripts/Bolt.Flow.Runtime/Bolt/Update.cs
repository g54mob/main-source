namespace Bolt
{
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(3)]
	public sealed class Update : MachineEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "Update";
	}
}
