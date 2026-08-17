using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class Phaser2Weapon : PhaserWeapon
{
	protected override void Setuppo()
	{
		_soundVolume = 0.9f;
		_soundEffect = SfxType.Synth3;
		_musicBeatInterval = 425f;
		_timeUnit = 106.25f;
		_camSizePerc = 1f;
	}

	protected override float GetTimeUnit()
	{
		return _timeUnit;
	}

	protected override float GetProjectilesAmount()
	{
		//IL_0053: Expected O, but got I
		//IL_00b4: Invalid comparison between F4 and I
		//IL_00c6: Expected O, but got I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected I4, but got Unknown
		//IL_00dd: Expected O, but got I4
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		float num4 = default(float);
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			WeaponData currentWeaponData = _currentWeaponData;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			float num3 = num4 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+20+v53 @ rdx_v5 (System.Int32)*4]");
			bool flag = !(num3 > 0f);
			object obj2 = 1;
			if (!flag)
			{
				obj2 = 4;
			}
			int accumulatedActivations = _accumulatedActivations + obj2;
			_accumulatedActivations = accumulatedActivations;
			float num5 = base.PAmount();
			float num6 = (float)_accumulatedActivations * num3;
			return num6 * 4f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return num4;
	}

	public unsafe override float2 PickRandomEnemyOnScreenRect()
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Ref, but got Unknown
		//IL_015e: Expected O, but got I4
		//IL_0142: Expected O, but got F4
		//IL_018c: Expected O, but got F4
		//IL_0119->IL017e: Incompatible stack heights: 0 vs 1
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		GameManager core = GM.Core;
		float2 float5 = default(float2);
		float x = (float)bounds.m_Center - (float)float5;
		float num = (float)float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v4 (UnityEngine.Bounds)+10]");
		float y = num - 0f;
		float width = (float)float5 * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v4 (UnityEngine.Bounds)+10]");
		float height = 0f * 2f;
		Rectangle rectangle = new Rectangle();
		rectangle._x = x;
		rectangle._y = y;
		rectangle._width = width;
		rectangle._height = height;
		core._stage.GetEnemyBodiesInRect(rectangle, ref *(List<BaseBody>*)(this + 344));
		List<BaseBody> list = bodies;
		if (list._size <= 0)
		{
			object obj = UnityEngine.Random.value;
			object obj2 = UnityEngine.Random.value;
			return float5;
		}
		object obj3 = UnityEngine.Random.RandomRangeInt(0, list._size);
		bool flag = (nint)obj3 >= list._size;
		return float5;
	}

	public Phaser2Weapon()
	{
		_detuneValues = new float[64]
		{
			0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
			0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
			-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
			1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
			5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
			7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
			2f, 14f, 5f, 17f
		};
		_soundVolume = 1f;
		_musicBeatInterval = 425f;
		_timeUnit = 53.125f;
		_camOffsetPerc = 0.125f;
		_camSizePerc = 0.75f;
		((Weapon)this)._002Ector();
	}
}
