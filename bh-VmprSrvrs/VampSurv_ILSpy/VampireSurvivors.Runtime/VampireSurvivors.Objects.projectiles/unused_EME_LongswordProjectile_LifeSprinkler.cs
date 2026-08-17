using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class unused_EME_LongswordProjectile_LifeSprinkler : Projectile
{
	private ParticleSystem lifeSprinklerFullVFX;

	private ParticleEventCall lifeSprinklerFullVFXParticleEventCall;

	private ParticleSystem lifeSprinklerCrossVFX;

	private ParticleEventCall lifeSprinklerCrossVFXParticleEventCall;

	private float radius = 15f;

	private int hitMultiplier = 1;

	private int _amountOfHits;

	private float _spriteHalfHeight;

	private EnemyController _strongestEnemy;

	private Timer _hitboxTimer;

	private Camera _camera;

	protected override void Awake()
	{
		base.Awake();
		Camera main = Camera.main;
		_camera = main;
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = true;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		SetupMechanics();
		SetupVFX();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0340->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_007d->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_00ac->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_0142->IL02bc: Incompatible stack heights: 5 vs 0
		//IL_040d->IL02bc: Incompatible stack heights: 5 vs 0
		//IL_0298->IL02bc: Incompatible stack heights: 5 vs 0
		//IL_0209->IL02bc: Incompatible stack heights: 5 vs 0
		//IL_022c->IL02bc: Incompatible stack heights: 5 vs 0
		//IL_024c->IL02bc: Incompatible stack heights: 5 vs 0
		//IL_049a->IL03f3: Incompatible stack heights: 7 vs 5
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					Transform transform2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						float2 ret2;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret2));
						bool flag3 = (object)lifeSprinklerFullVFX == null;
						Transform transform3 = lifeSprinklerFullVFX.transform;
						bool flag4 = (object)transform3 == null;
						bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&ret2));
						Transform strongestEnemy = (Transform)(object)_strongestEnemy;
						if ((object)_strongestEnemy != null && ((UnityEngine.Object)strongestEnemy).m_CachedPtr != (IntPtr)0)
						{
							EnemyController strongestEnemy2 = _strongestEnemy;
							if ((object)_strongestEnemy == null)
							{
								goto IL_02bc;
							}
							if (!strongestEnemy2._003CIsDead_003Ek__BackingField)
							{
								goto IL_03f3;
							}
						}
						EnemyController strongestEnemy3 = ((_amountOfHits <= 0) ? null : GetStrongestTarget());
						_strongestEnemy = strongestEnemy3;
						Transform strongestEnemy4 = (Transform)(object)_strongestEnemy;
						if ((object)_strongestEnemy == null || ((UnityEngine.Object)strongestEnemy4).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						EnemyController strongestEnemy5 = _strongestEnemy;
						if ((object)_strongestEnemy != null && strongestEnemy5.body != null && (object)lifeSprinklerCrossVFX != null)
						{
							Transform transform4 = lifeSprinklerCrossVFX.transform;
							bool flag6 = (object)transform4 == null;
							bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&ret));
							goto IL_03f3;
						}
					}
				}
			}
		}
		goto IL_02bc;
		IL_02bc:
		throw new NullReferenceException();
		IL_03f3:
		if ((object)_strongestEnemy != null)
		{
			float2 float5 = _strongestEnemy.position;
			if ((object)_strongestEnemy != null)
			{
				float2 float6 = _strongestEnemy.position;
				float2 float7 = default(float2);
				base.position = float7;
				return;
			}
		}
		goto IL_02bc;
	}

	private void SetupMechanics()
	{
		//IL_0014: Expected I4, but got F4
		//IL_0038: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0207->IL017d: Incompatible stack heights: 1 vs 0
		//IL_0169->IL017d: Incompatible stack heights: 1 vs 0
		if ((object)_weapon != null)
		{
			int amountOfHits = (int)_weapon.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			_amountOfHits = amountOfHits;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setVisible(visible: true);
			Weapon weapon = _weapon;
			_isCullable = false;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					CharacterData currentSkinData = characterController._currentSkinData;
					if (characterController._currentSkinData != null)
					{
						Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField);
						if ((object)sprite != null)
						{
							bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
							object obj = default(object);
							float spriteHalfHeight = (float)obj * 0.5f;
							_spriteHalfHeight = spriteHalfHeight;
							if (body != null)
							{
								BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
								BaseBody baseBody2 = body;
								if (body != null)
								{
									baseBody2._enable = true;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupVFX()
	{
		//IL_00da->IL0089: Incompatible stack heights: 1 vs 0
		if ((object)lifeSprinklerCrossVFX != null)
		{
			Transform transform = lifeSprinklerCrossVFX.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				if ((object)lifeSprinklerFullVFX != null)
				{
					Transform transform2 = lifeSprinklerFullVFX.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					if ((object)lifeSprinklerFullVFX != null)
					{
						lifeSprinklerFullVFX.Play(withChildren: true);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			lifeSprinklerCrossVFX.Play(withChildren: true);
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			float hitBoxDelay = _weapon.HitBoxDelay;
			Action onComplete = RefreshHitbox;
			float duration = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
		}
	}

	private void RefreshHitbox()
	{
		if (--_amountOfHits <= 0)
		{
			Despawn();
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		lifeSprinklerCrossVFX.Clear(withChildren: true);
	}

	private EnemyController GetStrongestTarget()
	{
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_018a: Expected O, but got I4
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected I4, but got Unknown
		//IL_01c8: Expected F4, but got I4
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected I4, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected I4, but got Unknown
		Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (UnityEngine.Bounds)+10]");
		float num = 0f * 2f;
		object obj = default(object);
		float num2 = (float)obj * 2f;
		Weapon weapon = _weapon;
		float num3 = num2 * 0.5f;
		float num4 = num * 0.5f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		float x;
		if (characterController._isFlipped)
		{
			x = (float)bounds.m_Center - (float)obj;
		}
		else
		{
			object obj2 = (object)bounds.m_Center + obj;
			x = (float)obj2 - num3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v4 (UnityEngine.Bounds)+10]");
		object obj3 = obj - 0;
		Rectangle rectangle = new Rectangle();
		float num5 = num4 * 0.5f;
		rectangle._x = x;
		rectangle._width = num3;
		rectangle._height = num4;
		float y = num5 + (float)obj3;
		rectangle._y = y;
		GameManager core = GM.Core;
		List<EnemyController> allEnemiesInScreenBounds = core._stage.GetAllEnemiesInScreenBounds(0f);
		if (allEnemiesInScreenBounds != null && allEnemiesInScreenBounds._size != 0)
		{
			bool flag = allEnemiesInScreenBounds._size <= 0;
			EnemyController result = null;
			if (!flag)
			{
				object obj4 = -allEnemiesInScreenBounds._size;
				int num6 = allEnemiesInScreenBounds._size & obj4;
				bool flag2 = num6 < 0;
				bool flag3 = (nint)obj4 < 0;
				EnemyController enemyController = null;
				float num7 = 0f;
				EnemyController enemyController2 = null;
				bool flag4;
				EnemyController result2 = default(EnemyController);
				do
				{
					if (flag3 != flag2)
					{
						EnemyController[] items = allEnemiesInScreenBounds._items;
						EnemyController enemyController3 = items[(object)enemyController2];
						if (!enemyController3._003CIsDead_003Ek__BackingField && !(num7 > enemyController3._maxHp))
						{
							num7 = enemyController3._maxHp;
							enemyController = enemyController3;
						}
						enemyController2 = (EnemyController)(enemyController2 + 1);
						object obj5 = enemyController2 - allEnemiesInScreenBounds._size;
						int num8 = enemyController2 ^ allEnemiesInScreenBounds._size;
						object obj6 = (object)enemyController2 ^ obj5;
						int num9 = num8 & obj6;
						flag2 = num9 < 0;
						flag3 = (nint)obj5 < 0;
						flag4 = (nint)enemyController2 < allEnemiesInScreenBounds._size;
						result = enemyController;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result2;
				}
				while (flag4);
			}
			return result;
		}
		return null;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		lifeSprinklerFullVFX.Stop();
		lifeSprinklerCrossVFX.Stop();
		lifeSprinklerFullVFX.Clear(withChildren: true);
		lifeSprinklerCrossVFX.Clear(withChildren: true);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_isCullable = true;
		base.Despawn();
	}

	private void SprinklerFullVFXStopped()
	{
		//IL_0065: Expected O, but got I4
		ParticleSystem particleSystem = lifeSprinklerCrossVFX;
		bool flag = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
		object obj = ParticleSystem.IsAlive_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr, true);
		if (obj == null)
		{
			_isCullable = true;
			base.Despawn();
		}
	}

	private void SprinklerCrossVFXStopped()
	{
		//IL_0065: Expected O, but got I4
		ParticleSystem particleSystem = lifeSprinklerFullVFX;
		bool flag = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
		object obj = ParticleSystem.IsAlive_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr, true);
		if (obj == null)
		{
			_isCullable = true;
			base.Despawn();
		}
	}

	private void FinishDespawn()
	{
		_isCullable = true;
		base.Despawn();
	}
}
