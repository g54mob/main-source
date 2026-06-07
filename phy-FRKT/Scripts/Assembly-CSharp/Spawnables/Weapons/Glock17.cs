using System;
using System.Runtime.CompilerServices;
using Core.MeshData;
using Spawnables.Bullets;
using UnityEngine;
using Zenject;

namespace Spawnables.Weapons
{
	public class Glock17 : g, ISpawnableObject, hm, hj
	{
		[SerializeField]
		private Transform m_muzzlePivot;

		[SerializeField]
		private Transform m_boltTransform;

		[SerializeField]
		private Transform m_shellEjectionPointTransform;

		[SerializeField]
		private PistolBullet m_bullet;

		[SerializeField]
		private Glock17MuzzleParticlesPipeline m_muzzleParticlesPipeline;

		[SerializeField]
		private WeaponBoltMovement m_weaponBoltMovement;

		[SerializeField]
		private ShellsEjectionController m_shellsEjectionController;

		[Range(10f, 30000f)]
		[SerializeField]
		private float m_launchSpeed;

		[SerializeField]
		private AudioClip m_shootSoundClip;

		[SerializeField]
		private AudioSource m_shootSound;

		[SerializeField]
		private MeshDataHandler m_meshDataHandler;

		private readonly float raq;

		private float rar;

		private bkp ras;

		private bfc rat;

		private bhp rau;

		private bool rav;

		public pp raw
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

		public MeshDataHandler xdm => null;

		public event Action rap
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void gdc(hd a, bhp b, bfc c)
		{
		}

		protected override void cxh()
		{
		}

		public void gdh()
		{
		}

		public void gdi()
		{
		}

		public void ekf()
		{
		}

		public void gdj()
		{
		}

		private void gdk()
		{
		}

		private void gdl(Vector3 a)
		{
		}

		private bool gdm()
		{
			return false;
		}

		protected override void cxl()
		{
		}
	}
}
