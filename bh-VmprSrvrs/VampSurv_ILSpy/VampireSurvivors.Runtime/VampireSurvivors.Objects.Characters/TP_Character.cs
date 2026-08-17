using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class TP_Character : CharacterController
{
	public override bool RespectAnimationXPivots => true;

	public override void AfterFullInitialization()
	{
		//IL_011e->IL00c7: Incompatible stack heights: 1 vs 0
		//IL_0097->IL00c7: Incompatible stack heights: 1 vs 0
		//IL_016d->IL00c7: Incompatible stack heights: 2 vs 0
		//IL_00c7->IL00c7: Incompatible stack heights: 2 vs 0
		base.AfterFullInitialization();
		SpriteAnimation spriteAnimation = _spriteAnimation;
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
			if ((object)sprite != null)
			{
				bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					Sprite sprite2 = ((ArcadeSprite)this)._spriteRenderer.sprite;
					if ((object)sprite2 != null)
					{
						bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect _);
						if ((object)_spriteAnimation != null)
						{
							float2 originalSpriteSize = default(float2);
							spriteAnimation._originalSpriteSize = originalSpriteSize;
							Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 210 Invalid \"Jump target not found in method: 0x187623840\"");
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void AddTPItemsToLootTable()
	{
		//IL_006b: Expected O, but got I
		//IL_00c5: Expected O, but got I
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (stage._stageType != StageType.BONEZONE)
		{
			List<ItemType> list = new List<ItemType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v5+18]");
			if (num >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)206);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 206;
			}
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			config._003CCollectedItems_003Ek__BackingField.AddWithResize(ItemType.TP_RELIC_TELEPORT1);
			object obj3 = default(object);
			if (obj3 != null)
			{
				list.AddWithResize(ItemType.TP_HEART_REFRESH);
			}
			config._003CCollectedItems_003Ek__BackingField.AddWithResize(ItemType.TP_RELIC_TELEPORT2);
			object obj4 = default(object);
			if (obj4 != null)
			{
				list.AddWithResize(ItemType.TP_KARMA_COIN);
			}
			config._003CCollectedItems_003Ek__BackingField.AddWithResize(ItemType.TP_RELIC_TELEPORT3);
			object obj5 = default(object);
			if (obj5 != null)
			{
				list.AddWithResize(ItemType.TP_MIRROR_OF_TRUTH);
			}
			config._003CCollectedItems_003Ek__BackingField.AddWithResize(ItemType.TP_RELIC_TELEPORT4);
			object obj6 = default(object);
			if (obj6 != null)
			{
				list.AddWithResize(ItemType.TP_NEUTRON_BOMB);
			}
			GameManager core3 = GM.Core;
			core3._lootManager.AddToLootTable(list);
		}
	}
}
