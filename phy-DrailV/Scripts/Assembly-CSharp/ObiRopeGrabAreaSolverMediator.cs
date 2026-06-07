using Obi;
using UnityEngine;

[RequireComponent(typeof(ObiSolver))]
public class ObiRopeGrabAreaSolverMediator : MonoBehaviour
{
	private ObiSolver solver;

	private ObiRopeInteractingInfo interactionInfoToUpdate;

	private void Awake()
	{
		solver = GetComponent<ObiSolver>();
		if (solver == null)
		{
			Debug.LogError("ObiRopeGrabAreaSolverMediator couldn't find ObiSolver", base.gameObject);
			Object.Destroy(this);
		}
	}

	public bool HasCurrentInteraction()
	{
		return interactionInfoToUpdate != null;
	}

	public void SetupInteraction(ObiRopeInteractingInfo infoToUpdate)
	{
		if (interactionInfoToUpdate != null)
		{
			Debug.LogError("interactionInfoToUpdate has to be null, when SetupInteraction is called! Clearing current interaction info in order to recover");
			ClearInteraction();
		}
		interactionInfoToUpdate = infoToUpdate;
		solver.OnCollision += HandleSolverCollision;
	}

	public void ClearInteraction()
	{
		solver.OnCollision -= HandleSolverCollision;
		interactionInfoToUpdate = null;
	}

	private void HandleSolverCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
	{
		if (interactionInfoToUpdate == null || e == null || e.contacts == null)
		{
			return;
		}
		interactionInfoToUpdate.Clear();
		for (int i = 0; i < e.contacts.Length; i++)
		{
			Oni.Contact contact = e.contacts[i];
			if (contact.distance < 0.01f)
			{
				Collider collider = ObiColliderBase.idToCollider[contact.other] as Collider;
				if (!interactionInfoToUpdate.grabbedParticle.HasValue && interactionInfoToUpdate.unityCollider == collider)
				{
					ObiSolver.ParticleInActor obj = solver.particleToActor[e.contacts[i].particle];
					ObiActor actor = obj.actor;
					int indexInActor = obj.indexInActor;
					interactionInfoToUpdate.touchingParticle = indexInActor;
					interactionInfoToUpdate.touchingActor = actor;
				}
			}
		}
	}
}
