using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public class ShakePreset : ScriptableObject
{
	public Vector3 Strength;

	public float Duration = 0.5f;

	public int Vibrato;

	public float Randomness;

	public float Smoothness;

	public bool UseRandomInitialAngle;

	public float InitialAngle;

	public Vector3 Rotation;

	public bool IgnoreTimeScale;

	public ShakePreset()
	{
		Vector3 strength = default(Vector3);
		Strength = strength;
		_ = 0;
		Vibrato = 10;
		Randomness = 0.1f;
		Smoothness = 0.1f;
		UseRandomInitialAngle = true;
		base._002Ector();
	}
}
