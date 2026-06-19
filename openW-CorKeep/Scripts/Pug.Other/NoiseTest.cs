using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class NoiseTest : MonoBehaviour
{
	public enum NoiseType
	{
		None = 0,
		Perlin = 1,
		PerlinPeriodic = 2,
		Simplex = 3,
		SimplexPeriodic = 4,
		Cellular = 5
	}

	public NoiseType noiseType;

	[Range(0f, 10f)]
	public float x;

	[Range(0f, 10f)]
	public float y;

	[Range(0f, 10f)]
	public float z;

	[ReadOnly]
	public float3 value;

	public void OnValidate()
	{
		float3 float5 = new float3(x, y, z);
		switch (noiseType)
		{
		case NoiseType.Perlin:
			value = noise.cnoise(float5);
			break;
		case NoiseType.PerlinPeriodic:
			value = noise.pnoise(new float2(float5.x, float5.y), float5.z);
			break;
		case NoiseType.Simplex:
			value = noise.snoise(float5);
			break;
		case NoiseType.SimplexPeriodic:
			value = noise.psrnoise(new float2(float5.x, float5.y), float5.z);
			break;
		case NoiseType.Cellular:
			value = noise.cellular(float5).ToFloat3();
			break;
		}
	}
}
