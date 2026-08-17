using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Inferno1_Weapon : LEM_BaseWeapon
{
	private int _003CFireCounter_003Ek__BackingField;

	private int _003CKillsWhileCurrentProjectileActive_003Ek__BackingField;

	private int _003CHighestKillScoreThisRun_003Ek__BackingField;

	private int _runEnemiesKilledWhenWeaponFired;

	private bool _InfiniteDuration;

	public int FireCounter
	{
		get
		{
			return _003CFireCounter_003Ek__BackingField;
		}
		private set
		{
			_003CFireCounter_003Ek__BackingField = value;
		}
	}

	public int KillsWhileCurrentProjectileActive
	{
		get
		{
			return _003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
		}
		private set
		{
			_003CKillsWhileCurrentProjectileActive_003Ek__BackingField = value;
		}
	}

	public int HighestKillScoreThisRun
	{
		get
		{
			return _003CHighestKillScoreThisRun_003Ek__BackingField;
		}
		private set
		{
			_003CHighestKillScoreThisRun_003Ek__BackingField = value;
		}
	}

	public float YPosOffset => 0.16f;

	public float MaxProjectileScale => 5f;

	public bool InfiniteDuration => _InfiniteDuration;

	public override float PPower()
	{
		//IL_0087: Expected F4, but got I4
		//IL_0064: Expected F4, but got I4
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			int num;
			if (0 <= _003CKillsWhileCurrentProjectileActive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm6,xmm1\"");
				num = 0;
				float num2 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				num = _003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
				float num2 = _003CKillsWhileCurrentProjectileActive_003Ek__BackingField;
			}
			float num3 = (float)num * 0.05f;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num3 + currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num2;
					return num2 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(2.5f > num2);
		float result = 2.5f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		ResetKillTracking();
		_003CHighestKillScoreThisRun_003Ek__BackingField = 0;
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		((Weapon)this)._003CTotalTime_003Ek__BackingField = num2;
		AddOuterSaboteur();
	}

	protected virtual void ResetKillTracking()
	{
		_003CKillsWhileCurrentProjectileActive_003Ek__BackingField = 0;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_runEnemiesKilledWhenWeaponFired = config._003CRunEnemies_003Ek__BackingField;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		UpdateKillCount();
		float deltaTime = PauseSystem.DeltaTime;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		if (spawnedProjectiles._size <= 0)
		{
			float num3 = base.PInterval();
			if (!(num2 < deltaTime))
			{
				((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
	}

	protected virtual void UpdateKillCount()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num = (_003CKillsWhileCurrentProjectileActive_003Ek__BackingField = config._003CRunEnemies_003Ek__BackingField - _runEnemiesKilledWhenWeaponFired);
		if (num > _003CHighestKillScoreThisRun_003Ek__BackingField)
		{
			_003CHighestKillScoreThisRun_003Ek__BackingField = num;
		}
	}

	private void UpdateFiringInterval()
	{
		float deltaTime = PauseSystem.DeltaTime;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		float num = deltaTime * 1000f;
		float num2 = (((Weapon)this)._003CTotalTime_003Ek__BackingField = num + ((Weapon)this)._003CTotalTime_003Ek__BackingField);
		if (spawnedProjectiles._size <= 0)
		{
			float num3 = base.PInterval();
			if (!(num2 < deltaTime))
			{
				((Weapon)this)._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009f: Invalid comparison between O and F4
		//IL_00ca: Expected F4, but got O
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		if (spawnedProjectiles._size <= 0)
		{
			int num = _003CFireCounter_003Ek__BackingField + 1;
			_003CFireCounter_003Ek__BackingField = num;
			ResetKillTracking();
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 vector = default(Vector2);
			FireInfernoProjectiles(vector);
			float num2 = base.PInterval();
			float num3 = _lastFiringInterval - (float)vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num3 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
			{
				float num4 = base.PInterval();
				_lastFiringInterval = (float)vector;
				ResetFiringTimer();
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
		}
	}

	protected virtual void FireInfernoProjectiles(Vector2 pos)
	{
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			DespawnActiveProjectiles();
		}
	}

	public void PlayBlueTextSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_chips1, soundConfig, 100f, 1, time);
	}

	public void PlayRedTextSfx(int killCount = 0)
	{
		//IL_0052: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		int num;
		if (0 <= killCount)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
			num = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num = killCount;
		}
		float detune = (float)num * 50f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_multhit1, soundConfig, 200f, 10, time);
	}

	protected void DespawnActiveProjectiles()
	{
		//IL_0018: Expected O, but got I4
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
	}
}
