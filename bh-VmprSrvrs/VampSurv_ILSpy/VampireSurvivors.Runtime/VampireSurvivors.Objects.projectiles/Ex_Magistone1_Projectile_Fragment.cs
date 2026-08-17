using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class Ex_Magistone1_Projectile_Fragment : Projectile
{
	private List<MeshRenderer> _FragmentMeshes;

	private GameObject _MeshContainer;

	private SpriteRenderer _ShadowSprite;

	private const float Radius = 56f;

	private const float Gravity = 6.25f;

	private const float MinInitialSpeed = 2.5f;

	private const float MaxInitialSpeed = 3.5f;

	private const float ExtraSpeedForEvo = 1f;

	private const float BouncePosYVarianceLimit = 0.25f;

	private Ex_Magistone1_Weapon _trueWeapon;

	private MeshRenderer _fragmentMesh;

	private Vector2 _velocity;

	private float _initialSpeed;

	private int _flipSwitch;

	private float _bouncePosY;

	private float _bouncePosYVariance;

	private bool _hasBounced;

	private bool _isDespawning;

	private Vector3 _rotationEulers;

	private float _scaleMultiplier;

	private Tween _fadeTween;

	private Tween _scaleTween;

	private Tween _shadowFadeTween;

	private Tween _shadowScaleTween;

	public bool HasBounced => _hasBounced;

	protected override void Awake()
	{
		//IL_017e->IL0102: Incompatible stack heights: 1 vs 0
		//IL_0095->IL0102: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL0102: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL0102: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4B63]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Awake();
		if ((object)_ShadowSprite != null)
		{
			Transform transform = _ShadowSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)_ShadowSprite != null)
				{
					GameObject gameObject = _ShadowSprite.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						if ((object)_ShadowSprite != null)
						{
							GameObject gameObject2 = _ShadowSprite.gameObject;
							if ((object)gameObject2 != null)
							{
								((UnityEngine.Object)gameObject2).SetName("Ex_Magistone_Fragment_Shadow");
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0036: Expected I, but got O
		//IL_003e: Expected I, but got O
		//IL_004e: Expected O, but got I
		//IL_00ce: Expected O, but got I4
		//IL_008a: Expected O, but got I
		//IL_00c0: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0158: Expected I4, but got I8
		//IL_02bc: Expected I4, but got I8
		//IL_0375: Expected O, but got I
		//IL_0398: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected I4, but got Unknown
		//IL_02e4: Expected O, but got I
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		//IL_01ee: Expected O, but got I8
		//IL_022c: Expected O, but got I8
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		Ex_Magistone1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_026f;
		}
		nint num = (nint)typeof(Ex_Magistone1_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v41+FFFFFFF8+v69 @ rax_v36*8]");
			if (0 == (nint)typeof(Ex_Magistone1_Weapon))
			{
				obj3 = 1;
				goto IL_027e;
			}
		}
		obj3 = 0;
		goto IL_027e;
		IL_027e:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (Ex_Magistone1_Weapon)_weapon;
		}
		goto IL_026f;
		IL_026f:
		_trueWeapon = trueWeapon;
		_isCullable = false;
		_scaleMultiplier = 0f;
		SetScaleToArea(0f);
		BaseBody baseBody = body.setCircle(56f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		int num4 = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)baseBody2 < 0)
		{
			object obj4 = num4 - 1;
			object obj5 = obj4 | -2;
			num4 = obj5 + 1;
		}
		bool flag2 = num4 == 1;
		int flipSwitch = -1;
		if (!flag2)
		{
			flipSwitch = 1;
		}
		_flipSwitch = flipSwitch;
		_hasBounced = false;
		InitVelocity();
		float num5 = _bouncePosYVariance * 4f;
		float deltaTime = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		object obj7 = 0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj6 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			obj7 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v423 @ rax_v22 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj8 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			obj7 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v451 @ rax_v25 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj9 = num5 & 0;
		float num6 = 1f - (float)obj9;
		float num7 = num6 * -180f;
		float num8 = num7 * (float)_flipSwitch;
		float num9 = deltaTime * num8;
		Vector3 rotationEulers = default(Vector3);
		_rotationEulers = rotationEulers;
		InitShadow();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0154: Expected O, but got F4
		//IL_014a: Expected O, but got Ref
		//IL_00c7: Invalid comparison between O and F4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 6.25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
		float num2 = 0f - num;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		if (!_hasBounced)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
			if ((nint)0 <= (nint)0)
			{
				float2 float5 = base.position;
				object obj = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_bouncePosY))
				{
					_hasBounced = true;
					float2 float6 = base.position;
					float2 float7 = default(float2);
					base.position = float7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v8 (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
					float num3 = 0f * -0.5f;
					FadeOut();
				}
			}
		}
		UpdateShadow();
		object obj2 = Time.timeScale;
		Vector3 vector = default(Vector3);
		_cachedTransform.Rotate((Vector3)(&vector), Space.Self);
	}

	private void InitVelocity()
	{
		//IL_0010: Expected O, but got I
		//IL_027e: Expected O, but got I4
		//IL_00e2: Invalid comparison between I4 and F4
		//IL_00f4: Expected F4, but got I4
		//IL_0076: Expected O, but got I8
		//IL_0137: Invalid comparison between I4 and F4
		//IL_0149: Expected F4, but got I4
		//IL_0389: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		Ex_Magistone1_Projectile_Fragment ex_Magistone1_Projectile_Fragment = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			ex_Magistone1_Projectile_Fragment = (Ex_Magistone1_Projectile_Fragment)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v5 (should have been resolved before IL gen)");
		Ex_Magistone1_Weapon trueWeapon = _trueWeapon;
		bool flag2 = !trueWeapon._OverrideFragmentBounceY;
		float bouncePosYVariance = -0.25f;
		if (!flag2)
		{
			bouncePosYVariance = trueWeapon._FragmentBounceY;
		}
		_bouncePosYVariance = bouncePosYVariance;
		float2 float5 = base.position;
		object obj2 = default(object);
		float bouncePosY = (float)obj2 + _bouncePosYVariance;
		_bouncePosY = bouncePosY;
		object obj3 = _indexInWeapon + _indexInWeapon;
		float num = (float)obj3 + 4f;
		float num2 = num * (float)_flipSwitch;
		float num3 = 90f - num2;
		float num4 = num3 * ((float)Math.PI / 180f);
		float num5 = _weapon.PSpeed();
		float num6 = (float)_flipSwitch - 1f;
		bool flag3 = !(0f < num6);
		float num7 = 0f;
		if (!flag3)
		{
			num7 = num6;
		}
		float num8 = _weapon.PSpeed();
		float num9 = num6 - 1f;
		bool flag4 = !(0f < num9);
		float num10 = 0f;
		if (!flag4)
		{
			num10 = num9;
		}
		float num11 = num10 * 0.5f;
		float num12 = num7 * 0.25f;
		float maxInclusive = num11 + 3.5f;
		float minInclusive = num12 + 2.5f;
		float num13 = UnityEngine.Random.Range(minInclusive, maxInclusive);
		Weapon weapon = _weapon;
		object obj4 = ((Equipment)weapon)._currentJsonDataObject.ToObject<object>();
		bool flag5 = obj4 == null;
		float num14 = num13;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v16 (System.Object)+60]");
			bool flag6 = (nint)0 == 0;
			num14 = num13;
			if (!flag6)
			{
				num14 = num13 + 1f;
			}
		}
		Ex_Magistone1_Weapon trueWeapon2 = _trueWeapon;
		if (trueWeapon2._OverrideFragmentSpeed)
		{
			num14 = trueWeapon2._FragmentSpeed;
		}
		_initialSpeed = num14;
		WeaponData weaponData = ((Equipment)weapon)._currentJsonDataObject.ToObject<WeaponData>();
		float num15 = num4 * num14;
		WeaponData weaponData2 = ((Equipment)weapon)._currentJsonDataObject.ToObject<WeaponData>();
		float num16 = num4 * num14;
		_velocity = (Vector2)num15;
	}

	private void UpdateVelocity()
	{
		//IL_00c5: Invalid comparison between O and F4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 6.25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
		float num2 = 0f - num;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		if (!_hasBounced)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
			if ((nint)0 <= (nint)0)
			{
				float2 float5 = base.position;
				object obj = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_bouncePosY))
				{
					_hasBounced = true;
					float2 float6 = base.position;
					float2 float7 = default(float2);
					base.position = float7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
					float num3 = 0f * -0.5f;
					FadeOut();
				}
			}
		}
		UpdateShadow();
	}

	private unsafe void UpdateRotation()
	{
		//IL_0023: Expected O, but got F4
		//IL_0019: Expected O, but got Ref
		object obj = Time.timeScale;
		Vector3 vector = default(Vector3);
		_cachedTransform.Rotate((Vector3)(&vector), Space.Self);
	}

	private void InitShadow()
	{
		//IL_028b->IL018d: Incompatible stack heights: 5 vs 0
		if ((object)_trueWeapon != null && (object)_ShadowSprite != null)
		{
			GameObject gameObject = _ShadowSprite.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ShadowSprite, 0f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_ShadowSprite, 0f);
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v8 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v8 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					bool flag2 = (object)_weapon == null;
					float num = _weapon.PArea();
					bool flag3 = (object)_ShadowSprite == null;
					Transform transform = _ShadowSprite.transform;
					bool flag4 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v28 (UnityEngine.Transform)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v28 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)0, ref value);
					float scaledAlpha = GetScaledAlpha();
					float endValue = scaledAlpha * 0.4f;
					if (_shadowFadeTween != null)
					{
						DG.Tweening.TweenExtensions.Kill(_shadowFadeTween);
					}
					TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ShadowSprite, endValue, 0.25f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore != null)
					{
						_shadowFadeTween = tweenerCore;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateShadow()
	{
		//IL_010b->IL00b0: Incompatible stack heights: 1 vs 0
		if ((object)_trueWeapon != null && (object)_ShadowSprite != null)
		{
			Transform transform = _ShadowSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					float deltaTime = PauseSystem.DeltaTime;
					bool flag3 = (object)_ShadowSprite == null;
					Transform transform2 = _ShadowSprite.transform;
					bool flag4 = (object)transform2 == null;
					bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void InitRotation()
	{
		//IL_002b: Expected O, but got I
		//IL_004e: Expected O, but got I4
		//IL_010b: Expected O, but got I
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0095: Expected O, but got I8
		//IL_00d3: Expected O, but got I8
		float num = _bouncePosYVariance * 4f;
		float deltaTime = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		object obj2 = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			obj2 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53 @ rax_v5 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			obj2 = 6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v96 @ rax_v8 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num & 0;
		float num2 = 1f - (float)obj4;
		float num3 = num2 * -180f;
		float num4 = num3 * (float)_flipSwitch;
		float num5 = num4 * deltaTime;
		Vector3 rotationEulers = default(Vector3);
		_rotationEulers = rotationEulers;
	}

	private void CheckForBounce()
	{
		//IL_005b: Invalid comparison between O and F4
		if (_hasBounced)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
		if ((nint)0 <= (nint)0)
		{
			float2 float5 = base.position;
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_bouncePosY))
			{
				_hasBounced = true;
				float2 float6 = base.position;
				float2 float7 = default(float2);
				base.position = float7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment)+FC]");
				float num = 0f * -0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x18726FDF0\"");
			}
		}
	}

	private void FadeOut()
	{
		//IL_008a: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_fadeTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_fadeTween);
		}
		Material material = ((Renderer)_fragmentMesh).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_fadeTween = tweenerCore;
		if (_shadowFadeTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_shadowFadeTween);
		}
		TweenerCore<Color, Color, ColorOptions> gameId = DOTweenModuleSprite.DOFade(_ShadowSprite, 0f, 0.25f);
		Tween shadowFadeTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
		_shadowFadeTween = shadowFadeTween;
	}

	public unsafe void SetupFragmentMesh(int index, uint tint)
	{
		//IL_021b: Expected O, but got Ref
		//IL_0237: Expected O, but got Ref
		//IL_0090: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_04c9: Expected I, but got O
		//IL_00c7: Expected O, but got I
		//IL_014e: Expected O, but got I
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		//IL_0194: Expected O, but got I
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_01cc: Expected O, but got I
		//IL_035e: Expected O, but got Ref
		//IL_0604->IL044a: Incompatible stack heights: 1 vs 0
		//IL_02bc->IL044a: Incompatible stack heights: 2 vs 0
		//IL_031a->IL044a: Incompatible stack heights: 3 vs 0
		//IL_065e->IL044a: Incompatible stack heights: 4 vs 0
		//IL_06b8->IL044a: Incompatible stack heights: 5 vs 0
		//IL_05e0->IL085e: Incompatible stack heights: 9 vs 0
		//IL_0718->IL044a: Incompatible stack heights: 6 vs 0
		//IL_0778->IL044a: Incompatible stack heights: 7 vs 0
		//IL_07f8->IL044a: Incompatible stack heights: 8 vs 0
		//IL_0382->IL044a: Incompatible stack heights: 8 vs 0
		//IL_0854->IL044a: Incompatible stack heights: 9 vs 0
		if ((object)_MeshContainer != null)
		{
			Transform transform = _MeshContainer.transform;
			if ((object)transform != null)
			{
				IEnumerator enumerator = transform.GetEnumerator();
				object obj = null;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj14 = default(object);
				object obj15 = default(object);
				while (true)
				{
					bool flag = obj2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj3 == null)
					{
						break;
					}
					bool flag2 = obj2 == null;
					nint num = (nint)obj2;
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r10_v29 (Il2CppClass<System.Object>)+12E]");
					if ((nint)obj4 >= 0)
					{
						goto IL_0106;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r10_v29 (Il2CppClass<System.Object>)+B0]");
					object obj5 = 0;
					object obj6 = obj;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ r8_v37+v827 @ rax_v161*8]");
						if (0 == (nint)typeof(IEnumerator))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ r10_v29 (Il2CppClass<System.Object>)+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_0106;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ r8_v37+8+v1029 @ rcx_v142*8]");
					object obj10 = (nint)0 + (nint)1;
					object obj11 = obj10 << 4;
					object obj12 = obj11 + 312;
					object obj13 = obj12 + num;
					goto IL_04b1;
					IL_0106:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj5 = 1;
					obj13 = obj14;
					goto IL_04b1;
					IL_04b1:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1036 @ rdx_v67] (should have been resolved before IL gen)");
					nint num2 = (nint)typeof(Transform);
					if (obj15 != null)
					{
						nint num3 = (nint)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v69 (Il2CppClass<UnityEngine.Transform>)+130]");
						object obj16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ r8_v38 (Il2CppClass<System.Object>)+130]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v69 (Il2CppClass<UnityEngine.Transform>)+130]");
						bool flag3 = num4 < 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ r8_v38 (Il2CppClass<System.Object>)+C8]");
						object obj17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ rax_v135+FFFFFFF8+v1226 @ rax_v134*8]");
						bool flag4 = 0 != (nint)typeof(Transform);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v133 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v133 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						bool flag6 = (object)gameObject == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rax_v140 (UnityEngine.GameObject)+10]");
						bool flag7 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rax_v140 (UnityEngine.GameObject)+10]");
						GameObject.SetActive_Injected((IntPtr)0, false);
						MeshRenderer component = ((Component)obj15).GetComponent<MeshRenderer>();
						bool flag8 = (object)component == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v145 (UnityEngine.MeshRenderer)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rax_v145 (UnityEngine.MeshRenderer)+10]");
						Renderer.set_enabled_Injected((IntPtr)0, false);
						obj = null;
						continue;
					}
					throw new NullReferenceException();
				}
				object obj18 = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				object obj19 = (object)(&obj2);
				object obj20 = default(object);
				obj19 = obj20;
				if (obj20 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				List<MeshRenderer> fragmentMeshes = _FragmentMeshes;
				if (_FragmentMeshes != null)
				{
					bool flag10 = index >= fragmentMeshes._size;
					MeshRenderer[] items = fragmentMeshes._items;
					if (fragmentMeshes._items != null)
					{
						bool flag11 = index >= items.Length;
						_fragmentMesh = items[index];
						GameObject fragmentMesh = (GameObject)(object)_fragmentMesh;
						if ((object)_fragmentMesh != null)
						{
							bool flag12 = ((UnityEngine.Object)fragmentMesh).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)fragmentMesh).m_CachedPtr);
							GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							if ((object)gameObject2 != null)
							{
								bool flag13 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
								GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, true);
								object fragmentMesh2 = _fragmentMesh;
								if ((object)_fragmentMesh != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v31 (System.Object)+10]");
									bool flag14 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v31 (System.Object)+10]");
									Renderer.set_enabled_Injected((IntPtr)0, true);
									object fragmentMesh3 = _fragmentMesh;
									if ((object)_fragmentMesh != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v32 (System.Object)+10]");
										bool flag15 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v32 (System.Object)+10]");
										Renderer.set_sortingOrder_Injected((IntPtr)0, 2000);
										object fragmentMesh4 = _fragmentMesh;
										if ((object)_fragmentMesh != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v33 (System.Object)+10]");
											bool flag16 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v33 (System.Object)+10]");
											IntPtr material_Injected = Renderer.GetMaterial_Injected((IntPtr)0);
											Material material = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
											int num5 = (int)tint >> 16;
											float num6 = (float)num5 / 255f;
											if ((object)material != null)
											{
												float num7 = default(float);
												material.color = (Color)(&num7);
												GameObject fragmentMesh5 = (GameObject)(object)_fragmentMesh;
												if ((object)_fragmentMesh != null)
												{
													bool flag17 = ((UnityEngine.Object)fragmentMesh5).m_CachedPtr == (IntPtr)0;
													IntPtr material_Injected2 = Renderer.GetMaterial_Injected(((UnityEngine.Object)fragmentMesh5).m_CachedPtr);
													Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected2);
													if ((object)_weapon != null)
													{
														float num8 = _weapon.PArea();
														bool flag18 = !(1f < num6);
														float alpha = 1f;
														if (!flag18)
														{
															if (num6 < 4f)
															{
																float num9 = num6 - 1f;
																float num10 = num9 * 0.6f;
																float num11 = num10 / 3f;
																alpha = 1f - num11;
															}
															else
															{
																alpha = 0.4f;
															}
														}
														RenderingExtensions.SetAlpha(material2, alpha);
														return;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetFragmentScale(float scaleMultiplier)
	{
		//IL_0191: Invalid comparison between F4 and I4
		//IL_01ea: Invalid comparison between I4 and F4
		//IL_004f: Expected O, but got Ref
		SetScaleToArea(scaleMultiplier);
		_scaleMultiplier = scaleMultiplier;
		bool flag = !(_bouncePosYVariance > 0f);
		float num = 1f;
		if (!flag)
		{
			num = 0.5714286f;
		}
		if (0f > _bouncePosYVariance)
		{
			num = 1.25f;
		}
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = scaleTween;
		float num2 = _weapon.PArea();
		float num3 = _bouncePosYVariance * _scaleMultiplier;
		float num4 = num3 * 0.7f;
		float yScale = num4 * 0.2f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ShadowSprite, num4, yScale);
		float endValue = num4 * num;
		if (_shadowScaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_shadowScaleTween);
		}
		Transform target = _ShadowSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> shadowScaleTween = ShortcutExtensions.DOScaleX(target, endValue, 3f);
		_shadowScaleTween = shadowScaleTween;
	}

	private float GetScaledAlpha()
	{
		//IL_0018: Invalid comparison between F4 and O
		//IL_0041: Invalid comparison between O and F4
		float num = _weapon.PArea();
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float result = 1f;
		if (!flag)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)4f))
			{
				return 0.4f;
			}
			float num2 = (float)obj - 1f;
			float num3 = num2 * 0.6f;
			float num4 = num3 / 3f;
			result = 1f - num4;
		}
		return result;
	}

	public override void Despawn()
	{
		if ((object)_ShadowSprite != null)
		{
			_ShadowSprite.gameObject?.SetActive(value: false);
		}
		if (_fadeTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_fadeTween);
		}
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		if (_shadowFadeTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_shadowFadeTween);
		}
		if (_shadowScaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_shadowScaleTween);
		}
		base.Despawn();
	}
}
