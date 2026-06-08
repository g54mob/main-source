using UnityEngine;

[ExecuteInEditMode]
public class CameraEdgeDetectionAndColorEffect : ImageEffectBase
{
	public RenderTexture pixelRT;

	public RenderTexture lightMaskRT;

	public RenderTexture colorMaskRT;

	[Tooltip("The scale of the texture's uv scale.\r\n\r\nNote, this is multiplication, so 0.5 = half scale")]
	public float pixelUVScale = 0.5f;

	[Tooltip("This is the dullness of the non-data (data outside of the light cone).")]
	public float dullnessOfNonData = 0.5f;

	[Header("Edge Detection Options")]
	public float sensitivityDepth = 1f;

	public float sensitivityNormals = 1f;

	public float edgeExp = 1f;

	public float sampleDist = 1f;

	private Vector4 sensitivityVector = Vector4.zero;

	private void OnDestroy()
	{
		pixelRT = null;
		lightMaskRT = null;
		colorMaskRT = null;
	}

	private void OnPreCull()
	{
		if (DungeonManager.Instance != null && DungeonManager.Instance.SchematicBaseLight != null)
		{
			DungeonManager.Instance.SchematicBaseLight.enabled = true;
		}
		if (!(DroneManager.Instance != null) || DroneManager.Instance.playerDroneSpotlights == null)
		{
			return;
		}
		int count = DroneManager.Instance.playerDroneSpotlights.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject = DroneManager.Instance.playerDroneSpotlights[i];
			if (gameObject != null && !gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
		}
	}

	private void OnPreRender()
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
				if (gameObject != null && !gameObject.activeSelf)
				{
					gameObject.SetActive(true);
				}
			}
		}
		if (pixelRT != null)
		{
			pixelRT.wrapMode = TextureWrapMode.Repeat;
		}
		if (GetComponent<Camera>().targetTexture != null)
		{
			GetComponent<Camera>().targetTexture.isPowerOfTwo = false;
		}
		sensitivityVector.x = sensitivityDepth;
		sensitivityVector.y = sensitivityNormals;
		sensitivityVector.z = 1f;
		sensitivityVector.w = sensitivityNormals;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		base.material.SetTexture("_PixelTex", pixelRT);
		base.material.SetTexture("_LightMaskTex", lightMaskRT);
		base.material.SetTexture("_ColorMaskTex", colorMaskRT);
		base.material.SetVector("_Sensitivity", sensitivityVector);
		base.material.SetFloat("_SampleDistance", sampleDist);
		base.material.SetFloat("_ScaleRaised", pixelUVScale);
		base.material.SetFloat("_DullnessOfNonData", dullnessOfNonData);
		Graphics.Blit(src, dest, base.material);
	}
}
