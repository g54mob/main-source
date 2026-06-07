using UnityEngine;

public class OVRRuntimeSettings : ScriptableObject
{
	public OVRManager.ColorSpace colorSpace = OVRManager.ColorSpace.Rift_CV1;

	public static OVRRuntimeSettings GetRuntimeSettings()
	{
		OVRRuntimeSettings oVRRuntimeSettings = null;
		oVRRuntimeSettings = Resources.Load<OVRRuntimeSettings>("OculusRuntimeSettings");
		if (oVRRuntimeSettings == null)
		{
			Debug.LogWarning("Failed to load runtime settings. Using default runtime settings instead.");
			oVRRuntimeSettings = ScriptableObject.CreateInstance<OVRRuntimeSettings>();
		}
		return oVRRuntimeSettings;
	}
}
