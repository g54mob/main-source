using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Passive_CharmUp : CharacterSkillCard_Base
{
	public SubSkillCard_Passive_CharmUp(ArcanaType type)
		: base(type)
	{
	}

	public unsafe override void InitialActivate()
	{
		//IL_0097: Expected O, but got Ref
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		int num = playerStats._003CCharm_003Ek__BackingField + 50;
		playerStats._003CCharm_003Ek__BackingField = num;
		GameManager core = GM.Core;
		core._stage.RecalculateCurseAndCharm();
		GameManager core2 = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		core2._gizmoManager.DisplayIconOverhead("Apoplexy", "50", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset, textureName);
	}
}
