using UnityEngine;

public interface IDroneViewProcessor
{
	Camera dvpCameraSetup { get; }

	bool staleData { get; set; }

	int staleDataLifetimeSeconds { get; set; }

	int staleDataMaxLights { get; set; }

	bool staleDataEnableDelayBetweenLights { get; set; }

	int staleDataDelayBetweenLightDropsMS { get; set; }

	float colorCameraBrightness { get; set; }

	bool depthCameraDisableBanding { get; set; }

	void Initialize();

	void BringOnline();

	void SetDVPCamera(Camera camera);

	void Update();

	void DebugDrawSettings(Rect startingRect);
}
