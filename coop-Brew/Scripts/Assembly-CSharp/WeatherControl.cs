using UnityEngine;

public class WeatherControl : MonoBehaviour
{
	[Range(0f, 1f)]
	public float windIntensity;

	[Range(0f, 1f)]
	public float weatherIntensity;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void UpdateShaderGlobals()
	{
	}
}
