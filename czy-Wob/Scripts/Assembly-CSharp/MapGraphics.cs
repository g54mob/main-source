using UnityEngine;

public class MapGraphics : MonoBehaviour
{
	public GameObject mapRoads;

	public GameObject landmarks;

	private ScalableUIContainer.LoadCallback callback;

	private float scaleInTime = 0.15f;

	private float scaleOutTime = 0.1f;

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		mapRoads.transform.localScale = Vector3.zero;
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		callback = loadCallback;
		inchwormRef.RequestEaseToScale(mapRoads, Vector3.one, scaleInTime, Inchworm.EaseStyle.QuadraticOut, OnRoadsLoadedCallback);
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		callback = unloadCallback;
		landmarks.GetComponent<LandmarkGraphics>().Unload(OnLandmarksUnloadedCallback);
	}

	private void OnRoadsLoadedCallback()
	{
		landmarks.GetComponent<LandmarkGraphics>().Load(OnLoadComplete);
	}

	private void OnLandmarksUnloadedCallback()
	{
		inchwormRef.RequestEaseToScale(mapRoads, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnUnloadComplete);
	}

	private void OnLoadComplete()
	{
		callback();
		callback = null;
	}

	private void OnUnloadComplete()
	{
		callback();
		callback = null;
	}
}
