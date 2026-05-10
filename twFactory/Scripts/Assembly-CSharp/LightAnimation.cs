using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightAnimation : MonoBehaviour
{
	[SerializeField]
	private bool startEnabled = true;

	[SerializeField]
	private float defaultAnimationDuration = 1f;

	private Light light;

	private float intensity;

	private Tween currentTween;

	private void Awake()
	{
		light = GetComponent<Light>();
		intensity = light.intensity;
	}

	private void Start()
	{
		if (!startEnabled)
		{
			light.intensity = 0f;
			light.enabled = false;
		}
	}

	public void TurnOn()
	{
		TurnOn(defaultAnimationDuration);
	}

	public void TurnOn(float time)
	{
		light.intensity = 0f;
		light.enabled = true;
		if (currentTween != null && currentTween.IsActive())
		{
			currentTween.Kill();
		}
		currentTween = light.DOIntensity(intensity, time).SetEase(Ease.InOutSine);
	}

	public void TurnOff()
	{
		TurnOff(defaultAnimationDuration);
	}

	public void TurnOff(float time)
	{
		if (currentTween != null && currentTween.IsActive())
		{
			currentTween.Kill();
		}
		currentTween = light.DOIntensity(0f, time).SetEase(Ease.InOutSine);
		currentTween.OnComplete(delegate
		{
			light.enabled = false;
		});
	}
}
