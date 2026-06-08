using UnityEngine;

public class ParallaxWater : ParallaxLayer
{
	public float waterSpeedX = 1f;

	public float waterSpeedY;

	private float fScrollX;

	private float fScrollY;

	private GameCameraBinding cameraBinding;

	protected override void Awake()
	{
		base.Awake();
		cameraBinding = GetComponent<GameCameraBinding>();
	}

	protected override void Update()
	{
		base.Update();
		if (AsciiAnimation.allAnimationsEnabled)
		{
			fScrollX += Utils.deltaTime * waterSpeedX;
			fScrollY += Utils.deltaTime * waterSpeedY;
			if (cameraBinding != null && cameraBinding.gameCamera != null)
			{
				base.ParallaxX = cameraBinding.gameCamera.PositionX;
			}
			else
			{
				base.ParallaxX = 0;
			}
		}
	}

	protected override void UpdateParallaxX()
	{
		parallaxX += Mathf.RoundToInt(fScrollX);
		base.UpdateParallaxX();
	}

	protected override void UpdateParallaxY()
	{
		parallaxY += Mathf.RoundToInt(fScrollY);
		base.UpdateParallaxY();
	}
}
