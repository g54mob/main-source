using AmplifyColor;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu(null)]
public class AmplifyColorRenderMaskBase : MonoBehaviour
{
	public Camera maskCamera;

	public Color clearColor;

	public RenderLayer[] renderLayers;

	public bool debug;

	private Camera camera;

	private AmplifyColorBase colorEffect;

	private int width;

	private int height;

	private RenderTexture maskTexture;

	private Shader colorMaskShader;

	private Shader colorMaskShaderAlpha;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void DestroyRenderTextures()
	{
	}

	private void UpdateRenderTextures()
	{
	}

	private void UpdateCameraProperties()
	{
	}

	private void Render(Shader shader)
	{
	}

	private void OnPreRender()
	{
	}
}
