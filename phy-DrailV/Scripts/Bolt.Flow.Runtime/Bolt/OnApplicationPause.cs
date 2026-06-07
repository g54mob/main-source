namespace Bolt
{
	[UnitCategory("Events/Application")]
	public sealed class OnApplicationPause : GlobalEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "OnApplicationPause";
	}
}
