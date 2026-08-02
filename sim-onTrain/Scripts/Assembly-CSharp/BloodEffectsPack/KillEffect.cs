using System.Collections;
using UnityEngine;

namespace BloodEffectsPack
{
	public class KillEffect : MonoBehaviour
	{
		public float minLifetime = 3f;

		public float maxLifetime = 5f;

		private float lifetime;

		private Coroutine currentCoroutine;

		private void Start()
		{
			lifetime = Random.Range(minLifetime, maxLifetime);
			currentCoroutine = StartCoroutine(Kill());
		}

		private IEnumerator Kill()
		{
			yield return new WaitForSeconds(lifetime);
			Object.Destroy(base.gameObject);
		}

		private void OnDestroy()
		{
			if (currentCoroutine != null)
			{
				StopCoroutine(currentCoroutine);
			}
		}
	}
}
