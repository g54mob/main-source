using UnityEngine;

namespace BloodVFX
{
	public class EffectController : MonoBehaviour
	{
		[Space(10f)]
		public int spawnNumber = 5;

		public float spawnRadius = 1f;

		public float minScale = 0.2f;

		public float maxScale = 0.6f;

		public float spread = 1f;

		public float minForce;

		public float maxForce = 100f;

		public GameObject[] prefabs;

		private Rigidbody[] rigids;

		private void OnEnable()
		{
			for (int i = 0; i < spawnNumber; i++)
			{
				Vector3 position = base.transform.position + Random.insideUnitSphere * spawnRadius;
				int num = Random.Range(0, prefabs.Length);
				GameObject obj = Object.Instantiate(prefabs[num], position, Random.rotation);
				float num2 = Random.Range(minScale, maxScale);
				obj.transform.localScale = Vector3.one * num2;
				Vector3 vector = Vector3.Lerp(base.transform.position - base.transform.forward * 2f, base.transform.position, spread);
				Vector3 vector2 = Vector3.Normalize(obj.transform.position - vector);
				obj.GetComponent<Rigidbody>().AddForce(vector2 * Random.Range(minForce, maxForce));
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(base.transform.position, spawnRadius);
			Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 2f);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(Vector3.Lerp(base.transform.position - base.transform.forward * 2f, base.transform.position, spread), 0.1f);
		}
	}
}
