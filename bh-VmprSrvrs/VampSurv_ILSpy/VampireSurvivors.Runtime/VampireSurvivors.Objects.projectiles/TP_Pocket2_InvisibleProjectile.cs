using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Pocket2_InvisibleProjectile : Projectile
{
	private const float Radius = 20f;

	private bool _003CIsSuperAttack_003Ek__BackingField;

	public bool IsSuperAttack
	{
		get
		{
			return _003CIsSuperAttack_003Ek__BackingField;
		}
		set
		{
			_003CIsSuperAttack_003Ek__BackingField = value;
		}
	}

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
		BaseBody baseBody = body.setCircle(20f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		_isCullable = false;
	}

	public void AttachToTransform(Transform transform)
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
		_cachedTransform.SetParent(transform, worldPositionStays: true);
		TP_Pocket2_InvisibleProjectile cachedTransform = (TP_Pocket2_InvisibleProjectile)(object)_cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}
}
