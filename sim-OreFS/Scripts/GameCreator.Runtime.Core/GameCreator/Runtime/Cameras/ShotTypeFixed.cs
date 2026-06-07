using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Fixed Position")]
	[Category("Fixed Position")]
	[Image(typeof(IconShotFixed), ColorTheme.Type.Blue)]
	[Description("The Camera is locked in place but can pivot around itself")]
	public class ShotTypeFixed : TShotTypeLook
	{
		public ShotTypeFixed()
		{
			m_ShotSystems.Add(m_ShotSystemLook.Id, m_ShotSystemLook);
		}
	}
}
