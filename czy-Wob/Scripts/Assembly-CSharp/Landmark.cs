using UnityEngine;

public class Landmark : MonoBehaviour
{
	public string landmarkName;

	private ScalableUIContainer.LoadCallback callback;

	private float scaleInTime = 0.25f;

	private float scaleOutTime = 0.25f;

	private Inchworm inchwormRef;

	private void Awake()
	{
		MapTravelInfo.ValidateLandmarkName(landmarkName);
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		base.transform.localScale = Vector3.zero;
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		callback = loadCallback;
		inchwormRef.RequestEaseToScale(base.gameObject, Vector3.one, scaleInTime, Inchworm.EaseStyle.QuadraticOut, OnLoadComplete);
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		callback = unloadCallback;
		inchwormRef.RequestEaseToScale(base.gameObject, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnUnloadComplete);
	}

	public void PreUnload()
	{
		if (base.gameObject.GetComponent<Clickable>() != null)
		{
			Object.Destroy(base.gameObject.GetComponent<Clickable>());
		}
	}

	private void OnLoadComplete()
	{
		callback();
		callback = null;
		if (!MapTravelInfo.IsLandmarkNameCurrent(landmarkName))
		{
			Clickable clickable = base.gameObject.AddComponent<Clickable>();
			clickable.SetClickCallbacks(OnLandmarkClicked);
			clickable.SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
			clickable.SetColliderRef(base.transform.parent.GetComponent<CircleCollider2D>());
		}
	}

	private void OnUnloadComplete()
	{
		callback();
		callback = null;
	}

	private void OnLandmarkClicked()
	{
		string sceneNameForLandmarkName = MapTravelInfo.GetSceneNameForLandmarkName(landmarkName);
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION).TransitionToScene(sceneNameForLandmarkName);
	}
}
