using System.Collections;
using UnityEngine;

namespace JSAM.Example.Shmup2D
{
	public class EnemyController : MonoBehaviour
	{
		[SerializeField]
		private float rotateSpeed;

		[SerializeField]
		private int spawnAmount;

		[SerializeField]
		private float bulletDelay;

		[SerializeField]
		private float spawnDelay;

		[SerializeField]
		private ObjectPool pool;

		private void Start()
		{
			StartCoroutine(SpawnBehaviour());
		}

		private void Update()
		{
			base.transform.eulerAngles += new Vector3(0f, 0f, (0f - rotateSpeed) * Time.deltaTime);
		}

		private IEnumerator SpawnBehaviour()
		{
			while (true)
			{
				float angle = 360f / (float)spawnAmount;
				for (int i = 0; i < spawnAmount; i++)
				{
					GameObject gameObject = pool.GetObject();
					if ((bool)gameObject)
					{
						gameObject.transform.position = base.transform.position;
						gameObject.transform.localEulerAngles = base.transform.eulerAngles + new Vector3(0f, 0f, (float)i * angle);
						gameObject.SetActive(value: true);
						AudioManager.PlaySound(Shmup2DSounds.EnemyShot);
					}
					yield return new WaitForSeconds(bulletDelay);
				}
				yield return new WaitForSeconds(spawnDelay);
			}
		}
	}
}
