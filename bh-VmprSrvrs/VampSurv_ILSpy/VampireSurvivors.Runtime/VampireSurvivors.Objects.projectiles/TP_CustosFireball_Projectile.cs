using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_CustosFireball_Projectile : Projectile
{
	private SpriteAnimation _anim;

	private ParticleSystem _pfxEmitter;

	private MultiTargetTween _scaleTween;

	private Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Fireball01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Fireball", 1, 8, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("fireball", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		GenerateParticleSystem();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_00e3: Expected I, but got O
		//IL_0181: Expected O, but got I4
		//IL_02b1: Expected O, but got I4
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected I4, but got Unknown
		base.InitProjectile(pool, weapon, index);
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)0, (float?)(object)0);
		float2 float5 = base.position;
		object obj = default(object);
		float num = (float)obj + 0.16f;
		float2 float6 = default(float2);
		base.position = float6;
		_speed = 0.8f;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		bool flag2 = array == null;
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		bool flag3 = obj2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag4 = tweenConfig == null;
		tweenConfig.targets = array;
		bool flag5 = (object)_weapon == null;
		float num3 = _weapon.PArea();
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		bool flag6 = (object)_anim == null;
		_anim.SetAnimation("fireball");
		Weapon weapon2 = _weapon;
		bool flag7 = (object)_weapon == null;
		bool flag8 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
		int num4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.Depth;
		bool flag9 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag10 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag11 = s_scene._renderer == null;
		bool flag12 = (object)_renderer == null;
		int num5 = renderer.pixelHeight >> 31;
		object obj3 = renderer.pixelHeight - num5;
		object obj4 = obj3 >> 1;
		object obj5 = num4 + obj4;
		int sortingOrder = obj5 + index;
		_renderer.sortingOrder = sortingOrder;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete = StartDespawn;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void SetTarget(Transform target)
	{
		//IL_00ca: Expected O, but got I
		//IL_0144: Expected O, but got I
		//IL_1228: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_1270: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_0201: Expected I4, but got I8
		//IL_12b8: Expected O, but got I
		//IL_028a: Expected O, but got I
		//IL_1300: Expected O, but got I
		//IL_02f8: Expected O, but got I
		//IL_02dd: Expected I4, but got I8
		//IL_1348: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_1390: Expected O, but got I
		//IL_03d4: Expected O, but got I
		//IL_03b9: Expected I4, but got I8
		//IL_13d8: Expected O, but got I
		//IL_0442: Expected O, but got I
		//IL_1420: Expected O, but got I
		//IL_04b0: Expected O, but got I
		//IL_0495: Expected I4, but got I8
		//IL_1468: Expected O, but got I
		//IL_051e: Expected O, but got I
		//IL_14b0: Expected O, but got I
		//IL_058c: Expected O, but got I
		//IL_0571: Expected I4, but got I8
		//IL_14f8: Expected O, but got I
		//IL_05fa: Expected O, but got I
		//IL_1540: Expected O, but got I
		//IL_0668: Expected O, but got I
		//IL_064d: Expected I4, but got I8
		//IL_1588: Expected O, but got I
		//IL_06d6: Expected O, but got I
		//IL_15d0: Expected O, but got I
		//IL_0744: Expected O, but got I
		//IL_0729: Expected I4, but got I8
		//IL_1618: Expected O, but got I
		//IL_07b2: Expected O, but got I
		//IL_1660: Expected O, but got I
		//IL_0820: Expected O, but got I
		//IL_0805: Expected I4, but got I8
		//IL_16a8: Expected O, but got I
		//IL_088e: Expected O, but got I
		//IL_16f0: Expected O, but got I
		//IL_08fc: Expected O, but got I
		//IL_08e1: Expected I4, but got I8
		//IL_1738: Expected O, but got I
		//IL_096a: Expected O, but got I
		//IL_1780: Expected O, but got I
		//IL_09d8: Expected O, but got I
		//IL_09bd: Expected I4, but got I8
		//IL_17c8: Expected O, but got I
		//IL_0a46: Expected O, but got I
		//IL_1810: Expected O, but got I
		//IL_0ab4: Expected O, but got I
		//IL_0a99: Expected I4, but got I8
		//IL_1858: Expected O, but got I
		//IL_0b22: Expected O, but got I
		//IL_18a0: Expected O, but got I
		//IL_0b90: Expected O, but got I
		//IL_0b75: Expected I4, but got I8
		//IL_18e8: Expected O, but got I
		//IL_0bfe: Expected O, but got I
		//IL_1930: Expected O, but got I
		//IL_0c6c: Expected O, but got I
		//IL_0c51: Expected I4, but got I8
		//IL_1978: Expected O, but got I
		//IL_0cda: Expected O, but got I
		//IL_19c0: Expected O, but got I
		//IL_0d48: Expected O, but got I
		//IL_0d2d: Expected I4, but got I8
		//IL_1a08: Expected O, but got I
		//IL_0db6: Expected O, but got I
		//IL_1a50: Expected O, but got I
		//IL_0e24: Expected O, but got I
		//IL_0e09: Expected I4, but got I8
		//IL_1a98: Expected O, but got I
		//IL_0e92: Expected O, but got I
		//IL_1ae0: Expected O, but got I
		//IL_0f00: Expected O, but got I
		//IL_0ee5: Expected I4, but got I8
		//IL_1b28: Expected O, but got I
		//IL_0f6e: Expected O, but got I
		//IL_1b70: Expected O, but got I
		//IL_0fdc: Expected O, but got I
		//IL_0fc1: Expected I4, but got I8
		//IL_1bb8: Expected O, but got I
		//IL_104a: Expected O, but got I
		//IL_1c00: Expected O, but got I
		//IL_10b8: Expected O, but got I
		//IL_109d: Expected I4, but got I8
		//IL_1c45: Expected I4, but got I8
		//IL_10e3: Expected I4, but got I8
		//IL_112d: Expected O, but got I
		//IL_1c9c: Expected F4, but got O
		//IL_114d->IL11ef: Incompatible stack heights: 1 vs 0
		//IL_11c0->IL11ef: Incompatible stack heights: 1 vs 0
		_targetTransform = target;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			float num = AngleFromTargetRadians(_targetTransform, playerTransform);
			List<int> list = new List<int>();
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v15+18]");
					if (num2 >= 0)
					{
						list.AddWithResize(0);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj2 = (nint)0 + (nint)1;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v17+18]");
						if (num3 >= 0)
						{
							list.AddWithResize(1);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj4 = (nint)0 + (nint)1;
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v19+18]");
							if (num4 >= 0)
							{
								list.AddWithResize(-1);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj6 = (nint)0 + (nint)1;
								_ = 4294967295L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v21+18]");
								if (num5 >= 0)
								{
									list.AddWithResize(2);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
									object obj8 = (nint)0 + (nint)1;
									_ = 2;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v23+18]");
									if (num6 >= 0)
									{
										list.AddWithResize(-2);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
										object obj10 = (nint)0 + (nint)1;
										_ = 4294967294L;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v25+18]");
										if (num7 >= 0)
										{
											list.AddWithResize(3);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
											object obj12 = (nint)0 + (nint)1;
											_ = 3;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v27+18]");
											if (num8 >= 0)
											{
												list.AddWithResize(-3);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
												object obj14 = (nint)0 + (nint)1;
												_ = 4294967293L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
											object obj15 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
												nint num9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v29+18]");
												if (num9 >= 0)
												{
													list.AddWithResize(4);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													object obj16 = (nint)0 + (nint)1;
													_ = 4;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
												object obj17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													nint num10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v31+18]");
													if (num10 >= 0)
													{
														list.AddWithResize(-4);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
														object obj18 = (nint)0 + (nint)1;
														_ = 4294967292L;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
													object obj19 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
														nint num11 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v33+18]");
														if (num11 >= 0)
														{
															list.AddWithResize(5);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
															object obj20 = (nint)0 + (nint)1;
															_ = 5;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
														_ = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
														object obj21 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
															nint num12 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v35+18]");
															if (num12 >= 0)
															{
																list.AddWithResize(-5);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																object obj22 = (nint)0 + (nint)1;
																_ = 4294967291L;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
															object obj23 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																nint num13 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v37+18]");
																if (num13 >= 0)
																{
																	list.AddWithResize(6);
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																	object obj24 = (nint)0 + (nint)1;
																	_ = 6;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																_ = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																object obj25 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																	nint num14 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v39+18]");
																	if (num14 >= 0)
																	{
																		list.AddWithResize(-6);
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																		object obj26 = (nint)0 + (nint)1;
																		_ = 4294967290L;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																	_ = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																	object obj27 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																		nint num15 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v41+18]");
																		if (num15 >= 0)
																		{
																			list.AddWithResize(7);
																		}
																		else
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																			object obj28 = (nint)0 + (nint)1;
																			_ = 7;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																		_ = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																		object obj29 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																			nint num16 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v43+18]");
																			if (num16 >= 0)
																			{
																				list.AddWithResize(-7);
																			}
																			else
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																				object obj30 = (nint)0 + (nint)1;
																				_ = 4294967289L;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																			_ = (nint)0 + (nint)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																			object obj31 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																				nint num17 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v45+18]");
																				if (num17 >= 0)
																				{
																					list.AddWithResize(8);
																				}
																				else
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																					object obj32 = (nint)0 + (nint)1;
																					_ = 8;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																				_ = (nint)0 + (nint)1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																				object obj33 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																				if ((nint)0 != 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																					nint num18 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v47+18]");
																					if (num18 >= 0)
																					{
																						list.AddWithResize(-8);
																					}
																					else
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																						object obj34 = (nint)0 + (nint)1;
																						_ = 4294967288L;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																					_ = (nint)0 + (nint)1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																					object obj35 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																					if ((nint)0 != 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																						nint num19 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v49+18]");
																						if (num19 >= 0)
																						{
																							list.AddWithResize(9);
																						}
																						else
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																							object obj36 = (nint)0 + (nint)1;
																							_ = 9;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																						_ = (nint)0 + (nint)1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																						object obj37 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																							nint num20 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v51+18]");
																							if (num20 >= 0)
																							{
																								list.AddWithResize(-9);
																							}
																							else
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																								object obj38 = (nint)0 + (nint)1;
																								_ = 4294967287L;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																							_ = (nint)0 + (nint)1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																							object obj39 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																								nint num21 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v53+18]");
																								if (num21 >= 0)
																								{
																									list.AddWithResize(10);
																								}
																								else
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																									object obj40 = (nint)0 + (nint)1;
																									_ = 10;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																								_ = (nint)0 + (nint)1;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																								object obj41 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																								if ((nint)0 != 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																									nint num22 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v55+18]");
																									if (num22 >= 0)
																									{
																										list.AddWithResize(-10);
																									}
																									else
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																										object obj42 = (nint)0 + (nint)1;
																										_ = 4294967286L;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																									_ = (nint)0 + (nint)1;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																									object obj43 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																									if ((nint)0 != 0)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																										nint num23 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v57+18]");
																										if (num23 >= 0)
																										{
																											list.AddWithResize(11);
																										}
																										else
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																											object obj44 = (nint)0 + (nint)1;
																											_ = 11;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																										_ = (nint)0 + (nint)1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																										object obj45 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																										if ((nint)0 != 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																											nint num24 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v59+18]");
																											if (num24 >= 0)
																											{
																												list.AddWithResize(-11);
																											}
																											else
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																												object obj46 = (nint)0 + (nint)1;
																												_ = 4294967285L;
																											}
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																											_ = (nint)0 + (nint)1;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																											object obj47 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																											if ((nint)0 != 0)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																												nint num25 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v61+18]");
																												if (num25 >= 0)
																												{
																													list.AddWithResize(12);
																												}
																												else
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																													object obj48 = (nint)0 + (nint)1;
																													_ = 12;
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																												_ = (nint)0 + (nint)1;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																												object obj49 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																												if ((nint)0 != 0)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																													nint num26 = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v63+18]");
																													if (num26 >= 0)
																													{
																														list.AddWithResize(-12);
																													}
																													else
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																														object obj50 = (nint)0 + (nint)1;
																														_ = 4294967284L;
																													}
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																													_ = (nint)0 + (nint)1;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																													object obj51 = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																													if ((nint)0 != 0)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																														nint num27 = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v65+18]");
																														if (num27 >= 0)
																														{
																															list.AddWithResize(13);
																														}
																														else
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																															object obj52 = (nint)0 + (nint)1;
																															_ = 13;
																														}
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																														_ = (nint)0 + (nint)1;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																														object obj53 = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																														if ((nint)0 != 0)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																															nint num28 = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdx_v67+18]");
																															if (num28 >= 0)
																															{
																																list.AddWithResize(-13);
																															}
																															else
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																object obj54 = (nint)0 + (nint)1;
																																_ = 4294967283L;
																															}
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																															_ = (nint)0 + (nint)1;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																															object obj55 = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																															if ((nint)0 != 0)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																nint num29 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v69+18]");
																																if (num29 >= 0)
																																{
																																	list.AddWithResize(14);
																																}
																																else
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																	object obj56 = (nint)0 + (nint)1;
																																	_ = 14;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																_ = (nint)0 + (nint)1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																object obj57 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																if ((nint)0 != 0)
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																	nint num30 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rdx_v71+18]");
																																	if (num30 >= 0)
																																	{
																																		list.AddWithResize(-14);
																																	}
																																	else
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																		object obj58 = (nint)0 + (nint)1;
																																		_ = 4294967282L;
																																	}
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																	_ = (nint)0 + (nint)1;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																	object obj59 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																	if ((nint)0 != 0)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																		nint num31 = 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v73+18]");
																																		if (num31 >= 0)
																																		{
																																			list.AddWithResize(15);
																																		}
																																		else
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																			object obj60 = (nint)0 + (nint)1;
																																			_ = 15;
																																		}
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																		_ = (nint)0 + (nint)1;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																		object obj61 = 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																		if ((nint)0 != 0)
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																			nint num32 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v75+18]");
																																			if (num32 >= 0)
																																			{
																																				list.AddWithResize(-15);
																																			}
																																			else
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																				object obj62 = (nint)0 + (nint)1;
																																				_ = 4294967281L;
																																			}
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																			_ = (nint)0 + (nint)1;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																			object obj63 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																			if ((nint)0 != 0)
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																				nint num33 = 0;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v77+18]");
																																				if (num33 >= 0)
																																				{
																																					list.AddWithResize(16);
																																				}
																																				else
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																					object obj64 = (nint)0 + (nint)1;
																																					_ = 16;
																																				}
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																				_ = (nint)0 + (nint)1;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																				object obj65 = 0;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																				if ((nint)0 != 0)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																					nint num34 = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v79+18]");
																																					if (num34 >= 0)
																																					{
																																						list.AddWithResize(-16);
																																					}
																																					else
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																						object obj66 = (nint)0 + (nint)1;
																																						_ = 4294967280L;
																																					}
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																					_ = (nint)0 + (nint)1;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																					object obj67 = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																					if ((nint)0 != 0)
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																						nint num35 = 0;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v81+18]");
																																						if (num35 >= 0)
																																						{
																																							list.AddWithResize(17);
																																						}
																																						else
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																							object obj68 = (nint)0 + (nint)1;
																																							_ = 17;
																																						}
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																						_ = (nint)0 + (nint)1;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																						object obj69 = 0;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																						if ((nint)0 != 0)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																							nint num36 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v83+18]");
																																							if (num36 >= 0)
																																							{
																																								list.AddWithResize(-17);
																																							}
																																							else
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																								object obj70 = (nint)0 + (nint)1;
																																								_ = 4294967279L;
																																							}
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																							_ = (nint)0 + (nint)1;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																							object obj71 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																							if ((nint)0 != 0)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																								nint num37 = 0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v85+18]");
																																								if (num37 >= 0)
																																								{
																																									list.AddWithResize(18);
																																								}
																																								else
																																								{
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																									object obj72 = (nint)0 + (nint)1;
																																									_ = 18;
																																								}
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
																																								_ = (nint)0 + (nint)1;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																								object obj73 = 0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																								if ((nint)0 != 0)
																																								{
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																									nint num38 = 0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v87+18]");
																																									if (num38 >= 0)
																																									{
																																										list.AddWithResize(-18);
																																									}
																																									else
																																									{
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																										object obj74 = (nint)0 + (nint)1;
																																										_ = 4294967278L;
																																									}
																																									list.Add(19);
																																									list.Add(-19);
																																									list.Add(20);
																																									list.Add(-20);
																																									int indexInWeapon = _indexInWeapon;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																									int num39 = (int)((nint)indexInWeapon % (nint)0);
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
																																									bool flag = (nint)num39 >= (nint)0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																									object obj75 = 0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
																																									if ((nint)0 != 0)
																																									{
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rcx_v98+20+v152 @ rdx_v94 (System.Int32)*4]");
																																										float num40 = 0f * 3f;
																																										float projectileSpeed = base.ProjectileSpeed;
																																										float num41 = num40 * ((float)Math.PI / 180f);
																																										float rotation = num41 + num;
																																										Vector2 vector = SetVelocityFromRotation(rotation, num);
																																										if (body != null)
																																										{
																																											Transform transform = base.transform;
																																											((List<int>)(object)this).Add(0);
																																											Vector3 axis = default(Vector3);
																																											Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
																																											bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																																											Quaternion value = default(Quaternion);
																																											Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
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
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_CustosFireball_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		//IL_0183: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got I
		//IL_01bd: Expected O, but got Ref
		//IL_01e4: Expected O, but got I
		//IL_01f9: Expected native int or pointer, but got O
		//IL_0213: Expected O, but got I
		//IL_0233: Expected O, but got Ref
		//IL_024d: Expected native int or pointer, but got O
		//IL_02e6: Expected O, but got I
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
			((List<object>)(object)list).AddWithResize((object)"HitBoom1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitBoom2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 15));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 47));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		particleSystemConfig._on = true;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}
}
