using UnityEngine;

public class TerrainData : UpdateableData
{
	public float uniformScale = 2.5f;

	public bool useFalloff;

	public float heightMultiplier;

	public AnimationCurve heightCurve;

	public float minHeight
	{
		get
		{
			float num = heightCurve.Evaluate(0f);
			float num2 = heightMultiplier * uniformScale;
			return num * num2;
		}
	}

	public float maxHeight
	{
		get
		{
			float num = heightCurve.Evaluate(1f);
			float num2 = heightMultiplier * uniformScale;
			return num * num2;
		}
	}
}
