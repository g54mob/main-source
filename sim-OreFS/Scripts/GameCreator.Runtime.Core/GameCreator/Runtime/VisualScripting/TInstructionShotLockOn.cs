using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconShotLockOn), ColorTheme.Type.Yellow)]
	public abstract class TInstructionShotLockOn : TInstructionShot
	{
		protected override int SystemID => ShotSystemLockOn.ID;
	}
}
