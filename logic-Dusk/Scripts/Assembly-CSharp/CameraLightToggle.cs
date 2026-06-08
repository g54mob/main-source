using UnityEngine;

public class CameraLightToggle : ImageEffectBase
{
	public RenderTexture highMirrorMaskRT;

	public RenderTexture colorMaskRT;

	private GameObject spotlightObject;

	private void OnPreCull()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
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
		if (spotlightObject != null && spotlightObject.activeSelf)
		{
			spotlightObject.SetActive(false);
		}
	}

	private void OnPreRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
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
		if (spotlightObject != null && spotlightObject.activeSelf)
		{
			spotlightObject.SetActive(false);
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (highMirrorMaskRT != null)
		{
			base.material.SetTexture("_LightMaskTex", highMirrorMaskRT);
		}
		if (colorMaskRT != null)
		{
			base.material.SetTexture("_ColorMaskTex", colorMaskRT);
		}
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
