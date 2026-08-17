using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_Reroll_Dice : Pickup
{
	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public unsafe override void GetTaken()
	{
		//IL_00d2: Expected O, but got Ref
		//IL_00fc: Expected O, but got I4
		//IL_012b: Expected F4, but got O
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + base._003CValue_003Ek__BackingField;
			playerStats._003CReRolls_003Ek__BackingField = eggFloat2;
			base.SetHasSeenItem();
			base.AddToRunPickups();
			base.GetTaken();
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Dice", "1", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 2000f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, (float)characterController);
		}
	}
}
