using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
	public float customYVelTolerance;

	public bool stopRotationOnCollision;

	public string soundOnCollision;

	public float delayedDestruction;

	private bool destructionProcessed;

	protected Vector3 hitRot = new Vector3(90f, 0f, 0f);

	protected Dictionary<int, Vector3> hitPosDict = new Dictionary<int, Vector3>();

	protected Dictionary<int, Vector3> hitRotDict = new Dictionary<int, Vector3>();

	protected List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

	protected ParticleSystem particleSystemRef;

	private void Awake()
	{
		OnAwake();
	}

	protected virtual void OnAwake()
	{
		particleSystemRef = GetComponent<ParticleSystem>();
		if (particleSystemRef == null)
		{
			particleSystemRef = GetComponentInChildren<ParticleSystem>();
		}
	}

	private void Update()
	{
		if (!particleSystemRef.isPlaying && !destructionProcessed)
		{
			if (delayedDestruction > 0f)
			{
				StartCoroutine(DelayedDestroy());
			}
			else
			{
				OnDestroy();
			}
		}
	}

	private void LateUpdate()
	{
		if (!stopRotationOnCollision)
		{
			return;
		}
		ParticleSystem.Particle[] array = new ParticleSystem.Particle[particleSystemRef.main.maxParticles];
		int particles = particleSystemRef.GetParticles(array);
		for (int i = 0; i < particles; i++)
		{
			if (hitRotDict.ContainsKey(i) || Mathf.Abs(array[i].velocity.y) <= customYVelTolerance)
			{
				if (!hitRotDict.ContainsKey(i))
				{
					hitPosDict[i] = array[i].position;
					hitRotDict[i] = hitRot + new Vector3(0f, array[i].rotation3D.y, 0f);
				}
				array[i].position = hitPosDict[i];
				array[i].rotation3D = hitRotDict[i];
			}
		}
		particleSystemRef.SetParticles(array, particles);
	}

	private void OnParticleCollision(GameObject other)
	{
		if (soundOnCollision.Length == 0)
		{
			return;
		}
		int num = particleSystemRef.GetCollisionEvents(other, collisionEvents);
		for (int i = 0; i < num; i++)
		{
			if (Mathf.Abs(collisionEvents[i].velocity.y) > 10f)
			{
				AudioController.Play(soundOnCollision, collisionEvents[i].intersection);
			}
		}
	}

	private IEnumerator DelayedDestroy()
	{
		destructionProcessed = true;
		yield return new WaitForSeconds(delayedDestruction);
		OnDestroy();
	}

	protected virtual void OnDestroy()
	{
		destructionProcessed = true;
		Object.Destroy(base.gameObject);
	}
}
