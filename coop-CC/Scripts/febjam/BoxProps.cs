using Aggro.Core;
using UnityEngine;

public class BoxProps : EntityBehaviourBase
{
	public PhysicMaterial normalPhysicsMaterial;

	[Header("Heavy")]
	[Min(0f)]
	public float heavyMass = 2f;

	[Header("Bouncy")]
	public PhysicMaterial bouncyPhysicsMaterial;

	[Header("Links")]
	public Collider boxCollider;

	[Header("Achievements")]
	public string onTrashCompactedId;

	[SerializeField]
	private bool _infoIsSafe;

	private bool _physMatSet;

	public bool serverIsSafe { get; set; }

	protected override void OnEntityStart()
	{
		if (base.entity.tags.Has(CCTags.TAG_HEAVY))
		{
			base.entity.rigidbody.mass = heavyMass;
		}
		if (base.entity.tags.Has(CCTags.TAG_BOUNCY))
		{
			boxCollider.sharedMaterial = bouncyPhysicsMaterial;
		}
	}

	[UpdateInGroup(UpdatePriority.Early)]
	protected override void OnUpdateSimulationEarly()
	{
		if (base.isServer)
		{
			serverIsSafe = false;
		}
	}

	public void SetPhysicsMaterial(PhysicMaterial physMat)
	{
		if (boxCollider.sharedMaterial != physMat)
		{
			boxCollider.sharedMaterial = physMat;
			_physMatSet = true;
		}
	}

	public void ResetPhysicsMaterial()
	{
		if (_physMatSet)
		{
			_physMatSet = false;
			if (base.entity.tags.Has(CCTags.TAG_BOUNCY))
			{
				boxCollider.sharedMaterial = bouncyPhysicsMaterial;
			}
			else
			{
				boxCollider.sharedMaterial = normalPhysicsMaterial;
			}
		}
	}
}
