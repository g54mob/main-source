using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KatanaProjectile_GravediggerRock : Projectile
{
	private const float Radius = 16f;

	private const float AreaMultiplier = 0.7f;

	private Vector2 _velocity;

	private Tween _angleTween;

	private Tween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA8C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("rock0000", "vfx");
		_renderer.sprite = sprite;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0549: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0064: Expected O, but got I
		//IL_0088: Expected I4, but got I8
		//IL_069b: Expected O, but got I
		//IL_06a9: Expected O, but got I4
		//IL_00dd: Expected O, but got I8
		//IL_015b: Expected I, but got O
		//IL_01a2: Expected O, but got I4
		//IL_011b: Expected O, but got I8
		//IL_01d2: Expected O, but got I4
		//IL_0246: Expected O, but got I
		//IL_02c0: Expected O, but got Ref
		//IL_02d0: Expected O, but got I
		//IL_037e: Expected O, but got Ref
		//IL_02a7: Expected O, but got I8
		//IL_033b: Expected O, but got I8
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		BaseBody baseBody = body;
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		bool flag = characterController._isFlipped;
		Space space = (Space)(-1);
		if (!flag)
		{
			space = Space.Self;
		}
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			baseBody = (BaseBody)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v364 @ rax_v21 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Vector2 velocity = (Vector2)(0 * (int)space);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			baseBody = (BaseBody)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v395 @ rax_v24 (should have been resolved before IL gen)");
		ArcadeSprite sprite = _sprite;
		_velocity = velocity;
		_ = 3.5f;
		BaseBody baseBody3 = sprite.body;
		float2 float5 = default(float2);
		baseBody3._velocity = float5;
		Weapon weapon3 = _weapon;
		nint num = (nint)weapon3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+3F0]");
		bool flag2 = false;
		float num2 = weapon3.PArea();
		float endValue = (float)float5 * 0.7f;
		bool flag3 = _scaleTween == null;
		float? num3 = (float?)(object)0;
		if (!flag3)
		{
			TweenExtensions.Kill(_scaleTween);
			flag2 = false;
			num3 = (float?)(object)0;
		}
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.125f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj3 = "DefaultGameTweenId";
		_scaleTween = scaleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj4 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
			obj3 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v751 @ rax_v37 (should have been resolved before IL gen)");
		float2 float6 = default(float2);
		_cachedTransform.Rotate((Vector3)(&float6), Space.Self);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag4 = (nint)0 != 0;
		Transform cachedTransform = _cachedTransform;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
			cachedTransform = (Transform)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v781 @ rax_v41 (should have been resolved before IL gen)");
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		float duration = 250f * 0.001f;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&float6), duration, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
	}

	public override void InternalUpdate()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime + deltaTime;
		float num2 = num * -1f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_GravediggerRock)+D4]");
		float num4 = num3 + 0f;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		base.Despawn();
	}
}
