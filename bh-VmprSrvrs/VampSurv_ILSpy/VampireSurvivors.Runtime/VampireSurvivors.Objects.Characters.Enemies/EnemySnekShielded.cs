using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySnekShielded : EnemyController
{
	private Timer _shieldTimer;

	private bool _hasShield;

	private float _shieldDamage;

	private float _shieldDuration = 2000f;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		_shieldDuration = currentEnemyData._003CshieldDuration_003Ek__BackingField;
		_shieldDamage = 0f;
		_hasShield = true;
		if (_shieldTimer != null)
		{
			_shieldTimer.Cancel();
		}
		Action onComplete = delegate
		{
			float hp = _hp - _shieldDamage;
			_hasShield = false;
			_hp = hp;
		};
		float duration = _shieldDuration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer shieldTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_shieldTimer = shieldTimer;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_01d6: Invalid comparison between F4 and I4
		//IL_0200: Invalid comparison between I4 and F4
		//IL_027c: Expected O, but got I4
		//IL_029a: Expected O, but got I
		//IL_02bd: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0112: Expected O, but got I
		//IL_007e: Expected O, but got F4
		//IL_0096: Expected O, but got F4
		//IL_0156: Expected O, but got I8
		//IL_01b9: Expected O, but got F4
		bool flag = !(value > 0f);
		float num = value;
		float num2 = default(float);
		if (!flag)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag2 = !config._003CDamageNumbersEnabled_003Ek__BackingField;
			num = value;
			Vector2 vector = (Vector2)0;
			if (!flag2)
			{
				float2 float5 = base.position;
				GM.Core.ShowDamageAt((Vector2)num2, value);
				float num3 = num2;
				float num4 = default(float);
				num = num4;
				vector = (Vector2)num2;
			}
		}
		if (!_hasShield)
		{
			float num3 = _hp - value;
			_hp = num3;
		}
		else
		{
			float shieldDamage = value + _shieldDamage;
			_shieldDamage = shieldDamage;
		}
		if (!(0f < _hp))
		{
			nint num5 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v27 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemySnekShielded>)+460]");
			Vector2 vector = (Vector2)0;
			base.Die();
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		float? num6 = (float?)(object)1;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num6 = (float?)(object)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v318 @ rax_v11 (should have been resolved before IL gen)");
		float num7 = 0f - 0.5f;
		float detune = num7 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Secret, soundConfig, 150f, 3, time);
		if (showHitVfx != HitVfxType.None)
		{
			float2 float6 = base.position;
			VFXManager.SpawnImpactVFX(showHitVfx, (Vector2)num2);
		}
		bool hasKb2 = default(bool);
		base.OnGetDamaged(showHitVfx, hasKb2);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18774E1F0\"");
	}

	private unsafe void SnakeUpdate()
	{
		//IL_015e: Expected F4, but got I
		//IL_00a8->IL004d: Incompatible stack heights: 1 vs 0
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				object obj = ret - ret2;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				EnemySnekShielded cachedTransform2 = (EnemySnekShielded)(object)_cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Quaternion.AngleAxis_Injected((float)(nint)((UnityEngine.Object)cachedTransform).m_CachedPtr, ref ret, out Quaternion _);
				bool flag3 = (object)_cachedTransform == null;
				bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Quaternion*)(&ret2));
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitEnemy_003Eb__4_0()
	{
		float hp = _hp - _shieldDamage;
		_hasShield = false;
		_hp = hp;
	}
}
