using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDice : EnemyDiamond
{
	private static WeightedStore WEIGHTEDSTORE;

	protected Vector2 _initialVelocity;

	private float _grav = 0.3125f;

	protected override bool UseStandardLootTable => false;

	protected override float InvulDelay => 500f;

	protected override float ItemChance => 0.915f;

	protected override float Volume_breaking => 0.125f;

	protected override float Volume_gotHit => 0.075f;

	protected override SfxType Sfx_breaking => SfxType.Crystal12;

	protected override SfxType Sfx_gotHit => SfxType.Bumper;

	protected override bool ChangeFramesOnHit => false;

	protected override bool DoBaseUpdate => false;

	protected override bool IsImmovable => true;

	protected virtual bool IsAxe => false;

	protected virtual bool IsSnake => false;

	protected virtual uint[] TintProgression => new uint[4] { 16777164u, 16777096u, 16777028u, 16776994u };

	protected override string _textureName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A61C4]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "enemies2025";
		}
	}

	protected override string DefaultFrame
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A61C5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "diamondDice_i06";
		}
	}

	protected override string[] AvailableFrames
	{
		get
		{
			string[] array = new string[7];
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				return array;
			}
			return (string[])(object)new NullReferenceException();
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		//IL_0178: Expected O, but got F4
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
		BaseBody baseBody = body;
		bool isImmovable = IsImmovable;
		baseBody._immovable = isImmovable;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = true;
		if (IsAxe)
		{
			EnemyData currentEnemyData = _currentEnemyData;
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			((EnemyController)this)._003CSpeed_003Ek__BackingField = currentEnemyData._003Cspeed_003Ek__BackingField;
			float2 float5 = base.position;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 float6 = gameSessionData._activeCharacter.position;
			bool flag = (byte)(float5 < float6) != 0;
			object obj = float5 - float6;
			bool flag2 = obj == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			ArcadeSprite arcadeSprite = setFlipX(flag5);
			((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
			float2 float7 = base.position;
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			float2 float8 = gameSessionData2._activeCharacter.position;
			float num3 = default(float);
			BaseBody baseBody2 = default(BaseBody);
			if (float7 <= float8 != 0)
			{
				float num = ((EnemyController)this)._003CSpeed_003Ek__BackingField * 0.01f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,eax\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10818h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [188A10958h]\"");
				float num2 = 0f * ((float)Math.PI / 180f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				num3 = num2 * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				baseBody2 = body;
				float num4 = num2 * num;
			}
			baseBody2._velocity = (float2)num3;
			BaseBody baseBody3 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v50 (BaseBody)+74]");
			float num5 = 0f * -1f;
			BaseBody baseBody4 = body;
			_initialVelocity = baseBody4._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v51 (BaseBody)+74]");
			_ = 0;
		}
		if (WEIGHTEDSTORE == null)
		{
			GameManager gameManager = _gameManager;
			ItemType[] items = new ItemType[3]
			{
				ItemType.CLOVER,
				ItemType.GILDED,
				ItemType.PICKUP_REROLL_DICE
			};
			WeightedStore wEIGHTEDSTORE = gameManager._lootManager.ExportCustomLootTable(items);
			WEIGHTEDSTORE = wEIGHTEDSTORE;
		}
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		string defaultFrame = DefaultFrame;
		string textureName = _textureName;
		Sprite sprite = SpriteManager.GetSprite(defaultFrame, textureName);
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
	}

	public override void OnSpawnDone()
	{
		bool flag = !IsAxe || IsImmovable;
		bool flag2 = !flag;
		bool flag3 = !flag2;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = flag3;
		selfDuration = 120000f;
	}

	protected virtual void OnHit_ChangeSprite()
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

	protected virtual void OnHit_ChangeTint()
	{
		//IL_0015: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_019b: Expected O, but got F4
		//IL_006f: Expected O, but got I4
		uint[] tintProgression = TintProgression;
		object obj = tintProgression.Length - 1;
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
			uint[] tintProgression2 = TintProgression;
			uint[] tintProgression3 = TintProgression;
			int num = _hitsTaken % tintProgression3.Length;
			_saveTint = tintProgression2[num];
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, tintProgression2[num]);
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

	protected override void ChangeFrame()
	{
		OnHit_ChangeSprite();
	}

	protected override void OnUpdate()
	{
		//IL_017e: Expected O, but got I4
		base.OnUpdate();
		if (IsSnake)
		{
			SnakeUpdate();
		}
		if (IsAxe && !((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num = default(int);
			ArcadeSprite arcadeSprite = setDepth(num);
			if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
			{
				if (_receivingDamage)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,qword ptr [188A10510h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,xmm0\"");
				float deltaTime = PauseSystem.DeltaTime;
				float num2 = deltaTime * 1000f;
				float num3 = num2 * _grav;
				float num4 = num3 * 0.01f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyDice)+2AC]");
				float num5 = 0f - num4;
				float xVel = ((EnemyController)this)._003CSpeed_003Ek__BackingField * (float)_initialVelocity;
				setVelocity(xVel, (float?)(object)1);
			}
		}
		base.UpdateDepth();
	}

	protected override void CustomLoot()
	{
		//IL_02de->IL0215: Incompatible stack heights: 1 vs 0
		//IL_028f->IL0215: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._lootManager != null)
		{
			ItemType itemFromExportedTable = gameManager._lootManager.GetItemFromExportedTable(WEIGHTEDSTORE);
			if (itemFromExportedTable == ItemType.VOID)
			{
				return;
			}
			Transform transform = base.transform;
			Vector2 pos = default(Vector2);
			Vector3 ret;
			switch (itemFromExportedTable)
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
						Pickup pickup = _gameManager.MakePickup(pos, itemFromExportedTable, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
						return;
					}
				}
				break;
			case ItemType.GEM:
				if ((object)transform != null)
				{
					Vector3 vector = transform.position;
					if ((object)_gameManager != null)
					{
						_gameManager.MakeGem(pos, 1f);
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

	private void AxeUpdate()
	{
		//IL_0121: Expected O, but got I4
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
		{
			if (_receivingDamage)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,qword ptr [188A10510h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,xmm0\"");
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 1000f;
			float num3 = num2 * _grav;
			float num4 = num3 * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyDice)+2AC]");
			float num5 = 0f - num4;
			float xVel = ((EnemyController)this)._003CSpeed_003Ek__BackingField * (float)_initialVelocity;
			setVelocity(xVel, (float?)(object)1);
		}
	}

	private unsafe void SnakeUpdate()
	{
		//IL_018b: Expected F4, but got I
		//IL_00cb->IL006f: Incompatible stack heights: 1 vs 0
		//IL_0175->IL0076: Incompatible stack heights: 4 vs 0
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		RetargetIfNecessary();
		Transform targetTransform = ((EnemyController)this)._targetTransform;
		if ((object)((EnemyController)this)._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				object obj = ret - ret2;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				object cachedTransform2 = _cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Quaternion.AngleAxis_Injected((float)(nint)((UnityEngine.Object)cachedTransform).m_CachedPtr, ref ret, out Quaternion _);
				bool flag3 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rdi_v13 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rdi_v13 (System.Object)+10]");
				Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&ret2));
				return;
			}
		}
		throw new NullReferenceException();
	}
}
