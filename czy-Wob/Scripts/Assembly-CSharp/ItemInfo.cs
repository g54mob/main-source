using UnityEngine;

public class ItemInfo : MonoBehaviour
{
	public GameObject itemBox;

	public GameObject itemCircle;

	public GameObject itemPreview;

	private ScalableUIContainer.LoadCallback callback;

	private float circleScaleInTime = 0.2f;

	private float circleScaleOutTime = 0.2f;

	private float boxScaleInTime = 0.2f;

	private float boxScaleOutTime = 0.2f;

	private float previewScaleInTime = 0.2f;

	private float previewScaleOutTime = 0.2f;

	private Vector3 targetPreviewScale;

	private int elementsLoaded;

	private int elementsToLoad = 3;

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		itemBox.transform.localScale = Vector3.zero;
		itemCircle.transform.localScale = Vector3.zero;
		targetPreviewScale = itemPreview.transform.localScale;
		itemPreview.transform.localScale = Vector3.zero;
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		callback = loadCallback;
		inchwormRef.RequestEaseToScale(itemBox, Vector3.one, boxScaleInTime, Inchworm.EaseStyle.QuadraticOut, OnElementLoadedCallback);
		inchwormRef.RequestEaseToScale(itemCircle, Vector3.one, circleScaleInTime, Inchworm.EaseStyle.QuadraticOut, OnElementLoadedCallback);
		inchwormRef.RequestEaseToScale(itemPreview, targetPreviewScale, previewScaleInTime, Inchworm.EaseStyle.QuadraticOut, OnElementLoadedCallback);
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		callback = unloadCallback;
		inchwormRef.RequestEaseToScale(itemBox, Vector3.zero, boxScaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnElementUnloadedCallback);
		inchwormRef.RequestEaseToScale(itemCircle, Vector3.zero, circleScaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnElementUnloadedCallback);
		inchwormRef.RequestEaseToScale(itemPreview, Vector3.zero, previewScaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnElementUnloadedCallback);
	}

	private void OnElementLoadedCallback()
	{
		elementsLoaded++;
		if (elementsLoaded >= elementsToLoad)
		{
			OnLoadComplete();
		}
	}

	private void OnElementUnloadedCallback()
	{
		elementsLoaded--;
		if (elementsLoaded <= 0)
		{
			OnUnloadComplete();
		}
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
