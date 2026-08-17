using UnityEngine;

namespace Assets.Scripts.Managers;

public class ParticleSpawner : MonoBehaviour
{
	public unsafe static GameObject SpawnParticles(GameObject particles, Vector3 position, Quaternion rotation)
	{
		//IL_0016: Expected O, but got Ref
		//IL_0016: Expected O, but got Ref
		object obj = default(object);
		object obj2 = default(object);
		return Object.Instantiate(particles, (Vector3)(&obj), (Quaternion)(&obj2));
	}
}
