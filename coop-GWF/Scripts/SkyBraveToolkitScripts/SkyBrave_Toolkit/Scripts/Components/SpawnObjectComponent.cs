using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class SpawnObjectComponent : MonoBehaviour
	{
		[Header("Parameters")]
		public GameObject ObjectToSpawn;

		public Vector3 SpawnPosOffset;

		public Vector3 SpawnRot;

		[Header("Events")]
		public UnityEvent OnSpawned;

		public void Spawn(Transform parent = null)
		{
			if ((bool)ObjectToSpawn)
			{
				Object.Instantiate(ObjectToSpawn, base.transform.position + SpawnPosOffset, Quaternion.Euler(SpawnRot));
				OnSpawned.Invoke();
			}
			else
			{
				Debug.LogError("Object to spawn is null");
			}
		}

		public Vector3 GetRandomSpawnRotation(Vector3 MinSpawnRotation, Vector3 MaxSpawnRotation)
		{
			float x = Random.Range(MinSpawnRotation.x, MaxSpawnRotation.x);
			float y = Random.Range(MinSpawnRotation.y, MaxSpawnRotation.y);
			float z = Random.Range(MinSpawnRotation.z, MaxSpawnRotation.z);
			return new Vector3(x, y, z);
		}
	}
}
