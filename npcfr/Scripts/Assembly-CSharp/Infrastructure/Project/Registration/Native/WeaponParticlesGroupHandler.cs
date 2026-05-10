using System;
using System.Runtime.CompilerServices;
using Components.Particles.SingleShot;
using Spawnables.Weapons;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native
{
	[Serializable]
	public class WeaponParticlesGroupHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private SingleShotParticleSystem m_viper17ShootMuzzleFlash;

		[SerializeField]
		private SingleShotParticleSystem m_viper17ShootSmoke;

		[SerializeField]
		private SingleShotParticleSystem m_viper17ShootSparkles;

		[SerializeField]
		private PostShootSmoke m_viper17PostShootSmoke;

		[SerializeField]
		private SingleShotParticleSystem m_viper17SlowShootSparkles;

		public PrefabPassport<SingleShotParticleSystem> sxr
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

		public PrefabPassport<SingleShotParticleSystem> sxs
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

		public PrefabPassport<SingleShotParticleSystem> sxt
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

		public PrefabPassport<PostShootSmoke> sxu
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

		public PrefabPassport<SingleShotParticleSystem> sxv
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

		private void itx()
		{
		}
	}
}
