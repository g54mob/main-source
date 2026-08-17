using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Ex_Magistone1_Projectile : Projectile
{
	private List<MeshRenderer> _GemMeshes;

	private GameObject _MeshContainer;

	private SpriteRenderer _ShadowSprite;

	private const float Radius = 56f;

	private const float MinRotateDuration = 2f;

	private const float MaxRotateDuration = 3f;

	private Ex_Magistone1_Weapon _trueWeapon;

	private MeshRenderer _gemMesh;

	private int _meshIndex;

	private uint _tint;

	private int _spawnCounter;

	private float _spawnOffsetY;

	private Tween _posTween;

	private Tween _angleTween;

	private Tween _shadowFadeTween;

	private Tween _shadowScaleTween;

	private Timer _expireTimer;

	protected override void Awake()
	{
		//IL_017e->IL0102: Incompatible stack heights: 1 vs 0
		//IL_0095->IL0102: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL0102: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL0102: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4B58]");
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
								((UnityEngine.Object)gameObject2).SetName("Ex_Magistone_Shadow");
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0017: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_0362: Expected O, but got Ref
		//IL_037e: Expected O, but got Ref
		//IL_01d5: Expected I, but got O
		//IL_0268: Expected O, but got I4
		//IL_0476: Expected I, but got O
		//IL_020d: Expected O, but got I
		//IL_0434: Expected O, but got I4
		//IL_02cb: Expected I, but got O
		//IL_02db: Expected O, but got I
		//IL_027f: Expected O, but got I4
		//IL_0295: Expected O, but got I
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_0313: Expected O, but got I
		//IL_0553: Expected I, but got O
		//IL_0558->IL0558: Incompatible stack heights: 9 vs 1
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		Ex_Magistone1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_03f6;
		}
		nint num = (nint)weapon2;
		nint num2 = (nint)typeof(Ex_Magistone1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v93+FFFFFFF8+v73 @ rax_v88*8]");
			if (0 == (nint)typeof(Ex_Magistone1_Weapon))
			{
				obj3 = 1;
				goto IL_0405;
			}
		}
		obj3 = 0;
		goto IL_0405;
		IL_0405:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (Ex_Magistone1_Weapon)_weapon;
		}
		goto IL_03f6;
		IL_03f6:
		_trueWeapon = trueWeapon;
		Ex_Magistone1_Weapon trueWeapon2 = _trueWeapon;
		_spawnCounter = trueWeapon2._spawnCounter;
		_isCullable = false;
		bool flag2 = (object)_trueWeapon == null;
		SetScaleToArea(0.5f);
		BaseBody baseBody = body.setCircle(56f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		Transform transform = _MeshContainer.transform;
		IEnumerator enumerator = transform.GetEnumerator();
		nint num4 = 1;
		GameObject gameObject = default(GameObject);
		object obj4 = default(object);
		object obj12 = default(object);
		Transform transform2 = default(Transform);
		while (true)
		{
			bool flag3 = (object)gameObject == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			if (obj4 == null)
			{
				break;
			}
			bool flag4 = (object)gameObject == null;
			nint num5 = (nint)gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+12E]");
			object obj11;
			object obj5;
			if ((nint)0 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+B0]");
				obj5 = 0;
				bool flag5 = false;
				while (true)
				{
					object obj6 = (flag5 ? 1 : 0) + (flag5 ? 1 : 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r8_v12+v588 @ rax_v82*8]");
					if (0 == (nint)typeof(IEnumerator))
					{
						break;
					}
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
					bool num6 = flag5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+12E]");
					if ((nint)(num6 ? 1 : 0) < (nint)0)
					{
						continue;
					}
					goto IL_024d;
				}
				object obj7 = (flag5 ? 1 : 0) + (flag5 ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ r8_v12+8+v647 @ rcx_v62*8]");
				object obj8 = (nint)0 + (nint)1;
				object obj9 = obj8 << 4;
				object obj10 = obj9 + 312;
				obj11 = obj10 + num5;
				goto IL_045e;
			}
			goto IL_024d;
			IL_024d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj11 = obj12;
			obj5 = 1;
			goto IL_045e;
			IL_045e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v654 @ rdx_v16] (should have been resolved before IL gen)");
			nint num7 = (nint)typeof(Transform);
			nint num8 = (nint)transform2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rdx_v18 (Il2CppClass<UnityEngine.Transform>)+130]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v22 (Il2CppClass<UnityEngine.Transform>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rdx_v18 (Il2CppClass<UnityEngine.Transform>)+130]");
			bool flag6 = num9 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ r8_v22 (Il2CppClass<UnityEngine.Transform>)+C8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rax_v56+FFFFFFF8+v685 @ rax_v55*8]");
			bool flag7 = 0 != (nint)typeof(Transform);
			bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
			GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			bool flag9 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
			MeshRenderer component = transform2.GetComponent<MeshRenderer>();
			bool flag10 = (object)component == null;
			bool flag11 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			Renderer.set_enabled_Injected(((UnityEngine.Object)component).m_CachedPtr, false);
			num4 = (nint)typeof(IEnumerator);
		}
		object obj15 = (object)(&gameObject);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		object obj16 = (object)(&gameObject);
		object obj17 = default(object);
		obj16 = obj17;
		if (obj17 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
	}

	public void SetSpawnOffsetY(float spawnOffsetY)
	{
		_spawnOffsetY = spawnOffsetY;
		DropGem();
	}

	private unsafe void SetupGemMesh()
	{
		//IL_01dd: Expected O, but got I
		//IL_026c: Expected O, but got Ref
		//IL_008c->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_00ef->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_011c->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_0155->IL02bc: Incompatible stack heights: 1 vs 0
		//IL_0347->IL02bc: Incompatible stack heights: 2 vs 0
		//IL_018e->IL02bc: Incompatible stack heights: 2 vs 0
		//IL_01fd->IL02bc: Incompatible stack heights: 3 vs 0
		//IL_022e->IL02bc: Incompatible stack heights: 3 vs 0
		//IL_025a->IL02bc: Incompatible stack heights: 3 vs 0
		//IL_0286->IL02bc: Incompatible stack heights: 3 vs 0
		List<MeshRenderer> gemMeshes = _GemMeshes;
		if (_GemMeshes != null)
		{
			int num = (_meshIndex = _spawnCounter % gemMeshes._size);
			if (_GemMeshes != null)
			{
				bool flag = num >= gemMeshes._size;
				MeshRenderer[] items = gemMeshes._items;
				if (gemMeshes._items != null)
				{
					_gemMesh = items[num];
					if ((object)_gemMesh != null)
					{
						GameObject gameObject = _gemMesh.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							if ((object)_gemMesh != null)
							{
								_gemMesh.enabled = true;
								object gemMesh = _gemMesh;
								if ((object)_gemMesh != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v6 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v6 (System.Object)+10]");
									Renderer.set_sortingOrder_Injected((IntPtr)0, 2000);
									Ex_Magistone1_Weapon trueWeapon = _trueWeapon;
									if ((object)_trueWeapon != null)
									{
										List<uint> tints = trueWeapon._tints;
										if (trueWeapon._tints != null)
										{
											int spawnCounter = _spawnCounter;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.UInt32>)+18]");
											int num2 = (int)((nint)spawnCounter % (nint)0);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.UInt32>)+18]");
											bool flag3 = (nint)num2 >= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.UInt32>)+10]");
											object obj = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.UInt32>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v23+20+v112 @ rdx_v16 (System.Int32)*4]");
												_tint = 0u;
												if ((object)_gemMesh != null)
												{
													Material material = ((Renderer)_gemMesh).GetMaterial();
													if ((object)material != null)
													{
														float num3 = default(float);
														material.color = (Color)(&num3);
														if ((object)_gemMesh != null)
														{
															Material material2 = ((Renderer)_gemMesh).GetMaterial();
															float scaledAlpha = GetScaledAlpha();
															RenderingExtensions.SetAlpha(material2, scaledAlpha);
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
		}
		throw new NullReferenceException();
	}

	public unsafe void InitRotation()
	{
		//IL_0323: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0461: Expected I4, but got I8
		//IL_0089: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected I4, but got Unknown
		//IL_0076: Expected O, but got I8
		//IL_0165: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = num ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj3 = 0 & obj2;
		bool flag = (nint)obj3 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag2 = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		Ex_Magistone1_Projectile ex_Magistone1_Projectile = this;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			object obj4 = obj ^ obj;
			object obj5 = obj & obj4;
			flag = (nint)obj5 < 0;
			flag2 = (nint)obj < 0;
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			ex_Magistone1_Projectile = (Ex_Magistone1_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v50 @ rax_v3 (should have been resolved before IL gen)");
		int num2 = (int)(_spawnCounter & 0x80000001L);
		if (flag2 != flag)
		{
			object obj6 = num2 - 1;
			object obj7 = obj6 | -2;
			num2 = obj7 + 1;
		}
		if (num2 != 1)
		{
		}
		Weapon weapon = _weapon;
		object obj8 = ((Equipment)weapon)._currentJsonDataObject.ToObject<object>();
		bool flag4 = obj8 == null;
		float duration = 2f;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v11 (System.Object)+60]");
			bool flag5 = (nint)0 == 0;
			duration = 2f;
			if (!flag5)
			{
				duration = 2f / 3f;
			}
		}
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Transform target = _gemMesh.transform;
		Vector3 vector = default(Vector3);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&vector), duration, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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

	private unsafe void DropGem()
	{
		//IL_0017: Expected I, but got O
		//IL_0309: Invalid comparison between F4 and O
		//IL_0123: Expected O, but got Ref
		//IL_02cc->IL0237: Incompatible stack heights: 1 vs 0
		//IL_00b7->IL0237: Incompatible stack heights: 1 vs 0
		//IL_0335->IL0237: Incompatible stack heights: 2 vs 0
		//IL_01ff->IL0237: Incompatible stack heights: 2 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			object obj = default(object);
			float num = (float)obj - _spawnOffsetY;
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				nint num2 = (nint)weapon;
				float num3 = _weapon.PSpeed();
				object obj2 = default(object);
				if (0 <= (nint)obj2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				}
				Transform cachedTransform2 = _cachedTransform;
				float num4 = (float)obj2 * _spawnOffsetY;
				float num5 = num4 + 1f;
				float num6 = _spawnOffsetY / num5;
				if ((object)_cachedTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						Despawn();
						return;
					}
					SetupGemMesh();
					InitRotation();
					if (_posTween != null)
					{
						TweenExtensions.Kill(_posTween);
					}
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&ret), num6);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
					TweenCallback tweenCallback = SpawnFragments;
					Transform transform = default(Transform);
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ rax_v34 (UnityEngine.Transform)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ((object)transform != null)
					{
						_posTween = (Tween)(object)transform;
						if ((object)_weapon != null)
						{
							float num7 = _weapon.PArea();
							Vector2 vector = default(Vector2);
							DoShadowTween(vector, num6, Ease.InSine);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void DoShadowTween(Vector2 position, float tweenDuration, Ease ease)
	{
		//IL_0293: Expected I, but got O
		//IL_03a4->IL0331: Incompatible stack heights: 1 vs 0
		//IL_02b2->IL0331: Incompatible stack heights: 1 vs 0
		//IL_03c1->IL0331: Incompatible stack heights: 1 vs 0
		if ((object)_trueWeapon != null && (object)_weapon != null)
		{
			float num = _weapon.PArea();
			if ((object)_trueWeapon != null)
			{
				object obj = default(object);
				float num2 = (float)obj * 0.5f;
				float num3 = num2 * 0.7f;
				if ((object)_ShadowSprite != null)
				{
					GameObject gameObject = _ShadowSprite.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						if ((object)_ShadowSprite != null)
						{
							Transform transform = _ShadowSprite.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ShadowSprite, 0f);
							float num4 = num3 * 0.2f;
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_ShadowSprite, num4);
							float scaledAlpha = GetScaledAlpha();
							float endValue = scaledAlpha * 0.4f;
							if (_shadowFadeTween != null)
							{
								TweenExtensions.Kill(_shadowFadeTween);
							}
							TweenerCore<Color, Color, ColorOptions> component = DOTweenModuleSprite.DOFade(_ShadowSprite, endValue, tweenDuration);
							SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)(object)component, endValue);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)spriteRenderer3 != null)
							{
								TweenCallback tweenCallback = delegate
								{
									if (_shadowFadeTween != null)
									{
										TweenExtensions.Kill(_shadowFadeTween);
									}
									TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_ShadowSprite, 0f, 0.25f);
									if (tweenerCore2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									_shadowFadeTween = tweenerCore2;
								};
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v25 (UnityEngine.SpriteRenderer)+E8]");
								bool flag2 = (nint)0 == 0;
								nint num5 = 0;
								if (!flag2)
								{
									num5 = 0;
								}
								_shadowFadeTween = (Tween)(object)spriteRenderer3;
								if (_shadowScaleTween != null)
								{
									TweenExtensions.Kill(_shadowScaleTween);
									num5 = unchecked((nint)null);
								}
								if ((object)_ShadowSprite != null)
								{
									Transform target = _ShadowSprite.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, num3, tweenDuration);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									Tween tween = default(Tween);
									if (tween != null)
									{
										tween.stringId = "DefaultGameTweenId";
										_shadowScaleTween = tween;
										return;
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

	private unsafe void SpawnFragments()
	{
		//IL_000d: Expected I, but got O
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0071: Invalid comparison between I4 and F4
		//IL_0098: Expected F4, but got I4
		//IL_0186: Expected O, but got F4
		//IL_062b: Expected I, but got O
		//IL_01bd: Expected I, but got O
		//IL_01cb: Expected I, but got O
		//IL_01db: Expected O, but got I
		//IL_03a3: Expected I, but got O
		//IL_03b9: Expected O, but got I
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_025b: Expected O, but got I4
		//IL_043d: Expected I, but got O
		//IL_0521: Expected O, but got I
		//IL_0217: Expected O, but got I
		//IL_0675: Expected O, but got I4
		//IL_068c: Expected I, but got I8
		//IL_0268: Expected O, but got I
		//IL_024d: Expected O, but got I4
		//IL_0419: Expected I, but got I8
		//IL_05e5->IL0442: Incompatible stack heights: 1 vs 0
		//IL_06dc->IL0442: Incompatible stack heights: 1 vs 0
		//IL_0144->IL0442: Incompatible stack heights: 1 vs 0
		//IL_031d->IL0561: Incompatible stack heights: 1 vs 0
		//IL_0322->IL0322: Incompatible stack heights: 1 vs 0
		PlaySfx();
		Ex_Magistone1_Weapon trueWeapon = _trueWeapon;
		bool flag6 = default(bool);
		if ((object)_trueWeapon != null)
		{
			nint num = (nint)trueWeapon;
			float num2 = _trueWeapon.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r15d,xmm0\"");
			object obj2 = default(object);
			object obj = obj2 + trueWeapon._baseFragmentAmount;
			if ((object)_trueWeapon != null)
			{
				float num3 = (float)obj + 2f;
				float num4;
				if (!(0f > num3))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
					num4 = 0f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
					num4 = num3;
				}
				if (!(num4 > 2f))
				{
					num4 = 2f;
				}
				float fragmentScale = 0.5f / num4;
				bool flag = (nint)obj <= 0;
				int num5 = 0;
				if (flag)
				{
					goto IL_0322;
				}
				float num6 = default(float);
				while (true)
				{
					Ex_Magistone1_Weapon trueWeapon2 = _trueWeapon;
					if ((object)_trueWeapon == null)
					{
						break;
					}
					Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
					if (body != null)
					{
						BaseBody baseBody = body;
						ArcadeTransform arcadeTransform = baseBody._transform;
						if (baseBody._transform == null)
						{
							break;
						}
						arcadeTransform.position = ret;
					}
					if (trueWeapon2._fragmentPool == null)
					{
						break;
					}
					Weapon weapon = _weapon;
					Projectile projectile = trueWeapon2._fragmentPool.SpawnAt((float2)num6, _weapon, num5);
					Ex_Magistone1_Projectile_Fragment ex_Magistone1_Projectile_Fragment;
					if ((object)projectile == null)
					{
						ex_Magistone1_Projectile_Fragment = null;
						goto IL_053a;
					}
					nint num7 = (nint)projectile;
					nint num8 = (nint)typeof(Ex_Magistone1_Projectile_Fragment);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment>)+130]");
					object obj5;
					if (num9 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ rax_v52+FFFFFFF8+v911 @ rax_v48*8]");
						if (0 == (nint)typeof(Ex_Magistone1_Projectile_Fragment))
						{
							obj5 = 1;
							goto IL_050a;
						}
					}
					obj5 = 0;
					goto IL_050a;
					IL_053a:
					bool flag3 = (object)ex_Magistone1_Projectile_Fragment == null;
					Projectile projectile2 = projectile;
					if (!flag3)
					{
						bool flag4 = ((UnityEngine.Object)ex_Magistone1_Projectile_Fragment).m_CachedPtr == (IntPtr)0;
						projectile2 = projectile;
						if (!flag4)
						{
							ex_Magistone1_Projectile_Fragment.SetupFragmentMesh(_meshIndex, _tint);
							ex_Magistone1_Projectile_Fragment.SetFragmentScale(fragmentScale);
							projectile2 = null;
							weapon = null;
						}
					}
					num5++;
					bool flag5 = num5 < (nint)obj;
					num4 = num6;
					flag6 = flag6;
					if (flag5)
					{
						continue;
					}
					goto IL_0322;
					IL_050a:
					bool flag7 = obj5 == null;
					weapon = (Weapon)num7;
					ex_Magistone1_Projectile_Fragment = null;
					if (!flag7)
					{
						weapon = (Weapon)num7;
						ex_Magistone1_Projectile_Fragment = (Ex_Magistone1_Projectile_Fragment)projectile;
					}
					goto IL_053a;
				}
			}
		}
		goto IL_0442;
		IL_066c:
		object obj6 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.001f, action, null, isLooped: false, flag6, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0442:
		throw new NullReferenceException();
		IL_0322:
		BaseBody baseBody2 = body;
		if (body != null)
		{
			baseBody2._enable = true;
			object gemMesh = _gemMesh;
			if ((object)_gemMesh != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v16 (System.Object)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v16 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v63 (UnityEngine.GameObject)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v63 (UnityEngine.GameObject)+10]");
					GameObject.SetActive_Injected((IntPtr)0, false);
					action = null;
					nint num10 = (nint)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v69 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile>)+370]");
					nint method = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ r10_v1 (System.IntPtr)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = method;
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ r10_v1 (System.IntPtr)+4C]");
					object obj7 = (nint)0 >> 4;
					object obj8 = obj7 & 1;
					nint num11;
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ r10_v1 (System.IntPtr)+52]");
						if ((nint)0 == 0)
						{
							num11 = unchecked((nint)6447293664L);
							goto IL_066c;
						}
					}
					num11 = ((Delegate)action).method_ptr;
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					goto IL_066c;
				}
			}
		}
		goto IL_0442;
	}

	private void PlaySfx()
	{
		//IL_0057: Expected O, but got I4
		//IL_0137: Expected O, but got I8
		//IL_0049: Expected O, but got I
		//IL_0186: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected F4, but got Unknown
		//IL_00bb: Expected O, but got I4
		Weapon weapon = _weapon;
		object obj = ((Equipment)weapon)._currentJsonDataObject.ToObject<object>();
		object obj2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v5 (System.Object)+60]");
			obj2 = 0;
		}
		else
		{
			obj2 = 0;
		}
		float num = (float)_indexInWeapon * -100f;
		bool flag = obj2 != null;
		object obj3 = 4294967295L;
		if (!flag)
		{
			obj3 = 1;
		}
		float num2 = (float)obj3 * num;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Detune = num2;
		soundConfig.Rate = 3f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_magistone, soundConfig, 200f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float detune = num2 ^ 0;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = detune;
		soundConfig2.Rate = 1.5f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Crystal8, soundConfig2, 200f, 10, time);
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
		MeshRenderer gemMesh = _gemMesh;
		if ((object)_gemMesh != null && ((UnityEngine.Object)gemMesh).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _gemMesh.gameObject;
			gameObject.SetActive(value: false);
		}
		GameObject gameObject2 = _ShadowSprite.gameObject;
		gameObject2.SetActive(value: false);
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		if (_shadowFadeTween != null)
		{
			TweenExtensions.Kill(_shadowFadeTween);
		}
		if (_shadowScaleTween != null)
		{
			TweenExtensions.Kill(_shadowScaleTween);
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CDoShadowTween_003Eb__23_0()
	{
		if (_shadowFadeTween != null)
		{
			TweenExtensions.Kill(_shadowFadeTween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ShadowSprite, 0f, 0.25f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_shadowFadeTween = tweenerCore;
	}
}
