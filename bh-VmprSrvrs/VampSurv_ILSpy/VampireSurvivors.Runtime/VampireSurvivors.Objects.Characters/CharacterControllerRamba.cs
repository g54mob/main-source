using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
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

public class CharacterControllerRamba : CharacterController
{
	private bool _DebugAutoMorph;

	private const ItemType MorphRelic = ItemType.RELIC_LAZULIA;

	private const float BonusAmount = 1f;

	private const float BonusArmor = 2f;

	private const float BonusMaxHP = 100f;

	private MorphVFX _morphVFX;

	private bool _isMorphed;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _twinklePfx;

	private ParticleSystem _cartPfx;

	private PhaserSprite _cartFront;

	private PhaserSprite _cartBack;

	private MultiTargetTween _tintTween;

	private List<uint> _tints;

	private int _tintCounter;

	public bool MorphAbilityUnlocked
	{
		get
		{
			//IL_00ce: Expected I4, but got O
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected O, but got Unknown
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null)
				{
					List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 == 0)
						{
							return false;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj2 = default(object);
						object obj = obj2 - -1;
						bool flag = obj == null;
						return !flag;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsMorphed => _isMorphed;

	public bool EnableTintTween => true;

	public bool EnableTwinklePfx => false;

	public bool SitsOnCart => false;

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
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj2 = default(object);
			if (obj2 == null && MorphAbilityUnlocked)
			{
				Morph();
			}
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		UpdateDepths();
		if (_DebugAutoMorph)
		{
			Morph();
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_isMorphed = false;
		if (MorphAbilityUnlocked)
		{
			MakeMorphVFX();
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = ((!gameObject.TryGetComponent<ParticleEmitterManager>(out var component)) ? gameObject.AddComponent<ParticleEmitterManager>() : component);
			_pfxManager = pfxManager;
			GenerateTwinklePfx();
		}
	}

	private void CheckForMorph()
	{
		if (base._level < 80)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj2 = default(object);
			if (obj2 == null && MorphAbilityUnlocked)
			{
				Morph();
			}
		}
	}

	private void MorphedOnStop()
	{
		_wiggleTween.Pause();
		base.angle = 0f;
	}

	private void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			morphVFX._burstTint = new uint[4] { 65280u, 255u, 16776960u, 16711680u };
			morphVFX._sparkName = "blurredSharpStar.png";
			morphVFX._diskName = "disc.png";
			_morphVFX = morphVFX;
			_morphVFX.Make();
		}
	}

	protected override void OnStop()
	{
		if (!_isMorphed)
		{
			base.OnStop();
			return;
		}
		_wiggleTween.Pause();
		base.angle = 0f;
	}

	public override void OnDeath()
	{
		base.OnDeath();
	}

	public override void Revive(float percentage = 1f, bool instantRevival = false)
	{
		base.Revive(percentage, instantRevival);
	}

	private void Morph()
	{
		//IL_039a: Expected O, but got I4
		//IL_0112: Expected O, but got F4
		//IL_0144: Expected O, but got I4
		//IL_0144: Expected I4, but got F4
		//IL_01a0: Expected O, but got I4
		//IL_035c: Expected F4, but got O
		if (!_isMorphed)
		{
			MakeMorphVFX();
			_morphVFX.PlaySparkle(this);
			_isMorphed = true;
			_tintCounter = 0;
			DoTintTween();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.5f;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.RemoveWeapon(WeaponType.CART2, this);
			GameManager core2 = GM.Core;
			Weapon weapon2 = core2._weaponsFacade.AddWeapon(WeaponType.CART2EVO, this);
			core2.SetSeenWeapon(WeaponType.CART2EVO);
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			Vector2 vector = default(Vector2);
			int num2 = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Kahrahmbah_i", 1, 5, vector, (string)num, num2, flag);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk2");
			base._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
			SpriteAnimation spriteAnimation2 = _spriteAnimation;
			((BaseSpriteAnimation)spriteAnimation2)._003CIsPaused_003Ek__BackingField = false;
			BaseBody baseBody = body.setOffset(30f, (float?)(object)1);
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			List<Vector2> list = new List<Vector2>();
			list.Add(vector);
			currentSkinData._003CheadOffsets_003Ek__BackingField = list;
			base._spriteTrail.Reset();
			SpriteTrail spriteTrail = base._spriteTrail;
			spriteTrail._MaxHistory = 1;
			spriteTrail.InitialiseGhosts(expandExisting: true);
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 1f;
			playerStats._003CAmount_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + 2f;
			playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CMaxHp_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + 100f;
			playerStats3._003CMaxHp_003Ek__BackingField = eggFloat6;
			float num3 = base.MaxHp();
			base._currentHp = (float)vector;
		}
	}

	private void SpawnCart()
	{
	}

	private unsafe void DoTintTween()
	{
		//IL_0082: Expected O, but got I
		//IL_0173: Expected I, but got O
		//IL_00bd: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_0265: Expected O, but got I4
		//IL_028f: Expected O, but got I4
		//IL_0326: Expected O, but got I4
		//IL_00a2->IL02ba: Incompatible stack heights: 1 vs 0
		//IL_0196->IL0196: Incompatible stack heights: 1 vs 0
		//IL_0318->IL0357: Incompatible stack heights: 2 vs 0
		//IL_0252->IL02ba: Incompatible stack heights: 1 vs 0
		if (_tintCounter == 0)
		{
			List<uint> tints = _tints;
			SpriteRenderer characterRenderer = _CharacterRenderer;
			if (_tints != null)
			{
				int tintCounter = _tintCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
				int num = (int)((nint)tintCounter % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
				bool flag = (nint)num >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v41+20+v144 @ rdx_v33 (System.Int32)*4]");
					object obj2 = (nint)0 >> 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v41+20+v144 @ rdx_v33 (System.Int32)*4]");
					object obj3 = (nint)0 >> 8;
					float num2 = (float)obj2 / 255f;
					float num3 = (float)obj3 / 255f;
					bool flag2 = ((UnityEngine.Object)characterRenderer).m_CachedPtr == (IntPtr)0;
					float value = default(float);
					SpriteRenderer.set_color_Injected(((UnityEngine.Object)characterRenderer).m_CachedPtr, ref *(Color*)(&value));
					goto IL_0357;
				}
			}
			goto IL_02ba;
		}
		goto IL_0357;
		IL_02ba:
		throw new NullReferenceException();
		IL_0357:
		int tintCounter2 = _tintCounter + 1;
		_tintCounter = tintCounter2;
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			if ((object)_CharacterRenderer != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				bool flag3 = obj4 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				List<uint> tints2 = _tints;
				if (_tints != null)
				{
					int tintCounter3 = _tintCounter;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r8_v5 (System.Collections.Generic.List`1<System.UInt32>)+18]");
					int num5 = (int)((nint)tintCounter3 % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r8_v5 (System.Collections.Generic.List`1<System.UInt32>)+18]");
					bool flag4 = (nint)num5 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r8_v5 (System.Collections.Generic.List`1<System.UInt32>)+10]");
					if ((nint)0 != 0)
					{
						tweenConfig.tint = (uint?)(object)1;
						int num6 = _tintCounter & 1;
						bool flag5 = num6 == 0;
						object obj5 = !flag5;
						if (obj5 != null)
						{
							tweenConfig.alpha = (float?)(object)1;
							tweenConfig.duration = 5000f;
							TweenCallback onComplete = delegate
							{
								DoTintTween();
							};
							tweenConfig.onComplete = onComplete;
						}
						MultiTargetTween tintTween = Tweens.Add(tweenConfig);
						_tintTween = tintTween;
						return;
					}
				}
			}
		}
		goto IL_02ba;
	}

	private void GenerateTwinklePfx()
	{
	}

	private void GenerateCartPfx()
	{
	}

	private void UpdateCartPfx()
	{
	}

	private void UpdateDepths()
	{
		ParticleSystem twinklePfx = _twinklePfx;
		if ((object)_twinklePfx != null && ((UnityEngine.Object)twinklePfx).m_CachedPtr != (IntPtr)0)
		{
			int num = base.depth;
			int num2 = num - 1;
			RenderingExtensions.SetDepth(_twinklePfx, num2);
		}
		PhaserSprite cartFront = _cartFront;
		if ((object)_cartFront != null && ((UnityEngine.Object)cartFront).m_CachedPtr != (IntPtr)0)
		{
			int num3 = base.depth;
			int num4 = num3 + 1;
			PhaserSprite phaserSprite = _cartFront.setDepth(num4);
		}
		PhaserSprite cartBack = _cartBack;
		if ((object)_cartBack != null && ((UnityEngine.Object)cartBack).m_CachedPtr != (IntPtr)0)
		{
			int num5 = base.depth;
			int num6 = num5 - 1;
			PhaserSprite phaserSprite2 = _cartBack.setDepth(num6);
		}
	}

	private void PlayTwinklePfx(bool play = true)
	{
	}

	public override void Despawn()
	{
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
	}

	public CharacterControllerRamba()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01a4: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01cc: Expected O, but got I
		//IL_0156: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16777180u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16777180;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(16768255u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 16768255;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(14483455u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 14483455;
		}
		_tints = list;
		base._002Ector();
	}

	private void _003CDoTintTween_003Eb__36_0()
	{
		DoTintTween();
	}
}
