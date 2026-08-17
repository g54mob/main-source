using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.projectiles;

public class ReportProjectile : Projectile
{
	protected SpriteRenderer _visuals;

	protected SpriteAnimation _anim;

	private float2 _firingDirection;

	[NonSerialized]
	public float _life;

	protected float2 offset;

	protected bool visualInitalised;

	protected virtual bool followPlayerFacing => false;

	protected virtual void InitVisuals()
	{
		List<Sprite> frames = new List<Sprite>();
		Sprite sprite = SpriteManager.GetSprite("slash5", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("idle", frames, 16, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0588: Expected I, but got O
		//IL_05ac: Expected O, but got F4
		//IL_013f: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_01b9: Expected F4, but got O
		//IL_01d9: Expected O, but got Ref
		//IL_0228: Expected I, but got O
		//IL_0298: Expected O, but got I4
		//IL_02b3: Expected I, but got O
		//IL_0307: Expected I, but got O
		//IL_040b: Expected I, but got O
		//IL_0461: Expected O, but got I4
		//IL_0499: Expected O, but got I
		//IL_0535: Expected F4, but got I4
		//IL_0502: Expected O, but got I8
		base.InitProjectile(pool, weapon, index);
		if (!visualInitalised)
		{
			InitVisuals();
			visualInitalised = true;
		}
		nint num = (nint)this;
		_isCullable = false;
		if (!followPlayerFacing)
		{
			goto IL_0029;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v99 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		_ = 0;
		_firingDirection = characterController._lastMovementDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EB1B8Ah\"");
		if ((object)characterController._lastMovementDirection == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v99 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EB1B8Ah\"");
			if (flag)
			{
				goto IL_0029;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186252410");
		float num3 = default(float);
		float num2 = num3;
		goto IL_05a2;
		IL_05a2:
		_firingDirection = (float2)num2;
		BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		_life = 0f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_visuals, 0.65f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_visuals, 1f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_visuals, (float)_firingDirection);
		Transform transform = base.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		float num4 = _weapon.PDuration();
		float num5 = default(float);
		bool flag2 = num5 > 2f;
		float num6 = 2f;
		if (!flag2)
		{
			num6 = num5;
		}
		float duration = num6 * 400f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num7 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num8 = weapon.PArea();
			tweenConfig.duration = duration;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.projectiles.ReportProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num9 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num10 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value = default(object);
				bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_life", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary;
				tweenConfig2.duration = duration;
				tweenConfig2.ease = Ease.Linear;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				if ((object)_visuals != null)
				{
					nint num11 = (nint)array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				tweenConfig3.alpha = (float?)(object)1;
				tweenConfig3.duration = duration;
				tweenConfig3.ease = Ease.InCubic;
				MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag4 = (nint)0 != 0;
				TweenConfig tweenConfig4 = tweenConfig3;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj5 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
					tweenConfig4 = (TweenConfig)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1297 @ rax_v68 (should have been resolved before IL gen)");
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_ReportWeapon, 100f, 10, 0f, volume, rate, detune, loop, 1f);
				_anim.SetAnimation("idle");
				return;
			}
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			throw ex3;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
		IL_0029:
		if (((Equipment)weapon)._003COwner_003Ek__BackingField.flipX)
		{
			_ = 0;
			num2 = -1f;
		}
		else
		{
			_ = 0;
			num2 = 1f;
		}
		goto IL_05a2;
	}

	public override void InternalUpdate()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float num = _weapon.PSpeed();
		float2 float6 = default(float2);
		base.position = float6;
	}

	public ReportProjectile()
	{
		//IL_0017: Expected O, but got I4
		offset = (float2)0;
		_ = 1045220557;
		base._002Ector();
	}
}
