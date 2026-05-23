using Infrastructure.Project.Installers.AssetsHandlers.SFX;
using UnityEngine;
using Zenject;

namespace Spawnables.Bullets
{
	[RequireComponent(typeof(Rigidbody))]
	public class PistolBullet : g
	{
		private bfc rdp;

		[SerializeField]
		private Rigidbody m_rigidbody;

		[SerializeField]
		private Collider m_collider;

		[SerializeField]
		private TrailRenderer m_trailRenderer;

		[SerializeField]
		private GameObject m_model;

		private bool rdq;

		private const int rdr = 10000;

		private const int rds = 1;

		private int rdt;

		private Vector3 rdu;

		private Vector3 rdv;

		private float rdw;

		private Vector3 rdx;

		private const float rdy = 200f;

		private bool rdz;

		public Rigidbody xdp => null;

		[Inject]
		private void gfj(bfc a)
		{
		}

		protected override void cxh()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void gfl(Collision a)
		{
		}

		private void gfm(bjd a, biw b)
		{
		}

		private void gfn(bool a = true)
		{
		}

		private void gfo(Vector3 a, Rigidbody b, float c, float d)
		{
		}

		private static float gfp(float a, float b)
		{
			return 0f;
		}

		private void gfq(Vector3 a, Collision b, Vector3 c)
		{
		}

		private void gfr(float a)
		{
		}

		private void gfs(Vector3 a, Collision b, Vector3 c)
		{
		}

		private float gft()
		{
			return 0f;
		}

		private void gfu()
		{
		}

		private void gfv(ImpactSFXType a, float b, float c)
		{
		}
	}
}
