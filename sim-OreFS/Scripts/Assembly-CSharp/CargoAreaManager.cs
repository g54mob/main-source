using UnityEngine;

public class CargoAreaManager : MonoBehaviour
{
	[Header("Cargo Area Settings")]
	[Tooltip("Cargo area başlangıç noktası - Grid buradan başlar")]
	public Transform spawnOrigin;

	[Header("Grid Size")]
	[Tooltip("Grid sütun sayısı (X ekseni)")]
	[Range(1f, 10f)]
	public int columns = 4;

	[Tooltip("Grid satır sayısı (Z ekseni)")]
	[Range(1f, 10f)]
	public int rows = 4;

	[Header("Spacing")]
	[Tooltip("Kutular arası X mesafesi (sütunlar arası)")]
	public float spacingX = 2f;

	[Tooltip("Kutular arası Z mesafesi (satırlar arası)")]
	public float spacingZ = 2f;

	[Header("Height")]
	[Tooltip("Spawn yüksekliği (düşme efekti için)")]
	public float spawnHeight = 3f;

	public static CargoAreaManager Instance { get; private set; }

	public int TotalSpawnPoints => columns * rows;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Vector3 GetSpawnPosition(int index)
	{
		if (spawnOrigin == null)
		{
			Debug.LogWarning("[CargoAreaManager] spawnOrigin atanmamış!");
			return Vector3.up * spawnHeight;
		}
		int num = index % columns;
		int num2 = index / columns;
		float num3 = (float)num * spacingX;
		float num4 = (float)num2 * spacingZ;
		return spawnOrigin.position + spawnOrigin.right * num3 + spawnOrigin.forward * num4 + Vector3.up * spawnHeight;
	}

	public Vector3 GetSpawnPositionAt(int column, int row)
	{
		int index = row * columns + column;
		return GetSpawnPosition(index);
	}
}
