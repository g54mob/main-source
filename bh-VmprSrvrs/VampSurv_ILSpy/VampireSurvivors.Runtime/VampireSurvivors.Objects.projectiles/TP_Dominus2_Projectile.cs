using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Dominus2_Projectile : Projectile
{
	private float _radius = 8f;

	private PhaserSprite _animatedSprite;

	private bool _isDespawning;

	private bool _hasHitBottom;

	private string idle = "idle";

	private string burst = "burst";

	private string idleInverse = "idleInverse";

	private string burstInverse = "burstInverse";

	private bool inverted;

	private TP_Dominus2_Weapon _trueWeapon;

	protected override void Awake()
	{
		//IL_00d9: Expected O, but got I4
		//IL_00d9: Expected I4, but got O
		//IL_0142: Expected O, but got I4
		//IL_0142: Expected I4, but got O
		//IL_01ab: Expected O, but got I4
		//IL_01ab: Expected I4, but got O
		//IL_0214: Expected O, but got I4
		//IL_0214: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Hatred01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Hatred", 1, 6, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation(idle, animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Hatred", 7, 10, vector, text, num, flag);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.AddAnimation(burst, animationFrames2, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_HatredInv", 1, 6, vector, text, num, flag);
		PhaserSprite animatedSprite4 = _animatedSprite;
		animatedSprite4._spriteAnimation.AddAnimation(idleInverse, animationFrames3, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_HatredInv", 7, 10, vector, text, num, flag);
		PhaserSprite animatedSprite5 = _animatedSprite;
		animatedSprite5._spriteAnimation.AddAnimation(burstInverse, animationFrames4, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite6 = _animatedSprite;
		animatedSprite6._spriteAnimation.SetAnimation(idle);
	}

	public void Invert(bool value)
	{
		inverted = value;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0188: Expected O, but got I4
		//IL_0188: Expected O, but got I4
		//IL_01a5: Expected O, but got I4
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_026a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_02ae;
		}
		nint num = (nint)typeof(TP_Dominus2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v56+FFFFFFF8+v66 @ rax_v51*8]");
			if (0 == (nint)typeof(TP_Dominus2_Weapon))
			{
				obj3 = 1;
				goto IL_02bd;
			}
		}
		obj3 = 0;
		goto IL_02bd;
		IL_02bd:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_02ae;
		IL_02ae:
		_trueWeapon = (TP_Dominus2_Weapon)trueWeapon;
		TP_Dominus2_Weapon trueWeapon2 = _trueWeapon;
		inverted = trueWeapon2._003CInverted_003Ek__BackingField;
		_isCullable = false;
		_isDespawning = false;
		_speed = 1.5f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		float num4 = _weapon.PArea();
		float num5 = default(float);
		float radius = num5 * _radius;
		BaseBody baseBody2 = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		PhaserSprite phaserSprite = _animatedSprite.setScale(num5, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		string animation = ((!inverted) ? idle : idleInverse);
		animatedSprite._spriteAnimation.SetAnimation(animation);
		Transform transform = _animatedSprite.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		float projectileSpeed = base.ProjectileSpeed;
		object obj4 = Vector3.zeroVector ^ -0f;
		BaseBody baseBody3 = body;
		baseBody3._velocity = (float2)0;
	}

	private void LateUpdate()
	{
		//IL_0146: Invalid comparison between F4 and O
		//IL_01c4->IL0169: Incompatible stack heights: 1 vs 0
		//IL_00e6->IL0169: Incompatible stack heights: 1 vs 0
		//IL_0115->IL0169: Incompatible stack heights: 1 vs 0
		if ((object)_animatedSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
			float2 float5 = base.position;
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							ArcadeBodyBounds worldBoxCollider = characterController._worldBoxCollider;
							if (characterController._worldBoxCollider != null)
							{
								float num = worldBoxCollider.height * 0.5f;
								object obj = default(object);
								float num2 = (float)obj - num;
								object obj2 = default(object);
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
								{
									OnHittingScreenBottom();
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnHittingScreenBottom()
	{
		//IL_0029: Expected O, but got I4
		//IL_00a7: Expected I, but got O
		if (!_hasHitBottom)
		{
			_hasHitBottom = true;
			BaseBody baseBody = body;
			_ = 0;
			baseBody._velocity = (float2)0;
			PhaserSprite animatedSprite = _animatedSprite;
			string animation = ((!inverted) ? burst : burstInverse);
			animatedSprite._spriteAnimation.SetAnimation(animation);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus2_Projectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public override void Despawn()
	{
		if (!_isDespawning)
		{
			_isDespawning = true;
			if ((object)_animatedSprite != null)
			{
				PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
			}
			base.Despawn();
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			OnHittingScreenBottom();
		}
	}
}
