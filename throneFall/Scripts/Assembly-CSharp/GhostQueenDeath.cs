using UnityEngine;

public class GhostQueenDeath : MonoBehaviour
{
	private float scale;

	private float startLightIntensity;

	[SerializeField]
	private Light nightLight;

	private void Start()
	{
		scale = 1f;
		startLightIntensity = nightLight.intensity;
	}

	private void Update()
	{
		scale -= Time.deltaTime / 2f;
		base.transform.localScale = scale * Vector3.one;
		nightLight.intensity = scale * startLightIntensity;
		if (scale <= 0f)
		{
			nightLight.intensity = 0f;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				base.transform.GetChild(i).gameObject.SetActive(value: false);
			}
		}
	}
}
