using UnityEngine;
using UnityEngine.UI;

public class ReEntryMrt : MonoBehaviour
{
	private Camera _camera;

	[SerializeField]
	private RawImage _debugImg;

	[SerializeField]
	private bool _showDebug;

	[SerializeField]
	private RenderTexture _tex;

	private void Awake()
	{
		_camera = GetComponent<Camera>();
		_debugImg.enabled = _showDebug;
	}

	private void OnPreCull()
	{
		RenderBuffer colorBuffer = _tex.colorBuffer;
		_camera.SetTargetBuffers(new RenderBuffer[2]
		{
			RenderTexture.GetTemporary(_camera.pixelWidth, _camera.pixelHeight).colorBuffer,
			colorBuffer
		}, _tex.depthBuffer);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination);
	}

	private void OnValidate()
	{
		_debugImg.enabled = _showDebug;
	}

	private void Update()
	{
	}
}
