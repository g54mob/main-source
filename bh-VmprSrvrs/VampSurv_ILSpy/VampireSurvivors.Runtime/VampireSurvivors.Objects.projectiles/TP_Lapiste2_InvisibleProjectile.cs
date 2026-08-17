using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Lapiste2_InvisibleProjectile : Projectile
{
	private const float Radius = 16f;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SetScaleToArea();
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		_isCullable = false;
	}

	public void AttachToTransform(Transform transform)
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
		_cachedTransform.SetParent(transform, worldPositionStays: true);
		TP_Lapiste2_InvisibleProjectile cachedTransform = (TP_Lapiste2_InvisibleProjectile)(object)_cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			Weapon weapon = _weapon;
			if (weapon._explodeOnExpire)
			{
				float2 pos = base.position;
				Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
			}
			if (_weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
			{
				bool flag = TryFreeze(other);
			}
			if (_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
			{
				Weapon weapon2 = _weapon;
				GameManager gameMan = weapon2._gameMan;
				float2 float5 = base.position;
				Vector2 pos2 = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(pos2);
			}
		}
	}
}
