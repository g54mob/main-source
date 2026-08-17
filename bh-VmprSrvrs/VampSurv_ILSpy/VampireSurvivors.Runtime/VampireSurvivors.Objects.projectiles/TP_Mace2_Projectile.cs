using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Mace2_Projectile : Projectile
{
	private TrailRenderer _afterImageTrail;

	private float _angleTime;

	private Timer _swingTimer;

	private MultiTargetTween _alphaTween;

	private float _multiplier;

	private List<List<Projectile>> _swipeBodies;

	private float2 _playerOffset;

	private bool _isflipped;

	private int _flipNum;

	private float _extraDistTotal;

	private float _extraDistSpacing;

	protected bool _isCrit;

	private bool _isMoving;

	protected TP_Mace2_Weapon _trueWeapon;

	private Tween _despawnTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Mace2", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_afterImageTrail.emitting = false;
		Material material = ((Renderer)_afterImageTrail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_009f: Expected O, but got F4
		//IL_00cd: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(0f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.3f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 300f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Macir, soundConfig, 200f, 5, time);
	}

	public void SetCritical(bool isCritical)
	{
		//IL_0034: Expected I, but got O
		//IL_003c: Expected I, but got O
		//IL_004c: Expected O, but got I
		//IL_00cc: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0704: Expected O, but got I4
		//IL_0088: Expected O, but got I
		//IL_00e4: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_01d2: Expected I4, but got I8
		//IL_0220: Expected O, but got I4
		//IL_028c: Expected I4, but got O
		//IL_02ee: Expected I, but got O
		//IL_02d2: Expected I, but got O
		//IL_0731: Expected O, but got I4
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		//IL_0423: Expected I4, but got O
		//IL_0575: Expected F4, but got O
		//IL_05c5: Expected F4, but got I4
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Expected O, but got Unknown
		//IL_0673: Expected I4, but got O
		_isCrit = isCritical;
		_isCullable = false;
		bool flag = !isCritical;
		uint tint = 16777215u;
		if (!flag)
		{
			tint = 16737894u;
		}
		ArcadeSprite arcadeSprite = setTint(tint);
		Weapon weapon = _weapon;
		TP_Mace2_Weapon trueWeapon;
		float? num;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			num = (float?)(object)0;
			goto IL_06d8;
		}
		nint num2 = (nint)typeof(TP_Mace2_Weapon);
		nint num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace2_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v89+FFFFFFF8+v79 @ rax_v84*8]");
			if (0 == (nint)typeof(TP_Mace2_Weapon))
			{
				obj3 = 1;
				goto IL_06e7;
			}
		}
		obj3 = 0;
		goto IL_06e7;
		IL_06d8:
		_trueWeapon = trueWeapon;
		TP_Mace2_Weapon trueWeapon2 = _trueWeapon;
		Weapon weapon2 = _weapon;
		ArcadeSprite arcadeSprite2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)weapon2)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 vector = arcadeSprite2._spriteRenderer.size;
		object obj4 = default(object);
		float num5 = (float)obj4 * 0.5f;
		Weapon weapon3 = _weapon;
		_playerOffset = (float2)num;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
		_isflipped = characterController._isFlipped;
		Weapon weapon4 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
		bool flag2 = characterController2._isFlipped;
		int flipNum = -1;
		if (!flag2)
		{
			flipNum = 1;
		}
		_flipNum = flipNum;
		float num6 = _weapon.PArea();
		float num7 = num5 * 0.9f;
		object obj5 = trueWeapon2.ExtraBodyAmount + 1;
		List<List<Projectile>> swipeBodies = _swipeBodies;
		_extraDistTotal = num7;
		float xScale = (_extraDistSpacing = num7 / (float)obj5);
		int num8 = swipeBodies._size;
		int version = swipeBodies._version + 1;
		swipeBodies._version = version;
		swipeBodies._size = (int)num;
		if (swipeBodies._size > 0)
		{
			Array.Clear(swipeBodies._items, 0, swipeBodies._size);
			num3 = unchecked((nint)null);
		}
		Weapon weapon5 = _weapon;
		nint num9 = (nint)weapon5;
		float num10 = weapon5.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj6 = default(object);
		bool flag3 = (nint)obj6 <= 0;
		float? num11 = num;
		bool flag5 = default(bool);
		bool flag4 = flag5;
		if (!flag3)
		{
			bool flag8;
			do
			{
				List<Projectile> list = new List<Projectile>();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AABF00");
				bool flag6 = trueWeapon2.ExtraBodyAmount < 0;
				float? num12 = num;
				flag5 = flag4;
				if (!flag6)
				{
					bool flag7;
					do
					{
						TP_Mace2_Weapon trueWeapon3;
						Projectile projectile;
						int index;
						if ((object)num11 == null && (object)num12 == null)
						{
							trueWeapon3 = _trueWeapon;
							if ((_isCrit ? 1 : 0) != (nint)num12)
							{
								projectile = _trueWeapon.CreateCriticalProjectile(0);
								num8 = 0;
								goto IL_0768;
							}
							index = 0;
						}
						else
						{
							trueWeapon3 = _trueWeapon;
							index = (int)num12;
						}
						projectile = trueWeapon3.CreateStandardProjectile(index);
						num8 = 0;
						goto IL_0768;
						IL_0768:
						if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A10");
						}
						num12 = (float?)(object)((_003F?)num12 + 1);
						flag7 = (nint)num12 <= trueWeapon2.ExtraBodyAmount;
						flag5 = flag4;
					}
					while (flag7);
				}
				num11 = (float?)(object)((_003F?)num11 + 1);
				flag8 = System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num11) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
				flag4 = flag5;
			}
			while (flag8);
		}
		ArcadeSprite arcadeSprite3 = setOrigin(0.5f, (float?)(object)1);
		Weapon weapon6 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)weapon6)._003COwner_003Ek__BackingField;
		ArcadeSprite arcadeSprite4 = setFlipX(characterController3._isFlipped);
		float num13 = _weapon.PArea();
		ArcadeSprite arcadeSprite5 = setScale(xScale, num);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num14 = renderer.pixelHeight - 1;
		ArcadeSprite arcadeSprite6 = setDepth(num14);
		Weapon weapon7 = _weapon;
		_multiplier = (float)num;
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)weapon7)._003COwner_003Ek__BackingField;
		float num15 = ((!characterController4._isFlipped) ? 0f : 180f);
		updateAttackAngle(_angleTime = num15 * ((float)Math.PI / 180f));
		SetupTrails(_afterImageTrail);
		_afterImageTrail.emitting = true;
		Material material = ((Renderer)_afterImageTrail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 1f);
		if (_swingTimer != null)
		{
			_swingTimer.Cancel();
		}
		Action onComplete = LandHit;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer swingTimer = Timers.Register(1.6f, onComplete, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)(int)num != 0);
		_swingTimer = swingTimer;
		ArcadeSprite arcadeSprite7 = setAlpha(1f);
		_isMoving = true;
		return;
		IL_06e7:
		bool flag9 = obj3 == null;
		trueWeapon = null;
		num = (float?)(object)0;
		if (!flag9)
		{
			trueWeapon = (TP_Mace2_Weapon)_weapon;
			num = (float?)(object)0;
		}
		goto IL_06d8;
	}

	public override void InternalUpdate()
	{
		if (_isMoving)
		{
			float num = _weapon.PSpeed();
			object obj = default(object);
			float num2 = (float)obj + _multiplier;
			bool flag = !(5f > num2);
			float multiplier = 5f;
			if (!flag)
			{
				multiplier = num2;
			}
			_multiplier = multiplier;
			float deltaTime = PauseSystem.DeltaTime;
			float num3 = _weapon.PSpeed();
			float num4 = deltaTime * deltaTime;
			float num5 = num4 * _multiplier;
			updateAttackAngle(_angleTime = num5 + _angleTime);
		}
	}

	private unsafe void updateAttackAngle(float attackAngle)
	{
		//IL_0061: Expected F4, but got I4
		//IL_0086: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_0295->IL0363: Incompatible stack heights: 7 vs 2
		//IL_0255->IL033f: Incompatible stack heights: 7 vs 6
		Transform cachedTransform = _cachedTransform;
		float2 euler = default(float2);
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
		nint cachedPtr = ((UnityEngine.Object)cachedTransform).m_CachedPtr;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		object obj = default(object);
		float num = (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Mace2_Projectile)+104]");
		float num2 = num + 0f;
		float2 float6 = default(float2);
		base.position = float6;
		bool flag2 = !_isflipped;
		float num3 = 0f;
		if (!flag2)
		{
			num3 = 180f;
		}
		List<List<Projectile>> swipeBodies = _swipeBodies;
		bool flag3 = _swipeBodies == null;
		object obj2 = 0;
		object obj3 = 0;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		while ((nint)obj3 < swipeBodies._size)
		{
			float num4 = num3 * ((float)Math.PI / 180f);
			float num5 = (float)obj2 * (-(float)Math.PI / 12f);
			float num6 = num5 + attackAngle;
			if (!(num4 > num6))
			{
				num4 = num6;
			}
			List<List<Projectile>> swipeBodies2 = _swipeBodies;
			bool flag4 = _swipeBodies == null;
			bool flag5 = (nint)obj2 >= swipeBodies2._size;
			List<Projectile>[] items = swipeBodies2._items;
			bool flag6 = swipeBodies2._items == null;
			bool flag7 = (nint)obj2 >= items.Length;
			List<Projectile> list = items[obj2];
			if (items[obj2] != null)
			{
				for (cachedPtr = 0; cachedPtr < list._size; cachedPtr++)
				{
					object obj4 = cachedPtr * _extraDistSpacing;
					float num7 = _extraDistTotal - (float)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					float2 float7 = base.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num8 = num4 * num7;
					float num9 = num8 * (float)_flipNum;
					num2 = (float)obj + num9;
					bool flag8 = (object)arcadeSprite == null;
					arcadeSprite.position = float6;
				}
			}
			swipeBodies = _swipeBodies;
			obj2++;
			bool flag9 = _swipeBodies == null;
			obj3 = obj2;
		}
	}

	private unsafe void LandHit()
	{
		//IL_028e: Expected O, but got F4
		//IL_02bc: Expected O, but got I4
		//IL_00a8: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_016e: Expected O, but got I4
		//IL_02e5: Expected O, but got Ref
		//IL_0224: Expected I, but got O
		//IL_00cb->IL00cb: Incompatible stack heights: 1 vs 0
		//IL_0131->IL0131: Incompatible stack heights: 1 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 500f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Mace, soundConfig, 200f, 5, time);
		_isMoving = false;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_renderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Material material = ((Renderer)_afterImageTrail).GetMaterial();
		if ((object)material != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_despawnTimer != null)
		{
			TweenExtensions.Kill(_despawnTimer);
		}
		Transform target = base.transform;
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> despawnTimer = ShortcutExtensions.DOLocalMove(target, (Vector3)(&vector), 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Mace2_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num4 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rax_v39 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		_despawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		//IL_001e: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		if (_despawnTimer != null)
		{
			TweenExtensions.Kill(_despawnTimer);
			object obj = 0;
		}
		if (_swingTimer != null)
		{
			_swingTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		List<List<Projectile>> swipeBodies = _swipeBodies;
		object obj2 = 0;
		object obj3 = 0;
		object obj6 = default(object);
		while ((nint)obj3 < swipeBodies._size)
		{
			object obj4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				swipeBodies = _swipeBodies;
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v13+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				object obj = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v110 @ r8_v5+368] (should have been resolved before IL gen)");
				obj4++;
			}
			obj2++;
			obj3 = obj2;
		}
		_afterImageTrail.Clear();
		_afterImageTrail.emitting = false;
		base.Despawn();
	}

	private void SetupTrails(TrailRenderer _trail)
	{
		//IL_0128: Expected I4, but got F4
		//IL_0189->IL020d: Incompatible stack heights: 4 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PAmount();
			object obj = default(object);
			float time = (float)obj * 0.15f;
			float saturationMax = default(float);
			float valueMin = default(float);
			float valueMax = default(float);
			float alphaMin = default(float);
			Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.35f, saturationMax, valueMin, valueMax, alphaMin, 0.35f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Weapon weapon = _weapon;
			float num2 = weapon.PArea();
			float num3 = 0.8f * 0.2f;
			Transform transform = _trail.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			_trail.time = time;
			_trail.endWidth = num3;
			_trail.startWidth = num3;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_trail, sprite, true);
			Material material = ((Renderer)_trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			bool flag2 = ((UnityEngine.Object)_trail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)_trail).m_CachedPtr);
			Gradient gradient = new Gradient();
			IntPtr ptr = Gradient.Init();
			gradient.m_Ptr = ptr;
			gradient.m_RequiresNativeCleanup = true;
			GradientColorKey[] array = new GradientColorKey[2];
			bool flag3 = (nint)((MonoBehaviour)(object)array).m_CancellationTokenSource <= 0;
			((GameMonoBehaviour)(object)array)._onPauseSent = (byte)(int)color.r != 0;
			((PhaserGameObject)(object)array)._scene = null;
			bool flag4 = (nint)((MonoBehaviour)(object)array).m_CancellationTokenSource <= 1;
			_ = color.r;
			_ = 0.5f;
			GradientAlphaKey[] array2 = new GradientAlphaKey[2];
			if (array2 != null)
			{
				bool flag5 = array2.Length <= 0;
				_ = 1056964608;
				bool flag6 = array2.Length <= 1;
				_ = 0;
				_ = 1056964608;
				gradient.SetKeys(array, array2);
				_trail.colorGradient = gradient;
				TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public TP_Mace2_Projectile()
	{
		List<List<Projectile>> swipeBodies = new List<List<Projectile>>();
		_swipeBodies = swipeBodies;
		base._002Ector();
	}
}
