using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Framework.Cheats;

public class GameplayCheatCodeManager : CheatCodeManager
{
	private GameManager _gameManager;

	private bool _hasPetTheGoodDoggy;

	private void Construct(GameManager gameManager)
	{
		_gameManager = gameManager;
	}

	public override void InternalUpdate()
	{
		CheckForCheatCodeComboActivation();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C04]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_player.GetButton("LeftTrigger") && _player.GetButton("RightTrigger"))
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._selectedChar == CharacterType.TATANKA && !_hasPetTheGoodDoggy)
			{
				_hasPetTheGoodDoggy = true;
				VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
				_gameManager.DoPraise(playerOne);
			}
		}
	}

	private void CheckForControllerPet()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C04]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_player.GetButton("LeftTrigger") && _player.GetButton("RightTrigger"))
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._selectedChar == CharacterType.TATANKA && !_hasPetTheGoodDoggy)
			{
				_hasPetTheGoodDoggy = true;
				VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
				_gameManager.DoPraise(playerOne);
			}
		}
	}

	protected override void AddCheatCodeCombos()
	{
		//IL_024a: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_02a4: Expected O, but got I
		//IL_00d8: Expected O, but got I
		//IL_0583: Expected O, but got I
		//IL_0533: Expected O, but got I
		//IL_030e: Expected O, but got I
		//IL_0142: Expected O, but got I
		//IL_05ab: Expected O, but got I
		//IL_055b: Expected O, but got I
		//IL_0378: Expected O, but got I
		//IL_01ac: Expected O, but got I
		//IL_05d3: Expected O, but got I
		//IL_03e2: Expected O, but got I
		//IL_05fb: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_0623: Expected O, but got I
		//IL_04b6: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		if (config._selectedChar == CharacterType.TATANKA)
		{
			CheatCodeCombo cheatCodeCombo = new CheatCodeCombo();
			List<KeyCode> list = new List<KeyCode>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v33+18]");
			if (num >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)112);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 112;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v35+18]");
			if (num2 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)101);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
				object obj4 = (nint)0 + (nint)1;
				_ = 101;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v37+18]");
			if (num3 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)116);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v54 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
				object obj6 = (nint)0 + (nint)1;
				_ = 116;
			}
			cheatCodeCombo.Combo = list;
			Action onComboComplete = PraiseTheGoodDoggy;
			cheatCodeCombo.OnComboComplete = onComboComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		}
		CheatCodeCombo cheatCodeCombo2 = new CheatCodeCombo();
		List<KeyCode> list2 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v6+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)104);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 104;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v8+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)117);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 117;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v10+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)109);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 109;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v12+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)98);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 98;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v11+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)117);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 117;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v16+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)103);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 103;
		}
		cheatCodeCombo2.Combo = list2;
		Action onComboComplete2 = UnlockHumbug;
		cheatCodeCombo2.OnComboComplete = onComboComplete2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
	}

	private void PraiseTheGoodDoggy()
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (config._selectedChar == CharacterType.TATANKA && !_hasPetTheGoodDoggy)
		{
			_hasPetTheGoodDoggy = true;
			VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
			_gameManager.DoPraise(playerOne);
		}
	}

	private void UnlockHumbug()
	{
		if (GameManager.Tflag == 7)
		{
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				_playerOptions.UnlockCharacter(CharacterType.SMITH);
				_playerOptions.RevealCharacter(CharacterType.SMITH);
				_playerOptions.BuyCharacter(CharacterType.SMITH);
			}
			_playerOptions.Save();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Detune = -1000f;
			soundConfig.Rate = 0.5f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
		}
	}
}
