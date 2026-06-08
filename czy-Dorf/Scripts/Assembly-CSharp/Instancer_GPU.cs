using System;
using UnityEngine;

public class Instancer_GPU : MonoBehaviour
{
	[SerializeField]
	private Vector2 heightRandomRange = new Vector2(-0.075f, -0.044f);

	[SerializeField]
	private float mapSize = 100f;

	[SerializeField]
	private int instances = 1000;

	[SerializeField]
	private Mesh reference;

	[SerializeField]
	private Material material;

	public const int GroupMaxSize = 1022;

	private int instancesGroupCount;

	private Matrix4x4[][] normalTreesPlacement;

	private void Start()
	{
		GeneratePlacements();
	}

	private void GeneratePlacements()
	{
		instancesGroupCount = (int)Math.Ceiling((float)instances / 1022f);
		normalTreesPlacement = new Matrix4x4[instancesGroupCount][];
		float num = mapSize / 2f;
		float minInclusive = 0f - num;
		Quaternion q = new Quaternion(0f, 0f, 0f, 1f);
		Vector3 s = new Vector3(1f, 1f, 1f);
		int num2 = instances;
		for (int i = 0; i < instancesGroupCount; i++)
		{
			int num3 = Math.Min(num2, 1022);
			Matrix4x4[] array = new Matrix4x4[num3];
			for (int j = 0; j < num3; j++)
			{
				Vector3 pos = new Vector3(UnityEngine.Random.Range(minInclusive, num), UnityEngine.Random.Range(heightRandomRange.x, heightRandomRange.y), UnityEngine.Random.Range(minInclusive, num));
				array[j] = Matrix4x4.TRS(pos, q, s);
			}
			normalTreesPlacement[i] = array;
			num2 -= 1022;
		}
	}

	private void Update()
	{
		for (int i = 0; i < instancesGroupCount; i++)
		{
			Matrix4x4[] array = normalTreesPlacement[i];
			Graphics.DrawMeshInstanced(reference, 0, material, array, array.Length);
		}
	}
}
