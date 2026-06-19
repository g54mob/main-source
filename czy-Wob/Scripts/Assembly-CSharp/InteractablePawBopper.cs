using System.Collections;
using UnityEngine;

public class InteractablePawBopper : InteractableBase
{
	public Rigidbody bopBody;

	public Transform castTransform;

	public Transform bopForceTransform;

	private float bopForce = -10000f;

	private float bopCheckChance = 0.01f;

	private string bopperHitSound = "bopper_hit";

	private float customHitMinVelocity = 25f;

	private float customHitMaxVelocity = 50f;

	private Coroutine currentBopRoutine;

	private void Start()
	{
		bopBody.GetComponent<CollisionSound>().SetCustomCollisionSound(bopperHitSound, null, customHitMinVelocity, customHitMaxVelocity);
	}

	private void OnDestroy()
	{
		if (currentBopRoutine != null)
		{
			StopCoroutine(currentBopRoutine);
			currentBopRoutine = null;
		}
	}

	public void OnDogInTriggerArea(Collider collider)
	{
		if (currentBopRoutine == null && !(Random.value > bopCheckChance))
		{
			Bop(bopBody.transform.position - collider.transform.position);
		}
	}

	private void Bop(Vector3? customBopVector = null)
	{
		if (currentBopRoutine == null)
		{
			currentBopRoutine = StartCoroutine(BopRoutine(customBopVector));
		}
	}

	private IEnumerator BopRoutine(Vector3? customBopVector = null)
	{
		Vector3 bopVector = ((!customBopVector.HasValue) ? (-bopForceTransform.forward) : customBopVector.Value);
		WaitForFixedUpdate fixedUpdateWait = new WaitForFixedUpdate();
		float bopForceTimer = 0.05f;
		float bopForceMax = bopForceTimer;
		while (bopForceTimer > 0f)
		{
			yield return fixedUpdateWait;
			bopForceTimer -= Time.fixedDeltaTime;
			bopBody.AddForceAtPosition(bopForce * (Mathf.Max(bopForceTimer, 0f) / bopForceMax) * bopVector, bopForceTransform.position);
		}
		bopForceTimer = 0.15f;
		while (bopForceTimer > 0f)
		{
			yield return fixedUpdateWait;
			bopForceTimer -= Time.fixedDeltaTime;
			bopBody.AddForceAtPosition(bopForce * bopVector, bopForceTransform.position);
		}
		yield return new WaitForSeconds(2.5f);
		currentBopRoutine = null;
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		Bop(biteVector.normalized);
	}
}
