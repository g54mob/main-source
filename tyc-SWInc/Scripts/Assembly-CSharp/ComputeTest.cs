using System;
using UnityEngine;
using UnityEngine.Rendering;

public class ComputeTest : MonoBehaviour
{
	public ComputeShader CShader;

	public Renderer Target;

	public float PointAlpha = 0.25f;

	public float MaxSpeed = 10f;

	public float NoiseGainMin = 0.2f;

	public float NoiseGainMax = 2f;

	public float FadeSpeedMin = 0.001f;

	public float FadeSpeedMax = 0.1f;

	public float ChangeSpeed = 5f;

	private float _countdown;

	private RenderTexture _rt;

	private Texture2D _noiseLocal;

	private int _threads;

	private static Texture2D _noise;

	private ComputeBuffer _buffer;

	private ComputeBuffer _velBuffer;

	public bool Valid;

	public Collider Col;

	public bool EnableCollider = true;

	private bool _isDragging;

	private void InitNoise()
	{
		if (!(_noise == null))
		{
			return;
		}
		_noiseLocal = (_noise = new Texture2D(1024, 1024, TextureFormat.RHalf, false, false));
		byte[] array = new byte[2 * _noise.width * _noise.height];
		for (int i = 0; i < _noise.width; i++)
		{
			for (int j = 0; j < _noise.height; j++)
			{
				byte[] bytes = BitConverter.GetBytes(Mathf.FloatToHalf(Mathf.PerlinNoise((float)i / 1024f * 10f, (float)j / 1024f * 10f)));
				for (int k = 0; k < 2; k++)
				{
					array[(i * 1024 + j) * 2 + k] = bytes[k];
				}
			}
		}
		_noise.LoadRawTextureData(array);
		_noise.Apply(false);
	}

	private void Awake()
	{
		Valid = SystemInfo.supportsComputeShaders;
		if (!Valid)
		{
			base.gameObject.SetActive(false);
			return;
		}
		int num = 1;
		num = 2;
		_threads = num * 64;
		MaxSpeed *= num;
		NoiseGainMax *= num;
		NoiseGainMin *= num;
		InitNoise();
		RenderTextureFormat format = RenderTextureFormat.ARGBHalf;
		if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLCore)
		{
			format = RenderTextureFormat.ARGBFloat;
		}
		_rt = new RenderTexture(512 * num, 512 * num, 0, format);
		_rt.enableRandomWrite = true;
		_rt.filterMode = FilterMode.Trilinear;
		_rt.anisoLevel = 16;
		_rt.Create();
		_buffer = new ComputeBuffer(512, 8);
		_velBuffer = new ComputeBuffer(512, 8);
		float[] array = new float[1024];
		for (int i = 0; i < 1024; i += 2)
		{
			array[i] = UnityEngine.Random.Range(0, 1024);
			array[i + 1] = UnityEngine.Random.Range(0, 1024);
		}
		_buffer.SetData(array);
		try
		{
			CShader.SetTexture(0, "Result", _rt);
		}
		catch (Exception ex)
		{
			Valid = false;
			UnityEngine.Object.Destroy(_rt);
			_buffer.Release();
			_velBuffer.Release();
			base.gameObject.SetActive(false);
			Debug.Log(ex.ToString());
			return;
		}
		CShader.SetTexture(1, "Result", _rt);
		CShader.SetBuffer(0, "PointBuffer", _buffer);
		CShader.SetBuffer(0, "VelBuffer", _velBuffer);
		CShader.SetTexture(0, "Noise", _noise);
		CShader.SetFloat("Points", _buffer.count);
		CShader.SetFloat("NoiseSize", _noise.width);
		CShader.SetFloat("CanvasSize", _rt.width);
		CShader.SetFloat("PointAlpha", PointAlpha);
		CShader.SetFloat("MaxSpeed", MaxSpeed);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _rt;
		GL.Clear(false, true, RandomizeParams());
		RenderTexture.active = active;
		Target.sharedMaterial.mainTexture = _rt;
	}

	public void Reset()
	{
		_countdown = 0f;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _rt;
		GL.Clear(false, true, RandomizeParams());
		RenderTexture.active = active;
	}

	public Color RandomizeParams()
	{
		int num = 0;
		float v = num.MapRange(0f, 1f, 1f, 0.25f);
		float value = UnityEngine.Random.value;
		Color color = Color.HSVToRGB(value, 1f, v);
		Color color2 = Color.HSVToRGB((value + UnityEngine.Random.Range(0.25f, 0.75f)) % 1f, 1f, v);
		Color color3 = new Color(num, num, num, 1f);
		CShader.SetFloat("NoiseGain", UnityEngine.Random.Range(NoiseGainMin, NoiseGainMax));
		CShader.SetFloat("FadeSpeed", UnityEngine.Random.Range(FadeSpeedMin, FadeSpeedMax));
		CShader.SetVector("StartColor", color);
		CShader.SetVector("EndColor", color2);
		CShader.SetVector("ClearColor", color3);
		CShader.SetVector("NoiseOffset", new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 0f));
		_countdown = 0f;
		return color3;
	}

	public void SetMouse(Vector2 p, bool enabled)
	{
		CShader.SetVector("PushPoint", new Vector4(p.x, p.y, enabled ? 1 : 0, 0f));
	}

	private void FixedUpdate()
	{
		if (Input.GetMouseButton(0) && EnableCollider)
		{
			Ray ray = MainMenuController.Instance.SSAAScript.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (Col.Raycast(ray, out hitInfo, 100f))
			{
				Vector2 p = hitInfo.textureCoord * _rt.width;
				SetMouse(p, true);
				_isDragging = true;
			}
			else if (_isDragging)
			{
				_isDragging = false;
				SetMouse(-Vector2.one, false);
			}
		}
		else if (_isDragging)
		{
			_isDragging = false;
			SetMouse(-Vector2.one, false);
		}
		CShader.Dispatch(0, 8, 1, 1);
		CShader.Dispatch(1, _threads, _threads, 1);
		_countdown += Time.deltaTime;
		if (_countdown >= ChangeSpeed)
		{
			RandomizeParams();
		}
	}

	private void OnDestroy()
	{
		if (Valid)
		{
			UnityEngine.Object.Destroy(_rt);
			_buffer.Release();
			_velBuffer.Release();
		}
	}
}
