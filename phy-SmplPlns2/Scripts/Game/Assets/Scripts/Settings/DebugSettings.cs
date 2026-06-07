using UnityEngine;

namespace Assets.Scripts.Settings
{
	public static class DebugSettings
	{
		public static bool XRControllerLogs => !Application.isEditor;
	}
}
