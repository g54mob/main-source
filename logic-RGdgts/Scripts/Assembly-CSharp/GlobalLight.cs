using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
	private Light2D globalLight;

	[NonSerialized]
	[HideInInspector]
	public float defaultIntensity;

	private static GlobalLight _instance;

	public static GlobalLight Instance => null;

	public float intensity
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}
}
