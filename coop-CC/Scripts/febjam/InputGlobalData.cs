using System;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class InputGlobalData : GlobalScriptableObject<InputGlobalData>
{
	[Serializable]
	public class VibrateStrengthValue
	{
		[Range(0f, 1f)]
		public float lowFrequency = 0.5f;

		[Range(0f, 1f)]
		public float highFrequency = 0.5f;

		[Min(0f)]
		public float duration = 0.2f;
	}

	[Serializable]
	public class VibrateStrengthFrameValue
	{
		[Range(0f, 1f)]
		public float lowFrequency = 0.5f;

		[Range(0f, 1f)]
		public float highFrequency = 0.5f;
	}

	public VibrateStrengthValue[] vibrateStrengthValues;

	public VibrateStrengthFrameValue[] vibrateStrengthFrameValues;

	public void GetVibrateValues(VibrateStrength strength, out float lowFrequency, out float highFrequency, out float duration)
	{
		if (strength == VibrateStrength.None)
		{
			lowFrequency = 0f;
			highFrequency = 0f;
			duration = 0f;
		}
		else
		{
			VibrateStrengthValue vibrateStrengthValue = vibrateStrengthValues[math.clamp((int)strength, 0, vibrateStrengthValues.Length - 1)];
			lowFrequency = vibrateStrengthValue.lowFrequency;
			highFrequency = vibrateStrengthValue.highFrequency;
			duration = vibrateStrengthValue.duration;
		}
	}

	public void GetVibrateFrameValues(VibrateStrength strength, out float lowFrequency, out float highFrequency)
	{
		if (strength == VibrateStrength.None)
		{
			lowFrequency = 0f;
			highFrequency = 0f;
		}
		else
		{
			VibrateStrengthFrameValue vibrateStrengthFrameValue = vibrateStrengthFrameValues[math.clamp((int)strength, 0, vibrateStrengthFrameValues.Length - 1)];
			lowFrequency = vibrateStrengthFrameValue.lowFrequency;
			highFrequency = vibrateStrengthFrameValue.highFrequency;
		}
	}
}
