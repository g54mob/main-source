using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Teleporter")]
	public sealed class Teleporter : MonoBehaviour
	{
		[Tooltip("Defines the area in which the objects spawn after being ported. It should be a trigger collider or else the object might get stuck.")]
		public Collider SpawnArea;

		[Tooltip("Time delay in seconds between appearance of two ported objects.")]
		public float SpawnDelay;

		[Tooltip("Vector3 to declare forward direction. Most likely (0,0,1) for 3D scenarios and (0,1,0) for 2D scenarios.")]
		public Vector3 Forward = new Vector3(0f, 0f, 1f);

		[Tooltip("Flag to determine if the item should face towards the teleporter after it was ported.")]
		public bool FaceTowards = true;

		private Queue<Transform> teleportQueue = new Queue<Transform>();

		private float currentTime = -1f;

		private void Update()
		{
			if (teleportQueue.Count > 0 && currentTime >= SpawnDelay)
			{
				Transform transform = teleportQueue.Dequeue();
				Vector3 vector = default(Vector3);
				vector.x = Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
				vector.y = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
				vector.z = Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z);
				transform.position = vector;
				if (FaceTowards)
				{
					Vector3 vector2 = Vector3.Cross(Forward, base.transform.position - vector);
					float num = Vector3.Angle(Forward, base.transform.position - vector);
					if (Mathf.Abs(vector2.x) > Mathf.Abs(vector2.y) && Mathf.Abs(vector2.x) > Mathf.Abs(vector2.z))
					{
						transform.rotation = Quaternion.Euler(num * Mathf.Sign(vector2.x), 0f, 0f);
					}
					else if (Mathf.Abs(vector2.y) > Mathf.Abs(vector2.z))
					{
						transform.rotation = Quaternion.Euler(0f, num * Mathf.Sign(vector2.y), 0f);
					}
					else
					{
						transform.rotation = Quaternion.Euler(0f, 0f, num * Mathf.Sign(vector2.z));
					}
				}
				if (transform.GetComponent<Rigidbody>() != null)
				{
					transform.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
				}
				if (transform.GetComponent<Rigidbody2D>() != null)
				{
					transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
				}
				transform.gameObject.SetActive(value: true);
				currentTime = 0f;
			}
			currentTime += Time.deltaTime;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			Despawn(collision.transform);
		}

		private void OnTriggerEnter(Collider collision)
		{
			Despawn(collision.transform);
		}

		private void Despawn(Transform transform)
		{
			if (teleportQueue.Count == 0)
			{
				currentTime = 0f;
			}
			teleportQueue.Enqueue(transform);
			transform.gameObject.SetActive(value: false);
		}
	}
}
