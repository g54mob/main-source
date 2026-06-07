using UnityEngine;

public class RainRippleMultiplierController : MonoBehaviour
{
	public float trainVelocityHasRain;

	public float trainVelocityNoRain;

	public float transitionSpeedUp;

	public float transitionSpeedDown;

	private float desiredMultiplier;

	private void Update()
	{
		Camera activeCamera = PlayerManager.ActiveCamera;
		if (activeCamera == null)
		{
			return;
		}
		desiredMultiplier = 1f;
		TrainCar trainCar = PlayerManager.Car;
		if (activeCamera != PlayerManager.PlayerCamera)
		{
			ExternalCamera component = activeCamera.GetComponent<ExternalCamera>();
			if ((bool)component)
			{
				trainCar = component.CurrentCar;
			}
		}
		if ((bool)trainCar)
		{
			float magnitude = trainCar.GetVelocity().magnitude;
			desiredMultiplier = Mathf.InverseLerp(trainVelocityNoRain, trainVelocityHasRain, magnitude);
		}
		RainRipples.flowMultiplier = Mathf.Lerp(RainRipples.flowMultiplier, desiredMultiplier, Time.deltaTime * ((RainRipples.flowMultiplier < desiredMultiplier) ? transitionSpeedDown : transitionSpeedUp));
		RainRipples.rippleMultiplier = Mathf.Lerp(RainRipples.rippleMultiplier, desiredMultiplier, Time.deltaTime * ((RainRipples.rippleMultiplier < desiredMultiplier) ? transitionSpeedDown : transitionSpeedUp));
	}
}
