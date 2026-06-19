using System.Collections.Generic;
using UnityEngine;

public class GenericGUIElementLoaderBase : MonoBehaviour
{
	public List<GameObject> elementsToLoad = new List<GameObject>();

	private int elementsLoaded;

	public Inchworm.EaseStyle style = Inchworm.EaseStyle.QuadraticOut;

	public float scaleInTime = 0.15f;

	public float scaleOutTime = 0.15f;

	protected Segment currentEase;

	protected ScalableUIContainer.LoadCallback callback;

	protected Inchworm inchwormRef;

	private void Awake()
	{
		AwakeBehavior();
	}

	protected virtual void AwakeBehavior()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		base.transform.localScale = Vector3.zero;
	}

	public virtual void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		elementsLoaded = 0;
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		callback = loadCallback;
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, Vector3.one, scaleInTime, style, OnSelfLoadComplete);
	}

	public virtual void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		elementsLoaded = elementsToLoad.Count;
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		Clickable component = GetComponent<Clickable>();
		if (component != null)
		{
			component.ForceCancelEase();
			Object.Destroy(component);
		}
		callback = unloadCallback;
		for (int i = 0; i < elementsToLoad.Count; i++)
		{
			elementsToLoad[i].GetComponent<GenericGUIElementLoaderBase>().Unload(OnSubElementUnloaded);
		}
	}

	protected virtual void SelfUnload()
	{
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, Vector3.zero, scaleOutTime, style, OnUnloadComplete);
	}

	protected virtual void OnSelfLoadComplete()
	{
		currentEase = null;
		for (int i = 0; i < elementsToLoad.Count; i++)
		{
			elementsToLoad[i].GetComponent<GenericGUIElementLoaderBase>().Load(OnSubElementLoaded);
		}
		if (elementsToLoad.Count == 0)
		{
			OnLoadComplete();
		}
	}

	protected virtual void OnSubElementUnloaded()
	{
		elementsLoaded--;
		if (elementsLoaded <= 0)
		{
			SelfUnload();
		}
	}

	protected virtual void OnSubElementLoaded()
	{
		elementsLoaded++;
		if (elementsLoaded >= elementsToLoad.Count)
		{
			OnLoadComplete();
		}
	}

	protected virtual void OnLoadComplete()
	{
		currentEase = null;
		CallCallback();
	}

	protected virtual void OnUnloadComplete()
	{
		currentEase = null;
		CallCallback();
	}

	protected virtual void CallCallback()
	{
		if (callback != null)
		{
			callback();
			callback = null;
		}
	}
}
