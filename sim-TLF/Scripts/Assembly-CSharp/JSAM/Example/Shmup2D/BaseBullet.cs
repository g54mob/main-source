using System.Collections;
using UnityEngine;

namespace JSAM.Example.Shmup2D
{
	public abstract class BaseBullet : MonoBehaviour
	{
		[SerializeField]
		protected float bulletSpeed = 50f;

		[SerializeField]
		protected float lifeTime = 1f;

		protected float lifeTimer;

		protected bool isAlive;

		private void OnEnable()
		{
			isAlive = true;
			StartCoroutine(Move());
			StartCoroutine(TickLifeTimer());
		}

		private void Update()
		{
			if (!isAlive)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		protected IEnumerator Move()
		{
			while (isAlive)
			{
				base.transform.position += base.transform.up * bulletSpeed * Time.deltaTime;
				yield return null;
			}
		}

		protected IEnumerator TickLifeTimer()
		{
			lifeTimer = lifeTime;
			while (isAlive)
			{
				lifeTimer -= Time.deltaTime;
				if (lifeTimer <= 0f)
				{
					isAlive = false;
				}
				yield return null;
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			TriggerEnter(other);
		}

		protected abstract void TriggerEnter(Collider2D other);
	}
}
