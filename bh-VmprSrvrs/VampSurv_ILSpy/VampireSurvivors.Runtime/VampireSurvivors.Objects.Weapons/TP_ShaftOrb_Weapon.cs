using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_ShaftOrb_Weapon : TP_Light1_Weapon
{
	private PhaserSprite _sprite1;

	private PhaserSprite _sprite2;

	private PhaserSprite _sprite3;

	private float _angle1;

	private float _angle2;

	private float _angle3;

	protected unsafe override void OnStart()
	{
		//IL_00b5: Expected I4, but got I8
		//IL_00d2: Expected I4, but got I8
		base.OnStart();
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite sprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_ShaftRing01");
		_sprite1 = sprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite sprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_ShaftRing02");
		_sprite2 = sprite2;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite sprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_ShaftRing03");
		_sprite3 = sprite3;
		PhaserSprite phaserSprite = _sprite1.setDepth(-2);
		PhaserSprite phaserSprite2 = _sprite2.setDepth(-1);
		PhaserSprite phaserSprite3 = _sprite3.setDepth(1);
		_angle1 = 0f;
		_angle3 = 0f;
		Transform transform = _sprite1.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		Transform transform2 = _sprite2.transform;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector2 value2 = default(Vector2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
		Transform transform3 = _sprite3.transform;
		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Vector2 value3 = default(Vector2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value3));
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00c5: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		//IL_0125: Expected O, but got Ref
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * 2.1618f;
		float num3 = num * 1.6181f;
		float angle = num2 + _angle2;
		float angle2 = num + _angle1;
		float angle3 = num3 + _angle3;
		_angle2 = angle;
		_angle1 = angle2;
		_angle3 = angle3;
		Transform transform = _sprite1.transform;
		object obj = default(object);
		transform.Rotate((Vector3)(&obj), 2f, Space.Self);
		Transform transform2 = _sprite2.transform;
		transform2.Rotate((Vector3)(&obj), 2.2f, Space.Self);
		Transform transform3 = _sprite3.transform;
		transform3.Rotate((Vector3)(&obj), 2.4f, Space.Self);
	}

	public override void Cleanup()
	{
		PhaserSprite phaserSprite = _sprite1.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _sprite2.setVisible(visible: false);
		PhaserSprite phaserSprite3 = _sprite3.setVisible(visible: false);
		base.Cleanup();
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		_isVisible = visible;
		if (!visible)
		{
			List<Projectile> spawnedProjectiles = _spawnedProjectiles;
			bool flag = (nint)_spawnedProjectiles < 0;
			object obj = spawnedProjectiles._size - 1;
			if (!flag)
			{
				Projectile[] items;
				do
				{
					List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
					if ((nint)obj < spawnedProjectiles2._size)
					{
						items = spawnedProjectiles2._items;
						items[obj].Despawn();
						obj--;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				while ((nint)items[obj] >= 0);
			}
		}
		PhaserSprite phaserSprite = _sprite1.setVisible(visible);
		PhaserSprite phaserSprite2 = _sprite2.setVisible(visible);
		PhaserSprite phaserSprite3 = _sprite3.setVisible(visible);
	}
}
