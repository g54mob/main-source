using System.Collections.Generic;
using UnityEngine;

public class LightShadowQualitySetter : MonoBehaviour
{
	private Dictionary<Light, LightShadows> originalLightShadows;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnQualityChange(int previousIdx, int newIdx)
	{
	}

	private void ToggleAdditionalLightShadows(bool on)
	{
	}
}
