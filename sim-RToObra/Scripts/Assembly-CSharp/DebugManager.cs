public class DebugManager
{
	public static void AddPreUpdateFuncs()
	{
		PreUpdater.Add(DebugDrawer.FlushIfNecessary);
		PreUpdater.Add(DebugMenu.Update);
	}
}
