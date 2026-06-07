using UnityEngine;
using UnityEngine.UI;

public class TextureCam : MonoBehaviour
{
	public Camera Cam;

	public Canvas Cvs;

	public RectTransform XfmCanvas;

	public RawImage ImgTexture;

	private const int kPixCamSize = 256;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public void SetOrtho(float ortho)
	{
	}
}
