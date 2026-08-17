using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.App.Objects.Spells;

public class Spell_Kamiki(PlayerOptions player, SignalBus signalBus, SpellsManager spellsManager) : SpellModifier
{
	private PlayerOptions _playerOptions = player;

	private SignalBus _signalBus = signalBus;

	private SpellsManager _spellsManager = spellsManager;

	public void Start()
	{
		//IL_0113: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		_spellsManager.AddSpell(this);
		SoundManager.StopMusic(BgmType.BGM_Secret);
		PlayerOptionsData config = _playerOptions.Config;
		SpellsManager._003CCachedStageType_003Ek__BackingField = (StageType?)(object)1;
		PlayerOptionsData config2 = _playerOptions.Config;
		SpellsManager._003CCachedCharacterType_003Ek__BackingField = (CharacterType?)(object)1;
		PlayerOptionsData config3 = _playerOptions.Config;
		SpellsManager._003CCachedBgmMod_003Ek__BackingField = (BgmModType?)(object)1;
		PlayerOptionsData config4 = _playerOptions.Config;
		SpellsManager._003CCachedBgm_003Ek__BackingField = (BgmType?)(object)1;
		PlayerOptionsData config5 = _playerOptions.Config;
		config5._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Gatti;
		PlayerOptionsData config6 = _playerOptions.Config;
		config6._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Hyper;
		PlayerOptionsData config7 = _playerOptions.Config;
		config7.SelectedCharacter = CharacterType.TATANKA;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B670");
	}

	public unsafe void Activate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0047: Expected O, but got Ref
		//IL_00ac: Expected O, but got Ref
		//IL_0111: Expected O, but got Ref
		//IL_0188: Expected I, but got O
		//IL_01d8: Expected O, but got I4
		//IL_01e1: Expected O, but got I4
		//IL_0452: Expected I, but got O
		//IL_0288: Expected I, but got O
		//IL_02d9: Expected O, but got I4
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0347: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		_ = gameSessionData._activeCharacter;
		_ = 91;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B720");
		_ = 0;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData2 = core2._gameSessionData;
		_ = gameSessionData2._activeCharacter;
		_ = 34;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B720");
		_ = 0;
		GameManager core3 = GM.Core;
		GameSessionData gameSessionData3 = core3._gameSessionData;
		_ = gameSessionData3._activeCharacter;
		_ = 61;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B810");
		GameManager core4 = GM.Core;
		core4._stage.DebugSpawnDestructibles();
		if ((object)GM.Core != null)
		{
			object[] array = new object[10];
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ rcx_v20 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core5 = GM.Core;
			GameSessionData gameSessionData4 = core5._gameSessionData;
			float2 position = gameSessionData4._activeCharacter.position;
			object obj6 = 0;
			object obj7 = 0;
			Vector2 pos = default(Vector2);
			object obj9 = default(object);
			object value = default(object);
			while (true)
			{
				nint num3 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
				float num4 = 0f * ((float)Math.PI * 3f / 5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
				float num5 = 0f * ((float)Math.PI * 3f / 5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(ItemType.CLOVER))
				{
					break;
				}
				Pickup pickup = PickupManager.CreatePickup(pos, ItemType.CLOVER);
				pickup._goToPlayer = true;
				PhysicsManager sInstance = PhysicsManager._sInstance;
				Group obj8 = sInstance._goToPlayerPickupGroup.add(pickup);
				PhysicsManager sInstance2 = PhysicsManager._sInstance;
				sInstance2._pickupGroup.remove(pickup);
				pickup.Time = 1f;
				nint num6 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rax_v52 (Il2CppClass<System.Object[]>)+40]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj9 != null)
				{
					array[obj6] = pickup;
					obj7 = 0;
					obj6++;
					if ((nint)obj6 >= 10)
					{
						TweenConfig tweenConfig = new TweenConfig();
						tweenConfig.targets = array;
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						_ = 1065353216;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Time", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig.custom = dictionary;
						tweenConfig.duration = 16f;
						Func<int, float> staggerDelay = Tweens.Stagger(100f);
						tweenConfig.staggerDelay = staggerDelay;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						return;
					}
					continue;
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		throw new NullReferenceException();
	}

	public void Deactivate()
	{
	}
}
