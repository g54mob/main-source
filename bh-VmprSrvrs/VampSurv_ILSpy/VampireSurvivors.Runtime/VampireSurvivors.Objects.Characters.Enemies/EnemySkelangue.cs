using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySkelangue : EnemyController
{
	private int _lives = 3;

	private const string UndieAnimName = "Undie";

	private List<Sprite> _frames;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0167: Expected I4, but got O
		//IL_01c7: Expected O, but got I4
		//IL_00e9->IL00e9: Incompatible stack heights: 1 vs 0
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
		bool flag = _frames != null;
		string text = null;
		bool flag3 = default(bool);
		if (!flag)
		{
			EnemyData currentEnemyData = _currentEnemyData;
			List<string> list = currentEnemyData._003CframeNames_003Ek__BackingField;
			object obj = UnityEngine.Random.RandomRangeInt(0, list._size);
			bool flag2 = (nint)obj >= list._size;
			string[] items = list._items;
			string animName = items[obj].Replace("0", "");
			EnemyData currentEnemyData2 = _currentEnemyData;
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 0, currentEnemyData2._003Cend_003Ek__BackingField, currentEnemyData2._003CtextureName_003Ek__BackingField, flag3 ? 1 : 0);
			_frames = animationFrames;
			List<Sprite> frames = (List<Sprite>)(object)new List<object>(_frames);
			_frames = frames;
			((List<object>)(object)_frames).Reverse();
			text = currentEnemyData2._003CtextureName_003Ek__BackingField;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_SpriteAnimation.AddAnimation("Undie", _frames, 24, flag3, startRandomFrame, onComplete, autoSetAnimation);
		EnemyData currentEnemyData3 = _currentEnemyData;
		int lives = (((object)currentEnemyData3._003Clives_003Ek__BackingField == null) ? _lives : ((object?)currentEnemyData3._003Clives_003Ek__BackingField >> 32));
		_lives = lives;
	}

	public override void Disappear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6338]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_lives = 0;
		base._003CIsDead_003Ek__BackingField = true;
		_SpriteAnimation.SetAnimation("die");
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 24;
		if ((nint)obj <= 2 || (nint)obj2 == 1612 || (nint)obj2 == 17)
		{
			_lives = 0;
		}
		if (!base._003CIsDead_003Ek__BackingField)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	protected override void OnDeathAnimationComplete()
	{
		if (--_lives > 0)
		{
			base._003CIsDead_003Ek__BackingField = true;
			if (body == null)
			{
				Debug.Log("[EnemySkelangue] Body is null...");
			}
			else
			{
				BaseBody baseBody = body;
				baseBody._enable = false;
			}
			_SpriteAnimation.SetAnimation("Undie");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
			Action action = OnUndieAnimComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
			return;
		}
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
		{
			bool hasStateAuthority = _coherenceSync.HasStateAuthority;
			if (!hasStateAuthority && base._003CKilledByAuthority_003Ek__BackingField == hasStateAuthority)
			{
				_EnemyRenderer.enabled = false;
				return;
			}
		}
		Despawn();
	}

	private void OnUndieAnimComplete()
	{
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		Action callback = OnUndieAnimComplete;
		if (((Dictionary<object, object>)(object)((BaseSpriteAnimation)spriteAnimation)._animations).TryGetValue((object)"Undie", out object value))
		{
			((FrameAnimationData)value).RemoveCompletionCallback(callback);
		}
		_SpriteAnimation.SetAnimation("idle");
		_hp = _maxHp;
		BaseBody baseBody = body;
		base._003CIsDead_003Ek__BackingField = false;
		baseBody._enable = true;
	}

	public override void Despawn()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A633B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
		base.Despawn();
	}
}
