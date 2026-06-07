using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotThirdPerson), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotZoom : TInstructionShot
	{
		protected override int SystemID => ShotSystemZoom.ID;
	}
}
