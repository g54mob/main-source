using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class Cart2EvoProjectile : Projectile
{
	private SpriteRenderer _CartSprite;

	private SpriteRenderer _LightSprite;

	private const float Radius = 75f;

	private Cart2EvoWeapon _trueWeapon;

	private Bounds _camBounds;

	private ParticleSystem _pfxEmitter;

	private float _cachedSpeed;

	private float _cachedArea;

	private bool _isOnScreen;

	private bool _canDespawn;

	private bool _isFlipped;

	private int _flipSwitch;

	private bool _003CIsLastCart_003Ek__BackingField;

	public bool IsLastCart
	{
		get
		{
			return _003CIsLastCart_003Ek__BackingField;
		}
		set
		{
			_003CIsLastCart_003Ek__BackingField = value;
		}
	}

	public bool IsFlipped => _isFlipped;

	protected override void Awake()
	{
		base.Awake();
		GeneratePfx();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I4, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_011f: Expected F4, but got I
		//IL_014f: Expected F4, but got I
		//IL_017e: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		Cart2EvoWeapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_01d2;
		}
		nint num = (nint)typeof(Cart2EvoWeapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2EvoWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v7 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2EvoWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v7 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v28+FFFFFFF8+v62 @ rax_v23*8]");
			if (0 == (nint)typeof(Cart2EvoWeapon))
			{
				obj3 = 1;
				goto IL_01e1;
			}
		}
		obj3 = 0;
		goto IL_01e1;
		IL_01e1:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (Cart2EvoWeapon)_weapon;
		}
		goto IL_01d2;
		IL_01d2:
		_trueWeapon = trueWeapon;
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v6 (UnityEngine.Bounds)+10]");
		_ = 0;
		float num4 = _weapon.PSpeed();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v6 (UnityEngine.Bounds)+10]");
		_cachedSpeed = 0f;
		float num5 = _weapon.PArea();
		Cart2EvoWeapon trueWeapon2 = _trueWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v6 (UnityEngine.Bounds)+10]");
		_cachedArea = 0f;
		_isCullable = false;
		_canDespawn = false;
		ArcadeSprite arcadeSprite = setScale(trueWeapon2._003CScaleMultiplier_003Ek__BackingField, (float?)(object)0);
		InitSprites();
		SetDepths();
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
		UpdatePfx();
		if (_isOnScreen = CameraExtensions.IsObjectVisible(_mainCamera, _CartSprite))
		{
			if (!_canDespawn)
			{
				_canDespawn = true;
			}
		}
		else if (_canDespawn)
		{
			Despawn();
		}
	}

	private void UpdatePosition()
	{
		//IL_0114: Expected O, but got F4
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (UnityEngine.Bounds)+10]");
		_ = 0;
		float2 float5 = base.position;
		float deltaTime = PauseSystem.DeltaTime;
		float num = (float)_flipSwitch * _cachedSpeed;
		float num2 = deltaTime * num;
		float num3 = num2 + (float)float5;
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				base.position = (float2)num3;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void CheckForDespawn()
	{
		if (_isOnScreen = CameraExtensions.IsObjectVisible(_mainCamera, _CartSprite))
		{
			if (!_canDespawn)
			{
				_canDespawn = true;
			}
		}
		else if (_canDespawn)
		{
			Despawn();
		}
	}

	public void SetFlipped(bool flipped)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		//IL_009c: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		_isFlipped = flipped;
		object obj = (flipped ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		int flipSwitch = obj2 - 1;
		_flipSwitch = flipSwitch;
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		Transform cachedTransform2 = _cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
		float radius = ((_indexInWeapon != 0) ? 60f : 75f);
		if (_isFlipped)
		{
		}
		bool flag4 = body == null;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		bool flag5 = body == null;
		baseBody2._enable = true;
	}

	private void InitSprites()
	{
		//IL_002f: Expected O, but got I4
		bool flag = _indexInWeapon == 0;
		bool flag2 = _indexInWeapon == 0;
		string spriteName = "Trains_03";
		if (!flag2)
		{
			int num = _indexInWeapon & 1;
			bool flag3 = num == 0;
			object obj = !flag3;
			spriteName = "Trains_01";
			if (obj == null)
			{
				spriteName = "Trains_02";
			}
		}
		Sprite sprite = SpriteManager.GetSprite(spriteName, "vfx");
		_CartSprite.sprite = sprite;
		Sprite sprite2 = SpriteManager.GetSprite("TrainLight", "vfx");
		_LightSprite.sprite = sprite2;
		Material material = MaterialManager.GetMaterial(MaterialType.VfxScreen);
		((Renderer)_LightSprite).SetMaterial(material);
		_LightSprite.enabled = flag;
	}

	private void SetBody()
	{
		//IL_0040: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		float radius = ((_indexInWeapon != 0) ? 60f : 75f);
		if (_isFlipped)
		{
		}
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
	}

	private void SetDepths()
	{
		//IL_013b: Expected O, but got I4
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected I4, but got Unknown
		//IL_01b1: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected I4, but got Unknown
		//IL_017c->IL00d5: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL00d5: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			int num = ((Equipment)weapon)._003COwner_003Ek__BackingField.depth;
			if ((object)_CartSprite != null)
			{
				int sortingOrder = num - 1;
				_CartSprite.sortingOrder = sortingOrder;
				object cartSprite = _CartSprite;
				if ((object)_CartSprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v7 (System.Object)+10]");
					object obj = Renderer.get_sortingOrder_Injected((IntPtr)0);
					int num2 = obj - 1;
					RenderingExtensions.SetDepth(_pfxEmitter, num2);
					Renderer cartSprite2 = _CartSprite;
					if ((object)_CartSprite != null)
					{
						bool flag2 = ((UnityEngine.Object)cartSprite2).m_CachedPtr == (IntPtr)0;
						object obj2 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)cartSprite2).m_CachedPtr);
						if ((object)_LightSprite != null)
						{
							int sortingOrder2 = obj2 + 100;
							_LightSprite.sortingOrder = sortingOrder2;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GeneratePfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00ec: Expected native int or pointer, but got O
		//IL_0106: Expected O, but got I
		//IL_0126: Expected O, but got Ref
		//IL_0140: Expected native int or pointer, but got O
		//IL_0281: Expected O, but got I4
		//IL_0165: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01bb: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_02bb: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-61]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}

	private unsafe void UpdatePfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007a: Expected O, but got I4
		//IL_01be: Expected I, but got O
		//IL_00b3: Expected O, but got I4
		//IL_015f: Expected O, but got Ref
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_012b->IL00d0: Incompatible stack heights: 1 vs 0
		//IL_01af->IL01b4: Incompatible stack heights: 3 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			Cart2EvoWeapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon != null)
			{
				float num = trueWeapon._003CScaleMultiplier_003Ek__BackingField * _cachedArea;
				float num2 = num * 0.79999995f;
				float num3 = num * 0.1f;
				object obj3 = 0;
				do
				{
					nint num4 = (nint)_pfxEmitter;
					float num5 = (float)ret + num2;
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					_ = 1;
					bool flag2 = (object)_pfxEmitter == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
					_ = 0;
					_ = 0;
					_ = 0;
					obj = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdi_v9 (System.IntPtr)+10]");
					bool flag3 = (nint)0 == 0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdi_v9 (System.IntPtr)+10]");
					ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj4, 1);
					obj3++;
					num2 *= -1f;
				}
				while ((nint)obj3 < 2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_LightSprite.enabled = false;
		CheckForTrainTrackFadeOut();
		base.Despawn();
	}

	private void CheckForTrainTrackFadeOut()
	{
		//IL_006b: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		if (!_003CIsLastCart_003Ek__BackingField)
		{
			return;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			List<Projectile> spawnedProjectiles = weapon._spawnedProjectiles;
			if (weapon._spawnedProjectiles != null)
			{
				List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = 0;
					object obj2 = 0;
					if (obj2 == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v5+10]");
					if ((nint)0 == 0)
					{
						continue;
					}
					bool flag;
					if ((object)this != null)
					{
						object obj3 = obj2 - (object)this;
						flag = obj3 == null;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v5+10]");
						flag = (nint)0 == 0;
					}
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v5+112]");
						if ((nint)0 == (_isFlipped ? 1 : 0))
						{
							return;
						}
					}
				}
				if ((object)_trueWeapon != null)
				{
					_trueWeapon.ShowTrainTrack(show: false, _isFlipped);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
