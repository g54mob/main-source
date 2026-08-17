using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Projectiles;

public class EnemyProjectile : ArcadeSprite
{
	protected SpriteTrail _spriteTrail;

	protected float _speed;

	protected int _indexInWeapon;

	private EnemyBulletPool _pool;

	private float _003CDamage_003Ek__BackingField;

	public float ProjectileSpeed => _speed * 1.6500001f;

	public float Damage
	{
		get
		{
			return _003CDamage_003Ek__BackingField;
		}
		protected set
		{
			_003CDamage_003Ek__BackingField = value;
		}
	}

	protected virtual void Awake()
	{
		SpriteTrail componentInChildren = GetComponentInChildren<SpriteTrail>();
		_spriteTrail = componentInChildren;
	}

	public virtual void InitProjectile(int index, float2 direction, EnemyBulletPool pool)
	{
		_indexInWeapon = index;
		_pool = pool;
		if (body == null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			Factory add = s_scene.add;
			PhaserGameObject phaserGameObject = add._world.enableBody(this);
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
		Group obj = pool.add(this);
		SpriteTrail spriteTrail = _spriteTrail;
		if ((object)_spriteTrail != null && ((UnityEngine.Object)spriteTrail).m_CachedPtr != (IntPtr)0)
		{
			_spriteTrail.Reset();
		}
	}

	public virtual void Despawn()
	{
		_pool.remove(this);
		BaseBody baseBody = body;
		baseBody._enable = false;
		EnemyBulletPool pool = _pool;
		if ((object)pool._pool != null)
		{
			GameObject obj = base.gameObject;
			pool._pool.Release(obj);
		}
	}

	public virtual void OnHitPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		bool damaged = player.GetDamaged(_003CDamage_003Ek__BackingField);
		Despawn();
	}

	public virtual void OnHasHitWallPhaser(PhaserTile tile)
	{
		Despawn();
	}

	public virtual bool ShouldHitWalls()
	{
		return true;
	}

	public void SetVelocity(Vector2 velocity)
	{
		BaseBody baseBody = body;
		baseBody._velocity = velocity;
	}

	public EnemyProjectile()
	{
		//IL_002b: Expected I, but got O
		_speed = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
