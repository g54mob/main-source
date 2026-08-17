using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class DiamondProjectile : Projectile
{
	private TrailRenderer _Trail;

	private Timer _expireTimer;

	private float _saveVelX;

	private float _saveVelY;

	private readonly List<int> _targetAngles;

	private bool isFullColourRange;

	protected override void Awake()
	{
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_04ca: Expected O, but got I4
		//IL_04ca: Expected O, but got I4
		//IL_00f5: Expected O, but got I
		//IL_05f2: Expected O, but got I4
		//IL_05f2: Expected O, but got I4
		//IL_016f: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_0220: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_02d1: Expected O, but got I
		//IL_0308: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_0784: Expected I4, but got O
		//IL_03b9: Expected O, but got I
		//IL_0439: Expected O, but got I
		//IL_041e: Expected O, but got I
		//IL_0893: Expected I4, but got O
		//IL_090c: Expected I4, but got O
		//IL_09a1: Expected O, but got I4
		//IL_07dd: Expected F4, but got I4
		//IL_08ad->IL07e2: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		_speed = 1.1f;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				if (characterController._characterType != CharacterType.TP_ACTRISE)
				{
					goto IL_0485;
				}
				Weapon weapon3 = _weapon;
				_speed = 0.75f;
				isFullColourRange = true;
				if ((object)_weapon != null)
				{
					weapon3.IsHoming = true;
					List<string> list = new List<string>();
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v84+18]");
							if (num >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"listone1");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj2 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v86+18]");
								if (num2 >= 0)
								{
									((List<object>)(object)list).AddWithResize((object)"listone2");
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
									object obj4 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v88+18]");
									if (num3 >= 0)
									{
										((List<object>)(object)list).AddWithResize((object)"listone3");
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
										object obj6 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v90+18]");
										if (num4 >= 0)
										{
											((List<object>)(object)list).AddWithResize((object)"listone4");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj8 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v92+18]");
											if (num5 >= 0)
											{
												((List<object>)(object)list).AddWithResize((object)"listone5");
												object obj10 = 0;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v113 (System.Collections.Generic.List`1<System.String>)+18]");
												object obj11 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												object obj10 = "listone5";
											}
											string text = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
											Sprite sprite = default(Sprite);
											ArcadeSprite arcadeSprite = setFrame(sprite);
											goto IL_0485;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07e2;
		IL_07e2:
		throw new NullReferenceException();
		IL_0485:
		_isCullable = false;
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			Weapon weapon4 = _weapon;
			if ((object)_weapon != null)
			{
				if (!weapon4.IsHoming)
				{
					Transform targetTransform = base.AimForRandomEnemy();
					_targetTransform = targetTransform;
				}
				else
				{
					Transform targetTransform2 = base.AimForNearestEnemy(rotate: false);
					_targetTransform = targetTransform2;
					Transform targetTransform3 = _targetTransform;
					if ((object)_targetTransform == null || ((UnityEngine.Object)targetTransform3).m_CachedPtr == (IntPtr)0)
					{
						Transform targetTransform4 = base.AimForRandomEnemy();
						_targetTransform = targetTransform4;
					}
				}
				SetScaleToArea();
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
				setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
				if ((object)weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && base.body != null)
					{
						Body body = base.body.setBoundsRectangle(characterController2._worldBoxCollider);
						BaseBody baseBody2 = base.body;
						if (base.body != null)
						{
							baseBody2._onWorldBounds = true;
							if (_expireTimer != null)
							{
								_expireTimer.Cancel();
							}
							if ((object)_weapon != null)
							{
								float num6 = _weapon.PDuration();
								Action onComplete = FadeOutAndDispose;
								object obj12 = default(object);
								float duration = (float)obj12 * 0.001f;
								bool flag = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_expireTimer = expireTimer;
								SetupTrails();
								int num7 = (int)_targetTransform;
								if ((object)_targetTransform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdi_v15 (System.Int32)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdi_v15 (System.Int32)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
									int num8 = (int)_cachedTransform;
									if ((object)_cachedTransform != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdi_v16 (System.Int32)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdi_v16 (System.Int32)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
										object obj13 = ret - ret2;
										object obj15 = default(object);
										object obj16 = default(object);
										object obj14 = obj15 - obj16;
										int num9 = (int)_cachedTransform;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
										Quaternion.Internal_FromEulerRad_Injected(ref ret, out Quaternion _);
										bool flag4 = (object)_cachedTransform == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rdi_v17 (System.Int32)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rdi_v17 (System.Int32)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&ret2));
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Rate = 1f,
											Volume = (float?)(object)1
										};
										float detune = (float)_indexInWeapon * -100f;
										soundConfig.Detune = detune;
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, flag ? 1 : 0);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07e2;
	}

	public override void SetTarget(Transform target)
	{
		//IL_00ee: Expected O, but got I
		//IL_0235: Expected F4, but got O
		//IL_010e->IL01cf: Incompatible stack heights: 1 vs 0
		//IL_01a1->IL01cf: Incompatible stack heights: 1 vs 0
		_targetTransform = target;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			float num = AngleFromTargetRadians(_targetTransform, playerTransform);
			List<int> targetAngles = _targetAngles;
			if (_targetAngles != null)
			{
				int indexInWeapon = _indexInWeapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32>)+18]");
				int num2 = (int)((nint)indexInWeapon % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32>)+18]");
				bool flag = (nint)num2 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32>)+10]");
				Transform transform = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v10 (UnityEngine.Transform)+18]");
					if ((nint)num2 >= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
					float projectileSpeed = base.ProjectileSpeed;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v10 (UnityEngine.Transform)+20+v142 @ rdx_v15 (System.Int32)*4]");
					float num3 = 0f * ((float)Math.PI / 180f);
					float rotation = num3 + num;
					Vector2 vector = SetVelocityFromRotation(rotation, num);
					BaseBody baseBody = body;
					if (body != null)
					{
						Transform transform2 = base.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						Vector3 axis = default(Vector3);
						Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Quaternion value = default(Quaternion);
						Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_0098: Expected F4, but got O
		//IL_00e6: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		_Trail.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187023EE5h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187023F06h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		if (b == body)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v5 (BaseBody)+74]");
			float num = 0f * 57.29578f;
			base.angle = num;
		}
	}

	private void SetupTrails()
	{
		//IL_038c: Expected O, but got F4
		//IL_03a5: Invalid comparison between I4 and F4
		//IL_0125: Expected O, but got I4
		//IL_03f5: Expected O, but got I4
		//IL_044f->IL0372: Incompatible stack heights: 1 vs 0
		//IL_049e->IL0372: Incompatible stack heights: 1 vs 0
		//IL_0277->IL0372: Incompatible stack heights: 3 vs 0
		//IL_0349->IL0372: Incompatible stack heights: 7 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			if ((object)_Trail != null)
			{
				_Trail.time = 1f;
				object obj = default(object);
				float num2 = (float)obj * 0.015f;
				if ((object)_Trail != null)
				{
					_Trail.endWidth = num2;
					_Trail.startWidth = num2;
					if (!isFullColourRange)
					{
						float saturationMax = default(float);
						float valueMin = default(float);
						float valueMax = default(float);
						float alphaMin = default(float);
						float r = UnityEngine.Random.ColorHSV(0f, 1f, 0.35f, saturationMax, valueMin, valueMax, alphaMin, 0.35f).r;
						object obj2 = 0;
					}
					else
					{
						object obj3 = UnityEngine.Random.value;
						float num3 = (float)obj * 16777215f;
						if (0f > num3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
						float num4 = 0f / 255f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
						object obj2 = 0;
						float r = num4;
					}
					Sprite sprite = default(Sprite);
					RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
					if ((object)_Trail != null)
					{
						Material material = ((Renderer)_Trail).GetMaterial();
						RenderingExtensions.SetAlpha(material, 0.65f);
						TrailRenderer trail = _Trail;
						if ((object)_Trail != null)
						{
							bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
							if ((object)_Trail != null)
							{
								_Trail.emitting = true;
								Gradient gradient = new Gradient();
								IntPtr ptr = Gradient.Init();
								gradient.m_Ptr = ptr;
								gradient.m_RequiresNativeCleanup = true;
								GradientColorKey[] array = new GradientColorKey[2];
								if (array != null)
								{
									bool flag2 = array.Length <= 0;
									bool flag3 = array.Length <= 1;
									_ = 1f;
									GradientAlphaKey[] array2 = new GradientAlphaKey[4];
									if (array2 != null)
									{
										bool flag4 = array2.Length <= 0;
										_ = 1061997773;
										bool flag5 = array2.Length <= 1;
										_ = 1061997773;
										_ = 1056964608;
										bool flag6 = array2.Length <= 2;
										_ = 1056964608;
										_ = 1056964608;
										bool flag7 = array2.Length <= 3;
										_ = 1036831949;
										_ = 1065353216;
										gradient.SetKeys(array, array2);
										if ((object)_Trail != null)
										{
											_Trail.colorGradient = gradient;
											TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
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
		throw new NullReferenceException();
	}

	public unsafe Color ColorFromUInt(uint value)
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_003b: Expected native int or pointer, but got O
		//IL_0063: Expected native int or pointer, but got O
		//IL_0081: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->a = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		float r = 0f / 255f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		((Color*)(nint)color)->r = r;
		float g = 0f / 255f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rax\"");
		((Color*)(nint)color)->g = g;
		float b = 0f / 255f;
		((Color*)(nint)color)->b = b;
		return color;
	}

	private void FadeOutAndDispose()
	{
		//IL_0148: Expected I, but got O
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
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
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_renderer, 0f, 0.1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.DiamondProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0234: Expected O, but got I4
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01ce;
			}
		}
		obj5 = 4294967295L;
		goto IL_01ce;
		IL_024f:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num3 = _saveVelY * 57.29578f;
		base.angle = num3;
		return;
		IL_01ce:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num4 = tile._data & 1;
		bool flag7 = num4 == 0;
		bool flag8 = num4 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num5 = tile._data & 2;
			bool flag10 = num5 == 0;
			bool flag11 = num5 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_024f;
			}
		}
		obj6 = 4294967295L;
		goto IL_024f;
	}

	public override void Despawn()
	{
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_Trail.emitting = false;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	public DiamondProjectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0445: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_046d: Expected O, but got I
		//IL_015a: Expected O, but got I
		//IL_013f: Expected I4, but got I8
		//IL_0495: Expected O, but got I
		//IL_01c8: Expected O, but got I
		//IL_04bd: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_021b: Expected I4, but got I8
		//IL_04e5: Expected O, but got I
		//IL_02a4: Expected O, but got I
		//IL_050d: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_02f7: Expected I4, but got I8
		//IL_0535: Expected O, but got I
		//IL_0380: Expected O, but got I
		//IL_055d: Expected O, but got I
		//IL_03ee: Expected O, but got I
		//IL_03d3: Expected I4, but got I8
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 4294967286L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(-20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4294967276L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(-30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 4294967266L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(-40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 4294967256L;
		}
		_targetAngles = list;
		base._002Ector();
	}
}
