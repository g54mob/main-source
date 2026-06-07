using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotFollow), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotFollow : TInstructionShot
	{
		protected override int SystemID => ShotSystemFollow.ID;
	}
}
