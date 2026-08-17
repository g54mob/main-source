using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MilkShake;

[Serializable]
public class ShakeParameters : IShakeParameters
{
	private ShakeType shakeType;

	private float strength;

	private float roughness;

	private float fadeIn;

	private float fadeOut;

	private Vector3 positionInfluence;

	private Vector3 rotationInfluence;

	public ShakeType ShakeType
	{
		get
		{
			return shakeType;
		}
		set
		{
			shakeType = value;
		}
	}

	public float Strength
	{
		get
		{
			return strength;
		}
		set
		{
			strength = value;
		}
	}

	public float Roughness
	{
		get
		{
			return roughness;
		}
		set
		{
			roughness = value;
		}
	}

	public float FadeIn
	{
		get
		{
			return fadeIn;
		}
		set
		{
			fadeIn = value;
		}
	}

	public float FadeOut
	{
		get
		{
			return fadeOut;
		}
		set
		{
			fadeOut = value;
		}
	}

	public unsafe Vector3 PositionInfluence
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)positionInfluence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MilkShake.ShakeParameters)+2C]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			positionInfluence = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 RotationInfluence
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)rotationInfluence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MilkShake.ShakeParameters)+38]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			rotationInfluence = (Vector3)value.x;
			_ = value.z;
		}
	}

	public ShakeParameters()
	{
	}

	public ShakeParameters(IShakeParameters original)
	{
		//IL_0094: Expected O, but got F4
		//IL_00bf: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		ShakeType shakeType = default(ShakeType);
		this.shakeType = shakeType;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		float num = default(float);
		strength = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		roughness = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		fadeIn = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		fadeOut = num;
		Vector3 vector = original.PositionInfluence;
		positionInfluence = (Vector3)vector.x;
		_ = vector.z;
		Vector3 vector2 = original.RotationInfluence;
		rotationInfluence = (Vector3)vector2.x;
		_ = vector2.z;
	}
}
