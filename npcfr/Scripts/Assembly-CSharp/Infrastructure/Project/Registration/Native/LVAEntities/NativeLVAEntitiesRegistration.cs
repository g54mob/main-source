using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native.LVAEntities
{
	public class NativeLVAEntitiesRegistration : bgg, bgm
	{
		[SerializeField]
		private HumanGroupHandler m_humanGroupHandler;

		[SerializeField]
		private CameraGroupHandler m_cameraGroupHandler;

		public HumanGroupHandler xnb => null;

		public CameraGroupHandler xnc => null;

		protected override List<NativePrefabsGroupHandler> iso()
		{
			return null;
		}
	}
}
