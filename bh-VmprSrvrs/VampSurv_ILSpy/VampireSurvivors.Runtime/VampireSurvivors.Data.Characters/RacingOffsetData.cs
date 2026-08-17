using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class RacingOffsetData
{
	private CharacterVehicleType _003CvehicleType_003Ek__BackingField;

	private Vector2? _003CracingOffset_003Ek__BackingField;

	private float? _003CracingAngle_003Ek__BackingField;

	public CharacterVehicleType vehicleType
	{
		get
		{
			return _003CvehicleType_003Ek__BackingField;
		}
		set
		{
			_003CvehicleType_003Ek__BackingField = value;
		}
	}

	public Vector2? racingOffset
	{
		get
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+14]");
			RacingOffsetData racingOffsetData = (RacingOffsetData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+1C]");
			_ = 0;
			return (Vector2?)this;
		}
		set
		{
			_003CracingOffset_003Ek__BackingField = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Nullable`1<UnityEngine.Vector2>)+8]");
			_ = 0;
		}
	}

	public float? racingAngle
	{
		get
		{
			return _003CracingAngle_003Ek__BackingField;
		}
		set
		{
			_003CracingAngle_003Ek__BackingField = value;
		}
	}

	public RacingOffsetData()
	{
		//IL_0010: Expected O, but got I4
		_003CracingAngle_003Ek__BackingField = (float?)(object)1;
	}
}
