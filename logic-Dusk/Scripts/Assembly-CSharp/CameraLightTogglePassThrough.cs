using UnityEngine;

public class CameraLightTogglePassThrough : ImageEffectBase
{
	private void OnPreCull()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
		if (DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
		{
			if (DroneManager.Instance.DebugEnableCameraArray)
			{
				DroneManager.Instance.CurrentDrone.transform.Find("SpotlightTestCameraArray").gameObject.SetActive(false);
			}
			else
			{
				DroneManager.Instance.CurrentDrone.Swival.transform.Find("SpotlightTest").gameObject.SetActive(false);
			}
		}
	}

	private void OnPreRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
		if (DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
		{
			if (DroneManager.Instance.DebugEnableCameraArray)
			{
				DroneManager.Instance.CurrentDrone.transform.Find("SpotlightTestCameraArray").gameObject.SetActive(false);
			}
			else
			{
				DroneManager.Instance.CurrentDrone.Swival.transform.Find("SpotlightTest").gameObject.SetActive(false);
			}
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, base.material);
	}

	private void OnPostRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = false;
		}
	}
}
