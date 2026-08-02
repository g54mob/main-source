using UnityEngine;

[ExecuteInEditMode]
public class BK_EnvironmentManager : MonoBehaviour
{
	public Light directionalLight;

	public Gradient sunColorGradient;

	public Gradient fogColorGradient;

	public Gradient cloudColorGradient;

	public Gradient scatteringColorGradient;

	[Header("Color Gradients Enable Flags")]
	public bool overrideSunColor = true;

	public bool overrideFogColor = true;

	public bool overrideCloudColor = true;

	[Header("Base Wind")]
	[Tooltip("Base wind animate the trunks")]
	[Range(0f, 5f)]
	public float baseWindPower = 3f;

	[Tooltip("Base wind animate the trunks")]
	public float baseWindSpeed = 1f;

	[Header("Wind Burst")]
	[Tooltip("Bursts are managed by a moving World-Space noise that multiply the base wind speed and power")]
	[Range(0f, 10f)]
	public float burstsPower = 0.5f;

	[Tooltip("Speed of the Bursts noise")]
	public float burstsSpeed = 5f;

	[Tooltip("Size of the Bursts noise in Word-Space")]
	public float burstsScale = 10f;

	[Header("Micro Wind")]
	[Tooltip("Micro wind animate the leaves")]
	[Range(0f, 1f)]
	public float microPower = 0.1f;

	[Tooltip("Micro wind animate the leaves")]
	public float microSpeed = 1f;

	[Tooltip("Micro wind animate the leaves")]
	public float microFrequency = 3f;

	[Space(10f)]
	public float renderDistance = 30f;

	[Space(10f)]
	public float Altitude = 1000f;

	public float volumeSize = 500f;

	public int volumeSamples = 25;

	private float volumeOffset;

	private Mesh quadMesh;

	private Matrix4x4[] matrices;

	[Space(10f)]
	[Tooltip("Material for the clouds")]
	public Material cloudsMaterial;

	private bool hasIssuedMaterialWarning;

	private void Awake()
	{
		quadMesh = Resources.GetBuiltinResource<Mesh>("Quad.fbx");
		matrices = new Matrix4x4[volumeSamples];
	}

	private void Update()
	{
		UpdateEnvironment();
		UpdateCloudsVolume();
		UpdateLighting();
	}

	private void UpdateEnvironment()
	{
		Shader.SetGlobalFloat("WindPower", baseWindPower);
		Shader.SetGlobalFloat("WindSpeed", baseWindSpeed);
		Shader.SetGlobalFloat("WindBurstsPower", burstsPower);
		Shader.SetGlobalFloat("WindBurstsSpeed", burstsSpeed);
		Shader.SetGlobalFloat("WindBurstsScale", burstsScale);
		Shader.SetGlobalFloat("MicroPower", microPower);
		Shader.SetGlobalFloat("MicroSpeed", microSpeed);
		Shader.SetGlobalFloat("MicroFrequency", microFrequency);
		Shader.SetGlobalFloat("GrassRenderDist", renderDistance);
	}

	private void UpdateCloudsVolume()
	{
		volumeSamples = Mathf.Max(1, volumeSamples);
		volumeSize = Mathf.Max(0f, volumeSize);
		if (cloudsMaterial == null)
		{
			return;
		}
		if (matrices.Length != volumeSamples)
		{
			matrices = new Matrix4x4[volumeSamples];
		}
		if (!cloudsMaterial.HasProperty("_ScatteringColor"))
		{
			if (!hasIssuedMaterialWarning)
			{
				Debug.LogWarning("The assigned material in the Cloud material slot of the EnvironmentManager isn't supported.");
				hasIssuedMaterialWarning = true;
			}
			return;
		}
		hasIssuedMaterialWarning = false;
		cloudsMaterial.SetFloat("_cloudsPosition", Altitude);
		cloudsMaterial.SetFloat("_cloudsHeight", volumeSize);
		volumeOffset = volumeSize / (float)volumeSamples / 2f;
		Vector3 vector = new Vector3(0f, Altitude, 0f) + Vector3.up * (volumeOffset * (float)volumeSamples / 2f);
		for (int i = 0; i < volumeSamples; i++)
		{
			matrices[i] = Matrix4x4.TRS(vector - Vector3.up * volumeOffset * i, Quaternion.Euler(-90f, 0f, 0f), new Vector3(10000f, 10000f, 10000f));
		}
		Graphics.DrawMeshInstanced(quadMesh, 0, cloudsMaterial, matrices, volumeSamples);
	}

	private void UpdateLighting()
	{
		if (!(directionalLight == null))
		{
			float time = (Vector3.Dot(directionalLight.transform.forward, Vector3.up) + 1f) / 2f;
			if (overrideFogColor)
			{
				RenderSettings.fogColor = fogColorGradient.Evaluate(time);
			}
			if (overrideSunColor)
			{
				directionalLight.color = sunColorGradient.Evaluate(time);
			}
			if (cloudsMaterial != null && cloudsMaterial.HasProperty("_ScatteringColor") && overrideCloudColor)
			{
				cloudsMaterial.SetColor("_ScatteringColor", scatteringColorGradient.Evaluate(time));
			}
			else if (cloudsMaterial == null)
			{
				Debug.LogError("cloudsMaterial is null. Please assign a material.");
			}
		}
	}
}
