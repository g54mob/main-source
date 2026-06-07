using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

public static class AkAudioInputManager
{
	public delegate void AudioFormatDelegate(uint playingID, AkAudioFormat format);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void AudioFormatInteropDelegate(uint playingID, IntPtr format);

	public delegate bool AudioSamplesDelegate(uint playingID, uint channelIndex, float[] samples);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate bool AudioSamplesInteropDelegate(uint playingID, [In][Out] float[] samples, uint channelIndex, uint frames);

	private static bool initialized;

	private static readonly Dictionary<uint, AudioSamplesDelegate> audioSamplesDelegates;

	private static readonly Dictionary<uint, AudioFormatDelegate> audioFormatDelegates;

	private static readonly AkAudioFormat audioFormat;

	private static readonly AudioSamplesInteropDelegate audioSamplesDelegate;

	private static readonly AudioFormatInteropDelegate audioFormatDelegate;

	public static uint PostAudioInputEvent(uint akEventID, GameObject gameObject, AudioSamplesDelegate sampleDelegate, AudioFormatDelegate formatDelegate = null)
	{
		return 0u;
	}

	public static uint PostAudioInputEvent(string akEventName, GameObject gameObject, AudioSamplesDelegate sampleDelegate, AudioFormatDelegate formatDelegate = null)
	{
		return 0u;
	}

	[MonoPInvokeCallback(typeof(AudioSamplesInteropDelegate))]
	private static bool InternalAudioSamplesDelegate(uint playingID, float[] samples, uint channelIndex, uint frames)
	{
		return false;
	}

	[MonoPInvokeCallback(typeof(AudioFormatInteropDelegate))]
	private static void InternalAudioFormatDelegate(uint playingID, IntPtr format)
	{
	}

	private static void TryInitialize()
	{
	}

	private static void AddPlayingID(uint playingID, AudioSamplesDelegate sampleDelegate, AudioFormatDelegate formatDelegate)
	{
	}

	private static void EventCallback(object cookie, AkCallbackType type, AkCallbackInfo callbackInfo)
	{
	}
}
