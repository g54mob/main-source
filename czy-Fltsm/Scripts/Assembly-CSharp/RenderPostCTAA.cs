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
		base.transform.position = ctaaCamTransform.position;
		base.transform.rotation = ctaaCamTransform.rotation;
		MaskRenderCam.transform.position = ctaaCamTransform.position;
		MaskRenderCam.transform.rotation = ctaaCamTransform.rotation;
	}

	private void OnDisable()
	{
		if (maskTexRT != null)
		{
			Object.DestroyImmediate(maskTexRT);
		}
		maskTexRT = null;
		if (MaskRenderCam != null)
		{
			MaskRenderCam.targetTexture = null;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (maskTexRT == null || maskTexRT.width != source.width || maskTexRT.height != source.height)
		{
			Object.DestroyImmediate(maskTexRT);
			maskTexRT = new RenderTexture(source.width, source.height, 16, source.format);
			maskTexRT.hideFlags = HideFlags.HideAndDontSave;
			maskTexRT.filterMode = FilterMode.Bilinear;
			maskTexRT.wrapMode = TextureWrapMode.Repeat;
			MaskRenderCam.targetTexture = maskTexRT;
		}
		if (layerMaskingEnabled)
		{
			MaskRenderCam.RenderWithShader(maskRenderShader, "");
		}
		RenderTexture cTAA_Render = ctaaPC.getCTAA_Render();
		if (cTAA_Render != null)
		{
			layerPostMat.SetTexture("_CTAA_RENDER", cTAA_Render);
			layerPostMat.SetTexture("_maskTexRT", maskTexRT);
			if (layerMaskingEnabled)
			{
				Graphics.Blit(source, destination, layerPostMat);
			}
			else
			{
				Graphics.Blit(cTAA_Render, destination);
			}
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}
}
