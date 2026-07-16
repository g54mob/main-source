using System;
using System.Collections;
using UnityEngine;

public class CharacterItemSocket : MonoBehaviour
{
	[SerializeField]
	private Transform trackTransform;

	private GameObject socketObject;

	private Transform impactPoint;

	[SerializeField]
	private ParticleSystem hitParticles;

	public void UpdateSocket(ItemInfo info)
	{
		ClearSocket();
		if (!(info.prefab == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(info.prefab, trackTransform);
			gameObject.transform.localPosition = Vector3.zero;
			socketObject = gameObject;
		}
	}

	public void ClearSocket()
	{
		if (!(socketObject == null))
		{
			if (hitParticles.transform.parent != base.transform)
			{
				hitParticles.transform.parent = base.transform;
			}
			UnityEngine.Object.Destroy(socketObject);
			socketObject = null;
		}
	}

	public void TriggerHitParticlesInstant()
	{
		TriggerHitParticles(0f, null);
	}

	public void TriggerHitParticles(float delay, Action triggerAction)
	{
		hitParticles.transform.parent = impactPoint;
		hitParticles.transform.localPosition = Vector3.zero;
		StartCoroutine(SpawnHitParticles(delay, triggerAction));
	}

	private IEnumerator SpawnHitParticles(float delay, Action triggerAction)
	{
		yield return new WaitForSeconds(delay);
		hitParticles.Play();
		triggerAction?.Invoke();
	}

	private void Update()
	{
		if (!(trackTransform == null))
		{
			base.transform.localRotation = trackTransform.localRotation;
			base.transform.localRotation = trackTransform.localRotation;
		}
	}
}
