using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Tools;

public class AudioSourcePreview : MonoBehaviour
{
	private AudioSource _audioSource;

	public bool IsPlaying
	{
		get
		{
			//IL_007d: Expected I4, but got O
			AudioSource audioSource = _audioSource;
			if ((object)_audioSource != null && ((UnityEngine.Object)audioSource).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_audioSource != null)
				{
					return _audioSource.isPlaying;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
	}

	public float CurrentTime
	{
		get
		{
			//IL_0050: Expected F4, but got I4
			AudioSource audioSource = _audioSource;
			if ((object)_audioSource == null || ((UnityEngine.Object)audioSource).m_CachedPtr == (IntPtr)0)
			{
				return 0f;
			}
			return _audioSource.time;
		}
	}

	private void Awake()
	{
		AudioSource component = GetComponent<AudioSource>();
		_audioSource = component;
	}

	public AudioSourcePreview()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
