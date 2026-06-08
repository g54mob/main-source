using UnityEngine;

public class CameraLightArrayFinalPassEffect : ImageEffectBase
{
	public RenderTexture colorMaskRT;

	private void OnPreCull()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
		if (DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			DroneManager.Instance.SetLightArrayStatus(false);
		}
	}

	private void OnPreRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
		if (!(DroneManager.Instance != null) || DroneManager.Instance.playerDroneSpotlights == null)
		{
			return;
		}
		foreach (GameObject playerDroneSpotlight in DroneManager.Instance.playerDroneSpotlights)
		{
			if (playerDroneSpotlight.activeSelf)
			{
				playerDroneSpotlight.SetActive(false);
			}
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
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
