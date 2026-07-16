using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	private List<GameObject> cloudGos;

	[SerializeField]
	private Sprite[] cloudSprites;

	[SerializeField]
	private float cloudSpeed = 0.1f;

	[SerializeField]
	private float timeBetweenCloudsMin;

	[SerializeField]
	private float timeBetweenCloudsMax;

	[SerializeField]
	private float yMin;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float x;

	[SerializeField]
	private string cloudLayer;

	[SerializeField]
	private int cloudLayerIndex;

	private float cloudTimer;

	private void Awake()
	{
		cloudGos = new List<GameObject>();
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Hub)
		{
			DestroyAllClouds();
		}
		else if (LevelManager.Instance.LevelHistory != null && LevelManager.Instance.LevelHistory.Count != 1)
		{
			MoveClouds();
			cloudTimer -= Time.deltaTime * Mathf.Max(Train.Instance.TrainSpeedNormalized, 0.1f);
			if (!(cloudTimer > 0f))
			{
				InstantiateCloud();
				cloudTimer = Random.Range(timeBetweenCloudsMin, timeBetweenCloudsMax);
			}
		}
	}

	private void InstantiateCloud()
	{
		GameObject gameObject = new GameObject("Cloud");
		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = cloudLayer;
		spriteRenderer.sortingOrder = cloudLayerIndex;
		gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		gameObject.AddComponent<Shadow>();
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("PP");
		float num = Random.Range(yMin, yMax);
		if (Random.Range(0, 2) == 0)
		{
			num *= -1f;
		}
		gameObject.transform.position = new Vector3(x, num);
		spriteRenderer.enabled = false;
		int num2 = Random.Range(0, cloudSprites.Length);
		spriteRenderer.sprite = cloudSprites[num2];
		cloudGos.Add(gameObject);
	}

	private void MoveClouds()
	{
		if (cloudGos == null || cloudGos.Count == 0)
		{
			return;
		}
		_ = Train.Instance.SpeedCurrent;
		for (int i = 0; i < cloudGos.Count; i++)
		{
			Transform transform = cloudGos[i].transform;
			float num = (0f - cloudSpeed) * Time.deltaTime;
			transform.position = new Vector3(transform.position.x + num, transform.position.y, 0f);
			if (transform.position.x < -5f)
			{
				Object.Destroy(cloudGos[i]);
				cloudGos.RemoveAt(i);
			}
		}
	}

	private void DestroyAllClouds()
	{
		if (cloudGos.Count != 0)
		{
			for (int i = 0; i < cloudGos.Count; i++)
			{
				Object.Destroy(cloudGos[i]);
			}
			cloudGos = new List<GameObject>();
		}
	}
}
