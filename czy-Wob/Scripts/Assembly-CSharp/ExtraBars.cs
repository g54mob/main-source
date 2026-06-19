using System.Collections.Generic;
using UnityEngine;

public class ExtraBars : MonoBehaviour
{
	public GameObject bar1;

	public GameObject bar2;

	private ScalableUIContainer.LoadCallback callback;

	private float bar1InTime = 0.25f;

	private float bar2InTime = 0.25f;

	private float bar1OutTime = 0.2f;

	private float bar2OutTime = 0.2f;

	private float delayTime;

	private float inDelay = 0.1f;

	private float outDelay = 0.1f;

	private bool needsSecondEaseIn;

	private bool needsSecondEaseOut;

	private Vector3 easeVector = new Vector3(1.2f, -1.2f, 0f);

	private int numElements = 2;

	private int loadedElements;

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	private void Update()
	{
		CheckDelayedEases();
	}

	private void CheckDelayedEases()
	{
		if (needsSecondEaseIn)
		{
			delayTime += Time.deltaTime;
			if (delayTime >= inDelay)
			{
				bar2.SetActive(value: true);
				List<GameObject> objectsToEase = new List<GameObject> { bar2 };
				inchwormRef.RequestEase(objectsToEase, easeVector, bar2InTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, ElementLoadedCallback);
				needsSecondEaseIn = false;
			}
		}
		if (needsSecondEaseOut)
		{
			delayTime += Time.deltaTime;
			if (delayTime >= outDelay)
			{
				List<GameObject> objectsToEase2 = new List<GameObject> { bar1 };
				inchwormRef.RequestEase(objectsToEase2, -easeVector, bar1OutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, ElementUnloadedCallback);
				needsSecondEaseOut = false;
			}
		}
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		callback = loadCallback;
		List<GameObject> objectsToEase = new List<GameObject> { bar1 };
		inchwormRef.RequestEase(objectsToEase, easeVector, bar1InTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, ElementLoadedCallback);
		bar2.SetActive(value: false);
		delayTime = 0f;
		needsSecondEaseIn = true;
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		callback = unloadCallback;
		List<GameObject> objectsToEase = new List<GameObject> { bar2 };
		inchwormRef.RequestEase(objectsToEase, -easeVector, bar2OutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, ElementUnloadedCallback);
		delayTime = 0f;
		needsSecondEaseOut = true;
	}

	private void ElementLoadedCallback()
	{
		loadedElements++;
		if (loadedElements >= numElements)
		{
			OnLoadComplete();
		}
	}

	private void ElementUnloadedCallback()
	{
		loadedElements--;
		if (loadedElements <= 0)
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
