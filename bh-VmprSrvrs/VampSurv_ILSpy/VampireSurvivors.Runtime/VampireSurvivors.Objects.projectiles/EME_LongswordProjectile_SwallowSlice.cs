using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_LongswordProjectile_SwallowSlice : Projectile
{
	private ParticleSystem swallowSliceVFX;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
	}

	public unsafe void SetDirection(Vector3 direction)
	{
		//IL_0014: Expected I4, but got I8
		//IL_003e: Expected O, but got I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected I4, but got Unknown
		//IL_0173: Expected O, but got Ref
		int num = (int)(_indexInWeapon & 0x8000001FL);
		object obj = default(object);
		object obj2 = default(object);
		if (obj != obj2)
		{
			object obj3 = num - 1;
			object obj4 = obj3 | -32;
			num = obj4 + 1;
		}
		float num2 = (float)num * 0.1f;
		float num3 = 3f - num2;
		bool flag = !(0.5f < num3);
		float scaleToArea = 0.5f;
		if (!flag)
		{
			scaleToArea = num3;
		}
		SetScaleToArea(scaleToArea);
		Transform cachedTransform = _cachedTransform;
		_isCullable = true;
		_speed = 2f;
		bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
		Transform cachedTransform2 = _cachedTransform;
		bool flag3 = (object)_cachedTransform == null;
		bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
		ApplyPlayerFacingVelocity((Vector3)(&ret));
		if ((object)swallowSliceVFX != null)
		{
			swallowSliceVFX.Play(withChildren: true);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			if ((object)swallowSliceVFX != null)
			{
				swallowSliceVFX.Stop();
			}
			if ((object)swallowSliceVFX != null)
			{
				swallowSliceVFX.Clear(withChildren: true);
			}
			_isCullable = true;
			base.Despawn();
		}
	}

	private void DeactivateProjectile()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if ((object)swallowSliceVFX != null)
		{
			swallowSliceVFX.Stop();
		}
		if ((object)swallowSliceVFX != null)
		{
			swallowSliceVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}
}
