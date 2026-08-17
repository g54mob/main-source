using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_EX_Ziappunta : CharacterController
{
	protected float _spawnPROPS_Delay = 1000f;

	protected float _spawnPROPS_Time;

	protected Timer _PROPSactivationTimer;

	protected List<PropType> _PROPSTypes;

	protected bool _spawnExtraProps;

	public int SpecialChestsSpawned;

	public override void AfterFullInitialization()
	{
		//IL_0046: Expected O, but got I
		//IL_00a0: Expected O, but got I
		base.AfterFullInitialization();
		List<PropType> pROPSTypes = new List<PropType>();
		_PROPSTypes = pROPSTypes;
		List<System.Int32Enum> pROPSTypes2 = (List<System.Int32Enum>)(object)_PROPSTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v4+18]");
		if (num >= 0)
		{
			pROPSTypes2.AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 20;
		}
		_spawnPROPS_Time = _spawnPROPS_Delay;
		_spawnExtraProps = true;
		EnableDestroyDestructiblesOnTouch();
	}

	protected float PROPSSpawnInterval()
	{
		return _spawnPROPS_Delay;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!_spawnExtraProps)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (!((_spawnPROPS_Time = num + _spawnPROPS_Time) < _spawnPROPS_Delay))
		{
			_spawnPROPS_Time = 0f;
			if (_PROPSactivationTimer != null)
			{
				_PROPSactivationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				SpawnProps();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer pROPSactivationTimer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_PROPSactivationTimer = pROPSactivationTimer;
		}
	}

	protected void SpawnProps()
	{
		//IL_020f: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+10]");
						object obj5 = 0;
						object obj6 = obj4 + 1;
						GameManager core = GM.Core;
						Stage stage = core._stage;
						TilingTileset tilingTileset = stage._tilingTileset;
						if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
						{
							GameManager core2 = GM.Core;
							Stage stage2 = core2._stage;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v10+20+v212 @ stack_-30_v2*4]");
							stage2.SpawnChosenDestructibleWallsCheck(PropType.CANDLE);
							obj4 = obj6;
						}
						else
						{
							GameManager core3 = GM.Core;
							Stage stage3 = core3._stage;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v10+20+v212 @ stack_-30_v2*4]");
							stage3.SpawnChocenDestructibleOutOfSight(PropType.CANDLE, force: true, 2f);
							obj4 = obj6;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		CharacterController_EX_Ziappunta characterController_EX_Ziappunta = (CharacterController_EX_Ziappunta)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-38_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			characterController_EX_Ziappunta = null;
		}
		throw new NullReferenceException();
	}

	public bool CheckAchievementStats()
	{
		//IL_0010: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		object obj = SpecialChestsSpawned - 10;
		int num = SpecialChestsSpawned ^ 0xA;
		int num2 = SpecialChestsSpawned ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 == flag;
	}

	public CharacterController_EX_Ziappunta()
	{
		List<PropType> pROPSTypes = new List<PropType>();
		_PROPSTypes = pROPSTypes;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__8_0()
	{
		SpawnProps();
	}
}
