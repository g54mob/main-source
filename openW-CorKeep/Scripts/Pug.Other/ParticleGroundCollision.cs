using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleGroundCollision : MonoBehaviour
{
	private static Transform s_floorPlane;

	private void Awake()
	{
		ParticleSystem.CollisionModule collision = GetComponent<ParticleSystem>().collision;
		collision.enabled = true;
		collision.type = ParticleSystemCollisionType.Planes;
		for (int i = 0; i < collision.planeCount; i++)
		{
			collision.RemovePlane(0);
		}
		if (s_floorPlane == null)
		{
			s_floorPlane = new GameObject("_ParticleCollisionFloorPlane").transform;
			Object.DontDestroyOnLoad(s_floorPlane.gameObject);
			s_floorPlane.position = Vector3.zero;
		}
		collision.AddPlane(s_floorPlane);
	}
}
