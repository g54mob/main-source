using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyTrinaMoon : EnemyTrina
{
	private bool _hasShield;

	private float _shieldDamage;

	private Timer _timer;

	public Action OnDefeat;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		((EnemyController)this).InitEnemy(enemyType, asRemote);
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		UpdateSprites();
		base._wings.enabled = true;
		base._snakes.enabled = true;
		base._legs.enabled = true;
		EnemyData currentEnemyData = _currentEnemyData;
		_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
		((EnemyController)this)._003CIsTeleportOnCull_003Ek__BackingField = true;
		_shieldDamage = 0f;
		_hasShield = true;
		if (_timer != null)
		{
			_timer.Cancel();
		}
		Action onComplete = delegate
		{
			float hp = _hp - _shieldDamage;
			_hasShield = false;
			_hp = hp;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(20f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timer = timer;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0146: Invalid comparison between F4 and I4
		//IL_01a3: Invalid comparison between I4 and F4
		//IL_01d1: Expected O, but got I4
		//IL_01ed: Expected O, but got F4
		//IL_0081->IL0081: Incompatible stack heights: 1 vs 0
		if (value > 0f)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CDamageNumbersEnabled_003Ek__BackingField)
			{
				object cachedTransform = _cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v6 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v6 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2990");
			}
		}
		float num = ((!_hasShield) ? (_hp -= value) : (_shieldDamage = value + _shieldDamage));
		if (0f < _hp)
		{
			_damageKb = damageKb;
		}
		else
		{
			Die();
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float num2 = num - 0.5f;
		float detune = num2 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, time);
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
	}

	protected override void Die()
	{
		((EnemyController)this).Die();
		base._wings.enabled = false;
		base._snakes.enabled = false;
		base._legs.enabled = false;
		Action onDefeat = OnDefeat;
		if (OnDefeat != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v92.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void _003CInitEnemy_003Eb__4_0()
	{
		float hp = _hp - _shieldDamage;
		_hasShield = false;
		_hp = hp;
	}
}
