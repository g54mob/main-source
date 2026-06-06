using System.Collections.Generic;
using UnityEngine;

public class LandmarkGenerator2 : MonoBehaviour
{
	[SerializeField]
	private Polygon _polygon;

	[SerializeField]
	private bool _useCustomSeed;

	[SerializeField]
	[ConditionalHide("_useCustomSeed", true)]
	private int _customSeed;

	private List<GameObject> _roadList = new List<GameObject>(4);

	public void Generate()
	{
		Clear();
		GenerateRoad();
	}

	private void GenerateRoad()
	{
		if (!_useCustomSeed)
		{
			_customSeed = Random.Range(int.MinValue, int.MaxValue);
		}
		Random.InitState(_customSeed);
		Debug.Log($"used seed: {_customSeed}");
		GameObject gameObject = new GameObject("Road Objects");
		gameObject.transform.SetParent(base.transform);
		float num = _polygon.ReturnBoundingRadius() / 2f;
		Debug.Log($"{num} radius");
		float x = Random.Range(base.transform.position.x - num, base.transform.position.x + num);
		float z = Random.Range(base.transform.position.z - num, base.transform.position.z + num);
		Vector3 vector = new Vector3(x, 0f, z);
		GameObject gameObject2 = new GameObject("Startpoint");
		gameObject2.transform.SetParent(gameObject.transform);
		gameObject2.transform.position = vector;
		if (_polygon.ReturnPointIsOverlapping(vector))
		{
			Debug.Log(gameObject2.name + " is inside polygon");
		}
	}

	public void Clear()
	{
		for (int num = base.transform.childCount - 1; num >= 0; num--)
		{
			Object.DestroyImmediate(base.transform.GetChild(num).gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		if (_polygon != null)
		{
			_polygon.DrawGizmos();
		}
	}
}
