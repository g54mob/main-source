using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStaticVase_Gold : EnemyStatic
{
	private static WeightedStore WEIGHTEDSTORE;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base.SetFlipX(flip: false);
		if (WEIGHTEDSTORE == null)
		{
			GameManager gameManager = _gameManager;
			ItemType[] items = new ItemType[3]
			{
				ItemType.COIN,
				ItemType.COINBAG1,
				ItemType.COINBAGMAX
			};
			WeightedStore wEIGHTEDSTORE = gameManager._lootManager.ExportCustomLootTable(items);
			WEIGHTEDSTORE = wEIGHTEDSTORE;
		}
	}

	protected override void Die()
	{
		((EnemyController)this).Die();
		if (base._onEnterTween != null)
		{
			base._onEnterTween.Pause();
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 38 Invalid \"Jump target not found in method: 0x187778CC0\"");
	}

	protected void CustomLoot()
	{
		//IL_0173: Expected I4, but got F4
		//IL_030a->IL0247: Incompatible stack heights: 1 vs 0
		//IL_0299->IL0247: Incompatible stack heights: 1 vs 0
		//IL_01ce->IL024e: Incompatible stack heights: 1 vs 0
		//IL_02bb->IL024e: Incompatible stack heights: 1 vs 0
		//IL_0128->IL024e: Incompatible stack heights: 1 vs 0
		//IL_0151->IL0247: Incompatible stack heights: 1 vs 0
		//IL_018d->IL024e: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._lootManager != null)
		{
			ItemType itemFromExportedTable = gameManager._lootManager.GetItemFromExportedTable(WEIGHTEDSTORE);
			if (itemFromExportedTable == ItemType.VOID)
			{
				return;
			}
			Transform transform = base.transform;
			Vector3 ret;
			Vector2 pos = default(Vector2);
			switch (itemFromExportedTable)
			{
			default:
			{
				if ((object)transform == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_gameManager != null)
				{
					float num = default(float);
					ItemType relicType = default(ItemType);
					bool shouldCallValidatePickups = default(bool);
					bool isRemote = default(bool);
					Pickup pickup = _gameManager.MakePickup(pos, itemFromExportedTable, WeaponType.VOID, num, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
					if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					float2 float5 = base.position;
					if ((object)_gameManager != null)
					{
						CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, (byte)(int)num != 0);
						bool flag2 = pickup.Vacuum(closestPlayer);
						return;
					}
				}
				break;
			}
			case ItemType.COINBAG1:
				if ((object)transform != null)
				{
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.MakeRedCoinBag(pos);
						return;
					}
				}
				break;
			case ItemType.COIN:
				if ((object)transform == null)
				{
					break;
				}
				if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
					break;
				}
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_gameManager != null)
				{
					_gameManager.MakeCoin(pos);
					return;
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	public EnemyStaticVase_Gold()
	{
		//IL_001b: Expected I4, but got I8
		base._prevDepth = -1;
		((EnemyController)this)._002Ector();
	}
}
