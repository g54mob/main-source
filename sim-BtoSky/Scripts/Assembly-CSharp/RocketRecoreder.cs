using UnityEngine;

public class RocketRecoreder : MonoBehaviour
{
	public enum Type
	{
		DigitalCam = 0,
		RocketCam = 1
	}

	public Type type;

	public Camera cam;

	private void Start()
	{
		RocketMount.OnRocketMounted += RocketMount_OnRocketMounted;
		BusStopUI.OnRocketRetrived += BusStopUI_OnRocketRetrived;
		if (type == Type.DigitalCam && GameManager.S.isRocketMountExist && !GameManager.S.isRocketCamInstalled)
		{
			cam.enabled = true;
		}
	}

	private void BusStopUI_OnRocketRetrived()
	{
		cam.enabled = false;
	}

	private void RocketMount_OnRocketMounted()
	{
		if (type == Type.DigitalCam)
		{
			if (!GameManager.S.isRocketCamInstalled)
			{
				cam.enabled = true;
			}
			else
			{
				cam.enabled = false;
			}
		}
	}

	private void OnDestroy()
	{
		RocketMount.OnRocketMounted -= RocketMount_OnRocketMounted;
		BusStopUI.OnRocketRetrived -= BusStopUI_OnRocketRetrived;
	}
}
