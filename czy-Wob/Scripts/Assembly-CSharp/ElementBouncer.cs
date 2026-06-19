using System.Collections.Generic;
using UnityEngine;

public class ElementBouncer : MonoBehaviour
{
	public delegate void ElementBouncerCallback();

	private ElementBouncerCallback currentCallback;

	private float defaultBounceTime = 0.75f;

	private Vector3 startingScale = Vector3.one;

	private Segment activeBounce;

	private List<BounceRequest> bounceQueue = new List<BounceRequest>();

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public void RequestBounceIn(Inchworm.EaseStyle easeStyle = Inchworm.EaseStyle.ElasticOut, ElementBouncerCallback callback = null)
	{
		RequestBounce(Vector3.zero, startingScale, defaultBounceTime, overwriteExistingBounces: true, easeStyle, callback);
	}

	public void RequestBounceOut(Inchworm.EaseStyle easeStyle = Inchworm.EaseStyle.ElasticOut, ElementBouncerCallback callback = null)
	{
		RequestBounce(startingScale, Vector3.zero, defaultBounceTime, overwriteExistingBounces: true, easeStyle, callback);
	}

	public void RequestBounce(Vector3 startScale, Vector3 endScale, float time, bool overwriteExistingBounces = false, Inchworm.EaseStyle easeStyle = Inchworm.EaseStyle.ElasticOut, ElementBouncerCallback callback = null)
	{
		BounceRequest bounceRequest = new BounceRequest(startScale, endScale, time, overwriteExistingBounces, easeStyle, callback);
		if (overwriteExistingBounces)
		{
			ClearAllBounces();
		}
		else if (activeBounce != null)
		{
			bounceQueue.Add(bounceRequest);
			return;
		}
		ProcessBounceRequest(bounceRequest);
	}

	private void ProcessBounceRequest(BounceRequest request)
	{
		ProcessCallback();
		currentCallback = request.callback;
		base.transform.localScale = request.startScale;
		activeBounce = inchwormRef.RequestEaseToScale(base.gameObject, request.endScale, request.time, request.easeStyle, OnBounceFinished);
	}

	private void ProcessCallback()
	{
		if (currentCallback != null)
		{
			ElementBouncerCallback elementBouncerCallback = currentCallback;
			currentCallback = null;
			elementBouncerCallback();
		}
	}

	private void ClearAllBounces()
	{
		if (activeBounce != null)
		{
			inchwormRef.CancelAndFinishEase(ref activeBounce);
			activeBounce = null;
		}
		bounceQueue.Clear();
	}

	private void OnBounceFinished()
	{
		ProcessCallback();
		activeBounce = null;
		if (bounceQueue.Count > 0)
		{
			BounceRequest request = bounceQueue[0];
			bounceQueue.RemoveAt(0);
			ProcessBounceRequest(request);
		}
	}
}
