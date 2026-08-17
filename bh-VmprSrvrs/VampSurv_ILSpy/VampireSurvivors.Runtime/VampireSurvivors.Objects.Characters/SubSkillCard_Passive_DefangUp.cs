using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Passive_DefangUp : CharacterSkillCard_Base
{
	public SubSkillCard_Passive_DefangUp(ArcanaType type)
		: base(type)
	{
	}

	public unsafe override void InitialActivate()
	{
		//IL_007d: Expected O, but got Ref
		base.InitialActivate();
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		float num = playerStats._003CDefang_003Ek__BackingField + 0.15f;
		playerStats._003CDefang_003Ek__BackingField = num;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		CharacterController character = default(CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		core._gizmoManager.DisplayIconOverhead("Antidote", "15", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset, textureName);
	}
}
