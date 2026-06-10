using System.Collections.Generic;
using UnityEngine;

public class MenuFishSpawner : MonoBehaviour
{
	[Header("References")]
	public GameObject fishPrefab;

	[Header("Limits")]
	public int maxTotalFish = 10;

	public int maxFrontFish = 3;

	[Header("Spawn Timing")]
	public float minSpawnInterval = 1f;

	public float maxSpawnInterval = 3f;

	[Header("Spawn Settings (World Units)")]
	public float spawnXOffset = 11f;

	[Range(0f, 1f)]
	public float chanceForFarFish = 0.7f;

	[Header("Depth - Positions (World Y)")]
	public float nearY = -4f;

	public float farY = 3.5f;

	[Header("Depth - Visuals")]
	public float minScale = 0.5f;

	public float maxScale = 1.2f;

	public Color nearColor = Color.white;

	public Color farColor = new Color(0.5f, 0.6f, 0.7f, 1f);

	[Header("Sorting Layers")]
	public int farSortingOrder;

	public int frontSortingOrder = 10;

	[Header("Speed (World Units)")]
	public float minSpeed = 1f;

	public float maxSpeed = 4f;

	private float _timer;

	private bool _spawnFromLeft = true;

	private List<GameObject> _allFish = new List<GameObject>();

	private List<GameObject> _frontFish = new List<GameObject>();

	private void Start()
	{
		_timer = 0.5f;
	}

	private void Update()
	{
		CleanLists();
		_timer -= Time.deltaTime;
		if (_timer <= 0f)
		{
			if (_allFish.Count < maxTotalFish)
			{
				TrySpawnFish();
			}
			_timer = Random.Range(minSpawnInterval, maxSpawnInterval);
		}
	}

	private void TrySpawnFish()
	{
		if (!(fishPrefab == null))
		{
			bool flag = Random.value < chanceForFarFish;
			if (!flag && _frontFish.Count >= maxFrontFish)
			{
				flag = true;
			}
			float t = ((!flag) ? Random.Range(0.7f, 1f) : Random.Range(0f, 0.4f));
			float y = Mathf.Lerp(farY, nearY, t);
			float num = Mathf.Lerp(minScale, maxScale, t);
			Color color = Color.Lerp(farColor, nearColor, t);
			float num2 = Mathf.Lerp(0.6f, 1f, t);
			int num3 = (_spawnFromLeft ? 1 : (-1));
			float x = (_spawnFromLeft ? (0f - spawnXOffset) : spawnXOffset);
			GameObject gameObject = Object.Instantiate(fishPrefab, base.transform);
			gameObject.transform.position = new Vector3(x, y, 0f);
			float x2 = ((num3 == 1) ? (0f - num) : num);
			gameObject.transform.localScale = new Vector3(x2, num, 1f);
			SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
			if (component != null)
			{
				component.color = color;
				component.sortingOrder = (flag ? farSortingOrder : frontSortingOrder);
			}
			AmbientFish component2 = gameObject.GetComponent<AmbientFish>();
			if (component2 != null)
			{
				float speed = Random.Range(minSpeed, maxSpeed) * num2;
				component2.Setup(speed, num3);
			}
			if (!flag)
			{
				_frontFish.Add(gameObject);
			}
			_allFish.Add(gameObject);
			_spawnFromLeft = !_spawnFromLeft;
		}
	}

	private void CleanLists()
	{
		_allFish.RemoveAll((GameObject item) => item == null);
		_frontFish.RemoveAll((GameObject item) => item == null);
	}
}
