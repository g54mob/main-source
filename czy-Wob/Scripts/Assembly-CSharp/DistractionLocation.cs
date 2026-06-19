using UnityEngine;

public class DistractionLocation : DistractionBase
{
	protected Vector3 targetLocation;

	protected GameObject distractionLocationTarget;

	protected DogBehaviorBase walkToLocationBehavior;

	private float targetRadius = 2f;

	public DistractionLocation(DogAI newAIRef, float newWeight, Vector3 location)
		: base(newAIRef, newWeight)
	{
		priority = DistractionPriority.HIGH;
		targetLocation = location;
		walkToLocationBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.LOCATION_TRANSFORM][0];
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null)
		{
			aiRef.OnDistractionDone(this);
		}
	}

	public override bool FindNewBehavior(bool forceInterrupt)
	{
		distractionLocationTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		distractionLocationTarget.name = "DistractionLocation Target Object";
		distractionLocationTarget.transform.localScale = new Vector3(targetRadius, targetRadius, targetRadius);
		distractionLocationTarget.GetComponent<Renderer>().enabled = false;
		distractionLocationTarget.GetComponent<Collider>().isTrigger = true;
		distractionLocationTarget.transform.position = targetLocation + Vector3.up * 0.1f;
		currentRunningBehavior = walkToLocationBehavior;
		bool num = aiRef.TryRunBehavior(currentRunningBehavior, distractionLocationTarget, forceInterrupt);
		if (!num)
		{
			aiRef.OnDistractionDone(this);
		}
		return num;
	}

	public override void PreDestroy()
	{
		base.PreDestroy();
		Object.Destroy(distractionLocationTarget);
	}
}
