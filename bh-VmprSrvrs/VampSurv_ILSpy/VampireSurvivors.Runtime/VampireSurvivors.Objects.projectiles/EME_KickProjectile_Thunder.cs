using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KickProjectile_Thunder : Projectile
{
	private List<TrailRenderer> _Trails;

	private float TrailPreTime;

	private ParticleSystem ThunderHeadFX;

	private ParticleSystem ThunderHeadEndFX;

	private bool FadeAlpha;

	private Vector2 _saveVel;

	private List<int> _targetAngles;

	private int _wallBounces;

	private static readonly int Tiling;

	private EME_Kick1Weapon _trueWeapon;

	private int _bouncedTimes;

	private bool _isLeft;

	protected int ExtraBounces;

	protected int AngleOffset;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0017: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Expected O, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Expected O, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Expected O, but got Unknown
		//IL_0704: Expected O, but got I
		//IL_0a09: Expected O, but got I4
		//IL_0a6f: Expected O, but got I4
		//IL_0724->IL0858: Incompatible stack heights: 1 vs 0
		//IL_079d->IL0858: Incompatible stack heights: 1 vs 0
		//IL_0ae2->IL0ae2: Incompatible stack heights: 2 vs 1
		//IL_083d->IL0858: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_0895;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(EME_Kick1Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v67 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v67 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v136+FFFFFFF8+v74 @ rax_v131*8]");
			if (0 == (nint)typeof(EME_Kick1Weapon))
			{
				obj3 = 1;
				goto IL_08a4;
			}
		}
		obj3 = 0;
		goto IL_08a4;
		IL_0858:
		throw new NullReferenceException();
		IL_0895:
		_trueWeapon = (EME_Kick1Weapon)trueWeapon;
		_bouncedTimes = 0;
		if ((object)_trueWeapon != null)
		{
			int wallBounces = _trueWeapon.WallBounces;
			int wallBounces2 = wallBounces + ExtraBounces;
			_wallBounces = wallBounces2;
			_isCullable = false;
			BaseBody baseBody = base.body;
			if (base.body != null)
			{
				baseBody._enable = true;
				ArcadeSprite arcadeSprite = setVisible(visible: false);
				if (base.body != null)
				{
					BaseBody baseBody2 = base.body.setCircle(32f, (float?)(object)1, (float?)(object)1);
					_speed = 10f;
					SetScaleToArea();
					if (FadeAlpha)
					{
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
					}
					setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
					if ((object)weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && base.body != null)
						{
							Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
							BaseBody baseBody3 = base.body;
							if (base.body != null)
							{
								baseBody3._onWorldBounds = true;
								Weapon weapon2 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
								{
									if (!(_isLeft = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX))
									{
										List<int> list = new List<int>();
										if (list != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v104 (System.Collections.Generic.List`1<System.Int32>)+1C]");
											_ = (nint)0 + (nint)1;
											IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
											if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
											{
												CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rcx_v74 (System.IntPtr)+18]");
												if ((nint)cancellationTokenSource >= 0)
												{
													list.AddWithResize(30);
												}
												else
												{
													CancellationTokenSource cancellationTokenSource2 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
													((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource2;
													_ = 30;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v104 (System.Collections.Generic.List`1<System.Int32>)+1C]");
												_ = (nint)0 + (nint)1;
												IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list).m_CachedPtr;
												if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
												{
													CancellationTokenSource cancellationTokenSource3 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v76 (System.IntPtr)+18]");
													if ((nint)cancellationTokenSource3 >= 0)
													{
														list.AddWithResize(240);
													}
													else
													{
														CancellationTokenSource cancellationTokenSource4 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
														((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource4;
														_ = 240;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v104 (System.Collections.Generic.List`1<System.Int32>)+1C]");
													_ = (nint)0 + (nint)1;
													IntPtr cachedPtr3 = ((UnityEngine.Object)(object)list).m_CachedPtr;
													if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
													{
														CancellationTokenSource cancellationTokenSource5 = ((MonoBehaviour)(object)list).m_CancellationTokenSource;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rcx_v78 (System.IntPtr)+18]");
														if ((nint)cancellationTokenSource5 >= 0)
														{
															list.AddWithResize(105);
														}
														else
														{
															CancellationTokenSource cancellationTokenSource6 = (CancellationTokenSource)(((MonoBehaviour)(object)list).m_CancellationTokenSource + 1);
															((MonoBehaviour)(object)list).m_CancellationTokenSource = cancellationTokenSource6;
															_ = 105;
														}
														_targetAngles = list;
														goto IL_06a7;
													}
												}
											}
										}
									}
									else
									{
										List<int> list2 = new List<int>();
										if (list2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1143 @ rax_v85 (System.Collections.Generic.List`1<System.Int32>)+1C]");
											_ = (nint)0 + (nint)1;
											IntPtr cachedPtr4 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
											if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
											{
												CancellationTokenSource cancellationTokenSource7 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v61 (System.IntPtr)+18]");
												if ((nint)cancellationTokenSource7 >= 0)
												{
													list2.AddWithResize(150);
												}
												else
												{
													CancellationTokenSource cancellationTokenSource8 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
													((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource8;
													_ = 150;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1143 @ rax_v85 (System.Collections.Generic.List`1<System.Int32>)+1C]");
												_ = (nint)0 + (nint)1;
												IntPtr cachedPtr5 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
												if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
												{
													CancellationTokenSource cancellationTokenSource9 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rcx_v63 (System.IntPtr)+18]");
													if ((nint)cancellationTokenSource9 >= 0)
													{
														list2.AddWithResize(300);
													}
													else
													{
														CancellationTokenSource cancellationTokenSource10 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
														((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource10;
														_ = 300;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1143 @ rax_v85 (System.Collections.Generic.List`1<System.Int32>)+1C]");
													_ = (nint)0 + (nint)1;
													IntPtr cachedPtr6 = ((UnityEngine.Object)(object)list2).m_CachedPtr;
													if (((UnityEngine.Object)(object)list2).m_CachedPtr != (IntPtr)0)
													{
														CancellationTokenSource cancellationTokenSource11 = ((MonoBehaviour)(object)list2).m_CancellationTokenSource;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rcx_v65 (System.IntPtr)+18]");
														if ((nint)cancellationTokenSource11 >= 0)
														{
															list2.AddWithResize(75);
														}
														else
														{
															CancellationTokenSource cancellationTokenSource12 = (CancellationTokenSource)(((MonoBehaviour)(object)list2).m_CancellationTokenSource + 1);
															((MonoBehaviour)(object)list2).m_CancellationTokenSource = cancellationTokenSource12;
															_ = 75;
														}
														_targetAngles = list2;
														goto IL_06a7;
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
		goto IL_0858;
		IL_08a4:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_0895;
		IL_06a7:
		List<int> targetAngles = _targetAngles;
		if (_targetAngles != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v39 (System.Collections.Generic.List`1<System.Int32>)+18]");
			bool flag2 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v39 (System.Collections.Generic.List`1<System.Int32>)+10]");
			Weapon weapon3 = (Weapon)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v39 (System.Collections.Generic.List`1<System.Int32>)+10]");
			if ((nint)0 != 0)
			{
				int num4 = AngleOffset;
				if (!_isLeft)
				{
					num4 = -num4;
				}
				float projectileSpeed = base.ProjectileSpeed;
				object obj4 = (((GameMonoBehaviour)weapon3)._onPauseSent ? 1 : 0) + num4;
				float rotation = (float)obj4 * ((float)Math.PI / 180f);
				float speed = default(float);
				Vector2 vector = SetVelocityFromRotation(rotation, speed);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Rate = 1f
				};
				float detune = (float)_indexInWeapon * -100f;
				soundConfig.Detune = detune;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, time);
				if (_Trails != null)
				{
					List<TrailRenderer>.Enumerator enumerator = default(List<TrailRenderer>.Enumerator);
					while (enumerator.MoveNext())
					{
						Weapon weapon4 = null;
						if (FadeAlpha)
						{
							throw new NullReferenceException();
						}
						bool flag3 = ((UnityEngine.Object)weapon4).m_CachedPtr == (IntPtr)0;
						TrailRenderer.Clear_Injected(((UnityEngine.Object)weapon4).m_CachedPtr);
						((TrailRenderer)null).emitting = true;
						((TrailRenderer)null).time = TrailPreTime;
					}
					Weapon thunderHeadFX = (Weapon)(object)ThunderHeadFX;
					if ((object)ThunderHeadFX == null || ((UnityEngine.Object)thunderHeadFX).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					if ((object)ThunderHeadFX != null)
					{
						ThunderHeadFX.Play(withChildren: true);
						return;
					}
				}
			}
		}
		goto IL_0858;
	}

	public override void InternalUpdate()
	{
		//IL_0059: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_00e5: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_01b9: Expected O, but got I4
		//IL_0284: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_032c: Invalid comparison between O and F4
		//IL_04ad->IL0465: Incompatible stack heights: 1 vs 0
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer = s_scene._renderer;
			if (s_scene._renderer != null)
			{
				int num = renderer.pixelHeight >> 31;
				object obj = renderer.pixelHeight - num;
				object obj2 = obj >> 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
				if ((object)_renderer != null)
				{
					int sortingOrder = default(int);
					_renderer.sortingOrder = sortingOrder;
					if (_Trails != null)
					{
						object obj3 = 0;
						List<TrailRenderer>.Enumerator enumerator = default(List<TrailRenderer>.Enumerator);
						if (enumerator.MoveNext())
						{
							nint num2 = (nint)typeof(RenderingExtensions);
							throw new NullReferenceException();
						}
						ParticleSystem thunderHeadFX = ThunderHeadFX;
						if ((object)ThunderHeadFX != null && ((UnityEngine.Object)thunderHeadFX).m_CachedPtr != (IntPtr)0)
						{
							RenderingExtensions.SetDepth(ThunderHeadFX, sortingOrder);
							obj3 = 0;
						}
						ParticleSystem thunderHeadEndFX = ThunderHeadEndFX;
						if ((object)ThunderHeadEndFX != null && ((UnityEngine.Object)thunderHeadEndFX).m_CachedPtr != (IntPtr)0)
						{
							RenderingExtensions.SetDepth(ThunderHeadEndFX, sortingOrder);
							obj3 = 0;
						}
						BaseBody baseBody = body;
						if (body != null)
						{
							Vector2 saveVel = baseBody._velocity;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871EC9FFh\"");
							if ((object)baseBody._velocity == null)
							{
								saveVel = _saveVel;
							}
							_saveVel = saveVel;
							BaseBody baseBody2 = body;
							if (body != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v44 (BaseBody)+74]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871ECA29h\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v44 (BaseBody)+74]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KickProjectile_Thunder)+F8]");
									obj4 = 0;
								}
								Renderer thunderHeadFX2 = (Renderer)(object)ThunderHeadFX;
								if ((object)ThunderHeadFX == null || ((UnityEngine.Object)thunderHeadFX2).m_CachedPtr == (IntPtr)0)
								{
									return;
								}
								if ((object)ThunderHeadFX != null)
								{
									Transform transform = ThunderHeadFX.transform;
									object obj5 = _saveVel * _saveVel;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KickProjectile_Thunder)+F8]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KickProjectile_Thunder)+F8]");
									object obj6 = num3 * 0;
									object obj7 = obj5 + obj6;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
										Vector3 euler = default(Vector3);
										Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
										bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Quaternion value = default(Quaternion);
										Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
									}
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

	private void SetRotationBasedOnVelocity(Transform target, Vector2 velocity)
	{
		//IL_0030: Invalid comparison between O and F4
		//IL_00aa->IL0062: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = obj2 * obj2;
		object obj3 = velocity * velocity;
		object obj4 = obj + obj3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
		}
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00bc: Expected O, but got I
		//IL_00d0: Expected I, but got O
		//IL_01a4: Expected O, but got I
		//IL_0121: Expected O, but got F4
		if (b != body)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		List<int> targetAngles = _targetAngles;
		int num = ++_bouncedTimes;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj = (object)b >> 31;
		object obj2 = (object)b + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = num - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)obj5 < 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj6 = 0;
			int num2 = AngleOffset;
			nint num3 = (nint)this;
			float projectileSpeed = base.ProjectileSpeed;
			int num4 = -AngleOffset;
			if (!_isLeft)
			{
				num2 = num4;
			}
			int num5 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rsi_v5+20+v147 @ rcx_v10*4]");
			object obj7 = (nint)num5 + (nint)0;
			float num6 = (float)obj7 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			object obj8 = default(object);
			float num7 = num6 * (float)obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			ArcadeSprite sprite = _sprite;
			float num8 = num6 * (float)obj8;
			BaseBody baseBody = sprite.body;
			baseBody._velocity = (float2)num7;
			if (--_wallBounces <= 0)
			{
				FadeOutAndDispose();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void SetupTrails(TrailRenderer _trail)
	{
		if (FadeAlpha)
		{
			Material material = ((Renderer)_trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
		}
		bool flag = ((UnityEngine.Object)_trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)_trail).m_CachedPtr);
		_trail.emitting = true;
		_trail.time = TrailPreTime;
	}

	private void FadeOutAndDispose()
	{
		//IL_00f5: Expected F4, but got I4
		//IL_026d: Expected I, but got O
		//IL_02bf: Expected F4, but got I
		//IL_02c4->IL02c4: Incompatible stack heights: 1 vs 0
		BaseBody baseBody = body;
		baseBody._enable = false;
		ParticleSystem thunderHeadFX = ThunderHeadFX;
		if ((object)ThunderHeadFX != null && ((UnityEngine.Object)thunderHeadFX).m_CachedPtr != (IntPtr)0)
		{
			ThunderHeadFX.Stop();
			ThunderHeadFX.Clear(withChildren: true);
		}
		ParticleSystem thunderHeadEndFX = ThunderHeadEndFX;
		if ((object)ThunderHeadEndFX != null && ((UnityEngine.Object)thunderHeadEndFX).m_CachedPtr != (IntPtr)0)
		{
			ThunderHeadEndFX.Play(withChildren: true);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(endValue: (!FadeAlpha) ? 1f : 0f, target: _renderer, duration: 1.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KickProjectile_Thunder>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		List<TrailRenderer>.Enumerator enumerator = default(List<TrailRenderer>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v7 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v7 (System.Object)+10]");
			TrailRenderer.set_time_Injected((IntPtr)0, 0f);
		}
	}

	public override void Despawn()
	{
		//IL_01a3->IL02d1: Incompatible stack heights: 2 vs 0
		//IL_022c->IL012c: Incompatible stack heights: 1 vs 0
		//IL_009d->IL009d: Incompatible stack heights: 1 vs 0
		//IL_02ab->IL012c: Incompatible stack heights: 1 vs 0
		//IL_0125->IL0125: Incompatible stack heights: 1 vs 0
		if (_Trails != null)
		{
			List<TrailRenderer>.Enumerator enumerator = default(List<TrailRenderer>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v19 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v19 (System.Object)+10]");
				TrailRenderer.Clear_Injected((IntPtr)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v19 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v19 (System.Object)+10]");
				TrailRenderer.set_emitting_Injected((IntPtr)0, false);
			}
			ParticleSystem thunderHeadFX = ThunderHeadFX;
			if ((object)ThunderHeadFX == null || ((UnityEngine.Object)thunderHeadFX).m_CachedPtr == (IntPtr)0)
			{
				goto IL_009d;
			}
			object thunderHeadFX2 = ThunderHeadFX;
			if ((object)ThunderHeadFX != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v18 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v18 (System.Object)+10]");
				ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
				if ((object)ThunderHeadFX != null)
				{
					ThunderHeadFX.Clear(withChildren: true);
					goto IL_009d;
				}
			}
		}
		goto IL_012c;
		IL_009d:
		ParticleSystem thunderHeadEndFX = ThunderHeadEndFX;
		if ((object)ThunderHeadEndFX == null || ((UnityEngine.Object)thunderHeadEndFX).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0125;
		}
		object thunderHeadEndFX2 = ThunderHeadEndFX;
		if ((object)ThunderHeadEndFX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v17 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v17 (System.Object)+10]");
			ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
			if ((object)ThunderHeadEndFX != null)
			{
				ThunderHeadEndFX.Clear(withChildren: true);
				goto IL_0125;
			}
		}
		goto IL_012c;
		IL_0125:
		base.Despawn();
		return;
		IL_012c:
		throw new NullReferenceException();
	}

	public EME_KickProjectile_Thunder()
	{
		//IL_004d: Expected O, but got I
		//IL_00a7: Expected O, but got I
		//IL_0474: Expected O, but got I
		//IL_0111: Expected O, but got I
		//IL_049c: Expected O, but got I
		//IL_017f: Expected O, but got I
		//IL_0164: Expected I4, but got I8
		//IL_04c4: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_04ec: Expected O, but got I
		//IL_025b: Expected O, but got I
		//IL_0240: Expected I4, but got I8
		//IL_0514: Expected O, but got I
		//IL_02c9: Expected O, but got I
		//IL_053c: Expected O, but got I
		//IL_0337: Expected O, but got I
		//IL_031c: Expected I4, but got I8
		//IL_0564: Expected O, but got I
		//IL_03a5: Expected O, but got I
		//IL_058c: Expected O, but got I
		//IL_0413: Expected O, but got I
		//IL_03f8: Expected I4, but got I8
		List<TrailRenderer> trails = new List<TrailRenderer>();
		_Trails = trails;
		TrailPreTime = 0.6f;
		FadeAlpha = true;
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v8+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v10+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(-10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 4294967286L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v12+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v14+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(-20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4294967276L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v16+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v18+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(-30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 4294967266L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v20+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v22+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(-40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 4294967256L;
		}
		_targetAngles = list;
		base._002Ector();
	}

	static EME_KickProjectile_Thunder()
	{
		int tiling = Shader.PropertyToID("_Tiling");
		Tiling = tiling;
	}
}
