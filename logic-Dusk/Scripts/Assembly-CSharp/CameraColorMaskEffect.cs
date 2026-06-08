using UnityEngine;

[ExecuteInEditMode]
public class CameraColorMaskEffect : ImageEffectBase
{
	public RenderTexture lightMaskRT;

	public float brightness = 1f;

	private Color originalColor = Color.green;

	private void OnDestroy()
	{
		lightMaskRT = null;
	}

	private void OnPreCull()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = false;
		}
		if (DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			int count = DroneManager.Instance.playerDroneSpotlights.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = DroneManager.Instance.playerDroneSpotlights[i];
				if (gameObject != null)
				{
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(true);
					}
					gameObject.GetComponent<Light>().color = Color.white;
				}
			}
		}
		if (DroneManager.Instance != null && DroneManager.Instance.EnableStaleData && DroneManager.Instance.sdLightArray != null && DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			DroneManager.Instance.SetLightArrayStatus(false);
		}
	}

	private void OnPreRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = false;
		}
		if (DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			int count = DroneManager.Instance.playerDroneSpotlights.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = DroneManager.Instance.playerDroneSpotlights[i];
				if (gameObject != null)
				{
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(true);
					}
					gameObject.GetComponent<Light>().color = Color.white;
				}
			}
		}
		if (DroneManager.Instance != null && DroneManager.Instance.EnableStaleData && DroneManager.Instance.sdLightArray != null && DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			DroneManager.Instance.SetLightArrayStatus(false);
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetTexture("_LightMaskTex", lightMaskRT);
		base.material.SetFloat("_Brightness", brightness);
		Graphics.Blit(src, dest, base.material);
	}

	private void OnPostRender()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
		if (DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			int count = DroneManager.Instance.playerDroneSpotlights.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = DroneManager.Instance.playerDroneSpotlights[i];
				if (gameObject != null)
				{
					gameObject.GetComponent<Light>().color = originalColor;
				}
			}
		}
		if (DroneManager.Instance != null && DroneManager.Instance.EnableStaleData && DroneManager.Instance.sdLightArray != null && DroneManager.Instance != null && DroneManager.Instance.playerDroneSpotlights != null)
		{
			DroneManager.Instance.SetLightArrayStatus(true);
		}
	}
}
