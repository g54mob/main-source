using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters;

public class TP_MegaloDracula_Character : TP_Dracula_Character
{
	private bool firstUpdateDone;

	protected override void OnUpdate()
	{
		OnUpdate();
		if (!firstUpdateDone && _isInitialized)
		{
			firstUpdateDone = true;
			Morph(addBonusStats: false);
		}
	}

	public TP_MegaloDracula_Character()
	{
		List<PhaserSprite> megaloSprites = new List<PhaserSprite>();
		base._megaloSprites = megaloSprites;
		((CharacterController)this)._002Ector();
	}
}
