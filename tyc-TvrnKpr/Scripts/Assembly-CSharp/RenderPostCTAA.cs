using UnityEngine;

public class RenderPostCTAA : MonoBehaviour
{
	public CTAA_PC ctaaPC;

	public Transform ctaaCamTransform;

	public Camera MaskRenderCam;

	public Shader maskRenderShader;

	public RenderTexture maskTexRT;

	public bool layerMaskingEnabled;

	public Material layerPostMat;

	private void LateUpdate()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
	}
}
