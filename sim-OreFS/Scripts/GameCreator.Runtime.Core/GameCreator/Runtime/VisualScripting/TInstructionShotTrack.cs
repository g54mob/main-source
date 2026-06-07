using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotTrack), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotTrack : TInstructionShot
	{
		protected override int SystemID => ShotSystemTrack.ID;
	}
}
