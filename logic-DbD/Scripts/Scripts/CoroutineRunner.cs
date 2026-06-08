using System;
using System.Collections;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
	public void StartCoroutine(Func<IEnumerator> coroutine)
	{
		StartCoroutine(coroutine());
	}
}
