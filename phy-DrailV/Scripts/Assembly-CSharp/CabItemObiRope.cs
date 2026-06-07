using System.Collections;
using Obi;
using UnityEngine;

public class CabItemObiRope : CabItemRigidbody
{
	public int particleIndexToAffect;

	public float forceMultiplier = 10f;

	private ObiRope rope;

	private ObiSolver solver;

	private int[] particleIndices;

	private Vector4 force;

	private bool initialized;

	public float debugForce = 10f;

	[InspectorButton("Boop", true, true)]
	public bool applyDebugForce;

	private void Boop()
	{
		Vector4 vector = Random.onUnitSphere;
		ApplyForce(vector * debugForce);
	}

	private IEnumerator Start()
	{
		Init();
		yield return null;
		rope = base.gameObject.GetComponent<ObiRope>();
		solver = rope.Solver;
		if (rope.particleIndices.Length == 0)
		{
			Debug.LogWarning("CabItemObiRope has rope with no particles, deleting component", base.gameObject);
			Object.Destroy(this);
			yield break;
		}
		Mathf.Clamp(particleIndexToAffect, 0, rope.particleIndices.Length - 1);
		particleIndices = new int[1] { rope.particleIndices[particleIndexToAffect] };
		initialized = true;
	}

	private void FixedUpdate()
	{
		if (initialized && !assumeIsPaused && receiveForces)
		{
			Vector3 velocity = base.ReceiveForcesFrom.velocity;
			force.Set(velocity.x - prevAppliedVelocity.x, velocity.y - prevAppliedVelocity.y, velocity.z - prevAppliedVelocity.z, 0f);
			force *= forceMultiplier;
			ApplyForce(force);
			prevAppliedVelocity = velocity;
		}
	}

	public void ApplyForce(Vector4 force)
	{
		if ((bool)solver)
		{
			Oni.AddParticleExternalForce(solver.OniSolver, ref force, particleIndices, 1);
		}
	}

	protected override bool ShouldAddRespawnOnDrop()
	{
		return false;
	}
}
