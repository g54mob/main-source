using System;
using System.Collections.Generic;
using DV;
using DV.Utils;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class PlatformAutoCanvasScaler : MonoBehaviour
{
	[Serializable]
	private class PlatformCanvasScale
	{
		public APlatformProvider.Platform platform;

		public Vector2 referenceResolution;
	}

	[SerializeField]
	private List<PlatformCanvasScale> canvasScales;

	private void Start()
	{
		CanvasScaler component = GetComponent<CanvasScaler>();
		APlatformProvider.Platform currentPlatform = SingletonBehaviour<APlatformProvider>.Instance.CurrentPlatform;
		foreach (PlatformCanvasScale canvasScale in canvasScales)
		{
			if (currentPlatform.HasAnyByteFlag(canvasScale.platform))
			{
				component.referenceResolution = canvasScale.referenceResolution;
				break;
			}
		}
	}
}
