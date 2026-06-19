using UnityEngine;

public class DialogueBox : MonoBehaviour
{
	private Inchworm.EaseCallback currentCallback;

	public GameObject boxHolder;

	public GameObject nametagHolder;

	private int elementsLoaded;

	private int elementsTotal = 2;

	private bool isLoading;

	private bool isUnloading;

	private float currentOffset;

	private static float scaleInOffset = 0.1f;

	private static float scaleOutOffset = 0.1f;

	private static float scaleDurationIn = 0.35f;

	private static float scaleDurationOut = 0.15f;

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	private void Update()
	{
		if (isLoading && currentOffset < scaleInOffset)
		{
			currentOffset += Time.deltaTime;
			if (currentOffset >= scaleInOffset)
			{
				inchwormRef.RequestEaseToScale(nametagHolder, Vector3.one, scaleDurationIn, Inchworm.EaseStyle.ElasticOut, ElementLoadedCallback);
			}
		}
		else if (isUnloading && currentOffset < scaleOutOffset)
		{
			currentOffset += Time.deltaTime;
			if (currentOffset >= scaleOutOffset)
			{
				inchwormRef.RequestEaseToScale(boxHolder, Vector3.zero, scaleDurationOut, Inchworm.EaseStyle.InBack, ElementUnloadedCallback);
			}
		}
	}

	public void RequestScaleLoad(Inchworm.EaseCallback newCallback)
	{
		isLoading = true;
		currentOffset = 0f;
		elementsLoaded = 0;
		currentCallback = newCallback;
		boxHolder.SetActive(value: true);
		nametagHolder.SetActive(value: true);
		boxHolder.transform.localScale = Vector3.zero;
		nametagHolder.transform.localScale = Vector3.zero;
		inchwormRef.RequestEaseToScale(boxHolder, Vector3.one, scaleDurationIn, Inchworm.EaseStyle.ElasticOut, ElementLoadedCallback);
	}

	public void RequestScaleUnload(Inchworm.EaseCallback newCallback)
	{
		isUnloading = true;
		currentOffset = 0f;
		currentCallback = newCallback;
		inchwormRef.RequestEaseToScale(nametagHolder, Vector3.zero, scaleDurationOut, Inchworm.EaseStyle.InBack, ElementUnloadedCallback);
	}

	private void ElementLoadedCallback()
	{
		elementsLoaded++;
		if (elementsLoaded >= elementsTotal)
		{
			LoadFinished();
		}
	}

	private void ElementUnloadedCallback()
	{
		elementsLoaded--;
		if (elementsLoaded <= 0)
		{
			UnloadFinished();
		}
	}

	private void LoadFinished()
	{
		isLoading = false;
		currentCallback();
		currentCallback = null;
	}

	private void UnloadFinished()
	{
		isUnloading = false;
		currentCallback();
		currentCallback = null;
	}
}
