using UnityEngine;

[ExecuteInEditMode]
public class CameraEdgeDetection : ImageEffectBase
{
	public RenderTexture pixelRT;

	public RenderTexture lightMaskRT;

	[Tooltip("The scale of the texture's uv scale.\r\n\r\nNote, this is multiplication, so 0.5 = half scale")]
	public float pixelUVScale = 0.5f;

	[Tooltip("This is the dullness of the non-data (data outside of the light cone).")]
	public float dullnessOfNonData = 0.5f;

	[Header("Edge Detection Options")]
	public float sensitivityDepth = 1f;

	public float sensitivityNormals = 1f;

	public float edgeExp = 1f;

	public float sampleDist = 1f;

	[Tooltip("Enable the sonar effect.\r\n\r\nNote: The 'Camera Sonar Effect' component must be enabled on the LightDataCamera object, which animates and configures the sonar lines")]
	[Header("Sonar Effect Options")]
	public bool enableSonar = true;

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
		if (spotlightObject != null && !spotlightObject.activeSelf)
		{
			spotlightObject.SetActive(true);
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
		if (spotlightObject != null && !spotlightObject.activeSelf)
		{
			spotlightObject.SetActive(true);
		}
		if (pixelRT != null)
		{
			pixelRT.wrapMode = TextureWrapMode.Repeat;
		}
		if (GetComponent<Camera>().targetTexture != null)
		{
			GetComponent<Camera>().targetTexture.isPowerOfTwo = false;
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (pixelRT != null)
		{
			base.material.SetTexture("_PixelTex", pixelRT);
		}
		if (lightMaskRT != null)
		{
			base.material.SetTexture("_LightMaskTex", lightMaskRT);
		}
		Vector2 vector = new Vector2(sensitivityDepth, sensitivityNormals);
		base.material.SetVector("_Sensitivity", new Vector4(vector.x, vector.y, 1f, vector.y));
		base.material.SetFloat("_SampleDistance", sampleDist);
		base.material.SetFloat("_ScaleRaised", pixelUVScale);
		base.material.SetFloat("_DullnessOfNonData", dullnessOfNonData);
		if (enableSonar)
		{
			base.material.SetFloat("_EnableSonar", 1f);
		}
		else
		{
			base.material.SetFloat("_EnableSonar", 0f);
		}
		Graphics.Blit(src, dest, base.material);
	}
}
