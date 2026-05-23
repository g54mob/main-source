using System;
using System.Runtime.CompilerServices;
using Spawnables.Weapons;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	[Serializable]
	public class NativeWeaponsGroupHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private Glock17 m_glock17;

		public PrefabPassport<Glock17> sxy
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

		[field: SerializeField]
		public NativeBulletsGroupHandler Bullets { get; private set; }

		protected override void ist(bgd a)
		{
		}

		public override void isj()
		{
		}
	}
}
