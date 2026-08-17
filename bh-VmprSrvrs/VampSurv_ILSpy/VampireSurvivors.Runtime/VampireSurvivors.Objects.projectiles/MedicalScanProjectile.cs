using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MedicalScanProjectile : Projectile
{
	private SpriteRenderer _medscanFront;

	private VampireSurvivors.Objects.Characters.CharacterController _targetPlayer;

	private float _animationT;

	private bool _isAnimating;

	protected PhaserSprite _explosionSprite;

	private PhaserSprite _rainbowSprite;

	private MultiTargetTween _rainbowTween;

	private MultiTargetTween _rainbowTween2;

	private MultiTargetTween _highlightTween;

	private MultiTargetTween _highlightTween2;

	protected unsafe override void Awake()
	{
		//IL_0106: Expected O, but got I
		//IL_0309: Expected O, but got I
		//IL_03d2->IL0348: Incompatible stack heights: 1 vs 0
		//IL_0130->IL0348: Incompatible stack heights: 1 vs 0
		base.Awake();
		float2 float5 = base.position;
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "sPFX_ring_64");
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
				if ((object)phaserSprite2 != null)
				{
					PhaserSprite explosionSprite = phaserSprite2.setAlpha(0f);
					_explosionSprite = explosionSprite;
					if ((object)_explosionSprite != null)
					{
						Transform transform = _explosionSprite.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector2 value = default(Vector2);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
							string explosionSprite2 = (string)(object)_explosionSprite;
							if ((object)_explosionSprite != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rsi_v16 (System.String)+28]");
								string text = (string)0;
								CheckRenderer();
								object spriteRenderer = ((ArcadeSprite)this)._spriteRenderer;
								if ((object)((ArcadeSprite)this)._spriteRenderer != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v16 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v16 (System.Object)+10]");
									SpriteRenderer.get_color_Injected((IntPtr)0, out Color ret);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rsi_v16 (System.String)+28]");
									bool flag3 = (nint)0 == 0;
									bool flag4 = text._stringLength == 0;
									Color value2 = default(Color);
									SpriteRenderer.set_color_Injected((IntPtr)text._stringLength, ref value2);
									bool flag5 = (object)_explosionSprite == null;
									PhaserSprite phaserSprite3 = _explosionSprite.setBlendMode(BlendMode.Add);
									bool flag6 = (object)GM.Core == null;
									PhaserScene s_scene = ArcadePhysics.s_scene;
									bool flag7 = ArcadePhysics.s_scene == null;
									PhaserScene.Renderer renderer = s_scene._renderer;
									bool flag8 = s_scene._renderer == null;
									bool flag9 = (object)phaserSprite3 == null;
									PhaserSprite phaserSprite4 = phaserSprite3.setDepth(renderer.pixelHeight);
									GameObject gameObject2 = base.gameObject;
									PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "s_pfx_rainbow_64w");
									bool flag10 = (object)phaserSprite5 == null;
									PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
									bool flag11 = (object)phaserSprite6 == null;
									PhaserSprite phaserSprite7 = phaserSprite6.setBlendMode(BlendMode.Add);
									bool flag12 = (object)GM.Core == null;
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									bool flag13 = ArcadePhysics.s_scene == null;
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									bool flag14 = s_scene2._renderer == null;
									bool flag15 = (object)phaserSprite7 == null;
									PhaserSprite rainbowSprite = phaserSprite7.setDepth(renderer2.pixelHeight);
									_rainbowSprite = rainbowSprite;
									object rainbowSprite2 = _rainbowSprite;
									bool flag16 = (object)_rainbowSprite == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1034 @ rdi_v21 (System.Object)+28]");
									object obj = 0;
									CheckRenderer();
									MedicalScanProjectile spriteRenderer2 = (MedicalScanProjectile)(object)((ArcadeSprite)this)._spriteRenderer;
									bool flag17 = (object)((ArcadeSprite)this)._spriteRenderer == null;
									bool flag18 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
									SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out ret);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1034 @ rdi_v21 (System.Object)+28]");
									bool flag19 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdi_v22 (System.Object)+10]");
									bool flag20 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdi_v22 (System.Object)+10]");
									SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
									return;
								}
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
		//IL_0023: Expected O, but got I4
		//IL_007e: Expected I, but got O
		//IL_00e2: Expected O, but got I4
		//IL_014f: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		_animationT = 0f;
		_isAnimating = false;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_medscanFront, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				_isAnimating = true;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_MedicalScan, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void SetTarget(Transform target)
	{
		_targetTransform = target;
		VampireSurvivors.Objects.Characters.CharacterController component = target.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		_targetPlayer = component;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0098: Expected I, but got O
		//IL_0179: Expected O, but got I4
		//IL_00f0: Expected I, but got O
		//IL_02c2: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0271: Expected I, but got O
		//IL_0480: Expected O, but got I4
		//IL_048e: Expected O, but got I4
		//IL_04b8: Expected O, but got I4
		//IL_042f: Expected I, but got O
		if (!_isAnimating || !(_animationT < 1f))
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		if ((_animationT = deltaTime + _animationT) < 1f)
		{
			return;
		}
		ApplyScanEffect();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_medscanFront != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.ease = Ease.Flash;
			tweenConfig.repeat = 2;
			tweenConfig.repeatDelay = 20f;
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			float radius = GetRadius();
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			if (_highlightTween != null)
			{
				_highlightTween.Kill();
			}
			if (_highlightTween2 != null)
			{
				_highlightTween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_explosionSprite != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.duration = 250f;
			tweenConfig2.ease = Ease.OutSine;
			tweenConfig2.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0058: Expected O, but got Ref
				PhaserSprite phaserSprite = RenderingExtensions.SetScale(_explosionSprite, 0f);
				PhaserSprite phaserSprite2 = _explosionSprite.setAlpha(0f);
				Transform transform = _explosionSprite.transform;
				object obj5 = default(object);
				transform.localEulerAngles = (Vector3)(&obj5);
				PhaserSprite phaserSprite3 = _explosionSprite.setVisible(visible: true);
			};
			tweenConfig2.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				//IL_002c: Expected I, but got O
				//IL_0090: Expected O, but got I4
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[1];
				if ((object)_explosionSprite != null)
				{
					nint num5 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				tweenConfig4.duration = 250f;
				tweenConfig4.alpha = (float?)(object)1;
				TweenCallback onComplete3 = delegate
				{
					PhaserSprite phaserSprite = _explosionSprite.setVisible(visible: false);
					Despawn();
				};
				tweenConfig4.onComplete = onComplete3;
				MultiTargetTween highlightTween2 = Tweens.Add(tweenConfig4);
				_highlightTween2 = highlightTween2;
			};
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween highlightTween = Tweens.Add(tweenConfig2);
			_highlightTween = highlightTween;
			Weapon weapon2 = _weapon;
			float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			if (_rainbowTween != null)
			{
				_rainbowTween.Kill();
			}
			if (_rainbowTween2 != null)
			{
				_rainbowTween2.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_rainbowSprite != null)
			{
				nint num4 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.alpha = (float?)(object)1;
			tweenConfig3.scale = (float?)(object)1;
			tweenConfig3.duration = 300f;
			tweenConfig3.ease = Ease.OutSine;
			tweenConfig3.angle = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				//IL_0058: Expected O, but got Ref
				PhaserSprite phaserSprite = RenderingExtensions.SetScale(_rainbowSprite, 0f);
				PhaserSprite phaserSprite2 = _rainbowSprite.setAlpha(0f);
				Transform transform = _rainbowSprite.transform;
				object obj5 = default(object);
				transform.localEulerAngles = (Vector3)(&obj5);
				PhaserSprite phaserSprite3 = _rainbowSprite.setVisible(visible: true);
			};
			tweenConfig3.onStart = onStart2;
			TweenCallback onComplete2 = delegate
			{
				//IL_002c: Expected I, but got O
				//IL_0090: Expected O, but got I4
				//IL_009e: Expected O, but got I4
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[1];
				if ((object)_rainbowSprite != null)
				{
					nint num5 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				tweenConfig4.duration = 250f;
				tweenConfig4.alpha = (float?)(object)1;
				tweenConfig4.angle = (float?)(object)1;
				TweenCallback onComplete3 = delegate
				{
					PhaserSprite phaserSprite = _rainbowSprite.setVisible(visible: false);
				};
				tweenConfig4.onComplete = onComplete3;
				MultiTargetTween rainbowTween2 = Tweens.Add(tweenConfig4);
				_rainbowTween2 = rainbowTween2;
			};
			tweenConfig3.onComplete = onComplete2;
			MultiTargetTween rainbowTween = Tweens.Add(tweenConfig3);
			_rainbowTween = rainbowTween;
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	protected virtual void ApplyScanEffect()
	{
		//IL_0095: Expected F4, but got I4
		//IL_02a4: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		//IL_01f3: Expected I, but got O
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d2: Invalid comparison between F4 and O
		//IL_020b->IL02da: Incompatible stack heights: 1 vs 0
		//IL_01e1->IL02da: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PRegen();
		float num2 = _weapon.PAmount();
		object obj = default(object);
		float num3 = (float)obj + 4f;
		float num4 = num3 * (float)obj;
		float radius = GetRadius();
		float num5 = radius * 17f;
		float num6 = num5 * num5;
		GameManager core = GM.Core;
		float num7 = 0f;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj7 = default(object);
		object obj8 = default(object);
		while (enumerator.MoveNext())
		{
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v4 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			Transform targetTransform = _targetTransform;
			bool flag2 = (object)transform == null;
			bool flag3 = (object)_targetTransform == null;
			object obj3 = flag2 & flag3;
			bool flag4 = obj3 == null;
			object obj4 = !flag4;
			if (obj4 == null)
			{
				bool flag5;
				if ((object)_targetTransform != null)
				{
					if ((object)transform != null)
					{
						object obj5 = (object)transform - (object)_targetTransform;
						flag5 = obj5 == null;
					}
					else
					{
						flag5 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				}
				if (!flag5)
				{
					float2 float5 = ((ArcadeSprite)null).position;
					Weapon weapon2 = _weapon;
					float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
					object obj6 = obj7 - obj8;
					object obj9 = float6 - float5;
					num7 = (float)obj6 * (float)obj6;
					object obj10 = obj9 * obj9;
					characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(obj10 + num7);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) < System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref characters))
					{
						continue;
					}
				}
			}
			nint num8 = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v807 @ rax_v31 (Il2CppClass<System.Object>)+3F8] (should have been resolved before IL gen)");
			num7 = num4;
		}
	}

	public void LateUpdate()
	{
		int num = _targetPlayer.depth;
		int num2 = num - 1;
		ArcadeSprite arcadeSprite = setDepth(num2);
		int num3 = _targetPlayer.depth;
		int sortingOrder = num3 + 1;
		_medscanFront.sortingOrder = sortingOrder;
		float2 float5 = _targetPlayer.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	protected float GetRadius()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00b3: Expected O, but got I4
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag2 = obj == null;
			flag = !flag2;
		}
		float num = _weapon.PArea();
		object obj3 = (flag ? 1 : 0) + 1;
		object obj5 = default(object);
		object obj4 = obj5 * obj3;
		float num2 = (float)obj4 * 4f;
		return num2 * 0.01f;
	}

	public override void Despawn()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_medscanFront, 0f);
		ArcadeSprite arcadeSprite = setAlpha(0f);
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		_isAnimating = true;
	}

	private unsafe void _003CInternalUpdate_003Eb__13_0()
	{
		//IL_0058: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_explosionSprite, 0f);
		PhaserSprite phaserSprite2 = _explosionSprite.setAlpha(0f);
		Transform transform = _explosionSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _explosionSprite.setVisible(visible: true);
	}

	private void _003CInternalUpdate_003Eb__13_1()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_explosionSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _explosionSprite.setVisible(visible: false);
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween highlightTween = Tweens.Add(tweenConfig);
		_highlightTween2 = highlightTween;
	}

	private void _003CInternalUpdate_003Eb__13_2()
	{
		PhaserSprite phaserSprite = _explosionSprite.setVisible(visible: false);
		Despawn();
	}

	private unsafe void _003CInternalUpdate_003Eb__13_3()
	{
		//IL_0058: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_rainbowSprite, 0f);
		PhaserSprite phaserSprite2 = _rainbowSprite.setAlpha(0f);
		Transform transform = _rainbowSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _rainbowSprite.setVisible(visible: true);
	}

	private void _003CInternalUpdate_003Eb__13_4()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_rainbowSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _rainbowSprite.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween rainbowTween = Tweens.Add(tweenConfig);
		_rainbowTween2 = rainbowTween;
	}

	private void _003CInternalUpdate_003Eb__13_5()
	{
		PhaserSprite phaserSprite = _rainbowSprite.setVisible(visible: false);
	}
}
