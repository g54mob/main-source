using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerSiugnas : EME_CharacterControllerShowstopper
{
	private int m_StatsApplied;

	private float[] m_HealthIncreases = new float[4] { 1f, 0.5f, 0.05f, 0.005f };

	private int followerNameindex = 1;

	public override bool DrainWeaponsImmunity => true;

	private unsafe void SpawnNewEnemyFollower()
	{
		//IL_003a: Invalid comparison between O and F4
		//IL_008e: Invalid comparison between O and F4
		//IL_00e2: Invalid comparison between O and F4
		//IL_00f4: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_005a: Invalid comparison between F4 and O
		//IL_00ae: Invalid comparison between F4 and O
		//IL_0114: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected I4, but got Unknown
		//IL_026c: Expected O, but got I4
		GameManager core = GM.Core;
		if (core._latestKilledEnemyThatCanBeFollowerData == null)
		{
			return;
		}
		float num = base.MaxHp();
		object obj = default(object);
		object obj2;
		object obj3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)140f))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)200f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				obj2 = 2;
				obj3 = 1;
				goto IL_0122;
			}
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)200f))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)300f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				obj2 = 3;
				obj3 = 2;
				goto IL_0122;
			}
		}
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)300f);
		obj2 = 1;
		obj3 = 0;
		if (!flag)
		{
			obj2 = 4;
			obj3 = 3;
		}
		goto IL_0122;
		IL_0122:
		int numAliveEnemyFollowers = GM.Core.GetNumAliveEnemyFollowers(this);
		if (numAliveEnemyFollowers >= (nint)obj2)
		{
			return;
		}
		FollowerEnemy_CharacterController followerEnemy_CharacterController = GM.Core.AddLastEnemyFollower(this);
		if ((object)followerEnemy_CharacterController != null && ((UnityEngine.Object)followerEnemy_CharacterController).m_CachedPtr != (IntPtr)0)
		{
			if (!followerEnemy_CharacterController.HasSetName)
			{
				CharacterData currentCharacterData = ((CharacterController)followerEnemy_CharacterController)._currentCharacterData;
				int num2 = this + 1112;
				string text = ((int*)num2)->ToString();
				string charName = currentCharacterData._003CcharName_003Ek__BackingField + " " + text;
				currentCharacterData.charName = charName;
				followerEnemy_CharacterController.HasSetName = true;
				int num3 = followerNameindex + 1;
				followerNameindex = num3;
			}
			float[] healthIncreases = m_HealthIncreases;
			if ((nint)obj3 >= healthIncreases.Length)
			{
				obj3 = healthIncreases.Length - 1;
			}
			PlayerModifierStats playerStats = _playerStats;
			EggFloat maxHp = playerStats._003CMaxHp_003Ek__BackingField + healthIncreases[obj3];
			playerStats.MaxHp = maxHp;
			int statsApplied = m_StatsApplied + 1;
			m_StatsApplied = statsApplied;
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		((CharacterController)this).MakeLevelOne(false);
		base._mightBonus = 0f;
		base._luckBonus = 0f;
		base._isMorphed = false;
		Action action = SpawnNewEnemyFollower;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1E60");
	}

	public override void Despawn()
	{
		Action action = SpawnNewEnemyFollower;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2100");
	}

	public EME_CharacterControllerSiugnas()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
