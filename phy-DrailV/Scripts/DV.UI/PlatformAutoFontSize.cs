using System;
using System.Collections.Generic;
using DV;
using DV.Utils;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PlatformAutoFontSize : MonoBehaviour
{
	[Serializable]
	private class PlatformFontSize
	{
		public APlatformProvider.Platform platform;

		public float fontSize;
	}

	[SerializeField]
	private List<PlatformFontSize> fontSizes;

	private void Start()
	{
		TMP_Text component = GetComponent<TMP_Text>();
		APlatformProvider.Platform currentPlatform = SingletonBehaviour<APlatformProvider>.Instance.CurrentPlatform;
		foreach (PlatformFontSize fontSize in fontSizes)
		{
			if (currentPlatform.HasAnyByteFlag(fontSize.platform))
			{
				component.fontSize = fontSize.fontSize;
				component.fontSizeMax = fontSize.fontSize;
				break;
			}
		}
	}
}
