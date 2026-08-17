using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_EnemiesCount_AddCoins : CharacterSkillCard_Base
{
	protected override int[] bonusTresholds => new int[3] { 1000, 2000, 3000 };

	public SubSkillCard_EnemiesCount_AddCoins(ArcanaType type)
		: base(type)
	{
	}

	public override void Update()
	{
		base.Update();
		Update_CountEnemies();
	}

	protected override void OnEnemiesCountReached()
	{
		//IL_01bd: Expected I, but got O
		//IL_0166: Expected F4, but got O
		//IL_0129->IL0167: Incompatible stack heights: 1 vs 0
		//IL_014b->IL0167: Incompatible stack heights: 1 vs 0
		if ((object)LinkedCharacter != null)
		{
			float2 position = LinkedCharacter.position;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = (object)((CharacterSkillCard_Base)(object)transform).LinkedCharacter == null;
						Transform.get_position_Injected((IntPtr)((CharacterSkillCard_Base)(object)transform).LinkedCharacter, out Vector3 _);
						if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.COINBAGMAX))
						{
							Vector2 pos = default(Vector2);
							Pickup pickup = PickupManager.CreatePickup(pos, ItemType.COINBAGMAX);
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._gizmoManager != null)
						{
							float y = default(float);
							core2._gizmoManager.ShowHighlightAt((float)position, y);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
