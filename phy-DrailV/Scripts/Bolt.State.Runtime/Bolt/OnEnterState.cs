namespace Bolt
{
	[UnitCategory("Events/State")]
	public class OnEnterState : ManualEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "OnEnterState";
	}
}
