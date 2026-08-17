using System;
using System.Collections.Generic;
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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class SireProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__15_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDrawSymbol_003Eb__15_0()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int index;

		public int detune;

		public SireProjectile _003C_003E4__this;

		internal void _003COnRecycle_003Eb__0()
		{
			float offset = default(float);
			_003C_003E4__this.EraseRandomEnemy(SfxType.MoonBeat, index, detune, offset);
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public int index;

		public int detune;

		public SireProjectile _003C_003E4__this;

		internal void _003COnRecycle_003Eb__1()
		{
			float offset = default(float);
			_003C_003E4__this.EraseRandomEnemy(SfxType.MoonBeat, index, detune, offset);
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public int index;

		public int detune;

		public SireProjectile _003C_003E4__this;

		internal void _003COnRecycle_003Eb__2()
		{
			float offset = default(float);
			_003C_003E4__this.EraseRandomEnemy(SfxType.MoonBeat, index, detune, offset);
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public SireProjectile _003C_003E4__this;

		public int index;

		internal void _003CMoonDamage_003Eb__0(Pickup gem)
		{
			if ((object)gem != null && ((UnityEngine.Object)gem).m_CachedPtr != (IntPtr)0)
			{
				SireProjectile sireProjectile = _003C_003E4__this;
				string[] frames = sireProjectile._frames;
				int num = index % frames.Length;
				gem.SetFrame(frames[num]);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public SireProjectile _003C_003E4__this;

		public int i;

		public Action<Pickup> _003C_003E9__0;

		internal void _003CEraseEnemies_003Eb__0(Pickup gem)
		{
			if ((object)gem != null && ((UnityEngine.Object)gem).m_CachedPtr != (IntPtr)0)
			{
				SireProjectile sireProjectile = _003C_003E4__this;
				string[] frames = sireProjectile._frames;
				int num = i % frames.Length;
				gem.SetFrame(frames[num]);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public SpriteRenderer[] faces;

		public SireProjectile _003C_003E4__this;

		public Transform parent;

		internal void _003CShatter_003Eb__0()
		{
			//IL_0417->IL0358: Incompatible stack heights: 1 vs 0
			//IL_01c6->IL0358: Incompatible stack heights: 1 vs 0
			//IL_01f5->IL0358: Incompatible stack heights: 1 vs 0
			//IL_0217->IL0358: Incompatible stack heights: 1 vs 0
			//IL_0242->IL0383: Incompatible stack heights: 1 vs 0
			//IL_02d2->IL0383: Incompatible stack heights: 4 vs 0
			if (faces == null)
			{
				return;
			}
			SpriteRenderer[] array = faces;
			if (array.Length == 0)
			{
				return;
			}
			if (array.Length > 0)
			{
				SpriteRenderer spriteRenderer = array[0];
				if ((object)array[0] == null || ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				SpriteRenderer[] array2 = faces;
				if (faces != null)
				{
					if (array2.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if ((object)array2[0] != null)
					{
						Transform transform = array2[0].transform;
						if ((object)transform != null)
						{
							Transform transform2 = transform.parent;
							if ((object)transform2 != null)
							{
								Transform transform3 = transform2.transform;
								if ((object)transform3 != null)
								{
									bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
									SireProjectile sireProjectile = _003C_003E4__this;
									if ((object)_003C_003E4__this != null)
									{
										Weapon weapon = sireProjectile._weapon;
										if ((object)sireProjectile._weapon != null)
										{
											VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
											if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)characterController._coherenceSync != null)
											{
												if (characterController._coherenceSync.HasStateAuthority)
												{
													GameManager core = GM.Core;
													bool flag2 = (object)GM.Core == null;
													bool flag3 = core._multiplayer == null;
													if (!core._multiplayer.IsOnlineMultiplayer)
													{
														bool flag4 = (object)GM.Core == null;
														GM.Core.TurnOnVacuum();
														return;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
													SireProjectile sireProjectile2 = _003C_003E4__this;
													bool flag5 = (object)_003C_003E4__this == null;
													Weapon weapon2 = sireProjectile2._weapon;
													bool flag6 = (object)sireProjectile2._weapon == null;
													OnlineStageManager onlineStageManager = default(OnlineStageManager);
													bool flag7 = (object)onlineStageManager == null;
													onlineStageManager.SendTurnOnVaccuum(((Equipment)weapon2)._003COwner_003Ek__BackingField);
												}
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
			throw new IndexOutOfRangeException();
		}

		internal void _003CShatter_003Eb__1()
		{
			//IL_024c: Expected I, but got O
			//IL_0366->IL02d7: Incompatible stack heights: 1 vs 0
			//IL_023f->IL02d7: Incompatible stack heights: 1 vs 0
			//IL_0383->IL02d7: Incompatible stack heights: 1 vs 0
			//IL_02d7->IL0311: Incompatible stack heights: 1 vs 0
			Transform transform = parent;
			if ((object)parent == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)parent != null)
			{
				GameObject gameObject = parent.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: false);
					SireProjectile sireProjectile = _003C_003E4__this;
					if ((object)_003C_003E4__this != null && (object)sireProjectile._renderer != null)
					{
						sireProjectile._renderer.enabled = true;
						SireProjectile sireProjectile2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)sireProjectile2._renderer != null)
						{
							Transform transform2 = sireProjectile2._renderer.transform;
							if ((object)_003C_003E4__this != null && (object)transform2 != null)
							{
								bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
								SireProjectile sireProjectile3 = _003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(sireProjectile3._renderer, 0f, 0.3f);
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 4;
											_ = 0;
										}
									}
									object obj = _003C_003E4__this;
									SireProjectile sireProjectile4 = _003C_003E4__this;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ r8_v8 (Il2CppClass<System.Object>)+370]");
									TweenCallback tweenCallback = new TweenCallback(sireProjectile4, (IntPtr)0);
									if ((object)_003C_003E4__this != null)
									{
										nint num = (nint)obj;
										if (tweenerCore != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
											if ((nint)0 == 0)
											{
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if (tweenerCore != null)
										{
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
	}

	private Transform _playerCachedTransform;

	private ShatterVFX _shatterVfx;

	private MultiTargetTween[] _tweens;

	private float _globalScale;

	private bool _eraseItems;

	protected SireWeapon _trueWeapon;

	private float[] _offsets;

	private string[] _frames;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		_renderer.sprite = sprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I4, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		Weapon weapon2 = _weapon;
		bool flag = (object)_weapon == null;
		SireWeapon trueWeapon = null;
		if (flag)
		{
			goto IL_0231;
		}
		nint num = (nint)typeof(SireWeapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.SireWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v2 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.SireWeapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v2 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v50+FFFFFFF8+v71 @ rax_v46*8]");
			if (0 == (nint)typeof(SireWeapon))
			{
				obj3 = 1;
				goto IL_0240;
			}
		}
		obj3 = 0;
		goto IL_0240;
		IL_0231:
		_trueWeapon = trueWeapon;
		Weapon weapon3 = _weapon;
		Transform playerCachedTransform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
		_playerCachedTransform = playerCachedTransform;
		float num3 = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Extents * 2f;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v19 (UnityEngine.Bounds)+10]");
		float num4 = 0f * 2f;
		if (!(num4 > num3))
		{
			num3 = num4;
		}
		float num5 = num3 * 100f;
		float num6 = num5 * 0.8f;
		float globalScale = num6 * 0.00390625f;
		_globalScale = globalScale;
		Sprite sprite = PentagramManager.GetSprite(PentagramType.Sire);
		_renderer.sprite = sprite;
		Transform transform = _renderer.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		_renderer.enabled = false;
		OnRecycle();
		return;
		IL_0240:
		bool flag3 = obj3 == null;
		trueWeapon = null;
		if (!flag3)
		{
			trueWeapon = (SireWeapon)_weapon;
		}
		goto IL_0231;
	}

	private unsafe void OnRecycle()
	{
		//IL_0043: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0142: Expected I, but got O
		//IL_0158: Expected O, but got I
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01cf: Expected I, but got O
		//IL_06a5: Expected I, but got I8
		//IL_01b8: Expected I, but got I8
		//IL_02dc: Expected I, but got O
		//IL_02f2: Expected O, but got I
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0369: Expected I, but got O
		//IL_0718: Expected I, but got I8
		//IL_0352: Expected I, but got I8
		//IL_0476: Expected I, but got O
		//IL_048c: Expected O, but got I
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_0503: Expected I, but got O
		//IL_078b: Expected I, but got I8
		//IL_04ec: Expected I, but got I8
		//IL_05b9: Expected I, but got O
		//IL_05cf: Expected O, but got I
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Expected O, but got Unknown
		//IL_064b: Expected I, but got O
		//IL_07fe: Expected I, but got I8
		//IL_061e: Expected I, but got I8
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isCullable = false;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MoonStarter, soundConfig, 0f, 10, time);
		int[] array = new int[4] { 0, -500, -200, -500 };
		object obj = 24;
		int num = 0;
		float num2 = 3000f;
		do
		{
			_003C_003Ec__DisplayClass10_0 obj2 = new _003C_003Ec__DisplayClass10_0();
			obj2._003C_003E4__this = this;
			obj2.index = num;
			int num3 = num % array.Length;
			obj2.detune = array[num3];
			TweenCallback tweenCallback = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass10_0._003COnRecycle_003Eb__0);
			((Delegate)tweenCallback).m_target = obj2;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num5;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_067e;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num5 = ((Delegate)tweenCallback).method_ptr;
			goto IL_067e;
			IL_067e:
			float delay = num2 * 0.001f;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			Tween tween = DOVirtual.DelayedCall(delay, tweenCallback, ignoreTimeScale: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween.stringId = "DefaultGameTweenId";
			num++;
			num2 += 750f;
		}
		while (num < 8);
		int num6 = 0;
		do
		{
			_003C_003Ec__DisplayClass10_1 obj5 = new _003C_003Ec__DisplayClass10_1();
			obj5._003C_003E4__this = this;
			obj5.index = num6;
			int num7 = num6 % array.Length;
			obj5.detune = array[num7];
			TweenCallback tweenCallback2 = null;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass10_1._003COnRecycle_003Eb__1);
			((Delegate)tweenCallback2).m_target = obj5;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num9;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num9 = unchecked((nint)6447293664L);
					goto IL_06f1;
				}
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num9 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_06f1;
			IL_06f1:
			float delay2 = num2 * 0.001f;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			Tween tween2 = DOVirtual.DelayedCall(delay2, tweenCallback2, ignoreTimeScale: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween2.stringId = "DefaultGameTweenId";
			num6++;
			num2 += 375f;
		}
		while (num6 < 4);
		int num10 = 0;
		do
		{
			_003C_003Ec__DisplayClass10_2 obj8 = new _003C_003Ec__DisplayClass10_2();
			obj8._003C_003E4__this = this;
			obj8.index = num10;
			int num11 = num10 % array.Length;
			obj8.detune = array[num11];
			TweenCallback tweenCallback3 = null;
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v8 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass10_2._003COnRecycle_003Eb__2);
			((Delegate)tweenCallback3).m_target = obj8;
			((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v8 (Il2CppMethodInfo)+4C]");
			object obj9 = (nint)0 >> 4;
			object obj10 = obj9 & 1;
			nint num13;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v8 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num13 = unchecked((nint)6447293664L);
					goto IL_0764;
				}
			}
			((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
			num13 = ((Delegate)tweenCallback3).method_ptr;
			goto IL_0764;
			IL_0764:
			float delay3 = num2 * 0.001f;
			((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
			Tween tween3 = DOVirtual.DelayedCall(delay3, tweenCallback3, ignoreTimeScale: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween3.stringId = "DefaultGameTweenId";
			num10++;
			num2 += 200f;
		}
		while (num10 < 8);
		TweenCallback tweenCallback4 = null;
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v9 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback4).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback4).method = (nint)__ldftn(SireProjectile.DrawSymbol);
		((Delegate)tweenCallback4).m_target = this;
		((Delegate)tweenCallback4).method_code = (IntPtr)tweenCallback4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v9 (Il2CppMethodInfo)+4C]");
		object obj11 = (nint)0 >> 4;
		object obj12 = obj11 & 1;
		nint num15;
		if (obj12 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v9 (Il2CppMethodInfo)+52]");
			bool flag = (nint)0 == 0;
			num15 = unchecked((nint)6447293664L);
			if (flag)
			{
				goto IL_07d7;
			}
		}
		num15 = ((Delegate)tweenCallback4).method_ptr;
		((Delegate)tweenCallback4).method_code = (IntPtr)((Delegate)tweenCallback4).m_target;
		goto IL_07d7;
		IL_07d7:
		float delay4 = num2 * 0.001f;
		((Delegate)tweenCallback4).extra_arg = unchecked((nint)6447293568L);
		Tween tween4 = DOVirtual.DelayedCall(delay4, tweenCallback4, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween4.stringId = "DefaultGameTweenId";
	}

	public override void InternalUpdate()
	{
		//IL_0027: Expected I, but got O
		//IL_002f: Expected I, but got O
		//IL_003f: Expected O, but got I
		//IL_00bf: Expected O, but got I4
		//IL_007b: Expected O, but got I
		//IL_00b1: Expected O, but got I4
		//IL_0109: Expected O, but got I
		//IL_00f3->IL0154: Incompatible stack heights: 3 vs 0
		//IL_012c->IL0154: Incompatible stack heights: 3 vs 0
		Transform playerCachedTransform = _playerCachedTransform;
		object cachedTransform = _cachedTransform;
		if ((object)_playerCachedTransform == null)
		{
			goto IL_0154;
		}
		bool flag = ((UnityEngine.Object)playerCachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)playerCachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v1 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v1 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_position_Injected((IntPtr)0, ref value);
		Weapon weapon = _weapon;
		if ((object)_weapon == null)
		{
			return;
		}
		nint num = (nint)typeof(SireWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.SireWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.SireWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v37+FFFFFFF8+v463 @ rax_v27*8]");
			if (0 == (nint)typeof(SireWeapon))
			{
				obj3 = 1;
				goto IL_0238;
			}
		}
		obj3 = 0;
		goto IL_0238;
		IL_0238:
		bool flag4 = obj3 == null;
		Weapon weapon2 = null;
		if (!flag4)
		{
			weapon2 = _weapon;
		}
		if ((object)weapon2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v30 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v30 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
			int sortingOrder = ((Renderer)0).sortingOrder;
			if ((object)_renderer != null)
			{
				int sortingOrder2 = sortingOrder + 30;
				_renderer.sortingOrder = sortingOrder2;
				return;
			}
		}
		goto IL_0154;
		IL_0154:
		throw new NullReferenceException();
	}

	private unsafe void EraseRandomEnemy(SfxType sfx, int index = 0, int detune = 0, float offset = 0f)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0309: Expected O, but got I4
		//IL_0316: Expected F4, but got I4
		//IL_0422: Expected O, but got F4
		//IL_0147: Expected O, but got Ref
		//IL_0147: Expected O, but got Ref
		//IL_0539->IL0462: Incompatible stack heights: 1 vs 0
		//IL_018a->IL0462: Incompatible stack heights: 1 vs 0
		//IL_01ac->IL0462: Incompatible stack heights: 1 vs 0
		//IL_01db->IL0462: Incompatible stack heights: 1 vs 0
		//IL_01f8->IL0462: Incompatible stack heights: 1 vs 0
		//IL_0231->IL0462: Incompatible stack heights: 1 vs 0
		//IL_0267->IL0462: Incompatible stack heights: 1 vs 0
		//IL_0289->IL0462: Incompatible stack heights: 1 vs 0
		//IL_02e4->IL02e4: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			GameManager gameMan = weapon._gameMan;
			if ((object)weapon._gameMan != null)
			{
				object playerCachedTransform = _playerCachedTransform;
				if ((object)_playerCachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v5 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_playerCachedTransform);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdi_v5 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
						if ((object)gameMan._stage != null)
						{
							object obj = default(object);
							EnemyController enemyController = gameMan._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
							if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
							{
								goto IL_02e4;
							}
							EnemyController component = enemyController.GetComponent<EnemyController>();
							SireWeapon trueWeapon = _trueWeapon;
							if ((object)_trueWeapon != null)
							{
								Transform transform = enemyController.transform;
								if ((object)transform != null)
								{
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
									if ((object)trueWeapon._explosionPool != null)
									{
										object obj3 = default(object);
										GameObject obj2 = trueWeapon._explosionPool.GetObject((Vector3)(&obj), (Quaternion)(&obj3));
										ExplosionVFX objectComponent = trueWeapon._explosionPool.GetObjectComponent<ExplosionVFX>(obj2);
										SireWeapon trueWeapon2 = _trueWeapon;
										if ((object)_trueWeapon != null && ((Weapon)trueWeapon2)._playerOptions != null)
										{
											PlayerOptionsData config = ((Weapon)trueWeapon2)._playerOptions.Config;
											if (config != null && (object)objectComponent != null)
											{
												objectComponent.SpawnAt(0f, 10f, config._003CFlashingVFXEnabled_003Ek__BackingField);
												if ((object)component != null)
												{
													float2 float5 = component.position;
													GameSessionData gameSessionData = _gameSessionData;
													if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
													{
														float2 float6 = gameSessionData._activeCharacter.position;
														object obj4 = default(object);
														float num = (float)obj4 + 1f;
														object obj5 = default(object);
														float depthPlease = num - (float)obj5;
														objectComponent.SetDepthPlease(depthPlease);
														MoonDamage(component, index);
														goto IL_02e4;
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
		goto IL_0462;
		IL_0462:
		throw new NullReferenceException();
		IL_02e4:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx, soundConfig, 0f, 10, num2);
		Weapon weapon2 = _weapon;
		if ((object)_weapon != null && weapon2._playerOptions != null)
		{
			PlayerOptionsData config2 = weapon2._playerOptions.Config;
			if (config2 != null)
			{
				if (!config2._003CFlashingVFXEnabled_003Ek__BackingField)
				{
					return;
				}
				if ((object)_trueWeapon != null)
				{
					object obj6 = default(object);
					float durationMillis = (float)obj6 / 3f;
					_trueWeapon.SpinSeal(durationMillis, 0.6f, 0.6f, (Projectile)num2);
					return;
				}
			}
		}
		goto IL_0462;
	}

	private void MoonDamage(EnemyController target, int index = 0)
	{
		//IL_01b9: Expected F4, but got I4
		//IL_02f9->IL020d: Incompatible stack heights: 1 vs 0
		//IL_0199->IL020d: Incompatible stack heights: 2 vs 0
		//IL_01dd->IL020d: Incompatible stack heights: 2 vs 0
		//IL_020d->IL025c: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass13_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6._003C_003E4__this = this;
			CS_0024_003C_003E8__locals6.index = index;
			object obj = default(object);
			if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0 || ((object)target._003CResRosary_003Ek__BackingField != null && (nint)obj > 0))
			{
				return;
			}
			bool flag = 66f > target._maxHp;
			float value = 66f;
			if (!flag)
			{
				value = target._maxHp;
			}
			target.GetDamaged(value, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				WeaponData currentWeaponData = weapon._currentWeaponData;
				if (weapon._currentWeaponData != null)
				{
					Transform transform = target.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v24 (UnityEngine.Transform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v24 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						float[] offsets = _offsets;
						if (_offsets != null)
						{
							int num = CS_0024_003C_003E8__locals6.index % offsets.Length;
							bool flag3 = num >= offsets.Length;
							Action<Pickup> callback = delegate(Pickup gem)
							{
								if ((object)gem != null && ((UnityEngine.Object)gem).m_CachedPtr != (IntPtr)0)
								{
									SireProjectile sireProjectile = CS_0024_003C_003E8__locals6._003C_003E4__this;
									string[] frames = sireProjectile._frames;
									int num3 = CS_0024_003C_003E8__locals6.index % frames.Length;
									gem.SetFrame(frames[num3]);
								}
							};
							if ((object)GM.Core != null)
							{
								Vector2 pos = default(Vector2);
								GM.Core.MakeGem(pos, currentWeaponData._003Camount_003Ek__BackingField, callback);
								Weapon weapon2 = _weapon;
								if ((object)_weapon != null)
								{
									float num2 = weapon2._003CStatsInflictedDamage_003Ek__BackingField + target._maxHp;
									weapon2._003CStatsInflictedDamage_003Ek__BackingField = num2;
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

	protected void EraseEnemies()
	{
		//IL_0125: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_014c: Expected F4, but got I
		//IL_015d: Invalid comparison between F4 and I
		//IL_027d: Expected O, but got F4
		//IL_029e: Expected O, but got I4
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals15._003C_003E4__this = this;
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		List<EnemyController> allEnemiesInScreenBounds = gameMan._stage.GetAllEnemiesInScreenBounds(0f);
		CS_0024_003C_003E8__locals15.i = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj5 = default(object);
		Component component = default(Component);
		Component component2 = default(Component);
		float num2 = default(float);
		while (true)
		{
			if (CS_0024_003C_003E8__locals15.i >= allEnemiesInScreenBounds._size)
			{
				return;
			}
			int i = CS_0024_003C_003E8__locals15.i;
			if (CS_0024_003C_003E8__locals15.i >= allEnemiesInScreenBounds._size)
			{
				break;
			}
			EnemyController[] items = allEnemiesInScreenBounds._items;
			EnemyController enemyController = items[i];
			object obj3;
			if ((object)enemyController._003CResRosary_003Ek__BackingField != null)
			{
				bool flag = (nint)obj > 0;
				obj2 = obj;
				obj3 = obj;
				if (flag)
				{
					goto IL_02fd;
				}
			}
			((_003C_003Ec__DisplayClass14_0)(object)allEnemiesInScreenBounds)._003CEraseEnemies_003Eb__0((Pickup)CS_0024_003C_003E8__locals15.i);
			((_003C_003Ec__DisplayClass14_0)(object)allEnemiesInScreenBounds)._003CEraseEnemies_003Eb__0((Pickup)CS_0024_003C_003E8__locals15.i);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v19+1EC]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v19+1EC]");
			if (66f > 0f)
			{
				num = 66f;
			}
			object obj4 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v717 @ rdx_v9+3E8] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Transform transform = component.transform;
			Vector3 vector = transform.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Transform transform2 = component2.transform;
			Vector3 vector2 = transform2.position;
			Action<Pickup> callback = CS_0024_003C_003E8__locals15._003C_003E9__0;
			if (CS_0024_003C_003E8__locals15._003C_003E9__0 == null)
			{
				callback = (CS_0024_003C_003E8__locals15._003C_003E9__0 = delegate(Pickup gem)
				{
					if ((object)gem != null && ((UnityEngine.Object)gem).m_CachedPtr != (IntPtr)0)
					{
						SireProjectile sireProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
						string[] frames = sireProjectile._frames;
						int num5 = CS_0024_003C_003E8__locals15.i % frames.Length;
						gem.SetFrame(frames[num5]);
					}
				});
			}
			GM.Core.MakeGem((Vector2)num2, 1f, callback);
			Weapon weapon2 = _weapon;
			((_003C_003Ec__DisplayClass14_0)(object)allEnemiesInScreenBounds)._003CEraseEnemies_003Eb__0((Pickup)CS_0024_003C_003E8__locals15.i);
			float num3 = weapon2._003CStatsInflictedDamage_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v34+1EC]");
			float num4 = num3 + 0f;
			weapon2._003CStatsInflictedDamage_003Ek__BackingField = num4;
			obj3 = obj2;
			goto IL_02fd;
			IL_02fd:
			int i2 = CS_0024_003C_003E8__locals15.i + 1;
			CS_0024_003C_003E8__locals15.i = i2;
			obj2 = obj3;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void DrawSymbol()
	{
		//IL_0155: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		_trueWeapon.FlashScreen(this);
		_trueWeapon.HideSeal(this);
		_renderer.enabled = true;
		TweenCallback callback = _003C_003Ec._003C_003E9__15_0;
		if (_003C_003Ec._003C_003E9__15_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__15_0 = delegate
			{
			});
		}
		Tween tween = DOVirtual.DelayedCall(0.010000001f, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
		TweenCallback callback2 = delegate
		{
			EraseEnemies();
		};
		Tween tween2 = DOVirtual.DelayedCall(0.1f, callback2, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween2.stringId = "DefaultGameTweenId";
		InitShatterVfx();
		Shatter();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -500f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.MoonFinisher, soundConfig2, 0f, 10, time);
	}

	private unsafe void Shatter()
	{
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_05f9: Expected I, but got O
		//IL_060f: Expected O, but got I
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected O, but got Unknown
		//IL_0686: Expected I, but got O
		//IL_0a04: Expected O, but got I4
		//IL_0a1b: Expected I, but got I8
		//IL_066f: Expected I, but got I8
		//IL_074a: Expected I, but got O
		//IL_0760: Expected O, but got I
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_06ff: Expected O, but got I8
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Expected O, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Expected O, but got Unknown
		//IL_03e0: Expected O, but got I
		//IL_0384: Expected I, but got O
		//IL_07dc: Expected I, but got O
		//IL_0bbc: Expected O, but got I4
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd1: Expected O, but got Unknown
		//IL_0afa: Expected I, but got I8
		//IL_07af: Expected I, but got I8
		//IL_0475: Expected I, but got O
		//IL_04e8: Expected O, but got I4
		//IL_08fb: Expected O, but got F4
		//IL_0929: Expected O, but got I4
		//IL_0b5b: Expected O, but got F4
		//IL_0ba9: Expected O, but got I4
		//IL_0937: Expected O, but got F4
		//IL_09cb: Expected O, but got I4
		//IL_053a: Expected I, but got O
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		//IL_0872->IL07f8: Incompatible stack heights: 1 vs 0
		//IL_0182->IL07f8: Incompatible stack heights: 1 vs 0
		//IL_01c4->IL07f8: Incompatible stack heights: 1 vs 0
		//IL_026d->IL07f8: Incompatible stack heights: 1 vs 0
		//IL_03a8->IL03a8: Incompatible stack heights: 6 vs 5
		//IL_0493->IL0493: Incompatible stack heights: 11 vs 10
		//IL_055d->IL055d: Incompatible stack heights: 14 vs 13
		//IL_05ab->IL09d0: Incompatible stack heights: 14 vs 1
		_003C_003Ec__DisplayClass16_0 obj = new _003C_003Ec__DisplayClass16_0();
		TweenCallback tweenCallback;
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if ((object)_shatterVfx != null)
			{
				SpriteRenderer[] faces = _shatterVfx.Shatter();
				obj.faces = faces;
				SpriteRenderer[] faces2 = obj.faces;
				if (obj.faces != null && (object)faces2[0] != null)
				{
					Transform transform = faces2[0].transform;
					if ((object)transform != null)
					{
						Transform parent = transform.parent;
						obj.parent = parent;
						if ((object)obj.parent != null)
						{
							Transform transform2 = obj.parent.transform;
							if ((object)transform2 != null)
							{
								bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								float value = default(float);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
								if ((object)obj.parent != null)
								{
									GameObject gameObject = obj.parent.gameObject;
									if ((object)gameObject != null)
									{
										gameObject.SetActive(value: true);
										MultiTargetTween[] tweens = _tweens;
										bool flag2 = _tweens == null;
										object obj2 = null;
										Transform transform3 = null;
										if (!flag2)
										{
											while ((nint)transform3 < tweens.Length)
											{
												if (tweens[obj2] != null)
												{
													tweens[obj2].Kill();
												}
												obj2++;
												transform3 = (Transform)obj2;
											}
											SpriteRenderer[] faces3 = obj.faces;
											if (obj.faces != null)
											{
												MultiTargetTween[] tweens2 = new MultiTargetTween[faces3.Length];
												_tweens = tweens2;
												Transform transform4 = null;
												float num2 = default(float);
												float num = num2;
												Transform transform5 = null;
												object obj4 = default(object);
												object obj9 = default(object);
												while (true)
												{
													SpriteRenderer[] faces4 = obj.faces;
													bool flag3 = obj.faces == null;
													if ((nint)transform5 >= faces4.Length)
													{
														break;
													}
													MultiTargetTween[] tweens3 = _tweens;
													TweenConfig tweenConfig = new TweenConfig();
													object[] array = new object[2];
													object faces5 = obj.faces;
													bool flag4 = obj.faces == null;
													Transform obj3 = transform4;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1574 @ rbx_v22 (System.Object)+18]");
													bool flag5 = (nint)obj3 >= 0;
													bool flag6 = array == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1574 @ rbx_v22 (System.Object)+20+v471 @ r14_v14 (UnityEngine.Transform)*8]");
													if ((nint)0 != 0)
													{
														nint num3 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag7 = obj4 == null;
													}
													bool flag8 = array.Length <= 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1574 @ rbx_v22 (System.Object)+20+v471 @ r14_v14 (UnityEngine.Transform)*8]");
													array[0] = 0;
													SpriteRenderer[] faces6 = obj.faces;
													bool flag9 = obj.faces == null;
													bool flag10 = (nint)transform4 >= faces6.Length;
													object obj5 = faces6[(object)transform4];
													bool flag11 = (object)faces6[(object)transform4] == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rbx_v24 (System.Object)+10]");
													bool flag12 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rbx_v24 (System.Object)+10]");
													IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
													Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
													if ((object)transform6 != null)
													{
														Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform6);
														bool flag13 = (object)transform7 == null;
													}
													bool flag14 = array.Length <= 1;
													array[1] = transform6;
													bool flag15 = tweenConfig == null;
													tweenConfig.targets = array;
													tweenConfig.alpha = (float?)(object)1;
													object obj6 = UnityEngine.Random.value;
													float num4 = num * 360f;
													float num5 = num4 - 90f;
													tweenConfig.angle = (float?)(object)1;
													object obj7 = UnityEngine.Random.value;
													float num6 = num5 - 0.5f;
													float num7 = num6 * 1.5f;
													float num8 = num7 * _globalScale;
													float num9 = num8 + num8;
													tweenConfig.localX = (float?)(object)1;
													object obj8 = UnityEngine.Random.value;
													float num10 = num9 - 0.5f;
													float num11 = num10 * 1.2f;
													float num12 = num11 * _globalScale;
													tweenConfig.ease = Ease.InOutSine;
													tweenConfig.duration = 1000f;
													tweenConfig.delay = 150f;
													tweenConfig.repeat = 0;
													num = num12 + num12;
													tweenConfig.yoyo = true;
													tweenConfig.localY = (float?)(object)1;
													MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
													bool flag16 = _tweens == null;
													if (multiTargetTween != null)
													{
														nint num13 = (nint)tweens3;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag17 = obj9 == null;
													}
													bool flag18 = (nint)transform4 >= tweens3.Length;
													tweens3[(object)transform4] = multiTargetTween;
													transform4 = (Transform)(transform4 + 1);
													transform5 = transform4;
												}
												tweenCallback = null;
												nint num14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ r10_v4 (Il2CppMethodInfo)+8]");
												((Delegate)tweenCallback).method_ptr = (IntPtr)0;
												((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_0._003CShatter_003Eb__0);
												((Delegate)tweenCallback).m_target = obj;
												((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ r10_v4 (Il2CppMethodInfo)+4C]");
												object obj10 = (nint)0 >> 4;
												object obj11 = obj10 & 1;
												nint num15;
												if (obj11 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ r10_v4 (Il2CppMethodInfo)+52]");
													if ((nint)0 == 0)
													{
														num15 = unchecked((nint)6447293664L);
														goto IL_09fb;
													}
												}
												((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
												num15 = ((Delegate)tweenCallback).method_ptr;
												goto IL_09fb;
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
		IL_0ae3:
		TweenCallback tweenCallback2;
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		Tween tween = DOVirtual.DelayedCall(2.3000002f, tweenCallback2, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag19 = tween == null;
		return;
		IL_09fb:
		object obj12 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Tween tween2 = DOVirtual.DelayedCall(1.1500001f, tweenCallback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag20 = tween2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag21 = (nint)0 == 0;
		tween2.stringId = "DefaultGameTweenId";
		if (!flag21)
		{
			object obj13 = tween2 + 56;
			object obj14 = obj13 >> 12;
			object obj15 = 6603577472L;
			object obj16 = obj14 & 0x1FFFFF;
			object obj17 = obj16 >> 6;
			object obj18 = obj16 & 0x3F;
			nint num17;
			do
			{
				object obj19 = 1 << (int)obj18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ rdi_v24+462E0+v1954 @ rdx_v46*8]");
				object obj20 = 0 | obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ rdi_v24+462E0+v1954 @ rdx_v46*8]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ rdi_v24+462E0+v1954 @ rdx_v46*8]");
				if (num16 == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ rdi_v24+462E0+v1954 @ rdx_v46*8]");
				num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1951 @ rdi_v24+462E0+v1954 @ rdx_v46*8]");
			}
			while (num17 != 0);
		}
		tweenCallback2 = null;
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r10_v5 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_0._003CShatter_003Eb__1);
		((Delegate)tweenCallback2).m_target = obj;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r10_v5 (Il2CppMethodInfo)+4C]");
		object obj21 = (nint)0 >> 4;
		object obj22 = obj21 & 1;
		nint num19;
		if (obj22 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ r10_v5 (Il2CppMethodInfo)+52]");
			bool flag22 = (nint)0 == 0;
			num19 = unchecked((nint)6447293664L);
			if (flag22)
			{
				goto IL_0ae3;
			}
		}
		num19 = ((Delegate)tweenCallback2).method_ptr;
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		goto IL_0ae3;
	}

	public override void Despawn()
	{
		//IL_00e9: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		MultiTargetTween[] tweens = _tweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < tweens.Length)
		{
			if (tweens[obj] != null)
			{
				tweens[obj].Kill();
			}
			obj++;
			obj2 = obj;
		}
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx != null && ((UnityEngine.Object)shatterVfx).m_CachedPtr != (IntPtr)0)
		{
			_shatterVfx.Destroy();
		}
		base.Despawn();
	}

	private void InitShatterVfx()
	{
		//IL_0096: Expected O, but got I4
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx == null || ((UnityEngine.Object)shatterVfx).m_CachedPtr == (IntPtr)0)
		{
			ShatterVFX.ShatterDetails shatterDetails = new ShatterVFX.ShatterDetails();
			shatterDetails.horizontalCuts = 8;
			shatterDetails.verticalCuts = 8;
			shatterDetails.shatterType = ShatterVFX.ShatterType.Radial;
			shatterDetails.radialSectors = 13;
			shatterDetails.radials = 3;
			shatterDetails.radialCentre = (Vector2)1056964608;
			_ = 1056964608;
			shatterDetails.randomSeed = 61;
			shatterDetails.randomizeAtRunTime = false;
			shatterDetails.randomness = 1f;
			GameObject gameObject = _renderer.gameObject;
			ShatterVFX shatterVfx2 = gameObject.AddComponent<ShatterVFX>();
			_shatterVfx = shatterVfx2;
			ShatterVFX shatterVfx3 = _shatterVfx;
			shatterVfx3.shatterDetails = shatterDetails;
		}
	}

	private void KillTweens()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		MultiTargetTween[] tweens = _tweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
	}

	private static void KillTween(MultiTargetTween[] tweens)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
	}

	public SireProjectile()
	{
		MultiTargetTween[] tweens = new MultiTargetTween[0];
		_tweens = tweens;
		_globalScale = 1f;
		_offsets = new float[4] { -0.08f, 0.08f, -0.016f, 0.016f };
		string[] frames = new string[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_frames = frames;
		base._002Ector();
	}

	private void _003CDrawSymbol_003Eb__15_1()
	{
		EraseEnemies();
	}
}
