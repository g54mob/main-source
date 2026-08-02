using UnityEngine;

namespace BloodEffectsPack
{
	public class TrailProjectorSpawner : MonoBehaviour
	{
		[HideInInspector]
		public int ignoreLayerMask;

		public GameObject projectorController_prefab;

		[Header("Spawn")]
		public float spawnDistance_min = 1f;

		public float spawnDistance_max = 1f;

		[Header("Duration")]
		public float duration = float.PositiveInfinity;

		private float timeCounter;

		[Header("Size")]
		public float startSize_min = 1f;

		public float startSize_max = 1f;

		private Vector3 lastPosition;

		private float distanceTraveled;

		private GameObject projectorSpawnerGrp;

		private void Start()
		{
			projectorSpawnerGrp = new GameObject(base.gameObject.name + "_ProjectorSpawner_GRP");
			projectorSpawnerGrp.AddComponent<KillEffect_Trail_Projector>();
		}

		private void OnEnable()
		{
			timeCounter = 0f;
			distanceTraveled = 0f;
			lastPosition = base.transform.position;
		}

		private void Update()
		{
			timeCounter += Time.deltaTime;
			distanceTraveled += Vector3.Distance(base.transform.position, lastPosition);
			lastPosition = base.transform.position;
			float num = Random.Range(spawnDistance_min, spawnDistance_max);
			if (distanceTraveled >= num)
			{
				SpawnProjector();
				distanceTraveled = 0f;
			}
			if (timeCounter >= duration)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void SpawnProjector()
		{
			GameObject gameObject = Object.Instantiate(projectorController_prefab, base.transform.position + Vector3.up * 1f, Quaternion.identity);
			ProjectorSpawner component = gameObject.GetComponent<ProjectorSpawner>();
			component.startSize_max = startSize_max;
			component.startSize_min = startSize_min;
			component.ResetAndInitialize(ignoreLayerMask);
			if (projectorSpawnerGrp != null)
			{
				gameObject.transform.SetParent(projectorSpawnerGrp.transform);
			}
		}
	}
}
