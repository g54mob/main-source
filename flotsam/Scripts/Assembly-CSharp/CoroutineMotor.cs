using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;

public class CoroutineMotor : MonoBehaviour
{
	private static CoroutineMotor _instance;

	private List<PLCoroutine> _coroutinesToValidate = new List<PLCoroutine>();

	public static CoroutineMotor Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject().AddComponent<CoroutineMotor>();
				_instance.name = "Coroutine Motor";
			}
			return _instance;
		}
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	public static Coroutine StartRoutine(IEnumerator coroutine)
	{
		return Instance.StartCoroutine(coroutine);
	}

	public static void StopRoutine(Coroutine coroutine)
	{
		Instance.StopCoroutine(coroutine);
	}
}
