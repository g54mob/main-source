using UnityEngine;

public class Instancer_GameObject : MonoBehaviour
{
	[SerializeField]
	private Vector2 heightRandomRange = new Vector2(-0.075f, -0.044f);

	[SerializeField]
	private float mapSize = 100f;

	[SerializeField]
	private uint instances = 1000u;

	[SerializeField]
	private GameObject reference;

	private void Start()
	{
		if ((object)reference != null)
		{
			GenerateInstances();
		}
	}

	private void GenerateInstances()
	{
		Transform parent = base.transform;
		float num = mapSize / 2f;
		float minInclusive = 0f - num;
		Quaternion rotation = new Quaternion(0f, 0f, 0f, 1f);
		for (int i = 0; i < instances; i++)
		{
			Object.Instantiate(position: new Vector3(Random.Range(minInclusive, num), Random.Range(heightRandomRange.x, heightRandomRange.y), Random.Range(minInclusive, num)), original: reference, rotation: rotation, parent: parent);
		}
	}
}
