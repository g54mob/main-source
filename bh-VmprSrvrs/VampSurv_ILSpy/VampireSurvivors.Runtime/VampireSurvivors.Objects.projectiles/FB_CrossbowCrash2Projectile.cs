using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_CrossbowCrash2Projectile : Projectile
{
	private MeshRenderer _PropellerMesh;

	private Transform _Propeller;

	private Transform _Pivot;

	private FB_CrossbowCrashWeapon _crossbowCrash;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _moveXTween;

	private MultiTargetTween _moveYTween;

	private float _speedXDuration = 300f;

	private float _pivotRotation;

	private TweenerCore<float, float, FloatOptions> pivotRotationTween;

	public float offsetX;

	public float offsetY;

	public float targetX;

	public float targetY;

	public float scaleOffsetX = 1f;

	private float _bodyPixelSize = 124f;

	private float _propellerScale = 15f;

	protected unsafe override void Awake()
	{
		//IL_0049: Expected O, but got Ref
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("whiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_Propeller, (Vector3)(&obj), 1f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_05a0: Expected O, but got I4
		//IL_004a: Expected I, but got O
		//IL_0052: Expected I, but got O
		//IL_0062: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_05cf: Expected O, but got I
		//IL_05d8: Expected O, but got I4
		//IL_009e: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_00d4: Expected O, but got I4
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected F4, but got Unknown
		//IL_0377: Expected I, but got O
		//IL_043c: Expected O, but got I4
		//IL_0702: Expected I, but got O
		//IL_0736: Expected O, but got F4
		//IL_0753: Expected I4, but got F4
		//IL_052a: Expected O, but got I4
		//IL_036a->IL0567: Incompatible stack heights: 1 vs 0
		//IL_03bc->IL0567: Incompatible stack heights: 2 vs 0
		//IL_0404->IL0567: Incompatible stack heights: 2 vs 0
		//IL_04a9->IL0567: Incompatible stack heights: 2 vs 0
		//IL_04d5->IL0567: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setScale(_bodyPixelSize, (float?)(object)0);
		float? crossbowCrash;
		float? num;
		if ((object)weapon == null)
		{
			num = (float?)(object)0;
			crossbowCrash = (float?)(object)0;
			goto IL_05a9;
		}
		nint num2 = (nint)typeof(FB_CrossbowCrashWeapon);
		nint num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_CrossbowCrashWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_CrossbowCrashWeapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v45 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v125+FFFFFFF8+v86 @ rax_v120*8]");
			if (0 == (nint)typeof(FB_CrossbowCrashWeapon))
			{
				obj3 = 1;
				goto IL_05b8;
			}
		}
		obj3 = 0;
		goto IL_05b8;
		IL_05e6:
		FB_CrossbowCrashWeapon crossbowCrash2 = _crossbowCrash;
		float num7;
		if ((object)_crossbowCrash != null)
		{
			float num5 = crossbowCrash2.defaultWidth * 0.5f;
			float num6 = num5 * num7;
			float num8 = num6 * 0.01f;
			float num9 = num8 + 0.19999999f;
			targetX = num9;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null)
					{
						float num10 = targetX * -1f;
						offsetX = num10;
						float num11 = (targetY = (float)renderer.pixelHeight * 0.01f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float num12 = num11 ^ 0;
						offsetY = num12;
						if ((object)_Propeller != null)
						{
							Transform transform = _Propeller.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								scaleOffsetX = 0f;
								moveToTargetX();
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								if (array != null)
								{
									nint num13 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj4 = default(object);
									bool flag2 = obj4 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										((EventEmitter)(object)tweenConfig).callbacks = (Delegate[])array;
										Dictionary<string, object> dictionary = new Dictionary<string, object>();
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
										if (dictionary != null)
										{
											object value2 = default(object);
											bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"offsetY", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											((Group)(object)tweenConfig).children = (HashSet<PhaserGameObject>)1157234688;
											TweenCallback pool2 = delegate
											{
												Despawn();
											};
											((BulletPool)(object)tweenConfig)._pool = (ObjectPool)(object)pool2;
											MultiTargetTween moveYTween = Tweens.Add(tweenConfig);
											_moveYTween = moveYTween;
											BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
											if ((object)_weapon != null)
											{
												Transform transform2 = _weapon.transform;
												if ((object)transform2 != null)
												{
													bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
													bool flag5 = (object)_cachedTransform == null;
													bool flag6 = ((EventEmitter)cachedTransform).callbacks == null;
													Vector3 value3 = default(Vector3);
													Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, ref value3);
													ArcadeSprite arcadeSprite3 = setAlpha(1f);
													SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
													{
														Rate = 1f
													};
													object obj5 = UnityEngine.Random.value;
													object obj6 = default(object);
													float num14 = (float)obj6 * 500f;
													((GameMonoBehaviour)(object)soundConfig)._onPauseSent = (byte)(int)num14 != 0;
													_ = 1;
													float time = default(float);
													PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Song, soundConfig, 150f, 6, time);
													PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Song, new SoundManager.SoundConfig
													{
														Volume = (float?)(object)1,
														Rate = 1f,
														Detune = -1000f
													}, 150f, 6, time);
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
		goto IL_0567;
		IL_05a9:
		_crossbowCrash = (FB_CrossbowCrashWeapon)crossbowCrash;
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = true;
			_isCullable = false;
			if ((object)_weapon != null)
			{
				float num15 = _weapon.PArea();
				object obj7 = default(object);
				float num16 = (float)obj7 + 0.25f;
				float num17 = num16 + (float)index;
				if (!(10f > num17))
				{
					object obj8 = num17 & -2147483649L;
					bool flag7 = (nint)obj8 <= 2139095040;
					num7 = 10f;
					if (flag7)
					{
						goto IL_05e6;
					}
				}
				num7 = num17;
				goto IL_05e6;
			}
		}
		goto IL_0567;
		IL_05b8:
		bool flag8 = obj3 == null;
		num = (float?)(object)num3;
		crossbowCrash = (float?)(object)0;
		if (!flag8)
		{
			num = (float?)(object)num3;
			crossbowCrash = (float?)weapon;
		}
		goto IL_05a9;
		IL_0567:
		throw new NullReferenceException();
	}

	private unsafe void moveToTargetX()
	{
		//IL_0044: Invalid comparison between I4 and F4
		//IL_0056: Expected O, but got I4
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected I4, but got Unknown
		//IL_041f: Invalid comparison between F4 and I4
		//IL_042d: Expected I, but got O
		//IL_0071: Expected O, but got I8
		//IL_0286: Expected I, but got O
		//IL_02cb->IL039e: Incompatible stack heights: 1 vs 0
		//IL_0313->IL039e: Incompatible stack heights: 1 vs 0
		//IL_0244->IL0244: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					bool flag = !(0f < targetX);
					object obj = 10;
					if (!flag)
					{
						obj = 4294967286L;
					}
					int num = obj + renderer.pixelHeight;
					ArcadeSprite arcadeSprite = setDepth(num);
					float num2 = targetX;
					bool flag2 = !(targetX > 0f);
					nint num3 = unchecked((nint)null);
					if (!flag2)
					{
						Tween tween = pivotRotationTween;
						if (pivotRotationTween != null && tween._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(pivotRotationTween);
						}
						_pivotRotation = -90f;
						if ((object)_Pivot == null)
						{
							goto IL_039e;
						}
						Transform transform = _Pivot.transform;
						float x = _pivotRotation * ((float)Math.PI / 180f);
						Vector3 euler = default(Vector3);
						float ret;
						Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						float value = default(float);
						Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)(&value));
						DOGetter<float> getter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						DOSetter<float> dOSetter = null;
						((FB_CrossbowCrash2Projectile)(object)dOSetter)._003CmoveToTargetX_003Eb__19_1(x);
						float duration = _speedXDuration * 0.002f;
						TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, -450f, duration);
						TweenCallback tweenCallback = delegate
						{
							Transform transform2 = _Pivot.transform;
							Vector3 euler2 = default(Vector3);
							Quaternion.Internal_FromEulerRad_Injected(ref euler2, out Quaternion _);
							bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Quaternion value3 = default(Quaternion);
							Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value3);
						};
						bool flag4 = tweenerCore == null;
						num3 = 0;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rax_v73 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
							bool flag5 = (nint)0 == 0;
							num3 = 0;
							if (!flag5)
							{
								num3 = 0;
							}
						}
						pivotRotationTween = tweenerCore;
						TweenerCore<float, float, FloatOptions> tweenerCore2 = pivotRotationTween;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						num2 = ret;
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						nint num4 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						bool flag6 = obj2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							if (dictionary != null)
							{
								object value2 = default(object);
								bool flag7 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"offsetX", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								tweenConfig.custom = dictionary;
								tweenConfig.duration = _speedXDuration;
								TweenCallback onComplete = delegate
								{
									float num5 = targetX * -1f;
									targetX = num5;
									moveToTargetX();
								};
								tweenConfig.onComplete = onComplete;
								MultiTargetTween moveXTween = Tweens.Add(tweenConfig);
								_moveXTween = moveXTween;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_039e;
		IL_039e:
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_01b7: Expected O, but got Ref
		//IL_01e1: Invalid comparison between F4 and I4
		//IL_020b: Expected I4, but got I8
		//IL_028a->IL0210: Incompatible stack heights: 1 vs 0
		//IL_0062->IL0210: Incompatible stack heights: 1 vs 0
		//IL_0117->IL0210: Incompatible stack heights: 6 vs 0
		//IL_0302->IL0210: Incompatible stack heights: 6 vs 0
		//IL_013e->IL0210: Incompatible stack heights: 6 vs 0
		//IL_015c->IL0210: Incompatible stack heights: 6 vs 0
		//IL_0329->IL0210: Incompatible stack heights: 6 vs 0
		//IL_0183->IL0210: Incompatible stack heights: 6 vs 0
		//IL_01a0->IL0210: Incompatible stack heights: 6 vs 0
		//IL_01d1->IL0210: Incompatible stack heights: 6 vs 0
		object cachedTransform = _cachedTransform;
		if ((object)_weapon != null)
		{
			Transform transform = _weapon.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_PropellerMesh != null)
				{
					Transform transform2 = _PropellerMesh.transform;
					if ((object)transform2 != null)
					{
						Vector3 forward = transform2.forward;
						bool flag2 = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (System.Object)+10]");
						Transform.set_position_Injected((IntPtr)0, ref ret);
						bool flag4 = (object)_PropellerMesh == null;
						Material material = ((Renderer)_PropellerMesh).GetMaterial();
						Weapon weapon = _weapon;
						bool flag5 = (object)_weapon == null;
						bool flag6 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
						float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)material != null)
								{
									float2 float6 = default(float2);
									material.SetVector("_LightPos", (Vector4)(&float6));
									if ((object)_PropellerMesh != null)
									{
										bool flag7 = targetX > 0f;
										int sortingOrder = 4000;
										if (!flag7)
										{
											sortingOrder = -2000;
										}
										_PropellerMesh.sortingOrder = sortingOrder;
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

	public override void Despawn()
	{
		Tween tween = pivotRotationTween;
		if (pivotRotationTween != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(pivotRotationTween);
		}
		if (_moveXTween != null)
		{
			_moveXTween.Kill();
		}
		if (_moveYTween != null)
		{
			_moveYTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__18_0()
	{
		Despawn();
	}

	private float _003CmoveToTargetX_003Eb__19_0()
	{
		return _pivotRotation;
	}

	private void _003CmoveToTargetX_003Eb__19_1(float x)
	{
		_pivotRotation = x;
	}

	private void _003CmoveToTargetX_003Eb__19_2()
	{
		Transform transform = _Pivot.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void _003CmoveToTargetX_003Eb__19_3()
	{
		float num = targetX * -1f;
		targetX = num;
		moveToTargetX();
	}
}
