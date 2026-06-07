using UltimateReplay;
using UnityEngine;
using VolumetricLines;

public class LaserEmitterReplay : ReplayBehaviour
{
	private LaserRayBase laserRay;

	private VolumetricLineBehavior[] volumetricLineBehavior;

	private Light[] lights;

	public override void Awake()
	{
		base.Awake();
		laserRay = GetComponent<LaserRayBase>();
		volumetricLineBehavior = GetComponentsInChildren<VolumetricLineBehavior>(includeInactive: true);
		lights = GetComponentsInChildren<Light>(includeInactive: true);
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		for (int i = 0; i < lights.Length; i++)
		{
			lights[i].enabled = true;
		}
		for (int j = 0; j < volumetricLineBehavior.Length; j++)
		{
			volumetricLineBehavior[j].enabled = true;
		}
		laserRay.IsOnReplay = true;
		laserRay.enabled = true;
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		laserRay.IsOnReplay = false;
	}
}
