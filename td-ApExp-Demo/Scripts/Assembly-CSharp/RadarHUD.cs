using System.Collections.Generic;
using UnityEngine;

public class RadarHUD : MonoBehaviour
{
	public GameObject arrowPrefab;

	private List<GameObject> keysToRemove;

	private Dictionary<GameObject, GameObject> arrows;

	private void Awake()
	{
		arrows = new Dictionary<GameObject, GameObject>();
		keysToRemove = new List<GameObject>();
	}

	private void Update()
	{
		keysToRemove.Clear();
		foreach (KeyValuePair<GameObject, GameObject> arrow in arrows)
		{
			if (arrow.Key == null)
			{
				Object.Destroy(arrow.Value.gameObject);
				keysToRemove.Add(arrow.Key);
				continue;
			}
			Vector3 point = Camera.main.WorldToViewportPoint(arrow.Key.transform.position);
			if (Camera.main.rect.Contains(point))
			{
				Object.Destroy(arrow.Value.gameObject);
				keysToRemove.Add(arrow.Key);
				continue;
			}
			Vector3 normalized = arrow.Key.transform.position.normalized;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normalized);
			arrow.Value.transform.position = normalized;
			arrow.Value.transform.rotation = rotation;
		}
		foreach (GameObject item in keysToRemove)
		{
			arrows.Remove(item);
		}
	}

	public void OnEnemySpawn(EnemyBase newEnemy)
	{
		GameObject value = Object.Instantiate(arrowPrefab, base.transform);
		arrows.Add(newEnemy.gameObject, value);
	}
}
