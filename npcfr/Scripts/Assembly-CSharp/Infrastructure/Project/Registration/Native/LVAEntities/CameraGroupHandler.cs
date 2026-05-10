using System;
using System.Runtime.CompilerServices;
using LVA.Creatures.Implementations;
using LVA.Limbs.Variants;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native.LVAEntities
{
	[Serializable]
	public class CameraGroupHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private AutomaticCctvCamera m_camera;

		[SerializeField]
		private WallBracket m_wallBracket;

		[SerializeField]
		private AutoCameraBody m_cameraBody;

		public PrefabPassport<AutomaticCctvCamera> syc
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public PrefabPassport<WallBracket> syd
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public PrefabPassport<AutoCameraBody> sye
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public override void isj()
		{
		}
	}
}
