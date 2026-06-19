using UnityEngine;

public class InteractableSnowglobe : InteractableBase
{
	public InchwormBounce bouncerRef;

	public ParticleSystem particlesRef;

	public Transform interactionPointTransform;

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		ShakeGlobe();
	}

	public void ShakeGlobe()
	{
		particlesRef.Play();
		bouncerRef.RequestBounce();
	}

	public override bool HasCustomInteractionPoint()
	{
		return true;
	}

	public override Vector3 GetInteractionPoint()
	{
		return interactionPointTransform.position;
	}

	public override Transform GetInteractionPointTransform()
	{
		return interactionPointTransform;
	}
}
