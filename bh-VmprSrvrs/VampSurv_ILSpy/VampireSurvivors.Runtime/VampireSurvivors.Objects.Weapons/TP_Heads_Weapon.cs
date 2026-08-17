using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Heads_Weapon : TP_Clockwork_Weapon
{
	private Transform _cachedCameraTransform;

	private Vector2 _leftOffset;

	private Vector2 _rightOffset;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_005d: Expected O, but got F4
		//IL_00b7: Expected O, but got F4
		base.InitWeapon(characterController, weaponType);
		Camera main = Camera.main;
		Transform cachedCameraTransform = main.transform;
		_cachedCameraTransform = cachedCameraTransform;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width * -0.6f;
		_ = 0;
		_leftOffset = (Vector2)num;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			float num2 = renderer2.width * 0.6f;
			_ = 0;
			_rightOffset = (Vector2)num2;
			return;
		}
		throw new NullReferenceException();
	}

	public override void FireProjectiles(Vector2 pos)
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
			Transform cachedCameraTransform = _cachedCameraTransform;
			if ((object)_cachedCameraTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedCameraTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedCameraTransform).m_CachedPtr, out Vector3 _);
				if (!flipX)
				{
				}
				Vector2 pos2 = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos2, 0, _targetTransform);
				return;
			}
		}
		throw new NullReferenceException();
	}
}
