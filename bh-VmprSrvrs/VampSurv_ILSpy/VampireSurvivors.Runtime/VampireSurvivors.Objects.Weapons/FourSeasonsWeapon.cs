using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FourSeasonsWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int copy;

		public FourSeasonsWeapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			FourSeasonsWeapon fourSeasonsWeapon = _003C_003E4__this;
			float2 pos = default(float2);
			Projectile projectile = fourSeasonsWeapon._projectilePool.SpawnAt(pos, _003C_003E4__this, copy);
		}
	}

	private PhaserSprite[] _orbs;

	private MultiTargetTween[] _orbTweens;

	private bool _canSpin;

	public float2[] _positions;

	private float _angleUnit = (float)Math.PI / 360f;

	private float[] _angles;

	private float[] _cornerOffsets = new float[9] { 192f, 192f, 176f, 160f, 144f, 128f, 112f, 96f, 64f };

	public override float PPower()
	{
		if (_currentWeaponData != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				bool flag = _currentWeaponData == null;
				float num2 = default(float);
				float num = num2;
				if (!flag)
				{
					float num3 = base.PDuration();
					float num4 = base.PAmount();
					bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
					num = num2;
					if (!flag2)
					{
						num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
							float num5 = num2 * 0.001f;
							float num6 = num5 + currentWeaponData._003Cpower_003Ek__BackingField;
							float num7 = num6 * num2;
							float num8 = num7 * num;
							return num + num8;
						}
					}
				}
				throw new NullReferenceException();
			}
		}
		return 1f;
	}

	protected override void FakeConstruct()
	{
		//IL_021c: Expected I, but got O
		//IL_0026: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_0092: Expected I, but got O
		//IL_016f: Expected I, but got O
		base.FakeConstruct();
		float2[] positions = new float2[4];
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v4 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v3 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v9 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num4 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v11 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num5 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v12 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num6 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v10 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		nint num7 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v13 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num8 = 0;
		_ = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v11 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		_positions = positions;
		PhaserSprite[] orbs = new PhaserSprite[8];
		_orbs = orbs;
		MultiTargetTween[] orbTweens = new MultiTargetTween[8];
		_orbTweens = orbTweens;
		bool flag = false;
		Vector2 pos = default(Vector2);
		object obj = default(object);
		while (true)
		{
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "bulletFourSeasons");
			PhaserSprite[] orbs2 = _orbs;
			if ((object)phaserSprite != null)
			{
				nint num9 = (nint)orbs2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj == null)
				{
					break;
				}
			}
			orbs2[flag ? 1u : 0u] = phaserSprite;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			if ((flag ? 1 : 0) >= 8)
			{
				_explodeOnExpire = false;
				_explosionType = WeaponType.RAYEXPLOSION;
				return;
			}
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void Set4Positions()
	{
		float[] cornerOffsets = _cornerOffsets;
		int num = ((Equipment)this)._003CLevel_003Ek__BackingField;
		int num2 = cornerOffsets.Length - 1;
		if (((Equipment)this)._003CLevel_003Ek__BackingField >= num2)
		{
			num = num2;
		}
		float[] cornerOffsets2 = _cornerOffsets;
		float num3 = cornerOffsets2[num] * 0.01f;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num4 = renderer.width * 0.5f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float2[] positions = _positions;
		float num5 = renderer2.height * -0.5f;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num6 = (float)position - num4;
		float num7 = num6 + num3;
		float2[] positions2 = _positions;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		object obj = default(object);
		float num8 = (float)obj - num5;
		float num9 = num8 - num3;
		float2[] positions3 = _positions;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num10 = (float)position3 + num4;
		float num11 = num10 - num3;
		float2[] positions4 = _positions;
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num12 = (float)obj - num5;
		float num13 = num12 - num3;
		float2[] positions5 = _positions;
		float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num14 = (float)position5 - num4;
		float num15 = num14 + num3;
		float2[] positions6 = _positions;
		float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num16 = (float)obj + num5;
		float num17 = num16 + num3;
		float2[] positions7 = _positions;
		float2 position7 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num18 = (float)position7 + num4;
		float num19 = num18 - num3;
		float2[] positions8 = _positions;
		float2 position8 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num20 = (float)obj + num5;
		float num21 = num20 + num3;
	}

	protected unsafe override void MakeLevelOne()
	{
		//IL_0037: Expected F4, but got I4
		//IL_0069: Expected F4, but got I4
		//IL_009b: Expected F4, but got I4
		//IL_00cd: Expected F4, but got I4
		//IL_00ff: Expected F4, but got I4
		//IL_0131: Expected F4, but got I4
		//IL_0163: Expected F4, but got I4
		//IL_0195: Expected F4, but got I4
		//IL_01c7: Expected F4, but got I4
		//IL_0367: Expected I, but got O
		//IL_0406: Expected O, but got I4
		//IL_0441: Expected O, but got I8
		//IL_04a0: Expected O, but got I4
		//IL_06c4: Expected I, but got O
		//IL_06da: Expected O, but got I
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected O, but got Unknown
		//IL_0538: Expected I, but got O
		//IL_070e: Expected O, but got I4
		//IL_0725: Expected I, but got I8
		//IL_0521: Expected I, but got I8
		//IL_05a0: Expected I, but got O
		//IL_035a->IL061e: Incompatible stack heights: 1 vs 0
		//IL_0318->IL061e: Incompatible stack heights: 1 vs 0
		//IL_06b2->IL061e: Incompatible stack heights: 2 vs 0
		//IL_03d6->IL061e: Incompatible stack heights: 2 vs 0
		//IL_042a->IL061e: Incompatible stack heights: 2 vs 0
		//IL_0576->IL061e: Incompatible stack heights: 2 vs 0
		//IL_060b->IL061e: Incompatible stack heights: 2 vs 0
		//IL_05c3->IL05c3: Incompatible stack heights: 3 vs 2
		//IL_061d->IL0737: Incompatible stack heights: 2 vs 0
		base.MakeLevelOne();
		float[] angles = new float[9];
		_angles = angles;
		if (_angles != null)
		{
			float[] array = default(float[]);
			array[0] = 0f;
			if (_angles != null)
			{
				float[] array2 = default(float[]);
				array2[1] = 1.0601716E+09f;
				if (_angles != null)
				{
					float[] array3 = default(float[]);
					array3[2] = 1.0685602E+09f;
					if (_angles != null)
					{
						float[] array4 = default(float[]);
						array4[3] = 1.0740499E+09f;
						if (_angles != null)
						{
							float[] array5 = default(float[]);
							array5[4] = 1.0769487E+09f;
							if (_angles != null)
							{
								float[] array6 = default(float[]);
								array6[5] = 1.0798477E+09f;
								if (_angles != null)
								{
									float[] array7 = default(float[]);
									array7[6] = 1.0824385E+09f;
									if (_angles != null)
									{
										float[] array8 = default(float[]);
										array8[7] = 1.083888E+09f;
										if (_angles != null)
										{
											float[] array9 = default(float[]);
											array9[8] = 1.0853373E+09f;
											_canSpin = false;
											Set4Positions();
											if (_orbs == null)
											{
												return;
											}
											PhaserSprite[] orbs = _orbs;
											bool flag = false;
											bool flag2 = false;
											float2 position = default(float2);
											object obj = default(object);
											object obj8 = default(object);
											while (true)
											{
												if ((flag2 ? 1 : 0) >= orbs.Length)
												{
													return;
												}
												PhaserSprite[] orbs2 = _orbs;
												if (_orbs == null || (object)orbs2[flag ? 1u : 0u] == null)
												{
													break;
												}
												PhaserSprite phaserSprite = orbs2[flag ? 1u : 0u].setVisible(visible: true);
												ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
												{
													break;
												}
												Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
												if ((object)cachedTrans == null)
												{
													break;
												}
												bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
												float2 ret;
												Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
												if (arcadeSprite.body != null)
												{
													BaseBody body = arcadeSprite.body;
													ArcadeTransform arcadeTransform = body._transform;
													if (body._transform == null)
													{
														break;
													}
													arcadeTransform.position = ret;
												}
												PhaserSprite phaserSprite2 = orbs2[flag ? 1u : 0u].setPosition(position);
												MultiTargetTween[] orbTweens = _orbTweens;
												TweenConfig tweenConfig = new TweenConfig();
												object[] array10 = new object[1];
												if (array10 == null)
												{
													break;
												}
												nint num = (nint)array10;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												bool flag4 = obj == null;
												array10[0] = orbs2[flag ? 1u : 0u];
												if (tweenConfig == null)
												{
													break;
												}
												tweenConfig.targets = array10;
												if (_positions == null)
												{
													break;
												}
												if ((nint)_positions < 0)
												{
												}
												tweenConfig.x = (float?)(object)1;
												float2[] positions = _positions;
												if (_positions == null)
												{
													break;
												}
												object obj2 = (flag ? 1 : 0) & 0x80000003L;
												if ((nint)_positions < 0)
												{
													object obj3 = obj2 - 1;
													object obj4 = obj3 | -4;
													obj2 = obj4 + 1;
												}
												tweenConfig.y = (float?)(object)1;
												tweenConfig.duration = 500f;
												TweenCallback tweenCallback = null;
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r10_v9 (Il2CppMethodInfo)+8]");
												((Delegate)tweenCallback).method_ptr = (IntPtr)0;
												((Delegate)tweenCallback).method = (nint)__ldftn(FourSeasonsWeapon._003CMakeLevelOne_003Eb__10_0);
												((Delegate)tweenCallback).m_target = this;
												((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r10_v9 (Il2CppMethodInfo)+4C]");
												object obj5 = (nint)0 >> 4;
												object obj6 = obj5 & 1;
												nint num3;
												if (obj6 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r10_v9 (Il2CppMethodInfo)+52]");
													if ((nint)0 == 0)
													{
														num3 = unchecked((nint)6447293664L);
														goto IL_0705;
													}
												}
												((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
												num3 = ((Delegate)tweenCallback).method_ptr;
												goto IL_0705;
												IL_0705:
												object obj7 = 24;
												((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
												tweenConfig.onComplete = tweenCallback;
												MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
												if (_orbTweens == null)
												{
													break;
												}
												if (multiTargetTween != null)
												{
													nint num4 = (nint)orbTweens;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													bool flag5 = obj8 == null;
												}
												orbTweens[flag ? 1u : 0u] = multiTargetTween;
												orbs = _orbs;
												flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
												if (_orbs == null)
												{
													break;
												}
												flag2 = flag;
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

	public override void InternalUpdate()
	{
		//IL_0048: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_01b0: Expected O, but got F4
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		base.InternalUpdate();
		Set4Positions();
		if (!_canSpin)
		{
			return;
		}
		float[] angles = _angles;
		object obj = 0;
		object obj2 = 0;
		float num2 = default(float);
		while ((nint)obj2 < angles.Length)
		{
			float[] angles2 = _angles;
			object obj3 = Time.deltaTime;
			float num = num2 * _angleUnit;
			object obj4 = obj + 1;
			float num3 = num * 1000f;
			num2 = (angles2[obj] = num3 + angles2[obj]);
			angles = _angles;
			obj = obj4;
			obj2 = obj4;
		}
		if (_orbs == null)
		{
			return;
		}
		PhaserSprite[] orbs = _orbs;
		object obj5 = 0;
		object obj6 = 0;
		float2 position = default(float2);
		while ((nint)obj6 < orbs.Length)
		{
			PhaserSprite[] orbs2 = _orbs;
			if ((nint)_positions < 0)
			{
			}
			float[] angles3 = _angles;
			double num4 = Math.Cos(angles3[obj5]);
			float[] angles4 = _angles;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
			object obj7 = obj5 + 1;
			double num5 = Math.Cos(angles4[obj7]);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			PhaserSprite phaserSprite = orbs2[obj5].setPosition(position);
			orbs = _orbs;
			obj5++;
			bool flag = _orbs != null;
			obj6 = obj5;
			if (!flag)
			{
				throw new NullReferenceException();
			}
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01f4: Expected O, but got I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0129: Expected I4, but got F4
		//IL_00ba: Expected F4, but got O
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Seasons1, soundConfig, 2000f, 1, num);
		int num2 = 0;
		float2 float5 = default(float2);
		float num3;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass12_0();
			CS_0024_003C_003E8__locals5._003C_003E4__this = this;
			CS_0024_003C_003E8__locals5.copy = num2;
			WeaponData currentWeaponData = _currentWeaponData;
			object obj = num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj <= 0)
			{
				Projectile projectile = _projectilePool.SpawnAt(float5, this, num2);
				num3 = (float)float5;
			}
			else
			{
				Action onComplete = delegate
				{
					FourSeasonsWeapon fourSeasonsWeapon = CS_0024_003C_003E8__locals5._003C_003E4__this;
					float2 pos = default(float2);
					Projectile projectile2 = fourSeasonsWeapon._projectilePool.SpawnAt(pos, CS_0024_003C_003E8__locals5._003C_003E4__this, CS_0024_003C_003E8__locals5.copy);
				};
				float num4 = (float)num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				num3 = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			num2++;
		}
		while (num2 < 4);
		float num5 = base.PInterval();
		bool flag = _lastFiringInterval == num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018750DEACh\"");
		if (!flag)
		{
			float num6 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_003c: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		bool flag = _orbs == null;
		_isVisible = visible;
		if (flag)
		{
			return;
		}
		PhaserSprite[] orbs = _orbs;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < orbs.Length)
		{
			PhaserSprite[] orbs2 = _orbs;
			PhaserSprite phaserSprite = orbs2[obj2];
			orbs2[obj2].EnsureSpriteRenderer();
			SpriteRenderer spriteRenderer = phaserSprite._spriteRenderer;
			if ((object)phaserSprite._spriteRenderer != null && ((UnityEngine.Object)spriteRenderer).m_CachedPtr != (IntPtr)0)
			{
				phaserSprite._spriteRenderer.enabled = visible;
			}
			orbs = _orbs;
			obj2++;
			obj = obj2;
		}
	}

	public override void Cleanup()
	{
		//IL_0019: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0076->IL016e: Incompatible stack heights: 1 vs 0
		base.Cleanup();
		if (_orbs != null)
		{
			PhaserSprite[] orbs = _orbs;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < orbs.Length)
			{
				object obj3 = orbs[obj];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v10 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v10 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj4, 0f);
				obj++;
				obj2 = obj;
			}
			_orbs = null;
		}
		if (_orbTweens != null)
		{
			MultiTargetTween[] orbTweens = _orbTweens;
			object obj5 = 0;
			object obj6 = 0;
			while ((nint)obj6 < orbTweens.Length)
			{
				orbTweens[obj5].Kill();
				obj5++;
				obj6 = obj5;
			}
			_orbTweens = null;
		}
	}

	private void _003CMakeLevelOne_003Eb__10_0()
	{
		_canSpin = true;
	}
}
