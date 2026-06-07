using UnityEngine;

public class LightIntensityZone : MonoBehaviour
{
	[Header("Light To Control")]
	public Light targetLight;

	[Header("Zone Settings")]
	public Transform[] zoneCenters;

	public float dimRadius = 3f;

	[Header("Intensity Settings")]
	public float normalIntensity = 1f;

	public float dimmedIntensity = 0.1f;

	public float fadeSpeed = 5f;

	private void Update()
	{
		if (!GameManager.Singleton || !GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			return;
		}
		Vector3 b = Vector3.zero;
		if (zoneCenters.Length == 1)
		{
			b = zoneCenters[0].position;
		}
		else if (zoneCenters.Length > 1)
		{
			float num = float.PositiveInfinity;
			Transform[] array = zoneCenters;
			foreach (Transform transform in array)
			{
				float num2 = Vector3.Distance(base.transform.position, transform.position);
				if (num2 < num)
				{
					b = transform.position;
					num = num2;
				}
			}
		}
		float b2 = ((Vector3.Distance(targetLight.transform.position, b) < dimRadius) ? dimmedIntensity : normalIntensity);
		targetLight.intensity = Mathf.Lerp(targetLight.intensity, b2, Time.deltaTime * fadeSpeed);
	}
}
