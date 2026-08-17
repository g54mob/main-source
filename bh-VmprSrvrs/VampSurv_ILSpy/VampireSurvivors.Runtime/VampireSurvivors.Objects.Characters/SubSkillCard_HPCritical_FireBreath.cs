using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_HPCritical_FireBreath : CharacterSkillCard_Base
{
	public SubSkillCard_HPCritical_FireBreath(ArcanaType type)
		: base(type)
	{
	}

	public override void InitialActivate()
	{
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		linkedCharacter._isCriticalHPEnabled = true;
		CharacterController linkedCharacter2 = LinkedCharacter;
		linkedCharacter2._hasAnyCriticalHPSkill = true;
	}

	public override void OnOwnerCriticalHPTreshold(float rawDamage)
	{
		//IL_0166: Expected F4, but got O
		//IL_0129->IL019e: Incompatible stack heights: 1 vs 0
		//IL_014b->IL019e: Incompatible stack heights: 1 vs 0
		//IL_018a->IL019e: Incompatible stack heights: 1 vs 0
		base.OnOwnerCriticalHPTreshold(rawDamage);
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
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.NFT))
						{
							Vector2 pos = default(Vector2);
							Pickup pickup = PickupManager.CreatePickup(pos, ItemType.NFT);
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._gizmoManager != null)
						{
							float y = default(float);
							core2._gizmoManager.ShowHighlightAt((float)position, y);
							CharacterController linkedCharacter = LinkedCharacter;
							if ((object)LinkedCharacter != null)
							{
								linkedCharacter._isCriticalHPEnabled = false;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
