using System;
using System.Runtime.CompilerServices;
using Spawnables.Misc;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	[Serializable]
	public class NativeMiscGroupHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private HumanSpawner m_humanSpawner;

		public PrefabPassport<HumanSpawner> sxx
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
