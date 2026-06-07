using UnityEngine;

[ExecuteInEditMode]
public class WindController : MonoBehaviour
{
	[Header("Wind Properties")]
	private Vector3 direction = Vector3.right;

	[SerializeField]
	[Range(0f, 1f)]
	private float intensity = 0.5f;

	[SerializeField]
	private Texture2D noise;

	[SerializeField]
	private float noiseSpeed = 1f;

	private void Awake()
	{
		UpdateShaderValues();
	}

	private void Update()
	{
		if (!Application.isPlaying && Application.isEditor)
		{
			base.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
			UpdateShaderValues();
		}
	}

	private void OnValidate()
	{
		if (!Application.isPlaying && Application.isEditor)
		{
			UpdateShaderValues();
		}
	}

	private void UpdateShaderValues()
	{
		direction = base.transform.forward * intensity;
		Shader.SetGlobalVector("WindDirection", direction);
		Shader.SetGlobalFloat("WindIntensity", intensity);
		Shader.SetGlobalTexture("WindNoise", noise);
		Shader.SetGlobalFloat("WindNoiseSpeed", noiseSpeed);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.Lerp(Color.green, Color.red, intensity);
		Gizmos.DrawLine(base.transform.position + base.transform.right * 0.05f, base.transform.position + base.transform.forward + base.transform.right * 0.05f);
		Gizmos.DrawLine(base.transform.position + base.transform.right * -0.05f, base.transform.position + base.transform.forward + base.transform.right * -0.05f);
		Gizmos.DrawLine(base.transform.position + base.transform.forward + base.transform.right * 0.05f, base.transform.position + base.transform.forward * 0.7f + base.transform.right * 0.4f);
		Gizmos.DrawLine(base.transform.position + base.transform.forward + base.transform.right * -0.05f, base.transform.position + base.transform.forward * 0.7f + base.transform.right * -0.4f);
		Gizmos.DrawLine(base.transform.position + base.transform.forward * 0.7f + base.transform.right * 0.4f, base.transform.position + base.transform.forward * 1.3f);
		Gizmos.DrawLine(base.transform.position + base.transform.forward * 0.7f + base.transform.right * -0.4f, base.transform.position + base.transform.forward * 1.3f);
	}
}
