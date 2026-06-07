using Microsoft.Win32;
using UnityEngine.XR.OpenXR;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public static class OpenXRRuntime
	{
		public static string Name
		{
			get
			{
				string empty = string.Empty;
				string text = (Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Khronos\\OpenXR\\1", "ActiveRuntime", string.Empty) as string).ToLower();
				empty = (text.Contains("oculus") ? "OculusVR" : (text.Contains("steam") ? "SteamVR" : ((!text.Contains("mixed")) ? "Unknown" : "Windows Mixed Reality")));
				string name = UnityEngine.XR.OpenXR.OpenXRRuntime.name;
				if (!string.IsNullOrWhiteSpace(name))
				{
					return name;
				}
				return empty;
			}
		}
	}
}
