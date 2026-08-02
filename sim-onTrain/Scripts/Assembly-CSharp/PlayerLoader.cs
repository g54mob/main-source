using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
	[Header("Streaming Settings")]
	public float loadRange = 500f;

	public float unloadRange = 600f;

	public float updateInterval = 0.25f;

	[Header("LOD Settings")]
	public float lodHighRange = 100f;

	public float lodMediumRange = 300f;

	public float lodLowRange = 500f;

	private List<GameObject> sectors = new List<GameObject>();

	private List<Terrain> terrains = new List<Terrain>();

	private float timer;

	private void Start()
	{
		GameObject[] array = Object.FindObjectsOfType<GameObject>();
		foreach (GameObject gameObject in array)
		{
			if (!gameObject.name.Contains("Sector") && !gameObject.name.Contains("SECTR"))
			{
				continue;
			}
			sectors.Add(gameObject);
			Terrain component = gameObject.GetComponent<Terrain>();
			if (component != null)
			{
				terrains.Add(component);
				component.heightmapPixelError = 10f;
				component.basemapDistance = 1000f;
				component.drawInstanced = true;
				if (component.materialTemplate != null)
				{
					component.materialTemplate.enableInstancing = true;
				}
			}
		}
		QualitySettings.lodBias = 2f;
		QualitySettings.maximumLODLevel = 2;
		Camera.main.farClipPlane = loadRange + 100f;
		Debug.Log($"PlayerLoader: Found {sectors.Count} sectors, {terrains.Count} terrain chunks");
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= updateInterval)
		{
			timer = 0f;
			UpdateStreaming();
			UpdateTerrainLOD();
		}
		if (Input.GetKeyDown(KeyCode.F1))
		{
			ShowStats();
		}
	}

	private void UpdateStreaming()
	{
		Vector3 position = base.transform.position;
		int num = 0;
		foreach (GameObject sector in sectors)
		{
			if (!(sector == null))
			{
				float num2 = Vector3.Distance(position, sector.transform.position);
				if (num2 <= loadRange && !sector.activeSelf)
				{
					sector.SetActive(value: true);
					num++;
				}
				else if (num2 > unloadRange && sector.activeSelf)
				{
					sector.SetActive(value: false);
				}
				else if (sector.activeSelf)
				{
					num++;
				}
			}
		}
	}

	private void UpdateTerrainLOD()
	{
		Vector3 position = base.transform.position;
		foreach (Terrain terrain in terrains)
		{
			if (!(terrain == null) && terrain.gameObject.activeSelf)
			{
				float num = Vector3.Distance(position, terrain.transform.position);
				if (num < lodHighRange)
				{
					terrain.heightmapPixelError = 5f;
					terrain.detailObjectDistance = 150f;
					terrain.treeDistance = 500f;
					terrain.treeBillboardDistance = 200f;
					terrain.drawTreesAndFoliage = true;
					terrain.castShadows = true;
				}
				else if (num < lodMediumRange)
				{
					terrain.heightmapPixelError = 10f;
					terrain.detailObjectDistance = 80f;
					terrain.treeDistance = 300f;
					terrain.treeBillboardDistance = 150f;
					terrain.drawTreesAndFoliage = true;
					terrain.castShadows = false;
				}
				else if (num < lodLowRange)
				{
					terrain.heightmapPixelError = 20f;
					terrain.detailObjectDistance = 40f;
					terrain.treeDistance = 150f;
					terrain.treeBillboardDistance = 100f;
					terrain.drawTreesAndFoliage = false;
					terrain.castShadows = false;
				}
				else
				{
					terrain.heightmapPixelError = 30f;
					terrain.drawTreesAndFoliage = false;
					terrain.castShadows = false;
				}
			}
		}
	}

	private void ShowStats()
	{
		int num = 0;
		int num2 = 0;
		foreach (GameObject sector in sectors)
		{
			if (sector.activeSelf)
			{
				num++;
			}
		}
		foreach (Terrain terrain in terrains)
		{
			if (terrain.gameObject.activeSelf)
			{
				num2++;
			}
		}
		Debug.Log("=== STREAMING STATS ===");
		Debug.Log($"Active Sectors: {num}/{sectors.Count}");
		Debug.Log($"Active Terrains: {num2}/{terrains.Count}");
		Debug.Log($"Player Position: {base.transform.position}");
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(base.transform.position, loadRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, unloadRange);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, lodLowRange);
	}
}
