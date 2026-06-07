using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotFirstPerson), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotNoise : TInstructionShot
	{
		protected override int SystemID => ShotSystemNoise.ID;
	}
}
