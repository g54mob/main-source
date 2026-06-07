using UnityEngine;
using UnityEngine.Rendering;

public class CensorCamera : MonoBehaviour
{
	private RenderTexture tex;

	private RenderTexture tex3;

	public RenderTexture tex2;

	public Texture2D White;

	public Material Mat;

	public Material Mat2;

	public Material BlurMaterial;

	public Material OutlineMat;

	public Material FlatColorMat;

	public Mesh CensorMesh;

	public float BlurSize;

	public int BlurIt = 2;

	public static CensorCamera Instance;

	private Material _camHDR;

	public Vector3 Scale = Vector3.one;

	public Vector3 Rot = Vector3.one;

	private CommandBuffer _buffer;

	private void Awake()
	{
		float num = (float)Screen.width / (float)Screen.height;
		tex = new RenderTexture(Mathf.RoundToInt(64f * num), 64, 24, RenderTextureFormat.ARGB32);
		tex.autoGenerateMips = false;
		tex.filterMode = FilterMode.Point;
		tex.wrapMode = TextureWrapMode.Clamp;
		Mat.mainTexture = tex;
		tex3 = new RenderTexture(Mathf.RoundToInt(256f * num), 256, 24, RenderTextureFormat.ARGB32);
		tex3.autoGenerateMips = false;
		tex3.filterMode = FilterMode.Bilinear;
		tex3.wrapMode = TextureWrapMode.Clamp;
		BlurMaterial = new Material(BlurMaterial);
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	private void DoGrass()
	{
		Camera mainCam = CameraScript.Instance.mainCam;
		if (_buffer == null)
		{
			_buffer = new CommandBuffer();
			mainCam.AddCommandBuffer(CameraEvent.BeforeGBuffer, _buffer);
			_camHDR = new Material(Shader.Find("Hidden/HDRConversion"));
		}
		_buffer.Clear();
		Renderer grassPlane = TimeOfDay.Instance.GrassPlane;
		int num = Shader.PropertyToID("_MainTex");
		_buffer.GetTemporaryRT(num, Screen.width, Screen.height, 24, FilterMode.Bilinear, RenderTextureFormat.ARGBHalf);
		_buffer.SetRenderTarget(new RenderTargetIdentifier(num));
		_buffer.ClearRenderTarget(true, true, Color.black);
		_buffer.DrawRenderer(grassPlane, grassPlane.sharedMaterial, 0, 2);
		_buffer.Blit(num, BuiltinRenderTextureType.GBuffer0);
		_buffer.Blit(num, BuiltinRenderTextureType.CameraTarget, _camHDR);
		_buffer.SetRenderTarget(new RenderTargetIdentifier(num));
		_buffer.ReleaseTemporaryRT(num);
		_buffer.SetRenderTarget(BuiltinRenderTextureType.GBuffer2);
		_buffer.ClearRenderTarget(true, true, new Color(0.5f, 1f, 0.5f));
		_buffer.SetRenderTarget(BuiltinRenderTextureType.GBuffer1);
		_buffer.ClearRenderTarget(true, true, new Color(0.2f, 0.2f, 0.2f, 0f));
		_buffer.SetRenderTarget(BuiltinRenderTextureType.None, BuiltinRenderTextureType.CameraTarget);
		Matrix4x4 matrix4x = Matrix4x4.LookAt(mainCam.transform.position, mainCam.transform.position + mainCam.transform.forward, -mainCam.transform.up);
		Matrix4x4 view = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(1f, 1f, -1f)) * matrix4x.inverse;
		_buffer.SetViewProjectionMatrices(view, mainCam.projectionMatrix * Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(Rot), Scale));
		_buffer.DrawRenderer(grassPlane, grassPlane.sharedMaterial, 0, 2);
	}

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, tex);
		BlurMaterial.SetVector("_Parameter", new Vector4(BlurSize, 0f - BlurSize, 0f, 0f));
		bool num = (BlurIt & 1) == 0;
		RenderTexture renderTexture = (num ? tex3 : tex2);
		RenderTexture renderTexture2 = (num ? tex2 : tex3);
		bool flag = true;
		for (int i = 0; i < BlurIt; i++)
		{
			if (flag)
			{
				Graphics.Blit(source, renderTexture, BlurMaterial, 0);
				flag = false;
			}
			else
			{
				Graphics.Blit(renderTexture2, renderTexture, BlurMaterial, 0);
			}
			Graphics.Blit(renderTexture, renderTexture2, BlurMaterial, 1);
			Graphics.Blit(renderTexture2, renderTexture, BlurMaterial, 2);
			RenderTexture renderTexture3 = renderTexture2;
			renderTexture2 = renderTexture;
			renderTexture = renderTexture3;
		}
		Graphics.Blit(source, destination);
	}
}
