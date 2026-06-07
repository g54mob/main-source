using System.Collections;
using UnityEngine;

public class CruiseNearTrigger : Trigger
{
	[SerializeField]
	private float distanceToCheck = 1f;

	[SerializeField]
	private float activationProbability = 1f;

	[SerializeField]
	[Tooltip("Cada cuanto se comprueba la distancia con el jugador")]
	private Vector2 minMaxCheckTime = Vector2.one;

	[SerializeField]
	private bool ignoreHeight = true;

	private void Start()
	{
		if (activationProbability > 0f)
		{
			StartCoroutine(CheckDistanceCoroutine());
		}
	}

	private IEnumerator CheckDistanceCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minMaxCheckTime.x, minMaxCheckTime.y));
			if (Random.value <= activationProbability && GameManager.instance.PlayerCharacter != null)
			{
				Vector3 position = base.transform.position;
				if (ignoreHeight)
				{
					position.y = GameManager.instance.PlayerCharacter.transform.position.y;
				}
				if (Vector3.SqrMagnitude(GameManager.instance.PlayerCharacter.transform.position - position) < distanceToCheck * distanceToCheck)
				{
					ActivateTrigger();
				}
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(base.transform.position, distanceToCheck);
	}
}
