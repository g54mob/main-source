using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamond : EnemyController
{
	public float selfDuration = 30000f;

	public int gridX = -1;

	public int gridY;

	protected int _hitsTaken;

	protected bool _isInvul;

	protected bool _canBreak;

	protected MultiTargetTween _onEnterTween;

	protected float _selfTime;

	protected string _defaultFrame = "diamondBlue_i01";

	protected string[] _availableFrames;

	protected virtual bool UseStandardLootTable => true;

	protected virtual float InvulDelay => 500f;

	protected virtual float ItemChance => 0.615f;

	protected virtual float Volume_breaking => 0.6f;

	protected virtual float Volume_gotHit => 0.2f;

	protected virtual SfxType Sfx_breaking => SfxType.Crystal12;

	protected virtual SfxType Sfx_gotHit => SfxType.Bumper;

	protected virtual bool IsImmovable => true;

	protected virtual bool ChangeFramesOnHit => true;

	protected virtual bool DoBaseUpdate => false;

	protected virtual string _textureName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A61A3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "enemiesM";
		}
	}

	protected virtual string DefaultFrame
	{
		get
		{
			return _defaultFrame;
		}
		set
		{
			_defaultFrame = value;
		}
	}

	protected virtual string[] AvailableFrames
	{
		get
		{
			return _availableFrames;
		}
		set
		{
			_availableFrames = value;
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0080: Expected O, but got I4
		//IL_00fc: Expected I, but got O
		//IL_0160: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		_selfTime = 0f;
		gridX = -1;
		base.InitEnemy(enemyType, asRemote);
		_hitsTaken = 0;
		_isInvul = false;
		base._003CIsCullable_003Ek__BackingField = false;
		if (ChangeFramesOnHit)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			string defaultFrame = DefaultFrame;
			string textureName = _textureName;
			Sprite sprite = SpriteManager.GetSprite(defaultFrame, textureName);
			ArcadeSprite arcadeSprite = setFrame(sprite);
		}
		selfDuration = 30000f;
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
		_onEnterTween = onEnterTween;
		ArcadeSprite arcadeSprite3 = setOrigin(0.5f, (float?)(object)0);
		if (IsImmovable)
		{
			BaseBody baseBody = body;
			base._003CIsStatic_003Ek__BackingField = true;
			base._003CSpeed_003Ek__BackingField = 0f;
			baseBody._immovable = true;
		}
	}

	public virtual void OnSpawnDone()
	{
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!base._003CIsDead_003Ek__BackingField && !_isInvul)
		{
			int hitsTaken = _hitsTaken + 1;
			_hitsTaken = hitsTaken;
			_isInvul = true;
			ChangeFrame();
			float invulDelay = InvulDelay;
			Action onComplete = delegate
			{
				_isInvul = false;
			};
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			PlayVFXFlash(showHitVfx);
			_receivingDamage = false;
		}
	}

	public override void GetDamagedSpecial(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true, Vector3? damagePosition = null)
	{
		if (!base._003CIsDead_003Ek__BackingField && !_isInvul)
		{
			int hitsTaken = _hitsTaken + 1;
			_hitsTaken = hitsTaken;
			_isInvul = true;
			ChangeFrame();
			float invulDelay = InvulDelay;
			Action onComplete = delegate
			{
				_isInvul = false;
			};
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			PlayVFXFlash(showHitVfx);
			_receivingDamage = false;
		}
	}

	protected virtual void ChangeFrame()
	{
		//IL_0033: Expected O, but got I4
		//IL_0169: Expected O, but got I4
		//IL_01b0: Expected O, but got F4
		//IL_008d: Expected O, but got I4
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		string[] availableFrames = AvailableFrames;
		object obj = availableFrames.Length - 1;
		float time = default(float);
		if (_hitsTaken < (nint)obj)
		{
			SfxType sfx_gotHit = Sfx_gotHit;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float volume_gotHit = Volume_gotHit;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)_hitsTaken * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfx_gotHit, soundConfig, 100f, 4, time);
			string[] availableFrames2 = AvailableFrames;
			int hitsTaken = _hitsTaken;
			string textureName = _textureName;
			Sprite sprite = SpriteManager.GetSprite(availableFrames2[hitsTaken], textureName);
			ArcadeSprite arcadeSprite = setFrame(sprite);
		}
		else
		{
			SfxType sfx_breaking = Sfx_breaking;
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			float volume_breaking = Volume_breaking;
			soundConfig2.Volume = (float?)(object)1;
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			float detune2 = (float)obj3 * -600f;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(sfx_breaking, soundConfig2, 100f, 4, time);
			Die();
		}
	}

	protected override void OnUpdate()
	{
		base.angle = 0f;
		if (!base._003CIsDead_003Ek__BackingField)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			if (!((_selfTime = num + _selfTime) < selfDuration))
			{
				if (base._003CIsDead_003Ek__BackingField)
				{
					return;
				}
				base._003CIsCullable_003Ek__BackingField = true;
				Disappear();
			}
		}
		if (DoBaseUpdate)
		{
			base.OnUpdate();
		}
	}

	protected override void Die()
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0065: Invalid comparison between O and F4
		gridX = -1;
		base.Die();
		object obj = (object)_deathRng << 13;
		object obj2 = obj ^ (object)_deathRng;
		object obj3 = (object)_deathRng >> 9;
		object obj4 = obj3 | 0x3F800000;
		object obj5 = obj2 >> 17;
		object obj6 = obj2 ^ obj5;
		object obj7 = obj6 << 5;
		Unity.Mathematics.Random deathRng = (Unity.Mathematics.Random)(obj7 ^ obj6);
		_deathRng = deathRng;
		float itemChance = ItemChance;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		CharacterData currentCharacterData = activeCharacter._currentCharacterData;
		object obj9 = default(object);
		object obj8 = obj9 * currentCharacterData._003Cluck_003Ek__BackingField;
		float num = (float)obj4 - 1f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
		{
			if (UseStandardLootTable)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 141 Invalid \"Jump target not found in method: 0x1876F1E30\"");
				throw new NullReferenceException();
			}
			CustomLoot();
		}
	}

	private void StandardLoot()
	{
		//IL_003a: Expected O, but got I4
		//IL_0297->IL017f: Incompatible stack heights: 1 vs 0
		//IL_017f->IL00fc: Incompatible stack heights: 1 vs 0
		//IL_0248->IL017f: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL017f: Incompatible stack heights: 1 vs 0
		//IL_013e->IL00fc: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL00fc: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._lootManager != null)
		{
			ItemType randomWeightedItem = gameManager._lootManager.GetRandomWeightedItem((Unity.Mathematics.Random?)(object)1);
			if (randomWeightedItem == ItemType.VOID)
			{
				return;
			}
			Transform transform = base.transform;
			Vector3 ret;
			Vector2 pos = default(Vector2);
			switch (randomWeightedItem)
			{
			default:
				if ((object)transform != null)
				{
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						float value = default(float);
						ItemType relicType = default(ItemType);
						bool shouldCallValidatePickups = default(bool);
						bool isRemote = default(bool);
						Pickup pickup = _gameManager.MakePickup(pos, randomWeightedItem, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
						return;
					}
				}
				break;
			case ItemType.COINBAG1:
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeRedCoinBag(pos);
						return;
					}
				}
				break;
			case ItemType.COIN:
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeCoin(pos);
						return;
					}
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void CustomLoot()
	{
		//IL_003a: Expected O, but got I4
		//IL_02ea->IL0221: Incompatible stack heights: 1 vs 0
		//IL_0221->IL013b: Incompatible stack heights: 1 vs 0
		//IL_029b->IL0221: Incompatible stack heights: 1 vs 0
		//IL_01e0->IL013b: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._lootManager != null)
		{
			ItemType randomWeightedItem = gameManager._lootManager.GetRandomWeightedItem((Unity.Mathematics.Random?)(object)1);
			if (randomWeightedItem == ItemType.VOID)
			{
				return;
			}
			Transform transform = base.transform;
			Vector2 pos = default(Vector2);
			Vector3 ret;
			switch (randomWeightedItem)
			{
			default:
				if ((object)transform != null)
				{
					Vector3 vector2 = transform.position;
					if ((object)_gameManager != null)
					{
						float value = default(float);
						ItemType relicType = default(ItemType);
						bool shouldCallValidatePickups = default(bool);
						bool isRemote = default(bool);
						Pickup pickup = _gameManager.MakePickup(pos, randomWeightedItem, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
						return;
					}
				}
				break;
			case ItemType.COINBAG1:
				if ((object)transform != null)
				{
					Vector3 vector = transform.position;
					if ((object)_gameManager != null)
					{
						_gameManager.MakeRedCoinBag(pos, 1f);
						return;
					}
				}
				break;
			case ItemType.GEM:
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeGem(pos, 1f);
						return;
					}
				}
				break;
			case ItemType.COIN:
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeCoin(pos);
						return;
					}
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	public override void Disappear()
	{
		gridX = -1;
		base.Disappear();
	}

	public EnemyDiamond()
	{
		string[] availableFrames = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_availableFrames = availableFrames;
		base._002Ector();
	}

	private void _003CGetDamaged_003Eb__40_0()
	{
		_isInvul = false;
	}

	private void _003CGetDamagedSpecial_003Eb__41_0()
	{
		_isInvul = false;
	}
}
