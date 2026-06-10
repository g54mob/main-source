using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Map;
using UnityEngine;

public class ParticleGeometryGenerator : MonoBehaviour
{
	[SerializeField]
	private float fallSpeed = 1f;

	[SerializeField]
	private float wobbleAmount = 0.5f;

	[SerializeField]
	private float wobbleFrequency = 10f;

	[SerializeField]
	private Vector3 windDirection = Vector3.zero;

	[SerializeField]
	private ComputeShader computeShader;

	[SerializeField]
	private float particlesMinHeight;

	[SerializeField]
	private float particlesMaxHeight = 48f;

	[SerializeField]
	private int particlesCount = 50000;

	[SerializeField]
	private float cubeOffsetForward;

	[SerializeField]
	private Vector3 cubeBounds = Vector3.one;

	[SerializeField]
	private bool debugSnapToFloor;

	[Tooltip("Set this to true if you don't want particles to go through mesh floors.")]
	[SerializeField]
	private bool useAlternativeHeightmap;

	private Vector3 mapSize;

	private ComputeBuffer outputBuffer;

	private ComputeBuffer randomBuffer;

	private int computeShaderKernel;

	private bool firstTime;

	private bool buffersInitialized;

	private BillboardGeometryRenderer geometryRenderer;

	private Heightmap heightmap;

	private RtsCamera rtsCamera;

	public float ParticlesCountNormalized { get; set; } = 1f;

	public BillboardGeometryRenderer GeometryRenderer
	{
		get
		{
			if (geometryRenderer == null)
			{
				geometryRenderer = base.transform.GetComponent<BillboardGeometryRenderer>();
			}
			return geometryRenderer;
		}
	}

	public ComputeBuffer OutputBuffer => outputBuffer;

	public void ResetToStartState()
	{
		firstTime = true;
	}

	public void Dispatch()
	{
		if (!buffersInitialized)
		{
			InitBuffers();
		}
		if (!MonoSingleton<Heightmap>.IsInstantiated() || !MonoSingleton<RtsCamera>.IsInstantiated() || !MonoSingleton<Heightmap>.IsInstantiated() || !MonoSingleton<Heightmap>.Instance.IsReady)
		{
			return;
		}
		if (heightmap == null)
		{
			heightmap = MonoSingleton<Heightmap>.Instance;
		}
		if (MonoSingleton<World>.IsInstantiated() && !(computeShader == null) && heightmap.ComputeBuffer != null)
		{
			if (rtsCamera == null)
			{
				rtsCamera = MonoSingleton<RtsCamera>.Instance;
			}
			if (Vector3.Distance(mapSize, Vector3.zero) <= 0.01f)
			{
				mapSize = new Vector3(MonoSingleton<World>.Instance.SizeX, MonoSingleton<World>.Instance.SizeY * World.MapBlockHeight, MonoSingleton<World>.Instance.SizeZ);
				base.gameObject.transform.position = mapSize * 0.5f;
			}
			ComputeBuffer computeBuffer = (useAlternativeHeightmap ? heightmap.ComputeBuffer : heightmap.NoPassthroughFloorsComputeBuffer);
			if (computeBuffer != null && computeBuffer.IsValid())
			{
				computeShader.SetBuffer(computeShaderKernel, "heightmap", computeBuffer);
				computeShader.SetBuffer(computeShaderKernel, "edgeFrameCoordsPacked", heightmap.EdgeFrameCoordsComputeBuffer);
				computeShader.SetFloat("time", Time.time * 0.01f);
				computeShader.SetInt("edgeFrameSize", 80);
				computeShader.SetBuffer(computeShaderKernel, "randomBuffer", randomBuffer);
				computeShader.SetBuffer(computeShaderKernel, "outputBuffer", outputBuffer);
				computeShader.SetFloat("fallSpeed", fallSpeed);
				computeShader.SetFloat("wobbleAmount", wobbleAmount);
				computeShader.SetFloat("wobbleFrequency", wobbleFrequency);
				computeShader.SetVector("windDirection", windDirection);
				computeShader.SetFloat("testVariable", cubeOffsetForward);
				computeShader.SetFloat("deltaTime", Time.deltaTime);
				int val = Mathf.FloorToInt(Mathf.Clamp01(ParticlesCountNormalized) * (float)particlesCount);
				computeShader.SetInt("maxParticlesCount", val);
				computeShader.SetVector("mapSizeWorldSpace", mapSize);
				computeShader.SetBool("isStartPosition", firstTime);
				computeShader.SetFloat("particlesMinHeight", particlesMinHeight);
				computeShader.SetFloat("particlesMaxHeight", particlesMaxHeight);
				computeShader.SetVector("cameraPos", rtsCamera.transform.position);
				computeShader.SetVector("cameraForward", rtsCamera.transform.localToWorldMatrix * Vector3.forward);
				computeShader.SetVector("bounds", cubeBounds);
				computeShader.SetInt("DEBUG_SNAP_TO_FLOOR", 0);
				computeShader.Dispatch(computeShaderKernel, 32, 32, 1);
				firstTime = false;
			}
		}
	}

	private void Start()
	{
		firstTime = true;
		computeShaderKernel = computeShader.FindKernel("CSMain");
		bool isEnabled;
		FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\ParticleGeometryGenerator.cs");
		if (isEnabled)
		{
			messageBuilder.AppendFormatted(computeShader.name);
			messageBuilder.AppendLiteral(" shader supported: ");
			messageBuilder.AppendFormatted(computeShader.IsSupported(computeShaderKernel));
		}
		Log.Warning(messageBuilder);
	}

	private void CreateRandomBuffer(ref ComputeBuffer buffer, int length)
	{
		buffer = new ComputeBuffer(length, 12);
		Vector3[] array = new Vector3[particlesCount];
		for (int i = 0; i < particlesCount; i++)
		{
			array[i] = new Vector3(Random.value, Random.value, Random.value);
		}
		buffer.SetData(array);
	}

	private void InitBuffers()
	{
		buffersInitialized = true;
		firstTime = true;
		CreateRandomBuffer(ref randomBuffer, particlesCount);
		int stride = 16;
		outputBuffer = new ComputeBuffer(particlesCount, stride);
	}

	private void ReleaseBuffers()
	{
		randomBuffer?.Release();
		outputBuffer?.Release();
		buffersInitialized = false;
	}

	private void OnDisable()
	{
		ReleaseBuffers();
	}
}
