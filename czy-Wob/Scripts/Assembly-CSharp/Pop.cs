using UnityEngine;

public class Pop : MonoBehaviour
{
	private float popTime = 0.5f;

	private float popForce = -10f;

	private Segment currentEase;

	private Vector3 popScale = new Vector3(1f, 0.1f, 1f);

	private Collider selfCollider;

	private Inchworm inchwormRef;

	private void Start()
	{
		selfCollider = GetComponent<Collider>();
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	private void OnCollisionEnter(Collision c)
	{
		if (currentEase == null && selfCollider.enabled && !(c.relativeVelocity.y > popForce) && c.transform.root.gameObject.layer != RaycastUtil.stageLayer)
		{
			base.transform.root.localScale = popScale;
			currentEase = inchwormRef.RequestEaseToScale(base.transform.root.gameObject, Vector3.one, popTime, Inchworm.EaseStyle.ElasticOut, PopFinished);
		}
	}

	private void OnDestroy()
	{
		if (currentEase != null && inchwormRef != null)
		{
			CancelEase();
		}
	}

	private void CancelEase()
	{
		inchwormRef.CancelAndFinishEase(ref currentEase);
		currentEase = null;
	}

	private void PopFinished()
	{
		currentEase = null;
	}
}
