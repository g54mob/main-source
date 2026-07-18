using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
	[SerializeField]
	private GameObject starPrefab;

	[SerializeField]
	private List<GameObject> stars;

	[SerializeField]
	private int amountOfStarsToSpawn;

	[SerializeField]
	private float minDistance;

	private IEnumerator Start()
	{
		for (int i = 0; i < amountOfStarsToSpawn; i++)
		{
			Vector3 vector = Vector3.zero;
			for (int j = 0; j < 19; j++)
			{
				vector = GetRandomPosition(i);
				if (i == 0 || !(stars[i - 1].GetComponent<RectTransform>().anchoredPosition.y - vector.y <= minDistance))
				{
					break;
				}
			}
			GameObject gameObject = Object.Instantiate(starPrefab, base.transform);
			gameObject.GetComponentInParent<RectTransform>().anchoredPosition = vector;
			stars.Add(gameObject);
			yield return new WaitForSeconds(0.25f);
		}
	}

	private Vector3 GetRandomPosition(int i)
	{
		return new Vector3(-850 + 1500 / amountOfStarsToSpawn * i + Random.Range(-50, 50), Random.Range(-500, 500), 0f);
	}
}
