using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Follow Track")]
	[Category("Follow Track")]
	[Image(typeof(IconShotTrack), ColorTheme.Type.Blue)]
	[Description("Follows the target from along a pre-defined path segment")]
	public class ShotTypeTrack : TShotTypeLook
	{
		[SerializeField]
		private ShotSystemTrack m_ShotSystemTrack;

		public ShotSystemTrack Track => m_ShotSystemTrack;

		public override Vector3 Position { get; set; }

		public override Quaternion Rotation { get; set; }

		public ShotTypeTrack()
		{
			m_ShotSystemTrack = new ShotSystemTrack();
			m_ShotSystems.Add(m_ShotSystemLook.Id, m_ShotSystemLook);
			m_ShotSystems.Add(m_ShotSystemTrack.Id, m_ShotSystemTrack);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_ShotSystemTrack.OnUpdate(this);
		}
	}
}
