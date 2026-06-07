using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Follow Target")]
	[Category("Follow Target")]
	[Image(typeof(IconShotFollow), ColorTheme.Type.Blue)]
	[Description("Follows the target from a certain distance")]
	public class ShotTypeFollow : TShotTypeLook
	{
		[SerializeField]
		private ShotSystemFollow m_ShotSystemFollow;

		public ShotSystemFollow Follow => m_ShotSystemFollow;

		public ShotTypeFollow()
		{
			m_ShotSystemFollow = new ShotSystemFollow();
			m_ShotSystems.Add(m_ShotSystemLook.Id, m_ShotSystemLook);
			m_ShotSystems.Add(m_ShotSystemFollow.Id, m_ShotSystemFollow);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_ShotSystemFollow.OnUpdate(this);
		}
	}
}
