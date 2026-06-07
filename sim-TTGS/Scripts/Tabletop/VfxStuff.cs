using UnityEngine;

public static class VfxStuff
{
	public static float ReturnPerlinNoise(float seedAdd, float t, float freq, float power)
	{
		return Mathf.PerlinNoise1D(t * freq + seedAdd) * power;
	}

	public static Vector3 NoisedVector(float seedAdd, float t, float freq, float power)
	{
		return new Vector3(ReturnPerlinNoise(seedAdd, t, freq, power), ReturnPerlinNoise(seedAdd + 546f, t, freq, power), ReturnPerlinNoise(seedAdd + 484521f, t, freq, power));
	}

	public static Vector3 SineAlongVector(Vector3 vec, float seedAdd, float t, float freq, float power)
	{
		return SineWithSFP(seedAdd, t, freq, power) * vec;
	}

	public static float SineWithSFP(float seedAdd, float t, float freq, float power)
	{
		return Mathf.Sin(t * freq + seedAdd) * power;
	}

	public static Quaternion MousePosRemappedToRotation(Vector2 mousePos, float rotationSensivity)
	{
		Vector2 vector = MousePosRemaped(mousePos) * rotationSensivity;
		return Quaternion.Euler(vector.x, vector.y, 0f);
	}

	public static Vector2 MousePosRemaped(Vector2 mousePos)
	{
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		float num = vector.y / vector.x;
		Vector2 vector2 = mousePos / vector * 2f - Vector2.one;
		return new Vector2((0f - vector2.y) * num, 0f - vector2.x);
	}
}
