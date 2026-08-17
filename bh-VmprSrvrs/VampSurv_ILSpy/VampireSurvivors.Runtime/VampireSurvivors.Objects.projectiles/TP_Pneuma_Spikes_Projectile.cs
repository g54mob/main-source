using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Pneuma_Spikes_Projectile : Projectile
{
	private const float Radius = 0.25f;

	private float _spacer = 0.25f;

	private float _timer;

	private int _counter;

	private Timer _spikeTimerEvent;

	private Timer _completeTimerEvent;

	private float2 _originalPos;

	private float2 _direction;

	private float _angle;

	private float _iterationScale;

	private float _iterationScaleMultiply = 0.75f;

	private float _iterationAlpha;

	private float _iterationAlphaMultiply = 0.75f;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0229: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0031: Expected I, but got O
		//IL_004d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		_timer = 0f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		nint num = (nint)weapon;
		float num2 = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		float2 originalPos = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		_originalPos = originalPos;
		_ = 3238002688L;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		float2 direction = default(float2);
		_direction = direction;
		_ = 3238002688L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num3 = 3.2380027E+09f * 57.29578f;
		float num4 = (_angle = num3 + 180f);
		float num5 = _weapon.PArea();
		float iterationScale = num4 * 0.8f;
		_iterationAlpha = 0.8f;
		_iterationScale = iterationScale;
		Action onComplete = delegate
		{
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_0067: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			Weapon weapon2 = _weapon;
			float2 pos = base.position;
			nint num7 = (nint)typeof(TP_Pneuma_Weapon);
			nint num8 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pneuma_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pneuma_Weapon>)+130]");
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6+FFFFFFF8+v49 @ rax_v5*8]");
				if (0 == (nint)typeof(TP_Pneuma_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pneuma_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6+FFFFFFF8+v91 @ rcx_v5*8]");
					object obj4 = 0 - typeof(TP_Pneuma_Weapon);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					TP_Pneuma_Weapon tP_Pneuma_Weapon = null;
					if (!flag2)
					{
						tP_Pneuma_Weapon = (TP_Pneuma_Weapon)weapon2;
					}
					float alpha = default(float);
					tP_Pneuma_Weapon.addSpikeSprite(pos, _angle, _iterationScale, alpha);
					float iterationScale2 = _iterationScaleMultiply * _iterationScale;
					float iterationAlpha = _iterationAlphaMultiply * _iterationAlpha;
					_iterationScale = iterationScale2;
					_iterationAlpha = iterationAlpha;
					return;
				}
			}
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer spikeTimerEvent = Timers.Register(0.05f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_spikeTimerEvent = spikeTimerEvent;
		float num6 = _weapon.PDuration();
		Action onComplete2 = delegate
		{
			_spikeTimerEvent.Cancel();
			Despawn();
		};
		float duration = 0.05f * 0.001f;
		Timer completeTimerEvent = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_completeTimerEvent = completeTimerEvent;
	}

	private void updateSpikePos()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		float num = _weapon.PAmount();
		float num2 = _weapon.PArea();
		object obj = default(object);
		float num3 = (float)obj - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,dword ptr [rbx+70h]\"");
		object obj2 = 0 * _spacer;
		float num4 = num3 * 0.5f;
		float num5 = (float)obj * 0.25f;
		float num6 = num4 * _spacer;
		float num7 = _timer * _timer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj3 = num6 ^ 0;
		object obj4 = obj2 + obj3;
		float num8 = num7 + 2f;
		float num9 = (float)obj4 * 57.29578f;
		float num10 = num8 * num5;
		float num11 = num9 / 360f;
		float num12 = num5 * ((float)Math.PI * 2f);
		float num13 = num10 * ((float)Math.PI * 2f);
		float num14 = num11 * num12;
		float num15 = num14 * 360f;
		float num16 = num15 / num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float num17 = num10 - 0.25f;
		object obj5 = default(object);
		float num18 = (float)obj5 * num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num19 = num16 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Pneuma_Spikes_Projectile)+FC]");
		float num20 = 0f + num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float5 = default(float2);
		base.position = float5;
	}

	public override void InternalUpdate()
	{
		//IL_00eb: Expected O, but got F4
		float deltaTime = PauseSystem.DeltaTime;
		float num = _weapon.PSpeed();
		float num2 = deltaTime * deltaTime;
		float num3 = num2 + num2;
		float timer = num3 + _timer;
		_timer = timer;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num4 = (float)_direction * deltaTime2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Pneuma_Spikes_Projectile)+FC]");
		float num5 = 0f * deltaTime2;
		float num6 = _weapon.PSpeed();
		float num7 = num4 * deltaTime2;
		float num8 = num5 * deltaTime2;
		float num9 = (float)_originalPos + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Pneuma_Spikes_Projectile)+F4]");
		float num10 = 0f + num8;
		_originalPos = (float2)num9;
		updateSpikePos();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	public void manuallySetDirection(float2 direction)
	{
		_direction = direction;
	}

	public void manuallySetOriginalPos(float2 originalPos)
	{
		_originalPos = originalPos;
	}

	public override void Despawn()
	{
		if (_spikeTimerEvent != null)
		{
			_spikeTimerEvent.Cancel();
		}
		if (_completeTimerEvent != null)
		{
			_completeTimerEvent.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Weapon weapon = _weapon;
		float2 pos = base.position;
		nint num = (nint)typeof(TP_Pneuma_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pneuma_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pneuma_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6+FFFFFFF8+v49 @ rax_v5*8]");
			if (0 == (nint)typeof(TP_Pneuma_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pneuma_Weapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6+FFFFFFF8+v91 @ rcx_v5*8]");
				object obj4 = 0 - typeof(TP_Pneuma_Weapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				TP_Pneuma_Weapon tP_Pneuma_Weapon = null;
				if (!flag2)
				{
					tP_Pneuma_Weapon = (TP_Pneuma_Weapon)weapon;
				}
				float alpha = default(float);
				tP_Pneuma_Weapon.addSpikeSprite(pos, _angle, _iterationScale, alpha);
				float iterationScale = _iterationScaleMultiply * _iterationScale;
				float iterationAlpha = _iterationAlphaMultiply * _iterationAlpha;
				_iterationScale = iterationScale;
				_iterationAlpha = iterationAlpha;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__14_1()
	{
		_spikeTimerEvent.Cancel();
		Despawn();
	}
}
