using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotFirstPerson), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotHeadBobbing : TInstructionShot
	{
		protected override int SystemID => ShotSystemHeadBobbing.ID;
	}
}
