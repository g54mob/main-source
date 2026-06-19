using System.Collections.Generic;
using UnityEngine;

public class LandmarkGraphics : MonoBehaviour
{
	public GameObject activeLandmarkFlag;

	public List<GameObject> landmarkList;

	private ElementStatus currentStatus = ElementStatus.UNLOADED;

	private int currentLandmark;

	private float offsetTime;

	private float landmarkOffset = 0.05f;

	private int loadedLandmarks;

	private ScalableUIContainer.LoadCallback callback;

	private float flagScaleInTime = 0.15f;

	private float flagScaleOutTime = 0.1f;

	private Vector3 flagOffset = new Vector3(0f, 1.25f, 0f);

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		activeLandmarkFlag.transform.localScale = Vector3.zero;
	}

	private void Update()
	{
		if (currentStatus == ElementStatus.LOADING && currentLandmark < landmarkList.Count)
		{
			if (offsetTime >= landmarkOffset)
			{
				LoadNextLandmark();
			}
			offsetTime += Time.deltaTime;
		}
		else if (currentStatus == ElementStatus.UNLOADING && currentLandmark >= 0)
		{
			if (offsetTime >= landmarkOffset)
			{
				UnloadNextLandmark();
			}
			offsetTime += Time.deltaTime;
		}
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		currentStatus = ElementStatus.LOADING;
		offsetTime = 0f;
		currentLandmark = 0;
		callback = loadCallback;
		LoadNextLandmark();
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		currentStatus = ElementStatus.UNLOADING;
		for (int i = 0; i < landmarkList.Count; i++)
		{
			landmarkList[i].GetComponent<Landmark>().PreUnload();
		}
		offsetTime = 0f;
		callback = unloadCallback;
		currentLandmark = -1;
		inchwormRef.RequestEaseToScale(activeLandmarkFlag, Vector3.zero, flagScaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnFlagUnloaded);
	}

	private void LoadNextLandmark()
	{
		landmarkList[currentLandmark].GetComponent<Landmark>().Load(OnElementLoadedCallback);
		currentLandmark++;
		offsetTime = 0f;
	}

	private void UnloadNextLandmark()
	{
		landmarkList[currentLandmark].GetComponent<Landmark>().Unload(OnElementUnloadedCallback);
		currentLandmark--;
		offsetTime = 0f;
	}

	private void OnElementLoadedCallback()
	{
		loadedLandmarks++;
		if (loadedLandmarks >= landmarkList.Count)
		{
			OnLandmarksLoaded();
		}
	}

	private void OnElementUnloadedCallback()
	{
		loadedLandmarks--;
		if (loadedLandmarks <= 0)
		{
			OnUnloadComplete();
		}
	}

	private void OnLandmarksLoaded()
	{
		for (int i = 0; i < landmarkList.Count; i++)
		{
			if (MapTravelInfo.IsLandmarkNameCurrent(landmarkList[i].GetComponent<Landmark>().landmarkName))
			{
				activeLandmarkFlag.transform.SetParent(landmarkList[i].transform);
				activeLandmarkFlag.transform.localPosition = flagOffset;
				break;
			}
		}
		inchwormRef.RequestEaseToScale(activeLandmarkFlag, Vector3.one, flagScaleInTime, Inchworm.EaseStyle.QuadraticOut, OnLoadComplete);
	}

	private void OnFlagUnloaded()
	{
		currentLandmark = landmarkList.Count - 1;
		UnloadNextLandmark();
	}

	private void OnLoadComplete()
	{
		currentStatus = ElementStatus.LOADED;
		callback();
		callback = null;
	}

	private void OnUnloadComplete()
	{
		currentStatus = ElementStatus.UNLOADED;
		callback();
		callback = null;
	}
}
