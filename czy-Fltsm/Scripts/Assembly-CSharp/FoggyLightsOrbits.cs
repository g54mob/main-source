using UnityEngine;

public class FoggyLightsOrbits : MonoBehaviour
{
	public float SpinSpeed = 50f;

	private float X;

	private float Y;

	private float Z;

	[Range(0f, 1f)]
	public float _ColorSpeed = 1f;

	private float ColorSpeed;

	private Vector3 RandomRangeXYZ;

	private float Opacity;

	private void Start()
	{
		Opacity = base.transform.GetChild(0).GetComponent<FoggyLight>().PointLightColor.a;
		RandomRangeXYZ.x = Random.Range(0f, 1f);
		RandomRangeXYZ.y = Random.Range(0f, 1f);
		RandomRangeXYZ.z = Random.Range(0f, 1f);
	}

	private void Update()
	{
		ColorSpeed += Time.deltaTime * _ColorSpeed;
		base.transform.Rotate(0f, Time.deltaTime * SpinSpeed, 0f);
		X = Mathf.Sin(ColorSpeed * RandomRangeXYZ.x) * 0.5f + 0.5f;
		Y = Mathf.Sin(ColorSpeed * RandomRangeXYZ.y) * 0.5f + 0.5f;
		Z = Mathf.Sin(ColorSpeed * RandomRangeXYZ.z) * 0.5f + 0.5f;
		Color pointLightColor = new Color(X, Y, Z, Opacity);
		base.transform.GetChild(0).GetComponent<FoggyLight>().PointLightColor = pointLightColor;
	}
}
