using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class TP_Astarte_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CLevelUp_003Eb__2_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1503;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public TP_Astarte_Character _003C_003E4__this;

		public Equipment statue;

		internal unsafe void _003CLevelUp_003Eb__1()
		{
			Equipment equipment = statue;
			if (equipment._003CLevel_003Ek__BackingField < 8)
			{
				bool flag = equipment.LevelUp();
				Action onComplete = delegate
				{
					//IL_002d: Expected O, but got Ref
					GameManager core = GM.Core;
					object obj = default(object);
					CharacterController character = default(CharacterController);
					float displayTimeMultiplier = default(float);
					Vector2 vOffset = default(Vector2);
					core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.TP_STARFLAIL1, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				Timer timer = TimerHelper.RegisterMillisUI(60f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
			}
		}
	}

	private int followerNameindex = 1;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		EnableDestroyDestructiblesOnTouch();
		PlayerModifierStats playerStats = _playerStats;
		float num = playerStats._003CDefang_003Ek__BackingField + 0.15f;
		playerStats._003CDefang_003Ek__BackingField = num;
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_STARFLAIL1, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			WeaponData currentWeaponData = weaponByType._currentWeaponData;
			weaponByType.IsAdept = true;
			float num2 = currentWeaponData._003Cinterval_003Ek__BackingField * 0.5f;
			currentWeaponData._003Cinterval_003Ek__BackingField = num2;
		}
	}

	public unsafe override void LevelUp()
	{
		//IL_0034: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		base.LevelUp();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj = ((CharacterController)this)._level >> 2;
		object obj2 = obj >> 31;
		object obj3 = obj + obj2;
		object obj4 = obj3 * 7;
		if (((CharacterController)this)._level != (nint)obj4)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__2_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 1503;
				return obj5 == null;
			});
		}
		Equipment statue = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.Find(match);
		CS_0024_003C_003E8__locals6.statue = statue;
		Equipment statue2 = CS_0024_003C_003E8__locals6.statue;
		if ((object)CS_0024_003C_003E8__locals6.statue == null || ((UnityEngine.Object)statue2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Equipment statue3 = CS_0024_003C_003E8__locals6.statue;
		if (statue3._003CLevel_003Ek__BackingField >= 8)
		{
			return;
		}
		Action onComplete = delegate
		{
			Equipment statue4 = CS_0024_003C_003E8__locals6.statue;
			if (statue4._003CLevel_003Ek__BackingField < 8)
			{
				bool flag = statue4.LevelUp();
				Action onComplete2 = delegate
				{
					//IL_002d: Expected O, but got Ref
					GameManager core = GM.Core;
					object obj5 = default(object);
					CharacterController character = default(CharacterController);
					float displayTimeMultiplier = default(float);
					Vector2 vOffset = default(Vector2);
					core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.TP_STARFLAIL1, "1", (Color?)(object)(&obj5), character, displayTimeMultiplier, vOffset);
				};
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				Timer timer2 = TimerHelper.RegisterMillisUI(60f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2);
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public unsafe void ShowIcons()
	{
		Action onComplete = delegate
		{
			//IL_002d: Expected O, but got Ref
			GameManager core = GM.Core;
			object obj = default(object);
			CharacterController character = default(CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.TP_STARFLAIL1, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(60f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
	}

	private unsafe void SpawnNewEnemyFollower()
	{
		//IL_01ce: Expected I, but got O
		//IL_009f: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected I4, but got Unknown
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		if (core._latestKilledEnemyThatCanBeFollowerData == null)
		{
			return;
		}
		float num3 = (float)((CharacterController)this)._level / 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj = default(object);
		object obj2;
		if ((nint)obj >= 1)
		{
			bool flag = (nint)obj <= 10;
			obj2 = obj;
			if (!flag)
			{
				obj2 = 10;
			}
		}
		else
		{
			obj2 = 1;
		}
		int numAliveEnemyFollowers = GM.Core.GetNumAliveEnemyFollowers(this);
		if (numAliveEnemyFollowers < (nint)obj2)
		{
			FollowerEnemy_CharacterController followerEnemy_CharacterController = GM.Core.AddLastEnemyFollower(this);
			if ((object)followerEnemy_CharacterController != null && ((UnityEngine.Object)followerEnemy_CharacterController).m_CachedPtr != (IntPtr)0 && !followerEnemy_CharacterController.HasSetName)
			{
				CharacterData currentCharacterData = ((CharacterController)followerEnemy_CharacterController)._currentCharacterData;
				int num4 = this + 1040;
				string text = ((int*)num4)->ToString();
				string charName = currentCharacterData._003CcharName_003Ek__BackingField + " " + text;
				currentCharacterData.charName = charName;
				followerEnemy_CharacterController.HasSetName = true;
				int num5 = followerNameindex + 1;
				followerNameindex = num5;
			}
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		Action action = SpawnNewEnemyFollower;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1E60");
	}

	public override void Despawn()
	{
		Action action = SpawnNewEnemyFollower;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2100");
	}

	private unsafe void _003CShowIcons_003Eb__3_0()
	{
		//IL_002d: Expected O, but got Ref
		GameManager core = GM.Core;
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		core._gizmoManager.DisplayWeaponIconOverhead(WeaponType.TP_STARFLAIL1, "1", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
	}
}
