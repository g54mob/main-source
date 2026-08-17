using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SpiritTornado2_Projectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__26_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CEraseEnemies_003Eb__26_0()
		{
			GM.Core.TurnOnVacuum();
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public int index;

		public int detune;

		public TP_SpiritTornado2_Projectile _003C_003E4__this;

		internal void _003CDoMoonBeatSequence_003Eb__0()
		{
			float offset = default(float);
			bool scaleVenus = default(bool);
			_003C_003E4__this.EraseRandomEnemies(SfxType.MoonBeat, index, detune, offset, scaleVenus);
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_1
	{
		public int index;

		public int detune;

		public TP_SpiritTornado2_Projectile _003C_003E4__this;

		internal void _003CDoMoonBeatSequence_003Eb__2()
		{
			float offset = default(float);
			bool scaleVenus = default(bool);
			_003C_003E4__this.EraseRandomEnemies(SfxType.MoonBeat, index, detune, offset, scaleVenus);
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_2
	{
		public int index;

		public int detune;

		public TP_SpiritTornado2_Projectile _003C_003E4__this;

		internal void _003CDoMoonBeatSequence_003Eb__3()
		{
			float offset = default(float);
			bool scaleVenus = default(bool);
			_003C_003E4__this.EraseRandomEnemies(SfxType.MoonBeat, index, detune, offset, scaleVenus);
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public Vector2 pos;

		public TP_SpiritTornado2_Projectile _003C_003E4__this;

		internal void _003CEraseEnemies_003Eb__1()
		{
			Vector2 vector = default(Vector2);
			_003C_003E4__this.MakeLittleHeart(vector);
		}

		internal void _003CEraseEnemies_003Eb__2()
		{
			Vector2 vector = default(Vector2);
			_003C_003E4__this.MakeLittleHeart(vector);
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public TP_SpiritTornado2_Projectile _003C_003E4__this;

		public bool canExplode;

		internal void _003CMakeSpiritGem_003Eb__0(Pickup gem)
		{
			//IL_02ca: Expected O, but got I4
			//IL_0134: Expected I, but got O
			//IL_0142: Expected I, but got O
			//IL_0152: Expected O, but got I
			//IL_01d2: Expected O, but got I4
			//IL_018e: Expected O, but got I
			//IL_01c4: Expected O, but got I4
			if ((object)gem == null || ((UnityEngine.Object)gem).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile = _003C_003E4__this;
			string[] gemFrames = tP_SpiritTornado2_Projectile._gemFrames;
			object obj = UnityEngine.Random.RandomRangeInt(0, gemFrames.Length);
			gem.SetFrame(gemFrames[obj]);
			if (gem._003CDisableGet_003Ek__BackingField)
			{
				return;
			}
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile2 = _003C_003E4__this;
			TP_SpiritTornado2_Weapon trueWeapon = tP_SpiritTornado2_Projectile2._trueWeapon;
			float2 position = gem.position;
			float2 position2 = gem.position;
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile3 = _003C_003E4__this;
			float2 pos = default(float2);
			Projectile projectile = trueWeapon._spiritGemProjectilePool.SpawnAt(pos, tP_SpiritTornado2_Projectile3._weapon);
			bool flag = (object)projectile == null;
			ArcadeSprite arcadeSprite = null;
			object obj4;
			if (!flag)
			{
				nint num = (nint)projectile;
				nint num2 = (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v52+FFFFFFF8+v554 @ rax_v48*8]");
					if (0 == (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile))
					{
						obj4 = 1;
						goto IL_02d4;
					}
				}
				obj4 = 0;
				goto IL_02d4;
			}
			goto IL_02fb;
			IL_02d4:
			bool flag2 = obj4 == null;
			arcadeSprite = null;
			if (!flag2)
			{
				arcadeSprite = projectile;
			}
			goto IL_02fb;
			IL_02fb:
			if ((object)arcadeSprite != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
			{
				((ArcadeSprite)gem).CheckRenderer();
				Sprite sprite = ((ArcadeSprite)gem)._spriteRenderer.sprite;
				ArcadeSprite arcadeSprite2 = arcadeSprite.setFrame(sprite);
				_ = canExplode;
			}
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile4 = _003C_003E4__this;
			Weapon weapon = tP_SpiritTornado2_Projectile4._weapon;
			bool flag3 = gem.Vacuum(((Equipment)weapon)._003COwner_003Ek__BackingField);
		}
	}

	private Transform _VenusTransform;

	private Animator _VenusAnimator;

	private const float VenusMeshScale = 1f;

	private Transform _playerCachedTransform;

	private ExplodeFragments _explodeFragments;

	private MultiTargetTween[] _tweens;

	protected TP_SpiritTornado2_Weapon _trueWeapon;

	private readonly float[] _gemOffsets;

	private readonly string[] _gemFrames;

	private readonly int[] _moonBeatDetunes;

	private const float _moonBeatOffset1 = 600f;

	private const float _moonBeatOffset2 = 300f;

	private const float _moonBeatOffset3 = 150f;

	private const WeaponType WType = WeaponType.TP_SPIRITTORNADO2;

	private List<Gem> _gems;

	private bool _storeGemXP;

	private bool _spiritGemsCanExplode;

	private Timer _vacuumTimer;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		Transform venusTransform = _VenusTransform;
		if ((object)_VenusTransform != null && ((UnityEngine.Object)venusTransform).m_CachedPtr != (IntPtr)0)
		{
			Animator component = _VenusTransform.GetComponent<Animator>();
			_VenusAnimator = component;
		}
		ExplodeFragments component2 = GetComponent<ExplodeFragments>();
		_explodeFragments = component2;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_028b: Expected O, but got I4
		//IL_00c8: Expected I4, but got O
		//IL_00ab: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag;
		if ((object)_weapon == null)
		{
			flag = false;
			goto IL_0281;
		}
		nint num = (nint)typeof(TP_SpiritTornado2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v49+FFFFFFF8+v70 @ rax_v44*8]");
			if (0 == (nint)typeof(TP_SpiritTornado2_Weapon))
			{
				obj3 = 1;
				goto IL_0290;
			}
		}
		obj3 = 0;
		goto IL_0290;
		IL_0290:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)_weapon != 0;
		}
		goto IL_0281;
		IL_0281:
		_trueWeapon = (TP_SpiritTornado2_Weapon)flag;
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon3 = _weapon;
		_isCullable = false;
		_storeGemXP = false;
		Transform playerCachedTransform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
		_playerCachedTransform = playerCachedTransform;
		TweenIn();
		DoMoonBeatSequence();
		if (_vacuumTimer != null)
		{
			_vacuumTimer.Cancel();
		}
		if ((object)_trueWeapon != null)
		{
			Action onComplete = delegate
			{
				_storeGemXP = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer vacuumTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_vacuumTimer = vacuumTimer;
			Transform venusTransform = _VenusTransform;
			if ((object)_VenusTransform != null && ((UnityEngine.Object)venusTransform).m_CachedPtr != (IntPtr)0)
			{
				_VenusAnimator.SetTriggerString("Reset");
			}
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		Transform playerCachedTransform = _playerCachedTransform;
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)playerCachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)playerCachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		ConvertGemsToSpiritGems();
	}

	private void ConvertGemsToSpiritGems()
	{
		//IL_00a3: Expected O, but got I4
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		//IL_0240: Expected O, but got I4
		//IL_01b5: Expected F4, but got I
		//IL_01c2: Expected I, but got O
		if (!_storeGemXP)
		{
			return;
		}
		GameManager core = GM.Core;
		IEnumerable<Gem> enumerable = Enumerable.OfType<Gem>(core._gems);
		if (enumerable != null)
		{
			List<object> gems = new List<object>(enumerable);
			_gems = (List<Gem>)(object)gems;
			List<Gem> gems2 = _gems;
			bool flag = (nint)_gems < 0;
			object obj = gems2._size - 1;
			if (flag)
			{
				goto IL_01d4;
			}
			Vector2 pos = default(Vector2);
			while (true)
			{
				List<Gem> gems3 = _gems;
				if ((nint)obj >= gems3._size)
				{
					break;
				}
				Gem[] items = gems3._items;
				ArcadeSprite arcadeSprite = items[obj];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v11 (ArcadeSprite)+FC]");
				bool flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v11 (ArcadeSprite)+FC]");
				if ((nint)0 > (nint)0)
				{
					arcadeSprite.CheckRenderer();
					bool flag3 = CameraExtensions.IsObjectVisible(_mainCamera, arcadeSprite._spriteRenderer);
					flag2 = (flag3 ? 1 : 0) < (false ? 1 : 0);
					if (flag3)
					{
						float2 float5 = arcadeSprite.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v11 (ArcadeSprite)+FC]");
						MakeSpiritGem(pos, 0f, _spiritGemsCanExplode);
						nint num = (nint)arcadeSprite;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v676 @ rax_v33 (Il2CppClass<ArcadeSprite>)+368] (should have been resolved before IL gen)");
					}
				}
				obj--;
				object obj2 = !flag2;
				if (obj2 != null)
				{
					continue;
				}
				goto IL_01d4;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
		IL_01d4:
		GM.Core.TurnOnVacuum();
	}

	private unsafe void TweenIn()
	{
		//IL_0071: Expected O, but got Ref
		//IL_0202: Expected O, but got Ref
		//IL_0472->IL031b: Incompatible stack heights: 3 vs 0
		//IL_008b->IL031b: Incompatible stack heights: 3 vs 0
		//IL_03d9->IL031b: Incompatible stack heights: 3 vs 0
		//IL_03f6->IL031b: Incompatible stack heights: 3 vs 0
		//IL_0438->IL031b: Incompatible stack heights: 3 vs 0
		if ((object)_VenusTransform != null)
		{
			GameObject gameObject = _VenusTransform.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				object venusTransform = _VenusTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v8 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v8 (System.Object)+10]");
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				object venusTransform2 = _VenusTransform;
				bool flag2 = (object)_VenusTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rbx_v9 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rbx_v9 (System.Object)+10]");
				Vector3 value2 = default(Vector3);
				Transform.set_localPosition_Injected((IntPtr)0, ref value2);
				if ((object)_VenusTransform != null)
				{
					_VenusTransform.localEulerAngles = (Vector3)(&value);
					if ((object)_trueWeapon != null)
					{
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_VenusTransform, 1f, 3.0000002f);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 4;
								_ = 0;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore != null)
						{
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveY(_VenusTransform, -1f, 3.0000002f);
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ rax_v46 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 4;
									_ = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore2 != null)
							{
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(_VenusTransform, (Vector3)(&value2), 3.0000002f, RotateMode.LocalAxisAdd);
								if (tweenerCore3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 4;
											_ = 0;
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore3 != null)
								{
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

	private unsafe void DoMoonBeatSequence()
	{
		//IL_0714: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_0107: Expected I, but got O
		//IL_011d: Expected O, but got I
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0194: Expected I, but got O
		//IL_0747: Expected I, but got I8
		//IL_017d: Expected I, but got I8
		//IL_0341: Expected I, but got O
		//IL_0357: Expected O, but got I
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_03ce: Expected I, but got O
		//IL_07ba: Expected I, but got I8
		//IL_03b7: Expected I, but got I8
		//IL_04ea: Expected I, but got O
		//IL_0500: Expected O, but got I
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_0577: Expected I, but got O
		//IL_082d: Expected I, but got I8
		//IL_0560: Expected I, but got I8
		//IL_062d: Expected I, but got O
		//IL_0643: Expected O, but got I
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Expected O, but got Unknown
		//IL_06bf: Expected I, but got O
		//IL_08a0: Expected I, but got I8
		//IL_0692: Expected I, but got I8
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MoonStarter, soundConfig, 0f, 10, time);
		float num2;
		TweenCallback tweenCallback4;
		if ((object)_trueWeapon != null)
		{
			object obj = 24;
			int num = 0;
			num2 = 3000f;
			while (true)
			{
				_003C_003Ec__DisplayClass23_0 obj2 = new _003C_003Ec__DisplayClass23_0();
				obj2._003C_003E4__this = this;
				obj2.index = num;
				int[] moonBeatDetunes = _moonBeatDetunes;
				int num3 = num % moonBeatDetunes.Length;
				obj2.detune = moonBeatDetunes[num3];
				TweenCallback tweenCallback = null;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r10_v4 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass23_0._003CDoMoonBeatSequence_003Eb__0);
				((Delegate)tweenCallback).m_target = obj2;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r10_v4 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				nint num5;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r10_v4 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num5 = unchecked((nint)6447293664L);
						goto IL_0720;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num5 = ((Delegate)tweenCallback).method_ptr;
				goto IL_0720;
				IL_0720:
				float delay = num2 * 0.001f;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				Tween tween = DOVirtual.DelayedCall(delay, tweenCallback, ignoreTimeScale: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				tween.stringId = "DefaultGameTweenId";
				if (num == 0)
				{
					TweenCallback callback = delegate
					{
						//IL_003a: Expected O, but got I4
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Rate = 1f;
						int[] moonBeatDetunes4 = _moonBeatDetunes;
						float detune = (float)moonBeatDetunes4[0] - 1200f;
						soundConfig2.Detune = detune;
						soundConfig2.Volume = (float?)(object)1;
						float time2 = default(float);
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.MoonBeat, soundConfig2, 0f, 10, time2);
					};
					float delay2 = num2 * 0.001f;
					Tween gameId = DOVirtual.DelayedCall(delay2, callback, ignoreTimeScale: false);
					Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
					num++;
					num2 += 600f;
				}
				else
				{
					num++;
					num2 += 600f;
					if (num >= 8)
					{
						break;
					}
				}
			}
			int num6 = 0;
			do
			{
				_003C_003Ec__DisplayClass23_1 obj5 = new _003C_003Ec__DisplayClass23_1();
				obj5._003C_003E4__this = this;
				obj5.index = num6;
				int[] moonBeatDetunes2 = _moonBeatDetunes;
				int num7 = num6 % moonBeatDetunes2.Length;
				obj5.detune = moonBeatDetunes2[num7];
				TweenCallback tweenCallback2 = null;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r10_v6 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass23_1._003CDoMoonBeatSequence_003Eb__2);
				((Delegate)tweenCallback2).m_target = obj5;
				((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r10_v6 (Il2CppMethodInfo)+4C]");
				object obj6 = (nint)0 >> 4;
				object obj7 = obj6 & 1;
				nint num9;
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r10_v6 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num9 = unchecked((nint)6447293664L);
						goto IL_0793;
					}
				}
				((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
				num9 = ((Delegate)tweenCallback2).method_ptr;
				goto IL_0793;
				IL_0793:
				float delay3 = num2 * 0.001f;
				((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
				Tween tween3 = DOVirtual.DelayedCall(delay3, tweenCallback2, ignoreTimeScale: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				tween3.stringId = "DefaultGameTweenId";
				num6++;
				num2 += 300f;
			}
			while (num6 < 4);
			int num10 = 0;
			do
			{
				_003C_003Ec__DisplayClass23_2 obj8 = new _003C_003Ec__DisplayClass23_2();
				obj8._003C_003E4__this = this;
				obj8.index = num10;
				int[] moonBeatDetunes3 = _moonBeatDetunes;
				int num11 = num10 % moonBeatDetunes3.Length;
				obj8.detune = moonBeatDetunes3[num11];
				TweenCallback tweenCallback3 = null;
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r10_v8 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass23_2._003CDoMoonBeatSequence_003Eb__3);
				((Delegate)tweenCallback3).m_target = obj8;
				((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r10_v8 (Il2CppMethodInfo)+4C]");
				object obj9 = (nint)0 >> 4;
				object obj10 = obj9 & 1;
				nint num13;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r10_v8 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num13 = unchecked((nint)6447293664L);
						goto IL_0806;
					}
				}
				((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
				num13 = ((Delegate)tweenCallback3).method_ptr;
				goto IL_0806;
				IL_0806:
				float delay4 = num2 * 0.001f;
				((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
				Tween tween4 = DOVirtual.DelayedCall(delay4, tweenCallback3, ignoreTimeScale: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				tween4.stringId = "DefaultGameTweenId";
				num10++;
				num2 += 150f;
			}
			while (num10 < 8);
			tweenCallback4 = null;
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r10_v9 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback4).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback4).method = (nint)__ldftn(TP_SpiritTornado2_Projectile.StartShatterSequence);
			((Delegate)tweenCallback4).m_target = this;
			((Delegate)tweenCallback4).method_code = (IntPtr)tweenCallback4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r10_v9 (Il2CppMethodInfo)+4C]");
			object obj11 = (nint)0 >> 4;
			object obj12 = obj11 & 1;
			nint num15;
			if (obj12 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r10_v9 (Il2CppMethodInfo)+52]");
				bool flag = (nint)0 == 0;
				num15 = unchecked((nint)6447293664L);
				if (flag)
				{
					goto IL_0879;
				}
			}
			num15 = ((Delegate)tweenCallback4).method_ptr;
			((Delegate)tweenCallback4).method_code = (IntPtr)((Delegate)tweenCallback4).m_target;
			goto IL_0879;
		}
		throw new NullReferenceException();
		IL_0879:
		float delay5 = num2 * 0.001f;
		((Delegate)tweenCallback4).extra_arg = unchecked((nint)6447293568L);
		Tween tween5 = DOVirtual.DelayedCall(delay5, tweenCallback4, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween5.stringId = "DefaultGameTweenId";
	}

	private unsafe void EraseRandomEnemies(SfxType sfx, int index = 0, int detune = 0, float offset = 0f, bool scaleVenus = true)
	{
		//IL_0071: Expected O, but got Ref
		//IL_00a6: Expected O, but got I4
		//IL_05a1: Expected O, but got I4
		//IL_0452: Expected O, but got F4
		//IL_060a: Expected O, but got Ref
		GameManager core = GM.Core;
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Quaternion quaternion2 = default(Quaternion);
		List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&quaternion2), excludeDead: true);
		float num = _weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r15d,xmm0\"");
		object obj = 0;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune2 = default(float);
		soundConfig.Detune = detune2;
		soundConfig.Volume = (float?)(object)1;
		IntPtr intPtr = default(IntPtr);
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)(nint)intPtr, soundConfig, 0f, 10, num2);
		Weapon weapon2 = _weapon;
		PlayerOptions playerOptions = weapon2._playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_05cb;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_05cb;
		IL_05cb:
		if (playerOptionsData._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			object obj2 = default(object);
			float durationMillis = (float)obj2 / 3f;
			_trueWeapon.SpinSeal(durationMillis, 0.6f, 0.6f, (Projectile)num2);
		}
		object obj3 = default(object);
		if (obj3 != null)
		{
			float num3 = default(float);
			Tweener tweener = ShortcutExtensions.DOPunchScale(_VenusTransform, (Vector3)(&num3), 0.25f, 10, num2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tweener.stringId = "DefaultGameTweenId";
		}
	}

	private void MoonDamage(EnemyController target, int index = 0)
	{
		//IL_0202: Expected O, but got F4
		//IL_010f: Invalid comparison between F4 and I4
		//IL_0121: Expected F4, but got I4
		//IL_0167->IL018e: Incompatible stack heights: 1 vs 0
		object obj = default(object);
		if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0 && ((object)target._003CResRosary_003Ek__BackingField == null || (nint)obj <= 0))
		{
			bool flag = !(66f < target._maxHp);
			float value = 66f;
			if (!flag)
			{
				value = target._maxHp;
			}
			target.GetDamaged(value, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
			Transform transform = target.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			float[] gemOffsets = _gemOffsets;
			int num = index % gemOffsets.Length;
			object obj2 = UnityEngine.Random.value;
			EnemyData currentEnemyData = target._currentEnemyData;
			float num2 = (float)obj + 0.5f;
			float num3 = num2 * currentEnemyData._003Cxp_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			float num4 = default(float);
			bool flag3 = !(num4 > 1f);
			float xp = 1f;
			if (!flag3)
			{
				xp = num4;
			}
			Vector2 pos = default(Vector2);
			MakeSpiritGem(pos, xp, canExplode: true);
			Weapon weapon = _weapon;
			float num5 = weapon._003CStatsInflictedDamage_003Ek__BackingField + target._maxHp;
			weapon._003CStatsInflictedDamage_003Ek__BackingField = num5;
		}
	}

	protected unsafe void EraseEnemies(bool makeHearts)
	{
		//IL_0085: Expected F4, but got I4
		//IL_008a: Expected I, but got O
		//IL_00aa: Expected F4, but got I4
		//IL_00af: Expected I, but got O
		//IL_05c8: Expected I, but got O
		//IL_05de: Expected O, but got I
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		//IL_0680: Expected I, but got O
		//IL_07e4: Expected O, but got I4
		//IL_07fb: Expected I, but got I8
		//IL_063e: Expected I, but got I8
		//IL_01c8: Invalid comparison between F4 and I4
		//IL_0232: Expected F4, but got I
		//IL_0243: Invalid comparison between F4 and I
		//IL_029d: Expected O, but got I4
		//IL_02a2: Expected I, but got O
		//IL_02d5: Expected O, but got I4
		//IL_02da: Expected I, but got O
		//IL_0319: Expected O, but got I4
		//IL_031e: Expected I, but got O
		//IL_033b: Expected O, but got I4
		//IL_0357: Expected O, but got I4
		//IL_035c: Expected I, but got O
		//IL_038c: Expected O, but got I4
		//IL_0391: Expected I, but got O
		//IL_03c4: Expected O, but got I4
		//IL_03c9: Expected I, but got O
		//IL_040e: Expected O, but got F4
		//IL_043a: Expected I, but got O
		//IL_0534: Expected O, but got I4
		//IL_0564: Expected O, but got I4
		//IL_05a4: Expected O, but got I4
		//IL_050b: Expected I, but got O
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			GameManager gameMan = weapon._gameMan;
			if ((object)weapon._gameMan != null && (object)gameMan._stage != null)
			{
				List<EnemyController> allEnemiesInScreenBounds = gameMan._stage.GetAllEnemiesInScreenBounds(0f);
				bool flag = allEnemiesInScreenBounds == null;
				float num = 0f;
				nint num2 = unchecked((nint)null);
				if (!flag)
				{
					bool flag2 = false;
					num = 0f;
					num2 = unchecked((nint)null);
					bool flag3 = false;
					float num3 = default(float);
					object obj = default(object);
					object obj2 = default(object);
					Component component = default(Component);
					Component component2 = default(Component);
					Vector2 pos = default(Vector2);
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					object obj6 = default(object);
					object obj9 = default(object);
					float num4 = default(float);
					while (true)
					{
						float num5;
						bool flag12;
						if ((flag3 ? 1 : 0) < allEnemiesInScreenBounds._size)
						{
							_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass26_0();
							if (CS_0024_003C_003E8__locals5 == null)
							{
								break;
							}
							CS_0024_003C_003E8__locals5._003C_003E4__this = this;
							if ((flag2 ? 1 : 0) < allEnemiesInScreenBounds._size)
							{
								EnemyController[] items = allEnemiesInScreenBounds._items;
								if (allEnemiesInScreenBounds._items == null)
								{
									break;
								}
								if ((flag2 ? 1 : 0) < items.Length)
								{
									EnemyController enemyController = items[flag2 ? 1u : 0u];
									if ((object)items[flag2 ? 1u : 0u] == null)
									{
										break;
									}
									if ((object)enemyController._003CResRosary_003Ek__BackingField != null)
									{
										bool flag4 = num3 > 0f;
										num4 = num3;
										num5 = num3;
										if (flag4)
										{
											goto IL_072f;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									if (obj == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v57+1EC]");
									num = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v57+1EC]");
									if (66f > 0f)
									{
										num = 66f;
									}
									if (obj2 == null)
									{
										break;
									}
									object obj3 = obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1195 @ rdx_v18+3E8] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									bool flag5 = (object)component == null;
									object obj4 = 0;
									num2 = unchecked((nint)null);
									if (flag5)
									{
										break;
									}
									Transform transform = component.transform;
									bool flag6 = (object)transform == null;
									obj4 = 0;
									num2 = unchecked((nint)null);
									if (flag6)
									{
										break;
									}
									Vector3 vector = transform.position;
									float[] gemOffsets = _gemOffsets;
									bool flag7 = _gemOffsets == null;
									obj4 = 0;
									num2 = unchecked((nint)null);
									if (flag7)
									{
										break;
									}
									object obj5 = (flag2 ? 1 : 0) % gemOffsets.Length;
									bool flag8 = (nint)obj5 >= gemOffsets.Length;
									obj4 = 0;
									num2 = unchecked((nint)null);
									if (!flag8)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										bool flag9 = (object)component2 == null;
										obj4 = 0;
										num2 = unchecked((nint)null);
										if (flag9)
										{
											break;
										}
										Transform transform2 = component2.transform;
										bool flag10 = (object)transform2 == null;
										obj4 = 0;
										num2 = unchecked((nint)null);
										if (flag10)
										{
											break;
										}
										float num6 = gemOffsets[obj5] + vector.x;
										Vector3 vector2 = transform2.position;
										CS_0024_003C_003E8__locals5.pos = (Vector2)num6;
										num = vector2.y + 0.016f;
										bool flag11 = !makeHearts;
										num2 = unchecked((nint)null);
										if (!flag11)
										{
											MakeLittleHeart(pos);
											Action onComplete = delegate
											{
												Vector2 pos2 = default(Vector2);
												CS_0024_003C_003E8__locals5._003C_003E4__this.MakeLittleHeart(pos2);
											};
											Timer timer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
											Action onComplete2 = delegate
											{
												Vector2 pos2 = default(Vector2);
												CS_0024_003C_003E8__locals5._003C_003E4__this.MakeLittleHeart(pos2);
											};
											Timer timer2 = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
											flag12 = false;
											num4 = 0.5f;
											num2 = unchecked((nint)null);
										}
										Weapon weapon2 = _weapon;
										bool flag13 = (object)_weapon == null;
										obj4 = 0;
										if (flag13)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										bool flag14 = obj6 == null;
										obj4 = 0;
										if (flag14)
										{
											break;
										}
										float num7 = weapon2._003CStatsInflictedDamage_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v70+1EC]");
										float num8 = num7 + 0f;
										weapon2._003CStatsInflictedDamage_003Ek__BackingField = num8;
										obj4 = 0;
										num5 = num4;
										goto IL_072f;
									}
								}
								throw new IndexOutOfRangeException();
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							goto IL_0811;
						}
						TweenCallback callback = _003C_003Ec._003C_003E9__26_0;
						if (_003C_003Ec._003C_003E9__26_0 != null)
						{
							goto IL_0685;
						}
						TweenCallback tweenCallback = null;
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r10_v6 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec._003CEraseEnemies_003Eb__26_0);
						((Delegate)tweenCallback).m_target = _003C_003Ec._003C_003E9;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r10_v6 (Il2CppMethodInfo)+4C]");
						object obj7 = (nint)0 >> 4;
						object obj8 = obj7 & 1;
						nint num10;
						if (obj8 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r10_v6 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num10 = unchecked((nint)6447293664L);
								goto IL_07db;
							}
						}
						else if (_003C_003Ec._003C_003E9 == null)
						{
							goto IL_0811;
						}
						num10 = ((Delegate)tweenCallback).method_ptr;
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						goto IL_07db;
						IL_0811:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
						throw obj9;
						IL_0685:
						Tween tween = DOVirtual.DelayedCall(0.1f, callback);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag15 = tween == null;
						flag12 = false;
						num4 = 0.1f;
						num2 = 1;
						if (flag15)
						{
							break;
						}
						tween.stringId = "DefaultGameTweenId";
						return;
						IL_07db:
						object obj10 = 24;
						((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
						_003C_003Ec._003C_003E9__26_0 = tweenCallback;
						callback = tweenCallback;
						goto IL_0685;
						IL_072f:
						flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
						num4 = num5;
						flag3 = flag2;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeLittleHeart(Vector2 pos)
	{
		//IL_005a: Expected I, but got O
		//IL_0062: Expected I, but got O
		//IL_0072: Expected O, but got I
		//IL_00f2: Expected O, but got I4
		//IL_00ae: Expected O, but got I
		//IL_00e4: Expected O, but got I4
		Pickup pickup;
		object obj3;
		if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TP_SOULSTEAL_LITTLEHEART))
		{
			pickup = PickupManager.CreatePickup(pos, ItemType.TP_SOULSTEAL_LITTLEHEART);
			nint num = (nint)typeof(Pickup_TP_SoulStealLittleHeart);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_TP_SoulStealLittleHeart>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_TP_SoulStealLittleHeart>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rcx_v17+FFFFFFF8+v263 @ rcx_v9*8]");
				if (0 == (nint)typeof(Pickup_TP_SoulStealLittleHeart))
				{
					obj3 = 1;
					goto IL_016a;
				}
			}
			obj3 = 0;
			goto IL_016a;
		}
		throw new NullReferenceException();
		IL_016a:
		bool flag = obj3 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		pickup2.GoToPlayer = true;
		Weapon weapon = _weapon;
		pickup2._targetPlayer = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		pickup2.Time = 1.6518f;
	}

	private void MakeSpiritGem(Vector2 pos, float xp, bool canExplode)
	{
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass28_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.canExplode = canExplode;
		Weapon weapon = _weapon;
		if (!weapon._isVisible)
		{
			return;
		}
		TP_SpiritTornado2_Weapon trueWeapon = _trueWeapon;
		float num = xp + trueWeapon._003CStoredXP_003Ek__BackingField;
		trueWeapon._003CStoredXP_003Ek__BackingField = num;
		Action<Pickup> callback = delegate(Pickup gem)
		{
			//IL_02ca: Expected O, but got I4
			//IL_0134: Expected I, but got O
			//IL_0142: Expected I, but got O
			//IL_0152: Expected O, but got I
			//IL_01d2: Expected O, but got I4
			//IL_018e: Expected O, but got I
			//IL_01c4: Expected O, but got I4
			if ((object)gem == null || ((UnityEngine.Object)gem).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile = CS_0024_003C_003E8__locals7._003C_003E4__this;
			string[] gemFrames = tP_SpiritTornado2_Projectile._gemFrames;
			object obj = UnityEngine.Random.RandomRangeInt(0, gemFrames.Length);
			gem.SetFrame(gemFrames[obj]);
			if (gem._003CDisableGet_003Ek__BackingField)
			{
				return;
			}
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
			TP_SpiritTornado2_Weapon trueWeapon2 = tP_SpiritTornado2_Projectile2._trueWeapon;
			float2 float5 = gem.position;
			float2 float6 = gem.position;
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile3 = CS_0024_003C_003E8__locals7._003C_003E4__this;
			float2 pos2 = default(float2);
			Projectile projectile = trueWeapon2._spiritGemProjectilePool.SpawnAt(pos2, tP_SpiritTornado2_Projectile3._weapon);
			bool flag = (object)projectile == null;
			ArcadeSprite arcadeSprite = null;
			object obj4;
			if (!flag)
			{
				nint num2 = (nint)projectile;
				nint num3 = (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v52+FFFFFFF8+v554 @ rax_v48*8]");
					if (0 == (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile))
					{
						obj4 = 1;
						goto IL_02d4;
					}
				}
				obj4 = 0;
				goto IL_02d4;
			}
			goto IL_02fb;
			IL_02d4:
			bool flag2 = obj4 == null;
			arcadeSprite = null;
			if (!flag2)
			{
				arcadeSprite = projectile;
			}
			goto IL_02fb;
			IL_02fb:
			if ((object)arcadeSprite != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
			{
				((ArcadeSprite)gem).CheckRenderer();
				Sprite sprite = ((ArcadeSprite)gem)._spriteRenderer.sprite;
				ArcadeSprite arcadeSprite2 = arcadeSprite.setFrame(sprite);
				_ = CS_0024_003C_003E8__locals7.canExplode;
			}
			TP_SpiritTornado2_Projectile tP_SpiritTornado2_Projectile4 = CS_0024_003C_003E8__locals7._003C_003E4__this;
			Weapon weapon2 = tP_SpiritTornado2_Projectile4._weapon;
			bool flag3 = gem.Vacuum(((Equipment)weapon2)._003COwner_003Ek__BackingField);
		};
		GM.Core.MakeGem(pos, 0f, callback);
	}

	private int GetEnemyXPValue(EnemyController enemy)
	{
		//IL_0084: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		EnemyData currentEnemyData = enemy._currentEnemyData;
		object obj2 = default(object);
		float num = (float)obj2 + 0.5f;
		float num2 = num * currentEnemyData._003Cxp_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		int num3 = default(int);
		bool flag = num3 <= 1;
		int result = 1;
		if (!flag)
		{
			result = num3;
		}
		return result;
	}

	private unsafe void StartShatterSequence()
	{
		//IL_01a0: Expected O, but got I4
		//IL_01a9: Expected O, but got I4
		//IL_01b1: Expected F4, but got O
		//IL_01b9: Expected O, but got Ref
		//IL_037d: Expected I, but got O
		//IL_0393: Expected O, but got I
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_040d: Expected O, but got I4
		//IL_0415: Expected F4, but got O
		//IL_0442: Expected I, but got O
		//IL_05ca: Expected O, but got I4
		//IL_05e1: Expected I, but got I8
		//IL_03f3: Expected I, but got I8
		//IL_0648: Expected O, but got I4
		//IL_049e: Expected O, but got I4
		TP_SpiritTornado2_Weapon trueWeapon = _trueWeapon;
		TweenCallback tweenCallback;
		object obj2;
		float num;
		List<Projectile> spawnedProjectiles;
		bool flag2;
		if ((object)_trueWeapon != null)
		{
			_trueWeapon.FlashScreen(this);
			trueWeapon = _trueWeapon;
			bool flag = (object)_trueWeapon == null;
			flag2 = false;
			if (!flag)
			{
				_trueWeapon.HideSeal(this);
				if (_vacuumTimer != null)
				{
					_vacuumTimer.Cancel();
				}
				Animator venusAnimator = _VenusAnimator;
				bool flag3 = (object)_VenusAnimator == null;
				flag2 = false;
				trueWeapon = (TP_SpiritTornado2_Weapon)(object)typeof(UnityEngine.Object);
				if (!flag3)
				{
					bool flag4 = ((UnityEngine.Object)venusAnimator).m_CachedPtr == (IntPtr)0;
					flag2 = false;
					trueWeapon = (TP_SpiritTornado2_Weapon)(object)typeof(UnityEngine.Object);
					if (!flag4)
					{
						bool flag5 = (object)_VenusAnimator == null;
						flag2 = false;
						trueWeapon = (TP_SpiritTornado2_Weapon)(object)_VenusAnimator;
						if (flag5)
						{
							goto IL_04c4;
						}
						_VenusAnimator.SetTriggerString("Open");
						flag2 = false;
						trueWeapon = (TP_SpiritTornado2_Weapon)(object)_VenusAnimator;
					}
				}
				_spiritGemsCanExplode = false;
				Weapon weapon = _weapon;
				if ((object)_weapon != null)
				{
					spawnedProjectiles = weapon._spawnedProjectiles;
					if (weapon._spawnedProjectiles != null)
					{
						List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj = 0;
							obj2 = 0;
							num = (float)spawnedProjectiles;
							List<Projectile>.Enumerator enumerator2 = (List<Projectile>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						tweenCallback = null;
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r10_v5 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(TP_SpiritTornado2_Projectile._003CStartShatterSequence_003Eb__30_0);
						((Delegate)tweenCallback).m_target = this;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r10_v5 (Il2CppMethodInfo)+4C]");
						object obj3 = (nint)0 >> 4;
						object obj4 = obj3 & 1;
						nint num3;
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r10_v5 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num3 = unchecked((nint)6447293664L);
								goto IL_05c1;
							}
						}
						else
						{
							bool flag6 = (object)this == null;
							obj2 = 0;
							num = (float)spawnedProjectiles;
							if (flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
								object obj5 = default(object);
								throw obj5;
							}
						}
						num3 = ((Delegate)tweenCallback).method_ptr;
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						goto IL_05c1;
					}
				}
			}
		}
		goto IL_04c4;
		IL_04c4:
		throw new NullReferenceException();
		IL_05c1:
		object obj6 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Tween tween = DOVirtual.DelayedCall(0.1f, tweenCallback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
			trueWeapon = (TP_SpiritTornado2_Weapon)(object)"DefaultGameTweenId";
		}
		bool flag7 = tween == null;
		obj2 = 0;
		num = 0.1f;
		spawnedProjectiles = null;
		flag2 = false;
		if (!flag7)
		{
			tween.stringId = "DefaultGameTweenId";
			Shatter();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MoonFinisher, soundConfig, 0f, 10, time);
			return;
		}
		goto IL_04c4;
	}

	private void Shatter()
	{
		//IL_02c6: Expected O, but got I4
		//IL_02cf: Expected O, but got I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_021a: Expected I, but got O
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
		Weapon weapon = _weapon;
		if (!weapon._isVisible)
		{
			return;
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_VenusTransform, 1.5f, 2.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
		TweenCallback callback = delegate
		{
			//IL_00de: Expected O, but got I4
			//IL_011f: Expected O, but got I4
			//IL_0169: Expected O, but got I4
			//IL_01b3: Expected O, but got I4
			GameObject gameObject = _VenusTransform.gameObject;
			gameObject.SetActive(value: false);
			ExplodeFragments explodeFragments = _explodeFragments;
			if ((object)_explodeFragments != null && ((UnityEngine.Object)explodeFragments).m_CachedPtr != (IntPtr)0)
			{
				_explodeFragments.Explode();
			}
			_storeGemXP = false;
			_trueWeapon.FlashScreen(this);
			EraseEnemies(makeHearts: false);
			_trueWeapon.MakeBigGem();
			DespawnAllSpiritGems();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Glass09, soundConfig, 0f, 10, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Glass20, soundConfig2, 0f, 10, time);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig3, 0f, 10, time);
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Volume = (float?)(object)1;
			soundConfig4.Rate = 1f;
			soundConfig4.Detune = 1200f;
			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig4, 0f, 10, time);
		};
		Tween tween = DOVirtual.DelayedCall(2.5f, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
		TweenCallback callback2 = delegate
		{
			ExplodeFragments explodeFragments = _explodeFragments;
			if ((object)_explodeFragments != null && ((UnityEngine.Object)explodeFragments).m_CachedPtr != (IntPtr)0)
			{
				_explodeFragments.ResetFragments();
			}
		};
		Tween tween2 = DOVirtual.DelayedCall(4.5f, callback2, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tween2 != null && tween2._003Cactive_003Ek__BackingField)
		{
			tween2.onComplete = onComplete;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween2.stringId = "DefaultGameTweenId";
	}

	private void DespawnAllSpiritGems()
	{
		//IL_0018: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0411: Expected O, but got I4
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_0115: Expected I, but got O
		//IL_0122: Expected I, but got O
		//IL_0138: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_04cc: Expected O, but got I4
		//IL_02b0: Expected I, but got O
		//IL_02c8: Expected O, but got I
		//IL_0304: Expected O, but got I
		//IL_0341: Expected O, but got I
		//IL_0351: Expected O, but got I
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_039e: Expected O, but got I4
		//IL_049f: Expected I, but got O
		List<Gem> gems = _gems;
		bool flag = (nint)_gems < 0;
		object obj = gems._size - 1;
		if (flag)
		{
			goto IL_015c;
		}
		nint num2 = default(nint);
		nint num = num2;
		nint num4 = default(nint);
		nint num3 = num4;
		while (true)
		{
			List<Gem> gems2 = _gems;
			if ((nint)obj >= gems2._size)
			{
				break;
			}
			Gem[] items = gems2._items;
			ArcadeSprite arcadeSprite = items[obj];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v11 (ArcadeSprite)+FC]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187176BAEh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v11 (ArcadeSprite)+FC]");
			if ((nint)0 == 0)
			{
				arcadeSprite.CheckRenderer();
				bool flag3 = CameraExtensions.IsObjectVisible(_mainCamera, arcadeSprite._spriteRenderer);
				flag2 = (flag3 ? 1 : 0) < (false ? 1 : 0);
				bool flag4 = !flag3;
				num = unchecked((nint)null);
				num3 = (nint)arcadeSprite._spriteRenderer;
				if (!flag4)
				{
					nint num5 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rax_v39 (Il2CppClass<ArcadeSprite>)+370]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v563 @ rax_v39 (Il2CppClass<ArcadeSprite>)+368] (should have been resolved before IL gen)");
					num = unchecked((nint)null);
				}
			}
			obj--;
			object obj2 = !flag2;
			num2 = num;
			num4 = num3;
			if (obj2 != null)
			{
				continue;
			}
			goto IL_015c;
		}
		goto IL_03e6;
		IL_03e6:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_015c:
		Weapon weapon = _weapon;
		List<Projectile> spawnedProjectiles = weapon._spawnedProjectiles;
		bool flag5 = (nint)weapon._spawnedProjectiles < 0;
		object obj3 = spawnedProjectiles._size - 1;
		if (flag5)
		{
			return;
		}
		object obj6 = default(object);
		object obj8 = default(object);
		object obj9 = default(object);
		object obj11 = default(object);
		while (true)
		{
			Weapon weapon2 = _weapon;
			List<Projectile> spawnedProjectiles2 = weapon2._spawnedProjectiles;
			if ((nint)obj3 >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items2 = spawnedProjectiles2._items;
			Projectile projectile = items2[obj3];
			object obj4 = projectile + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			num4 = 1;
			object obj7 = obj8 - obj9;
			bool flag6 = (nint)obj7 < 0;
			if (obj8 == obj9)
			{
				Weapon weapon3 = _weapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				nint num6 = (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile);
				object obj10 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v21+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v21+C8]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v19+FFFFFFF8+v117 @ rcx_v18*8]");
					if (0 == (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v21+C8]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritTornado2_SpiritGemProjectile>)+130]");
						object obj15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v22+FFFFFFF8+v635 @ rcx_v20*8]");
						object obj16 = 0 - typeof(TP_SpiritTornado2_SpiritGemProjectile);
						bool flag7 = obj16 == null;
						flag6 = (flag7 ? 1 : 0) < (false ? 1 : 0);
						bool flag8 = !flag7;
						object obj17 = 0;
						if (!flag8)
						{
							obj17 = obj11;
						}
						object obj18 = obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rax_v24+370]");
						num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v649 @ rax_v24+368] (should have been resolved before IL gen)");
						num2 = (nint)typeof(TP_SpiritTornado2_SpiritGemProjectile);
						goto IL_04b3;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_04b3;
			IL_04b3:
			obj3--;
			object obj19 = !flag6;
			if (obj19 == null)
			{
				return;
			}
		}
		goto IL_03e6;
	}

	public override void Despawn()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
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
		if (_vacuumTimer != null)
		{
			_vacuumTimer.Cancel();
		}
		base.Despawn();
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

	public TP_SpiritTornado2_Projectile()
	{
		MultiTargetTween[] tweens = new MultiTargetTween[0];
		_tweens = tweens;
		_gemOffsets = new float[4] { -0.08f, 0.08f, -0.016f, 0.016f };
		string[] gemFrames = new string[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_gemFrames = gemFrames;
		_moonBeatDetunes = new int[4] { 700, 200, 400, -500 };
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__19_0()
	{
		_storeGemXP = true;
	}

	private void _003CDoMoonBeatSequence_003Eb__23_1()
	{
		//IL_003a: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		int[] moonBeatDetunes = _moonBeatDetunes;
		float detune = (float)moonBeatDetunes[0] - 1200f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MoonBeat, soundConfig, 0f, 10, time);
	}

	private void _003CStartShatterSequence_003Eb__30_0()
	{
		EraseEnemies(makeHearts: true);
	}

	private void _003CShatter_003Eb__31_0()
	{
		//IL_00de: Expected O, but got I4
		//IL_011f: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		GameObject gameObject = _VenusTransform.gameObject;
		gameObject.SetActive(value: false);
		ExplodeFragments explodeFragments = _explodeFragments;
		if ((object)_explodeFragments != null && ((UnityEngine.Object)explodeFragments).m_CachedPtr != (IntPtr)0)
		{
			_explodeFragments.Explode();
		}
		_storeGemXP = false;
		_trueWeapon.FlashScreen(this);
		EraseEnemies(makeHearts: false);
		_trueWeapon.MakeBigGem();
		DespawnAllSpiritGems();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Glass09, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Glass20, soundConfig2, 0f, 10, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig3, 0f, 10, time);
		SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
		soundConfig4.Volume = (float?)(object)1;
		soundConfig4.Rate = 1f;
		soundConfig4.Detune = 1200f;
		PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.PentagramSFX, soundConfig4, 0f, 10, time);
	}

	private void _003CShatter_003Eb__31_1()
	{
		ExplodeFragments explodeFragments = _explodeFragments;
		if ((object)_explodeFragments != null && ((UnityEngine.Object)explodeFragments).m_CachedPtr != (IntPtr)0)
		{
			_explodeFragments.ResetFragments();
		}
	}
}
