using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
	[Header("Life")]
	public float life = 5f;

	[Header("Force")]
	public bool hasForce;

	[Tooltip("Explosion force strength")]
	public float forceValue = 500f;

	[Tooltip("Explosion radius")]
	public float forceRadius = 5f;

	[Tooltip("Optional upward modifier")]
	public float forceUpwards;

	[Tooltip("Which layers should receive explosion force (ex: Ragdoll)")]
	public LayerMask forceLayers;

	[Tooltip("If true, applies force once on enable. If false, applies right before disabling.")]
	public bool applyForceOnEnable = true;

	private Coroutine lifeRoutine;

	private void OnEnable()
	{
		if (applyForceOnEnable)
		{
			TryApplyExplosionForce();
		}
		lifeRoutine = StartCoroutine(ObjController());
	}

	private void OnDisable()
	{
		if (lifeRoutine != null)
		{
			StopCoroutine(lifeRoutine);
			lifeRoutine = null;
		}
	}

	private IEnumerator ObjController()
	{
		yield return new WaitForSeconds(life);
		if (!applyForceOnEnable)
		{
			TryApplyExplosionForce();
		}
		base.gameObject.SetActive(value: false);
	}

	public void TryApplyExplosionForce()
	{
		if (!hasForce || forceValue <= 0f || forceRadius <= 0f)
		{
			return;
		}
		Vector3 position = base.transform.position;
		Collider[] array = Physics.OverlapSphere(position, forceRadius, forceLayers, QueryTriggerInteraction.Ignore);
		if (array == null || array.Length == 0)
		{
			return;
		}
		HashSet<Rigidbody> hashSet = new HashSet<Rigidbody>();
		for (int i = 0; i < array.Length; i++)
		{
			Rigidbody attachedRigidbody = array[i].attachedRigidbody;
			if (!(attachedRigidbody == null) && hashSet.Add(attachedRigidbody))
			{
				attachedRigidbody.AddExplosionForce(forceValue, position, forceRadius, forceUpwards, ForceMode.Impulse);
			}
		}
	}
}
