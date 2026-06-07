public static class JunctionExtensions
{
	public static JunctionSwitchRemoteControllable RemoteControllable(this Junction j)
	{
		return j.transform.parent.GetComponentInChildren<JunctionSwitchRemoteControllable>(includeInactive: true);
	}
}
