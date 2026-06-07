using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotLook : TInstructionShot
	{
		protected override int SystemID => ShotSystemLook.ID;
	}
}
