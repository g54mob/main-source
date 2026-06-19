using UnityEngine;

public class SeedTester : MonoBehaviour
{
	private const int MAX_VALUE = 100000;

	[Range(0f, 100000f)]
	public int seed;

	private void OnEnable()
	{
		UpdateShaderParameter();
	}

	private void OnValidate()
	{
		UpdateShaderParameter();
	}

	public void Randomize()
	{
		seed = Random.Range(0, 100000);
		UpdateShaderParameter();
	}

	private void UpdateShaderParameter()
	{
		Shader.SetGlobalFloat("seed", seed);
	}
}
