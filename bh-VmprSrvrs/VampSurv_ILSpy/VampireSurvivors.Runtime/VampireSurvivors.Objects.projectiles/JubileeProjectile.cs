using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class JubileeProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public JubileeProjectile _003C_003E4__this;

		public ParticleSystem emitter;

		public Weapon weapon;

		internal void _003CInitProjectile_003Eb__0()
		{
			_003C_003E4__this.Despawn();
		}

		internal unsafe void _003CInitProjectile_003Eb__1()
		{
			//IL_0059: Expected O, but got Ref
			if ((object)weapon != null)
			{
				float num = weapon.PArea();
				float num2 = default(float);
				bool flag = !(4f > num2);
				float min = 4f;
				if (!flag)
				{
					min = num2;
				}
				ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
				object obj = default(object);
				RenderingExtensions.SetScale(emitter, (ParticleSystem.MinMaxCurve)(&obj));
				RenderingExtensions.SetQuantity(emitter, 64);
				if ((object)emitter != null)
				{
					Transform transform = emitter.transform;
					if ((object)_003C_003E4__this != null)
					{
						float2 position = _003C_003E4__this.position;
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						RenderingExtensions.Start(emitter);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			emitter.Stop();
		}

		internal void _003CInitProjectile_003Eb__3()
		{
			emitter.Stop();
		}
	}

	private MultiTargetTween _scaleTween;

	private JubileeWeapon _trueWeapon;

	private MultiTargetTween _emitterCounter;

	private int _basePixelSize = 48;

	public float counter;

	protected override void Awake()
	{
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_003b: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_00ed: Expected I, but got O
		//IL_0105: Expected O, but got I
		//IL_0185: Expected O, but got I4
		//IL_00d1: Expected O, but got I4
		//IL_00da: Expected O, but got I4
		//IL_0905: Expected O, but got I4
		//IL_0141: Expected O, but got I
		//IL_01a6: Expected I4, but got O
		//IL_0177: Expected O, but got I4
		//IL_0923: Expected O, but got I
		//IL_0214: Expected O, but got I
		//IL_0275: Expected O, but got I
		//IL_0287: Expected I4, but got O
		//IL_030f: Expected F4, but got I4
		//IL_09ce: Expected O, but got I4
		//IL_0532: Expected O, but got I4
		//IL_0a44: Expected O, but got I4
		//IL_0600: Expected O, but got I4
		//IL_0234->IL089a: Incompatible stack heights: 1 vs 0
		//IL_02ea->IL089a: Incompatible stack heights: 1 vs 0
		//IL_04bf->IL089a: Incompatible stack heights: 1 vs 0
		//IL_04e1->IL089a: Incompatible stack heights: 1 vs 0
		//IL_03a9->IL089a: Incompatible stack heights: 1 vs 0
		//IL_099d->IL089a: Incompatible stack heights: 1 vs 0
		//IL_03d0->IL089a: Incompatible stack heights: 1 vs 0
		//IL_0440->IL089a: Incompatible stack heights: 1 vs 0
		//IL_0565->IL089a: Incompatible stack heights: 1 vs 0
		//IL_0596->IL089a: Incompatible stack heights: 1 vs 0
		//IL_05ca->IL089a: Incompatible stack heights: 1 vs 0
		//IL_0a49->IL09dc: Incompatible stack heights: 2 vs 1
		//IL_061d->IL089a: Incompatible stack heights: 1 vs 0
		//IL_070a->IL089a: Incompatible stack heights: 1 vs 0
		//IL_075c->IL089a: Incompatible stack heights: 2 vs 0
		//IL_079c->IL089a: Incompatible stack heights: 2 vs 0
		//IL_07e3->IL089a: Incompatible stack heights: 2 vs 0
		//IL_0899->IL0899: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals31 = new _003C_003Ec__DisplayClass6_0();
		float? trueWeapon;
		object obj3;
		float? num;
		if (CS_0024_003C_003E8__locals31 != null)
		{
			CS_0024_003C_003E8__locals31._003C_003E4__this = this;
			CS_0024_003C_003E8__locals31.weapon = weapon;
			base.InitProjectile(pool, CS_0024_003C_003E8__locals31.weapon, index);
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
				float? weapon2 = (float?)CS_0024_003C_003E8__locals31.weapon;
				if ((object)CS_0024_003C_003E8__locals31.weapon == null)
				{
					num = (float?)(object)0;
					trueWeapon = (float?)(object)0;
					goto IL_08de;
				}
				nint num2 = (nint)typeof(JubileeWeapon);
				num = weapon2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rdx_v91 (Il2CppClass<VampireSurvivors.Objects.Weapons.JubileeWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v18 (System.Nullable`1<System.Single>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rdx_v91 (Il2CppClass<VampireSurvivors.Objects.Weapons.JubileeWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v18 (System.Nullable`1<System.Single>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v177+FFFFFFF8+v733 @ rax_v172*8]");
					if (0 == (nint)typeof(JubileeWeapon))
					{
						obj3 = 1;
						goto IL_08ed;
					}
				}
				obj3 = 0;
				goto IL_08ed;
			}
		}
		goto IL_089a;
		IL_089a:
		throw new NullReferenceException();
		IL_08ed:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)CS_0024_003C_003E8__locals31.weapon;
		}
		goto IL_08de;
		IL_09dc:
		float2 float5 = default(float2);
		base.position = float5;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		float value2 = default(float);
		if (array != null)
		{
			if ((object)transform != null)
			{
				int value = ((int*)(&array))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				if ((object)CS_0024_003C_003E8__locals31.weapon != null)
				{
					float num4 = CS_0024_003C_003E8__locals31.weapon.PArea();
					float num5 = value2 * (float)_basePixelSize;
					tweenConfig.scale = (float?)(object)1;
					if ((object)CS_0024_003C_003E8__locals31.weapon != null)
					{
						float num6 = CS_0024_003C_003E8__locals31.weapon.PDuration();
						tweenConfig.duration = num5;
						tweenConfig.yoyo = true;
						TweenCallback onComplete = delegate
						{
							CS_0024_003C_003E8__locals31._003C_003E4__this.Despawn();
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
						_scaleTween = scaleTween;
						if (_emitterCounter != null)
						{
							_emitterCounter.Kill();
						}
						counter = 0f;
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 != null)
						{
							object obj5 = array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj6 = default(object);
							bool flag2 = obj6 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								Dictionary<string, object> dictionary = new Dictionary<string, object>();
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								if (dictionary != null)
								{
									object value3 = default(object);
									bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"counter", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									if ((object)CS_0024_003C_003E8__locals31.weapon != null)
									{
										float num7 = CS_0024_003C_003E8__locals31.weapon.PDuration();
										float num8 = num5 * 0.3f;
										TweenCallback tweenCallback = delegate
										{
											//IL_0059: Expected O, but got Ref
											if ((object)CS_0024_003C_003E8__locals31.weapon != null)
											{
												float num14 = CS_0024_003C_003E8__locals31.weapon.PArea();
												float num15 = default(float);
												bool flag10 = !(4f > num15);
												float min = 4f;
												if (!flag10)
												{
													min = num15;
												}
												ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
												object obj9 = default(object);
												RenderingExtensions.SetScale(CS_0024_003C_003E8__locals31.emitter, (ParticleSystem.MinMaxCurve)(&obj9));
												RenderingExtensions.SetQuantity(CS_0024_003C_003E8__locals31.emitter, 64);
												if ((object)CS_0024_003C_003E8__locals31.emitter != null)
												{
													Transform transform4 = CS_0024_003C_003E8__locals31.emitter.transform;
													if ((object)CS_0024_003C_003E8__locals31._003C_003E4__this != null)
													{
														float2 float7 = CS_0024_003C_003E8__locals31._003C_003E4__this.position;
														bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
														Vector3 value5 = default(Vector3);
														Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value5);
														RenderingExtensions.Start(CS_0024_003C_003E8__locals31.emitter);
														return;
													}
												}
											}
											throw new NullReferenceException();
										};
										TweenCallback tweenCallback2 = delegate
										{
											CS_0024_003C_003E8__locals31.emitter.Stop();
										};
										TweenCallback tweenCallback3 = delegate
										{
											CS_0024_003C_003E8__locals31.emitter.Stop();
										};
										MultiTargetTween emitterCounter = Tweens.Add(tweenConfig2);
										_emitterCounter = emitterCounter;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_089a;
		IL_049b:
		Weapon weapon3 = _weapon;
		if ((object)_weapon == null || (object)weapon3._gameMan == null)
		{
			goto IL_089a;
		}
		Transform transform2 = weapon3._gameMan.FindClosestEnemyToPlayer(((Equipment)weapon3)._003COwner_003Ek__BackingField);
		bool flag4 = (object)transform2 == null;
		num = (float?)(object)0;
		if (!flag4)
		{
			bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			num = (float?)(object)0;
			if (!flag5)
			{
				Transform transform3 = transform2.transform;
				if ((object)transform3 == null)
				{
					goto IL_089a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v136 (UnityEngine.Transform)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v136 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				num = (float?)(object)0;
			}
		}
		goto IL_09dc;
		IL_08de:
		_trueWeapon = (JubileeWeapon)trueWeapon;
		int num9 = (int)_trueWeapon;
		if ((object)_trueWeapon != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdi_v9 (System.Int32)+158]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdi_v9 (System.Int32)+158]");
			if ((nint)0 != 0)
			{
				int indexInWeapon = _indexInWeapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v26+18]");
				int num10 = (int)((nint)indexInWeapon % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v26+18]");
				bool flag7 = (nint)num10 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v26+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v26+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v27+18]");
					if ((nint)num10 >= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v27+20+v157 @ rdx_v19 (System.Int32)*8]");
					CS_0024_003C_003E8__locals31.emitter = (ParticleSystem)0;
					int num11 = (int)CS_0024_003C_003E8__locals31.emitter;
					if ((object)CS_0024_003C_003E8__locals31.emitter == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdi_v10 (System.Int32)+10]");
					if ((nint)0 == 0)
					{
						return;
					}
					Weapon weapon4 = CS_0024_003C_003E8__locals31.weapon;
					if ((object)CS_0024_003C_003E8__locals31.weapon != null)
					{
						bool flag8 = weapon4.IsHoming;
						float num12 = 0f;
						if (flag8)
						{
							goto IL_049b;
						}
						float num13 = CS_0024_003C_003E8__locals31.weapon.PAmount();
						if (4f > value2)
						{
							bool flag9 = _indexInWeapon == 0;
							num12 = 4f;
							if (flag9)
							{
								goto IL_049b;
							}
						}
						float2 float6 = base.position;
						float value4 = UnityEngine.Random.value;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
							{
								value2 = UnityEngine.Random.value;
								num12 = 4f;
								goto IL_09dc;
							}
						}
					}
				}
			}
		}
		goto IL_089a;
	}
}
