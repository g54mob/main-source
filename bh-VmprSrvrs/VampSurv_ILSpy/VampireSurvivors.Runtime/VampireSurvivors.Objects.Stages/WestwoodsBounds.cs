using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Objects.Stages;

public class WestwoodsBounds : MonoBehaviour
{
	public enum WestwoodsZone
	{
		One,
		Two,
		Three
	}

	private float _staticBoundsLimit;

	private float[] _boundsXLimits;

	private float _inverseStaticBoundsLimit;

	private float[] _inverseBoundsXLimits;

	private bool _isStageInverse;

	public float StaticBoundsLimit
	{
		get
		{
			if (_isStageInverse)
			{
				return _inverseStaticBoundsLimit;
			}
			return _staticBoundsLimit;
		}
	}

	public float[] BoundsXLimits
	{
		get
		{
			if (_isStageInverse)
			{
				return _inverseBoundsXLimits;
			}
			return _boundsXLimits;
		}
	}

	public void Initialise(bool isStageInverse)
	{
		_isStageInverse = isStageInverse;
	}

	public void EnableBoundsForZone(WestwoodsZone zone)
	{
		if (_isStageInverse)
		{
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			WestwoodsBounds westwoodsBounds = null;
			WestwoodsBounds westwoodsBounds2 = null;
			throw new NullReferenceException();
		}
	}

	public bool IsPositionInsidePlayableSpace(float2 position, WestwoodsZone currentUnlockedZone)
	{
		//IL_018c: Expected I4, but got O
		//IL_010c: Invalid comparison between O and F4
		//IL_0130: Invalid comparison between F4 and O
		//IL_0150: Invalid comparison between F4 and I4
		//IL_008e: Invalid comparison between F4 and O
		//IL_00af: Invalid comparison between O and F4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		float[] array = ((!_isStageInverse) ? _boundsXLimits : _inverseBoundsXLimits);
		if ((int)currentUnlockedZone < array.Length)
		{
			if (_isStageInverse)
			{
				float num = array[(int)currentUnlockedZone];
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
				{
					bool flag = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_inverseStaticBoundsLimit);
					object obj = position - _inverseStaticBoundsLimit;
					bool flag2 = obj == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
			else if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)array[(int)currentUnlockedZone]))
			{
				float staticBoundsLimit = _staticBoundsLimit;
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)staticBoundsLimit) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
				float num2 = _staticBoundsLimit - (float)position;
				bool flag6 = num2 == 0f;
				bool flag7 = !flag5;
				bool flag8 = !flag6;
				return flag8 & flag7;
			}
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public WestwoodsBounds()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
