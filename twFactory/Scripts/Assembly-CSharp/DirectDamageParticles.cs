using System.Collections;
using UnityEngine;

public class DirectDamageParticles : MonoBehaviour
{
	private ParticleSystem particles;

	private Coroutine directDamageParticlesCorutine;

	private void Awake()
	{
		particles = GetComponent<ParticleSystem>();
	}

	public void StartParticles(Vector3 startPosition, Vector3 endPosition, Enemy enemy)
	{
		this.StartCoroutineCheckingVar(DirectDamageParticlesCoroutine(startPosition, endPosition, enemy), ref directDamageParticlesCorutine);
	}

	public void StopParticles()
	{
		this.StopCoroutineCheckingVar(ref directDamageParticlesCorutine);
	}

	protected virtual IEnumerator DirectDamageParticlesCoroutine(Vector3 startPosition, Vector3 endPosition, Enemy enemy)
	{
		float timer = 0f;
		float duration = particles.main.startLifetime.constant;
		base.transform.rotation = Quaternion.identity;
		particles.Play(withChildren: true);
		do
		{
			timer += Time.deltaTime;
			particles.transform.position = (enemy ? enemy.CombatComponent.TargetObject.transform.position : endPosition);
			ParticleSystem.ShapeModule shape = particles.shape;
			shape.position = startPosition - (enemy ? enemy.CombatComponent.TargetObject.transform.position : endPosition);
			yield return null;
		}
		while (timer < duration && enemy != null);
		directDamageParticlesCorutine = null;
	}
}
