using UnityEngine;

[AddComponentMenu("Wwise/AkInitializer")]
[ExecuteAlways]
[DisallowMultipleComponent]
[DefaultExecutionOrder(-100)]
public class AkInitializer : MonoBehaviour
{
	private static AkInitializer ms_Instance;

	public AkWwiseInitializationSettings InitializationSettings;

	public static AkSurfaceReflector.GeometryData CubeGeometryData;

	public static AkSurfaceReflector.GeometryData SphereGeometryData;

	private void CreateRoomGeometryData()
	{
	}

	private void Awake()
	{
	}

	private bool IsInstance()
	{
		return false;
	}

	public static GameObject GetAkInitializerGameObject()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	public void InitializeInitializationSettings()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}

	private void OnApplicationFocus(bool focus)
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void LateUpdate()
	{
	}
}
