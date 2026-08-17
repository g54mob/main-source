using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyReapperoni : EnemyController
{
	private bool _legitKill;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		_legitKill = false;
		base._003CDontTeleportOnFreeRoam_003Ek__BackingField = true;
	}

	protected override void Die()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			base.Die();
			if (_legitKill)
			{
				HandleLegitKill();
			}
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		object obj = default(object);
		float num2 = default(float);
		if ((nint)obj != 73)
		{
			if ((nint)obj != 74)
			{
				goto IL_0073;
			}
			float num = _maxHp * 0.01f;
			num2 += num;
		}
		_legitKill = true;
		goto IL_0073;
		IL_0073:
		base.GetDamaged(num2, showHitVfx, damageKb, damageType, hasKb);
	}

	private unsafe void HandleLegitKill()
	{
		//IL_02d2: Expected O, but got I
		//IL_05c5: Expected O, but got Ref
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_065f->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_0388->IL04b2: Incompatible stack heights: 1 vs 0
		//IL_03cb->IL04b2: Incompatible stack heights: 2 vs 0
		//IL_0414->IL0559: Incompatible stack heights: 2 vs 0
		//IL_0419->IL0419: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		float num;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
				if (stage._003CStageMods_003Ek__BackingField != null)
				{
					bool flag = (object)stageModifiers._003CTimeLimit_003Ek__BackingField == null;
					num = 1800f;
					if (!flag)
					{
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage != null)
							{
								if (stage2._003CStageMods_003Ek__BackingField != null)
								{
									if ((object)stageModifiers._003CTimeLimit_003Ek__BackingField != null)
									{
										float num2 = default(float);
										num = num2;
										goto IL_0664;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					goto IL_0664;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
		IL_04b2:
		throw new NullReferenceException();
		IL_0664:
		GameManager core3 = GM.Core;
		if ((object)GM.Core != null)
		{
			float num3 = num + 60f;
			if (num3 > core3._003CSurvivedSeconds_003Ek__BackingField)
			{
				float num4 = num + 60f;
				core3._003CSurvivedSeconds_003Ek__BackingField = num4;
			}
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				gameManager._canRunTickerTimer = false;
				GameManager gameManager2 = _gameManager;
				if ((object)_gameManager != null && (object)gameManager2._WhiteHandManager != null)
				{
					gameManager2._WhiteHandManager.SummonWhiteHand();
					GameManager gameManager3 = _gameManager;
					if ((object)_gameManager != null)
					{
						Stage stage3 = gameManager3._stage;
						if ((object)gameManager3._stage != null)
						{
							object spawnedEnemies = stage3._spawnedEnemies;
							bool flag2 = (nint)stage3._spawnedEnemies < 0;
							if (stage3._spawnedEnemies != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rbx_v13 (System.Object)+18]");
								object obj = -1;
								if (flag2)
								{
									goto IL_0419;
								}
								while (true)
								{
									GameManager gameManager4 = _gameManager;
									if ((object)_gameManager == null)
									{
										break;
									}
									Stage stage4 = gameManager4._stage;
									if ((object)gameManager4._stage == null)
									{
										break;
									}
									List<EnemyController> spawnedEnemies2 = stage4._spawnedEnemies;
									if (stage4._spawnedEnemies == null)
									{
										break;
									}
									bool flag3 = (nint)obj >= spawnedEnemies2._size;
									EnemyController[] items = spawnedEnemies2._items;
									if (spawnedEnemies2._items == null)
									{
										break;
									}
									bool flag4 = (nint)obj >= items.Length;
									if ((object)items[obj] == null)
									{
										break;
									}
									items[obj].Disappear();
									obj--;
									if ((nint)items[obj] >= 0)
									{
										continue;
									}
									goto IL_0419;
								}
							}
						}
					}
				}
			}
		}
		goto IL_04b2;
		IL_0419:
		object cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v19 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v19 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
			object obj2 = null;
			Vector2 vector = (Vector2)(&ret);
			float num5 = 60f;
			ItemType itemType = ItemType.VOID;
			object obj3 = default(object);
			Vector2 vector2 = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
				float num6 = 0f * ((float)Math.PI * 2f / 5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
				float num7 = 0f * ((float)Math.PI * 2f / 5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num8 = num7 * 0.6f;
				num5 = num8 + (float)obj3;
				if ((object)_gameManager == null)
				{
					break;
				}
				Pickup pickup = _gameManager.MakeStagePickup(vector2, ItemType.RELIC_GOLDENEGG, WeaponType.VOID, value, relicType, validatePickups);
				obj2++;
				bool flag6 = (nint)obj2 < 5;
				vector = vector2;
				itemType = ItemType.RELIC_GOLDENEGG;
				if (!flag6)
				{
					return;
				}
			}
		}
		goto IL_04b2;
	}
}
