using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamondAxe : EnemyAxeMotion
{
	private int _hitsTaken;

	private bool _isInvul;

	private bool _canBreak;

	private string[] _availableFrames;

	private Timer _selfTimer;

	private float _invulDelay;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * 0.01f;
		float num3 = localEulerAngles.z - num2;
		base.angle = num3;
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0050: Expected O, but got F4
		((EnemyController)this).InitEnemy(enemyType, asRemote);
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		float2 float5 = base.position;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float6 = gameSessionData._activeCharacter.position;
		float num3 = default(float);
		BaseBody baseBody = default(BaseBody);
		if (float5 <= float6 != 0)
		{
			float num = ((EnemyController)this)._003CSpeed_003Ek__BackingField * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,eax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10818h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [188A10958h]\"");
			float num2 = 0f * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			num3 = num2 * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			baseBody = body;
			float num4 = num2 * num;
		}
		baseBody._velocity = (float2)num3;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v16 (BaseBody)+74]");
		float num5 = 0f * -1f;
		BaseBody baseBody3 = body;
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		_initialVelocity = baseBody3._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v17 (BaseBody)+74]");
		_ = 0;
		_hitsTaken = 0;
		_isInvul = false;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		Sprite sprite = SpriteManager.GetSprite("diamondBlue_i01", "enemiesM");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		if (_selfTimer != null)
		{
			_selfTimer.Cancel();
		}
		Action onComplete = delegate
		{
			((EnemyController)this)._003CIsCullable_003Ek__BackingField = true;
			base.Disappear();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer selfTimer = Timers.Register(10f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_selfTimer = selfTimer;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField && !_isInvul)
		{
			int hitsTaken = _hitsTaken + 1;
			_hitsTaken = hitsTaken;
			_isInvul = true;
			ChangeFrame();
			_ = 1073741824;
			Action onComplete = delegate
			{
				_isInvul = false;
			};
			float duration = _invulDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			base.OnGetDamaged(showHitVfx, hasKb: false);
		}
	}

	protected void ChangeFrame()
	{
		//IL_0033: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_017d: Expected O, but got F4
		//IL_006b: Expected O, but got I4
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		string[] availableFrames = _availableFrames;
		object obj = availableFrames.Length - 1;
		float time = default(float);
		if (_hitsTaken < (nint)obj)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = (float)_hitsTaken * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bumper, soundConfig, 100f, 4, time);
			string[] availableFrames2 = _availableFrames;
			int hitsTaken = _hitsTaken;
			Sprite sprite = SpriteManager.GetSprite(availableFrames2[hitsTaken], "enemiesM");
			ArcadeSprite arcadeSprite = setFrame(sprite);
		}
		else
		{
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			float detune2 = (float)obj3 * -600f;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Crystal12, soundConfig2, 0f, 10, time);
			Die();
		}
	}

	protected override void Die()
	{
		//IL_01eb: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0302->IL0185: Incompatible stack heights: 1 vs 0
		//IL_0185->IL00fc: Incompatible stack heights: 1 vs 0
		//IL_02b3->IL0185: Incompatible stack heights: 1 vs 0
		//IL_025e->IL0185: Incompatible stack heights: 1 vs 0
		//IL_0144->IL00fc: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL00fc: Incompatible stack heights: 1 vs 0
		int num = (int)(_deathSeed << 13);
		int num2 = (int)_deathSeed ^ num;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		_deathRng = (Unity.Mathematics.Random)num6;
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._lootManager != null)
		{
			ItemType randomWeightedItem = gameManager._lootManager.GetRandomWeightedItem((Unity.Mathematics.Random?)(object)1);
			if (randomWeightedItem == ItemType.VOID)
			{
				goto IL_00fc;
			}
			Transform transform = base.transform;
			Vector3 ret;
			Vector2 pos = default(Vector2);
			if (randomWeightedItem != ItemType.COIN)
			{
				if (randomWeightedItem != ItemType.COINBAG1)
				{
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
						if ((object)_gameManager != null)
						{
							float value = default(float);
							ItemType relicType = default(ItemType);
							bool shouldCallValidatePickups = default(bool);
							bool isRemote = default(bool);
							Pickup pickup = _gameManager.MakePickup(pos, randomWeightedItem, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
							goto IL_00fc;
						}
					}
				}
				else if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v29 (UnityEngine.Transform)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v29 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeRedCoinBag(pos);
						goto IL_00fc;
					}
				}
			}
			else if ((object)transform != null)
			{
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_gameManager != null)
				{
					_gameManager.MakeCoin(pos);
					goto IL_00fc;
				}
			}
		}
		throw new NullReferenceException();
		IL_00fc:
		base.Die();
	}

	public EnemyDiamondAxe()
	{
		string[] availableFrames = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_availableFrames = availableFrames;
		_invulDelay = 350f;
		base._grav = 0.3125f;
		((EnemyController)this)._002Ector();
	}

	private void _003CInitEnemy_003Eb__7_0()
	{
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = true;
		base.Disappear();
	}

	private void _003CGetDamaged_003Eb__8_0()
	{
		_isInvul = false;
	}
}
