using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerMortaccio : CharacterController
{
	private bool _isMorphed;

	private int _amountBonus;

	private int _armorBonus;

	private int _maxHpBonus;

	private PhaserSprite _sparkSprite;

	private PhaserSprite _ringSprite;

	private PhaserSprite _burstSprite;

	private PhaserSprite _darkSprite;

	private PhaserSprite _head;

	private SpriteAnimation _burstSpriteAnim;

	private SpriteAnimation _headSpriteAnim;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private MultiTargetTween _darkTween;

	private readonly float2 _headOffset;

	private readonly float2 _invHeadOffset;

	private bool _morphSpritesHidden;

	public bool IsMorphed => _isMorphed;

	protected override void OnUpdate()
	{
		//IL_0196->IL0130: Incompatible stack heights: 1 vs 0
		//IL_008f->IL0130: Incompatible stack heights: 1 vs 0
		//IL_01b5->IL0130: Incompatible stack heights: 1 vs 0
		//IL_0105->IL0130: Incompatible stack heights: 1 vs 0
		//IL_0130->IL0137: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		if (!_isMorphed)
		{
			return;
		}
		base.angle = 0f;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			float2 float5 = base.position;
			float2 float6 = base.position;
			if ((object)_CharacterRenderer != null)
			{
				bool flag2 = _CharacterRenderer.flipX;
				if ((object)_head != null)
				{
					PhaserSprite phaserSprite = _head.setFlipX(flag2);
					if (flag2)
					{
					}
					if ((object)_head != null)
					{
						float2 float7 = default(float2);
						PhaserSprite phaserSprite2 = _head.setPosition(float7);
						int num = base.Depth;
						if ((object)_head != null)
						{
							int num2 = num + 1;
							PhaserSprite phaserSprite3 = _head.setDepth(num2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void LevelUp()
	{
		base.LevelUp();
		if (base._level < 80)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			if (config3.HasCollectedItem(ItemType.RELIC_MALACHITE))
			{
				Morph();
			}
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_009c: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_031c: Expected O, but got I4
		//IL_039f: Expected O, but got I4
		//IL_052a: Expected O, but got I4
		base.MakeLevelOne();
		PhaserSprite sparkSprite = _sparkSprite;
		_isMorphed = false;
		_armorBonus = 2;
		_amountBonus = 1;
		_maxHpBonus = 100;
		Vector2 pos = default(Vector2);
		if ((object)_sparkSprite == null || ((UnityEngine.Object)sparkSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			float2 float5 = base.position;
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "blurredSharpStar");
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_06a8;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserSprite phaserSprite5 = phaserSprite4.setDepth(renderer.height);
			GameObject gameObject = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject).SetName("sparkSprite");
			_sparkSprite = phaserSprite5;
		}
		PhaserSprite ringSprite = _ringSprite;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			float2 float6 = base.position;
			PhaserSprite phaserSprite6 = instance2.AddPhaserSprite(pos, "vfx", "disc");
			PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
			PhaserSprite phaserSprite8 = phaserSprite7.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite9 = phaserSprite8.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_06a8;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			PhaserSprite phaserSprite10 = phaserSprite9.setDepth(renderer2.height);
			GameObject gameObject2 = phaserSprite10.gameObject;
			((UnityEngine.Object)gameObject2).SetName("ringSprite");
			_ringSprite = phaserSprite10;
		}
		PhaserSprite darkSprite = _darkSprite;
		if ((object)_darkSprite != null && ((UnityEngine.Object)darkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_044e;
		}
		PhaserWorld instance3 = PhaserWorld.Instance;
		float2 float7 = base.position;
		PhaserSprite phaserSprite11 = instance3.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite12 = phaserSprite11.setAlpha(0f);
		PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			if ((object)GM.Core != null)
			{
				float xScale = renderer3.width * 100f;
				PhaserSprite phaserSprite14 = phaserSprite13.setScale(xScale, (float?)(object)1);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer4 = s_scene4._renderer;
					float num = renderer4.height - 1f;
					PhaserSprite component = phaserSprite14.setDepth(num);
					PhaserSprite phaserSprite15 = RenderingExtensions.SetScrollFactor(component, 0f);
					GameObject gameObject3 = phaserSprite15.gameObject;
					((UnityEngine.Object)gameObject3).SetName("darkSprite");
					_darkSprite = phaserSprite15;
					goto IL_044e;
				}
			}
		}
		goto IL_06a8;
		IL_06a8:
		throw new NullReferenceException();
		IL_0658:
		int num2 = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Burst", 1, 6, "vfx", num2);
		bool flag = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_burstSpriteAnim.AddAnimation("enter", animationFrames, 30, (byte)num2 != 0, flag, onComplete, autoSetAnimation);
		return;
		IL_044e:
		PhaserSprite burstSprite = _burstSprite;
		if ((object)_burstSprite == null || ((UnityEngine.Object)burstSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance4 = PhaserWorld.Instance;
			if ((object)GM.Core != null && (object)GM.Core != null)
			{
				PhaserSprite phaserSprite16 = instance4.AddPhaserSprite(pos, "vfx", "Burst1");
				PhaserSprite phaserSprite17 = phaserSprite16.setAlpha(0f);
				PhaserSprite phaserSprite18 = phaserSprite17.setScale(10f, (float?)(object)0);
				PhaserSprite phaserSprite19 = phaserSprite18.setBlendMode(BlendMode.Add);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene5 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer5 = s_scene5._renderer;
					PhaserSprite component2 = phaserSprite19.setDepth(renderer5.height);
					PhaserSprite phaserSprite20 = RenderingExtensions.SetScrollFactor(component2, 0f);
					GameObject gameObject4 = phaserSprite20.gameObject;
					((UnityEngine.Object)gameObject4).SetName("burstSprite");
					PhaserSprite burstSprite2 = phaserSprite20.setTint(65280u, 255u, 16776960u, (uint)num2, flag ? BlendMode.Add : BlendMode.Normal);
					_burstSprite = burstSprite2;
					PhaserSprite burstSprite3 = _burstSprite;
					GameObject gameObject5 = burstSprite3._spriteRenderer.gameObject;
					SpriteAnimation burstSpriteAnim = gameObject5.AddComponent<SpriteAnimation>();
					_burstSpriteAnim = burstSpriteAnim;
					num2 = num2;
					goto IL_0658;
				}
			}
			goto IL_06a8;
		}
		goto IL_0658;
	}

	private void MakeBigSkeleton()
	{
		//IL_00ea: Expected O, but got I4
		PhaserSprite head = _head;
		if ((object)_head == null || ((UnityEngine.Object)head).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite head2 = instance.AddPhaserSprite(pos, "anima", "Gash_head_i01");
			_head = head2;
			GameObject gameObject = _head.gameObject;
			((UnityEngine.Object)gameObject).SetName("Head");
			PhaserSprite head3 = _head;
			GameObject gameObject2 = head3._spriteRenderer.gameObject;
			SpriteAnimation headSpriteAnim = gameObject2.AddComponent<SpriteAnimation>();
			_headSpriteAnim = headSpriteAnim;
		}
		PhaserSprite phaserSprite = _head.setOrigin(0f, (float?)(object)1);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Gash_head_i", 1, 5, "anima", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_headSpriteAnim.AddAnimation("idle", animationFrames, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	private void Morph()
	{
		//IL_0083: Expected O, but got I4
		//IL_00ea: Expected O, but got I4
		//IL_0180: Expected O, but got F4
		//IL_01dd: Expected O, but got I4
		//IL_01dd: Expected I4, but got F4
		//IL_0366: Expected F4, but got O
		if (!_isMorphed)
		{
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.RemoveWeapon(WeaponType.BONE, this);
			GameManager core2 = GM.Core;
			Weapon weapon2 = core2._weaponsFacade.AddWeapon(WeaponType.BONE2, this);
			core2.SetSeenWeapon(WeaponType.BONE2);
			BaseBody baseBody = body.setOffset(22f, (float?)(object)1);
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			List<Vector2> list = new List<Vector2>();
			Vector2 vector = default(Vector2);
			list.Add(vector);
			currentSkinData._003CheadOffsets_003Ek__BackingField = list;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.5f;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
			PlaySparkle();
			MakeBigSkeleton();
			SpriteAnimation spriteAnimation = _spriteAnimation;
			_isMorphed = true;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			int num2 = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Gash_body_i0", 1, 1, vector, (string)num, num2, flag);
			Sprite sprite = SpriteManager.GetSprite("Gash_body_i01", "anima");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walk2", animationFrames, 1, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
			base._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
			base._spriteTrail.Reset();
			SpriteTrail spriteTrail = base._spriteTrail;
			spriteTrail._MaxHistory = 1;
			spriteTrail.InitialiseGhosts(expandExisting: true);
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = (float)_amountBonus + eggFloat._val;
			playerStats._003CAmount_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = (float)_armorBonus + eggFloat3._val;
			playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CMaxHp_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = (float)_maxHpBonus + eggFloat5._val;
			playerStats3._003CMaxHp_003Ek__BackingField = eggFloat6;
			float num3 = base.MaxHp();
			base._currentHp = (float)vector;
		}
	}

	private unsafe void PlaySparkle()
	{
		//IL_00a6: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_01e7: Expected I, but got O
		//IL_0259: Expected O, but got I4
		//IL_031a: Expected I, but got O
		//IL_0370: Expected O, but got I4
		//IL_037e: Expected O, but got I4
		//IL_038c: Expected O, but got I4
		//IL_03a8: Expected O, but got I4
		_burstSpriteAnim.SetAnimation("enter");
		PhaserSprite phaserSprite = _burstSprite.setAlpha(1f);
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringSprite != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite2 = _ringSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _ringSprite.setAlpha(1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_darkTween != null)
		{
			_darkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_darkSprite != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 100f;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			PhaserSprite phaserSprite2 = _darkSprite.setAlpha(0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween darkTween = Tweens.Add(tweenConfig2);
		_darkTween = darkTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_sparkSprite != null)
		{
			nint num3 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scaleX = (float?)(object)1;
		tweenConfig3.scaleY = (float?)(object)1;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 200f;
		tweenConfig3.angle = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			//IL_001a: Expected O, but got I4
			//IL_005d: Expected O, but got Ref
			PhaserSprite phaserSprite2 = _sparkSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _sparkSprite.setAlpha(1f);
			Transform transform = _sparkSprite.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onUpdate = delegate
		{
			//IL_001e: Expected F4, but got O
			//IL_006a: Expected F4, but got O
			float2 float5 = base.position;
			_sparkSprite.X = (float)float5;
			float2 float6 = base.position;
			object obj4 = default(object);
			float y = (float)obj4 + 0.19999999f;
			_sparkSprite.Y = y;
			float2 float7 = base.position;
			_ringSprite.X = (float)float7;
			float2 float8 = base.position;
			float y2 = (float)obj4 + 0.19999999f;
			_ringSprite.Y = y2;
		};
		tweenConfig3.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite2 = _ringSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = _sparkSprite.setAlpha(0f);
		};
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig3);
		_sparkTween = sparkTween;
	}

	public override void Revive(float percentage = 1f, bool instantRevival = false)
	{
		base.Revive(percentage, instantRevival);
		if (_isMorphed && !_morphSpritesHidden)
		{
			PhaserSprite phaserSprite = _head.setVisible(visible: true);
		}
	}

	public override void OnDeath()
	{
		base.OnDeath();
		if (_isMorphed)
		{
			PhaserSprite phaserSprite = _head.setVisible(visible: false);
		}
	}

	public override void SetExtraVisualsVisible(bool show)
	{
		bool morphSpritesHidden = (byte)((show ? 1u : 0u) ^ 1u) != 0;
		bool flag = !_isMorphed;
		_morphSpritesHidden = morphSpritesHidden;
		if (!flag)
		{
			PhaserSprite phaserSprite = _head.setVisible(show);
		}
	}

	public CharacterControllerMortaccio()
	{
		//IL_000b: Expected O, but got I4
		//IL_0024: Expected O, but got I8
		_headOffset = (float2)1057300152;
		_ = 3193375293L;
		_invHeadOffset = (float2)3196395192L;
		_ = 3193375293L;
		base._002Ector();
	}

	private void _003CPlaySparkle_003Eb__24_0()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _ringSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _ringSprite.setAlpha(1f);
	}

	private void _003CPlaySparkle_003Eb__24_1()
	{
		PhaserSprite phaserSprite = _darkSprite.setAlpha(0f);
	}

	private unsafe void _003CPlaySparkle_003Eb__24_2()
	{
		//IL_001a: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		PhaserSprite phaserSprite = _sparkSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _sparkSprite.setAlpha(1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__24_3()
	{
		//IL_001e: Expected F4, but got O
		//IL_006a: Expected F4, but got O
		float2 float5 = base.position;
		_sparkSprite.X = (float)float5;
		float2 float6 = base.position;
		object obj = default(object);
		float y = (float)obj + 0.19999999f;
		_sparkSprite.Y = y;
		float2 float7 = base.position;
		_ringSprite.X = (float)float7;
		float2 float8 = base.position;
		float y2 = (float)obj + 0.19999999f;
		_ringSprite.Y = y2;
	}

	private void _003CPlaySparkle_003Eb__24_4()
	{
		PhaserSprite phaserSprite = _ringSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _sparkSprite.setAlpha(0f);
	}
}
