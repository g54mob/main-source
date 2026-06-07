using Assets.Scripts.Flight.Combat;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class TargetProxy
	{
		private TrackedTarget _trackedTarget;

		public float Distance => _trackedTarget.Distance;

		public string Name => _trackedTarget.Target.Name;

		[MoonSharpHidden]
		public TargetProxy(TrackedTarget trackedTarget, ProxyFactory factory)
		{
			_trackedTarget = trackedTarget;
		}
	}
}
