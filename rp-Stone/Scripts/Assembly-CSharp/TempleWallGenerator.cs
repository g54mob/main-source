using System.Collections.Generic;
using UnityEngine;

public class TempleWallGenerator : MonoBehaviour
{
	public float generationInterval = 1f;

	public float radius = 10f;

	public float brickWidth = 1.5f;

	public float brickHeight = 1f;

	public float brickArc = 5f;

	public int rowCount = 8;

	public GameObject cubePrototype;

	private List<GameObject> cubes = new List<GameObject>();

	private Stack<GameObject> cubePool = new Stack<GameObject>();

	private float lastRadius;

	private float lastBrickWidth;

	private float lastBrickHeight;

	private float lastBrickArc;

	private int lastRowCount;

	private float lastGenerationTime;

	private void Update()
	{
		if ((lastRadius != radius || lastBrickHeight != brickHeight || lastBrickWidth != brickWidth || lastBrickArc != brickArc || lastRowCount != rowCount) && Time.realtimeSinceStartup - lastGenerationTime > generationInterval)
		{
			lastRadius = radius;
			lastBrickHeight = brickHeight;
			lastBrickWidth = brickWidth;
			lastBrickArc = brickArc;
			lastRowCount = rowCount;
			lastGenerationTime = Time.realtimeSinceStartup;
			Generate();
		}
	}

	private void Generate()
	{
		RecycleCubes();
		Transform transform = base.transform;
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		brickArc = Mathf.Abs(brickArc);
		Vector3 eulers = new Vector3(0f, brickArc, 0f);
		Vector3 position = new Vector3(0f, 0f, radius) + transform.position;
		Vector3 localScale = new Vector3(brickWidth, brickHeight, brickHeight);
		for (int i = 0; i < rowCount; i++)
		{
			if (i % 2 == 0)
			{
				transform.Rotate(new Vector3(0f, -90f, 0f));
			}
			else
			{
				transform.Rotate(new Vector3(0f, -90f - brickArc / 2f, 0f));
			}
			transform.position = new Vector3(0f, ((float)i - (float)rowCount / 2f) * brickHeight, 0f);
			float num = 0f;
			while (num < 180.1f)
			{
				GameObject gameObject = NewCube();
				gameObject.transform.position = position;
				gameObject.transform.rotation = Quaternion.identity;
				gameObject.transform.localScale = localScale;
				cubes.Add(gameObject);
				num += brickArc;
				transform.Rotate(eulers);
			}
			transform.rotation = Quaternion.identity;
		}
		transform.position = Vector3.zero;
		transform.Rotate(new Vector3(0f, (0f - brickArc) / 2f, 0f));
	}

	private void RecycleCubes()
	{
		for (int i = 0; i < cubes.Count; i++)
		{
			GameObject gameObject = cubes[i];
			gameObject.SetActive(value: false);
			cubePool.Push(gameObject);
		}
		cubes.Clear();
	}

	private GameObject NewCube()
	{
		GameObject gameObject = null;
		if (cubePool.Count > 0)
		{
			gameObject = cubePool.Pop();
		}
		if (gameObject == null)
		{
			gameObject = Object.Instantiate(cubePrototype);
			gameObject.transform.SetParent(base.transform);
		}
		gameObject.SetActive(value: true);
		return gameObject;
	}

	private void Start()
	{
		cubePrototype.SetActive(value: false);
	}
}
