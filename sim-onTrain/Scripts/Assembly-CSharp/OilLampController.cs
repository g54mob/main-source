using DG.Tweening;
using UnityEngine;

public class OilLampController : MonoBehaviour
{
	public Light lampLight;

	public float lightIntensity = 2f;

	public float openDuration = 0.5f;

	public float openingDelay;

	private void OnEnable()
	{
		lampLight.intensity = 0f;
		lampLight.DOIntensity(lightIntensity, openDuration).SetEase(Ease.OutQuad).SetDelay(openingDelay);
	}

	private void OnDisable()
	{
		lampLight.DOKill();
		lampLight.intensity = 0f;
	}
}
