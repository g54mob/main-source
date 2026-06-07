using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class OVRLipSync : MonoBehaviour
{
	public enum Result
	{
		Success = 0,
		Unknown = -2200,
		CannotCreateContext = -2201,
		InvalidParam = -2202,
		BadSampleRate = -2203,
		MissingDLL = -2204,
		BadVersion = -2205,
		UndefinedFunction = -2206
	}

	public enum AudioDataType
	{
		S16_Mono = 0,
		S16_Stereo = 1,
		F32_Mono = 2,
		F32_Stereo = 3
	}

	public enum Viseme
	{
		sil = 0,
		PP = 1,
		FF = 2,
		TH = 3,
		DD = 4,
		kk = 5,
		CH = 6,
		SS = 7,
		nn = 8,
		RR = 9,
		aa = 10,
		E = 11,
		ih = 12,
		oh = 13,
		ou = 14
	}

	public enum Signals
	{
		VisemeOn = 0,
		VisemeOff = 1,
		VisemeAmount = 2,
		VisemeSmoothing = 3,
		LaughterAmount = 4
	}

	public enum ContextProviders
	{
		Original = 0,
		Enhanced = 1,
		Enhanced_with_Laughter = 2
	}

	[Serializable]
	public class Frame
	{
		public int frameNumber;

		public int frameDelay;

		public float[] Visemes = new float[VisemeCount];

		public float laughterScore;

		public void CopyInput(Frame input)
		{
			frameNumber = input.frameNumber;
			frameDelay = input.frameDelay;
			input.Visemes.CopyTo(Visemes, 0);
			laughterScore = input.laughterScore;
		}

		public void Reset()
		{
			frameNumber = 0;
			frameDelay = 0;
			Array.Clear(Visemes, 0, VisemeCount);
			laughterScore = 0f;
		}
	}

	public static readonly int VisemeCount = Enum.GetNames(typeof(Viseme)).Length;

	public static readonly int SignalCount = Enum.GetNames(typeof(Signals)).Length;

	public const string strOVRLS = "OVRLipSync";

	private static Result sInitialized = Result.Unknown;

	public static OVRLipSync sInstance = null;

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_Initialize(int samplerate, int buffersize);

	[DllImport("OVRLipSync")]
	private static extern void ovrLipSyncDll_Shutdown();

	[DllImport("OVRLipSync")]
	private static extern IntPtr ovrLipSyncDll_GetVersion(ref int Major, ref int Minor, ref int Patch);

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_CreateContextEx(ref uint context, ContextProviders provider, int sampleRate, bool enableAcceleration);

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_CreateContextWithModelFile(ref uint context, ContextProviders provider, string modelPath, int sampleRate, bool enableAcceleration);

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_DestroyContext(uint context);

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_ResetContext(uint context);

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_SendSignal(uint context, Signals signal, int arg1, int arg2);

	[DllImport("OVRLipSync")]
	private static extern int ovrLipSyncDll_ProcessFrameEx(uint context, IntPtr audioBuffer, uint bufferSize, AudioDataType dataType, ref int frameNumber, ref int frameDelay, float[] visemes, int visemeCount, ref float laughterScore, float[] laughterCategories, int laughterCategoriesLength);

	private void Awake()
	{
		if (sInstance == null)
		{
			sInstance = this;
			if (IsInitialized() != Result.Success)
			{
				sInitialized = Initialize();
				if (sInitialized != Result.Success)
				{
					Debug.LogWarning($"OvrLipSync Awake: Failed to init Speech Rec library");
				}
			}
			OVRTouchpad.Create();
		}
		else
		{
			Debug.LogWarning($"OVRLipSync Awake: Only one instance of OVRPLipSync can exist in the scene.");
		}
	}

	private void OnDestroy()
	{
		if (sInstance != this)
		{
			Debug.LogWarning("OVRLipSync OnDestroy: This is not the correct OVRLipSync instance.");
		}
	}

	public static Result Initialize()
	{
		int outputSampleRate = AudioSettings.outputSampleRate;
		AudioSettings.GetDSPBufferSize(out var bufferLength, out var _);
		Debug.LogWarning($"OvrLipSync Awake: Queried SampleRate: {outputSampleRate:F0} BufferSize: {bufferLength:F0}");
		sInitialized = (Result)ovrLipSyncDll_Initialize(outputSampleRate, bufferLength);
		return sInitialized;
	}

	public static Result Initialize(int sampleRate, int bufferSize)
	{
		Debug.LogWarning($"OvrLipSync Awake: Queried SampleRate: {sampleRate:F0} BufferSize: {bufferSize:F0}");
		sInitialized = (Result)ovrLipSyncDll_Initialize(sampleRate, bufferSize);
		return sInitialized;
	}

	public static void Shutdown()
	{
		ovrLipSyncDll_Shutdown();
		sInitialized = Result.Unknown;
	}

	public static Result IsInitialized()
	{
		return sInitialized;
	}

	public static Result CreateContext(ref uint context, ContextProviders provider, int sampleRate = 0, bool enableAcceleration = false)
	{
		if (IsInitialized() != Result.Success && Initialize() != Result.Success)
		{
			return Result.CannotCreateContext;
		}
		return (Result)ovrLipSyncDll_CreateContextEx(ref context, provider, sampleRate, enableAcceleration);
	}

	public static Result CreateContextWithModelFile(ref uint context, ContextProviders provider, string modelPath, int sampleRate = 0, bool enableAcceleration = false)
	{
		if (IsInitialized() != Result.Success && Initialize() != Result.Success)
		{
			return Result.CannotCreateContext;
		}
		return (Result)ovrLipSyncDll_CreateContextWithModelFile(ref context, provider, modelPath, sampleRate, enableAcceleration);
	}

	public static Result DestroyContext(uint context)
	{
		if (IsInitialized() != Result.Success)
		{
			return Result.Unknown;
		}
		return (Result)ovrLipSyncDll_DestroyContext(context);
	}

	public static Result ResetContext(uint context)
	{
		if (IsInitialized() != Result.Success)
		{
			return Result.Unknown;
		}
		return (Result)ovrLipSyncDll_ResetContext(context);
	}

	public static Result SendSignal(uint context, Signals signal, int arg1, int arg2)
	{
		if (IsInitialized() != Result.Success)
		{
			return Result.Unknown;
		}
		return (Result)ovrLipSyncDll_SendSignal(context, signal, arg1, arg2);
	}

	public static Result ProcessFrame(uint context, float[] audioBuffer, Frame frame, bool stereo = true)
	{
		if (IsInitialized() != Result.Success)
		{
			return Result.Unknown;
		}
		AudioDataType dataType = (stereo ? AudioDataType.F32_Stereo : AudioDataType.F32_Mono);
		uint bufferSize = (uint)(stereo ? (audioBuffer.Length / 2) : audioBuffer.Length);
		GCHandle gCHandle = GCHandle.Alloc(audioBuffer, GCHandleType.Pinned);
		int result = ovrLipSyncDll_ProcessFrameEx(context, gCHandle.AddrOfPinnedObject(), bufferSize, dataType, ref frame.frameNumber, ref frame.frameDelay, frame.Visemes, frame.Visemes.Length, ref frame.laughterScore, null, 0);
		gCHandle.Free();
		return (Result)result;
	}

	public static Result ProcessFrame(uint context, short[] audioBuffer, Frame frame, bool stereo = true)
	{
		if (IsInitialized() != Result.Success)
		{
			return Result.Unknown;
		}
		AudioDataType dataType = (stereo ? AudioDataType.S16_Stereo : AudioDataType.S16_Mono);
		uint bufferSize = (uint)(stereo ? (audioBuffer.Length / 2) : audioBuffer.Length);
		GCHandle gCHandle = GCHandle.Alloc(audioBuffer, GCHandleType.Pinned);
		int result = ovrLipSyncDll_ProcessFrameEx(context, gCHandle.AddrOfPinnedObject(), bufferSize, dataType, ref frame.frameNumber, ref frame.frameDelay, frame.Visemes, frame.Visemes.Length, ref frame.laughterScore, null, 0);
		gCHandle.Free();
		return (Result)result;
	}
}
