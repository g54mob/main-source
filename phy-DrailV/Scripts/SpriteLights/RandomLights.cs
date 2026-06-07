using System;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomLights : MonoBehaviour
{
	public IndexFormat meshIndexFormat;

	public Material material;

	public int lightAmount = 10000;

	[Range(-1f, 1f)]
	public float globalBrightnessOffset;

	private void Start()
	{
		UnityEngine.Random.InitState(Mathf.RoundToInt(DateTime.Now.Millisecond));
		GenerateRandomLights(lightAmount, new Vector2(0f, 300f), material);
	}

	private void GenerateRandomLights(int amount, Vector2 area, Material material)
	{
		SpriteLights.LightData[] array = new SpriteLights.LightData[amount];
		for (int i = 0; i < amount; i++)
		{
			array[i] = default(SpriteLights.LightData);
			array[i].size = UnityEngine.Random.Range(1f, 5f);
			array[i].position = new Vector3(UnityEngine.Random.Range(area.x, area.y), 0f, UnityEngine.Random.Range(area.x, area.y));
		}
		SpriteLights.CreateLights("RandomLights", array, material, meshIndexFormat, null);
	}
}
