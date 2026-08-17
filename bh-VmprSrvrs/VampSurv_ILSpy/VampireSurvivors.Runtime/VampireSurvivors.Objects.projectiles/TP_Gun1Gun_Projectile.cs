using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Gun1Gun_Projectile : Projectile
{
	private float _flipNum;

	private float _rotationInc;

	private float _rotationMultiplier = 150f;

	private MultiTargetTween _scaleTween;

	protected Timer _despawnTimer;

	protected float _floorY;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_GUN1", "TP_items");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02bd: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_01ee: Expected F4, but got I4
		//IL_02da->IL01f3: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			SetScaleToArea();
			_penetrating = 65535;
			_rotationMultiplier = 150f;
			if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
				object obj = (flag ? 1 : 0) ^ 1;
				object obj2 = obj * 2;
				float flipNum = (float)obj2 - 1f;
				_flipNum = flipNum;
				Transform transform = base.transform;
				Vector3 euler = default(Vector3);
				float ret;
				Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v23 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v23 (UnityEngine.Transform)+10]");
				float value = default(float);
				Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
				float projectileSpeed = base.ProjectileSpeed;
				float projectileSpeed2 = base.ProjectileSpeed;
				float num = ret;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj3 = num ^ 0;
				float xVel = (float)obj3 * _flipNum;
				setVelocity(xVel, (float?)(object)1);
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					_floorY = ret;
					if (_despawnTimer != null)
					{
						_despawnTimer.Cancel();
					}
					float num2 = weapon.PDuration();
					Action onComplete = StartDespawn;
					float duration = ret * 0.001f;
					bool flag3 = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_despawnTimer = despawnTimer;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Rate = 2f
					}, 200f, 10, flag3 ? 1 : 0);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
	}

	public override void InternalUpdate()
	{
		//IL_0033: Expected O, but got I4
		float num = (_rotationMultiplier *= 0.98f);
		float projectileSpeed = base.ProjectileSpeed;
		float deltaTime = PauseSystem.DeltaTime;
		float num2 = _rotationMultiplier * num;
		float num3 = num2 * deltaTime;
		float num4 = num3 * _flipNum;
		float rotationInc = num4 + _rotationInc;
		_rotationInc = rotationInc;
		Transform transform = base.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		BaseBody baseBody = body;
		float xVel = (float)baseBody._velocity * 0.98f;
		setVelocity(xVel, (float?)(object)1);
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Gun1Gun_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}
}
