using System.Collections.Generic;
using UnityEngine;

public class SineWaveChildren : MonoBehaviour
{
	public float amplitude = 0.5f;

	public float frequency = 1f;

	public float phaseOffset = 0.5f;

	public List<Transform> children = new List<Transform>();

	private List<Vector3> startPositions = new List<Vector3>();

	private void Awake()
	{
		startPositions.Clear();
		foreach (Transform child in children)
		{
			startPositions.Add(child.localPosition);
		}
	}

	private void Update()
	{
		float num = Time.time * frequency;
		for (int i = 0; i < children.Count; i++)
		{
			Transform obj = children[i];
			Vector3 vector = startPositions[i];
			float num2 = Mathf.Sin(num + (float)i * phaseOffset) * amplitude;
			obj.localPosition = vector + Vector3.up * num2;
		}
	}
}
