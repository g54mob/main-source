using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
	[Header("Spawn Settings")]
	public bool spawnOnlyNight = true;

	public float triggerDistance = 15f;

	[Tooltip("Bu noktada spawn olacak özel zombi prefab'ı. Boş bırakılırsa rastgele seçilir.")]
	public GameObject overrideZombiePrefab;

	[Tooltip("Bu spawn noktasında zombi yerden çıkma animasyonu yapsın mı (kapalı alanda kapatılabilir)")]
	public bool useEmergeAnimation = true;

	[Tooltip("Açıkken zombi zemine raycast'lenip zemine snap'lenir. Ev içi/kapalı alanlarda kapat: zombi tam bu noktanın pozisyonunda doğar (çatıya sıçramaz).")]
	public bool snapToGround = true;

	[Header("Debug")]
	[SerializeField]
	private bool hasSpawnedZombie;

	[SerializeField]
	private ZombieController spawnedZombie;

	public bool HasSpawnedZombie => hasSpawnedZombie;

	public ZombieController SpawnedZombie => spawnedZombie;

	private void Awake()
	{
		spawnedZombie = null;
		hasSpawnedZombie = false;
	}

	private void Start()
	{
		if (ZombieSpawner.Instance != null)
		{
			ZombieSpawner.Instance.RegisterSpawnPoint(this);
		}
		else
		{
			Debug.LogWarning("[ZombieSpawnPoint] " + base.gameObject.name + " ZombieSpawner.Instance bulunamadı!");
		}
	}

	public void SetSpawnedZombie(ZombieController zombie)
	{
		spawnedZombie = zombie;
		hasSpawnedZombie = zombie != null;
	}

	public void ResetSpawnPoint()
	{
		spawnedZombie = null;
		hasSpawnedZombie = false;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = (hasSpawnedZombie ? Color.red : Color.yellow);
		Gizmos.DrawWireSphere(base.transform.position, triggerDistance);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.up * 2f);
	}

	private void OnDestroy()
	{
		if (ZombieSpawner.Instance != null)
		{
			ZombieSpawner.Instance.UnregisterSpawnPoint(this);
		}
	}
}
