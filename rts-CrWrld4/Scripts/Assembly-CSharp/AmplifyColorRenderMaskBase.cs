using AmplifyColor;
using UnityEngine;

[ExecuteInEditMode]
public class AmplifyColorRenderMaskBase : MonoBehaviour
{
	public Color ClearColor;

	public RenderLayer[] RenderLayers;

	public bool DebugMask;

	private Camera referenceCamera;

	private Camera maskCamera;

	private AmplifyColorBase colorEffect;

	private int width;

	private int height;

	private RenderTexture maskTexture;

	private Shader colorMaskShader;

	private bool singlePassStereo;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void DestroyCamera()
	{
	}

	private void DestroyRenderTextures()
	{
	}

	private void UpdateRenderTextures(bool singlePassStereo)
	{
	}

	private void UpdateCameraProperties()
	{
	}

	private void OnPreRender()
	{
	}
}
