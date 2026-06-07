using System;
using Obi;
using UnityEngine;

public class ObiRopeNegateVelocity : MonoBehaviour
{
	private const float MAGIC_TWEAK = 1.5f;

	public ObiRope rope;

	private Rigidbody rb;

	private Vector4[] vel = new Vector4[1];

	private void Awake()
	{
		if (rope == null)
		{
			rope = GetComponent<ObiRope>();
		}
		if (rope == null)
		{
			Debug.LogWarning("ObiRopeNegateVelocity doesn't have a rope assigned, destroying self.", this);
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			rope.OnAddedToSolver += OnAddedToSolver;
			rope.OnRemovedFromSolver += OnRemovedFromSolver;
		}
	}

	private void OnEnable()
	{
		if (rope.Solver == null)
		{
			Debug.LogWarning("ObiRopeNegateVelocity got rope that doesn't have a solver assigned, disabling self.", this);
			base.enabled = false;
			return;
		}
		if (!rope.InSolver)
		{
			base.enabled = false;
			return;
		}
		rb = GetComponentInParent<Rigidbody>();
		if (rb == null)
		{
			Debug.LogWarning("ObiRopeNegateVelocity doesn't have a Rigidbody in any of the parents, disabling self.", this);
			base.enabled = false;
		}
		else
		{
			rope.Solver.OnFrameEnd += OnSolverFrame;
		}
	}

	private void OnDisable()
	{
		rope.Solver.OnFrameEnd -= OnSolverFrame;
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && !(rope == null))
		{
			rope.OnAddedToSolver -= OnAddedToSolver;
			rope.OnRemovedFromSolver -= OnRemovedFromSolver;
		}
	}

	private void OnAddedToSolver(object _, ObiActor.ObiActorSolverArgs __)
	{
		base.enabled = true;
	}

	private void OnRemovedFromSolver(object _, ObiActor.ObiActorSolverArgs __)
	{
		base.enabled = false;
	}

	private void OnSolverFrame(object _, EventArgs __)
	{
		if (!rope.InSolver)
		{
			base.enabled = false;
		}
		else
		{
			if (rb.isKinematic)
			{
				return;
			}
			IntPtr oniSolver = rope.Solver.OniSolver;
			Vector4 vector = rb.velocity * Time.fixedDeltaTime * 1.5f;
			for (int i = 0; i < rope.UsedParticles; i++)
			{
				if (rope.invMasses[i] != 0f)
				{
					int num = rope.particleIndices[i];
					Oni.GetParticleVelocities(oniSolver, vel, 1, num);
					vel[0] += vector;
					Oni.SetParticleVelocities(oniSolver, vel, 1, num);
				}
			}
		}
	}
}
