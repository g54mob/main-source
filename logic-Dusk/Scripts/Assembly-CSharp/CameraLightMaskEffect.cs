using UnityEngine;

[ExecuteInEditMode]
public class CameraLightMaskEffect : ImageEffectBase
{
	private GameObject spotlightObject;

	private void OnDestroy()
	{
		spotlightObject = null;
	}

	private void OnPreCull()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = false;
		}
		if (spotlightObject == null && DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
		{
			if (DroneManager.Instance.DebugEnableCameraArray)
			{
				spotlightObject = DroneManager.Instance.CurrentDrone.transform.Find("SpotlightTestCameraArray").gameObject;
			}
			else
			{
				spotlightObject = DroneManager.Instance.CurrentDrone.Swival.transform.Find("SpotlightTest").gameObject;
			}
		}
		if (spotlightObject != null && !spotlightObject.activeSelf)
		{
			spotlightObject.SetActive(true);
		}
	}

	private void OnPreRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = false;
		}
		if (spotlightObject == null && DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
		{
			if (DroneManager.Instance.DebugEnableCameraArray)
			{
				spotlightObject = DroneManager.Instance.CurrentDrone.transform.Find("SpotlightTestCameraArray").gameObject;
			}
			else
			{
				spotlightObject = DroneManager.Instance.CurrentDrone.Swival.transform.Find("SpotlightTest").gameObject;
			}
		}
		if (spotlightObject != null && !spotlightObject.activeSelf)
		{
			spotlightObject.SetActive(true);
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
		Graphics.Blit(src, dest, base.material);
	}

	private void OnPostRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
	}
}
