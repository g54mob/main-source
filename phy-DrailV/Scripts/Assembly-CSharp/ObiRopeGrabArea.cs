using Obi;
using UnityEngine;

public class ObiRopeGrabArea : MonoBehaviour
{
	public ObiRopeGrabAreaSolverMediator solverInterface;

	public Collider grabCollider;

	private ObiRopeInteractingInfo obiInteractionInfo;

	private void Start()
	{
		if (grabCollider == null || solverInterface == null)
		{
			Debug.LogError("grabCollider or solverInterface is null! Can't initialize interaction info! Destroying self");
			Object.Destroy(this);
		}
		else
		{
			grabCollider.gameObject.SetActive(value: false);
			InitializeInteractionInfo();
		}
	}

	private void InitializeInteractionInfo()
	{
		obiInteractionInfo = new ObiRopeInteractingInfo();
		ObiCollider obiCollider = grabCollider.GetComponent<ObiCollider>();
		if (obiCollider == null)
		{
			obiCollider = grabCollider.gameObject.AddComponent<ObiCollider>();
		}
		obiInteractionInfo.unityCollider = grabCollider;
		obiInteractionInfo.obiCollider = obiCollider;
	}

	public bool CanGrab()
	{
		return !solverInterface.HasCurrentInteraction();
	}

	public void StartGrab(Vector3 startWorldPosition)
	{
		if (!CanGrab())
		{
			Debug.LogError("Rope is already being interacted with, check CanGrab() before calling StartGrab", this);
			return;
		}
		UpdatePosition(startWorldPosition);
		grabCollider.gameObject.SetActive(value: true);
		solverInterface.SetupInteraction(obiInteractionInfo);
	}

	public void FeedPosition(Vector3 worldPosition)
	{
		if ((bool)obiInteractionInfo.touchingActor && !obiInteractionInfo.grabbedParticle.HasValue)
		{
			obiInteractionInfo.CreatePinConstraint();
		}
		UpdatePosition(worldPosition);
	}

	private void UpdatePosition(Vector3 worldPosition)
	{
		Vector3 vector = base.transform.InverseTransformPoint(worldPosition);
		if (vector.sqrMagnitude > 1f)
		{
			vector = Vector3.ClampMagnitude(vector, 1f);
		}
		grabCollider.transform.localPosition = vector;
	}

	public void EndGrab()
	{
		if (obiInteractionInfo.grabbedParticle.HasValue)
		{
			obiInteractionInfo.RemovePinConstraint();
			obiInteractionInfo.Clear();
		}
		solverInterface.ClearInteraction();
		grabCollider.gameObject.SetActive(value: false);
	}
}
