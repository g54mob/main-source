using System;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos.A
{
	[Serializable]
	public class RandomColor : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		}
	}
}
