using Cpp2ILInjected;
using UnityEngine;

namespace MilkShake;

public class ShakePreset : ScriptableObject, IShakeParameters
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MilkShake.ShakePreset)+34]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (MilkShake.ShakePreset)+40]");
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
}
