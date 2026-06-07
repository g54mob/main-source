using System.Collections.Generic;
using UnityEngine;

public class EndingRay : MonoBehaviour
{
	public GameObject GarbageTemplate;

	public List<Sprite> GarbageSprites;

	public GameObject LeftDot;

	public GameObject RightDot;

	private List<GameObject> _garbages = new List<GameObject>();

	private List<float> _rotations = new List<float>();

	private List<float> _movements = new List<float>();

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		for (int i = 0; i < _garbages.Count; i++)
		{
			GameObject gameObject = _garbages[i];
			gameObject.transform.position += new Vector3(_movements[i] * Time.fixedDeltaTime, 0f, 0f);
			if (gameObject.transform.position.x > RightDot.transform.position.x)
			{
				gameObject.transform.position -= new Vector3(RightDot.transform.position.x - LeftDot.transform.position.x, 0f, 0f);
			}
			gameObject.transform.Rotate(0f, 0f, _rotations[i] * Time.fixedDeltaTime);
		}
	}

	public void StartRay()
	{
		for (int i = 0; i < 100; i++)
		{
			GameObject gameObject = Object.Instantiate(GarbageTemplate, base.transform);
			gameObject.transform.position = new Vector3(Random.Range(LeftDot.transform.position.x, RightDot.transform.position.x), Random.Range(base.transform.position.y + -2f, base.transform.position.y + 2f), 0f);
			gameObject.GetComponent<SpriteRenderer>().sprite = GarbageSprites[Random.Range(0, GarbageSprites.Count)];
			gameObject.SetActive(value: true);
			_garbages.Add(gameObject);
			_rotations.Add(Random.Range(-30f, 30f));
			_movements.Add(Random.Range(6f, 10f));
		}
	}
}
