using UnityEngine;

public class StandardGUIElementLoader : MonoBehaviour
{
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
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		callback = loadCallback;
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, Vector3.one, scaleInTime, Inchworm.EaseStyle.QuadraticOut, OnLoadComplete);
	}

	public virtual void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
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
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnUnloadComplete);
	}

	protected virtual void OnLoadComplete()
	{
		currentEase = null;
		callback();
		callback = null;
	}

	protected virtual void OnUnloadComplete()
	{
		currentEase = null;
		callback();
		callback = null;
	}
}
