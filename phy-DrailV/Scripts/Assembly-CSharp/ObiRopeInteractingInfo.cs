using Obi;
using UnityEngine;

public class ObiRopeInteractingInfo
{
	public Vector3 pinOffset;

	public float stiffness = 1f;

	public Collider unityCollider;

	public ObiCollider obiCollider;

	public ObiActor touchingActor;

	public int touchingParticle;

	public int? grabbedParticle;

	public int? pinIndex;

	public ObiPinConstraints activePinConstraints;

	public void Clear()
	{
		touchingActor = null;
		touchingParticle = -1;
	}

	public void CreatePinConstraint()
	{
		activePinConstraints = touchingActor.GetComponent<ObiPinConstraints>();
		ObiPinConstraintBatch obiPinConstraintBatch = activePinConstraints.GetBatches()[0] as ObiPinConstraintBatch;
		activePinConstraints.RemoveFromSolver(null);
		pinIndex = obiPinConstraintBatch.ConstraintCount;
		grabbedParticle = touchingParticle;
		obiPinConstraintBatch.AddConstraint(grabbedParticle.Value, obiCollider, pinOffset, stiffness);
		activePinConstraints.AddToSolver(null);
		activePinConstraints.PushDataToSolver();
	}

	public void RemovePinConstraint()
	{
		ObiPinConstraintBatch obiPinConstraintBatch = activePinConstraints.GetBatches()[0] as ObiPinConstraintBatch;
		activePinConstraints.RemoveFromSolver(null);
		if (pinIndex.HasValue)
		{
			obiPinConstraintBatch.RemoveConstraint(pinIndex.Value);
			pinIndex = null;
		}
		activePinConstraints.AddToSolver(null);
		activePinConstraints.PushDataToSolver();
		grabbedParticle = null;
		activePinConstraints = null;
	}
}
