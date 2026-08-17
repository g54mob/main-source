using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Backup_PlaneProjectile : Projectile
{
	private float2 _targetPosition;

	private float _timeSinceChangedTarget;

	private Timer _timerEvent;

	public BulletPool bulletPool;

	[NonSerialized]
	public float planeAngleOffset = 140f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Flame1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected I, but got O
		//IL_0081: Expected O, but got F4
		//IL_00c8: Expected F4, but got I4
		//IL_0110: Expected I4, but got F4
		//IL_0110: Expected O, but got F4
		//IL_0110: Expected I4, but got O
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		RefreshTarget();
		float num = UnityEngine.Random.Range(-180f, 180f);
		nint num2 = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		BaseBody baseBody = body;
		float num3 = num * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float num4 = num3 * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		baseBody._velocity = (float2)num4;
		float num5 = num3 * num;
		float? num6 = default(float?);
		float num7 = default(float);
		float num8 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_HomingShot, 100f, 12, 0f, num6, num7, num8, flag, 1f);
		Action onComplete = delegate
		{
			fireBullet();
		};
		Timer timerEvent = Timers.Register(0.25f, onComplete, null, isLooped: true, (byte)(int)num6 != 0, (MonoBehaviour)num7, (int)num8, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		_timerEvent = timerEvent;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_02b0: Invalid comparison between F4 and O
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Ref, but got Unknown
		//IL_0224->IL022b: Incompatible stack heights: 1 vs 0
		//IL_0111->IL0224: Incompatible stack heights: 1 vs 0
		//IL_02e6->IL0224: Incompatible stack heights: 1 vs 0
		//IL_0194->IL0224: Incompatible stack heights: 1 vs 0
		//IL_01b6->IL0224: Incompatible stack heights: 1 vs 0
		//IL_0219->IL022b: Incompatible stack heights: 1 vs 0
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime + _timeSinceChangedTarget;
		planeAngleOffset = 140f;
		_timeSinceChangedTarget = num;
		if (!(num > 0.5f))
		{
			return;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float2 float5 = base.cachedPosition;
				object obj = (object)ret - (object)float5;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				object obj5 = obj * obj;
				object obj6 = obj2 * obj2;
				object obj7 = obj5 + obj6;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
				{
					RefreshTarget();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
				BaseBody baseBody = body;
				float target = (float)obj2 * 57.29578f;
				if (body != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v16 (BaseBody)+74]");
					float current = 0f * 57.29578f;
					float deltaTime2 = PauseSystem.DeltaTime;
					float maxDelta = deltaTime2 * 250f;
					float num2 = Mathf.MoveTowardsAngle(current, target, maxDelta);
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						float projectileSpeed = base.ProjectileSpeed;
						if (body != null && (object)s_scene.physics != null)
						{
							float rotation = num2 * ((float)Math.PI / 180f);
							ref float2 vec = ref *(float2*)(body + 112);
							float2 float6 = s_scene.physics.velocityFromRotation(rotation, num2, ref vec);
							float num3 = num2 + planeAngleOffset;
							base.angle = num3;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RefreshTarget()
	{
		//IL_013c: Expected O, but got F4
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				UnityEngine.Random.GetRandomUnitCircle(out Vector2 output);
				float num = (float)output * 50f;
				object obj = default(object);
				float num2 = (float)obj * 50f;
				float num3 = num * 0.01f;
				float num4 = num2 * 0.01f;
				float num5 = (float)ret + num3;
				object obj2 = default(object);
				float num6 = (float)obj2 + num4;
				_timeSinceChangedTarget = 0f;
				_targetPosition = (float2)num5;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void fireBullet()
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Ref, but got Unknown
		if (bulletPool == null)
		{
			return;
		}
		float2 float5 = base.position;
		float2 float6 = base.position;
		float2 float7 = default(float2);
		Projectile projectile = bulletPool.SpawnAt(float7, _weapon);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			projectile.SetNullTarget();
			BaseBody baseBody = projectile.body;
			if (projectile.body != null)
			{
				baseBody._transform.ForceFullReupdate();
			}
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			float num = cachedTrans.localEulerAngles.z - planeAngleOffset;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			float projectileSpeed = projectile.ProjectileSpeed;
			float speed = (float)float7 + (float)float7;
			ref float2 vec = ref *(float2*)(projectile.body + 112);
			float rotation = num * ((float)Math.PI / 180f);
			float2 float8 = s_scene.physics.velocityFromRotation(rotation, speed, ref vec);
			projectile.angle = num;
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_timerEvent != null)
		{
			_timerEvent.Cancel();
		}
		if (bulletPool != null)
		{
			bulletPool.Cleanup();
		}
	}

	private void _003CInitProjectile_003Eb__6_0()
	{
		fireBullet();
	}
}
