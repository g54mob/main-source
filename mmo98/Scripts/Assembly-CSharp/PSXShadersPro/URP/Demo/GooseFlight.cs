using UnityEngine;

namespace PSXShadersPro.URP.Demo
{
	public class GooseFlight : MonoBehaviour
	{
		[SerializeField]
		private Transform leftWing;

		[SerializeField]
		private Transform rightWing;

		[SerializeField]
		private float flapSpeed;

		[SerializeField]
		private float flapOffset;

		[SerializeField]
		private float flapAngle;

		[SerializeField]
		private float flySpeed;

		[SerializeField]
		private Vector2 xSpawnBounds;

		[SerializeField]
		private Vector2 ySpawnBounds;

		[SerializeField]
		private Vector2 zSpawnBounds;

		private void Update()
		{
			Vector3 position = base.transform.position;
			position.z += flySpeed * Time.deltaTime;
			base.transform.position = position;
			if (base.transform.position.z > zSpawnBounds.y)
			{
				Respawn();
			}
			float z = Mathf.Lerp(0f - flapAngle, flapAngle, (Mathf.Sin(Time.time * flapSpeed + flapOffset) + 1f) * 0.5f);
			float z2 = Mathf.Lerp(flapAngle, 0f - flapAngle, (Mathf.Sin(Time.time * flapSpeed + flapOffset) + 1f) * 0.5f);
			leftWing.localRotation = Quaternion.Euler(0f, 0f, z);
			rightWing.localRotation = Quaternion.Euler(0f, 0f, z2);
		}

		private void Respawn()
		{
			Vector3 position = base.transform.position;
			position.x = Random.Range(xSpawnBounds.x, xSpawnBounds.y);
			position.y = Random.Range(ySpawnBounds.x, ySpawnBounds.y);
			position.z = zSpawnBounds.x;
			base.transform.position = position;
		}
	}
}
