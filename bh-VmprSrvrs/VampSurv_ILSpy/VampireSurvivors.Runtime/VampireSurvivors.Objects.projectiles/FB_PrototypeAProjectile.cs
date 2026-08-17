using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PrototypeAProjectile : Projectile
{
	private float _offset;

	private float _offsetDist = 0.19999999f;

	private float2 _centralPos;

	private Vector3 _direction;

	private SpriteAnimation _anims;

	private float _wArea;

	private float _MaxAlpha = 0.75f;

	private float _AlphaDiff = 0.25f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("FB_BulletOrange1", "firstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("FB_BulletOrange", 1, 4, "firstBlood", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("FB_BulletBlue", 1, 4, "firstBlood", num);
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation anims = gameObject.AddComponent<SpriteAnimation>();
		_anims = anims;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anims.AddAnimation("Orange", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_anims.AddAnimation("Blue", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		float alphaDiff = 1f - _MaxAlpha;
		_AlphaDiff = alphaDiff;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02aa: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_02ec: Expected I4, but got O
		//IL_01dd: Expected O, but got I4
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_03fb: Expected O, but got F4
		//IL_0205: Expected F4, but got O
		//IL_020e: Invalid comparison between O and F4
		//IL_03b1: Expected O, but got I4
		//IL_036d->IL0281: Incompatible stack heights: 1 vs 0
		//IL_0157->IL0281: Incompatible stack heights: 1 vs 0
		//IL_0186->IL0281: Incompatible stack heights: 1 vs 0
		//IL_03b6->IL03c5: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		object obj;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			string animation;
			if (index != 0)
			{
				_offset = 90f / (float)Math.PI;
				if ((object)_anims == null)
				{
					goto IL_0281;
				}
				animation = "Orange";
			}
			else
			{
				_offset = 180f / (float)Math.PI;
				if ((object)_anims == null)
				{
					goto IL_0281;
				}
				animation = "Blue";
			}
			_anims.SetAnimation(animation);
			if ((int)base.AimForNearestEnemy() != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v20 (System.Int32)+10]");
				if ((nint)0 != 0)
				{
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						if (!weapon2.IsHoming)
						{
							goto IL_0195;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v20 (System.Int32)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v20 (System.Int32)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						Weapon weapon3 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
						{
							Transform transform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v41 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v41 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								obj = 0;
								goto IL_03c5;
							}
						}
					}
					goto IL_0281;
				}
			}
			goto IL_0195;
		}
		goto IL_0281;
		IL_03c5:
		Vector3 direction = default(Vector3);
		_direction = direction;
		Vector3 vector = (Vector3)(this + 224);
		Vector3 normalized = ((Vector3*)vector)->normalized;
		_direction = (Vector3)normalized.x;
		_ = normalized.z;
		float2 float5 = (_centralPos = base.position);
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			float alpha = _MaxAlpha;
			_wArea = (float)float5;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
			{
				float num2 = (float)float5 - 1f;
				float num3 = num2 / 5f;
				float num4 = 1f - num3;
				float num5 = num4 * _AlphaDiff;
				float num6 = num5 + _MaxAlpha;
				alpha = num6;
			}
			ArcadeSprite arcadeSprite2 = setAlpha(alpha);
			return;
		}
		goto IL_0281;
		IL_0195:
		if ((object)weapon == null || (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
		{
			goto IL_0281;
		}
		obj = 0;
		goto IL_03c5;
		IL_0281:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_00ad: Expected O, but got F4
		//IL_00d2: Expected I, but got O
		//IL_0200: Expected O, but got I4
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected I4, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_029e: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		float deltaTime = PauseSystem.DeltaTime;
		float2 float5 = default(float2);
		float num = (float)float5 * deltaTime;
		float num2 = (float)_direction * deltaTime;
		float num3 = _weapon.PSpeed();
		float num4 = num2 * deltaTime;
		float num5 = num * deltaTime;
		float num6 = num4 * 1.25f;
		float num7 = num5 * 1.25f;
		float num8 = (float)_centralPos + num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_PrototypeAProjectile)+DC]");
		float num9 = 0f + num7;
		_centralPos = (float2)num8;
		float deltaTime2 = PauseSystem.DeltaTime;
		Weapon weapon = _weapon;
		nint num10 = (nint)weapon;
		float num11 = weapon.PSpeed();
		float num12 = deltaTime2 * deltaTime2;
		float num13 = num12 + num12;
		float offset = num13 + _offset;
		_offset = offset;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		base.position = float5;
		bool flag = _indexInWeapon == 1;
		Weapon weapon2 = _weapon;
		float offset2;
		int num15;
		if (!flag)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			int num14 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.Depth;
			offset2 = _offset;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			num15 = num14;
			object obj = 0;
		}
		else
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			int num16 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.Depth;
			offset2 = _offset;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			num15 = num16;
			object obj = 0;
		}
		float num17 = offset2 * 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj2 = default(object);
		int num18 = obj2 + num15;
		ArcadeSprite arcadeSprite = setDepth(num18);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num19 = _offset * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num19 & 0;
		object obj4 = obj3 * _wArea;
		float xScale = (float)obj4 + 0.75f;
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		OnHasHitAnObjectLogic(target, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable target)
	{
		//IL_009c: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			int bounces = _bounces - 1;
			_bounces = bounces;
			BaseBody baseBody = body;
			float num = (float)baseBody._velocity * -1f;
			baseBody._velocity = (float2)num;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v7 (BaseBody)+74]");
			float num2 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
	{
		//IL_008b: Expected O, but got I4
		//IL_01b2: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		bool flag = !triggerHit;
		IDamageable damageable = target;
		Vector2 typeFromHandle = (Vector2)typeof(IDamageable);
		if (!flag)
		{
			bool flag2 = _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE);
			bool flag3 = !flag2;
			damageable = null;
			typeFromHandle = (Vector2)19;
			if (!flag3)
			{
				Weapon weapon = _weapon;
				GameManager gameMan = weapon._gameMan;
				float2 float5 = base.position;
				Vector2 vector = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(vector);
				damageable = null;
				typeFromHandle = vector;
			}
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				base.Despawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		BaseBody baseBody = body;
		float num = (float)baseBody._velocity * -1f;
		baseBody._velocity = (float2)num;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v8 (BaseBody)+74]");
		float num2 = 0f * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
