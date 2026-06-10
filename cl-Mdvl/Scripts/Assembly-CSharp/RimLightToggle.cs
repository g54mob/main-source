using UnityEngine;

[ExecuteInEditMode]
public class RimLightToggle : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 1f)]
	private float rimLightGlobalShader;

	private void Start()
	{
	}

	private void Update()
	{
		Shader.SetGlobalFloat("_RimLightStrength", rimLightGlobalShader);
	}
}
