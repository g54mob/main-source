using System;
using System.Collections;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Tools;

public class CoroutineRunner : MonoBehaviour
{
	public static CoroutineRunner Instance;

	private void Awake()
	{
		Instance = this;
	}

	private Coroutine Begin(IEnumerator c)
	{
		return StartCoroutine(c);
	}

	public static Coroutine Run(IEnumerator c)
	{
		if ((object)Instance != null)
		{
			return Instance.StartCoroutine(c);
		}
		return (Coroutine)(object)new NullReferenceException();
	}

	public CoroutineRunner()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
