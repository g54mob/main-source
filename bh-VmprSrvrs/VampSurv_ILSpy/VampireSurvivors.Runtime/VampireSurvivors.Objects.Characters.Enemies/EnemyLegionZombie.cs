using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyLegionZombie : EnemyController
{
	private float _timeInMidair;

	private bool _hasHitGround;

	private EnemyLegion _legionBoss;

	public GameObject LegionBoss
	{
		get
		{
			EnemyLegion legionBoss = _legionBoss;
			if ((object)_legionBoss != null && ((UnityEngine.Object)legionBoss).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_legionBoss != null)
				{
					return _legionBoss.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value == null || ((UnityEngine.Object)value).m_CachedPtr == (IntPtr)0)
			{
				_legionBoss = null;
			}
			EnemyLegion component = value.GetComponent<EnemyLegion>();
			_legionBoss = component;
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_02fb: Expected O, but got I4
		//IL_0334: Expected I, but got O
		//IL_0385: Expected I, but got O
		//IL_02bb: Expected O, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_01f1->IL02d6: Incompatible stack heights: 1 vs 0
		//IL_022a->IL02d6: Incompatible stack heights: 1 vs 0
		//IL_0263->IL02d6: Incompatible stack heights: 3 vs 0
		//IL_0292->IL02d6: Incompatible stack heights: 3 vs 0
		//IL_039f->IL02d6: Incompatible stack heights: 4 vs 0
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Legion_Zombie", 1, 6, "Legion", num);
		if ((object)_SpriteAnimation != null)
		{
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_SpriteAnimation.AddAnimation("walk", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			if ((object)_SpriteAnimation != null)
			{
				_SpriteAnimation.SetAnimation("walk");
				SpriteAnimation spriteAnimation = _SpriteAnimation;
				if ((object)_SpriteAnimation != null)
				{
					((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
					List<Sprite> list = new List<Sprite>();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						if ((object)_SpriteAnimation != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1873EDE70");
							object obj = default(object);
							if (obj != null)
							{
								_ = 4;
								_ = 1048576000;
								if (animationFrames != null)
								{
									bool flag = animationFrames._size <= 0;
									Sprite[] items = animationFrames._items;
									if (animationFrames._items != null)
									{
										List<Sprite> list2 = (List<Sprite>)(object)items[0];
										if ((object)items[0] != null)
										{
											bool flag2 = list2._items == null;
											Sprite.get_rect_Injected((IntPtr)list2._items, out Rect _);
											bool flag3 = animationFrames._size <= 0;
											List<Sprite> items2 = (List<Sprite>)(object)animationFrames._items;
											if (animationFrames._items != null)
											{
												List<Sprite> syncRoot = (List<Sprite>)items2._syncRoot;
												if (items2._syncRoot != null)
												{
													bool flag4 = syncRoot._items == null;
													Sprite.get_rect_Injected((IntPtr)syncRoot._items, out Rect _);
													if (body != null)
													{
														BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
														_hasHitGround = false;
														_timeInMidair = 0f;
														return;
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
		throw new NullReferenceException();
	}

	public void Setup(EnemyLegion legionBoss)
	{
		_legionBoss = legionBoss;
	}

	protected override void OnUpdate()
	{
		EnemyLegion legionBoss = _legionBoss;
		object obj = default(object);
		float2 float7 = default(float2);
		if (_hasHitGround)
		{
			base.OnUpdate();
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.Enemies.EnemyLegion)+2A4]");
			if ((nint)obj > 0)
			{
				float2 float6 = base.position;
				base.position = float7;
			}
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float timeInMidair = deltaTime + _timeInMidair;
		_timeInMidair = timeInMidair;
		float2 float8 = base.position;
		base.position = float7;
		float2 float9 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.Enemies.EnemyLegion)+2A4]");
		if (0 > (nint)obj)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			_hasHitGround = true;
			_timeInMidair = 0f;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		}
		base.UpdateDepth();
	}
}
