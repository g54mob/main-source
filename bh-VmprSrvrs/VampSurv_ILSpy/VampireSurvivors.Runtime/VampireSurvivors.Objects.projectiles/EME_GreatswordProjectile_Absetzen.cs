using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_GreatswordProjectile_Absetzen : EME_GreatswordProjectile
{
	private ParticleSystem _SwordHeadFX;

	private Vector3 _defaultSwordSpriteRotation;

	protected override float MinTimeToLand => 750f;

	protected override float MaxTimeToLand => 1500f;

	protected override void DoGlimmerAttack()
	{
	}

	protected override void InitVelocity()
	{
		//IL_00d1: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rcx+70h]\"");
		float num = 0f * 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rcx+114h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,dword ptr [rcx+70h]\"");
		float num2 = num + 5f;
		float num3 = 0f * 0.1f;
		float num4 = num3 + 4f;
		float num5 = num2 * 0f;
		float num6 = 90f - num5;
		float num7 = num6 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num8 = num7 * num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num9 = num7 * num4;
		_velocity = (Vector2)num8;
	}

	public void RotateTowardsBeamTarget(EME_GreatswordProjectile_Absetzen target)
	{
		float2 float5 = target.position;
		float2 float6 = base.position;
		float2 float7 = base.position;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		object obj4 = float5 - float7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 36 Invalid \"Jump target not found in method: 0x1871DDEF0\"");
		throw new NullReferenceException();
	}

	public void RotateAtAngle(float angle)
	{
		RotateSwordSprite(angle);
	}

	private unsafe void RotateSwordSprite(float angle)
	{
		//IL_0086: Expected O, but got F4
		//IL_00a3: Expected I, but got O
		//IL_00ab: Expected I, but got O
		//IL_00bb: Expected O, but got I
		//IL_00f7: Expected O, but got I
		//IL_017e: Expected O, but got Ref
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			_SwordSprite.sprite = _swordSpriteFull;
		}
		Transform transform = _SwordSprite.transform;
		Vector3 eulerAngles = transform.eulerAngles;
		Weapon weapon = _weapon;
		_defaultSwordSpriteRotation = (Vector3)eulerAngles.x;
		_ = eulerAngles.z;
		nint num = (nint)typeof(EME_Greatsword2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword2Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v12+FFFFFFF8+v246 @ rax_v11*8]");
			if (0 == (nint)typeof(EME_Greatsword2Weapon))
			{
				if (_angleTween != null)
				{
					TweenExtensions.Kill(_angleTween);
				}
				Transform target = _SwordSprite.transform;
				object obj3 = default(object);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj3), 0.25f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 3;
							_ = 0;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				TweenCallback tweenCallback = PlaySwordHeadVfx;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
				}
				_angleTween = tweenerCore;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySwordHeadVfx()
	{
		ParticleSystem swordHeadFX = _SwordHeadFX;
		if ((object)_SwordHeadFX != null && ((UnityEngine.Object)swordHeadFX).m_CachedPtr != (IntPtr)0)
		{
			_SwordHeadFX.Play(withChildren: true);
		}
	}

	public unsafe override void Despawn()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _SwordSprite.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
		ParticleSystem swordHeadFX = _SwordHeadFX;
		if ((object)_SwordHeadFX != null && ((UnityEngine.Object)swordHeadFX).m_CachedPtr != (IntPtr)0)
		{
			_SwordHeadFX.Stop();
		}
		base.Despawn();
	}
}
