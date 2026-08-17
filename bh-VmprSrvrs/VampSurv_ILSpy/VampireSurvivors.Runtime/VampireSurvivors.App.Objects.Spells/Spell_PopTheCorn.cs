using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_PopTheCorn : SpellModifier
{
	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private SpellsManager _spellsManager;

	private DataManager _dataManager;

	public Spell_PopTheCorn(PlayerOptions player, SignalBus signalBus, SpellsManager spellsManager, DataManager dataManager)
	{
		_playerOptions = player;
		_signalBus = signalBus;
		_spellsManager = spellsManager;
		DataManager dataManager2 = default(DataManager);
		_dataManager = dataManager2;
	}

	public void Start()
	{
		//IL_00c3: Expected O, but got I
		//IL_00d8: Expected O, but got I
		_spellsManager.AddSpell(this);
		SoundManager.StopMusic(BgmType.BGM_Secret);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.GREENACRES;
		PlayerOptionsData config2 = _playerOptions.Config;
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)7);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v14 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v14 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v15+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v16+6C]");
			config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Forest;
			List<StageData> list = ((Dictionary<StageType, List<StageData>>)(object)_signalBus).get_Item(StageType.GREENACRES);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void Activate()
	{
		//IL_0032: Expected O, but got I4
		//IL_0334: Expected I, but got O
		//IL_00d7: Expected I, but got O
		//IL_01aa: Expected I, but got O
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj = 0;
		Vector2 pos = default(Vector2);
		while (true)
		{
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num2 = 0f * ((float)Math.PI / 18f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num3 = 0f * ((float)Math.PI / 18f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Pickup pickup;
			if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(ItemType.ROAST))
			{
				pickup = null;
			}
			else
			{
				Pickup pickup2 = PickupManager.CreatePickup(pos, ItemType.ROAST);
				pickup = pickup2;
			}
			Sprite sprite = SpriteManager.GetSprite("corn", "items");
			ArcadeSprite arcadeSprite = pickup.setFrame(sprite);
			nint num4 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num5 = 0f * ((float)Math.PI / 18f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num6 = 0f * ((float)Math.PI / 18f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(ItemType.ROAST))
			{
				break;
			}
			Pickup pickup3 = PickupManager.CreatePickup(pos, ItemType.ROAST);
			Sprite sprite2 = SpriteManager.GetSprite("corn", "items");
			ArcadeSprite arcadeSprite2 = pickup3.setFrame(sprite2);
			nint num7 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num8 = 0f * ((float)Math.PI / 18f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num9 = 0f * ((float)Math.PI / 18f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(ItemType.ROAST))
			{
				break;
			}
			Pickup pickup4 = PickupManager.CreatePickup(pos, ItemType.ROAST);
			Sprite sprite3 = SpriteManager.GetSprite("corn", "items");
			ArcadeSprite arcadeSprite3 = pickup4.setFrame(sprite3);
			obj++;
			if ((nint)obj >= 36)
			{
				return;
			}
		}
		Sprite sprite4 = SpriteManager.GetSprite("corn", "items");
		throw new NullReferenceException();
	}

	public void Deactivate()
	{
	}
}
