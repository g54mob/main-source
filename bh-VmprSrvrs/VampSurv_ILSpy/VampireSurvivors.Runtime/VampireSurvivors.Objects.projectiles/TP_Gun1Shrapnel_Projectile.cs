using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Gun1Shrapnel_Projectile : Projectile
{
	protected TrailRenderer _trail;

	protected Timer _despawnTimer;

	[NonSerialized]
	public float2 Offset;

	protected override void Awake()
	{
		//IL_0124->IL00ae: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		if ((object)_trail != null)
		{
			Material material = ((Renderer)_trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			TrailRenderer trail = _trail;
			if ((object)_trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)trail).m_CachedPtr, 999);
				TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
				TP_Gun1Shrapnel_Projectile trail2 = (TP_Gun1Shrapnel_Projectile)(object)_trail;
				if ((object)_trail != null)
				{
					bool flag2 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 129 ConditionalJump @-1, v210 @ ZF_v12 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 202 ConditionalJump @-1, v365 @ ZF_v17 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0076: Expected I4, but got O
		//IL_03b5: Expected O, but got F4
		//IL_029a: Expected O, but got F4
		//IL_02a5: Expected I4, but got O
		//IL_00df: Expected I4, but got O
		//IL_01f9: Expected I4, but got O
		base.InitProjectile(pool, weapon, index);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(2f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite = setAlpha(0.75f);
			_speed = 5f;
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				int num2 = (int)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v14 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v14 (System.Int32)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					object obj = UnityEngine.Random.value;
					object obj2 = UnityEngine.Random.value;
					int num3 = (int)_cachedTransform;
					bool flag2 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdi_v15 (System.Int32)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdi_v15 (System.Int32)+10]");
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)0, ref value);
					Weapon weapon2 = _weapon;
					bool flag4 = (object)_weapon == null;
					WeaponData currentWeaponData = weapon2._currentWeaponData;
					bool flag5 = weapon2._currentWeaponData == null;
					int num4 = (int)_trail;
					int penetrating = currentWeaponData._003Cpenetrating_003Ek__BackingField + 3;
					_penetrating = penetrating;
					bool flag6 = (object)_trail == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rdi_v16 (System.Int32)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rdi_v16 (System.Int32)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					bool flag8 = (object)_trail == null;
					_trail.startWidth = 0.02f;
					bool flag9 = (object)_trail == null;
					_trail.endWidth = 0f;
					bool flag10 = (object)_trail == null;
					_trail.time = 0.1f;
					bool flag11 = (object)_trail == null;
					Material material = ((Renderer)_trail).GetMaterial();
					RenderingExtensions.SetAlpha(material, 0.65f);
					bool flag12 = (object)_trail == null;
					_trail.emitting = true;
					int num5 = (int)_trail;
					bool flag13 = (object)_trail == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ rdi_v18 (System.Int32)+10]");
					bool flag14 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ rdi_v18 (System.Int32)+10]");
					Color value2 = default(Color);
					TrailRenderer.set_startColor_Injected((IntPtr)0, ref value2);
					EnableTrail(enable: false);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void EnableTrail(bool enable)
	{
		_trail.enabled = enable;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
	}

	public override void Despawn()
	{
		TrailRenderer trail = _trail;
		if ((object)_trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_trail.Clear();
			_trail.emitting = false;
		}
		base.Despawn();
	}
}
